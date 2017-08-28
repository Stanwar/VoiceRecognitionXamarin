using System;

using Android.App;
using Android.Content.PM;
using Android.Runtime;
using Android.Views;
using Android.Widget;
using Android.OS;

namespace VoiceRecognitionApp.Droid
{
    [Activity(Label = "VoiceRecognitionApp", Icon = "@drawable/icon", Theme = "@style/MainTheme", MainLauncher = true, ConfigurationChanges = ConfigChanges.ScreenSize | ConfigChanges.Orientation)]
    public class MainActivity : global::Xamarin.Forms.Platform.Android.FormsAppCompatActivity
    {
        //private bool isRecording;
        //private readonly int VOICe = 10;
        //private TextView textbox;
        //private Button recButton;

        protected override void OnCreate(Bundle bundle)
        {
            TabLayoutResource = Resource.Layout.Tabbar;
            ToolbarResource = Resource.Layout.Toolbar;

            base.OnCreate(bundle);

            //string rec = Android.Content.PM.PackageManager.FeatureMicrophone;

            //if (rec != "android.hardware.microphone")
            //{
            //    var alert = new AlertDialog.Builder
            //}
            //isRecording = false;
            //SetContentView(Resource.Layout);
            
            global::Xamarin.Forms.Forms.Init(this, bundle);
            LoadApplication(new App());
        }
    }
}

