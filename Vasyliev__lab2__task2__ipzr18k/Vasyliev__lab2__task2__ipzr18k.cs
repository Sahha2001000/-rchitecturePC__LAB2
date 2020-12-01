using System;
using System.Text;
using System.IO;
using System.Collections.Generic;
using System.Linq;

namespace Vasyliev__lab2__task2__ipzr18k
{
    class Program
    {
        static void Main(string[] args)
        {
            //Input user DEC numbers
            print("Enter number 1: ");
            byte num__1 = inputByte(input());
            print("Enter number 2: ");
            byte num__2 = inputByte(input());
            println($"\nNumber decimal 1: {num__1}.\nNumber decimal 2: {num__2}");
            //DEC transoform BIN
            string bin__1 = DecToBin(num__1);
            string bin__2 = DecToBin(num__2);
            println($"\nNumber binary 1: {bin__1}.\nNumber binary 2: {bin__2}\n");

            // BIN1 + BIN2 = BIN__16Byte
            string bin = bin__1 + bin__2;
            // BIN__16Byte array char from string
            char[] BIN__16Byte = bin.ToCharArray();
            // tmp str to num
            List<int> charKey01 = new List<int>();
            // arrBin int to byte
            byte[] arrBin = new byte[16];

            // arr chars append list <int>
            foreach (char c in BIN__16Byte)
            {
                int key = Convert.ToInt32(c);
                charKey01.Add(key);
            }
            // Keys char from int transofrm to byte 1,0
            for (int k = 0; k < charKey01.Count; k++)
            {
                if (charKey01[k] == 49)
                {
                    arrBin[k] = 1;
                }
                else
                {
                    arrBin[k] = 0;
                }
            }
            println("Два бинарных числа в одном бинарном массиве размерности 16:");
            // 10 and 11 element shpw red
            for (int k = 0; k < arrBin.Length; k++)
            {
                if (k == 10 || k == 11)
                {
                    Console.ForegroundColor = ConsoleColor.Red; // устанавливаем цвет
                    print(arrBin[k]);
                    Console.ResetColor(); // сбрасываем в стандартный
                }
                else
                {
                    print(arrBin[k]);
                }
            }
            println(" ");
            byte[] arrBin__shift1 = new byte[16];
            Array.Copy(arrBin, arrBin__shift1, 16);
            // 10 and 11 element show red
            for (int i = 0; i < arrBin.Length - 1; i++)
            {
                if (i == 10 || i == 11)
                {
                    arrBin[i] = arrBin__shift1[i];
                }
                else
                {
                    byte tmp = arrBin[i];
                    arrBin[i] = arrBin[i + 1];
                    arrBin[i + 1] = tmp;
                }
            }
            println("\nЦиклический сдвиг влево на 1 в массиве, при этом элементы 10 и 11 оставить на месте: ");
            for (int k = 0; k < arrBin.Length; k++)
            {
                if (k == 10 || k == 11)
                {
                    Console.ForegroundColor = ConsoleColor.Red; // устанавливаем цвет
                    print(arrBin[k]);
                    Console.ResetColor(); // сбрасываем в стандартный
                }
                else
                {
                    print(arrBin[k]);
                }
            }

            byte[] bin1__new = new byte[9];
            byte[] bin2__new = new byte[9];


            int f = 0;
            int j = 0;
            for (int k = 0; k < arrBin.Length; k++)
            {
                if (f < 9)
                {
                    bin1__new[f] = arrBin[k];
                    f++;
                }
                else if (f >= 9)
                {
                    bin2__new[j] = arrBin[k];
                    j++;
                }
            }

            List<string> n1 = new List<string>();
            List<string> n2 = new List<string>();

            println($"\n\nБинарное число 1: {num__1} после циклического сдвига влево на 1");
            for (int k = 0; k < bin1__new.Length - 1; k++)
            {
                print(bin1__new[k]);
                n1.Add(Convert.ToString(bin1__new[k]));
            }
            println($"\nБинарное число 2: {num__2} после циклического сдвига влево на 1");
            for (int k = 0; k < bin2__new.Length - 1; k++)
            {
                print(bin2__new[k]);
                n2.Add(Convert.ToString(bin2__new[k]));
            }
            print("\n\n");
            string bin__str_1 = string.Join("", n1);
            string bin__str_2 = string.Join("", n2);

            int num__1shift = Convert.ToInt32(bin__str_1, 2);
            int num__2shift = Convert.ToInt32(bin__str_2, 2);
            int multiplication = num__1shift * num__2shift;
            string binCount = DecToBin(multiplication);
            char[] numFormat = binCount.ToArray();
           
            println("Умножение байтов друг на друга с циклическим сдвигом влево на 1 в сдвигом влево на 1: ");
            println("<<Бинарный вид>>\n");

            for (int i = 0; i < numFormat.Length; i++)
            {
                if (i % 8 == 0)
                {
                    print(" " + numFormat[i]);
                }
                else
                {
                    print(numFormat[i] + "");
                }

            }

            println("\nУмножение байтов друг на друга с циклическим сдвигом влево на 1 в сдвигом влево на 1: ");
            println("<<Десятичный вид>>");
            println($"{multiplication}");

            println("Для выхода нажмите ENTER......");
            Console.ReadLine();
        }
        // func
        static void print(string str)
        {
            Console.Write(str);
        }

        static void print(int str)
        {
            Console.Write(str);
        }
        static void println(string str)
        {
            Console.WriteLine(str);
        }
   
        static int input()
        {
            int number = Convert.ToInt32(Console.ReadLine());
            return number;
        }
        static byte MOD__256(int number)
        {
            while (number > 256)
            {
                number %= 256;
            }
            return Convert.ToByte(number);
        }
        static byte inputByte(int num)
        {
            if (num > 256)
            {
                num = MOD__256(num);
                return Convert.ToByte(num);
            }
            else if (num < 0)
            {
                num = 130;
                return Convert.ToByte(num);
            }
            else
            {
                return Convert.ToByte(num);
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
