using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Diagnostics;
using System.Drawing;
using System.Linq;

using System.Reflection.Emit;
using System.Text;
using System.Windows.Forms;
using Microsoft.Speech.Recognition;

namespace SpeechRecognition
{
    public partial class Form1 : Form
    {
        public Form1()
        {
            InitializeComponent();
        }

        static System.Windows.Forms.Label l;

        static void sre_SpeechRecognized(object sender, SpeechRecognizedEventArgs e)
        {
            if (e.Result.Confidence > 0.7) l.Text = e.Result.Text;
        }	
        // Вывод  текста на экран
        private void Form1_Shown(object sender, EventArgs e)
        {

            l = label1;
            // Используем метод для переопределения языка на русский.
            System.Globalization.CultureInfo ci = new System.Globalization.CultureInfo("ru-ru");
            SpeechRecognitionEngine sre = new SpeechRecognitionEngine(ci);
            sre.SetInputToDefaultAudioDevice();
          
            sre.SpeechRecognized += new EventHandler<SpeechRecognizedEventArgs>(sre_SpeechRecognized);
          
          // Закидываем наш набор слов в массив данных  
            Choices numbers = new Choices();
            numbers.Add(new string[] { "привет", "как дела?", "Что делаешь?", "пока","Да", "Нет", "два", "три", "четыре", "пять"  });
             
            GrammarBuilder gb = new GrammarBuilder();
            gb.Culture = ci;
            gb.Append(numbers);


            Grammar g = new Grammar(gb);
            sre.LoadGrammar(g);


            sre.RecognizeAsync(RecognizeMode.Multiple);
            // Пытаемся запустить калькулятор. 
            //if (l.Text == "Пока")
            //{
            //    Close();
            //}
            //if (label1.Text == "Калькулятор")
            //{
            //    Process.Start("calc.exe");
            //}
        }

        private void lable1_TextChanged(object sender, EventArgs e)
        {
           
        }
    }
}
