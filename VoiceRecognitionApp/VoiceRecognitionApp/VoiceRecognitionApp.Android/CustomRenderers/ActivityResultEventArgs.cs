using System;
using Android.App;
using Android.Content;

namespace VoiceRecognitionApp    
{
    public class ActivityResultEventArgs : EventArgs
    {
        public int RequestCode { get; set; }
        public Result ResultCode { get; set; }
        public Intent Data { get; set; }

        public ActivityResultEventArgs() : base()
        {

        }
    }
}
    