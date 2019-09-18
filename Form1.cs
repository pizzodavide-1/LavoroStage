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
        #region Const
        const string FONT = "Times new roman";
        const int TOLLERANZA = 5;
        const int SISTEMA_X = 10;
        const int SISTEMA_Y = 220;
        
        const int SCALA_X = 47;
        const int SCALA_Y = 9;
        const int BLACK = 255;
        const int BLUE = 0;
        const int RED = 0;
        const int GREEN = 0;
        const int ALPHA = 25;
        const int DIMENSIONI_FONT_1 = 13;
        const int DIMENSIONI_FONT_2 = 7;
        const int DIMENSIONI_FONT_TITOLO = 20;
        const int BASE_GRAFICO = 222;
        const int X_FRECCIA_1 = 5;
        const int X_FRECCIA_2 = 505;
        const int Y_FRECCIA_1 = 495;
        const int Y_FRECCIA_2 = 493;
        const int MAX_ASSE_X = 500;
        const int SEGMENTI_Y = 3;
        const int SEGMENTI_X = 218;
        const int DIMENSIONE_PUNTI = 4;
        const int X_SCRITTA_ASSE_Y = 510;
        const int Y_SCRITTA_ASSE_Y = 210;
        const int X_SCRITTA_ASSE_X = 13;
        const int Y_SCRITTA_ASSE_X = 0;
        const int LARGH_MINIMA = 534;
        const int ALT_MINIMA = 251;
        #endregion
        //int[] _vex = new int[999999];
        //int[] _vey = new int[999999];

        #region field
        int _z = 0;
        string _path = "";
         bool _button = false;
        //labelMex.Text = "";
        StreamReader _sr;
        ToolTip _tt = new ToolTip();
        int[] _vx;
        int _linee;
        bool _control = true;
        int[] _vy;
        int _differenceWidth;
        int _differeceneHeight;
        string _drawXValues;
        string _drawYValues;
        private PictureBox _pictureBox = new PictureBox();
        private Graphics _gr;

        #endregion
        public Form1()
        {
            InitializeComponent();
            _pictureBox.Paint += new System.Windows.Forms.PaintEventHandler(this.pictureBoxGrafico_Paint);
            this.Controls.Add(_pictureBox);
            //pictureBoxGrafico.Refresh();

        }
        #region Graphic
        private void buttonImportGraphic_Click(object sender, EventArgs e)
        {
                _path = textBoxFilePath.Text;
                if (textBoxFilePath.Text == "" || textBoxFilePath.Text == "Seleziona un file") //Se non si seleziona nessun file...
                {
                    //labelMex.Text = "";
                    textBoxFilePath.Text = "Seleziona un file";
                    Graphics g = pictureBoxGrafico.CreateGraphics();
                    g.Clear(BackColor);
                    Pen pen = new Pen(Color.FromArgb(BLACK, RED, GREEN, BLUE));
                    Pen Pen = new Pen(Color.FromArgb(ALPHA, RED, GREEN, BLUE));
                    string drawStringX = "X";
                    string drawStringY = "Y";
                    string drawZero = "0";
                    System.Drawing.Font drawFont = new System.Drawing.Font(FONT, DIMENSIONI_FONT_1);
                    System.Drawing.Font drawFont2 = new System.Drawing.Font(FONT, DIMENSIONI_FONT_2);
                    //System.Drawing.Font drawFont3 = new System.Drawing.Font(FONT, 7);
                    System.Drawing.SolidBrush drawBrush = new System.Drawing.SolidBrush(System.Drawing.Color.Black);
                    System.Drawing.StringFormat drawFormat = new System.Drawing.StringFormat();
                    g.DrawString(drawStringY, drawFont, drawBrush, X_SCRITTA_ASSE_X, Y_SCRITTA_ASSE_X, drawFormat);//disegna la scritta 'X'
                    g.DrawString(drawStringX, drawFont, drawBrush, X_SCRITTA_ASSE_Y, Y_SCRITTA_ASSE_Y, drawFormat);//disegna la scritta 'X'
                    g.DrawLine(pen, SISTEMA_X, SISTEMA_X, SISTEMA_X, BASE_GRAFICO);//Disegna Asse Y
                    g.DrawLine(pen, SISTEMA_X, BASE_GRAFICO, MAX_ASSE_X, BASE_GRAFICO);//Disegna Asse X
                    g.DrawLine(pen, SISTEMA_X, X_FRECCIA_1, X_FRECCIA_1, DIMENSIONI_FONT_TITOLO);//Disegna freccia...
                    g.DrawLine(pen, SISTEMA_X, X_FRECCIA_1, 15, DIMENSIONI_FONT_TITOLO);//...dell' asse Y
                    g.DrawLine(pen, X_FRECCIA_2, BASE_GRAFICO, Y_FRECCIA_1, SEGMENTI_X);//Disegna freccia...
                    g.DrawLine(pen, X_FRECCIA_2, BASE_GRAFICO, Y_FRECCIA_2, 229);//...dell' asse X
                    DrawWithoutTransformation(g);
                    int c = 2;
                    for (int i = 0; i < SCALA_X; i = i + 2)
                    {
                        //Disegno delle varie tacchette e i corrispettivi valori sull'asse delle x
                        _drawXValues = c.ToString();
                        g.DrawLine(pen, CalcolaPuntoX(c), SEGMENTI_X, CalcolaPuntoX(c), 225);
                        g.DrawLine(Pen, CalcolaPuntoX(c), SEGMENTI_X, CalcolaPuntoX(c), 25);
                        g.DrawString(_drawXValues, drawFont2, drawBrush, (CalcolaPuntoX(c)) - 6, 227, drawFormat);
                        c = c + 2;
                    }
                    c = DIMENSIONI_FONT_TITOLO;
                    int YVal = SEGMENTI_Y;
                    for (int ii = 0; ii < SCALA_Y; ii++)
                    {
                        //Disegno delle varie tacchette e i corrispettivi valori sull'asse delle y
                        _drawYValues = YVal.ToString();
                        g.DrawLine(pen, SISTEMA_X, BASE_GRAFICO - c, 15, BASE_GRAFICO - c);
                        g.DrawLine(Pen, 14, BASE_GRAFICO - c, X_SCRITTA_ASSE_Y, BASE_GRAFICO - c);
                        g.DrawString(_drawYValues, drawFont2, drawBrush, -3, SISTEMA_Y - c, drawFormat);
                        YVal = YVal + SEGMENTI_Y;
                        c = c + DIMENSIONI_FONT_TITOLO;
                    }
                    g.DrawString(drawZero, drawFont2, drawBrush, Y_SCRITTA_ASSE_X, BASE_GRAFICO, drawFormat);
                    Draw(g, this.Size.Width, this.Size.Height);
                }

                else if ((Directory.Exists(_path) == false) && (File.Exists(_path) == false))
                {
                    MessageBox.Show("Percorso non esistente", "Error",
                        MessageBoxButtons.OK);
                    //labelMex.Text = "Percorso non esistente";
                    string drawStringX = "X";
                    string drawStringY = "Y";
                    string drawZero = "0";
                    Pen pen = new Pen(Color.FromArgb(BLACK, RED, GREEN, BLUE));
                    Pen Pen = new Pen(Color.FromArgb(ALPHA, RED, GREEN, BLUE));
                    Graphics g = pictureBoxGrafico.CreateGraphics();
                    g.Clear(BackColor);
                    System.Drawing.Font drawFont = new System.Drawing.Font(FONT, DIMENSIONI_FONT_1);
                    System.Drawing.Font drawFont2 = new System.Drawing.Font(FONT, 8);
                    //System.Drawing.Font drawFont3 = new System.Drawing.Font(FONT, 7);
                    System.Drawing.SolidBrush drawBrush = new System.Drawing.SolidBrush(System.Drawing.Color.Black);
                    System.Drawing.StringFormat drawFormat = new System.Drawing.StringFormat();
                    g.DrawString(drawStringY, drawFont, drawBrush, X_SCRITTA_ASSE_X, Y_SCRITTA_ASSE_X, drawFormat);//disegna la scritta 'Y'
                    g.DrawString(drawStringX, drawFont, drawBrush, X_SCRITTA_ASSE_Y, Y_SCRITTA_ASSE_Y, drawFormat);//disegna la scritta 'X'
                    g.DrawLine(pen, SISTEMA_X, SISTEMA_X, SISTEMA_X, BASE_GRAFICO);//Disegna Asse Y
                    g.DrawLine(pen, SISTEMA_X, BASE_GRAFICO, MAX_ASSE_X, BASE_GRAFICO);//Disegna Asse X
                    g.DrawLine(pen, SISTEMA_X, X_FRECCIA_1, X_FRECCIA_1, DIMENSIONI_FONT_TITOLO);//Disegna freccia...
                    g.DrawLine(pen, SISTEMA_X, X_FRECCIA_1, 15, DIMENSIONI_FONT_TITOLO);//...dell' asse Y
                    g.DrawLine(pen, X_FRECCIA_2, BASE_GRAFICO, Y_FRECCIA_1, SEGMENTI_X);//Disegna freccia...
                    g.DrawLine(pen, X_FRECCIA_2, BASE_GRAFICO, Y_FRECCIA_2, 229);//...dell' asse X
                    DrawWithoutTransformation(g);
                    int c = 2;
                    for (int i = 0; i < SCALA_X; i = i + 2)
                    {
                        //Disegno delle varie tacchette e i corrispettivi valori sull'asse delle x
                        _drawXValues = c.ToString();
                        g.DrawLine(pen, CalcolaPuntoX(c), SEGMENTI_X, CalcolaPuntoX(c), 225);
                        g.DrawLine(Pen, CalcolaPuntoX(c), SEGMENTI_X, CalcolaPuntoX(c), 25);
                        g.DrawString(_drawXValues, drawFont2, drawBrush, (CalcolaPuntoX(c)) - 6, 227, drawFormat);
                        c = c + 2;
                    }
                    c = DIMENSIONI_FONT_TITOLO;
                    int YVal = SEGMENTI_Y;
                    for (int ii = 0; ii < SCALA_Y; ii++)
                    {
                        //Disegno delle varie tacchette e i corrispettivi valori sull'asse delle y
                        _drawYValues = YVal.ToString();
                        g.DrawLine(pen, SISTEMA_X, BASE_GRAFICO - c, 14, BASE_GRAFICO - c);
                        g.DrawLine(Pen, 14, BASE_GRAFICO - c, X_SCRITTA_ASSE_Y, BASE_GRAFICO - c);
                        g.DrawString(_drawYValues, drawFont2, drawBrush, -3, SISTEMA_Y - c, drawFormat);
                        YVal = YVal + SEGMENTI_Y;
                        c = c + DIMENSIONI_FONT_TITOLO;
                    }
                    g.DrawString(drawZero, drawFont2, drawBrush, Y_SCRITTA_ASSE_X, BASE_GRAFICO, drawFormat);
                    //Draw(g, this.Size.Width, this.Size.Height);
                }
                else
                {
                    //labelMex.Text = "";
                    _sr = new StreamReader(_path);

                    int lines = File.ReadAllLines(_path).Length;
                    _linee = lines;
                    _vx = new int[lines];
                    _vy = new int[lines];
                    Graphics g = pictureBoxGrafico.CreateGraphics();
                    for (int i = 0; i < _vx.Length; i++)
                    {
                        string line = _sr.ReadLine();
                        if (!line.Any(char.IsDigit))
                        {
                            MessageBox.Show("Nel file selezionato non ci sono Coordinate valide", "Error",
        MessageBoxButtons.OK); g.Clear(BackColor);
                            Pen pen2 = new Pen(Color.FromArgb(BLACK, RED, GREEN, BLUE));
                            Pen pen = new Pen(Color.FromArgb(ALPHA, RED, GREEN, BLUE));
                            string drawStringX = "X";
                            string drawStringY = "Y";
                            string drawZero = "0";
                            System.Drawing.Font drawFont = new System.Drawing.Font(FONT, DIMENSIONI_FONT_1);
                            System.Drawing.Font drawFont2 = new System.Drawing.Font(FONT, DIMENSIONI_FONT_2);
                            //System.Drawing.Font drawFont3 = new System.Drawing.Font(FONT, 7);
                            System.Drawing.SolidBrush drawBrush = new System.Drawing.SolidBrush(System.Drawing.Color.Black);
                            System.Drawing.StringFormat drawFormat = new System.Drawing.StringFormat();
                            g.DrawString(drawStringY, drawFont, drawBrush, X_SCRITTA_ASSE_X, Y_SCRITTA_ASSE_X, drawFormat);//disegna la scritta 'Y'
                            g.DrawString(drawStringX, drawFont, drawBrush, X_SCRITTA_ASSE_Y, Y_SCRITTA_ASSE_Y, drawFormat);//disegna la scritta 'X'
                            g.DrawLine(pen2, SISTEMA_X, SISTEMA_X, SISTEMA_X, BASE_GRAFICO);//Disegna Asse Y
                            g.DrawLine(pen2, SISTEMA_X, BASE_GRAFICO, MAX_ASSE_X, BASE_GRAFICO);//Disegna Asse X
                            g.DrawLine(pen2, SISTEMA_X, X_FRECCIA_1, X_FRECCIA_1, DIMENSIONI_FONT_TITOLO);//Disegna freccia...
                            g.DrawLine(pen2, SISTEMA_X, X_FRECCIA_1, 15, DIMENSIONI_FONT_TITOLO);//...dell' asse Y
                            g.DrawLine(pen2, X_FRECCIA_2, BASE_GRAFICO, Y_FRECCIA_1, SEGMENTI_X);//Disegna freccia...
                            g.DrawLine(pen2, X_FRECCIA_2, BASE_GRAFICO, Y_FRECCIA_2, 229);//...dell' asse X
                            DrawWithoutTransformation(g);
                            int c = 2;
                            for (int z = 0; z < SCALA_X; z = z + 2)
                            {
                                //Disegno delle varie tacchette e i corrispettivi valori sull'asse delle x
                                _drawXValues = c.ToString();
                                g.DrawLine(pen2, CalcolaPuntoX(c), SEGMENTI_X, CalcolaPuntoX(c), 225);
                                g.DrawLine(pen, CalcolaPuntoX(c), SEGMENTI_X, CalcolaPuntoX(c), 25);
                                g.DrawString(_drawXValues, drawFont2, drawBrush, (CalcolaPuntoX(c)) - 6, 227, drawFormat);
                                c = c + 2;
                            }
                            c = DIMENSIONI_FONT_TITOLO;
                            int YVal = 3;
                            for (int ii = 0; ii < SCALA_Y; ii++)
                            {
                                //Disegno delle varie tacchette e corrispettivi valori sull'asse delle y
                                _drawYValues = YVal.ToString();
                                g.DrawLine(pen2, SISTEMA_X, BASE_GRAFICO - c, 14, BASE_GRAFICO - c);
                                g.DrawLine(pen, 14, BASE_GRAFICO - c, X_SCRITTA_ASSE_Y, BASE_GRAFICO - c);
                                g.DrawString(_drawYValues, drawFont2, drawBrush, -3, SISTEMA_Y - c, drawFormat);
                                YVal = YVal + 3;
                                c = c + DIMENSIONI_FONT_TITOLO;
                            }
                            g.DrawString(drawZero, drawFont2, drawBrush, Y_SCRITTA_ASSE_X, BASE_GRAFICO, drawFormat);
                            //Draw(g, this.Size.Width, this.Size.Height);
                            break;
                        }
                        string[] split = line.Split(new char[] { ';' });
                        if ((!(line.Contains(";"))) && (!(Path.GetExtension(_path) == ".csv")))
                        {
                            MessageBox.Show("Nel file selezionato non ci sono Coordinate valide", "Error",
        MessageBoxButtons.OK);
                            //labelMex.Text = ;
                            g.Clear(BackColor);
                            Pen pen2 = new Pen(Color.FromArgb(BLACK, RED, GREEN, BLUE));
                            Pen pen = new Pen(Color.FromArgb(ALPHA, RED, GREEN, BLUE));
                            string drawStringX = "X";
                            string drawStringY = "Y";
                            string drawZero = "0";
                            System.Drawing.Font drawFont = new System.Drawing.Font(FONT, DIMENSIONI_FONT_1);
                            System.Drawing.Font drawFont2 = new System.Drawing.Font(FONT, DIMENSIONI_FONT_2);
                            //System.Drawing.Font drawFont3 = new System.Drawing.Font(FONT, 7);
                            System.Drawing.SolidBrush drawBrush = new System.Drawing.SolidBrush(System.Drawing.Color.Black);
                            System.Drawing.StringFormat drawFormat = new System.Drawing.StringFormat();
                            g.DrawString(drawStringY, drawFont, drawBrush, X_SCRITTA_ASSE_X, Y_SCRITTA_ASSE_X, drawFormat);//disegna la scritta 'Y'
                            g.DrawString(drawStringX, drawFont, drawBrush, X_SCRITTA_ASSE_Y, Y_SCRITTA_ASSE_Y, drawFormat);//disegna la scritta 'X'
                            g.DrawLine(pen2, SISTEMA_X, SISTEMA_X, SISTEMA_X, BASE_GRAFICO);//Disegna Asse Y
                            g.DrawLine(pen2, SISTEMA_X, BASE_GRAFICO, MAX_ASSE_X, BASE_GRAFICO);//Disegna Asse X
                            g.DrawLine(pen2, SISTEMA_X, X_FRECCIA_1, X_FRECCIA_1, DIMENSIONI_FONT_TITOLO);//Disegna freccia...
                            g.DrawLine(pen2, SISTEMA_X, X_FRECCIA_1, 15, DIMENSIONI_FONT_TITOLO);//...dell' asse Y
                            g.DrawLine(pen2, X_FRECCIA_2, BASE_GRAFICO, Y_FRECCIA_1, SEGMENTI_X);//Disegna freccia...
                            g.DrawLine(pen2, X_FRECCIA_2, BASE_GRAFICO, Y_FRECCIA_2, 229);//...dell' asse X
                            DrawWithoutTransformation(g);
                            int c = 2;
                            for (int z = 0; z < SCALA_X; z = z + 2)
                            {
                                //Disegno delle varie tacchette e i corrispettivi valori sull'asse delle x
                                _drawXValues = c.ToString();
                                g.DrawLine(pen2, CalcolaPuntoX(c), SEGMENTI_X, CalcolaPuntoX(c), 225);
                                g.DrawLine(pen, CalcolaPuntoX(c), SEGMENTI_X, CalcolaPuntoX(c), 25);
                                g.DrawString(_drawXValues, drawFont2, drawBrush, (CalcolaPuntoX(c)) - 6, 227, drawFormat);
                                c = c + 2;
                            }
                            c = DIMENSIONI_FONT_TITOLO;
                            int YVal = SEGMENTI_Y;
                            for (int ii = 0; ii < SCALA_Y; ii++)
                            {
                                //Disegno delle varie tacchette e corrispettivi valori sull'asse delle y
                                _drawYValues = YVal.ToString();
                                g.DrawLine(pen2, SISTEMA_X, BASE_GRAFICO - c, 14, BASE_GRAFICO - c);
                                g.DrawLine(pen, 14, BASE_GRAFICO - c, X_SCRITTA_ASSE_Y, BASE_GRAFICO - c);
                                g.DrawString(_drawYValues, drawFont2, drawBrush, -3, SISTEMA_Y - c, drawFormat);
                                YVal = YVal + SEGMENTI_Y;
                                c = c + DIMENSIONI_FONT_TITOLO;
                            }
                            g.DrawString(drawZero, drawFont2, drawBrush, Y_SCRITTA_ASSE_X, BASE_GRAFICO, drawFormat);
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

                        g.FillEllipse(Brushes.Red, new Rectangle(CalcolaPuntoX(_vx[i]), CalcolaPuntoY(_vy[i]), DIMENSIONE_PUNTI, DIMENSIONE_PUNTI));
                        if (i == 0)
                        {
                            g.DrawLine(penX, SISTEMA_X, BASE_GRAFICO, CalcolaPuntoX(_vx[i]), CollegaAY(_vy[i]));
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
            if (_control == true) {
                Graphics g = pictureBoxGrafico.CreateGraphics();
                Pen pen = new Pen(Color.FromArgb(BLACK, RED, GREEN, BLUE));
                Pen Pen = new Pen(Color.FromArgb(ALPHA, RED, GREEN, BLUE));
                string drawStringX = "X";
                string drawStringY = "Y";
                string drawZero = "0";
                System.Drawing.Font drawFont = new System.Drawing.Font(FONT, DIMENSIONI_FONT_1);
                System.Drawing.Font drawFont2 = new System.Drawing.Font(FONT, DIMENSIONI_FONT_2);
                //System.Drawing.Font drawFont3 = new System.Drawing.Font("Times new roman", 7);
                System.Drawing.SolidBrush drawBrush = new System.Drawing.SolidBrush(System.Drawing.Color.Black);
                System.Drawing.StringFormat drawFormat = new System.Drawing.StringFormat();
                g.DrawString(drawStringY, drawFont, drawBrush, X_SCRITTA_ASSE_X, Y_SCRITTA_ASSE_X, drawFormat); //disegna la scritta 'Y'
                g.DrawString(drawStringX, drawFont, drawBrush, X_SCRITTA_ASSE_Y, Y_SCRITTA_ASSE_Y, drawFormat); //disegna la scritta 'X'
                g.DrawLine(pen, SISTEMA_X, SISTEMA_X, SISTEMA_X, BASE_GRAFICO); //Disegna Asse Y
                g.DrawLine(pen, SISTEMA_X, BASE_GRAFICO, MAX_ASSE_X, BASE_GRAFICO); //Disegna Asse X
                g.DrawLine(pen, SISTEMA_X, X_FRECCIA_1, X_FRECCIA_1, DIMENSIONI_FONT_TITOLO); //Disegna freccia...
                g.DrawLine(pen, SISTEMA_X, X_FRECCIA_1, 15, DIMENSIONI_FONT_TITOLO);//...dell' asse Y
                g.DrawLine(pen, X_FRECCIA_2, BASE_GRAFICO, Y_FRECCIA_1, SEGMENTI_X);//Disegna freccia...
                g.DrawLine(pen, X_FRECCIA_2, BASE_GRAFICO, Y_FRECCIA_2, 229);//...dell'asse X
                DrawWithoutTransformation(g);
                int c = 2;
                for (int i = 0; i < SCALA_X; i = i + 2)
                {
                    //Disegno delle varie tacchette e i corrispettivi valori sull'asse delle x
                    _drawXValues = c.ToString();
                    g.DrawLine(pen, CalcolaPuntoX(c), SEGMENTI_X, CalcolaPuntoX(c), 225);
                    g.DrawLine(Pen, CalcolaPuntoX(c), SEGMENTI_X, CalcolaPuntoX(c), 25);
                    g.DrawString(_drawXValues, drawFont2, drawBrush, (CalcolaPuntoX(c)) - 6, 227, drawFormat);
                    c = c + 2;
                }
                c = DIMENSIONI_FONT_TITOLO;
                int YVal = SEGMENTI_Y;
                for (int ii = 0; ii < SCALA_Y; ii++)
                {
                    //Disegno delle varie tacchette e corrispettivi valori sull'asse delle y
                    _drawYValues = YVal.ToString();
                    g.DrawLine(pen, SISTEMA_X, BASE_GRAFICO - c, 14, BASE_GRAFICO - c);
                    g.DrawLine(Pen, 14, BASE_GRAFICO - c, X_SCRITTA_ASSE_Y, BASE_GRAFICO - c);
                    g.DrawString(_drawYValues, drawFont2, drawBrush, -SEGMENTI_Y, SISTEMA_Y - c, drawFormat);
                    YVal = YVal + SEGMENTI_Y;
                    c = c + DIMENSIONI_FONT_TITOLO;
                }
                g.DrawString(drawZero, drawFont2, drawBrush, Y_SCRITTA_ASSE_X, BASE_GRAFICO, drawFormat);
                _z++;
            }
           
        }
        #endregion

        #region Reset
        private void resetButton_Click(object sender, EventArgs e)
        {
            
            Graphics g = pictureBoxGrafico.CreateGraphics();
            g.Clear(BackColor);
            //labelMex.Text = "";
            textBoxFilePath.Text = "";
            Pen pen2 = new Pen(Color.FromArgb(BLACK, RED, GREEN, BLUE));
            Pen pen = new Pen(Color.FromArgb(ALPHA, RED, GREEN, BLUE));
            string drawStringX = "X";
            string drawStringY = "Y";
            string drawZero = "0";
            System.Drawing.Font drawFont = new System.Drawing.Font(FONT, DIMENSIONI_FONT_1);
            System.Drawing.Font drawFont2 = new System.Drawing.Font(FONT, DIMENSIONI_FONT_2);
            //System.Drawing.Font drawFont3 = new System.Drawing.Font(FONT, 7);
            System.Drawing.SolidBrush drawBrush = new System.Drawing.SolidBrush(System.Drawing.Color.Black);
            System.Drawing.StringFormat drawFormat = new System.Drawing.StringFormat();
            g.DrawString(drawStringY, drawFont, drawBrush, X_SCRITTA_ASSE_X, Y_SCRITTA_ASSE_X, drawFormat);//disegna la scritta 'Y'
            g.DrawString(drawStringX, drawFont, drawBrush, X_SCRITTA_ASSE_Y, Y_SCRITTA_ASSE_Y, drawFormat);//disegna la scritta 'X'
            g.DrawLine(pen2, SISTEMA_X, SISTEMA_X, SISTEMA_X, BASE_GRAFICO);//Disegna Asse Y
            g.DrawLine(pen2, SISTEMA_X, BASE_GRAFICO, MAX_ASSE_X, BASE_GRAFICO);//Disegna Asse X
            g.DrawLine(pen2, SISTEMA_X, X_FRECCIA_1, X_FRECCIA_1, DIMENSIONI_FONT_TITOLO);//Disegna freccia...
            g.DrawLine(pen2, SISTEMA_X, X_FRECCIA_1, 15, DIMENSIONI_FONT_TITOLO);//...dell' asse Y
            g.DrawLine(pen2, X_FRECCIA_2, BASE_GRAFICO, Y_FRECCIA_1, SEGMENTI_X);//Disegna freccia...
            g.DrawLine(pen2, X_FRECCIA_2, BASE_GRAFICO, Y_FRECCIA_2, 229);//...dell' asse X
            DrawWithoutTransformation(g);
            int c = 2;
            for (int i = 0; i < SCALA_X; i = i + 2)
            {
                //Disegno delle varie tacchette e i corrispettivi valori sull'asse delle x
                _drawXValues = c.ToString();
                g.DrawLine(pen2, CalcolaPuntoX(c), SEGMENTI_X, CalcolaPuntoX(c), 225);
                g.DrawLine(pen, CalcolaPuntoX(c), SEGMENTI_X, CalcolaPuntoX(c), 25);
                g.DrawString(_drawXValues, drawFont2, drawBrush, (CalcolaPuntoX(c)) - 6, 227, drawFormat);
                c = c + 2;
            }
            c = DIMENSIONI_FONT_TITOLO;
            int YVal = SEGMENTI_Y;
            for (int ii = 0; ii < SCALA_Y; ii++)
            {
                //Disegno delle varie tacchette e corrispettivi valori sull'asse delle y
                _drawYValues = YVal.ToString();
                g.DrawLine(pen2, SISTEMA_X, BASE_GRAFICO - c, 14, BASE_GRAFICO - c);
                g.DrawLine(pen, 14, BASE_GRAFICO - c, X_SCRITTA_ASSE_Y, BASE_GRAFICO - c);
                g.DrawString(_drawYValues, drawFont2, drawBrush, -2, SISTEMA_Y - c, drawFormat);
                YVal = YVal + SEGMENTI_Y;
                c = c + DIMENSIONI_FONT_TITOLO;
            }
            g.DrawString(drawZero, drawFont2, drawBrush, Y_SCRITTA_ASSE_X, BASE_GRAFICO, drawFormat);
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
        #region MouseMove
        private void pictureBoxGrafico_MouseMove_1(object sender, MouseEventArgs e)
        {
            string toolTip = "";
            int p = 0;
            _tt.AutoPopDelay = 200;
            _tt.ShowAlways = false;

            if ((textBoxFilePath.Text == "") || (textBoxFilePath.Text == "Seleziona un file")) return;
            if (_vx == null) return;
            for (int m = 0; m < _linee; m++)
            {
                //Coordinate Punto = new Coordinate(Convert.ToDouble(_vx[m]), Convert.ToDouble(_vy[m]));
                //_Punti.Add(Punto);
                p++;
                if ((e.X >= (CalcolaPuntoX(_vx[m]) - TOLLERANZA)) && (e.X <= (CalcolaPuntoX(_vx[m]) + TOLLERANZA))) //Se il cursore del mouse e compreso nella tolleranza stabilita..
                {
                    if ((e.Y >= (CalcolaPuntoY(_vy[m]) - TOLLERANZA)) && (e.Y <= (CalcolaPuntoY(_vy[m]) + TOLLERANZA)))
                    {
                        toolTip = "Punto" + p + "--> X=" + _vx[m].ToString() + " Y=" + _vy[m].ToString();
                        m = 0;
                        break;
                    }
                }
                //if (e.X >= (CalcolaPuntoX(Convert.ToInt32(_Punti.ElementAt(m).X) - TOLLERANZA)) && (e.X <= (CalcolaPuntoX(Convert.ToInt32(_Punti.ElementAt(m).X) + TOLLERANZA))))
                //{
                //    if (e.Y >= (CalcolaPuntoY(Convert.ToInt32(_Punti.ElementAt(m).Y) - TOLLERANZA)) && (e.Y >= (CalcolaPuntoY(Convert.ToInt32(_Punti.ElementAt(m).Y) + TOLLERANZA))))
                //    {
                //        toolTip = "Punto" + p + "--> X=" + _Punti.ElementAt(m).X.ToString() + " Y=" + _Punti.ElementAt(m).Y.ToString();
                //        m = 0;
                //        break;
                //    } 
                //}

            }
            _tt.SetToolTip(pictureBoxGrafico, toolTip);
            toolTip = "";
        }
        #endregion

        #region DrawTitle
        private void DrawWithoutTransformation(Graphics gr) //Funzione che serve per disegnare il titolo 
        {
          
            using (Font title_font = new Font(FONT, DIMENSIONI_FONT_TITOLO))
            {
                using (StringFormat string_format = new StringFormat())
                    
                {
                    string_format.Alignment = StringAlignment.Center;
                    string_format.LineAlignment = StringAlignment.Center;
                    Point title_center = new Point(
                        pictureBoxGrafico.ClientSize.Width / 2, DIMENSIONI_FONT_TITOLO);
                   
                    gr.DrawString("Graphic Viewer",
                        title_font, Brushes.Blue,
                        title_center, string_format);
                    
                }
            }
        }
        #endregion
        #region SizeChanged
        private void pictureBoxGrafico_SizeChanged(object sender, EventArgs e)
        {
            _differenceWidth = (pictureBoxGrafico.Width) - LARGH_MINIMA;
            _differeceneHeight = (pictureBoxGrafico.Height) - ALT_MINIMA;
            Clear(_gr);
            Draw(_gr, _differenceWidth, _differeceneHeight);
            _control = false;
            _button = true;
            //Size sz = new Size();
            //int largh = sz.Width;
            //Point x = new Point(pictureBoxGrafico.ClientSize.Width);
        }
        #endregion
        #region Draw
        private void Draw(Graphics g, int Width, int Height)
        {
        
            g = pictureBoxGrafico.CreateGraphics();
            Pen pen = new Pen(Color.FromArgb(BLACK, RED, GREEN, BLUE));
            Pen Pen = new Pen(Color.FromArgb(ALPHA, RED, GREEN, BLUE));
            string drawStringX = "X";
            string drawStringY = "Y";
            string drawZero = "0";
            System.Drawing.Font drawFont = new System.Drawing.Font(FONT, DIMENSIONI_FONT_1);
            System.Drawing.Font drawFont2 = new System.Drawing.Font(FONT, DIMENSIONI_FONT_2);
            //System.Drawing.Font drawFont3 = new System.Drawing.Font("Times new roman", 7);
            System.Drawing.SolidBrush drawBrush = new System.Drawing.SolidBrush(System.Drawing.Color.Black);
            System.Drawing.StringFormat drawFormat = new System.Drawing.StringFormat();
            g.DrawString(drawStringY, drawFont, drawBrush, X_SCRITTA_ASSE_X, Y_SCRITTA_ASSE_X, drawFormat); //disegna la scritta 'Y'
            g.DrawString(drawStringX, drawFont, drawBrush, X_SCRITTA_ASSE_Y + Width, Y_SCRITTA_ASSE_Y +Height, drawFormat); //disegna la scritta 'X'
            g.DrawLine(pen, SISTEMA_X, SISTEMA_X, SISTEMA_X, BASE_GRAFICO + Height); //Disegna Asse Y
            g.DrawLine(pen, SISTEMA_X, BASE_GRAFICO +Height, MAX_ASSE_X + Width, BASE_GRAFICO + Height); //Disegna Asse X
            //g.DrawLine(pen, SISTEMA_X, X_FRECCIA_1, X_FRECCIA_1, DIMENSIONI_FONT_TITOLO); //Disegna freccia...
            //g.DrawLine(pen, SISTEMA_X, X_FRECCIA_1, 15, DIMENSIONI_FONT_TITOLO);//...dell' asse Y
            //g.DrawLine(pen, X_FRECCIA_2 + Width, BASE_GRAFICO + Height, Y_FRECCIA_1 + Height, SEGMENTI_X + Width);//Disegna freccia...
            //g.DrawLine(pen, X_FRECCIA_2 + Width, BASE_GRAFICO + Height, Y_FRECCIA_2 + Height, 229 + Width);//...dell'asse X 

            int c = 2;
            int a = 0;
            for (int i = 0; i < SCALA_X; i = i + 2)
            {
                //Disegna le varie tacchette e i corrispettivi valori sull'asse delle x
                _drawXValues = c.ToString();
               g.DrawLine(pen,  CalcolaPuntoX(a) + Width, SEGMENTI_X + Height, CalcolaPuntoX(a) + Width, 225+Height); //tacchette
                g.DrawLine(Pen, CalcolaPuntoX(a) + Width, SEGMENTI_X + Height, CalcolaPuntoX(a) + Width, -918 + Height); //linee grigie
                g.DrawString(_drawXValues, drawFont2, drawBrush, ((CalcolaPuntoX(a)) - 6)+Width , 227 + Height , drawFormat); //valori
                c = c + 2;
                a = a + (Width/50)+2;
            }
            c = DIMENSIONI_FONT_TITOLO;
            int YVal = SEGMENTI_Y;
            for (int ii = 0; ii < SCALA_Y; ii++)
            {
                //Disegna le varie tacchette e corrispettivi valori sull'asse delle y
                _drawYValues = YVal.ToString();
                g.DrawLine(pen, SISTEMA_X, (BASE_GRAFICO - c) + Height, 14, (BASE_GRAFICO - c) + Height);
                g.DrawLine(Pen, 14, (BASE_GRAFICO - c) , 1893, (BASE_GRAFICO - c) );
                g.DrawString(_drawYValues, drawFont2, drawBrush, SEGMENTI_Y, (SISTEMA_Y - c) + Height, drawFormat);
                YVal = YVal + SEGMENTI_Y;
                c = c + DIMENSIONI_FONT_TITOLO+Height;
            }
            g.DrawString(drawZero, drawFont2, drawBrush, Y_SCRITTA_ASSE_X, BASE_GRAFICO + Height, drawFormat);
            DrawWithoutTransformation(g);
            ///////////////////////////////////////////////////////////////////////////
             //if (_button==false) {
             //    _path = textBoxFilePath.Text;
             //    if (textBoxFilePath.Text == "" || textBoxFilePath.Text == "Seleziona un file") //Se non si seleziona nessun file...
             //    {
             //        textBoxFilePath.Text = "Seleziona un file";
             //        g.Clear(BackColor);
             //        g.DrawString(drawStringY, drawFont, drawBrush, X_SCRITTA_ASSE_X, Y_SCRITTA_ASSE_X, drawFormat); //disegna la scritta 'Y'
             //        g.DrawString(drawStringX, drawFont, drawBrush, X_SCRITTA_ASSE_Y + Width, Y_SCRITTA_ASSE_Y + Height, drawFormat); //disegna la scritta 'X'
             //        g.DrawLine(pen, SISTEMA_X, SISTEMA_X, SISTEMA_X, BASE_GRAFICO + Height); //Disegna Asse Y
             //        g.DrawLine(pen, SISTEMA_X, BASE_GRAFICO + Height, MAX_ASSE_X + Width, BASE_GRAFICO + Height); //Disegna Asse X
             //        //g.DrawLine(pen, SISTEMA_X, X_FRECCIA_1, X_FRECCIA_1, DIMENSIONI_FONT_TITOLO);//Disegna freccia...
             //        //g.DrawLine(pen, SISTEMA_X, X_FRECCIA_1, 15, DIMENSIONI_FONT_TITOLO);//...dell' asse Y
             //        //g.DrawLine(pen, X_FRECCIA_2, BASE_GRAFICO, Y_FRECCIA_1, SEGMENTI_X);//Disegna freccia...
             //        //g.DrawLine(pen, X_FRECCIA_2, BASE_GRAFICO, Y_FRECCIA_2, 229);//...dell' asse X
             //        DrawWithoutTransformation(g);
             //         c = 2;
             //          a = 0;
             //        for (int i = 0; i < SCALA_X; i = i + 2)
             //        {
             //            //Disegno delle varie tacchette e i corrispettivi valori sull'asse delle x
             //            _drawXValues = c.ToString();
             //            g.DrawLine(pen, CalcolaPuntoX(a) + Width, SEGMENTI_X + Height, CalcolaPuntoX(a) + Width, 225 + Height); //tacchette
             //            g.DrawLine(Pen, CalcolaPuntoX(a) + Width, SEGMENTI_X + Height, CalcolaPuntoX(a) + Width, -918 + Height); //linee grigie
             //            g.DrawString(_drawXValues, drawFont2, drawBrush, ((CalcolaPuntoX(a)) - 6) + Width, 227 + Height, drawFormat); //valori
             //            c = c + 2;
             //            a = a + (Width / 50) + 2;
             //        }
             //        c = DIMENSIONI_FONT_TITOLO;
             //         YVal = SEGMENTI_Y;
             //        for (int ii = 0; ii < SCALA_Y; ii++)
             //        {
             //           // Disegno delle varie tacchette e i corrispettivi valori sull'asse delle y
             //            _drawYValues = YVal.ToString();
             //            g.DrawLine(pen, SISTEMA_X, (BASE_GRAFICO - c) + Height, 14, (BASE_GRAFICO - c) + Height);
             //            g.DrawLine(Pen, 14, (BASE_GRAFICO - c), 1893, (BASE_GRAFICO - c));
             //            g.DrawString(_drawYValues, drawFont2, drawBrush, SEGMENTI_Y, (SISTEMA_Y - c) + Height, drawFormat);
             //            YVal = YVal + SEGMENTI_Y;
             //            c = c + DIMENSIONI_FONT_TITOLO+Height;
             //        }
             //        g.DrawString(drawZero, drawFont2, drawBrush, Y_SCRITTA_ASSE_X, BASE_GRAFICO + Height, drawFormat);
             //    }
             //} 
            /////////////////////////////////////////////////////////////////////////
        }
        #endregion
        #region Clear
        private void Clear(Graphics g) {
            g = pictureBoxGrafico.CreateGraphics();
            g.Clear(BackColor);
        }
        #endregion
        #region CalcolaPuntoX
        private int CalcolaPuntoX(int val)
        {
            int result;
            result = val * SISTEMA_X;
            return result;
        }
        #endregion
        #region CalcolaPuntoY
        private int CalcolaPuntoY(int val)
        {
            int result;
            result = SISTEMA_Y - ((val * 7) - DIMENSIONE_PUNTI);
            return result;
        }
        #endregion
        #region CollegaAY

        private int CollegaAY(int val)
        {
            int result;
            result = (SISTEMA_Y - (val * 7) + TOLLERANZA);
            return result;
        }
        #endregion
     
    }
}