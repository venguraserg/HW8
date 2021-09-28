

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
    public static class ConsoleIO
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
                // меню департамента
                case 1:
                    {
                        bool comeBack = false;
                        do
                        {
                            Console.Clear();
                            Console.WriteLine("Меню \"Департамент:\"");
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
                                    var tempName = Console.ReadLine();
                                    if(company.DepartmentsList.Where(i => i.Name == tempName).ToList<Department>().Count == 0)
                                    {
                                        Guid tempId = Guid.NewGuid();
                                        while (company.DepartmentsList.Where(e => e.IdDepartment == tempId).ToList<Department>().Count!=0)
                                        {
                                            tempId = Guid.NewGuid();
                                        }
                                        company.AddDepartment(new Department(tempId,tempName));
                                        if (EnterYesNo("Департамент создан, сохранить изменения в файл БД (Y/N)")) { SaveData(company, path); }
                                    }
                                    else
                                    { 
                                        Console.WriteLine("Департамент с таким именем существует");
                                    }
                                    Console.WriteLine("Для продолжения нажмите любую клавишу. . .");
                                    Console.ReadKey(true);

                                    break;
                                //Удаление департамента
                                case 3:
                                    Console.Clear();
                                    int index = GetIndexDepartment(company);
                                    if (index >= 0)
                                    {
                                        company.RemoveDepartment(index);
                                        if (EnterYesNo("Департамент удален, сохранить изменения в файл БД (Y/N)")) { SaveData(company, path); }
                                    }
                                    else
                                    {
                                        Console.WriteLine("Не верный ввод. . .");
                                    }
                                    Console.WriteLine("Для продолжения нажмите любую клавишу. . .");
                                    Console.ReadKey(true);
                                    break;

                                // Редактировать департамент
                                case 4:
                                    Console.Clear();
                                    index = GetIndexDepartment(company);

                                    if (index >= 0)
                                    {
                                        Guid id = company.DepartmentsList[index].IdDepartment;
                                        string newName = company.DepartmentsList[index].Name;
                                        DateTime newCreateDate = company.DepartmentsList[index].CreateDate;
                                        


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

                                        company.EditDepartment(new Department(id, newName, newCreateDate), index);
                                        if (EnterYesNo("Данные изменены, сохранить изменения в файл БД (Y/N)")) { SaveData(company, path); }

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
                // Меню сотрудников
                case 2:
                    {
                        bool comeBack = false;
                        do
                        {
                            Console.Clear();
                            Console.WriteLine("Меню \"Сотрудник\"");
                            Console.WriteLine("1. Посмотреть список ВСЕХ сотрудников");
                            Console.WriteLine("2. Добавить сотрудника");
                            Console.WriteLine("3. Удалить сотрудника");
                            Console.WriteLine("4. Редактировать сотрудника");
                            Console.WriteLine("5. Назад");

                            switch (InputNumber())
                            {
                                //просмотр списка всех сотрудников
                                case 1:
                                    Console.Clear();
                                    Console.WriteLine("Список всех сотрудников: ");
                                    PrintAllEmployees(company);
                                    Console.WriteLine("Для продолжения нажмите любую клавишу. . .");
                                    Console.ReadKey(true);
                                    break;

                                //добавление нового сотрудника
                                case 2:
                                    Console.Clear();
                                    Console.WriteLine("Добавление сотрудника: ");
                                    Console.Write("Введите фамилию: ");
                                    string tempName = Console.ReadLine();
                                    Console.Write("Введите имя: ");
                                    string tempSurname = Console.ReadLine();
                                    Console.Write("Введите возраст: ");
                                    int tempAge = InputNumber();
                                    Console.Write("Выберите департамент: ");
                                    Guid tempId = ChoiseDepartment(company);
                                    if (tempId == Guid.Empty) Console.WriteLine("Депатрамент не выбран, поле будет \"Без департамента\"");
                                    Console.Write("Введите заработную плату: ");
                                    if(!double.TryParse(Console.ReadLine(),out double tempSalary))
                                    {
                                        tempSalary = 0;
                                        Console.WriteLine("Не верный ввод, зарплата будет установлена по уморчанию - 0, \nИзменить можно при редактировании");
                                    }
                                    

                                    Employee tempEmployee = new Employee(tempSurname, tempName, tempAge, tempId, tempSalary);
                                    company.AddEmployee(tempEmployee);

                                    if (EnterYesNo("Сотрудник создан, сохранить в файл БД (Y/N)")) { SaveData(company, path); }
                                    Console.WriteLine("Для продолжения нажмите любую клавишу. . .");
                                    Console.ReadKey(true);
                                    break;
                                
                                //Удаление сотрудника
                                case 3:
                                    Console.Clear();
                                    int index = GetIndexEmployee(company);
                                    if (index >= 0 && index <= company.EmployeeList.Count - 1)
                                    {
                                        company.RemoveEmployee(index);
                                        if (EnterYesNo("Cотрудник удален, сохранить изменения в файл БД (Y/N)")) { SaveData(company, path); }
                                    }
                                    else
                                    {
                                        Console.WriteLine("Не верный ввод. . .");
                                    }
                                    Console.WriteLine("Для продолжения нажмите любую клавишу. . .");
                                    Console.ReadKey(true);
                                    break;

                                //Редактирование сотрудника
                                case 4:
                                    Console.Clear();
                                    index = GetIndexEmployee(company);

                                    if (index >= 0)
                                    {
                                        Guid newId = company.EmployeeList[index].Id;
                                        string newName = company.EmployeeList[index].Name;
                                        if (EnterYesNo($"Имя сотрудника - {company.EmployeeList[index].Name}, желаете изменить? (Y/N)"))
                                        {
                                            Console.Write("Введите новое имя: ");
                                            newName = Console.ReadLine();
                                        }

                                        string newSurname = company.EmployeeList[index].Surname;
                                        if (EnterYesNo($"Фамилия сотрудника - {company.EmployeeList[index].Surname}, желаете изменить? (Y/N)"))
                                        {
                                            Console.Write("Введите новую фамилию: ");
                                            newSurname = Console.ReadLine();
                                        }

                                        int newAge = company.EmployeeList[index].Age;
                                        if (EnterYesNo($"Возраст сотрудника - {company.EmployeeList[index].Age}, желаете изменить? (Y/N)"))
                                        {
                                            Console.Write("Введите новый возраст: ");
                                            newAge = InputNumber();
                                        }
                                        
                                        Guid newIdDep = company.EmployeeList[index].IdDepartment;
                                        if (EnterYesNo($"Текущий департамент - {company.GetNameDepartment(newIdDep)}, желаете изменить? (Y/N)"))
                                        {
                                            Console.Write("Выберите новый департамент: ");
                                            do
                                            {
                                                newIdDep = ChoiseDepartment(company);
                                                if (newIdDep == Guid.Empty)
                                                {
                                                    Console.WriteLine("Не верный ввод, повторите. . .");
                                                }

                                            } while (newIdDep == Guid.Empty);

                                        }

                                        double newSalary = company.EmployeeList[index].Salary;
                                        if (EnterYesNo($"Зарплата сотрудника - {company.EmployeeList[index].Salary}, желаете изменить? (Y/N)"))
                                        {
                                            Console.Write("Введите новую зарплату: ");
                                            bool correctParse = false;
                                            do
                                            {
                                                correctParse = double.TryParse(Console.ReadLine(), out newSalary);
                                                if (correctParse == false)
                                                {
                                                    Console.WriteLine("Не верный ввод, повторите. . .");
                                                }

                                            } while (!correctParse);

                                        }

                                        company.EditEmployee(new Employee(newId, newSurname, newName, newAge, newIdDep, newSalary), index);
                                        if (EnterYesNo("Данные изменены, сохранить изменения в файл БД (Y/N)")) { SaveData(company, path); }

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
                case 3:
                    if (EnterYesNo("Cохранить данные? (Y/N)")) { SaveData(company, path); }
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
        /// Выбор Департамента
        /// </summary>
        /// <param name="company"></param>
        /// <returns></returns>
        private static Guid ChoiseDepartment(Company company)
        {
            
            Console.WriteLine("Выберите департамент: ");
            PrintDepartment(company);
            var number = InputNumber();
            if(number <= company.DepartmentsList.Count || number<1)
            {
                return company.DepartmentsList[number - 1].IdDepartment;
            }
            return Guid.Empty;

            
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
        /// Выбор Сотрудника по индексу
        /// </summary>
        /// <param name="company"></param>
        /// <returns></returns>
        private static int GetIndexEmployee(Company company)
        {
            Console.WriteLine("Список департаментов: ");
            PrintAllEmployees(company);
            
            
            Console.WriteLine("Введите индекс");
            int index = InputNumber() - 1;
            
            return index > company.EmployeeList.Count ? -1 : index;
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
        /// Вывод списка Всех сотрудников
        /// </summary>
        /// <param name="company"></param>
        private static void PrintAllEmployees(Company company)
        {
            if (company.EmployeeList.Count == 0)
            {
                Console.WriteLine("Записей нет. . .");
            }
            else
            {
                Console.WriteLine("");
                for (int i = 0; i < company.EmployeeList.Count; i++)
                {
                    Console.WriteLine($"#{i + 1} - {company.EmployeeList[i]} департамент - {company.GetNameDepartment(company.EmployeeList[i].IdDepartment)}");
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
                company.AddDepartment(new Department());

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
            
             JsonSerialize(company, path);
            
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
