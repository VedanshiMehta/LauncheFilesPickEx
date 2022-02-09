using Android.App;
using Android.Content;
using Android.OS;
using Android.Runtime;
using Android.Views;
using Android.Webkit;
using Android.Widget;
using System;
using System.Collections.Generic;
using System.IO;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using Xamarin.Essentials;

namespace LauncheFilesPickEx
{
    [Activity(Label = "@string/app_name", Theme = "@style/AppTheme")]
    class LauncherDemo : Activity
    {
        private Button myButton;
        private WebView webView;
        private Button buttonfileOpen;

        protected override void OnCreate(Bundle savedInstanceState)
        {
            base.OnCreate(savedInstanceState);
            Xamarin.Essentials.Platform.Init(this, savedInstanceState);
            SetContentView(Resource.Layout.launcherDemo);


            myButton = FindViewById<Button>(Resource.Id.buttonClick);
            buttonfileOpen = FindViewById<Button>(Resource.Id.buttonFileOpen);
            webView = FindViewById<WebView>(Resource.Id.webView1);



            myButton.Click += MyButton_ClickAsync;
            buttonfileOpen.Click += ButtonfileOpen_Click;
        }

        private async void ButtonfileOpen_Click(object sender, EventArgs e)
        {
            var fn = "Shinchain.doc";
            var file = Path.Combine(FileSystem.CacheDirectory,fn);
            File.WriteAllText(file, "Shinchain is 5 year old boy.");

            await Launcher.OpenAsync(new OpenFileRequest
            {

                File = new ReadOnlyFile(file)
            }); 
        }

        private async void MyButton_ClickAsync(object sender, EventArgs e)
        {
            var supportsUri = await Launcher.CanOpenAsync("https://www.zomato.com/");

            if (supportsUri)
            {
                await Launcher.OpenAsync("https://www.zomato.com/");
            }

        }

    }
}