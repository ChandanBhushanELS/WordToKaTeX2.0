﻿using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Windows.Forms;
using System.IO;
using System.IO.Compression;
using IterateWordEquations;
using Microsoft.Office.Interop.Word;
using System.Diagnostics;
using Sys = System.IO;
using System.Text.RegularExpressions;
using MSWord = Microsoft.Office.Interop.Word;

namespace WordToKaTeX
{
    

    public partial class WordToKaTeX : Form
    {
        List<string> mathMLList = new List<string>();
        List<string> KatexList = new List<string>();
        string MathMLPath;
        string outputSolutionPath;
        string inputSolutionPath;
        string fpath;
        public WordToKaTeX()
        {
            InitializeComponent();
        }

        private void ConvertButton_Click(object sender, EventArgs e)
        {
            statusBox.Clear();
            ExtractMathTypes();

            //statusBox.Clear();
            //ExtractImages();

           // statusBox.Clear();
            //ReplaceMathTypesWithKaTeX();

            //statusBox.Clear();
            //DestroyDirs();

            MessageBox.Show("Done!","Word To KaTeX 2.0");

        }
        public void ExtractImages()
        {

        }
        public void DestroyDirs()
        {

        }
        public void ReplaceMathTypesWithKaTeX()
        {
            statusLabel.Text = "Replacing MathType with KaTeX...";
            int fileCounter = 0;
            inputSolutionPath = inputPathTextBox.Text + @"\";
            outputSolutionPath = outputPathTextBox.Text + @"\";
            DirectoryInfo di = new DirectoryInfo(inputSolutionPath.ToString());
            string texPath = outputSolutionPath + "KaTeXFiles";
            int tFiles = di.GetFiles("*.docx", SearchOption.AllDirectories).Length;
            statusBar.Minimum = 0;
            statusBar.Maximum = tFiles;
            //int tFiles = Directory.GetFiles(MathMLPath,".docx").Length;
            string[] allfiles = Directory.GetFiles(inputSolutionPath.ToString(), "*.docx", SearchOption.AllDirectories);

            MSWord.Application app = new MSWord.Application();
            foreach (string file in allfiles)
            {
                
                fileCounter += 1;
                statusBox.AppendText(Path.GetFileNameWithoutExtension(file) + Environment.NewLine);
                statusBar.Value = fileCounter;
               // List<MSWord.Range> ranges = new List<Microsoft.Office.Interop.Word.Range>();

                List<string> Mlist = new List<string>();
                string FILE_NAME = texPath + @"\" + Path.GetFileName(file).Replace(".docx", ".txt");
                //textBox1.AppendText(FILE_NAME + Environment.NewLine);
                string currLine = "";

                if (Sys.File.Exists(FILE_NAME) == true)
                {              
                    Sys.StreamReader objReader = new System.IO.StreamReader(FILE_NAME);

                    while (objReader.Peek() != -1)
                    {

                        currLine = objReader.ReadLine();
                        if (isChemistry.Checked)
                        {
                            currLine = currLine.Replace(@"\Xi", @"\overrightharpoon{\,_\leftharpoondown}");
                        }
                        //textBox1.AppendText(currLine + Environment.NewLine);
                        Mlist.Add(currLine);

                    }
                    objReader.Close();
                }





                for (int i = Mlist.Count-1; i >= 0; i--)
                {
                    statusBox.AppendText(Mlist[i].ToString() + Environment.NewLine);
                    //string replaceText = "MTI-" + (i).ToString();
                    
                    //textBox1.AppendText(replaceText + Mlist[i] + Environment.NewLine);
                }
                Mlist.Clear();

            }


        }

        public void ExtractMathTypes()
        {
            inputSolutionPath = inputPathTextBox.Text + @"\";
            outputSolutionPath = outputPathTextBox.Text + @"\";
            fpath = inputSolutionPath.ToString();
            MathMLPath = fpath;
            int count;
            int fileCounter = 0;
            try
            {
                //string MMLpath = outputSolutionPath + "/KaTeXFiles";

                //if (!Directory.Exists(MMLpath))
                //{
                //    Directory.CreateDirectory(MMLpath);
                //}

                string logPath = outputSolutionPath + "/Done Files/Logs";

                if (!Directory.Exists(logPath))
                {
                    Directory.CreateDirectory(logPath);
                }

                DirectoryInfo di = new DirectoryInfo(MathMLPath);

                int tFiles = di.GetFiles("*.docx", SearchOption.AllDirectories).Length;
                //int tFiles = Directory.GetFiles(MathMLPath,".docx").Length;
                string[] allfiles = Directory.GetFiles(MathMLPath, "*.docx", SearchOption.AllDirectories);

                MSWord.Application app = new MSWord.Application();


                using (StreamWriter er = new StreamWriter(logPath + "/" + "MathType-Error-Log.csv"))
                {

                    using (StreamWriter lr = new StreamWriter(logPath + "/" + "MathType-Conversion-Log.csv"))
                    {
                        DateTime now = DateTime.Now;
                        lr.WriteLine("Word to KaTeX - V-0.2.0.0");
                        //lr.WriteLine("Book code, Folder name,Number of files converted to KaTeX,Start time,End Time");
                        lr.WriteLine("Process start time:," + now.ToString("F"));
                        //lr.WriteLine("------------------------------------------------------------------");
                        foreach (string file in allfiles)
                        {
                            fileCounter += 1;
                            try
                            {
                                MSWord.Document doc = app.Documents.Open(file, ReadOnly: false);
                                statusBox.AppendText(Path.GetFileName(file).ToString().Replace(".docx", "").ToString() + "-" + "(" + fileCounter.ToString() + " of " + tFiles.ToString() + ")" + "-");
                                count = 0;
                                List<MSWord.Range> ranges = new List<Microsoft.Office.Interop.Word.Range>();
                                foreach (MSWord.Section sec in doc.Sections)
                                {
                                    foreach (MSWord.Paragraph para in sec.Range.Paragraphs)
                                    {
                                        foreach (InlineShape ishape in para.Range.InlineShapes)
                                        {
                                            try
                                            {
                                                if (ishape.OLEFormat.ProgID.StartsWith("Equation."))
                                                {
                                                    try
                                                    {
                                                        MathTypeEquation mobj = new MathTypeEquation(ishape.OLEFormat);
                                                        //textBox4.AppendText(mobj.LaTeX + Environment.NewLine);
                                                        mathMLList.Add(mobj.LaTeX);
                                                        mobj.Dispose();
                                                        ranges.Add(ishape.Range);
                                                        ishape.Delete();
                                                        
                                                        count++;
                                                    }
                                                    catch (NullReferenceException exce)
                                                    {

                                                        Console.WriteLine(exce.Message);
                                                        continue;
                                                    }
                                                    catch (Exception ex)
                                                    {
                                                        MessageBox.Show(ex.ToString() + Environment.NewLine + count.ToString());
                                                    }
                                                }
                                            }
                                            catch (NullReferenceException exce)
                                            {

                                                //Console.WriteLine(exce.Message);
                                                continue;
                                            }
                                            catch (Exception ex)
                                            {
                                                //Console.WriteLine(ex.Message);
                                                continue;
                                            }
                                        }

                                    }

                                    foreach (Process process in Process.GetProcessesByName("MathType"))
                                    {
                                        process.Kill();
                                    }
                                }

                               
                                //----------

                               // using (StreamWriter wr = new StreamWriter(MMLpath + "/" + Path.GetFileName(file).ToString().Replace(".docx", "") + ".txt"))
                                //{
                                    foreach (string item in mathMLList)
                                    {
                                        //.Replace("&", "")
                                        string citem = item.ToString().Replace(Environment.NewLine, "").Replace(@"\[", @"\(").Replace(@"\]", @"\)").Replace(@"\begin{align}", @"\begin{aligned}").Replace(@"\end{align}", @"\end{aligned}").Replace("{}", "").Replace("&", "").Replace("=", "&=").Replace("{&=}", "{=}");
                                        Regex regex = new Regex(@"text{(\s)*");
                                        foreach (Match ItemMatch in regex.Matches(citem))
                                        {
                                            string filler = String.Concat(Enumerable.Repeat(@"\,", (ItemMatch.Value.Length - 5)));
                                            textBox1.AppendText(citem + " <> " + ItemMatch.Value + "-" + "text{" + filler + Environment.NewLine);
                                            if (citem.Contains(ItemMatch.Value))
                                            {
                                                textBox1.AppendText("True" + Environment.NewLine);
                                            }
                                            var regex1 = new Regex(Regex.Escape(ItemMatch.Value));
                                            citem = regex1.Replace(citem, "text{" + filler, 1);
                                        }

                                        if (citem.Contains(@"\begin{matrix}"))
                                        {
                                            citem = citem.Replace(@"\begin{matrix}", @"\begin{array}{cccccccc}").Replace(@"\end{matrix}", @"\end{array}").Replace("   ", "").Replace("  ", "&&").Replace(@"&\\", @"\\\\").Replace("frac", "cfrac").Replace(@"&\\\\", @"\\\\").Replace(@"\\\\\end", @"\\\end").Replace("cdots", "cdots&&").Replace("vdots", "vdots&&").Replace("ddots", "ddots&&");
                                            er.WriteLine("WARNING! - " + Path.GetFileName(file).ToString() + ": Check if the matrix at index " + (mathMLList.IndexOf(item) + 1).ToString() + " in the solution file contains any verticle line or horizontal line in it. Please use the matrix guidelines for KaTeX to resolve the issue");
                                        }

                                        if (citem.ToString().Contains("aligned"))
                                        {
                                            //do nothing
                                            //citem = citem.Replace(").Replace(@"\ne", @"&\ne ");
                                        }
                                        else
                                        {
                                            citem = citem.Replace("&=", "=").Replace(@"&\ne", @"\ne");
                                        }

                                        //textBox3.AppendText(citem.Substring(0,2) + "-" + citem.Substring(citem.Length-2,2) + Environment.NewLine);
                                        //.Replace(" ", "")
                                        citem = citem.Replace(@"{\rm E}", @"\Epsilon").Replace(@"\varepsilon", @"\epsilon").Replace(@"\ne", @"\ne ").Replace(@"\le", @"\le ").Replace("le ft", "left").Replace(@"\approx", @"&\approx ").Replace(@"\partial", @"\partial ").Replace("cdot", "cdot ").Replace("cdot s", "cdots").Replace(@"\Delta", @"\Delta ").Replace(@"\delta", @"\delta ").Replace(@"%", @"\%").Replace(@"\ \ \ \ \ \ \ \ \ \ \ \ \ \ \", " ");

                                        string tempStr = citem.Replace(@"\(", "").Replace(@"\)", "");
                                        Regex reg = new Regex(@"\(([^)]+)\)*");
                                        foreach (Match ItemMatch in reg.Matches(tempStr))
                                        {
                                            string temp = ItemMatch.Value.Replace("&=", "=");
                                            citem = citem.Replace(ItemMatch.Value, temp);
                                        }
                                        Regex reg1 = new Regex(@"\{([^)]+)\}}*");
                                        foreach (Match ItemMatch in reg.Matches(tempStr))
                                        {
                                            string temp = ItemMatch.Value.Replace("&=", "=");
                                            citem = citem.Replace(ItemMatch.Value, temp);
                                        }

                                        if (citem.Substring(0, 1) == "$")
                                        {
                                            citem = citem.Trim('$');
                                            citem = @"\(" + citem + @"\)";
                                        }
                                        //if (citem.Substring(citem.Length - 1, 1) == "$")
                                        //{
                                        //    citem = citem.Replace(citem.Substring(citem.Length - 1, 1), @"\)");
                                        //}
                                        citem = citem.Replace(@"\cdot", @"\cdot ").Replace(@"\cdot s", @"\cdots").Replace(@"&&\\", @"\\");

                                        KatexList.Add(citem);
                                       // wr.WriteLine(citem);
                                    }
                                   // wr.Close();
                               // }
                                mathMLList.Clear();

                                //---------------
                                int mcount = 0;
                                foreach (MSWord.Range r in ranges)
                                {

                                    // replace image with image
                                    // r.InlineShapes.AddPicture(@"D:\New folder\img1.jpg", ref missing, ref missing, ref missing);
                                    // replace image with text    
                                    r.Text = KatexList[mcount].ToString();
                                    mcount++;
                                }


                                lr.WriteLine(Path.GetFileName(file).ToString().Replace(".docx", "") + "," + count.ToString() + " MathType(s) Converted.");
                                statusBox.AppendText(count.ToString() + " MathTypes Converted." + Environment.NewLine);



                                doc.SaveAs2(outputSolutionPath + "Done Files\\" + Path.GetFileName(file));
                                doc.Close();
                            }
                            catch (Exception ex)
                            {
                                //MessageBox.Show(ex.ToString());
                                statusBox.AppendText(ex.Message.ToString() + Environment.NewLine);
                            }
                        }
                        //lr.WriteLine("------------------------------------------------------------------");
                        lr.WriteLine("Total files processed:," + tFiles.ToString());
                        //lr.WriteLine("------------------------------------------------------------------");
                        DateTime now1 = DateTime.Now;
                        lr.WriteLine("Process end time:," + now1.ToString("F"));
                        //lr.WriteLine("------------------------------------------------------------------");
                        lr.WriteLine("");
                        lr.WriteLine("For any query regarding KaTeX, please write to chandan.kumar@evelynlearning.com");
                        lr.Close();
                    }
                    er.WriteLine("");
                    //er.WriteLine("------------------------------------------------------------------");
                    er.WriteLine("For any query regarding KaTeX, please write to chandan.kumar@evelynlearning.com");
                    er.Close();
                }

                app.Quit();

            }
            catch { }
            //MessageBox.Show("MathType Conversion Done" + Environment.NewLine + @"click on ""Go Back"" button.", "Latex Converter");
            Console.ReadLine();
        }

        private void exitbutton_Click(object sender, EventArgs e)
        {
            this.Dispose();
        }

        private void WordToKaTeX_Load(Object sender, EventArgs e)
        {
            statusLabel.Text = "";
            nonChemistry.Checked = true;
        }
    }
}