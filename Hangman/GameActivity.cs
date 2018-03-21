using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;

using Android.App;
using Android.Content;
using Android.OS;
using Android.Runtime;
using Android.Views;
using Android.Widget;

namespace Hangman
{
    [Activity(Label = "Hangman")]
    public class GameActivity : Activity
    {
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
        String Word;
        private char[] WordArrays;
        private char[] underscore;
        private char[] WordGuess2;
        private int wrongGuesses;
        private int rightGuesses;


        protected override void OnCreate(Bundle savedInstanceState)
        {
            RequestWindowFeature(WindowFeatures.NoTitle);
            base.OnCreate(savedInstanceState);



            // Set our view from the "main" layout resource
            SetContentView(Resource.Layout.Game);
            StartUp();
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
            WordLine = FindViewById<TextView>(Resource.Id.txtWord);
            Guess = FindViewById<TextView>(Resource.Id.txtGuesses);

            WordGuess();
            wrongGuesses = 0;
            rightGuesses = 0;


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
            Random random = new Random(DateTime.Now.Millisecond);
            //int Rnd = random.Next(1, 4);

            string[] wordBank = { "Abolishment", "Cat", "Blacksmith", "Merino" };

            Word = wordBank[random.Next(0, wordBank.Length)];

            FindViewById<TextView>(Resource.Id.txtWord).Text = Word;

            char[] WordArray = new char[Word.Length];
            
            char[] WordGuessArray;

            string copycurrentword = "";

            foreach  (char letter in WordArray)
            {
                copycurrentword += "_";

            }
            

            WordGuessArray = copycurrentword.ToArray();

            WordGuess2 = WordGuessArray;



            FindViewById<TextView>(Resource.Id.txtGuesses).Text = new string(WordGuess2);
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

            

            char[] WordArray = new char[Word.Length];
            WordArrays = WordArray;



            string WordUC = Word.ToUpper();

            

            if (WordUC.Contains(letter))
            {
                Toast.MakeText(this, letter + " is in the word", ToastLength.Long).Show();
                rightGuesses++;


            }
            else
            {
                Toast.MakeText(this, letter + " is not in the word", ToastLength.Long).Show();
                wrongGuesses++;



            }

            


            for (int i = 0; i < WordArrays.Length; i++)
            {


                if (WordUC[i] == letter)
                { 
                    WordGuess2[i] = letter;
                }
            }

            FindViewById<TextView>(Resource.Id.txtGuesses).Text = new string(WordGuess2);

            if (wrongGuesses == 5)
            {
                //var DeadActivity = new Intent(this, typeof(DeadActivity));
                //StartActivity(DeadActivity);

                Toast.MakeText(this, "DEAD!", ToastLength.Long).Show();
                rightGuesses++;
            }


        }
    }
}