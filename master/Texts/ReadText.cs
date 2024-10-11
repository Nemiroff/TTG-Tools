﻿using System;
using System.Collections.Generic;
using System.Text;
using System.IO;
using TTG_Tools.ClassesStructs.Text;
using System.Windows.Forms;

namespace TTG_Tools.Texts
{
    public class ReadText
    {
        private static int GetType(string FilePath)
        {
            FileInfo fi = new FileInfo(FilePath);

            if (fi.Extension.ToLower() == ".tsv") return 1;

            string[] strs = File.ReadAllLines(fi.FullName, Encoding.UTF8);
            if(strs.Length >= 5)
            {
                if ((strs[0].IndexOf("langid=") == 0) && (strs[1].IndexOf("actor=") == 0) && (strs[2].IndexOf("speechOriginal=") == 0) && (strs[3].IndexOf("speechTranslation=") == 0) && (strs[4].IndexOf("flags=") == 0))
                {
                    return 2;
                }
            }
            
            return 0;
        }

        private static List<CommonText> OldTextMode(string FilePath)
        {
            List<CommonText> txts = new List<CommonText>();
            FileStream fs = new FileStream(FilePath, FileMode.Open);
            StreamReader sr = new StreamReader(fs, Encoding.UTF8);

            try
            {
                CommonText tmpTxt;
                bool hasNumber = false;
                int prevNum = -1;
                int curNum = -1;
                string tmpString = "";
                int lastListIndex = -1;

                while (!sr.EndOfStream)
                {
                    tmpString = sr.ReadLine();

                    if (tmpString.IndexOf(")") > -1 && !hasNumber)
                    {
                        if(Methods.IsNumeric(tmpString.Substring(0, tmpString.IndexOf(")"))))
                        {
                            curNum = Convert.ToInt32(tmpString.Substring(0, tmpString.IndexOf(")")));
                            tmpTxt.isBothSpeeches = false;

                            if(curNum == prevNum)
                            {
                                lastListIndex = txts.Count - 1;

                                tmpTxt.strNumber = txts[lastListIndex].strNumber;
                                tmpTxt.isBothSpeeches = true;
                                tmpTxt.actorName = txts[lastListIndex].actorName;
                                tmpTxt.actorSpeechOriginal = txts[lastListIndex].actorSpeechOriginal;
                                tmpTxt.actorSpeechTranslation = "";
                                tmpTxt.flags = txts[lastListIndex].flags;
                                txts[lastListIndex] = tmpTxt;
                            }

                            try
                            {
                                tmpTxt.strNumber = (uint)curNum;
                                int numPos = tmpString.IndexOf(")") + 2;
                                tmpTxt.actorName = tmpString.Substring(numPos, tmpString.Length - numPos);
                                tmpTxt.actorSpeechOriginal = "";
                                tmpTxt.actorSpeechTranslation = "";
                                tmpTxt.flags = "";

                                if (!tmpTxt.isBothSpeeches) txts.Add(tmpTxt);

                                hasNumber = true;
                                prevNum = curNum;
                                lastListIndex = txts.Count - 1;
                            }
                            catch
                            {
                                MessageBox.Show("Error in string \"" + tmpString + "\".", "Error");
                                if (sr != null) sr.Close();
                                if (fs != null) fs.Close();

                                return null;
                            }
                        }
                        else
                        {
                            tmpTxt.strNumber = txts[lastListIndex].strNumber;
                            tmpTxt.isBothSpeeches = txts[lastListIndex].isBothSpeeches;
                            tmpTxt.actorName = txts[lastListIndex].actorName;
                            tmpTxt.actorSpeechOriginal = txts[lastListIndex].actorSpeechOriginal;
                            tmpTxt.actorSpeechTranslation = txts[lastListIndex].actorSpeechTranslation;
                            tmpTxt.flags = txts[lastListIndex].flags;

                            if (!txts[lastListIndex].isBothSpeeches)
                            {
                                tmpTxt.actorSpeechOriginal += "\r\n" + tmpString;
                                tmpTxt.actorSpeechTranslation = tmpTxt.actorSpeechOriginal;
                            }
                            else
                            {
                                tmpTxt.actorSpeechTranslation += "\r\n" + tmpString;
                            }

                            txts[lastListIndex] = tmpTxt;

                            hasNumber = false;
                        }
                    }
                    else
                    {
                        tmpTxt.strNumber = txts[lastListIndex].strNumber;
                        tmpTxt.isBothSpeeches = txts[lastListIndex].isBothSpeeches;
                        tmpTxt.actorName = txts[lastListIndex].actorName;
                        tmpTxt.actorSpeechOriginal = txts[lastListIndex].actorSpeechOriginal;
                        tmpTxt.actorSpeechTranslation = txts[lastListIndex].actorSpeechTranslation;
                        tmpTxt.flags = txts[lastListIndex].flags;

                        if (!txts[lastListIndex].isBothSpeeches)
                        {
                            tmpTxt.actorSpeechOriginal += "\r\n" + tmpString;
                            tmpTxt.actorSpeechTranslation = tmpTxt.actorSpeechOriginal;
                        }
                        else
                        {
                            tmpTxt.actorSpeechTranslation += "\r\n" + tmpString;
                        }

                        txts[lastListIndex] = tmpTxt;

                        hasNumber = false;
                    }
                }

                sr.Close();
                fs.Close();

                return txts;
            }
            catch
            {
                if(sr != null) sr.Close();
                if(fs != null) fs.Close();

                return null;
            }
        }

        private static List<CommonText> TsvTextMode(string FilePath)
        {
            List<CommonText> txts = new List<CommonText>();
            FileStream fs = new FileStream(FilePath, FileMode.Open);
            StreamReader sr = new StreamReader(fs, Encoding.UTF8);

            try
            {
                string tmpString = "";
                string[] tmpStrs;
                CommonText tmpTxt;

                while(!sr.EndOfStream)
                {
                    tmpString = sr.ReadLine();
                    tmpStrs = tmpString.Split('\t');

                    if((tmpStrs.Length) > 0 && ((tmpStrs.Length == 3) || (tmpStrs.Length == 4)))
                    {
                        try
                        {
                            tmpTxt.strNumber = Convert.ToUInt32(tmpStrs[0]);
                            tmpTxt.isBothSpeeches = tmpStrs.Length == 4;
                            tmpTxt.actorName = tmpStrs[1];
                            tmpTxt.actorSpeechOriginal = tmpStrs[2];
                            tmpTxt.actorSpeechTranslation = tmpStrs.Length == 4 ? tmpStrs[3] : tmpTxt.actorSpeechOriginal;
                            tmpTxt.flags = "";

                            if (tmpTxt.actorSpeechOriginal.Contains("\\r")) tmpTxt.actorSpeechOriginal = tmpTxt.actorSpeechOriginal.Replace("\\r", "\r");
                            if (tmpTxt.actorSpeechOriginal.Contains("\n")) tmpTxt.actorSpeechOriginal = tmpTxt.actorSpeechOriginal.Replace("\\n", "\n");
                            if (tmpTxt.actorSpeechOriginal.Contains("\t")) tmpTxt.actorSpeechOriginal = tmpTxt.actorSpeechOriginal.Replace("\\t", "\t");

                            if (tmpTxt.actorSpeechTranslation.Contains("\\r")) tmpTxt.actorSpeechTranslation = tmpTxt.actorSpeechTranslation.Replace("\\r", "\r");
                            if (tmpTxt.actorSpeechTranslation.Contains("\n")) tmpTxt.actorSpeechTranslation = tmpTxt.actorSpeechTranslation.Replace("\\n", "\n");
                            if (tmpTxt.actorSpeechTranslation.Contains("\t")) tmpTxt.actorSpeechTranslation = tmpTxt.actorSpeechTranslation.Replace("\\t", "\t");

                            txts.Add(tmpTxt);
                        }
                        catch
                        {
                            MessageBox.Show("Error in string \"" + tmpString + "\".", "Error");

                            if (sr != null) sr.Close();
                            if (fs != null) fs.Close();

                            return null;
                        }
                    }
                    else
                    {
                        MessageBox.Show("Error in string \"" + tmpString + "\".", "Error");

                        if (sr != null) sr.Close();
                        if (fs != null) fs.Close();

                        return null;
                    }
                }

                sr.Close();
                fs.Close();

                return txts;
            }
            catch
            {
                if (sr != null) sr.Close();
                if (fs != null) fs.Close();

                return null;
            }
        }

        private static List<CommonText> NewTextMode(string FilePath)
        {
            List<CommonText> txts = new List<CommonText>();
            FileStream fs = new FileStream(FilePath, FileMode.Open);
            StreamReader sr = new StreamReader(fs, Encoding.UTF8);

            try
            {
                string tmpString = "";
                CommonText tmpTxt;

                while (!sr.EndOfStream)
                {
                    tmpTxt.strNumber = 0;
                    tmpTxt.isBothSpeeches = true;
                    tmpTxt.actorName = "";
                    tmpTxt.actorSpeechOriginal = "";
                    tmpTxt.actorSpeechTranslation = "";
                    tmpTxt.flags = "";

                    for(int i = 0; i < 5; i++)
                    {
                        tmpString = sr.ReadLine();

                        switch(i)
                        {
                            case 0:
                                if (tmpString.IndexOf("langid=") != 0) throw new Exception("Error in string " + tmpString + ".");
                                try
                                {
                                    tmpString = tmpString.Substring(7, tmpString.Length - 7);
                                    tmpTxt.strNumber = Convert.ToUInt32(tmpString);
                                }
                                catch
                                {
                                    MessageBox.Show("Something wrong with file\r\n" + FilePath);

                                    if (sr != null) sr.Close();
                                    if (fs != null) fs.Close();

                                    return null;
                                }
                                break;

                            case 1:
                                if (tmpString.IndexOf("actor=") != 0) throw new Exception("Error in string " + tmpString + ".");

                                try
                                {
                                    tmpTxt.actorName = tmpString.Substring(6, tmpString.Length - 6);
                                }
                                catch
                                {
                                    MessageBox.Show("Something wrong with file\r\n" + FilePath);

                                    if (sr != null) sr.Close();
                                    if (fs != null) fs.Close();

                                    return null;
                                }
                                break;

                            case 2:
                                if (tmpString.IndexOf("speechOriginal=") != 0) throw new Exception("Error in string " + tmpString + ".");

                                try
                                {
                                    tmpTxt.actorSpeechOriginal = tmpString.Substring(15, tmpString.Length - 15);
                                }
                                catch
                                {
                                    MessageBox.Show("Something wrong with file\r\n" + FilePath);

                                    if (sr != null) sr.Close();
                                    if (fs != null) fs.Close();

                                    return null;
                                }
                                break;

                            case 3:
                                if (tmpString.IndexOf("speechTranslation=") != 0) throw new Exception("Error in string " + tmpString + ".");

                                try
                                {
                                    tmpTxt.actorSpeechTranslation = tmpString.Substring(18, tmpString.Length - 18);
                                }
                                catch
                                {
                                    MessageBox.Show("Something wrong with file\r\n" + FilePath);

                                    if (sr != null) sr.Close();
                                    if (fs != null) fs.Close();

                                    return null;
                                }
                                break;

                            case 4:
                                if (tmpString.IndexOf("flags=") != 0) throw new Exception("Error in string " + tmpString + ".");

                                try
                                {
                                    tmpTxt.flags = tmpString.Substring(6, tmpString.Length - 6);
                                }
                                catch
                                {
                                    MessageBox.Show("Something wrong with file\r\n" + FilePath);

                                    if (sr != null) sr.Close();
                                    if (fs != null) fs.Close();

                                    return null;
                                }
                                break;
                        }
                    }

                    txts.Add(tmpTxt);
                    tmpString = sr.ReadLine();
                }

                sr.Close();
                fs.Close();

                return txts;
            }
            catch(Exception ex)
            {
                MessageBox.Show(ex.Message, "Error");

                if (sr != null) sr.Close();
                if (fs != null) fs.Close();

                return null;
            }
        }

        public static List<CommonText> GetStrings(string FilePath)
        {
            List<CommonText> strings = new List<CommonText>();
            int type = GetType(FilePath);

            switch(type)
            {
                case 0:
                    strings = OldTextMode(FilePath);

                    for (int i = 0; i < strings.Count; i++)
                    {
                        CommonText tmpTxt = strings[i];
                        tmpTxt.actorSpeechOriginal = strings[i].actorSpeechOriginal.Substring(2, strings[i].actorSpeechOriginal.Length - 2);
                        tmpTxt.actorSpeechTranslation = strings[i].actorSpeechTranslation.Substring(2, strings[i].actorSpeechTranslation.Length - 2);

                        if (tmpTxt.actorSpeechOriginal.Contains("\r\n")) tmpTxt.actorSpeechOriginal = tmpTxt.actorSpeechOriginal.Replace("\r\n", "\n");
                        if (tmpTxt.actorSpeechTranslation.Contains("\r\n")) tmpTxt.actorSpeechTranslation = tmpTxt.actorSpeechTranslation.Replace("\r\n", "\n");

                        strings[i] = tmpTxt;
                    }
                    break;

                case 1:
                    strings = TsvTextMode(FilePath);

                    for(int i = 0; i < strings.Count; i++)
                    {
                        CommonText tmpTxt = strings[i];

                        if (tmpTxt.actorSpeechTranslation.Contains("\\t")) tmpTxt.actorSpeechTranslation = tmpTxt.actorSpeechTranslation.Replace("\\t", "\t");
                        if (tmpTxt.actorSpeechTranslation.Contains("\\r")) tmpTxt.actorSpeechTranslation = tmpTxt.actorSpeechTranslation.Replace("\\r", "\r");
                        if (tmpTxt.actorSpeechTranslation.Contains("\\n")) tmpTxt.actorSpeechTranslation = tmpTxt.actorSpeechTranslation.Replace("\\n", "\n");

                        if (tmpTxt.actorSpeechOriginal.Contains("\\t")) tmpTxt.actorSpeechOriginal = tmpTxt.actorSpeechOriginal.Replace("\\t", "\t");
                        if (tmpTxt.actorSpeechOriginal.Contains("\\r")) tmpTxt.actorSpeechOriginal = tmpTxt.actorSpeechOriginal.Replace("\\r", "\r");
                        if (tmpTxt.actorSpeechOriginal.Contains("\\n")) tmpTxt.actorSpeechOriginal = tmpTxt.actorSpeechOriginal.Replace("\\n", "\n");

                        strings[i] = tmpTxt;
                    }
                    break;

                case 2:
                    strings = NewTextMode(FilePath);

                    for (int i = 0; i < strings.Count; i++)
                    {
                        CommonText tmpTxt = strings[i];

                        if (tmpTxt.actorSpeechTranslation.Contains("\\t")) tmpTxt.actorSpeechTranslation = tmpTxt.actorSpeechTranslation.Replace("\\t", "\t");
                        if (tmpTxt.actorSpeechTranslation.Contains("\\r")) tmpTxt.actorSpeechTranslation = tmpTxt.actorSpeechTranslation.Replace("\\r", "\r");
                        if (tmpTxt.actorSpeechTranslation.Contains("\\n")) tmpTxt.actorSpeechTranslation = tmpTxt.actorSpeechTranslation.Replace("\\n", "\n");

                        if (tmpTxt.actorSpeechOriginal.Contains("\\t")) tmpTxt.actorSpeechOriginal = tmpTxt.actorSpeechOriginal.Replace("\\t", "\t");
                        if (tmpTxt.actorSpeechOriginal.Contains("\\r")) tmpTxt.actorSpeechOriginal = tmpTxt.actorSpeechOriginal.Replace("\\r", "\r");
                        if (tmpTxt.actorSpeechOriginal.Contains("\\n")) tmpTxt.actorSpeechOriginal = tmpTxt.actorSpeechOriginal.Replace("\\n", "\n");

                        strings[i] = tmpTxt;
                    }
                    break;
            }

            return strings;
        }
    }
}
