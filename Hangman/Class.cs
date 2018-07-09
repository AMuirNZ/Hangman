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
    class Class
    {

        public int wrongGuesses { get; set; }
        public String Word { get; set; }
        public char[] WordArrays { get; set; }
        public char[] WordGuess2 { get; set; }
        public int rightGuesses { get; set; }
        public int letters { get; set; }
      
        public string TheWord { get; set; }
        public char[] Wordz { get; set; }
        

        public string wordguess2 { get; set; }

    }
}