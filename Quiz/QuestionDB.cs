using System;
using System.Collections.Generic;
using System.Text;
using System.Linq;
using System.Threading.Tasks;
using System.IO;

namespace Quiz
{
    class QuestionDB
    {
        private List<Question> db; //коллекция вопросов
        private int i; //индекс текущего вопроса
        public Question CurrentQuestion //свойство получения вопроса по индексу
        {
            get
            {
                i++;
                return db[i % db.Count]; //зацикливание вопросов
            }
        }
        public QuestionDB()
        {
            this.db = new List<Question>();
            this.i = 0;
            var dataFile = File.ReadAllLines(@"C:\Users\froze\Documents\Quiz\Quiz\screenshots\screen.txt"); //считывание файла
            foreach (var e in dataFile) //пробег по всем строкам 
            {
                var args = e.Split('|'); //при встрече знака "|" 
                db.Add(new Question(args[0], args[1])); //разделить строку на две и передать первую часть в поле адрес изображения а вторую в ответ
            }
        }
    }
}