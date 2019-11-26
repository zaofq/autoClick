using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Text;
using System.Windows.Forms;
using System.IO;
using System.Drawing.Imaging;
namespace ZMECG
{
    public partial class Form1 : Form
    {
        public Form1()
        {
            InitializeComponent();
        }
        //
        public void WriteText(string path, string s)///写入已有文档
		{
            System.IO.StreamWriter sw = new StreamWriter(path, true);
            sw.WriteLine(s);
            sw.Close();
        }

        public void setuptext(string path, string txt)//生成UTF－8文档并写入一串txt，若已有此文档，则会删除重建
        {
            FileInfo fi = new FileInfo(path);
            StreamWriter sw = fi.CreateText();
            sw.Write(txt);
            sw.Flush();
            sw.Close();
        }

        public string ReadText(string path)//读文档
        {
            string st = null;
            FileInfo fi = new FileInfo(path);
            FileStream fs = fi.Open(FileMode.Open);
            StreamReader sr = new StreamReader(fs, System.Text.Encoding.UTF8);
            if (fs.Length > 0)
            {
                do
                {
                    st += sr.ReadLine() + "\n";
                } while (sr.Peek() != -1);
            }
            fs.Close();
            return st;
        }

        public void deletetext(string path)//删文档
        {
            FileInfo fi = new FileInfo(path);
            if (fi.Exists) fi.Delete();
        }

        private void button2_MouseUp(object sender, MouseEventArgs e)
        {
            this.setuptext("TOOL\\Position\\P1X.txt", Control.MousePosition.X.ToString());
            this.setuptext("TOOL\\Position\\P1Y.txt", Control.MousePosition.Y.ToString());
        }

        private void button3_MouseUp(object sender, MouseEventArgs e)
        {
            this.setuptext("TOOL\\Position\\P2X.txt", Control.MousePosition.X.ToString());
            this.setuptext("TOOL\\Position\\P2Y.txt", Control.MousePosition.Y.ToString());
        }

        private void button4_MouseUp(object sender, MouseEventArgs e)
        {
            this.setuptext("TOOL\\Position\\P3X.txt", Control.MousePosition.X.ToString());
            this.setuptext("TOOL\\Position\\P3Y.txt", Control.MousePosition.Y.ToString());
        }

        private void button5_MouseUp(object sender, MouseEventArgs e)
        {
            this.setuptext("TOOL\\Position\\P4X.txt", Control.MousePosition.X.ToString());
            this.setuptext("TOOL\\Position\\P4Y.txt", Control.MousePosition.Y.ToString());
        }

        private void button6_MouseUp(object sender, MouseEventArgs e)
        {
            this.setuptext("TOOL\\Position\\P5X.txt", Control.MousePosition.X.ToString());
            this.setuptext("TOOL\\Position\\P5Y.txt", Control.MousePosition.Y.ToString());
        }

        private void button7_MouseUp(object sender, MouseEventArgs e)
        {
            this.setuptext("TOOL\\Position\\P6X.txt", Control.MousePosition.X.ToString());
            this.setuptext("TOOL\\Position\\P6Y.txt", Control.MousePosition.Y.ToString());
        }

        private void button8_MouseUp(object sender, MouseEventArgs e)
        {
            this.setuptext("TOOL\\Position\\P7X.txt", Control.MousePosition.X.ToString());
            this.setuptext("TOOL\\Position\\P7Y.txt", Control.MousePosition.Y.ToString());
        }

        private void button9_MouseUp(object sender, MouseEventArgs e)
        {
            this.setuptext("TOOL\\Position\\P8X.txt", Control.MousePosition.X.ToString());
            this.setuptext("TOOL\\Position\\P8Y.txt", Control.MousePosition.Y.ToString());
        }

        private void button1_Click(object sender, EventArgs e)
        {
            int numX = 0;
            int numY = 0;
            if (checkBox1.Checked)
            {
                ////取得编号
                Clipboard.Clear();
                numX = Int32.Parse(this.ReadText("TOOL\\Position\\P1X.txt"));
                numY = Int32.Parse(this.ReadText("TOOL\\Position\\P1Y.txt"));
                mouseClass.SetCursorPos(numX, numY);
                mouseClass.MouseLeftDown(numX, numY, 0);
                mouseClass.MouseLeftUp(numX, numY, 0);
                System.Threading.Thread.Sleep(Int32.Parse(textBox1.Text.Trim()));
                Clipboard.SetText(" ");
                string buffstr = "";
                int copytime = 0;
                while (buffstr == "" && copytime < 1000)
                {
                    SendKeys.SendWait("^a^c");//  SendKeys.SendWait("^a");//SendKeys.SendWait("^c");//    SendKeys.SendWait("^c");
                    buffstr = Clipboard.GetText().Trim();
                    copytime++;
                }
                if (buffstr.Length > 20)
                { MessageBox.Show("请核实是否导入正确的编号"); }
                else
                { Clipboard.SetText(buffstr); }
                ///取得编号完
            }
            if (checkBox2.Checked)
            {
                //激活
              numX = Int32.Parse(this.ReadText("TOOL\\Position\\P2X.txt"));
              numY = Int32.Parse(this.ReadText("TOOL\\Position\\P2Y.txt"));
                mouseClass.SetCursorPos(numX, numY);
                mouseClass.MouseLeftDown(numX, numY, 0);
                mouseClass.MouseLeftUp(numX, numY, 0);
                System.Threading.Thread.Sleep(Int32.Parse(textBox2.Text.Trim()));
                //激活完
            }
            if (checkBox3.Checked)
            {
                //关窗
                numX = Int32.Parse(this.ReadText("TOOL\\Position\\P3X.txt"));
                numY = Int32.Parse(this.ReadText("TOOL\\Position\\P3Y.txt"));
                mouseClass.SetCursorPos(numX, numY);
                mouseClass.MouseLeftDown(numX, numY, 0);
                mouseClass.MouseLeftUp(numX, numY, 0);
                System.Threading.Thread.Sleep(Int32.Parse(textBox3.Text.Trim()));
                //关窗完
            }

            if (checkBox4.Checked)
            {
                //粘贴
                numX = Int32.Parse(this.ReadText("TOOL\\Position\\P4X.txt"));
                numY = Int32.Parse(this.ReadText("TOOL\\Position\\P4Y.txt"));
                mouseClass.SetCursorPos(numX, numY);
                mouseClass.MouseLeftDown(numX, numY, 0);
                mouseClass.MouseLeftUp(numX, numY, 0);
                System.Threading.Thread.Sleep(Int32.Parse(textBox4.Text.Trim()));
                // while (buffstr == "" && copytime < 1000)
                {
                    SendKeys.SendWait("^a^v");//  SendKeys.SendWait("^a");//SendKeys.SendWait("^c");//    SendKeys.SendWait("^c");
                                              // SendKeys.SendWait("^v");
                }
                //  SendKeys.Send("^a");//全选
                // SendKeys.Send("^c");//复制
                //  SendKeys.Send("^x");//剪切
                // SendKeys.Send("^v");//粘贴
                //粘贴完
            }

            if (checkBox5.Checked)
            {
                //查找
                numX = Int32.Parse(this.ReadText("TOOL\\Position\\P5X.txt"));
                numY = Int32.Parse(this.ReadText("TOOL\\Position\\P5Y.txt"));
                mouseClass.SetCursorPos(numX, numY);
                mouseClass.MouseLeftDown(numX, numY, 0);
                mouseClass.MouseLeftUp(numX, numY, 0);
                System.Threading.Thread.Sleep(Int32.Parse(textBox5.Text.Trim()));
                //查找完
            }

            if (checkBox6.Checked)
            {//选择
                numX = Int32.Parse(this.ReadText("TOOL\\Position\\P6X.txt"));
                numY = Int32.Parse(this.ReadText("TOOL\\Position\\P6Y.txt"));
                mouseClass.SetCursorPos(numX, numY);
                mouseClass.MouseLeftDown(numX, numY, 0);
                mouseClass.MouseLeftUp(numX, numY, 0);
                mouseClass.MouseLeftDown(numX, numY, 0);
                mouseClass.MouseLeftUp(numX, numY, 0);
                //System.Threading.Thread.Sleep(Int32.Parse(textBox6.Text.Trim()));
                //选择完
            }
            


        }

        private void Form1_Load(object sender, EventArgs e)
        {
            textBox1.Text = (this.ReadText("TOOL\\Position\\sleep1.txt")).Trim();
            textBox2.Text = (this.ReadText("TOOL\\Position\\sleep2.txt")).Trim();
            textBox3.Text = (this.ReadText("TOOL\\Position\\sleep3.txt")).Trim();
            textBox4.Text = (this.ReadText("TOOL\\Position\\sleep4.txt")).Trim();
            textBox5.Text = (this.ReadText("TOOL\\Position\\sleep5.txt")).Trim();
            textBox6.Text = (this.ReadText("TOOL\\Position\\sleep6.txt")).Trim();
        }

        private void Form1_FormClosed(object sender, FormClosedEventArgs e)
        {
            if (textBox1.Text != "")
            {
                this.setuptext("TOOL\\Position\\sleep1.txt", textBox1.Text.Trim());
            }
            if (textBox2.Text != "")
            {
                this.setuptext("TOOL\\Position\\sleep2.txt", textBox2.Text.Trim());
            }
            if (textBox3.Text != "")
            {
                this.setuptext("TOOL\\Position\\sleep3.txt", textBox3.Text.Trim());
            }
            if (textBox4.Text != "")
            {
                this.setuptext("TOOL\\Position\\sleep4.txt", textBox4.Text.Trim());
            }
            if (textBox5.Text != "")
            {
                this.setuptext("TOOL\\Position\\sleep5.txt", textBox5.Text.Trim());
            }
            if (textBox6.Text != "")
            {
                this.setuptext("TOOL\\Position\\sleep6.txt", textBox6.Text.Trim());
            }

        }

        private void button10_Click(object sender, EventArgs e)
        {
           int X = Int32.Parse(this.ReadText("TOOL\\Position\\P7X.txt"));
           int Y = Int32.Parse(this.ReadText("TOOL\\Position\\P7Y.txt"));
            int X1 = Int32.Parse(this.ReadText("TOOL\\Position\\P8X.txt"));
            int Y1 = Int32.Parse(this.ReadText("TOOL\\Position\\P8Y.txt"));
            int width = X1 - X;
            int height = Y1 - Y;
            Form2 imageform = new Form2();
            imageform.pictureBox1.Image = CutImageClass.GetImage( X , Y, width, height);
            imageform.Show();
        }
    }
}
