using Android.App;
using Android.Content;
using Android.OS;
using Android.Runtime;
using Android.Widget;
using AndroidX.AppCompat.App;

namespace LauncheFilesPickEx
{
    [Activity(Label = "@string/app_name", Theme = "@style/AppTheme", MainLauncher = true)]
    public class MainActivity : AppCompatActivity
    {
        private Button myLauncher;
        private Button myFilePicker;
        protected override void OnCreate(Bundle savedInstanceState)
        {
            base.OnCreate(savedInstanceState);
            Xamarin.Essentials.Platform.Init(this, savedInstanceState);
            // Set our view from the "main" layout resource
            SetContentView(Resource.Layout.activity_main);
            myLauncher = FindViewById<Button>(Resource.Id.button1);
            myFilePicker = FindViewById<Button>(Resource.Id.button2);

            myLauncher.Click += MyLauncher_Click;
            myFilePicker.Click += MyFilePicker_Click;
        }

        private void MyFilePicker_Click(object sender, System.EventArgs e)
        {
            Intent j = new Intent(Application.Context, typeof(FilePickerDemo));
            StartActivity(j);
        }

        private void MyLauncher_Click(object sender, System.EventArgs e)
        {
            Intent i = new Intent(Application.Context, typeof(LauncherDemo));
            StartActivity(i);
        }



        public override void OnRequestPermissionsResult(int requestCode, string[] permissions, [GeneratedEnum] Android.Content.PM.Permission[] grantResults)
        {
            Xamarin.Essentials.Platform.OnRequestPermissionsResult(requestCode, permissions, grantResults);

            base.OnRequestPermissionsResult(requestCode, permissions, grantResults);

            
        }

      
    }
   

}