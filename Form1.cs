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
        int _z = 0;
        string _path = "";
        //labelMex.Text = "";
        StreamReader _sr;
        ToolTip _tt = new ToolTip();
        int[] _vx;
        int[] _vy;
        string FONT = "Times new roman";
        int TOLLERANZA = 5;
        //int[] _vex = new int[999999];
        //int[] _vey = new int[999999];
        string _drawXValues;
        string _drawYValues;
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
                string drawZero = "0";
                System.Drawing.Font drawFont = new System.Drawing.Font(FONT, 13);
                System.Drawing.Font drawFont2 = new System.Drawing.Font(FONT, 8);
                System.Drawing.Font drawFont3 = new System.Drawing.Font(FONT, 7);
                System.Drawing.SolidBrush drawBrush = new System.Drawing.SolidBrush(System.Drawing.Color.Black);
                System.Drawing.StringFormat drawFormat = new System.Drawing.StringFormat();
                g.DrawString(drawStringY, drawFont, drawBrush, 13, 0, drawFormat);
                g.DrawString(drawStringX, drawFont, drawBrush, 510, 210, drawFormat);
                g.DrawLine(pen, 10, 10, 10, 222);
                g.DrawLine(pen, 10, 222, 500, 222);
                g.DrawLine(pen, 10, 5, 5, 20);
                g.DrawLine(pen, 10, 5, 15, 20);
                g.DrawLine(pen, 505, 222, 495, 218);
                g.DrawLine(pen, 505, 222, 493, 229);
                DrawWithoutTransformation(g);
                int c = 2;
                for (int i = 0; i < 47; i = i + 2)
                {
                    _drawXValues = c.ToString();
                    g.DrawLine(pen, CalcolaPuntoX(c), 218, CalcolaPuntoX(c), 225);
                    g.DrawLine(Pen, CalcolaPuntoX(c), 218, CalcolaPuntoX(c), 25);
                    g.DrawString(_drawXValues, drawFont2, drawBrush, (CalcolaPuntoX(c)) - 6, 227, drawFormat);
                    c = c + 2;
                }
                c = 20;
                int YVal = 3;
                for (int ii = 0; ii < 9; ii++)
                {
                    _drawYValues = YVal.ToString();
                    g.DrawLine(pen, 6, 222 - c, 14, 222 - c);
                    g.DrawLine(Pen, 14, 222 - c, 510, 222 - c);
                    g.DrawString(_drawYValues, drawFont2, drawBrush, -3, 220 - c, drawFormat);
                    YVal = YVal + 3;
                    c = c + 20;
                }
                g.DrawString(drawZero, drawFont2, drawBrush, 0, 222, drawFormat);
            }

            else if ((Directory.Exists(_path) == false) && (File.Exists(_path) == false))
            {
                MessageBox.Show("Percorso non esistente", "Error",
                    MessageBoxButtons.OK);
                //labelMex.Text = "Percorso non esistente";
                string drawStringX = "X";
                string drawStringY = "Y";
                string drawZero = "0";
                Pen pen = new Pen(Color.FromArgb(255, 0, 0, 0));
                Pen Pen = new Pen(Color.FromArgb(25, 0, 0, 0));
                Graphics g = pictureBoxGrafico.CreateGraphics();
                g.Clear(BackColor);
                System.Drawing.Font drawFont = new System.Drawing.Font(FONT, 13);
                System.Drawing.Font drawFont2 = new System.Drawing.Font(FONT, 8);
                System.Drawing.Font drawFont3 = new System.Drawing.Font(FONT, 7);
                System.Drawing.SolidBrush drawBrush = new System.Drawing.SolidBrush(System.Drawing.Color.Black);
                System.Drawing.StringFormat drawFormat = new System.Drawing.StringFormat();
                g.DrawString(drawStringY, drawFont, drawBrush, 13, 0, drawFormat);
                g.DrawString(drawStringX, drawFont, drawBrush, 510, 210, drawFormat);
                g.DrawLine(pen, 10, 10, 10, 222);
                g.DrawLine(pen, 10, 222, 500, 222);
                g.DrawLine(pen, 10, 5, 5, 20);
                g.DrawLine(pen, 10, 5, 15, 20);
                g.DrawLine(pen, 505, 222, 495, 218);
                g.DrawLine(pen, 505, 222, 493, 229);
                DrawWithoutTransformation(g);
                int c = 2;
                for (int i = 0; i < 47; i = i + 2)
                {
                    _drawXValues = c.ToString();
                    g.DrawLine(pen, CalcolaPuntoX(c), 218, CalcolaPuntoX(c), 225);
                    g.DrawLine(Pen, CalcolaPuntoX(c), 218, CalcolaPuntoX(c), 25);
                    g.DrawString(_drawXValues, drawFont2, drawBrush, (CalcolaPuntoX(c)) - 6, 227, drawFormat);
                    c = c + 2;
                }
                c = 20;
                int YVal = 3;
                for (int ii = 0; ii < 9; ii++)
                {
                    _drawYValues = YVal.ToString();
                    g.DrawLine(pen, 6, 222 - c, 14, 222 - c);
                    g.DrawLine(Pen, 14, 222 - c, 510, 222 - c);
                    g.DrawString(_drawYValues, drawFont2, drawBrush, -3, 220 - c, drawFormat);
                    YVal = YVal + 3;
                    c = c + 20;
                }
                g.DrawString(drawZero, drawFont2, drawBrush, 0, 222, drawFormat);
            }
            else
            {
                //labelMex.Text = "";
                _sr = new StreamReader(_path);
                int lines = File.ReadAllLines(_path).Length;
                
                _vx = new int[lines];
                _vy = new int[lines];
                Graphics g = pictureBoxGrafico.CreateGraphics();
                for (int i = 0; i < _vx.Length; i++)
                {
                    string line = _sr.ReadLine();
                    if (! line.Any(char.IsDigit)) {
                        MessageBox.Show("Nel file selezionato non ci sono Coordinate valide", "Error",
    MessageBoxButtons.OK); g.Clear(BackColor);
                        Pen pen2 = new Pen(Color.FromArgb(255, 0, 0, 0));
                        Pen pen = new Pen(Color.FromArgb(25, 0, 0, 0));
                        string drawStringX = "X";
                        string drawStringY = "Y";
                        string drawZero = "0";
                        System.Drawing.Font drawFont = new System.Drawing.Font(FONT, 13);
                        System.Drawing.Font drawFont2 = new System.Drawing.Font(FONT, 8);
                        System.Drawing.Font drawFont3 = new System.Drawing.Font(FONT, 7);
                        System.Drawing.SolidBrush drawBrush = new System.Drawing.SolidBrush(System.Drawing.Color.Black);
                        System.Drawing.StringFormat drawFormat = new System.Drawing.StringFormat();
                        g.DrawString(drawStringY, drawFont, drawBrush, 13, 0, drawFormat);
                        g.DrawString(drawStringX, drawFont, drawBrush, 510, 210, drawFormat);
                        g.DrawLine(pen2, 10, 10, 10, 222);
                        g.DrawLine(pen2, 10, 222, 500, 222);
                        g.DrawLine(pen2, 10, 5, 5, 20);
                        g.DrawLine(pen2, 10, 5, 15, 20);
                        g.DrawLine(pen2, 505, 222, 495, 218);
                        g.DrawLine(pen2, 505, 222, 493, 229);
                        DrawWithoutTransformation(g);
                        int c = 2;
                        for (int z = 0; z < 47; z = z + 2)
                        {
                            _drawXValues = c.ToString();
                            g.DrawLine(pen2, CalcolaPuntoX(c), 218, CalcolaPuntoX(c), 225);
                            g.DrawLine(pen, CalcolaPuntoX(c), 218, CalcolaPuntoX(c), 25);
                            g.DrawString(_drawXValues, drawFont2, drawBrush, (CalcolaPuntoX(c)) - 6, 227, drawFormat);
                            c = c + 2;
                        }
                        c = 20;
                        int YVal = 3;
                        for (int ii = 0; ii < 9; ii++)
                        {
                            _drawYValues = YVal.ToString();
                            g.DrawLine(pen2, 6, 222 - c, 14, 222 - c);
                            g.DrawLine(pen, 14, 222 - c, 510, 222 - c);
                            g.DrawString(_drawYValues, drawFont2, drawBrush, -3, 220 - c, drawFormat);
                            YVal = YVal + 3;
                            c = c + 20;
                        }
                        g.DrawString(drawZero, drawFont2, drawBrush, 0, 222, drawFormat);
                        break;
                    }
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
                        string drawZero = "0";
                        System.Drawing.Font drawFont = new System.Drawing.Font(FONT, 13);
                        System.Drawing.Font drawFont2 = new System.Drawing.Font(FONT, 8);
                        System.Drawing.Font drawFont3 = new System.Drawing.Font(FONT, 7);
                        System.Drawing.SolidBrush drawBrush = new System.Drawing.SolidBrush(System.Drawing.Color.Black);
                        System.Drawing.StringFormat drawFormat = new System.Drawing.StringFormat();
                        g.DrawString(drawStringY, drawFont, drawBrush, 13, 0, drawFormat);
                        g.DrawString(drawStringX, drawFont, drawBrush, 510, 210, drawFormat);
                        g.DrawLine(pen2, 10, 10, 10, 222);
                        g.DrawLine(pen2, 10, 222, 500, 222);
                        g.DrawLine(pen2, 10, 5, 5, 20);
                        g.DrawLine(pen2, 10, 5, 15, 20);
                        g.DrawLine(pen2, 505, 222, 495, 218);
                        g.DrawLine(pen2, 505, 222, 493, 229);
                        DrawWithoutTransformation(g);
                        int c = 2;
                        for (int z = 0; z < 47; z = z + 2)
                        {
                            _drawXValues = c.ToString();
                            g.DrawLine(pen2, CalcolaPuntoX(c), 218, CalcolaPuntoX(c), 225);
                            g.DrawLine(pen, CalcolaPuntoX(c), 218, CalcolaPuntoX(c), 25);
                            g.DrawString(_drawXValues, drawFont2, drawBrush, (CalcolaPuntoX(c)) - 6, 227, drawFormat);
                            c = c + 2;
                        }
                        c = 20;
                        int YVal = 3;
                        for (int ii = 0; ii < 9; ii++)
                        {
                            _drawYValues = YVal.ToString();
                            g.DrawLine(pen2, 6, 222 - c, 14, 222 - c);
                            g.DrawLine(pen, 14, 222 - c, 510, 222 - c);
                            g.DrawString(_drawYValues, drawFont2, drawBrush, -3, 220 - c, drawFormat);
                            YVal = YVal + 3;
                            c = c + 20;
                        }
                        g.DrawString(drawZero, drawFont2, drawBrush, 0, 222, drawFormat);
                        break;
                    }
                   
                    _vx[i] = Convert.ToInt32(split[0]);
                    _vy[i] = Convert.ToInt32(split[1]);


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

                    g.FillEllipse(Brushes.Red, new Rectangle(CalcolaPuntoX(_vx[i]), CalcolaPuntoY(_vy[i]), 4, 4));
                    if (i == 0)
                    {
                        g.DrawLine(penX, 10, 222, CalcolaPuntoX(_vx[i]), CollegaAY(_vy[i]));
                    }
                    else
                    {
                        g.DrawLine(penX, CalcolaPuntoX(_vx[i - 1]), CollegaAY(_vy[i - 1]), CalcolaPuntoX(_vx[i]), CollegaAY(_vy[i]));
                    }
                    //}
                }
            }
            // Pen pen = new Pen(Color.FromArgb(255, 0, 0, 0));  
            //Graphics g = pictureBox1.CreateGraphics();
            // 
            //  for (int i = 0; i < lines; i++) {
            //     g.DrawLine(pen, 10, 222, vectX[i], vectY[i]);
            //} 229
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
            string drawZero = "0";
            System.Drawing.Font drawFont = new System.Drawing.Font(FONT, 13);
            System.Drawing.Font drawFont2 = new System.Drawing.Font(FONT, 8);
            //System.Drawing.Font drawFont3 = new System.Drawing.Font("Times new roman", 7);
            System.Drawing.SolidBrush drawBrush = new System.Drawing.SolidBrush(System.Drawing.Color.Black);
            System.Drawing.StringFormat drawFormat = new System.Drawing.StringFormat();
            g.DrawString(drawStringY, drawFont, drawBrush, 13, 0, drawFormat); //disegna la scritta 'X'
            g.DrawString(drawStringX, drawFont, drawBrush, 510, 210, drawFormat); //disegna la scritta 'Y'
            g.DrawLine(pen, 10, 10, 10, 222); //Disegna Asse Y
            g.DrawLine(pen, 10, 222, 500, 222); //Disegna Asse X
            g.DrawLine(pen, 10, 5, 5, 20); //Disegna freccia...
            g.DrawLine(pen, 10, 5, 15, 20);//...dell' asse Y
            g.DrawLine(pen, 505, 222, 495, 218);//Disegna freccia...
            g.DrawLine(pen, 505, 222, 493, 229);//...dell'asse X
            DrawWithoutTransformation(g);
            int c = 2;
            for (int i = 0; i < 47; i = i + 2)
            {

                _drawXValues = c.ToString();
                g.DrawLine(pen, CalcolaPuntoX(c), 218, CalcolaPuntoX(c), 225);
                g.DrawLine(Pen, CalcolaPuntoX(c), 218, CalcolaPuntoX(c), 25);
                g.DrawString(_drawXValues, drawFont2, drawBrush, (CalcolaPuntoX(c)) - 6, 227, drawFormat);
                c = c + 2;
            }
            c = 20;
            int YVal = 3;
            for (int ii = 0; ii < 9; ii++)
            {
                _drawYValues = YVal.ToString();
                g.DrawLine(pen, 6, 222 - c, 14, 222 - c);
                g.DrawLine(Pen, 14, 222 - c, 510, 222 - c);
                g.DrawString(_drawYValues, drawFont2, drawBrush, -3, 220 - c, drawFormat);
                YVal = YVal + 3;
                c = c + 20;
            }
            g.DrawString(drawZero, drawFont2, drawBrush, 0, 222, drawFormat);
            _z++;
        }
        #endregion

        #region Reset
        private void resetButton_Click(object sender, EventArgs e)
        {
            Graphics g = pictureBoxGrafico.CreateGraphics();
            g.Clear(BackColor);
            //labelMex.Text = "";
            textBoxFilePath.Text = "";
            Pen pen2 = new Pen(Color.FromArgb(255, 0, 0, 0));
            Pen pen = new Pen(Color.FromArgb(25, 0, 0, 0));
            string drawStringX = "X";
            string drawStringY = "Y";
            string drawZero = "0";
            System.Drawing.Font drawFont = new System.Drawing.Font(FONT, 13);
            System.Drawing.Font drawFont2 = new System.Drawing.Font(FONT, 8);
            System.Drawing.Font drawFont3 = new System.Drawing.Font(FONT, 7);
            System.Drawing.SolidBrush drawBrush = new System.Drawing.SolidBrush(System.Drawing.Color.Black);
            System.Drawing.StringFormat drawFormat = new System.Drawing.StringFormat();
            g.DrawString(drawStringY, drawFont, drawBrush, 13, 0, drawFormat);
            g.DrawString(drawStringX, drawFont, drawBrush, 510, 210, drawFormat);
            g.DrawLine(pen2, 10, 10, 10, 222);
            g.DrawLine(pen2, 10, 222, 500, 222);
            g.DrawLine(pen2, 10, 5, 5, 20);
            g.DrawLine(pen2, 10, 5, 15, 20);
            g.DrawLine(pen2, 505, 222, 495, 218);
            g.DrawLine(pen2, 505, 222, 493, 229);
            DrawWithoutTransformation(g);
            int c = 2;
            for (int i = 0; i < 47; i = i + 2)
            {
                _drawXValues = c.ToString();
                g.DrawLine(pen2, CalcolaPuntoX(c), 218, CalcolaPuntoX(c), 225);
                g.DrawLine(pen, CalcolaPuntoX(c), 218, CalcolaPuntoX(c), 25);
                g.DrawString(_drawXValues, drawFont2, drawBrush, (CalcolaPuntoX(c)) - 6, 227, drawFormat);
                c = c + 2;
            }
            c = 20;
            int YVal = 3;
            for (int ii = 0; ii < 9; ii++)
            {
                _drawYValues = YVal.ToString();
                g.DrawLine(pen2, 6, 222 - c, 14, 222 - c);
                g.DrawLine(pen, 14, 222 - c, 510, 222 - c);
                g.DrawString(_drawYValues, drawFont2, drawBrush, -2, 220 - c, drawFormat);
                YVal = YVal + 3;
                c = c + 20;
            }
            g.DrawString(drawZero, drawFont2, drawBrush, 0, 222, drawFormat);
        }
        #endregion

        #region MouseHoverEvent
        private void pictureBoxGrafico_MouseHover(object sender, EventArgs e)
        {
            ToolTip tt = new ToolTip();
            //if ((_path == "") || (_path == "Seleziona un file"))
            //{
            //    tt.Dispose();
            //}
            //else
            //{
            //}
            //string tooltip = "";
            //if ((textBoxFilePath.ToString() == "") || (textBoxFilePath.ToString() == "Seleziona un file"))
            //{

            //}
            //else {
            //    StreamReader sr = new StreamReader(_path);
            //    int lines = File.ReadAllLines(_path).Length;
            //    for (int i = 0; i < lines; i++)
            //    {
            //        tooltip = tooltip + "Punto" + i + "-->X=" + _vex[i] + " Y=" + _vey[i];
            //    }
            //    tt.SetToolTip(pictureBoxGrafico, tooltip);
            //}

        }
        #endregion

        #region DrawTitle
        private void DrawWithoutTransformation(Graphics gr)
        {
            using (Font title_font = new Font(FONT, 20))
            {
                using (StringFormat string_format = new StringFormat())
                {
                    string_format.Alignment = StringAlignment.Center;
                    string_format.LineAlignment = StringAlignment.Center;
                    Point title_center = new Point(
                        pictureBoxGrafico.ClientSize.Width / 2, 20);
                    gr.DrawString("Graphic Viewer",
                        title_font, Brushes.Blue,
                        title_center, string_format);
                }
            }
        }
        #endregion
        #region MouseMove
        private void pictureBoxGrafico_MouseMove_1(object sender, MouseEventArgs e)
        {
            string toolTip = "";
            
            int p = 0;
            _tt.AutoPopDelay=200;
            _tt.ShowAlways = false;
            if ((textBoxFilePath.Text == "") || (textBoxFilePath.Text == "Seleziona un file")) return;
            if (_vx == null) return;
                    for (int m = 0; m < 13; m++)
                    {
                        p++;
                        if ((e.X >= (CalcolaPuntoX(_vx[m]) - TOLLERANZA)) && (e.X <= (CalcolaPuntoX(_vx[m]) + TOLLERANZA)))
                        {
                            if ((e.Y >= (CalcolaPuntoY(_vy[m]) - TOLLERANZA)) && (e.Y <= (CalcolaPuntoY(_vy[m]) + TOLLERANZA)))
                            {
                                toolTip = "Punto" + p + "--> X=" + _vx[m].ToString() + " Y=" + _vy[m].ToString();
                                m = 0;
                                break;
                            }
                        }
                    }
                    _tt.SetToolTip(pictureBoxGrafico, toolTip);
                    toolTip = "";
                    //toolTip = "Y->" + e.Y.ToString();
                    //tt.SetToolTip(pictureBoxGrafico, toolTip);
        }
        #endregion
        #region CalcolaPuntoX
        private int CalcolaPuntoX(int val)
        {
            int result;
            result = val * 10;
            return result;
        }
        #endregion
        #region CalcolaPuntoY
        private int CalcolaPuntoY(int val)
        {
            int result;
            result = 220 - ((val * 7) - 4);
            return result;
        }
        #endregion
        #region CollegaAY
        private int CollegaAY(int val)
        {
            int result;
            result = (220 - (val * 7) + 5);
            return result;
        }
        #endregion
    }
}