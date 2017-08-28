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
        }

        //private void endVoiceButton_Clicked(object sender, EventArgs e)
        //{

        //}
        public void OnStart(object sender, EventArgs e)
        {
            convertedText.Text = "Started Recording";
        }

        public void OnStop(object sender, EventArgs e)
        {
            convertedText.Text = "End Recording";
        }
    }
}