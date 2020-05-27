using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Text.RegularExpressions;
using System.Threading.Tasks;

namespace PP_Z11_
{
    class RegExp
    {
        private Regex r;
        private string text;

        public RegExp(string pattern, string txt)
        {
            r = new Regex(pattern);
            text = txt;
        }
        public bool IsExist()
        {
            Console.WriteLine("Определить, содержит ли текст фрагменты, соответствующие шаблону поля:");
            MatchCollection m = r.Matches(text);
            foreach (Match x in m)
            {
                Console.WriteLine("Есть\n");
                return true;
            }
            Console.WriteLine("Нет\n");
            return false;
        }

        public void ShowMatches()
        {
            Console.WriteLine("Вывести на экран все фрагменты текста, соответствующие шаблону поля:");
            MatchCollection m = r.Matches(text);
            foreach (Match x in m)
                Console.WriteLine("Нашлось совпадение с шаблоном:\n" + x.Value + "\n");
        }

        public string DeleteMatches()
        {
            Console.WriteLine("Удалить из текста все фрагменты, соответствующие шаблону поля:");
            MatchCollection m = r.Matches(text);
            string s = text;
            foreach (Match x in m)
            {
                int i = s.IndexOf(x.Value);
                int l = x.Value.Length;

                s = s.Remove(i, l);
            }
            Console.WriteLine(s);
            return s;
        }
        public Regex R
        {
            get { return r; }
            set { r = value; }
        }

        public string Text
        {
            get { return text; }
            set { text = value; }
        }
    }
    class Program
    {
        static void Main(string[] args)
        {
            string text = "Мой телефон 8(926)123-45-67, а у мамы +7 926 123 45 67";
            string pattern = @"((8|\+7)[\- ]?)?(\(?\d{3}\)?[\- ]?)?[\d\- ]{7,10}";

            Console.WriteLine("Строка текста:\n" + text + "\n");
            Console.WriteLine("Регулярное выражение:\n" + pattern + "\n");

            RegExp My = new RegExp(pattern, text);

            My.IsExist();
            My.ShowMatches();
            My.DeleteMatches();

            Console.ReadKey();
        }
    }

}
