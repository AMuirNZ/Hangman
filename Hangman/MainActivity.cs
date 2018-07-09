using Android.App;
using Android.Widget;
using Android.OS;
using Android.Views;
using System;
using Android.Content;
using Android.Media;

namespace Hangman
{
    [Activity(Label = "Hangman", MainLauncher = true, Icon =
        "@drawable/CS", ScreenOrientation = Android.Content.PM.ScreenOrientation.Portrait)]
    public class MainActivity : Activity
    {
        private Button btnNext;
        private Button btnMusic;
        private TextView txtName;
        private int Music = 0;

        MediaPlayer _player;

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
            btnMusic = FindViewById<Button>(Resource.Id.btnMusic);

            btnNext.Click += onNext_Click;
            btnMusic.Click += onMusic_Click;

        }

        private void onNext_Click(object sender, EventArgs e)
        {
            //if (Music == 0)
            //{
            //    _player = MediaPlayer.Create(this, Resource.Raw.Theme);
            //    _player.Start();
            //    Music = 1;
            //}
            //else
            //{
            //    _player.Stop();
            //    Music = 0;
            //}
            //Create an intent to move data to the other activity
            //Toast.MakeText(this, "Hi", ToastLength.Long).Show();

            var gameActivity = new Intent(this, typeof(GameActivity));
            gameActivity.PutExtra("Name", txtName.Text);

            //run the inent and start the other screen passing over the data
            StartActivity(gameActivity);

        }

        private void onMusic_Click(object sender, EventArgs e)
        {
            if (Music == 0)
            {
                _player = MediaPlayer.Create(this, Resource.Raw.Theme);
                _player.Start();
                Music = 1;
            }
            else
            {
                _player.Stop();
                Music = 0;
            }
            //Create an intent to move data to the other activity
            //Toast.MakeText(this, "Hi", ToastLength.Long).Show();

            //var gameActivity = new Intent(this, typeof(GameActivity));
            //gameActivity.PutExtra("Name", txtName.Text);

            ////run the inent and start the other screen passing over the data
            //StartActivity(gameActivity);

        }


    }
}

