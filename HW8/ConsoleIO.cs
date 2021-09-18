

using HW8.Model;
using Newtonsoft.Json;
using System;
using System.Collections.Generic;
using System.Globalization;
using System.IO;
using System.Linq;

namespace HW8
{
    /// <summary>
    /// Статический класс обеспечивающий ввод/вывод через консоль
    /// </summary>
    public class ConsoleIO
    {

        internal static bool Menu(ref Company company, string path)
        {

            // Меню 
            bool quit = false;
            Console.Clear();
            Console.WriteLine("Организация: " + company.Name);
            Console.WriteLine("Меню приложения:");
            Console.WriteLine("1. Департаменты");
            Console.WriteLine("2. Сотрудники");
            Console.WriteLine("3. Выход");

            switch (InputNumber())
            {
                case 1:
                    {
                        bool comeBack = false;
                        do
                        {
                            Console.Clear();
                            Console.WriteLine("Меню Департамента:");
                            Console.WriteLine("1. Посмотреть список");
                            Console.WriteLine("2. Добавить департамент");
                            Console.WriteLine("3. Удалить департамент");
                            Console.WriteLine("4. Редактировать департамент");
                            Console.WriteLine("5. Назад");

                            switch (InputNumber())
                            {
                                //просмотр департаментов
                                case 1:
                                    Console.Clear();
                                    Console.WriteLine("Список департаментов: ");
                                    PrintDepartment(company);
                                    Console.WriteLine("Для продолжения нажмите любую клавишу. . .");
                                    Console.ReadKey(true);
                                    break;
                                //Добавление департаментов
                                case 2:
                                    Console.Clear();
                                    Console.WriteLine("Добавление департамента: ");
                                    Console.Write("Введите название: ");
                                    company.AddDepartment(new Department(Console.ReadLine()));
                                    break;
                                //Удаление департамента
                                case 3:
                                    Console.Clear();
                                    int index = GetIndexDepartment(company);
                                    if (index >= 0)
                                    {
                                        company.RemoveDepartment(index);
                                    }
                                    break;

                                // Редактировать департамент
                                case 4:
                                    Console.Clear();
                                    index = GetIndexDepartment(company);

                                    if (index >= 0)
                                    {
                                        string newName = company.DepartmentsList[index].Name;
                                        DateTime newCreateDate = company.DepartmentsList[index].CreateDate;
                                        List<Employee> newListEmployees = company.DepartmentsList[index].Employees;


                                        if (EnterYesNo($"Название департамента - {company.DepartmentsList[index].Name}, желаете изменить? (Y/N)"))
                                        {
                                            Console.Write("Введите новое имя: ");
                                            newName = Console.ReadLine();
                                        }

                                        if (EnterYesNo($"Дата создания департамента - {company.DepartmentsList[index].CreateDate.ToShortDateString()}, желаете изменить? (Y/N)"))
                                        {
                                            Console.Write("Введите дату создания департамента: ");
                                            newCreateDate = InputDate(DateTime.Parse("01.01.1900"), DateTime.Now);
                                        }

                                        if (EnterYesNo($"Департамент имеет {company.DepartmentsList[index].Employees.Count()}, желаете удалить сотрудников? (Y/N)"))
                                        {

                                            newListEmployees.Clear();
                                        }

                                        company.EditDepartment(new Department(newName, newCreateDate, newListEmployees), index);
                                        
                                    }

                                    break;
                                case 5:
                                    comeBack = true;
                                    break;

                                default:
                                    Console.WriteLine("Не верный ввод, повторите. . .");
                                    break;
                            }

                        } while (!comeBack);

                        break;
                    }
                case 2:
                    {
                        bool comeBack = false;
                        do
                        {
                            Console.Clear();
                            Console.WriteLine("Меню Сотрудников:");
                            Console.WriteLine("1. Посмотреть список ВСЕХ сотрудников");
                            Console.WriteLine("2. Добавить сотрудника");
                            Console.WriteLine("3. Удалить сотрудника");
                            Console.WriteLine("4. Редактировать сотрудника");
                            Console.WriteLine("5. Назад");

                            switch (InputNumber())
                            {
                                case 1:

                                    break;










                                case 5:
                                    comeBack = true;
                                    break;

                                default:
                                    Console.WriteLine("Не верный ввод, повторите. . .");
                                    break;
                            }
                        } while (!comeBack);
                        break;
                    }
                case 3:
                    SaveData(company, path);
                    quit = true;
                    break;

                default:
                    Console.WriteLine("Не верный ввод, повторите. . .");
                    break;
            }

            return !quit;
        }
        /// <summary>
        /// Выбор департамента по индексу и имени
        /// </summary>
        /// <param name="company"></param>
        /// <returns></returns>
        private static int GetIndexDepartment(Company company)
        {
            Console.WriteLine("Список департаментов: ");
            PrintDepartment(company);
            int index = -1;
            if (EnterYesNo("Выбрать департамент по индексу? (Y/N)"))
            {
                Console.WriteLine("Введите индекс");
                index = InputNumber() - 1;
            }
            else
            //Удаление по имени
            {
                Console.WriteLine("Введите имя депортамента");
                int tempString = FindDepartmentByName(company, Console.ReadLine());
                if (tempString >= 0)
                {
                    index = tempString;                    
                }
                else
                {
                    Console.WriteLine("Департамент не найден");
                }
                Console.WriteLine("Для продолжения нажмите любую клавишу. . .");
                Console.ReadKey(true);
            }

            return index > company.DepartmentsList.Count ? -1: index;
        }

        /// <summary>
        /// Поиск департамента по имени
        /// </summary>
        /// <param name="company"></param>
        /// <param name="name"></param>
        /// <returns></returns>
        private static int FindDepartmentByName(Company company, string name)
        {
            int index = -1;
            for (int i = 0; i < company.DepartmentsList.Count; i++)
            {
                if(company.DepartmentsList[i].Name == name)
                {
                    index = i;
                    break;
                }
            }
            return index;
        }

        /// <summary>
        /// Вывод перечня департаментов
        /// </summary>
        /// <param name="company"></param>
        private static void PrintDepartment(Company company)
        {
            if(company.DepartmentsList.Count == 0)
            {
                Console.WriteLine("Записей нет. . .");
            }
            else
            {
                Console.WriteLine("");
                for (int i = 0; i < company.DepartmentsList.Count; i++)
                {
                    Console.WriteLine($"#{i+1} - {company.DepartmentsList[i].ToString()}");
                }
                Console.WriteLine("");
            }

        }

        /// <summary>
        /// инициализация приложения
        /// </summary>
        /// <param name="company"></param>
        internal static void FirstScan(ref Company company, ref string path)
        {
            Console.WriteLine("***********************************************");
            Console.WriteLine("*     Информационная система предприятия      *");
            Console.WriteLine("***********************************************\n\n\n");

            string tempPath;

            if (EnterYesNo("Загрузить базу по умолчанию(Y/N)")) 
            {
                tempPath = path;
            }
            else
            {
                Console.WriteLine("Введите имя файла без расширения, если такого файла нет, то он будет создан:");
                tempPath = Console.ReadLine() + ".json"; 
            }

            if (File.Exists(tempPath) == false)
            {
                using (File.Create(tempPath)) { };
                Console.WriteLine("Файл не найден, создан новый файл: " + tempPath);
            }
            bool isFileEmpty = string.IsNullOrEmpty(File.ReadAllText(tempPath));

            if (isFileEmpty)
            {
                Console.WriteLine("Файл с данными пуст, начните заполнять структуру");
                Console.Write("Введите наименование компании: ");
                company.Name = Console.ReadLine();

            }
            else
            {
                company = JsonDeserialize(tempPath);
                Console.WriteLine("Данные из базы прочитаны, компания: " + company.Name);
                Console.WriteLine("Для продолжения нажмите любую кравишу");
                Console.ReadKey();
                Console.Clear();
            }

            path = tempPath;

        }


        /// <summary>
        /// Серилизация в Json
        /// </summary>
        /// <param name="сompany">структура компании которую серилизуем</param>
        /// <param name="path">путь к файлу</param>
        internal static void JsonSerialize(Company сompany, string path)
        {
            string json = JsonConvert.SerializeObject(сompany);
            File.WriteAllText(path, json);
        }

        /// <summary>
        /// Десерилизация из json
        /// </summary>
        /// <param name="path">путь к файлу</param>
        /// <returns></returns>
        internal static Company JsonDeserialize(string path)
        {
            Company tempCompany = new Company();

            string json = File.ReadAllText(path);
            tempCompany = JsonConvert.DeserializeObject<Company>(json);

            return tempCompany;
        }
        /// <summary>
        /// Метод ввода Да/Нет
        /// </summary>
        /// <param name="text">Текстовое сообщение</param>
        /// <returns></returns>
        public static bool EnterYesNo(string text)
        {
            if (text != "") Console.WriteLine(text);
            ConsoleKeyInfo yn1;

            bool result = false;
            do
            {
                yn1 = Console.ReadKey(true);
                if (!(yn1.Key == ConsoleKey.Y || yn1.Key == ConsoleKey.N))
                {
                    Console.WriteLine("Не корректный ввод, попробуйте еще раз...");
                }
            } while (!(yn1.Key == ConsoleKey.Y || yn1.Key == ConsoleKey.N));

            if (yn1.Key == ConsoleKey.Y)
            {
                result = true;
            }
            else if (yn1.Key == ConsoleKey.N)
            {
                result = false;
            }
            return result;
        }

        /// <summary>
        /// Метод ввода положительного числа
        /// </summary>
        /// <returns></returns>
        internal static int InputNumber()
        {
            int number;
            bool isCorrectParse;
            do
            {
                isCorrectParse = int.TryParse(Console.ReadLine(), out number);
                if (isCorrectParse == false && number < 0)
                {
                    Console.WriteLine("Не корректный ввод, попробуйте еще раз...");
                }
            } while (isCorrectParse == false && number < 0);

            return number;
        }

        /// <summary>
        /// Записать репозиторий в файл
        /// </summary>
        /// <param name="company"></param>
        public static void SaveData(Company company, string path)
        {
            if (EnterYesNo("Хотите сохранить данные (Y/N):"))
            {
                JsonSerialize(company, path);
            }
            Console.WriteLine("");
        }
        /// <summary>
        /// Метод корректного ввода даты с проверкой Диапазона
        /// </summary>
        /// <returns></returns>
        public static DateTime InputDate(DateTime minValue, DateTime maxValue)
        {
            DateTime data; // date 
            string input;
            bool result;
            do
            {
                Console.Write("Введите дату в формате дд.ММ.гггг (день.месяц.год):");
                input = Console.ReadLine();
                result = DateTime.TryParseExact(input, "dd.MM.yyyy", null, DateTimeStyles.None, out data);
                if (data > maxValue || data < minValue)
                {
                    result = false;
                    Console.WriteLine("Не верно введена дата, повторите ввод");
                }
            }
            while (!result);

            return data;
        }
    }
}
