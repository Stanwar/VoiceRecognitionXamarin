﻿using System;
using Android.App;
using Android.Content;
using Android.Speech;
using VoiceRecognitionApp.Droid;
using VoiceRecognitionApp.Views;
using Xamarin.Forms;
using Xamarin.Forms.Platform.Android;

[assembly: ExportRenderer(typeof(VoiceButton), typeof(VoiceButtonRenderer))]
namespace VoiceRecognitionApp.Droid
{
    public class VoiceButtonRenderer : ButtonRenderer, Android.Views.View.IOnClickListener
    {
        private readonly int VOICE = 10;
        private MainActivity activity;
        private global::Android.Widget.Button nativeButton;
        private VoiceButton sharedButton;

        public VoiceButtonRenderer()
        {
        }
        protected override void OnElementChanged(ElementChangedEventArgs<Button> e)
        {
            base.OnElementChanged(e);
            activity = this.Context as MainActivity;
            nativeButton = new global::Android.Widget.Button(Context);

            if (e.OldElement == null)
            {
                SetNativeControl(nativeButton);
                nativeButton.Clickable = true;
                nativeButton.Focusable = true;
                nativeButton.SetOnClickListener(this);

            }

            if (e.OldElement != null)
            {
                activity.ActivityResult -= HandleActivityResult;
            }

            if (e.NewElement != null)
            {
                activity.ActivityResult += HandleActivityResult;
                sharedButton = e.NewElement as VoiceButton;
            }
        }
        protected override void OnElementPropertyChanged(object sender, System.ComponentModel.PropertyChangedEventArgs e)
        {
            base.OnElementPropertyChanged(sender, e);
            if (Control == null)
            {
                return;
            }
        }
        public void OnClick(Android.Views.View view)
        {
            try
            {
                string rec = Android.Content.PM.PackageManager.FeatureMicrophone;
                if (rec != "android.hardware.microphone")
                {
                    // no microphone, no recording. Disable the button and output an alert
                    var alert = new AlertDialog.Builder(Context);
                    alert.SetTitle("No microphone detected.");
                    alert.SetPositiveButton("OK", (sender, e) => {
                        return;
                    });

                    alert.Show();
                }
                else
                {
                    // create the intent and start the activity
                    var voiceIntent = new Intent(RecognizerIntent.ActionRecognizeSpeech);
                    voiceIntent.PutExtra(RecognizerIntent.ExtraLanguageModel, RecognizerIntent.LanguageModelFreeForm);

                    // put a message on the modal dialog
                    voiceIntent.PutExtra(RecognizerIntent.ExtraPrompt, "Speak Up!");

                    // if there is more then 1.5s of silence, consider the speech over
                    voiceIntent.PutExtra(RecognizerIntent.ExtraSpeechInputCompleteSilenceLengthMillis, 1500);
                    voiceIntent.PutExtra(RecognizerIntent.ExtraSpeechInputPossiblyCompleteSilenceLengthMillis, 1500);
                    voiceIntent.PutExtra(RecognizerIntent.ExtraSpeechInputMinimumLengthMillis, 15000);
                    voiceIntent.PutExtra(RecognizerIntent.ExtraMaxResults, 1);

                    voiceIntent.PutExtra(RecognizerIntent.ExtraLanguage, Java.Util.Locale.Default);
                    activity.StartActivityForResult(voiceIntent, VOICE);
                }
            }
            catch (Exception ex)
            {
                Console.WriteLine(ex.Message);
            }
        }
        private void HandleActivityResult(object sender, ActivityResultEventArgs e)
        {
            if (e.RequestCode == VOICE)
            {
                if (e.ResultCode == Result.Ok)
                {
                    var matches = e.Data.GetStringArrayListExtra(RecognizerIntent.ExtraResults);
                    if (matches.Count != 0)
                    {
                        string textInput = matches[0];

                        // limit the output to 500 characters
                        if (textInput.Length > 500)
                            textInput = textInput.Substring(0, 500);
                        sharedButton.OnTextChanged?.Invoke(textInput);
                        //textBox.Text = textInput;
                    }
                    else
                        sharedButton.OnTextChanged?.Invoke("No speech was recognised");
                }
            }

        }


    }
}
