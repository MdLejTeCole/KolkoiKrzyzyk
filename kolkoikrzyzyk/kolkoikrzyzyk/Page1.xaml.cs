using System;
using System.Threading;
using Xamarin.Forms;
using Xamarin.Forms.Xaml;

namespace kolkoikrzyzyk
{
    [XamlCompilation(XamlCompilationOptions.Compile)]
	public partial class Page1 : ContentPage
    {
        QueueWynikow queue = new QueueWynikow();
        public String wynik;
        private bool koniecGry = false;
        //tablica pól w grze
        private int[,] pola = new int[3, 3];
        //tablica z nazwami przycisków
        private Button[,] buttonNazwy = new Button[3, 3];
        int ktoZaczyna;
        int kogoRuch;
        public Page1(string nazwaUzytkowkika)
        {
            InitializeComponent();
            
            for (int i = 0; i < pola.GetLength(0); i++)
            {
                for (int j = 0; j < pola.GetLength(0); j++)
                {
                    pola[i, j] = -10;
                }
            }
            if (nazwaUzytkowkika==null)
            {
                labelNazwa.Text = "Nick";
            }
            else
            {
                labelNazwa.Text = nazwaUzytkowkika;
            }
            //kto zaczyna gre
            Random r = new Random();
            ktoZaczyna = r.Next(1, 3);
            if (ktoZaczyna == 2)
            { 
                RuchKomputera();
            }
        }

        private void RuchKomputera()
        {
            buttonNazwy[0, 0] = button1;
            buttonNazwy[0, 1] = button2;
            buttonNazwy[0, 2] = button3;
            buttonNazwy[1, 0] = button4;
            buttonNazwy[1, 1] = button5;
            buttonNazwy[1, 2] = button6;
            buttonNazwy[2, 0] = button7;
            buttonNazwy[2, 1] = button8;
            buttonNazwy[2, 2] = button9;
            int wygrana1 = pola[0, 0] + pola[0, 1] + pola[0, 2];
            int wygrana2 = pola[1, 0] + pola[1, 1] + pola[1, 2];
            int wygrana3 = pola[2, 0] + pola[2, 1] + pola[2, 2];
            int wygrana4 = pola[0, 0] + pola[1, 0] + pola[2, 0];
            int wygrana5 = pola[0, 1] + pola[1, 1] + pola[2, 1];
            int wygrana6 = pola[0, 2] + pola[1, 2] + pola[2, 2];
            int wygrana7 = pola[0, 0] + pola[1, 1] + pola[2, 2];
            int wygrana8 = pola[0, 2] + pola[1, 1] + pola[2, 0];

            //bot zaczyna
            if (ktoZaczyna==2)
            {
                if(kogoRuch==0)
                {
                    WstawZnak(buttonNazwy[1, 1]);
                }
                //drugi ruch
                if(kogoRuch==2)
                {
                    if( pola[0, 2] == 1 || pola[2, 0] == 1)
                    {
                        WstawZnak(buttonNazwy[0, 0]);
                    }
                    else if (pola[0, 0] == 1 || pola[2, 2] == 1)
                    {
                        WstawZnak(buttonNazwy[0, 2]);
                    }
                    else
                    {
                        WstawZnak(buttonNazwy[0, 2]);
                    }
                }
                //kolejne ruchy
                if(kogoRuch>2)
                {
                    RuchBota(wygrana1, wygrana2, wygrana3, wygrana4, wygrana5, wygrana6, wygrana7, wygrana8);
                }
            }
            //bot gra drugi
            else if(ktoZaczyna==1)
            {
                if (kogoRuch == 1)
                {
                    if (pola[1, 1] == -10)
                    {
                        WstawZnak(buttonNazwy[1, 1]);
                    }
                    else
                    {
                        WstawZnak(buttonNazwy[0, 0]);
                    }
                }
                //drugi ruch
                if (kogoRuch == 3)
                {
                    if(pola[1,1] == 0)
                    {
                        if(pola[0,0]==1 && pola[0,2]==1)
                        {
                            WstawZnak(buttonNazwy[0, 1]);
                        }
                        else if (pola[0, 0] == 1 && pola[2, 0] == 1)
                        {
                            WstawZnak(buttonNazwy[1, 0]);
                        }
                        else if (pola[2, 0] == 1 && pola[2, 2] == 1)
                        {
                            WstawZnak(buttonNazwy[2, 1]);
                        }
                        else if (pola[0, 2] == 1 && pola[2, 2] == 1)
                        {
                            WstawZnak(buttonNazwy[1, 2]);
                        }
                        else if(pola[0,0]==1 && pola[2,2]==1)
                        {
                            WstawZnak(buttonNazwy[0, 1]);
                        }
                        else if (pola[0, 2] == 1 && pola[2, 0] == 1)
                        {
                            WstawZnak(buttonNazwy[0, 1]);
                        }
                        //sytuacja gracz ma róg i bok po przeciwnej stronie, bot ma środek
                        else if ((pola[0,0]==1 || pola[2, 2] == 1 || pola[0, 2] == 1 || pola[2, 0] == 1) && (pola[0, 1] == 1 || pola[1, 0] == 1 || pola[1, 2] == 1 || pola[2, 1] == 1))
                        {
                            int a=0, b=0, c=0, d =0;
                            for (int i = 0; i < 3; i++)
                            {
                                for (int j = 0; j < 3; j++)
                                {
                                    if (i % 2 == 0 && j % 2 == 0)
                                    {
                                        if (pola[i, j] == 1)
                                        {
                                            a = i;
                                            b = j;
                                        }
                                    }
                                    else if ((i+j) % 2 == 1)
                                    {
                                        if (pola[i, j] == 1)
                                        {
                                            c = i;
                                            d = j;
                                        }
                                    }
                                }
                            }
                            if (a!=c && b!=d)
                            {
                                if (c % 2 == 0)
                                {
                                    WstawZnak(buttonNazwy[c, b]);
                                }
                                else
                                {
                                    WstawZnak(buttonNazwy[a, d]);
                                }
                            }
                            else
                            {
                                if(a == c)
                                {
                                    WstawZnak(buttonNazwy[a, 3-(b+d)]);
                                }
                                else
                                {
                                    WstawZnak(buttonNazwy[3-(a+c), b]);
                                }

                            }
                        }
                        else
                        {
                            for (int i = 0; i < 3; i++)
                            {
                                for (int j = 0; j < 3; j++)
                                {
                                    if (pola[i, j] == -10 && i%2==0 && j%2==0)
                                    {
                                        WstawZnak(buttonNazwy[i, j]);
                                        i = 3;
                                        j = 3;
                                    }
                                }
                            }
                        }
                    }
                    else if (pola[1,1]==1 && ((pola[1, 0] == 1) || (pola[1, 2] == 1) || (pola[0, 1] == 1) || (pola[2, 1] == 1)))
                    {
                        if (pola[1, 0] == 1)
                        {
                            WstawZnak(buttonNazwy[1, 2]);
                        }
                        else if (pola[1, 2] == 1)
                        {
                            WstawZnak(buttonNazwy[1, 0]);
                        }
                        else if (pola[0, 1] == 1)
                        {
                            WstawZnak(buttonNazwy[2, 1]);
                        }
                        else if (pola[2, 1] == 1)
                        {
                            WstawZnak(buttonNazwy[0, 1]);
                        }
                    }
                    else if (pola[0, 2] == -10)
                    {
                        WstawZnak(buttonNazwy[0, 2]);
                    }
                    else if (pola[2, 2] == -10)
                    {
                        WstawZnak(buttonNazwy[2, 2]);
                    }

                }
                //kolejne ruchy
                if(kogoRuch>3)
                {
                    RuchBota(wygrana1, wygrana2, wygrana3, wygrana4, wygrana5, wygrana6, wygrana7, wygrana8);                    
                }
            }
            //wypełnianie kolorem pól zaznaczonych przez komputer
            for (int i = 0; i < 3; i++)
            {
                for (int j = 0; j < 3; j++)
                {
                    if (pola[i, j] == 0)
                    {
                        buttonNazwy[i, j].BackgroundColor = Color.Green;
                    }
                }
            }
            kogoRuch++;
            SprawdzanieKoncaGry();
        }
        private void RuchBota(int wygrana1, int wygrana2, int wygrana3, int wygrana4, int wygrana5, int wygrana6, int wygrana7, int wygrana8)
        {

            {
                if (wygrana1 == -10)
                {
                    for (int i = 0; i < 3; i++)
                    {
                        if (pola[0, i] == -10)
                        {
                            WstawZnak(buttonNazwy[0, i]);
                        }
                    }
                }
                else if (wygrana2 == -10)
                {
                    for (int i = 0; i < 3; i++)
                    {
                        if (pola[1, i] == -10)
                        {
                            WstawZnak(buttonNazwy[1, i]);
                        }
                    }
                }
                else if (wygrana3 == -10)
                {
                    for (int i = 0; i < 3; i++)
                    {
                        if (pola[2, i] == -10)
                        {
                            WstawZnak(buttonNazwy[2, i]);
                        }
                    }
                }
                else if (wygrana4 == -10)
                {
                    for (int i = 0; i < 3; i++)
                    {
                        if (pola[i, 0] == -10)
                        {
                            WstawZnak(buttonNazwy[i, 0]);
                        }
                    }
                }
                else if (wygrana5 == -10)
                {
                    for (int i = 0; i < 3; i++)
                    {
                        if (pola[i, 1] == -10)
                        {
                            WstawZnak(buttonNazwy[i, 1]);
                        }
                    }
                }
                else if (wygrana6 == -10)
                {
                    for (int i = 0; i < 3; i++)
                    {
                        if (pola[i, 2] == -10)
                        {
                            WstawZnak(buttonNazwy[i, 2]);
                        }
                    }
                }
                else if (wygrana7 == -10)
                {
                    for (int i = 0; i < 3; i++)
                    {
                        if (pola[i, i] == -10)
                        {
                            WstawZnak(buttonNazwy[i, i]);
                        }
                    }
                }
                else if (wygrana8 == -10)
                {
                    if (pola[0, 2] == -10)
                    {
                        WstawZnak(buttonNazwy[0, 2]);
                    }
                    if (pola[1, 1] == -10)
                    {
                        WstawZnak(buttonNazwy[1, 1]);
                    }
                    if (pola[2, 0] == -10)
                    {
                        WstawZnak(buttonNazwy[2, 0]);
                    }
                }
                else if (wygrana1 == -8)
                {
                    for (int i = 0; i < 3; i++)
                    {
                        if (pola[0, i] == -10)
                        {
                            WstawZnak(buttonNazwy[0, i]);
                        }
                    }
                }
                else if (wygrana2 == -8)
                {
                    for (int i = 0; i < 3; i++)
                    {
                        if (pola[1, i] == -10)
                        {
                            WstawZnak(buttonNazwy[1, i]);
                        }
                    }
                }
                else if (wygrana3 == -8)
                {
                    for (int i = 0; i < 3; i++)
                    {
                        if (pola[2, i] == -10)
                        {
                            WstawZnak(buttonNazwy[2, i]);
                        }
                    }
                }
                else if (wygrana4 == -8)
                {
                    for (int i = 0; i < 3; i++)
                    {
                        if (pola[i, 0] == -10)
                        {
                            WstawZnak(buttonNazwy[i, 0]);
                        }
                    }
                }
                else if (wygrana5 == -8)
                {
                    for (int i = 0; i < 3; i++)
                    {
                        if (pola[i, 1] == -10)
                        {
                            WstawZnak(buttonNazwy[i, 1]);
                        }
                    }
                }
                else if (wygrana6 == -8)
                {
                    for (int i = 0; i < 3; i++)
                    {
                        if (pola[i, 2] == -10)
                        {
                            WstawZnak(buttonNazwy[i, 2]);
                        }
                    }
                }
                else if (wygrana7 == -8)
                {
                    for (int i = 0; i < 3; i++)
                    {
                        if (pola[i, i] == -10)
                        {
                            WstawZnak(buttonNazwy[i, i]);
                        }
                    }
                }
                else if (wygrana8 == -8)
                {
                    if (pola[0, 2] == -10)
                    {
                        WstawZnak(buttonNazwy[0, 2]);
                    }
                    if (pola[1, 1] == -10)
                    {
                        WstawZnak(buttonNazwy[1, 1]);
                    }
                    if (pola[2, 0] == -10)
                    {
                        WstawZnak(buttonNazwy[2, 0]);
                    }
                }
                else
                {
                    for (int i = 0; i < 3; i++)
                    {
                        for (int j = 0; j < 3; j++)
                        {
                            if (pola[i, j] == -10)
                            {
                                WstawZnak(buttonNazwy[i, j]);
                                i = 3;
                                j = 3;
                            }
                        }
                    }
                }

            }
        }
        private void WstawZnak(Button pole)
        {
            pole.Text = "O";
            pole.IsEnabled = false;
            int a = Grid.GetRow(pole);
            int b = Grid.GetColumn(pole);
            pola[a-1, b] = 0;
        }
        private void SprawdzanieKoncaGry()
        {

            int wygrana1 = pola[0, 0] + pola[0, 1] + pola[0, 2];
            int wygrana2 = pola[1, 0] + pola[1, 1] + pola[1, 2];
            int wygrana3 = pola[2, 0] + pola[2, 1] + pola[2, 2];
            int wygrana4 = pola[0, 0] + pola[1, 0] + pola[2, 0];
            int wygrana5 = pola[0, 1] + pola[1, 1] + pola[2, 1];
            int wygrana6 = pola[0, 2] + pola[1, 2] + pola[2, 2];
            int wygrana7 = pola[0, 0] + pola[1, 1] + pola[2, 2];
            int wygrana8 = pola[0, 2] + pola[1, 1] + pola[2, 0];
     
            if (wygrana1 == 0 || wygrana2 == 0 || wygrana3 == 0 || wygrana4 == 0 || wygrana5 == 0 || wygrana6 == 0 || wygrana7 == 0 || wygrana8 == 0)
            {
                koniecGry = true;               
            }
            if(koniecGry == true)
            {
                wynik = "Przegrałeś";
                QueueWynikow.Kolejka(QueueWynikow.ostatnieWyniki, wynik);                
                Navigation.PushAsync(new Page2(wynik, labelNazwa.Text));
                              
            }
            if(kogoRuch==9)
            {
                wynik = "Remis";
                QueueWynikow.Kolejka(QueueWynikow.ostatnieWyniki, wynik);
                Navigation.PushAsync(new Page2(wynik, labelNazwa.Text));
                
            }          
        }
        
        private void Button1_Clicked(object sender, EventArgs e)
        {
            Button przycisk = sender as Button;
            przycisk.IsEnabled = false;
            przycisk.BackgroundColor = Color.Blue;
            int a = Grid.GetRow(przycisk);
            int b = Grid.GetColumn(przycisk);
            pola[a-1, b] = 1;
            przycisk.Text = "X";
            kogoRuch++;
            SprawdzanieKoncaGry();
            RuchKomputera();
        }
    }       
}