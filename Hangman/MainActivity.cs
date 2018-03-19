using Android.App;
using Android.Widget;
using Android.OS;
using Android.Views;
using System;
using Android.Content;

namespace Hangman
{
    [Activity(Label = "Hangman", MainLauncher = true, Icon =
        "@drawable/mv")]
    public class MainActivity : Activity
    {
        private Button btnNext;
        private TextView txtName;



        protected override void OnCreate(Bundle savedInstanceState)
        {
            RequestWindowFeature(WindowFeatures.NoTitle);
            base.OnCreate(savedInstanceState);



            // Set our view from the "main" layout resource
            SetContentView(Resource.Layout.Main);
            StartUp();

        }

        private void StartUp()
        {
            txtName = FindViewById<TextView>(Resource.Id.etEnterName);
            btnNext = FindViewById<Button>(Resource.Id.btnNext);

            btnNext.Click += onNext_Click;

        }

        private void onNext_Click(object sender, EventArgs e)
        {
            //Create an intent to move data to the other activity
            //Toast.MakeText(this, "Hi", ToastLength.Long).Show();

            var gameActivity = new Intent(this, typeof(GameActivity));
            gameActivity.PutExtra("Name", txtName.Text);

            //run the inent and start the other screen passing over the data
            StartActivity(gameActivity);

        }
    }
}

