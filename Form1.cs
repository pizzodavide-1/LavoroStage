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
        //int[] _vex = new int[999999];
        //int[] _vey = new int[999999];
        //XmlTextReader _reader = new XmlTextReader("Graphic.xml");
        private PictureBox pictureBox1 = new PictureBox();
        public Form1()
        {
            InitializeComponent();
            pictureBox1.Paint += new System.Windows.Forms.PaintEventHandler(this.pictureBoxGrafico_Paint);
            this.Controls.Add(pictureBox1);
            //pictureBoxGrafico.Refresh();
            
        }
        #region Graphic
        private void buttonImportGraphic_Click(object sender, EventArgs e)
        {
            _path = textBoxFilePath.Text;
            if (textBoxFilePath.Text == "" || textBoxFilePath.Text == "Seleziona un file")
            {
                //labelMex.Text = "";
                textBoxFilePath.Text = "Seleziona un file";
                Graphics g = pictureBoxGrafico.CreateGraphics();
                g.Clear(BackColor);
                Pen pen = new Pen(Color.FromArgb(255, 0, 0, 0));
                Pen Pen = new Pen(Color.FromArgb(25, 0, 0, 0));
                string drawStringX = "X";
                string drawStringY = "Y";
                System.Drawing.Font drawFont = new System.Drawing.Font("Times new roman", 13);
                System.Drawing.SolidBrush drawBrush = new System.Drawing.SolidBrush(System.Drawing.Color.Black);
                System.Drawing.StringFormat drawFormat = new System.Drawing.StringFormat();
                g.DrawString(drawStringX, drawFont, drawBrush, 13, 0, drawFormat);
                g.DrawString(drawStringY, drawFont, drawBrush, 510, 210, drawFormat);
                g.DrawLine(pen, 10, 10, 10, 222);
                g.DrawLine(pen, 10, 222, 500, 222);
                g.DrawLine(pen, 10, 5, 5, 20);
                g.DrawLine(pen, 10, 5, 15, 20);
                g.DrawLine(pen, 505, 222, 495, 218);
                g.DrawLine(pen, 505, 222, 485, 231);
                int c = 2;
                for (int i = 0; i < 47; i = i + 2)
                {
                    g.DrawLine(pen, c * 10, 218, c * 10, 225);
                    g.DrawLine(Pen, c * 10, 218, c * 10, 25);
                    c = c + 2;
                }
                c = 20;
                for (int i = 0; i < 17; i = i + 2)
                {
                    g.DrawLine(pen, 6, 222 - c, 14, 222 - c);
                    g.DrawLine(Pen, 14, 222 - c, 510, 222 - c);
                    c = c + 20;
                }
            }

            else if ((Directory.Exists(_path) == false) && (File.Exists(_path) == false))
            {
                MessageBox.Show("Percorso non esistente","Error",
                    MessageBoxButtons.OK);
                //labelMex.Text = "Percorso non esistente";
                string drawStringX = "X";
                string drawStringY = "Y";
                Pen pen = new Pen(Color.FromArgb(255, 0, 0, 0));
                Pen Pen = new Pen(Color.FromArgb(25, 0, 0, 0));
                Graphics g = pictureBoxGrafico.CreateGraphics();
                System.Drawing.Font drawFont = new System.Drawing.Font("Times new roman", 13);
                System.Drawing.SolidBrush drawBrush = new System.Drawing.SolidBrush(System.Drawing.Color.Black);
                System.Drawing.StringFormat drawFormat = new System.Drawing.StringFormat();
                g.DrawString(drawStringX, drawFont, drawBrush, 13, 0, drawFormat);
                g.DrawString(drawStringY, drawFont, drawBrush, 510, 210, drawFormat);
                g.DrawLine(pen, 10, 10, 10, 222);
                g.DrawLine(pen, 10, 222, 500, 222);
                g.DrawLine(pen, 10, 5, 5, 20);
                g.DrawLine(pen, 10, 5, 15, 20);
                g.DrawLine(pen, 505, 222, 495, 218);
                g.DrawLine(pen, 505, 222, 485, 231);
                int c = 2;
                for (int i = 0; i < 47; i = i + 2)
                {
                    g.DrawLine(pen, c * 10, 218, c * 10, 225);
                    g.DrawLine(Pen, c * 10, 218, c * 10, 25);
                    c = c + 2;
                }
                c = 20;
                for (int i = 0; i < 17; i = i + 2)
                {
                    g.DrawLine(pen, 6, 222 - c, 14, 222 - c);
                    g.DrawLine(Pen, 14, 222 - c, 510, 222 - c);
                    c = c + 20;
                }
            }
            else
            {
                //labelMex.Text = "";
                StreamReader sr = new StreamReader(_path);
                int lines = File.ReadAllLines(_path).Length;
                int[] vx = new int[lines];
                int[] vy = new int[lines];
                Graphics g = pictureBoxGrafico.CreateGraphics();
                for (int i = 0; i < vx.Length; i++)
                {
                    string line = sr.ReadLine();
                    string[] split = line.Split(new char[] { ';' });
                    if ((!(line.Contains(";"))) && (!(Path.GetExtension(_path) == ".csv")))
                    {
                        MessageBox.Show("Nel file selezionato non ci sono Coordinate valide", "Error",
    MessageBoxButtons.OK);
                        //labelMex.Text = ;
                        g.Clear(BackColor);
                        Pen pen2 = new Pen(Color.FromArgb(255, 0, 0, 0));
                        Pen pen = new Pen(Color.FromArgb(25, 0, 0, 0));
                        string drawStringX = "X";
                        string drawStringY = "Y";
                        System.Drawing.Font drawFont = new System.Drawing.Font("Times new roman", 13);
                        System.Drawing.SolidBrush drawBrush = new System.Drawing.SolidBrush(System.Drawing.Color.Black);
                        System.Drawing.StringFormat drawFormat = new System.Drawing.StringFormat();
                        g.DrawString(drawStringX, drawFont, drawBrush, 13, 0, drawFormat);
                        g.DrawString(drawStringY, drawFont, drawBrush, 510, 210, drawFormat);
                        g.DrawLine(pen2, 10, 10, 10, 222);
                        g.DrawLine(pen2, 10, 222, 500, 222);
                        g.DrawLine(pen2, 10, 5, 5, 20);
                        g.DrawLine(pen2, 10, 5, 15, 20);
                        g.DrawLine(pen2, 505, 222, 495, 218);
                        g.DrawLine(pen2, 505, 222, 485, 231);
                        int c = 2;
                        for (int z = 0; z < 47; z = z + 2)
                        {
                            g.DrawLine(pen2, c * 10, 218, c * 10, 225);
                            g.DrawLine(pen, c * 10, 218, c * 10, 25);
                            c = c + 2;
                        }
                        c = 20;
                        for (int z = 0; z < 15; z= z + 2)
                        {
                            g.DrawLine(pen2, 6, 222 - c, 14, 222 - c);
                            g.DrawLine(pen, 14, 222 - c, 510, 222 - c);
                            c = c + 20;
                        }
                        break;
                    }
                    vx[i] = Convert.ToInt32(split[0]);
                    vy[i] = Convert.ToInt32(split[1]);
                    //_vex[i] = vx[i];
                    //_vey[i] = vy[i];
                    //PointF point = new PointF();
                    //point.X = vx[i];
                    
                    //point.Y = vy[i];
                    Pen penX = new Pen(Color.Black);
                    /*  if (vx[i] > 21)
                      {
                          g.FillEllipse(Brushes.Red, new Rectangle(vx[i] + 200, 205 -vy[i], 4, 4)); //Disegno del punto
                          if (i == 0)
                          {
                              g.DrawLine(pen, 10, 222, vx[i] + 200, (207 - vy[i]));
                          }
                          else
                          {
                              g.DrawLine(pen, vx[i - 1] * 10, (207 - vy[i - 1]), vx[i] + 200, (207 - vy[i]));
                          }
                      } else
                     {*/
                    g.FillEllipse(Brushes.Red, new Rectangle(vx[i] * 10, 205 - vy[i], 4, 4));
                    if (i == 0)
                    {
                        g.DrawLine(penX, 10, 222, vx[i] * 10, (207 - vy[i]));
                    }
                    else
                    {
                        g.DrawLine(penX, vx[i - 1] * 10, (207 - vy[i - 1]), vx[i] * 10, (207 - vy[i]));
                    }
                    //}
                }
            }
            // Pen pen = new Pen(Color.FromArgb(255, 0, 0, 0));
            //Graphics g = pictureBox1.CreateGraphics();
            // 
            //  for (int i = 0; i < lines; i++) {
            //     g.DrawLine(pen, 10, 222, vectX[i], vectY[i]);
            //}
        }
        #endregion

        #region Browse
        private void buttonBrowse_Click(object sender, EventArgs e)
        {
            //labelMex.Text = "";
            OpenFileDialog ofd = new OpenFileDialog();
            if (ofd.ShowDialog() == DialogResult.OK)
            {
                _path = ofd.FileName;
                textBoxFilePath.Text = _path;
            }
        }
        #endregion

        #region pictureBoxEvents
        private void pictureBoxGrafico_Paint(object sender, PaintEventArgs e)
        {
            Graphics g = pictureBoxGrafico.CreateGraphics();
            Pen pen = new Pen(Color.FromArgb(255, 0, 0, 0));
            Pen Pen = new Pen(Color.FromArgb(25, 0, 0, 0));
            string drawStringX = "X";
            string drawStringY = "Y";
            System.Drawing.Font drawFont = new System.Drawing.Font("Times new roman", 13);
            System.Drawing.SolidBrush drawBrush = new System.Drawing.SolidBrush(System.Drawing.Color.Black);
            System.Drawing.StringFormat drawFormat = new System.Drawing.StringFormat();
            g.DrawString(drawStringX, drawFont, drawBrush, 13, 0, drawFormat); //disegna la scritta 'X'
            g.DrawString(drawStringY, drawFont, drawBrush, 510, 210, drawFormat); //disegna la scritta 'Y'
            g.DrawLine(pen, 10, 10, 10, 222); //Disegna Asse Y
            g.DrawLine(pen, 10, 222, 500, 222); //Disegna Asse X
            g.DrawLine(pen, 10, 5, 5, 20); //Disegna freccia...
            g.DrawLine(pen, 10, 5, 15, 20);//...dell' asse Y
            g.DrawLine(pen, 505, 222, 495, 218);//Disegna freccia...
            g.DrawLine(pen, 505, 222, 485, 231);//...dell'asse X
            int c = 2;
            for (int i = 0; i < 47; i=i+2) {
                g.DrawLine(pen, c*10, 218, c*10, 225);
                g.DrawLine(Pen, c * 10, 218, c * 10, 25);
                c = c + 2;
            }
            c = 20;
            for (int i = 0; i < 17; i = i + 2) { 
            g.DrawLine(pen,6,222-c,14,222-c);
            g.DrawLine(Pen, 14, 222 - c, 510, 222 - c);
            c = c + 20;
            }
        }
        #endregion

        private void resetButton_Click(object sender, EventArgs e)
        {
            Graphics g = pictureBoxGrafico.CreateGraphics();
            g.Clear(BackColor);
            //labelMex.Text = "";
            textBoxFilePath.Text = "";
            Pen pen2 = new Pen(Color.FromArgb(255, 0, 0, 0));
            Pen pen=new Pen(Color.FromArgb(25,0,0,0));
            string drawStringX = "X";
            string drawStringY = "Y";
            System.Drawing.Font drawFont = new System.Drawing.Font("Times new roman", 13);
            System.Drawing.SolidBrush drawBrush = new System.Drawing.SolidBrush(System.Drawing.Color.Black);
            System.Drawing.StringFormat drawFormat = new System.Drawing.StringFormat();
            g.DrawString(drawStringX, drawFont, drawBrush, 13, 0, drawFormat);
            g.DrawString(drawStringY, drawFont, drawBrush, 510, 210, drawFormat);
            g.DrawLine(pen2, 10, 10, 10, 222);
            g.DrawLine(pen2, 10, 222, 500, 222);
            g.DrawLine(pen2, 10, 5, 5, 20);
            g.DrawLine(pen2, 10, 5, 15, 20);
            g.DrawLine(pen2, 505, 222, 495, 218);
            g.DrawLine(pen2, 505, 222, 485, 231);
            
            int c = 2;
            for (int i = 0; i < 47; i = i + 2)
            {
                g.DrawLine(pen2, c * 10, 218, c * 10, 225);
                g.DrawLine(pen, c * 10, 218, c * 10, 25);
                c = c + 2;
            }
            c = 20;
            for (int i = 0; i < 17; i = i + 2)
            {
                g.DrawLine(pen2, 6, 222 - c, 14, 222 - c);
                g.DrawLine(pen ,14,222-c,510,222-c);
                c = c + 20;
            }
        }
        private void pictureBoxGrafico_MouseHover(object sender, EventArgs e)
        {
            ToolTip tt = new ToolTip();
            //string tooltip="";
            //StreamReader sr = new StreamReader(_path);
            //    int lines = File.ReadAllLines(_path).Length;
            //    for (int i = 0; i < lines; i++) {
            //        tooltip = "Punto" + i + "-->X=" + _vex[i] + " Y=" + _vey[i];
            //    }
            //    tt.SetToolTip(pictureBoxGrafico, tooltip);
        }
    }
}