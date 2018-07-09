using System;
using System.Collections.Generic;
using System.IO;
using System.Linq;
using System.Text;
using Android.App;
using Android.Content;
using Android.OS;
using Android.Runtime;
using Android.Util;
using Android.Views;
using Android.Widget;

namespace Hangman
{
    [Activity(Label = "Hangman", ScreenOrientation = Android.Content.PM.ScreenOrientation.Portrait)]
    public class GameActivity : Activity
    {
        Class myClass = new Class();

        private Button A;
        private Button B;
        private Button C;
        private Button D;
        private Button E;
        private Button F;
        private Button G;
        private Button H;
        private Button I;
        private Button J;
        private Button K;
        private Button L;
        private Button M;
        private Button N;
        private Button O;
        private Button P;
        private Button Q;
        private Button R;
        private Button S;
        private Button T;
        private Button U;
        private Button V;
        private Button W;
        private Button X;
        private Button Y;
        private Button Z;
        private TextView WordLine;
        private TextView Guess;
        private ImageView GamePic;
        //private int wrongGuesses;

        //String Word;
        //private char[] WordArrays;       
        //private char[] WordGuess2;        
        //private int rightGuesses;
        //int letters = 0;
        //private ImageView GamePic;
        //public string TheWord;
        //public char[] Wordz;


        //public string wordguess2;

        //string copycurrentword = "";


        List<string> WordList = new List<string>();

        protected override void OnCreate(Bundle savedInstanceState)
        {
            RequestWindowFeature(WindowFeatures.NoTitle);
            base.OnCreate(savedInstanceState);
            myClass.letters = 0;


            // Set our view from the "main" layout resource
            SetContentView(Resource.Layout.Game);

            StartUp();
            //LoadWords();
        }

        private void StartUp()
        {
            A = FindViewById<Button>(Resource.Id.btnA);
            B = FindViewById<Button>(Resource.Id.btnB);
            C = FindViewById<Button>(Resource.Id.btnC);
            D = FindViewById<Button>(Resource.Id.btnD);
            E = FindViewById<Button>(Resource.Id.btnE);
            F = FindViewById<Button>(Resource.Id.btnF);
            G = FindViewById<Button>(Resource.Id.btnG);
            H = FindViewById<Button>(Resource.Id.btnH);
            I = FindViewById<Button>(Resource.Id.btnI);
            J = FindViewById<Button>(Resource.Id.btnJ);
            K = FindViewById<Button>(Resource.Id.btnK);
            L = FindViewById<Button>(Resource.Id.btnL);
            M = FindViewById<Button>(Resource.Id.btnM);
            N = FindViewById<Button>(Resource.Id.btnN);
            O = FindViewById<Button>(Resource.Id.btnO);
            P = FindViewById<Button>(Resource.Id.btnP);
            Q = FindViewById<Button>(Resource.Id.btnQ);
            R = FindViewById<Button>(Resource.Id.btnR);
            S = FindViewById<Button>(Resource.Id.btnS);
            T = FindViewById<Button>(Resource.Id.btnT);
            U = FindViewById<Button>(Resource.Id.btnU);
            V = FindViewById<Button>(Resource.Id.btnV);
            W = FindViewById<Button>(Resource.Id.btnW);
            X = FindViewById<Button>(Resource.Id.btnX);
            Y = FindViewById<Button>(Resource.Id.btnY);
            Z = FindViewById<Button>(Resource.Id.btnZ);
            
            Guess = FindViewById<TextView>(Resource.Id.txtGuesses);
            GamePic = FindViewById<ImageView>(Resource.Id.ivHangman);
            WordGuess();
            myClass.wrongGuesses = 0;
            myClass.rightGuesses = 0;


            A.Click += HangmanLetter;
            B.Click += HangmanLetter;
            C.Click += HangmanLetter;
            D.Click += HangmanLetter;
            E.Click += HangmanLetter;
            F.Click += HangmanLetter;
            G.Click += HangmanLetter;
            H.Click += HangmanLetter;
            I.Click += HangmanLetter;
            J.Click += HangmanLetter;
            K.Click += HangmanLetter;
            L.Click += HangmanLetter;
            M.Click += HangmanLetter;
            N.Click += HangmanLetter;
            O.Click += HangmanLetter;
            P.Click += HangmanLetter;
            Q.Click += HangmanLetter;
            R.Click += HangmanLetter;
            S.Click += HangmanLetter;
            T.Click += HangmanLetter;
            U.Click += HangmanLetter;
            V.Click += HangmanLetter;
            W.Click += HangmanLetter;
            X.Click += HangmanLetter;
            Y.Click += HangmanLetter;
            Z.Click += HangmanLetter;
        }



        private void WordGuess()
        {
            GamePic.SetImageResource(Resource.Drawable.Hangman7);

            //Provide words from string

            //Random random = new Random(DateTime.Now.Millisecond);
            //int Rnd = random.Next(1, 4);

            //string[] wordBank = { "Abolishment", "Cat", "Blacksmith", "Merino", "Banana" };
            //string[] wordBank = { "Heather" };
            //Toast.MakeText(this, Word, ToastLength.Long).Show();
            //Word = wordBank[random.Next(0, wordBank.Length)];
            //LoadWords();


            var assets = Assets;

            using (var sr = new StreamReader(assets.Open("hangmanwords.txt")))
            {
                while (!sr.EndOfStream)
                {
                    var text = sr.ReadLine();


                    if (text != string.Empty && text.Length > 4) //ignore empty lines or words less than 4 letters
                    {
                        text = text.Trim();



                        var word = text;

                        word = word.Trim();

                        //cut out the stuff you don't want

                        if (!WordList.Contains(word))
                        {

                            WordList.Add(word);
                        }
                    }


                }
            }

            Random rand = new Random();


            int RndNumber = rand.Next(1, WordList.Count);


            myClass.Word = WordList[RndNumber];
            Toast.MakeText(this, myClass.Word, ToastLength.Long).Show();
            //FindViewById<TextView>(Resource.Id.txtWord).Text = Word;

            char[] WordArray = new char[myClass.Word.Length];

            char[] WordGuessArray;

            string copycurrentword = "";

            foreach (char letter in WordArray)
            {
                copycurrentword += "*";
                myClass.letters++;
            }



            WordGuessArray = copycurrentword.ToArray();

            myClass.WordGuess2 = WordGuessArray;



            FindViewById<TextView>(Resource.Id.txtGuesses).Text = new string(myClass.WordGuess2);
        }

        private void HangmanLetter(object sender, EventArgs e)
        {
            //make a fake button

            Button fakeBtn = (Button)sender;


            if (fakeBtn.Clickable)

            {
                fakeBtn.Enabled = false;

            }

            char letter = Convert.ToChar(fakeBtn.Text);
            LetterSorting(letter);


        }

        private void LetterSorting(char letter)
        {



            char[] WordArray = new char[myClass.Word.Length];
            myClass.WordArrays = WordArray;



            string WordUC = myClass.Word.ToUpper();



            if (WordUC.Contains(letter))
            {
                Toast.MakeText(this, letter + " is in the word", ToastLength.Long).Show();
                myClass.rightGuesses++;
                



            }
            else
            {
                Toast.MakeText(this, letter + " is not in the word", ToastLength.Long).Show();
                myClass.wrongGuesses++;


            }




            for (int i = 0; i < myClass.WordArrays.Length; i++)
            {


                if (WordUC[i] == letter)
                {
                    myClass.WordGuess2[i] = letter;
                    //myClass.letters++;
                    myClass.letters = myClass.letters - 1;



                }
            }

            //Toast.MakeText(this, myClass.letters.ToString(), ToastLength.Long).Show();



            FindViewById<TextView>(Resource.Id.txtGuesses).Text = new string(myClass.WordGuess2);


            //if (myClass.rightGuesses == myClass.letters )
            if (myClass.letters == 0)
            {

                Toast.MakeText(this, "Correct!", ToastLength.Long).Show();
                Toast.MakeText(this, myClass.Word, ToastLength.Long).Show();
                myClass.rightGuesses++;
                var mainActivity = new Intent(this, typeof(MainActivity));


                //run the inent and start the other screen passing over the data
                StartActivity(mainActivity);
            }


            if (myClass.wrongGuesses >= 6)
                {
                    //var DeadActivity = new Intent(this, typeof(DeadActivity));
                    //StartActivity(DeadActivity);
                    GamePic.SetImageResource(Resource.Drawable.Hangman1);
                    Toast.MakeText(this, "DEAD!", ToastLength.Long).Show();
                    Toast.MakeText(this, myClass.Word, ToastLength.Long).Show();
                    myClass.rightGuesses++;
                    var mainActivity = new Intent(this, typeof(MainActivity));


                    //run the inent and start the other screen passing over the data
                    StartActivity(mainActivity);
                }
          
            else if (myClass.wrongGuesses == 5)
            {
                GamePic.SetImageResource(Resource.Drawable.Hangman2);
            }
            else if (myClass.wrongGuesses == 4)
            {
                GamePic.SetImageResource(Resource.Drawable.Hangman3);
            }
            else if (myClass.wrongGuesses == 3)
                {
                    GamePic.SetImageResource(Resource.Drawable.Hangman4);
                }
                else if (myClass.wrongGuesses == 2)
                {
                    GamePic.SetImageResource(Resource.Drawable.Hangman5);
                }
                else if (myClass.wrongGuesses == 1)
            {
                    GamePic.SetImageResource(Resource.Drawable.Hangman6);
                }
            else
            {
                GamePic.SetImageResource(Resource.Drawable.Hangman7);
            }
                
            }






        }
    
}




