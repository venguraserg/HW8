using System;
using System.Text;
using HW8.Model;



namespace HW8
{
    class Program
    {
        static void Main(string[] args)
        {
            //Настройка кодировки
            Console.OutputEncoding = Encoding.UTF8;

            //Цикл выполнения программы
            Company company = new Company();

            //путь к базе данных по умолчанию, не знаю почему, будем работать с json
            string path = "defaultBase.json";

            //Инициализация
            ConsoleIO.FirstScan(ref company, ref path);



            //Цикл выполнения программы
            while (ConsoleIO.Menu(ref company, path))
            {

            }
            //конец программы
            Console.WriteLine("Завершение программы. Нажмите любую клавищу . . . ");
            Console.ReadKey();
        }
    }
}
