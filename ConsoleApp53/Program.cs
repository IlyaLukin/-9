using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace ConsoleApp53
{
    class Program
    {
        public static int Size(DoubleList beg)
        {
            int size = 0;
            while (beg.next != null)
            {
                beg = beg.next;
                size++;
            }
            return size;
        }

        public static DoubleList Add(int el, DoubleList beg)
        {
            DoubleList temp = new DoubleList(el);
            DoubleList t = beg;
            while (t.next != null) t = t.next;
            t.next = temp;
            temp.last = t;
            return beg;
        }

        public static DoubleList Create(int N, int i, DoubleList beg)
        {
            if (i <= N)
            {
                beg = Add(i, beg);
                i++;
                beg = Create(N, i++, beg);
                return beg;
            }
            else return beg;
        }

        public static void Research(DoubleList beg, int num, int count)
        {
            if (beg != null)
            {
                DoubleList temp = beg;
                if (temp.data == num)
                {
                    Console.WriteLine($"Элемент {temp.data} найден на {count} месте");
                }
                else if (temp.next != null)
                {
                    count++;
                    temp = temp.next;
                    Research(temp, num, count);
                }
                else if (temp.next == null)
                {
                    Console.WriteLine("Элемент не найден");
                }
            }
        }

        public static void Delete(DoubleList beg, int n)
        {
            if (beg != null)
            {
                DoubleList temp = beg;
                DoubleList k = beg;
                if ((temp.data == n) && (temp.next != null))
                {
                    k = temp.next;
                    k.last = null;
                    Console.WriteLine("Элемент удален");
                }
                else if ((temp.next != null) && (temp.next.next != null) && (temp.next.data == n))
                {
                    temp = temp.next = temp.next.next;
                    Console.WriteLine("Элемент удален");
                }
                else if ((temp.next != null) && (temp.next.next == null) && (temp.next.data == n))
                {
                    temp.next = null;
                    Console.WriteLine("Элемент удален");
                }
                else
                {
                    if (temp.next != null)
                    {
                        temp = temp.next;
                        Delete(temp, n);
                    }
                }
            }
        }

        public static void Show(DoubleList beg)
        {
            if (beg != null)
            {
                DoubleList temp = beg.next;
                Console.WriteLine(@"Список:");
                while (temp != null)
                {
                    Console.Write(temp + " ");
                    temp = temp.next;
                }
                Console.WriteLine();
            }
            else Console.WriteLine("Список пуст");
        }

        public static int ReadAnswer()
        {
            int el = 0;
            bool ok = true;
            do
            {
                try
                {
                    el = Int32.Parse(Console.ReadLine());
                    ok = true;
                    if (el < 1)
                    {
                        Console.WriteLine("Ошибка, количество элементов должно быть больше 0");
                        ok = false;
                    }
                }
                catch
                {
                    ok = false;
                    Console.WriteLine("Ошибка, введите целое число");
                }
            } while (!ok);
            return el;
        }
        public static int ReadAnswer1()
        {
            int el = 0;
            bool ok = true;
            do
            {
                try
                {
                    el = Int32.Parse(Console.ReadLine());
                    ok = true;
                }
                catch
                {
                    ok = false;
                    Console.WriteLine("Ошибка, введите целое число");
                }
            } while (!ok);
            return el;
        }

        static void Main(string[] args)
        {
            Console.WriteLine("Введите количество элементов списка:");
            int N = ReadAnswer();
            DoubleList b = new DoubleList();
            b = Create(N, 1, b);
            Show(b);
            Console.WriteLine("Введите значение элемента, который вы хотите найти:");
            int search = ReadAnswer1();
            Research(b, search, 0);
            int count = Size(b);
            Console.WriteLine("Введите значение элемента, который нужно удалить:");
            int del = ReadAnswer1();
            Delete(b, del);
            if (count == Size(b)) Console.WriteLine("Такого элемента нет в списке");
            Show(b);
            Console.ReadKey();

        }
    }
}
