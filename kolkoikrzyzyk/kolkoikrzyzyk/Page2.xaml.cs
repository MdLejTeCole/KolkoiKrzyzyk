using System;
using System.Collections;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

using Xamarin.Forms;
using Xamarin.Forms.Xaml;

namespace kolkoikrzyzyk
{
	
	public partial class Page2 : ContentPage
	{
        MainPage nazwa = new MainPage();
        string nazwaUzyt;
        string r = "Remis";
               
        public Page2 (string wynik, string nazwaUzytkowkika)
		{          
			InitializeComponent ();
            nazwaUzyt = nazwaUzytkowkika;
            string[,] tab = QueueWynikow.WypiszKolejke(QueueWynikow.ostatnieWyniki, QueueWynikow.tablica, nazwaUzyt);
            
            labelWynik.Text = wynik;
            int ileWierszy=0;
            for (int i = 0; i < 6; i++)
            {
                if(tab[i,0]==null)
                {
                    ileWierszy = i;
                    i = 6;
                }
                else
                {
                    ileWierszy = 6;
                }
            }
            for (int i = 0; i < ileWierszy; i++)
            {
                labelOstatnieWyniki1.Text = tab[ileWierszy-1,0] + tab[ileWierszy - 1, 1];
                if (i >= 1)
                {
                    labelOstatnieWyniki2.Text = tab[ileWierszy - 2,0] + tab[ileWierszy - 2, 1];
                }
                if (i >= 2)
                {
                    labelOstatnieWyniki3.Text = tab[ileWierszy - 3,0] + tab[ileWierszy - 3, 1];
                }
                if (i >= 3)
                {
                    labelOstatnieWyniki4.Text = tab[ileWierszy - 4,0] + tab[ileWierszy - 4, 1];
                }
                if (i >= 4)
                {
                    labelOstatnieWyniki5.Text = tab[ileWierszy - 5,0] + tab[ileWierszy - 5, 1];
                }
                if (i >= 5)
                {
                    labelOstatnieWyniki6.Text = tab[ileWierszy - 6,0] + tab[ileWierszy - 6, 1];
                }
            }


            if (r.Equals(wynik))
            {
                labelWynikKolor.BackgroundColor = Color.Gray;                            
            }
            else
            {
                labelWynikKolor.BackgroundColor = Color.Red;               
            }
        }

        private void Nie_Clicked(object sender, EventArgs e)
        {
            Navigation.PushAsync(new MainPage());
            //System.Environment.Exit(0);
        }

        private void Tak_Clicked(object sender, EventArgs e)
        {
            
            Navigation.PushAsync(new Page1(nazwaUzyt));
        }
    }
}