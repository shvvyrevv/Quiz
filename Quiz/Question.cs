using System;
using System.Collections.Generic;
using System.Text;
using System.Linq;
using System.Threading.Tasks;
using System.Windows.Media.Imaging;

namespace Quiz
{
    public class Question
    {
        public BitmapImage Picture { get; set; } // поле хранения изображения
        public string Answer { get; set; } // поле хранения ответа
        public Question(string PathBitmapImageSource, string AnswerSource) //конструктор с указанием пути изображения и правильного ответа
        {
            this.Picture = new BitmapImage();
            this.Picture.BeginInit(); //инициализация текущего изображения
            this.Picture.UriSource = new Uri(PathBitmapImageSource, UriKind.Relative); //указание адресаресурса 
            this.Picture.EndInit(); //окончание процесса загрузки
            this.Answer = AnswerSource; //сохранение ответа
        }

    }
}