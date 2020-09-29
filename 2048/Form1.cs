using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Data.SQLite;
using System.Windows.Forms;

namespace _2048
{
    public partial class Form1 : Form
    {
        bool dark, soft = false;
        bool sun = true;
                
        public int[,] map = new int[4, 4];
        public Label[,] labels = new Label[4, 4];
        public PictureBox[,] pics = new PictureBox[4, 4];
        private int score = 0;
        
        /// ////////////////////////////////
        Color MyBackColor = new Color();
        Color PanelColor = new Color();
        Color col1 = new Color();
        Color col2 = new Color();
        Color col3 = new Color();
        Color col4 = new Color();
        Color col5 = new Color();
        Color col6 = new Color();
        Color col7 = new Color();
        Color col8 = new Color();
        Color col9 = new Color();
        Color col10 = new Color();
        Color col11 = new Color();
        Color col12 = new Color();
        Color col13 = new Color();
        Color col14 = new Color();
        


        public void SetColors()
        {
            if (sun == true)
            {
                MyBackColor = Color.FromArgb(20, 19, 24);
                PanelColor = Color.FromArgb(56, 31, 59);
                col1 = Color.FromArgb(254,227,103);
                col2 = Color.FromArgb(254,227,126);
                col3 = Color.FromArgb(254,227,153);
                col4 = Color.FromArgb(254,210,170);
                col5 = Color.FromArgb(251,181,155);
                col6 = Color.FromArgb(255,147,147);
                col7 = Color.FromArgb(236,108,123);
                col8 = Color.FromArgb(255,86,115);
                col9 = Color.FromArgb(175,85,111);
                col10 = Color.FromArgb(132,65,98);
                col11 = Color.FromArgb(90,40,78);
                col12 = Color.FromArgb(74,40,78);
                col13 = Color.FromArgb(68,40,78);
                col14 = Color.FromArgb(56,31,59);

                this.BackColor = MyBackColor;
                panel1.BackColor = PanelColor;
                label1.BackColor = PanelColor;
                label2.BackColor = PanelColor;
                label3.BackColor = PanelColor;
                label4.BackColor = PanelColor;
                label5.BackColor = PanelColor;
                label6.BackColor = PanelColor;
                label7.BackColor = PanelColor;

                DarkTheme.BackColor = PanelColor;
                SoftTheme.BackColor = PanelColor;
                SunsetTheme.BackColor = PanelColor;
                for (int i = 0; i < 4; i++)
                {
                    for (int j = 0; j < 4; j++)
                    {
                        if (labels[i, j] != null)
                            labels[i, j].ForeColor = MyBackColor;
                    }
                }
                for (int i = 0; i < 4; i++)
                {
                    for (int j = 0; j < 4; j++)
                    {
                        if (pics[i, j] != null)
                        {
                            int a = int.Parse(labels[i, j].Text);
                            changeColor(a, i, j);
                        }
                    }
                }
            }
            else if(dark == true)
            {
                MyBackColor = Color.FromArgb(0,0,0);
                PanelColor = Color.FromArgb(23,18,50);
                col1 = Color.FromArgb(215,196,224);
                col2 = Color.FromArgb(202,182,219);
                col3 = Color.FromArgb(188,169,214);
                col4 = Color.FromArgb(172,155,209);
                col5 = Color.FromArgb(155,137,197);
                col6 = Color.FromArgb(138,124,186);
                col7 = Color.FromArgb(120,110,173);
                col8 = Color.FromArgb(102,97,163);
                col9 = Color.FromArgb(85, 86, 150);
                col10 = Color.FromArgb(61,66,122);
                col11 = Color.FromArgb(59,49,110);
                col12 = Color.FromArgb(38,30,77);
                col13 = Color.FromArgb(38,18,69);
                col14 = Color.FromArgb(23,18,50);

                this.BackColor = MyBackColor;
                panel1.BackColor = PanelColor;
                label1.BackColor = PanelColor;
                label2.BackColor = PanelColor;
                label3.BackColor = PanelColor;
                label4.BackColor = PanelColor;
                label5.BackColor = PanelColor;
                label6.BackColor = PanelColor;
                label7.BackColor = PanelColor;
                DarkTheme.BackColor = PanelColor;
                SoftTheme.BackColor = PanelColor;
                SunsetTheme.BackColor = PanelColor;
                for(int i=0;i<4;i++)
                {
                    for(int j=0;j<4;j++)
                    {
                        if(labels[i,j]!=null)
                        labels[i, j].ForeColor = MyBackColor;
                    }
                }

                for (int i = 0; i < 4; i++)
                {
                    for (int j = 0; j < 4; j++)
                    {
                        if (pics[i, j] != null)
                        {
                            int a = int.Parse(labels[i,j].Text);
                            changeColor(a, i, j); }
                    }
                }


            }
            else if(soft == true)
            {
                MyBackColor = Color.FromArgb(207,100,54);
                PanelColor = Color.FromArgb(253,131,57);
                col1 = Color.FromArgb(254,248,232);
                col2 = Color.FromArgb(250,255,196);
                col3 = Color.FromArgb(250,241,166);
                col4 = Color.FromArgb(252,229,153);
                col5 = Color.FromArgb(253,221,136);
                col6 = Color.FromArgb(253,213,118);
                col7 = Color.FromArgb(252,203,100);
                col8 = Color.FromArgb(249,198,89);
                col9 = Color.FromArgb(249,188,82);
                col10 = Color.FromArgb(255,168,79);
                col11 = Color.FromArgb(255,155,73);
                col12 = Color.FromArgb(253,145,72);
                col13 = Color.FromArgb(253,137,66);
                col14 = Color.FromArgb(253,131,57);

                this.BackColor = MyBackColor;
                panel1.BackColor = PanelColor;
                label1.BackColor = PanelColor;
                label2.BackColor = PanelColor;
                label3.BackColor = PanelColor;
                label4.BackColor = PanelColor;
                label5.BackColor = PanelColor;
                label6.BackColor = PanelColor;
                label7.BackColor = PanelColor;
                DarkTheme.BackColor = PanelColor;
                SoftTheme.BackColor = PanelColor;
                SunsetTheme.BackColor = PanelColor;
                for (int i = 0; i < 4; i++)
                {
                    for (int j = 0; j < 4; j++)
                    {
                        if (labels[i, j] != null)
                            labels[i, j].ForeColor = MyBackColor;
                    }
                }
                for (int i = 0; i < 4; i++)
                {
                    for (int j = 0; j < 4; j++)
                    {
                        if (pics[i, j] != null)
                        {
                            int a = int.Parse(labels[i, j].Text);
                            changeColor(a, i, j);
                        }
                    }
                }

            }

        }
        

        /// ////////////////////////////////
        /// ////////////////////////////////
        
        public Form1()
        {
            InitializeComponent();
            SetColors();
            this.KeyDown += new KeyEventHandler(_keyboardEvent);
            map[0, 0] = 1;
            map[0, 1] = 1;
            createMap();
            createPics();
            generateNewPic();
            
        }
        private void createMap()
        {
            for (int i = 0; i < 4; i++)
            {
                for (int j = 0; j < 4; j++)
                {
                    PictureBox pic = new PictureBox();
                    pic.Location = new Point(14 + 124 * j, 114 + 124 * i);
                    pic.Size = new Size(117, 115);                    
                    this.Controls.Add(pic);
                }
            }
        }

        private void generateNewPic()
        {
            Random rnd = new Random();
            int a = rnd.Next(0, 4);
            int b = rnd.Next(0, 4);

            while (pics[a, b] != null)
            {
                a = rnd.Next(0, 4);
                b = rnd.Next(0, 4);
            }

            map[a, b] = 1;
            pics[a, b] = new PictureBox();
            labels[a, b] = new Label();
            labels[a, b].Text = "2";
            labels[a, b].Size = new Size(117, 115);
            labels[a, b].Font = new Font("Comic Sans MS", 21);
            labels[a, b].ForeColor = MyBackColor;
            labels[a,b].TextAlign = ContentAlignment.MiddleCenter;
            pics[a, b].Controls.Add(labels[a, b]);
            pics[a, b].Location = new Point(14 + b * 124, 114 + 124 * a);
            pics[a, b].Size = new Size(117, 115);
            pics[a, b].BackColor = col1;
            this.Controls.Add(pics[a, b]);
            pics[a, b].BringToFront();
        }
        private void createPics()
        {
            pics[0, 0] = new PictureBox();
            labels[0, 0] = new Label();
            labels[0, 0].Text = "2";
            labels[0, 0].Size = new Size(117, 115);
            labels[0, 0].Font = new Font("Comic Sans MS", 21);
            labels[0, 0].ForeColor = MyBackColor;
            labels[0, 0].TextAlign = ContentAlignment.MiddleCenter;
            pics[0, 0].Controls.Add(labels[0, 0]);
            pics[0, 0].Location = new Point(14, 114);
            pics[0, 0].Size = new Size(117, 115);
            pics[0, 0].BackColor = col1;
            this.Controls.Add(pics[0, 0]);
            pics[0, 0].BringToFront();

            pics[0, 1] = new PictureBox();
            labels[0, 1] = new Label();
            labels[0, 1].Text = "2";
            labels[0, 1].Size = new Size(117, 115);
            labels[0, 1].Font = new Font("Comic Sans MS", 21);
            labels[0, 1].ForeColor = MyBackColor;
            labels[0, 1].TextAlign = ContentAlignment.MiddleCenter;
            pics[0, 1].Controls.Add(labels[0, 1]);
            pics[0, 1].Location = new Point(138, 114);
            pics[0, 1].Size = new Size(117, 115);
            pics[0, 1].BackColor = col1;
            this.Controls.Add(pics[0, 1]);
            pics[0, 1].BringToFront();

        }
        private void changeColor(int sum, int k, int j)
        {
            if (sun == true)
            {
                if (sum == 16384)
                    pics[k, j].BackColor = col14;
                else if (sum == 8192)
                    pics[k, j].BackColor = col13;
                else if (sum == 4096)
                    pics[k, j].BackColor = col12;
                else if (sum == 2048)
                    pics[k, j].BackColor = col11;
                else if (sum == 1024)
                    pics[k, j].BackColor = col10;
                else if (sum == 512)
                    pics[k, j].BackColor = col9;
                else if (sum == 256)
                    pics[k, j].BackColor = col8;
                else if (sum == 128)
                    pics[k, j].BackColor = col7;
                else if (sum == 64)
                    pics[k, j].BackColor = col6;
                else if (sum == 32)
                    pics[k, j].BackColor = col5;
                else if (sum == 16)
                    pics[k, j].BackColor = col4;
                else if (sum == 8)
                    pics[k, j].BackColor = col3;
                else if (sum == 4)
                    pics[k, j].BackColor = col2;
                else
                    pics[k, j].BackColor = col1;
            }
            else if(dark==true)
            {
                if (sum == 16384)
                    pics[k, j].BackColor = col14;
                else if (sum == 8192)
                    pics[k, j].BackColor = col13;
                else if (sum == 4096)
                    pics[k, j].BackColor = col12;
                else if (sum == 2048)
                    pics[k, j].BackColor = col11;
                else if (sum == 1024)
                    pics[k, j].BackColor = col10;
                else if (sum == 512)
                    pics[k, j].BackColor = col9;
                else if (sum == 256)
                    pics[k, j].BackColor = col8;
                else if (sum == 128)
                    pics[k, j].BackColor = col7;
                else if (sum == 64)
                    pics[k, j].BackColor = col6;
                else if (sum == 32)
                    pics[k, j].BackColor = col5;
                else if (sum == 16)
                    pics[k, j].BackColor = col4;
                else if (sum == 8)
                    pics[k, j].BackColor = col3;
                else if (sum == 4)
                    pics[k, j].BackColor = col2;
                else
                    pics[k, j].BackColor = col1;
            }
            else if(soft == true)
            {
                if (sum == 16384)
                    pics[k, j].BackColor = col14;
                else if (sum == 8192)
                    pics[k, j].BackColor = col13;
                else if (sum == 4096)
                    pics[k, j].BackColor = col12;
                else if (sum == 2048)
                    pics[k, j].BackColor = col11;
                else if (sum == 1024)
                    pics[k, j].BackColor = col10;
                else if (sum == 512)
                    pics[k, j].BackColor = col9;
                else if (sum == 256)
                    pics[k, j].BackColor = col8;
                else if (sum == 128)
                    pics[k, j].BackColor = col7;
                else if (sum == 64)
                    pics[k, j].BackColor = col6;
                else if (sum == 32)
                    pics[k, j].BackColor = col5;
                else if (sum == 16)
                    pics[k, j].BackColor = col4;
                else if (sum == 8)
                    pics[k, j].BackColor = col3;
                else if (sum == 4)
                    pics[k, j].BackColor = col2;
                else
                    pics[k, j].BackColor = col1;
            }
        }
        /// ///////////////
        public int rec;
        public string nam;


        private void Prov()
        {
            int mapclear = 0;
            for(int i=0;i<4;i++)
            {
                for(int j=0;j<4;j++)
                {
                    if (map[i, j] == 1)
                        mapclear++;
                }
            }
            bool outofmoves = true;
            if(mapclear == 16)
            {
                for(int i1=0;i1<4;i1++)
                {
                    for(int j1=0;j1<4;j1++)
                    {
                        if(i1 == 0)
                        {
                            if(j1==0)
                            {
                                if (labels[i1, j1].Text == labels[i1 + 1, j1].Text || labels[i1, j1].Text == labels[i1, j1 + 1].Text)
                                    outofmoves = false;
                            }
                            if(j1==1)
                            {
                                if (labels[i1, j1].Text == labels[i1, j1-1].Text || labels[i1, j1].Text == labels[i1 + 1, j1].Text || labels[i1, j1].Text == labels[i1, j1 + 1].Text)
                                    outofmoves = false;
                            }
                            if(j1==2)
                            {
                                if(labels[i1, j1].Text == labels[i1, j1-1].Text || labels[i1, j1].Text == labels[i1 + 1, j1].Text || labels[i1, j1].Text == labels[i1, j1 + 1].Text)
                                    outofmoves = false;
                            }
                            if(j1==3)
                            {
                                if (labels[i1, j1].Text == labels[i1 + 1, j1].Text || labels[i1, j1].Text == labels[i1, j1 - 1].Text)
                                    outofmoves = false;
                            }
                        }
                        if(i1==1)
                        {
                            if(j1==0)
                            {
                                if (labels[i1, j1].Text == labels[i1 - 1, j1].Text || labels[i1, j1].Text == labels[i1 + 1, j1].Text || labels[i1, j1].Text == labels[i1, j1 + 1].Text)
                                    outofmoves = false;
                            }
                            if(j1==1)
                            {
                                if (labels[i1, j1].Text == labels[i1 - 1, j1].Text || labels[i1, j1].Text == labels[i1, j1 - 1].Text || labels[i1, j1].Text == labels[i1 + 1, j1].Text || labels[i1, j1].Text == labels[i1, j1 + 1].Text)
                                    outofmoves = false;
                            }
                            if(j1==2)
                            {
                                if (labels[i1, j1].Text == labels[i1 - 1, j1].Text || labels[i1, j1].Text == labels[i1, j1 - 1].Text || labels[i1, j1].Text == labels[i1 + 1, j1].Text || labels[i1, j1].Text == labels[i1, j1 + 1].Text)
                                    outofmoves = false;
                            }
                            if(j1==3)
                            {
                                if (labels[i1, j1].Text == labels[i1 - 1, j1].Text || labels[i1, j1].Text == labels[i1 + 1, j1].Text || labels[i1, j1].Text == labels[i1, j1 - 1].Text)
                                    outofmoves = false;
                            }
                        }
                        if(i1==2)
                        {
                            if (j1 == 0)
                            {
                                if (labels[i1, j1].Text == labels[i1 - 1, j1].Text || labels[i1, j1].Text == labels[i1 + 1, j1].Text || labels[i1, j1].Text == labels[i1, j1 + 1].Text)
                                    outofmoves = false;
                            }
                            if (j1 == 1)
                            {
                                if (labels[i1, j1].Text == labels[i1 - 1, j1].Text || labels[i1, j1].Text == labels[i1, j1 - 1].Text || labels[i1, j1].Text == labels[i1 + 1, j1].Text || labels[i1, j1].Text == labels[i1, j1 + 1].Text)
                                    outofmoves = false;
                            }
                            if (j1 == 2)
                            {
                                if (labels[i1, j1].Text == labels[i1 - 1, j1].Text || labels[i1, j1].Text == labels[i1, j1 - 1].Text || labels[i1, j1].Text == labels[i1 + 1, j1].Text || labels[i1, j1].Text == labels[i1, j1 + 1].Text)
                                    outofmoves = false;
                            }
                            if (j1 == 3)
                            {
                                if (labels[i1, j1].Text == labels[i1 - 1, j1].Text || labels[i1, j1].Text == labels[i1 + 1, j1].Text || labels[i1, j1].Text == labels[i1, j1 - 1].Text)
                                    outofmoves = false;
                            }
                        }
                        if(i1==3)
                        {
                            if (j1 == 0)
                            {
                                if (labels[i1, j1].Text == labels[i1 - 1, j1].Text || labels[i1, j1].Text == labels[i1, j1 + 1].Text)
                                    outofmoves = false;
                            }
                            if (j1 == 1)
                            {
                                if (labels[i1, j1].Text == labels[i1, j1 - 1].Text || labels[i1, j1].Text == labels[i1 - 1, j1].Text || labels[i1, j1].Text == labels[i1, j1 + 1].Text)
                                    outofmoves = false;
                            }
                            if (j1 == 2)
                            {
                                if (labels[i1, j1].Text == labels[i1, j1 - 1].Text || labels[i1, j1].Text == labels[i1 - 1, j1].Text || labels[i1, j1].Text == labels[i1, j1 + 1].Text)
                                    outofmoves = false;
                            }
                            if (j1 == 3)
                            {
                                if (labels[i1, j1].Text == labels[i1 - 1, j1].Text || labels[i1, j1].Text == labels[i1, j1 - 1].Text)
                                    outofmoves = false;
                            }
                        }
                    }
                }
                if (outofmoves == true)
                    MessageBox.Show("Упс. Кажется ходов нет. \nЧтобы начать игру заново нажми кнопку рестарта в правом верхнем углу.", " ", MessageBoxButtons.OK, MessageBoxIcon.Error);
            }
            

        }

       
        private void _keyboardEvent(object sender, KeyEventArgs e)
        {
            bool ifPicsWasMoved = false;

            switch (e.KeyCode.ToString())
            {
                case "Right":
                    for (int k = 0; k < 4; k++)
                    {
                        for (int l = 2; l >= 0; l--)
                        {
                            if (map[k, l] == 1)
                            {
                                for (int j = l + 1; j < 4; j++)
                                {
                                    if (map[k, j] == 0)
                                    {
                                        ifPicsWasMoved = true;
                                        map[k, j - 1] = 0;
                                        map[k, j] = 1;
                                        pics[k, j] = pics[k, j - 1];
                                        pics[k, j - 1] = null;
                                        labels[k, j] = labels[k, j - 1];
                                        labels[k, j - 1] = null;
                                        pics[k, j].Location = new Point(pics[k, j].Location.X + 124, pics[k, j].Location.Y);
                                    }
                                    else
                                    {
                                        int a = int.Parse(labels[k, j].Text);
                                        int b = int.Parse(labels[k, j - 1].Text);
                                        if (a == b)
                                        {
                                            ifPicsWasMoved = true;
                                            labels[k, j].Text = (a + b).ToString();
                                            score += (a + b);
                                            changeColor(a + b, k, j);
                                            label1.Text = "Очки: " + score;
                                            if (rec < score)
                                            {
                                                rec = score;
                                                label7.Text = "" + rec;
                                                
                                            }

                                            map[k, j - 1] = 0;
                                            this.Controls.Remove(pics[k, j - 1]);
                                            this.Controls.Remove(labels[k, j - 1]);
                                            pics[k, j - 1] = null;
                                            labels[k, j - 1] = null;
                                        }
                                    }
                                }
                            }
                        }
                    }

                    break;
                case "Left":
                    for (int k = 0; k < 4; k++)
                    {
                        for (int l = 1; l < 4; l++)
                        {
                            if (map[k, l] == 1)
                            {
                                for (int j = l - 1; j >= 0; j--)
                                {
                                    if (map[k, j] == 0)
                                    {
                                        ifPicsWasMoved = true;
                                        map[k, j + 1] = 0;
                                        map[k, j] = 1;
                                        pics[k, j] = pics[k, j + 1];
                                        pics[k, j + 1] = null;
                                        labels[k, j] = labels[k, j + 1];
                                        labels[k, j + 1] = null;
                                        pics[k, j].Location = new Point(pics[k, j].Location.X - 124, pics[k, j].Location.Y);
                                    }
                                    else
                                    {
                                        int a = int.Parse(labels[k, j].Text);
                                        int b = int.Parse(labels[k, j + 1].Text);
                                        if (a == b)
                                        {
                                            ifPicsWasMoved = true;
                                            labels[k, j].Text = (a + b).ToString();
                                            score += (a + b);
                                            changeColor(a + b, k, j);
                                            label1.Text = "Очки: " + score;
                                            if (rec < score)
                                            {
                                                rec = score;
                                                label7.Text = "" + rec;
                                                
                                            }
                                            map[k, j + 1] = 0;
                                            this.Controls.Remove(pics[k, j + 1]);
                                            this.Controls.Remove(labels[k, j + 1]);
                                            pics[k, j + 1] = null;
                                            labels[k, j + 1] = null;
                                        }
                                    }
                                }
                            }
                        }
                    }

                    break;
                case "Down":
                    for (int k = 2; k >= 0; k--)
                    {
                        for (int l = 0; l < 4; l++)
                        {
                            if (map[k, l] == 1)
                            {
                                for (int j = k + 1; j < 4; j++)
                                {
                                    if (map[j, l] == 0)
                                    {
                                        ifPicsWasMoved = true;
                                        map[j - 1, l] = 0;
                                        map[j, l] = 1;
                                        pics[j, l] = pics[j - 1, l];
                                        pics[j - 1, l] = null;
                                        labels[j, l] = labels[j - 1, l];
                                        labels[j - 1, l] = null;
                                        pics[j, l].Location = new Point(pics[j, l].Location.X, pics[j, l].Location.Y + 124);
                                    }
                                    else
                                    {
                                        int a = int.Parse(labels[j, l].Text);
                                        int b = int.Parse(labels[j - 1, l].Text);
                                        if (a == b)
                                        {
                                            ifPicsWasMoved = true;
                                            labels[j, l].Text = (a + b).ToString();
                                            score += (a + b);
                                            changeColor(a + b, j, l);
                                            label1.Text = "Очки: " + score;
                                            if (rec < score)
                                            {
                                                rec = score;
                                                label7.Text = "" + rec;
                                               
                                            }
                                            map[j - 1, l] = 0;
                                            this.Controls.Remove(pics[j - 1, l]);
                                            this.Controls.Remove(labels[j - 1, l]);
                                            pics[j - 1, l] = null;
                                            labels[j - 1, l] = null;
                                        }
                                    }
                                }
                            }
                        }
                    }

                    break;
                case "Up":
                    for (int k = 1; k < 4; k++)
                    {
                        for (int l = 0; l < 4; l++)
                        {
                            if (map[k, l] == 1)
                            {
                                for (int j = k - 1; j >= 0; j--)
                                {
                                    if (map[j, l] == 0)
                                    {
                                        ifPicsWasMoved = true;
                                        map[j + 1, l] = 0;
                                        map[j, l] = 1;
                                        pics[j, l] = pics[j + 1, l];
                                        pics[j + 1, l] = null;
                                        labels[j, l] = labels[j + 1, l];
                                        labels[j + 1, l] = null;
                                        pics[j, l].Location = new Point(pics[j, l].Location.X, pics[j, l].Location.Y - 124);
                                    }
                                    else
                                    {
                                        int a = int.Parse(labels[j, l].Text);
                                        int b = int.Parse(labels[j + 1, l].Text);
                                        if (a == b)
                                        {
                                            ifPicsWasMoved = true;
                                            labels[j, l].Text = (a + b).ToString();
                                            score += (a + b);
                                            changeColor(a + b, j, l);
                                            label1.Text = "Очки: " + score;
                                            if (rec < score)
                                            {
                                                rec = score;
                                                label7.Text = "" + rec;
                                               
                                            }
                                            map[j + 1, l] = 0;
                                            this.Controls.Remove(pics[j + 1, l]);
                                            this.Controls.Remove(labels[j + 1, l]);
                                            pics[j + 1, l] = null;
                                            labels[j + 1, l] = null;
                                        }
                                    }
                                }
                            }
                        }
                    }

                    break;
            }
            if (ifPicsWasMoved)
                generateNewPic();
            Prov();
            DataUpdate();


        }
        public SQLiteConnection DB;
        private void DataUpdate()
        {
            DB = new SQLiteConnection("Data source=DB\\2048Users.db");
            DB.Open();
            SQLiteCommand command = DB.CreateCommand();
            command.CommandText = "update Users set Record = @record where Name like @name";
            command.Parameters.Add("@name", DbType.String).Value = nam;
            command.Parameters.Add("@record", DbType.Int32).Value = rec;
            
            command.ExecuteNonQuery();

            
            DB.Close();
        }

        private void PictureBox1_Click(object sender, EventArgs e)
        {
            for (int i = 0; i < 4; i++)
            {
                for (int j = 0; j < 4; j++)
                {
                    map[i, j] = 0;
                    this.Controls.Remove(pics[i, j]);
                    this.Controls.Remove(labels[i, j]);
                    pics[i, j] = null;
                    labels[i, j] = null;
                }
            }
            label1.Text = "Очки: 0";
            score = 0;
            generateNewPic();
            generateNewPic();
        }

        private void DarkTheme_Click(object sender, EventArgs e)
        {
            dark = true;
            sun = false;
            soft = false;
            SetColors();
            panel2.Visible = false;
        }

        private void SunsetTheme_Click(object sender, EventArgs e)
        {
            sun = true;
            dark = false;
            soft = false;
            SetColors();
            panel2.Visible = false;
        }

        private void SoftTheme_Click(object sender, EventArgs e)
        {
            
            sun = false;
            soft = true;
            dark = false;
            SetColors();
            panel2.Visible = false;
        }

        private void Label2_Click(object sender, EventArgs e)
        {
            MessageBox.Show("Проект выполнен учащейся 35 ТП группы Баразна Валерией. \nВ меню 'Тема' можно выбрать цветовую гамму приложения. \n\nПравила игры: \n1.В каждом раунде появляется плитка номинала «2» \n2.Нажатием стрелки игрок может скинуть все плитки игрового поля в одну из 4 сторон.\nЕсли при сбрасывании две плитки одного номинала «налетают» одна на другую, то они слипаются в одну, номинал которой равен сумме соединившихся плиток.\nПосле каждого хода на свободной секции поля появляется новая плитка номиналом «2». \nЕсли при нажатии кнопки местоположение плиток или их номинал не изменится, то ход не совершается. \n3.Если в одной строчке или в одном столбце находится более двух плиток одного номинала, то при сбрасывании они начинают слипаться с той стороны, в которую были направлены.\nНапример, находящиеся в одной строке плитки(4, 4, 4) после хода влево они превратятся в(8, 4), а после хода вправо — в(4, 8).\nДанная обработка неоднозначности позволяет более точно формировать стратегию игры.\n4.За каждое соединение игровые очки увеличиваются на номинал получившейся плитки.\n5.Игра заканчивается поражением, если после очередного хода невозможно совершить действие.","Справка",MessageBoxButtons.OK,MessageBoxIcon.Information);
        }

        bool th = false;
   
        private void Form1_Load(object sender, EventArgs e)
        {
            label7.Text = "" + rec;
        }

        private void Label4_Click(object sender, EventArgs e)
        {
            Application.Exit();
        }
        Point lastPoint;
        private void Panel1_MouseMove(object sender, MouseEventArgs e)
        {
            if (e.Button == MouseButtons.Left)
            {
                this.Left += e.X - lastPoint.X;
                this.Top += e.Y - lastPoint.Y;
            }
        }

        private void Panel1_MouseDown(object sender, MouseEventArgs e)
        {
            lastPoint = new Point(e.X, e.Y);
        }
        
        private void Label5_Click(object sender, EventArgs e)
        {
            Rating rate = new Rating();
            rate.Show();
        }
        
        private void Label3_Click(object sender, EventArgs e)
        {
            th = (!th);
            if (th == true)
                panel2.Visible = true; 
            else
                panel2.Visible = false;

        }


        // смещение на 124

    }
}
