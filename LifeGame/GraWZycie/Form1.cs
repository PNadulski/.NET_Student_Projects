using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;
using System.IO;

namespace GraWZycie
{
    public partial class Form1 : Form
    {
        private bool[,] plansza = new bool[15, 15];
        private DostepneRozmiary wybranyRozmiar;
        public int wysokosc = 15, szerokosc = 15;

        public Form1()
        {
            InitializeComponent();

            this.MainPanel.Controls.Clear();

            for (int x = 0; x < 15; x++)
            {
                for (int y = 0; y < 15; y++)
                {
                    Button btn = new Button();
                    btn.UseVisualStyleBackColor = true;
                    btn.Visible = false;
                    btn.Click += BtnOnClick;
                    btn.Tag = new Point(x, y);

                    this.MainPanel.Controls.Add(btn);
                }
            }
        }

        private void Form1_Load(object sender, EventArgs e)
        {

        }

        private void otwórzToolStripMenuItem_Click(object sender, EventArgs e)
        {

            FileStream fs = new FileStream("Zapis.txt",
                FileMode.Open, FileAccess.Read);

            using(StreamReader sr = new StreamReader(fs))
            {               
                szerokosc = Int32.Parse(sr.ReadLine());
                wysokosc = Int32.Parse(sr.ReadLine());

                String[,] tablica = new String[szerokosc, wysokosc];

                for (int i = 0; i < szerokosc; i++)
                {
                    for (int j = 0; j < wysokosc; j++)
                    {
                        tablica[i, j] = sr.ReadLine();
                    }
                }

                for (int i = 0; i < szerokosc; i++)
                {
                    for (int j = 0; j < wysokosc; j++)
                    {
                        if (tablica[i, j] == "True")
                            plansza[i, j] = true;
                        else
                            plansza[i, j] = false;
                    }
                }

                RysujPlansze();
                fs.Close();
            }
        }

        private void BtnOnClick(object sender, EventArgs e)
        {
            Button btn = (sender as Button);
            if (btn != null)
            {
                Point p = (Point)btn.Tag;
                plansza[p.X, p.Y] = !plansza[p.X, p.Y];

                RysujPlansze();
            }
        }

        private void RysujPlansze()
        {
            foreach (var kontrolka in MainPanel.Controls)
            {
                Button btn = kontrolka as Button;
                if (btn != null)
                {
                    Point p = (Point)btn.Tag;
                    if (plansza[p.X, p.Y])
                        btn.BackColor = Color.Black;
                    else
                        btn.BackColor = Color.White;
                }
            }
        }

        private void zamknijToolStripMenuItem_Click(object sender, EventArgs e)
        {
            timer1.Enabled = false;
            this.Close();
        }

        private void x10ToolStripMenuItem_Click(object sender, EventArgs e)
        {
            zerowaniePlanszy();
            //10x10
            wybranyRozmiar = DostepneRozmiary.Mala;  // enum
            UstawRozmiarPrzyciskow();
            RysujPlansze();
        }

        private void x5ToolStripMenuItem_Click(object sender, EventArgs e)
        {
            zerowaniePlanszy();
            //10x15
            wybranyRozmiar = DostepneRozmiary.Srednia;  // enum
            UstawRozmiarPrzyciskow();
            RysujPlansze();
        }

        private void x15ToolStripMenuItem_Click(object sender, EventArgs e)
        {
            zerowaniePlanszy();
            //15x15
            wybranyRozmiar = DostepneRozmiary.Duza;  // enum
            UstawRozmiarPrzyciskow();
            RysujPlansze();
        }

        private void UstawRozmiarPrzyciskow()
        {
            int rozmiarPrzycisku = 0;
            switch (wybranyRozmiar)
            {
                case DostepneRozmiary.Mala:
                    rozmiarPrzycisku = Math.Min(this.MainPanel.Height / 10,
                                                this.MainPanel.Width / 10);
                    break;
                case DostepneRozmiary.Srednia:
                    rozmiarPrzycisku = Math.Min(this.MainPanel.Height / 10,
                                                this.MainPanel.Width / 15);
                    break;
                case DostepneRozmiary.Duza:
                    rozmiarPrzycisku = Math.Min(this.MainPanel.Height / 15,
                                                this.MainPanel.Width / 15);
                    break;
            }

            foreach (var kontrolka in MainPanel.Controls)
            {
                Button btn = kontrolka as Button;
                if (btn != null)
                {
                    Point p = (Point)btn.Tag;
                    btn.Location = new Point(p.X * rozmiarPrzycisku, p.Y * rozmiarPrzycisku);
                    btn.Size = new Size(rozmiarPrzycisku, rozmiarPrzycisku);

                    switch (wybranyRozmiar)
                    {
                        case DostepneRozmiary.Mala:
                            btn.Visible = p.X < 10 && p.Y < 10;
                            wysokosc = 10;
                            szerokosc = 10;
                            break;
                        case DostepneRozmiary.Srednia:
                            btn.Visible = p.X < 15 && p.Y < 10;
                            wysokosc = 10;
                            szerokosc = 15;
                            break;
                        case DostepneRozmiary.Duza:
                            btn.Visible = p.X < 15 && p.Y < 15;
                            wysokosc = 15;
                            szerokosc = 15;
                            break;
                    }
                }
            }
        }
            private void NowaGeneracja()
            {
                int[,] sasiedzi = PoliczSasiadow();
                WyliczPlansze(sasiedzi);
                RysujPlansze();
            }

            private int[,] PoliczSasiadow()
            {
                int[,] sasiedzi = new int[szerokosc, wysokosc];

                for (int x = 0; x < szerokosc; x++)
                {
                    for (int y = 0; y < wysokosc; y++)
                    {
                        sasiedzi[x, y] = 0;
                        for (int xi = x - 1; xi <= x + 1; xi++)
                        {
                            for (int yi = y - 1; yi <= y + 1; yi++)
                            {
                                if (xi >= 0 && xi < szerokosc && yi >= 0 && yi < wysokosc && !(xi == x && yi == y))
                                {
                                    if (plansza[xi, yi])
                                    {
                                        sasiedzi[x, y]++;
                                    }
                                }
                            }
                        }
                    }
                }
                return sasiedzi;
            }

            private void WyliczPlansze(int[,] sasiedzi)
            {
                for (int x = 0; x < szerokosc; x++)
                {
                    for (int y = 0; y < wysokosc; y++)
                    {
                        if (plansza[x, y])
                        {
                            if (sasiedzi[x, y] == 2 || sasiedzi[x, y] == 3)
                                plansza[x, y] = true;
                            else
                                plansza[x, y] = false;
                        }
                        else
                        {
                            if (sasiedzi[x, y] == 3)
                                plansza[x, y] = true;
                            else
                                plansza[x, y] = false;
                        }
                    }
                }
            }

        private void grajToolStripMenuItem_Click(object sender, EventArgs e)
        {
            timer1.Enabled = true;
        }

        private void timer1_Tick(object sender, EventArgs e)
        {
            nowaGraToolStripMenuItem.Enabled = false;
            otwórzToolStripMenuItem.Enabled = false;
            grajToolStripMenuItem.Enabled = false;
            zapiszToolStripMenuItem.Enabled = false;
            zablokujPlansze();
            NowaGeneracja();
        }

        void zablokujPlansze()
        {
            foreach (var kontrolka in MainPanel.Controls)
            {
                Button btn = kontrolka as Button;
                if (btn != null)
                {
                    Point p = (Point)btn.Tag;
                    if (plansza[p.X, p.Y])
                        btn.BackColor = Color.Black;
                    else
                        btn.BackColor = Color.White;
                    btn.Enabled = false;
                }
            }
        }
        void odblokujPlansze()
        {
            foreach (var kontrolka in MainPanel.Controls)
            {
                Button btn = kontrolka as Button;
                if (btn != null)
                {
                    Point p = (Point)btn.Tag;
                    if (plansza[p.X, p.Y])
                        btn.BackColor = Color.Black;
                    else
                        btn.BackColor = Color.White;
                    btn.Enabled = true;
                }
            }
        }

        private void nowaGraToolStripMenuItem_Click(object sender, EventArgs e)
        {
            
        }

        void zerowaniePlanszy()
        {
            foreach (var kontrolka in MainPanel.Controls)
            {
                Button btn = kontrolka as Button;
                if (btn != null)
                {
                    Point p = (Point)btn.Tag;
                    plansza[p.X, p.Y] = false;
                }
            }
        }

        private void zapiszToolStripMenuItem_Click(object sender, EventArgs e)
        {
            FileStream fs = new FileStream("Zapis.txt",
                FileMode.OpenOrCreate, FileAccess.ReadWrite);

            using (
                StreamWriter sw = new StreamWriter(fs))
            {            
                sw.WriteLine(szerokosc);
                sw.WriteLine(wysokosc);

                for (int i = 0; i < szerokosc; i++)
                {
                    for (int j = 0; j < wysokosc; j++)
                    {
                        sw.WriteLine(plansza[i, j]);
                    }
                }
            }
            fs.Close();
        }

        private void zakończGręToolStripMenuItem_Click(object sender, EventArgs e)
        {
            nowaGraToolStripMenuItem.Enabled = true;
            otwórzToolStripMenuItem.Enabled = true;
            grajToolStripMenuItem.Enabled = true;
            zapiszToolStripMenuItem.Enabled = true;
            odblokujPlansze();
            timer1.Enabled = false;
        }
    }
}