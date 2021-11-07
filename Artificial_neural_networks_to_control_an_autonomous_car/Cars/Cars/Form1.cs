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
using Accord.Neuro;
using Accord.Neuro.Learning;
using Accord.Statistics;
using Accord.Math;

namespace Samochody
{
    public partial class Form1 : Form
    {
        //zmienne globalne
        int carSpeed = 5;
        int roadSpeed = 5;
        bool carLeft;
        bool carRight;
        int trafficSpeed = 5;
        int Score = 0;

        Random rnd = new Random();

        //pozycja Pasow
        int pasLewy = 60;
        int pasSrodkowy = 175;
        int pasPrawy = 290;

        //pozycja przeszkod
        int przeszkodaL = 0;
        int przeszkodaS = 0;
        int przeszkodaP = 0;

        //pozycja pojazdu
        int pojazdL = 0;
        int pojazdS = 0;
        int pojazdP = 0;

        //akcja skret lewo/brak/prawo
        int skrecam = 0;
        

        ActivationNetwork network;

        private void AI()
        {
            int answer;
            double[] output = network.Compute(new double[]{przeszkodaL, przeszkodaS, przeszkodaP, pojazdL, pojazdS, pojazdP});
            double response = output.Max(out answer);

            if (answer == 1)
            {
                skretWLewo();
            }
            else if(answer == 2)
            {
                skretWPrawo();
            }
     
        }
        public void Ucz() //algorytm uczacy siec neuronowa
        {

            int NumberOfImputs = 6;
            int Classnes = 11;
            int NumberOfHiddenNeurons = 6; 

            network = new ActivationNetwork(new BipolarSigmoidFunction(2), NumberOfImputs, NumberOfHiddenNeurons, Classnes);
            var teacher = new BackPropagationLearning(network);
            double error=1;

            double[][] input = odczytDanychIN();
            int[] label = odczytDanychOUT();

            double[][] output = Jagged.OneHot(label, Classnes);

            for (int i = 0; i < 10000; i++)
            {
                error = teacher.RunEpoch(input, output);
            }
            label2.Text = error.ToString();
             
        }
        static public double[][] odczytDanychIN()  //pobieranie danych z pliku input
        {
            double[][] input = new double[100][];

            FileStream fs = new FileStream("dane.txt", FileMode.Open, FileAccess.Read);
            StreamReader sr = new StreamReader(fs);

            string dane;

            for (int i = 0; i < 100; i++)
            {
                dane = sr.ReadLine();
                string[] SI = dane.Split(';');
                input[i] = new double[6];
                for (int j = 0; j < 6; j++)
                {
                    input[i][j] = double.Parse(SI[j]);
                }
            }
            sr.Close();
            fs.Close();

            return input;
        }
        static public int[] odczytDanychOUT() //pobieranie danych z pliku output
        {
            int[] output = new int[100];

            FileStream fs = new FileStream("dane.txt", FileMode.Open, FileAccess.Read);
            StreamReader sr = new StreamReader(fs);

            string dane;
            
            for (int i = 0; i < 100; i++)
            {
                dane = sr.ReadLine();
                string[] SI = dane.Split(';');
                output[i] = (int.Parse(SI[6]));
            }
            sr.Close();
            fs.Close();

            return output;
        }
        public void zapisDanych() //tworzenie danych do uczenia neuronu. Baza składa się z 7 wartości oddzielonych średnikiem. Plik tworzy bazę zawierającą położenia:
            //1,2,3 czy przeszkoda znajduje się na pasie: lewym, środkowym, prawym. 4,5,6 pozycja pojazdu czy znajduje się na pasie: lewym, środkowym, prawym. 7 Czy pojazd skręca na pas: lewy, prawy lub zostaje w spoczynku
        {
            FileStream fs = new FileStream("dane.txt", FileMode.Append, FileAccess.Write);
            StreamWriter sw = new StreamWriter(fs);

            sw.Write(przeszkodaL);
            sw.Write(";");
            sw.Write(przeszkodaS);
            sw.Write(";");
            sw.Write(przeszkodaP);
            sw.Write(";");
            sw.Write(pojazdL);
            sw.Write(";");
            sw.Write(pojazdS);
            sw.Write(";");
            sw.Write(pojazdP);
            sw.Write(";");
            sw.Write(skrecam);
            sw.WriteLine("");
            sw.Close();
            fs.Close();
        }
        private void sprawdzPrzeszkody() //sprawdza czy przeszkoda jest na pasie lewym, środkowym oraz prawym
        {
            if (przeszkodaLewy.Bounds.IntersectsWith(SI1.Bounds) && przeszkodaSrodkowy.Bounds.IntersectsWith(SI2.Bounds))
            {
                przeszkodaL = 1;
                przeszkodaS = 1;
                przeszkodaP = 0;
            }
            else if (przeszkodaSrodkowy.Bounds.IntersectsWith(SI2.Bounds) && przeszkodaPrawy.Bounds.IntersectsWith(SI3.Bounds))
            {
                przeszkodaL = 0;
                przeszkodaS = 1;
                przeszkodaP = 1;
            }
            else if (przeszkodaLewy.Bounds.IntersectsWith(SI1.Bounds) && przeszkodaPrawy.Bounds.IntersectsWith(SI3.Bounds))
            {
                przeszkodaL = 1;
                przeszkodaS = 0;
                przeszkodaP = 1;
            }
            else if (przeszkodaLewy.Bounds.IntersectsWith(SI1.Bounds)){
                przeszkodaL = 1;
                przeszkodaS = 0;
                przeszkodaP = 0;
            }
            else if (przeszkodaSrodkowy.Bounds.IntersectsWith(SI2.Bounds))
            {
                przeszkodaL = 0;
                przeszkodaS = 1;
                przeszkodaP = 0;
            }
            else if (przeszkodaPrawy.Bounds.IntersectsWith(SI3.Bounds))
            {
                przeszkodaL = 0;
                przeszkodaS = 0;
                przeszkodaP = 1;
            }
            
        }
        private void sprawdzPojazd() //sprawdza pozyjce pojazdu
        {
            
            if (pojazdLewy.Bounds.IntersectsWith(player.Bounds))
            {
                pojazdL = 1;
                pojazdS = 0;
                pojazdP = 0;
            }
            else if (pojazdSrodkowy.Bounds.IntersectsWith(player.Bounds))
            {
                pojazdL = 0;
                pojazdS = 1;
                pojazdP = 0;
            }            
            else if (pojazdPrawy.Bounds.IntersectsWith(player.Bounds))
            {
                pojazdL = 0;
                pojazdS = 0;
                pojazdP = 1;
            }

        }
        private void Reset()  //przywraca pierwotne wartości statystyk
        {
            timer1.Enabled = true;
            timer2.Enabled = true;
            timer3.Enabled = true;

            trophy.Visible = false; // ukrywa trofeum
            button1.Enabled = false; // blokuje przycisk Start na czas gry
            button2.Enabled = false;
            button3.Enabled = false;
            explosion.Visible = false; //ukrywa obraz wybuchu
            trafficSpeed = 5; // resetuje statystyki
            roadSpeed = 5; // resetuje statystyki
            Score = 0; // resetuje statystyki

            player.Left = 175; // resetuje pozycje pojazdu na osi x
            player.Top = 330; // resetuje pozycje pojazdu na osi y

            carLeft = false; // resetuje poruszanie pojazdu po osi x
            carRight = false; // resetuje poruszanie pojazdu po osi x

            // dodawanie innych pojazdow poza wyswietlanym obrazem
            SI1.Left = 900;
            SI1.Top = -150;

            SI2.Left = 2550;
            SI2.Top = -850;

            SI3.Left = 4150;
            SI3.Top = -500;

            // resetowanie drogi do pierwotnej pozycji
            roadTrack2.Left = 0;
            roadTrack2.Top = -222;
            roadTrack1.Left = 0;
            roadTrack1.Top = -638;

        }
        public Form1()
        {
            InitializeComponent();
            
        }
        private void drganieImageboxaGdziePojazd() //wymysza poruszanie imageboxa sprawdzającego pozycję pojazdu aby wykluczyć kłopoty z boundem
        {
            pojazdLewy.Top += roadSpeed; //poruszanie testu lewego
            pojazdSrodkowy.Top += roadSpeed; //poruszanie testu srodkowego
            pojazdPrawy.Top += roadSpeed; //poruszanie testu prawego

            if (pojazdLewy.Top > 320)
            {
                pojazdLewy.Top = 315; //resetuje pozycje testu
            }
            if (pojazdSrodkowy.Top > 320)
            {
                pojazdSrodkowy.Top = 315; //resetuje pozycje testu
            }
            if (pojazdPrawy.Top > 320)
            {
                pojazdPrawy.Top = 315; //resetuje pozycje testu
            }
        }
        private void zapetlenieDrogi() //sprawia że droga się zapętla
        {
            if (roadTrack1.Top > 630)
            {
                roadTrack1.Top = -630;
            }
            if (roadTrack2.Top > 630)
            {
                roadTrack2.Top = -630;
            }
        }
        private void Resp() //algorytm generujący przypadkowe wystąpienia przeszkód
        {
            int randomowe = rnd.Next(1, 7);

            switch (randomowe)
            {
                case 1:
                    {
                        Lewy();
                    }
                    break;
                case 2:
                    {
                        Srodkowy();
                    }
                    break;
                case 3:
                    {
                        Prawy();
                    }
                    break;
                case 4:
                    {
                        Lewy();
                        Srodkowy();
                    }
                    break;
                case 5:
                    {
                        Srodkowy();
                        Prawy();
                    }
                    break;
                case 6:
                    {
                        Lewy();
                        Prawy();
                    }
                    break;
            }
         }
        private void Lewy() //spawn nowego pojazdu na pasie lewym
        {
            if (SI1.Top > panel1.Height)
            {
                changeSI1(); //przypadkowy pojazd
                SI1.Left = pasLewy; // spawn nowego pojazdu SI na osi X 
                SI1.Top = rnd.Next(100, 200) * -1; // spawn nowego pojazdu SI na osi Y w przedziale 
            }
        }
        private void Srodkowy() //spawn nowego pojazdu na pasie środkowym
        {
            if (SI2.Top > panel1.Height)
            {
                changeSI2(); //przypadkowy pojazd
                SI2.Left = pasSrodkowy; // spawn nowego pojazdu SI na osi X
                SI2.Top = rnd.Next(100, 200) * -1; // spawn nowego pojazdu SI na osi y w przedziale 
            }
        }
        private void Prawy() //spawn nowego pojazdu na pasie prawym
        {
            if (SI3.Top > panel1.Height)
            {
                changeSI3(); //przypadkowy pojazd 
                SI3.Left = pasPrawy; // spawn nowego pojazdu SI na osi X
                SI3.Top = rnd.Next(100, 200) * -1; // spawn nowego pojazdu SI na osi Y w przedziale 
            }
        }
        private void skretWLewo() //sktet pojazdu w lewą stronę
        {
            player.Left -= 120;  // poruszanie w lewo
            skrecam = 1;   //zmiana wartości poruszania

            zapisDanych();

            skrecam = 0;   //zmiana wartości poruszania
        }
        private void skretWPrawo() //sktet pojazdu w prawą stronę
        {
            player.Left += 120; // poruszanie w prawo
            skrecam = 2;   //zmiana wartości poruszania

            zapisDanych();

            skrecam = 0;   //zmiana wartości poruszania
        }
        private void moveCar(object sender, KeyEventArgs e) //zmiana pozycji pojazdu oraz nadpisanie bazy z danymi decyzji o ruchu gracza
        {
            if (e.KeyCode == Keys.Left && player.Left > 100) 
            {
                skretWLewo();
             }

            if (e.KeyCode == Keys.Right && player.Left < 250)
            {
                skretWPrawo();
            }
        }
        private void changeSI1() //randomowy wygląd przeszkody na pasie lewym
        {
            int num = rnd.Next(1, 8);

            switch (num)
            {
                case 1:
                    SI1.Image = Properties.Resources.auto7;
                    break;
                case 2:
                    SI1.Image = Properties.Resources.auto8;
                    break;
                case 3:
                    SI1.Image = Properties.Resources.auto9;
                    break;
                case 4:
                    SI1.Image = Properties.Resources.auto10;
                    break;
                case 5:
                    SI1.Image = Properties.Resources.Karetka;
                    break;
                case 6:
                    SI1.Image = Properties.Resources.taxi;
                    break;
                case 7:
                    SI1.Image = Properties.Resources.Policja;
                    break;
                case 8:
                    SI1.Image = Properties.Resources.auto4;
                    break;
                default:
                    break;
            }
        }
        private void changeSI2() //randomowy wygląd przeszkody na pasie środkowym
        {
            int num = rnd.Next(1, 8);

            switch (num)
            {
                case 1:
                    SI2.Image = Properties.Resources.auto7;
                    break;
                case 2:
                    SI2.Image = Properties.Resources.auto8;
                    break;
                case 3:
                    SI2.Image = Properties.Resources.auto9;
                    break;
                case 4:
                    SI2.Image = Properties.Resources.auto10;
                    break;
                case 5:
                    SI2.Image = Properties.Resources.Karetka;
                    break;
                case 6:
                    SI2.Image = Properties.Resources.taxi;
                    break;
                case 7:
                    SI2.Image = Properties.Resources.Policja;
                    break;
                case 8:
                    SI2.Image = Properties.Resources.auto4;
                    break;
                default:
                    break;
            }
         }
        private void changeSI3() //randomowy wygląd przeszkody na pasie prawym
        {
            int num = rnd.Next(1, 8);

            switch (num)
            {
                case 1:
                    SI3.Image = Properties.Resources.auto7;
                    break;
                case 2:
                    SI3.Image = Properties.Resources.auto8;
                    break;
                case 3:
                    SI3.Image = Properties.Resources.auto9;
                    break;
                case 4:
                    SI3.Image = Properties.Resources.auto10;
                    break;
                case 5:
                    SI3.Image = Properties.Resources.Karetka;
                    break;
                case 6:
                    SI3.Image = Properties.Resources.taxi;
                    break;
                case 7:
                    SI3.Image = Properties.Resources.Policja;
                    break;
                case 8:
                    SI3.Image = Properties.Resources.auto4;
                    break;
                default:
                    break;
            }
        }
        private void gameOver() //zatrzymujemy grę oraz wyświetlamy statystyki oraz trofea
        {
            trophy.Visible = true; //odpalenie obrazu z trofeum
            explosion.Visible = true; //odpalenie obrazu eksplozji
            timer1.Stop(); //zatrzymujemy czas
            timer2.Stop(); //zatrzymujemy czas
            timer3.Stop(); //zatrzymujemy czas
            button1.Enabled = true; //przycisk Start aktywny
            button2.Enabled = true;
            button3.Enabled = true;
            player.Controls.Add(explosion); 
            explosion.Location = new Point(-8, 5); //pozyjca eksplozji za pojeździe gracza
            explosion.BringToFront(); //eksplozja na froncie ekranu

            //obraz trofeum wyświetlany zależnie od wyniku
            if (Score < 1000) 
            {
                trophy.Image = Properties.Resources.bronze;
            }

            if (Score > 2000)
            {
                trophy.Image = Properties.Resources.silver;
            }

            if (Score > 3500)
            {
                trophy.Image = Properties.Resources.gold;
            }

        }
        private void button1_Click(object sender, EventArgs e) //przycisk Start //resetuje statystyki oraz odpala timer
        {
            Reset();
        }
        private void timer1_Tick(object sender, EventArgs e) //zmienia wartości zmiennych co określony czas
        {
            Score++; //zwiekszanie wartości wyniku
            distance.Text = "" + Score; // wyswietlenie wartosci wyniku
            roadTrack1.Top += roadSpeed; // poruszanie drogi
            roadTrack2.Top += roadSpeed; // poruszanie drogi

            SI1.Top += trafficSpeed; //poruszanie pojazdu lewego SI 
            SI2.Top += trafficSpeed; //poruszanie pojazdu srodkowego SI
            SI3.Top += trafficSpeed; //poruszanie pojazdu prawego SI

            drganieImageboxaGdziePojazd(); //wymysza poruszanie imageboxa sprawdzającego pozycję pojazdu
            zapetlenieDrogi(); //sprawia że droga się zapętla

            //gdy gracz wjedzie na przeszkode
            if (player.Bounds.IntersectsWith(SI1.Bounds) || player.Bounds.IntersectsWith(SI2.Bounds) || player.Bounds.IntersectsWith(SI3.Bounds))
            {
                gameOver(); // konczy rozgrywke
            }

            if (Score > 100 && Score < 500) //po przekroczeniu wyniku 100 gra przyśpiesza
            {
                trafficSpeed = 6;
                roadSpeed = 7;
            }

            else if (Score > 500 && Score < 1000) //po przekroczeniu wyniku 500 gra przyśpiesza
            {
                trafficSpeed = 9;
                roadSpeed = 10;
            }
        }
        private void timer2_Tick(object sender, EventArgs e) //odpowiada za częstość pojawiania się przeszkód
        {
            Resp();
        }
        private void timer3_Tick(object sender, EventArgs e) //odpowiada za częstość robienia testów oraz zapisu danych do bazy neuronów
        {
            sprawdzPrzeszkody();
            sprawdzPojazd();
            zapisDanych();
        }

        private void button2_Click(object sender, EventArgs e) //odpowiada za wczytanie danych z pliku tekstowego do bazy sztucznych sieci neuronowych
        {
            Ucz();
            button3.Visible = true;
        }

        private void button3_Click(object sender, EventArgs e) //odpowiada za uruchomienie gry w której sterowanie nad samochodem ma sztuczna siec neuronowa
        {
            Reset();
            timer4.Enabled = true;
            button4.Visible = true;
        }

        private void timer4_Tick(object sender, EventArgs e) //odpowiada za pobieranie danych wejściowych do sztucznej sieci neuronowej co pewien odstęp czasu oraz wyswietlenie  
        {
            AI();
        }

        private void button4_Click(object sender, EventArgs e) //przycisk możliwy do wciśnięcia tylko w wypadku gry sztucznej sieci neuronowej, blokuje akcje gracza.
        {
            gameOver();
            button4.Visible = false;
        }
    }
}
