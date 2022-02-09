using Android.App;
using Android.Content;
using Android.Graphics;
using Android.OS;
using Android.Runtime;
using Android.Views;
using Android.Widget;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using Xamarin.Essentials;

namespace LauncheFilesPickEx
{
    [Activity(Label = "@string/app_name", Theme = "@style/AppTheme")]
    class FilePickerDemo: Activity
    {
        private Button buttonPicker;
        private ImageView myPickerView;
        private TextView mytextPicker;
        private PickOptions options;
        protected override void OnCreate(Bundle savedInstanceState)
        {
            base.OnCreate(savedInstanceState);
            Xamarin.Essentials.Platform.Init(this, savedInstanceState);
            SetContentView(Resource.Layout.filepickerDemo);

            buttonPicker = FindViewById<Button>(Resource.Id.buttonP);
            myPickerView = FindViewById<ImageView>(Resource.Id.imageViewP);
            mytextPicker = FindViewById<TextView>(Resource.Id.textViewP);

            buttonPicker.Click += ButtonPicker_Click;
        }

        private async void ButtonPicker_Click(object sender, EventArgs e)
        {

            var res = await FilePicker.PickAsync(options);
            if (res != null)
            {
                mytextPicker.Text = $"File Name: {res.FileName}";
                if (res.FileName.EndsWith("jpg", StringComparison.OrdinalIgnoreCase) || (res.FileName.EndsWith("png", StringComparison.OrdinalIgnoreCase)))
                {

                    var stream = await res.OpenReadAsync();
                    myPickerView.SetImageBitmap(BitmapFactory.DecodeStream(stream));
                }
            
            }
        }
    }
}