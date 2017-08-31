using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

using Xamarin.Forms;
using Xamarin.Forms.Xaml;

namespace VoiceRecognitionApp.Views
{
    [XamlCompilation(XamlCompilationOptions.Compile)]
    public partial class HomePage : ContentPage
    {
        public HomePage()
        {
            InitializeComponent();
            // Add event handler
            voiceButton.OnTextChanged += (txt) => {
                convertedText.Text = txt;
            };
        }

        public void OnStart(object sender, EventArgs e)
        {
            convertedText.Text = "Started Recording";
        }

        public void OnStop(object sender, EventArgs e)
        {
            convertedText.Text = "End Recording";
        }

        public void GoHome(object sender, EventArgs e)
        {
            NavigationPage page = new NavigationPage(new VoiceRecognitionApp.MainPage());
            App.Current.MainPage = page;
        }
    }
}