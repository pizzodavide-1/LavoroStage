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
            
            //pictureBoxGrafico.Refresh();

                //Pen pen = new Pen(Color.FromArgb(255, 0, 0, 0));
                //Graphics g = pictureBox1.CreateGraphics();
              
                //int[] vectX =new int[5];
                //int[] vectY = new int[5];
                //StreamReader sr = new StreamReader(_path);
                //int lines = File.ReadAllLines(_path).Length;
                //for (int i = 0; i < lines; i++) {
                //    string line = sr.ReadLine(); 
                //    string[] split = line.Split(new char[] { ';' });
                //    vectX[i] =Convert.ToInt32( split[0]);
                //   vectY[i] = Convert.ToInt32(split[1])

                //   //g.DrawLine(pen, 10, -10000,10, 100);
                //   //g.DrawLine(pen, vectX[i], vectY[i], 0, 0);

                //}
        }
        private void buttonBrowse_Click(object sender, EventArgs e)
        {
            //Graphics g = pictureBox1.CreateGraphics();
            //Pen pen = new Pen(Color.FromArgb(255, 0, 0, 0));
            //g.DrawLine(pen, 0, 0, 0, 300);
            //g.DrawLine(pen, 0, 226, 500, 226);
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
            g.DrawLine(pen, 10, 222, 500, 222);
            g.DrawLine(pen, 10, 10, 5, 20);
            g.DrawLine(pen, 10, 10, 15, 20);
            g.DrawLine(pen, 500, 222, 494, 217);
            g.DrawLine(pen, 500, 222, 490, 229);

        }
    }
}
