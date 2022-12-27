using System;
using static System.Net.Mime.MediaTypeNames;

namespace HexViewer
{
    internal class Program
    {
        static void Main(string[] args)
        {
            string n;
            char[] hex = { 'A', 'B', 'C', 'D', 'E', 'F' };
            n = System.IO.File.ReadAllText("Text.txt");

            int numOct = 0;
            int num = 16;
            int numrem = 0;
            for (int i = 0; i < n.Length; i++)
            {

                //inainte de WriteLine scriem cele 16 octeti 
                if (i % 16 == 0 && i != 0)
                {
                    Console.Write("  | ");
                    Console.WriteLine("{0}{1}{2}{3}{4}{5}{6}{7}{8}{9}{10}{11}{12}{13}{14}{15}", n[i - 16],n[i - 15], n[i - 14], n[i - 13], n[i - 12], n[i - 11], n[i - 10], n[i - 9], n[i - 8], n[i - 7], n[i - 6], n[i - 5], n[i - 4], n[i - 3], n[i - 2], n[i - 1]);
                    numrem = 0;
                }

                //la inceputul fiecarui rand scriem 
                if (i % 16 == 0)
                {
                    int num1 = num;
                    convLine(num1, hex);
                    num += 16;
                    Console.Write(": ");
                }

                //formatare dupa 8 octeti
                if (numOct % 8 == 0 && i % 16 !=0)
                    Console.Write("| ");

                //convertare caractere in baza 16
                convChar(n[i], hex);
                numrem++;

                //daca nu sunt destule caractere pentru terminarea randului cu 16 octeti, face programul manual
                if (i == n.Length - 1 && numrem!=16)
                {
                    Console.Write("  | ");
                    while (numrem>0)
                    {
                        Console.Write(n[i - numrem + 1]);
                        numrem--;
                    }
                }
                numOct++;
            }
        }
        static void convLine(int num1, char[] hex)
        {
            char[] newLine = { '0', '0', '0', '0', '0', '0', '0', '0' };
            int i = 7;

            while (num1 > 0)
            {
                int x = num1 % 16;
                if (x > 9)
                    newLine[i] = hex[x % 10];
                else newLine[i] = (char) (x + 48);
                i--;
                num1 /= 16;
            }

            Console.Write(newLine);
        }

        static void convChar(char s, char[] hex)
        {
            int n = (int)s;
            if (n < 32 || n > 127)
                Console.Write("2E ");
            else
            {
                int x, y;

                x = n % 16;
                n /= 16;
                y = n % 16;

                if (y > 9)
                    Console.Write(hex[y % 10]);
                else Console.Write(y);
                if (x > 9)
                    Console.Write(hex[x % 10]);
                else Console.Write(x);
                Console.Write(" ");
            }
        }

    }
}