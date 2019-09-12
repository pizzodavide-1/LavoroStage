using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Windows.Forms;
using System.Drawing.Drawing2D;
using System.IO;

namespace GraphicViewer
{
    public partial class Form1 : Form
    {
    //int[] vx = new int[3] ;
    //int[] vy = new int[3];
        string _path;
        //XmlTextReader _reader = new XmlTextReader("Graphic.xml");
        private PictureBox pictureBox1 = new PictureBox();
        public Form1()
        {
            InitializeComponent();
            pictureBox1.Paint += new System.Windows.Forms.PaintEventHandler(this.pictureBoxGrafico_Paint);
            this.Controls.Add(pictureBox1);
            //pictureBoxGrafico.Refresh();
        }
        private void buttonImportGraphic_Click(object sender, EventArgs e)
        {
            
            if (textBoxFilePath.Text == "")
            {
                textBoxFilePath.Text = "Seleziona un file";
                Graphics g = pictureBoxGrafico.CreateGraphics();
                g.Clear(Color.WhiteSmoke);
                Pen pen = new Pen(Color.FromArgb(255, 0, 0, 0));
                g.DrawLine(pen, 10, 10, 10, 222);
                g.DrawLine(pen, 10, 222, 500, 222);
                g.DrawLine(pen, 10, 5, 5, 20);
                g.DrawLine(pen, 10, 5, 15, 20);
            }
            else {
                StreamReader sr = new StreamReader(_path);
                int lines = File.ReadAllLines(_path).Length;
                int []vx=new int[lines];
                int[] vy = new int[lines];
                Graphics g = pictureBoxGrafico.CreateGraphics();
                for (int i = 0; i < vx.Length; i++)
                {
                    string line = sr.ReadLine();
                    string[] split = line.Split(new char[] { ';' });
                    vx[i] = Convert.ToInt32(split[0]);
                    vy[i] = Convert.ToInt32(split[1]);
                    //PointF point = new PointF();
                    //point.X = vx[i];
                    //point.Y = vy[i];
                    Pen pen = new Pen(Color.Black);
                    if (vx[i] > 21)
                    {
                        g.FillEllipse(Brushes.Red, new Rectangle(vx[i] + 400, 150 - vy[i], 4, 4));
                        if (i == 0)
                        {
                            g.DrawLine(pen, 10, 222, vx[i] + 400, (150 - vy[i]));
                        }
                        else
                        {
                            g.DrawLine(pen, vx[i - 1] * 20, (150 - vy[i - 1]), vx[i] + 400, (150 - vy[i]));
                        } 
                    }
                    else 
                    {
                        g.FillEllipse(Brushes.Red, new Rectangle(vx[i] * 20, 150 - vy[i], 4, 4));
                        if (i == 0)
                        {
                            g.DrawLine(pen, 10, 222, vx[i] * 20, (150 - vy[i]));
                        }
                        else
                        {
                            g.DrawLine(pen, vx[i - 1] * 20, (150 - vy[i - 1]), vx[i] * 20, (150 - vy[i]));
                        } 
                    }
                }
            }
            // Pen pen = new Pen(Color.FromArgb(255, 0, 0, 0));
            //Graphics g = pictureBox1.CreateGraphics();
            // 
            //  for (int i = 0; i < lines; i++) {
            //     g.DrawLine(pen, 10, 222, vectX[i], vectY[i]);
            //}
        }
        private void buttonBrowse_Click(object sender, EventArgs e)
        {
            OpenFileDialog ofd = new OpenFileDialog();
            if (ofd.ShowDialog() == DialogResult.OK)
            {
                _path = ofd.FileName;
                textBoxFilePath.Text = _path;
            }
        }
        private void pictureBoxGrafico_Paint(object sender, PaintEventArgs e)
        {
            Graphics g = pictureBoxGrafico.CreateGraphics();
            Pen pen = new Pen(Color.FromArgb(255, 0, 0, 0));       
            g.DrawLine(pen, 10, 10, 10, 222);
            g.DrawLine(pen, 10, 222, 500, 222);
            g.DrawLine(pen, 10, 5, 5, 20);
            g.DrawLine(pen, 10, 5, 15, 20);
            g.DrawLine(pen, 505, 222, 495, 218);
            g.DrawLine(pen, 505, 222, 485, 231);
        }
    }
}