using System;
using Xamarin.Forms;

namespace VoiceRecognitionApp.Views
{
    public class VoiceButton : Button
    {
        public Action<string> OnTextChanged { get; set; }
    }
}