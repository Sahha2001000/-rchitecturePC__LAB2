using System;
using System.Text;
using System.IO;
using System.Collections.Generic;

namespace Vasyliev__lab2__task1__ipzr18k
{
    class Program
    {
        static void Main(string[] args)
        {
            string path = @"C:\Lab2VasylievOPIPZR18k";
            DirectoryInfo dirInfo = new DirectoryInfo(path);
            if (!dirInfo.Exists)
            {
                println("Каталог створено \'C:\\Lab2VasylievOPIPZR18k\' : ОК");
                dirInfo.Create();
            }

            print("Введите имя файла: ");
            Console.ForegroundColor = ConsoleColor.Magenta; // устанавливаем цвет
            string filename = Console.ReadLine();
            Console.ResetColor(); // сбрасываем в стандартный

            int countToDot = filename.LastIndexOf('.');
            try
            {
                string type = filename.Substring(countToDot);
                if (type == ".txt")
                {
                    string OK = "OK";
                    print("Проверка: ");
                    Console.ForegroundColor = ConsoleColor.Magenta; // устанавливаем цвет
                    print(OK);
                    Console.ResetColor(); // сбрасываем в стандартный
                    //Enter Filename --> exapmle <1.txt>

                    string pathToTXT = path + "\\" + filename;
                    FileInfo fileTXT = new FileInfo(pathToTXT);
                    using (StreamWriter stream = new StreamWriter(pathToTXT, true))
                    {
                        stream.WriteLine($"\nВведите имя файла: {filename}");
                        stream.WriteLine($"Проверка: OK");
                    }

                    if (!fileTXT.Exists)
                    {
                        println($"\nФайл {filename} створено: OK ");

                    }
                    println("");
                    print("Введите количество байтов (1-28): ");
                    Console.ForegroundColor = ConsoleColor.Magenta; // устанавливаем цвет
                    byte count = countByte();
                    Console.ResetColor(); // сбрасываем в стандартный

                    using (StreamWriter stream = new StreamWriter(pathToTXT, true))
                    {
                        stream.WriteLine($"Введите количество байтов (1-28): {count}");
                    }


                    List<byte> arrByteDEC = new List<byte>();
                    List<string> arrByteBIN__value = new List<string>();

                    string fileBytes = $"{path}\\Byte.txt";
                    using (StreamReader reader = new StreamReader(fileBytes))
                    {

                        // Чтение строки из StreamReader 
                        string dataFile = reader.ReadLine();
                        string[] nums = dataFile.Split(new char[] { ' ' });
                        byte countFileBytes = 0;
                        foreach (string n in nums)
                        {
                            countFileBytes++;
                        }
                        if (countFileBytes == count)
                        {
                            foreach (string n in nums)
                            {
                                byte k = Convert.ToByte(n);
                                arrByteDEC.Add(k);
                                string Bin = DecToBin(k);
                                arrByteBIN__value.Add(Bin);
                            }
                        }
                        else
                        {
                            println($"countFileBytes :{countFileBytes} != countByte: {count}");
                        }
                    }
                    Console.ForegroundColor = ConsoleColor.Blue; // устанавливаем цвет
                    println("Последовательность байт:");
                    Console.ResetColor(); // сбрасываем в стандартный
                    using (StreamWriter stream = new StreamWriter(pathToTXT, true))
                    {
                        stream.WriteLine($"Последовательность байт:");
                    }
                    for (int i = 0; i < arrByteDEC.Count; i++)
                    {
                        print(arrByteDEC[i] + " ");
                        using (StreamWriter stream = new StreamWriter(pathToTXT, true))
                        {
                            stream.Write($"{arrByteDEC[i]}" + " ");
                        }
                    }
                    println("");
                    Console.ForegroundColor = ConsoleColor.Blue; // устанавливаем цвет
                    println("Бинарная последовательность: ");
                    Console.ResetColor(); // сбрасываем в стандартный
                    using (StreamWriter stream = new StreamWriter(pathToTXT, true))
                    {
                        stream.WriteLine($"\nБинарная последовательность: ");
                    }
                    for (int i = 0; i < arrByteBIN__value.Count; i++)
                    {
                        print(arrByteBIN__value[i] + " ");
                        using (StreamWriter stream = new StreamWriter(pathToTXT, true))
                        {
                            stream.Write($"{arrByteBIN__value[i]}" + " ");
                        }
                    }

                    List<int> arrByteDEC__2LEFTSHIFT = new List<int>();
                    List<string> arrByteBIN__2LEFTSHIFT = new List<string>();
                    int max2lf__value = 0;
                    int max2lf__index = 0;
                    for (byte i = 0; i < arrByteDEC.Count; i++)
                    {
                        byte tmp = arrByteDEC[i];
                        int num_2lf = tmp << 2;
                        arrByteDEC__2LEFTSHIFT.Add(num_2lf);
                        string num_2lf__bin = DecToBin(num_2lf);
                        arrByteBIN__2LEFTSHIFT.Add(num_2lf__bin);
                        if (max2lf__value < num_2lf)
                        {
                            max2lf__index = i;
                            max2lf__value = num_2lf;

                        }

                    }
                    println("");
                    Console.ForegroundColor = ConsoleColor.Blue; // устанавливаем цвет
                    println("Сдвиг влево <- на 2 бита: ");
                    using (StreamWriter stream = new StreamWriter(pathToTXT, true))
                    {
                        stream.WriteLine($"\nСдвиг влево <- на 2 бита:");
                    }

                    Console.ResetColor(); // сбрасываем в стандартный
                    List<int> indexMAX = new List<int>();

                    for (int i = 0; i < arrByteBIN__2LEFTSHIFT.Count; i++)
                    {
                        int tmp = arrByteDEC__2LEFTSHIFT[i];
                        if (tmp == max2lf__value)
                        {
                            Console.ForegroundColor = ConsoleColor.Red;
                            print($"{arrByteBIN__2LEFTSHIFT[i]}" + " ");
                            Console.ResetColor(); // сбрасываем в стандартный
                            indexMAX.Add(i);
                            int maxbin = i;
                        }
                        else
                        {
                            print($"{arrByteBIN__2LEFTSHIFT[i]}" + " ");
                        }
                        using (StreamWriter stream = new StreamWriter(pathToTXT, true))
                        {
                            stream.Write($"{arrByteBIN__2LEFTSHIFT[i]}" + " ");
                        }
                    }

                    println("");
                    print("Максимальный байт: ");
                    Console.ForegroundColor = ConsoleColor.Red; // устанавливаем цвет
                    print(arrByteBIN__2LEFTSHIFT[max2lf__index] + " ");
                    Console.ForegroundColor = ConsoleColor.DarkMagenta;
                    print(Convert.ToString(max2lf__value));
                    Console.ResetColor(); // сбрасываем в стандартный

                    println(" ");
                    print($"Количество: ");
                    print($"{indexMAX.Count}");
                    using (StreamWriter stream = new StreamWriter(pathToTXT, true))
                    {
                        stream.WriteLine($"\nМаксимальный байт: {arrByteBIN__2LEFTSHIFT[max2lf__index]}  {max2lf__value}");
                        stream.WriteLine($"Количество: {indexMAX.Count}");
                    }
                    Console.ReadLine();
                }
            }
            catch (System.ArgumentOutOfRangeException)
            {
                string pathToTXT = path + "\\" + filename + ".txt";
                FileInfo fileTXT = new FileInfo(pathToTXT);
                print("Проверка: ");
                Console.ForegroundColor = ConsoleColor.Magenta; // устанавливаем цвет
                print("NOT OK");
                Console.ResetColor(); // сбрасываем в стандартный
                using (StreamWriter stream = new StreamWriter(pathToTXT, true))
                {
                    //Enter Filename --> exapmle <1.txt>
                    stream.WriteLine($"\nВведите имя файла: {filename}");

                    stream.WriteLine($"Проверка: NOT OK");
                }
                Console.ReadLine();
            }
        }
        // func
        static void print(string str)
        {
            Console.Write(str);
        }
        static void println(string str)
        {
            Console.WriteLine(str);
        }

        static byte inputByte()
        {
            byte number = Convert.ToByte(Console.ReadLine());
            return number;
        }
        static byte countByte()
        {
            byte countByte = inputByte();
            if (countByte >= 1 && countByte <= 28)
            {
                return countByte;
            }
            else if (countByte > 28)
            {
                countByte = 28;
                return countByte;
            }
            else
            {
                countByte = 7;
                return countByte;
            }
        }
        static string DecToBin(byte number)
        {
            string Bin = Convert.ToString(number, 2).PadLeft(8, '0');
            return Bin;
        }
        static string DecToBin(int number)
        {
            string Bin = Convert.ToString(number, 2).PadLeft(8, '0');
            return Bin;
        }
    }
}
