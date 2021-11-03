﻿using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace ConsoleApp1
{
    class Program
    {
        static char[,] ZeroTable(char[,] a, int size_x, int size_y)
        {
            for (int i = 0; i < size_x; i++)
                for (int j = 0; j < size_y; j++)
                    a[i, j] = '.';
            return a;
        }
        static void PrintTable(char[,] a, int size_x, int size_y)
        {
            for (int i = 0; i < size_x; i++)
            {
                for (int j = 0; j < size_y; j++)
                    Console.Write(a[i, j]);
                Console.WriteLine();
            }
        }
        static bool CheckPlay(char[,] a, int size_x, int size_y)
        {
            if ((a[0, 0] != '.') & (a[0, 0] == a[0, 1]) & (a[0, 0] == a[0, 2]))
                return false;
            if ((a[0, 0] != '.') & (a[0, 0] == a[1, 1]) & (a[0, 0] == a[2, 2]))
                return false;
            if ((a[1, 0] != '.') & (a[1, 0] == a[1, 1]) & (a[1, 0] == a[1, 2]))
                return false;
            if ((a[2, 0] != '.') & (a[2, 0] == a[2, 1]) & (a[2, 0] == a[2, 2]))
                return false;
            if ((a[0, 0] != '.') & (a[0, 0] == a[1, 0]) & (a[0, 0] == a[2, 0]))
                return false;
            if ((a[0, 1] != '.') & (a[0, 1] == a[1, 1]) & (a[0, 1] == a[2, 1]))
                return false;
            if ((a[0, 2] != '.') & (a[0, 2] == a[1, 2]) & (a[0, 2] == a[2, 2]))
                return false;
            if ((a[2, 0] != '.') & (a[2, 0] == a[1, 1]) & (a[2, 0] == a[0, 2]))
                return false;
            return true;
        }
        static bool CheckPeace(char[,] a, int size_x, int size_y)
        {
            for (int i = 0; i < size_x; i++)
                for (int j = 0; j < size_y; j++)
                    if (a[i, j] == '.')
                        return false;
            return true;
        }
        static int hod(string a)
        {
            Console.Write(a);
            bool parsed = int.TryParse(Console.ReadLine(), out int x);
            while (!parsed)
            {
                Console.Write(a);
                parsed = int.TryParse(Console.ReadLine(), out x);
            }
            return x;
        }
        static bool Checkhod(char[,] a, int size_x, int size_y, int a1, int a2)
        {
            int x = a1 - 1;
            int y = a2 - 1;
            if ((x > size_x) ^ (x < 0) ^ (y > size_y) ^ (y < 0))
                return false;
            else
            {
                if (a[x, y] == '.')
                    return true;
                else
                    return false;
            }
        }
        static char CharRand(int a)
        {
            if (a == 0)
                return 'o';
            else
                return 'x';
        }
        static char[,] AddHod(char[,] a, int size_x, int size_y, int a1, int a2, char t)
        {
            a[a1, a2] = t;
            return a;
        }
        static string CheckPlayer(int a)
        {
            if (a == 1)
                return "Крестиков";
            else
                return "Ноликов";
        }
        static void Main()
        {
            char[,] table = new char[3, 3];
            table = ZeroTable(table, 3, 3);
            var rand = new Random().Next(0, 2);
            Console.WriteLine("Игровое поле изначально.");
            PrintTable(table, 3, 3);

            var flag = CheckPlay(table, 3, 3);
            while (flag)
            {
                Console.WriteLine($"Ход {CheckPlayer(rand)}: ");
                int x = hod(" Введите - координату: ");
                int y = hod(" Введите | координату: ");
                while (!Checkhod(table, 3, 3, x, y))
                {
                    Console.WriteLine("Неверные координаты: ");
                    x = hod(" Введите - координату: ");
                    y = hod(" Введите | координату: ");
                }
                AddHod(table, 3, 3, x - 1, y - 1, CharRand(rand));
                Console.WriteLine();
                Console.WriteLine("Игровое поле после хода.");
                PrintTable(table, 3, 3);
                if (!CheckPlay(table, 3, 3))
                    flag = false;
                else
                {
                    if (CheckPeace(table, 3, 3))
                        flag = false;
                    else
                        rand = (rand + 1) % 2;
                }
            }
            Console.WriteLine($"Победа {CheckPlayer(rand)}");
        }
    }
}