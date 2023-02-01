using System;
using System.Collections.Generic;
using System.Text;
using System.Linq;
using System.Threading.Tasks;
using System.Windows.Controls;
using System.Windows;
using System.Windows.Media;


namespace Quiz
{
    class MainLogic
    {
        private StackPanel spAnswers; Image image;
        string currentAnswer;
        QuestionDB data;

        public TextBlock CreateTb(string Txt, StackPanel ToSp)
        {
            var tb = new TextBlock()
            {
                Text = Txt,
                FontSize = 25,
                TextAlignment = TextAlignment.Center,
                Margin = new Thickness(3),
                Background = Brushes.Coral,
                Width = 30,
                Height = 40,
            };
            tb.MouseDown += (s, e) =>
            {
                ToSp.Children.Add(CreateTbAlp((s as TextBlock).Text, ToSp));
                CheckAnswer();
            };
            return tb;
        }

        public TextBlock CreateTbAlp(string Txt, StackPanel stackPanel)
        {
            var tb = new TextBlock()
            {
                Text = Txt,
                FontSize = 30,
                Margin = new Thickness(3),
                Padding = new Thickness(10),
                Background = Brushes.LightBlue,
            };
            tb.MouseDown += (s, e) =>
            {
                stackPanel.Children.Remove((s as TextBlock));
            };
            return tb;
        }

        public void CheckAnswer()
        {
            string word = String.Empty;
            foreach (var e in spAnswers.Children) word += (e as TextBlock).Text;
            if (word == currentAnswer)
            {

                LoadNewQuestion();
            }
        }

        public void LoadNewQuestion()
        {
            var q = data.CurrentQuestion;
            image.Source = q.Picture;
            currentAnswer = q.Answer;
            spAnswers.Children.Clear();
        }

        public MainLogic(StackPanel SPAlphabet, StackPanel SPAnswers, Image ImageView)
        {
            data = new QuestionDB();
            image = ImageView;
            spAnswers = SPAnswers;

            for (int i = (int)'а'; i <= (int)'я'; i++)
            {
                SPAlphabet.Children.Add(CreateTb($"{(char)i}", SPAnswers));
                if (i == (int)'е')
                {
                    SPAlphabet.Children.Add(CreateTb($"{'ё'}", SPAnswers));
                }
                LoadNewQuestion();
            }
        }
    }
}