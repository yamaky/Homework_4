using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.IO;

namespace homework_4
{
    class Program
    {
        static void Main(string[] args)
        {
            //Задание 1
            var dirName = @"C:\Program Files\";

            DirectoryInfo startDirectory = new DirectoryInfo(dirName);
            IterateDirectory(startDirectory, 0);

            Console.Read();
            Console.Clear();

            //Задание 2
            string notebook = @"C:\Users\arazr\OneDrive\Рабочий стол\C#\Блокнот";
            DirectoryInfo dirInfo = new DirectoryInfo(notebook);
            if (!dirInfo.Exists)
            {
                dirInfo.Create();
            }
            Console.WriteLine("Созраненные файлы:");
            List<string> teams = new List<string>(); // создание списка
            int i = 0;
            foreach (var item in dirInfo.GetFiles())
            {
                teams.Add(item.Name);//добавление элемента ;
                Console.WriteLine(item.Name);
                i += 1;
            }
            if (i == 0)
                Console.WriteLine("В данной папке пока нет файлов.");
            Console.WriteLine("Хотите создать новую заметку? Да/Нет");
            string str = Console.ReadLine();
            Console.Clear();
            switch (str)
            {
                case "Да":
                case "да":
                    Console.WriteLine("Введите имя файла");
                    string name = Console.ReadLine();
                    //получить доступ к  существующему файлу, либо создать новый
                    DirectoryInfo dirInfoNew = new DirectoryInfo(name);
                    StreamWriter fileNext = new StreamWriter($@"C:\Users\arazr\OneDrive\Рабочий стол\C#\Блокнот\{name}.txt");
                    teams.Add(dirInfoNew.Name);
                    i += 1;
                    //записать в него
                    Console.WriteLine("Введите содержимое файла:");
                    fileNext.Write(Console.ReadLine());
                    //закрыть для сохранения данных
                    fileNext.Close();
                    Console.ReadLine();
                    Console.Clear();
                    //i += 1;
                    break;
                case "Нет":
                case "нет":
                    Console.WriteLine("Хотите редактировать заметку? Да/Нет");
                    string str1 = Console.ReadLine();

                    switch(str1)
                    {
                        case "Да":
                        case "да":
                            Console.WriteLine("Введите имя файла");
                            string Rename = Console.ReadLine();
                            //получить доступ к  существующему файлу, либо создать новый
                            DirectoryInfo RedirInfo = new DirectoryInfo(Rename);
                            Console.WriteLine("Хотите 1 - перезаписать или 2 - дополнить заметку? ");
                            string q = Console.ReadLine();
                            Console.WriteLine("Введите содержимое файла:");
                            string text = Console.ReadLine();
                            switch (q)
                            {
                                case "1":
                                    StreamWriter Newfile = new StreamWriter($@"C:\Users\arazr\OneDrive\Рабочий стол\C#\Блокнот\{Rename}.txt", false);
                                    Newfile.WriteLine(text);
                                    Newfile.Close();
                                    Console.ReadLine();
                                    Console.Clear();
                                    break;
                                case "2":
                                    StreamWriter Refile = new StreamWriter($@"C:\Users\arazr\OneDrive\Рабочий стол\C#\Блокнот\{Rename}.txt", true);
                                    Refile.WriteLine(text);
                                    Refile.Close();
                                    Console.ReadLine();
                                    Console.Clear();
                                    break;

                            }
                            break;
                        case "Нет":
                        case "нет":
                            Console.WriteLine("Данные последней заметки:");
                            //получить доступ к  существующему файлу, либо создать новый
                            StreamReader file = new StreamReader($@"C:\Users\arazr\OneDrive\Рабочий стол\C#\Блокнот\{teams[i - 1]}");
                            //записать в него
                            Console.WriteLine(file.ReadToEnd()); //считываем все данные с потока и выводим на экран
                            //закрыть для сохранения данных
                            file.Close();
                            Console.ReadLine();
                            Console.Clear();
                            break;
                    }


                    //Console.ReadLine();
                    break;
            }
            
            // Console.ReadLine();
        }

        private static void IterateDirectory(DirectoryInfo info, int level)
        {
            var indent = new string('\t', level);
            Console.WriteLine(indent + info.Name);
            var subDirectories = info.GetDirectories();
            foreach (var item in info.GetFiles())
            {
                Console.WriteLine(item.Name);
            }

            foreach (var subDir in subDirectories)
            {
                IterateDirectory(subDir, level + 1);
                Console.ReadLine();
            }
        }
    }
}
