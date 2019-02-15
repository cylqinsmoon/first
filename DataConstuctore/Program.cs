using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Collections;
using System.Collections.Specialized;

namespace ConsoleApplication1
{
    class Program
    {
        static void Main(string[] args)
        {
            ArrayList arr = new ArrayList();
            //arr容量不足便会翻倍，故容量为2的倍数
            Console.WriteLine("arr容量为：" + arr.Capacity + "  包含元素个数为：" + arr.Count);
            for (int i = 0; i < 26; i++)
            {
                arr.Add(Convert.ToChar('a' + i));
            }
            int j = 0;
            foreach (char letter in arr)
            {
                Console.Write(letter);
                if (j < 25)
                {
                    j++;
                    Console.Write(",");
                }
                else
                    Console.WriteLine();
            }
            Console.WriteLine("arr容量为：" + arr.Capacity + "  包含元素个数为：" + arr.Count);
            for (int i = 0; i < 11; i++)
            {
                arr.RemoveAt(0);//永远只删除索引号为0的数组上的数字
            }
            int l = 0;
            foreach (char letter in arr)
            {
                Console.Write(letter);
                if (l < 14)
                {
                    l++;
                    Console.Write(",");
                }
                else
                    Console.WriteLine();
            }
            Console.WriteLine("arr容量为：" + arr.Capacity + "  包含元素个数为：" + arr.Count);
            arr.TrimToSize();
            Console.WriteLine("arr容量为：" + arr.Capacity + "  包含元素个数为：" + arr.Count);
            ARRAYLIST ARR = new ARRAYLIST();
            Console.WriteLine("ARR容量为：" + ARR.Capacity + "  包含元素个数为：" + ARR.Count);
            ARR.Add(2018);
            Console.WriteLine(ARR[0]);
            Console.WriteLine("ARR容量为：" + ARR.Capacity + "  包含元素个数为：" + ARR.Count);
            for (int i = 0; i < 26; i++)
            {
                ARR.Add(Convert.ToChar('A' + i));
            }
            //foreach (char letter in ARR)
            //{
            //    Console.Write(letter);
            //    if (j < 25)
            //    {
            //        j++;
            //        Console.Write(",");
            //    }
            //}
            int k = 0;
            for (int i = 0; i < 26; i++)
            {
                Console.Write(ARR[i]);
                if (k < 25)
                {
                    k++;
                    Console.Write(",");
                }
                else
                {
                    Console.WriteLine();
                }
            }
            Console.WriteLine("ARR容量为：" + ARR.Capacity + "  包含元素个数为：" + ARR.Count);
            for (int i = 0; i < 11; i++)
            {
                ARR.RemoveAt(0);
            }
            int m = 0;
            for (int i = 0; i < 16; i++)
            {
                Console.Write(ARR[i]);
                if (m < 15)
                {
                    m++;
                    Console.Write(",");
                }
                else
                {
                    Console.WriteLine();
                }
            }
            Console.WriteLine("ARR容量为：" + ARR.Capacity + "  包含元素个数为：" + ARR.Count);
            LINKLIST lst = new LINKLIST();
            lst.Add(2018);
            for (int i = 0; i < 26; i++)
            {
                lst.Add(Convert.ToChar('a' + i));
            }
            Console.WriteLine("lst全部元素： " + lst.PRINT() + ", 包含元素个数：" + lst.Count);
            Console.WriteLine("第六个元素为： " + lst[5]);
            for (int i = 0; i <= 5; i++)
            {
                lst.RemoveAt(1);
            }
            Console.WriteLine("lst删去a-f后： " + lst.PRINT() + ", 包含元素个数：" + lst.Count);
            for (int i = 0; i < 10; i++)
            {
                lst.Insert(18 + i, Convert.ToChar('!' + i));
            }
            Console.WriteLine("lst在x后插入十个符号： " + lst.PRINT() + ", 包含元素个数：" + lst.Count);
            ListDictionary lst2 = new ListDictionary();
            for (int i = 0; i < 26; i++)
            {
                lst2.Add(i, Convert.ToChar('A' + i));
                
            }
            Console.Write("lst2所有元素：");
            int n2 = 0;
            for (int i = 0; i < 26; i++)
            {
                Console.Write(lst2[i]);
                if (n2 < 25)
                {
                    n2++;
                    Console.Write(",");
                }
            }
            Console.WriteLine(" 。lst2共有元素个数："+lst2.Count);
            CIRCULARLINKLIST clst = new CIRCULARLINKLIST();
            for (int i = 0; i < 26; i++)
            {
                clst.Add(Convert.ToChar('A' + i));

            }
            Console.WriteLine("clst中所有元素："+clst.ToString()+".包含元素个数："+clst.Count);
            Console.WriteLine("clst索引号为〇的元素："+clst[0]);
            string s = string.Empty;
            Console.WriteLine("请输入要循环出的位置：");
            int wz = int.Parse(Console.ReadLine());
            while (clst.Count > 1)
            {
                clst.Move(wz);
                s += clst.Current.ToString() + " ";
                clst.RemoveCurrentNode();
                Console.Write("\r\n剩余："+clst.ToString());
            }
            Console.WriteLine("\r\n出队顺序："+s+clst.Current);
            Console.ReadKey();
        }
    }
}
