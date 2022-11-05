﻿using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using TTG_Tools.ClassesStructs.Text;
using System.IO;

namespace TTG_Tools.Texts
{
    public class LangdbWorker
    {
        public static LangdbClass GetStringsFromLangdb(BinaryReader br, bool hasFlags)
        {
            try
            {
                LangdbClass langdb = new LangdbClass();
                langdb.blockLength = 0;
                int checkBlockLength = br.ReadInt32();
                long checkSize = br.BaseStream.Length - br.BaseStream.Position + 4;

                langdb.isBlockLength = false;

                if (checkSize == checkBlockLength)
                {
                    langdb.blockLength = checkBlockLength;
                    langdb.isBlockLength = true;
                    langdb.langdbCount = br.ReadInt32();
                }
                else
                {
                    langdb.blockLength = -1;
                    langdb.isBlockLength = false;
                    langdb.langdbCount = checkBlockLength;
                }

                langdb.langdbs = new langdb[langdb.langdbCount];
                //if (hasFlags) langdb.flags = new ClassesStructs.FlagsClass.LangdbFlagClass[langdb.langdbCount];
                langdb.flags = new ClassesStructs.FlagsClass.LangdbFlagClass[langdb.langdbCount];

                for (int i = 0; i < langdb.langdbCount; i++)
                {
                    langdb.langdbs[i].stringNumber = (uint)(i + 1);
                    langdb.langdbs[i].anmID = br.ReadUInt32();
                    langdb.langdbs[i].voxID = br.ReadUInt32();

                    int blockSize = -1;

                    if (langdb.isBlockLength) blockSize = br.ReadInt32();
                    int stringLength = br.ReadInt32();
                    byte[] tmp = br.ReadBytes(stringLength);
                    langdb.langdbs[i].actorName = Encoding.GetEncoding(MainMenu.settings.ASCII_N).GetString(tmp);

                    if (langdb.isBlockLength) blockSize = br.ReadInt32();
                    stringLength = br.ReadInt32();
                    tmp = br.ReadBytes(stringLength);
                    langdb.langdbs[i].actorSpeech = Encoding.GetEncoding(MainMenu.settings.ASCII_N).GetString(tmp);
                    if ((langdb.langdbs[i].actorSpeech.IndexOf('\n') >= 0)
                        || (langdb.langdbs[i].actorSpeech.IndexOf("\r\n") >= 0))
                    {
                        if (langdb.langdbs[i].actorSpeech.IndexOf("\r\n") >= 0) langdb.langdbs[i].actorSpeech = langdb.langdbs[i].actorSpeech.Replace("\r\n", "\\r\\n");
                        else langdb.langdbs[i].actorSpeech = langdb.langdbs[i].actorSpeech.Replace("\n", "\\n");
                    }

                    if (langdb.isBlockLength) blockSize = br.ReadInt32();
                    stringLength = br.ReadInt32();
                    tmp = br.ReadBytes(stringLength);
                    langdb.langdbs[i].anmFile = Encoding.GetEncoding(MainMenu.settings.ASCII_N).GetString(tmp);

                    if (langdb.isBlockLength) blockSize = br.ReadInt32();
                    stringLength = br.ReadInt32();
                    tmp = br.ReadBytes(stringLength);
                    langdb.langdbs[i].voxFile = Encoding.GetEncoding(MainMenu.settings.ASCII_N).GetString(tmp);

                    /*if (hasFlags)
                    {*/
                        langdb.flags[i] = new ClassesStructs.FlagsClass.LangdbFlagClass();
                        langdb.flags[i].flags = br.ReadBytes(3);
                    //}

                    langdb.langdbs[i].zero = br.ReadInt32();
                }

                return langdb;
            }
            catch
            {
                return null;
            }
        }

        public static string DoWork(string InputFile, bool extract, bool FullEncrypt, ref byte[] EncKey, int version)
        {
            string result = "";

            FileInfo fi = new FileInfo(InputFile);

            byte[] buffer = File.ReadAllBytes(InputFile);
            MemoryStream ms = new MemoryStream(buffer);
            BinaryReader br = new BinaryReader(ms);

            try
            {
                byte[] checkHeader = br.ReadBytes(4);
                int countBlocks = br.ReadInt32();

                string[] classes = new string[countBlocks];

                bool hasFlags = false;
                byte[] checkBlock = br.ReadBytes(8);
                br.BaseStream.Seek(8, SeekOrigin.Begin);
                ulong checkCRC64 = 0;
                bool isHashStrings = false;

                if (BitConverter.ToString(checkBlock) == BitConverter.ToString(BitConverter.GetBytes(CRCs.CRC64(checkCRC64, InEngineWords.ClassStructsNames.langdbClass.ToLower()))))
                {
                    isHashStrings = true;

                    for (int i = 0; i < countBlocks; i++)
                    {
                        byte[] tmp = br.ReadBytes(8);
                        classes[i] = BitConverter.ToString(tmp);
                        if (classes[i].ToLower() == BitConverter.ToString(BitConverter.GetBytes(CRCs.CRC64(checkCRC64, InEngineWords.ClassStructsNames.flagsClass.ToLower())))) hasFlags = true;
                        tmp = br.ReadBytes(4); //Some values (in oldest games I found some values in *.vers files
                    }
                }
                else
                {
                    for (int i = 0; i < countBlocks; i++)
                    {
                        int len = br.ReadInt32();
                        byte[] tmp = br.ReadBytes(len);
                        classes[i] = Encoding.ASCII.GetString(tmp);
                        if (classes[i].ToLower() == "class flags") hasFlags = true;
                        tmp = br.ReadBytes(4); //Some values (in oldest games I found some values in *.vers files
                    }
                }

                LangdbClass langdbs = GetStringsFromLangdb(br, hasFlags);
                br.Close();
                ms.Close();

                buffer = null;

                if (langdbs == null)
                {
                    return "File " + fi.Name + ": unknown error.";
                }
                if (langdbs != null && langdbs.langdbCount == 0)
                {
                    langdbs = null;
                    GC.Collect();
                    return fi.Name + " is EMPTY.";
                }

                if(extract)
                {
                    //TO DO:
                    //Need to think about sort same strings!

                    if (File.Exists(MainMenu.settings.pathForOutputFolder + "\\" + fi.Name.Remove(fi.Name.Length - 6, 6) + "txt")) File.Delete(MainMenu.settings.pathForOutputFolder + "\\" + fi.Name.Remove(fi.Name.Length - 6, 6) + "txt");
                    FileStream fs = new FileStream(MainMenu.settings.pathForOutputFolder + "\\" + fi.Name.Remove(fi.Name.Length - 6, 6) + "txt", FileMode.CreateNew);
                    StreamWriter sw = new StreamWriter(fs, Encoding.UTF8);

                    for(int i = 0; i < langdbs.langdbCount; i++)
                    {
                        if (MainMenu.settings.exportRealID) sw.WriteLine(langdbs.langdbs[i].voxID + ") " + langdbs.langdbs[i].actorName);
                        else sw.WriteLine(langdbs.langdbs[i].stringNumber + ") " + langdbs.langdbs[i].actorName);
                        sw.WriteLine(langdbs.langdbs[i].actorSpeech);
                    }

                    sw.Close();
                    fs.Close();

                    result = fi.Name + " successfully extracted.";
                }
                else
                {

                }
            }
            catch
            {
                if(br != null) br.Close();
                if(ms != null) ms.Close();

                result = "Something wrong with langdb file " + fi.Name;
            }

            GC.Collect();
            return result;
        }
    }
}
