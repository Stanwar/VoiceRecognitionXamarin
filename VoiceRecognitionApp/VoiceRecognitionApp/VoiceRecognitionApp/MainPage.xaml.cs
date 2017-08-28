using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using Xamarin.Forms;

namespace VoiceRecognitionApp
{
    public partial class MainPage : ContentPage
    {
        public MainPage()
        {
            InitializeComponent();
        }

        public void OnClickHome(object sender, EventArgs e)
        {
            NavigationPage page = new NavigationPage(new VoiceRecognitionApp.Views.HomePage());
            App.Current.MainPage = page;
        }
    }
}
