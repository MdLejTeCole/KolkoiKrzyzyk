using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using Xamarin.Forms;

namespace kolkoikrzyzyk
{
    public partial class MainPage : ContentPage
    {
        public String entryNazwa1;
        public MainPage()
        {
            InitializeComponent();

        }

        private void StartNutton_Clicked(object sender, EventArgs e)
        {
            entryNazwa1 = entryNazwa.Text;
            Navigation.PushAsync(new Page1(entryNazwa.Text));
        }
    }
}
