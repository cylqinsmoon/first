using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Collections;

namespace StackAndQueue
{
    class Program
    {
        static void Main(string[] args)
        {
            Stack<char> stac = new Stack<char>();
            for (int i=0;i<26;i++)
            {
                stac.Push(Convert.ToChar('a' + i));
            }
            Console.WriteLine("stac包含元素个数："+stac.Count);           
            Console.WriteLine("stac依次出栈：");
            foreach (char str in stac)
            {
                Console.Write(str+" ");
            }
            Console.WriteLine();
            STACK stac2 = new STACK();
            Console.WriteLine("stac2初始容量："+stac2.Capacity);
            for (int i = 0; i < 26; i++)
            {
                stac2.Push(Convert.ToChar('A' + i));
            }
            Console.WriteLine("stac2包含元素个数："+stac2.Count+
                "; stac2容量："+stac2.Capacity);
            Console.WriteLine("stac2第10个元素为："+stac2[9]);
            Console.WriteLine("stac2依次出栈：");
            for (int i=0;i<26;i++)
            {
                Console.Write(stac2.Pop()+" ");
            }
            Queue que = new Queue();
            for (int i = 0; i < 26; i++)
            {
                que.Enqueue(Convert.ToChar('a' + i));
            }
            Console.WriteLine();
            Console.WriteLine("que包含元素个数:"+que.Count);
            Console.WriteLine("que依次出队：");
            for (int i = 0; i < 26; i++)
            {
                Console.Write(que.Dequeue() + " ");
            }
            Console.WriteLine();
            QUEUE que2 = new QUEUE(1,1);//可指定增长因子
            Console.WriteLine("que2包含元素个数："+que2.Count+"，容量为："+que2._Capacity);
            for (int i = 0; i < 33; i++)
            {
                que2.Enqueue(Convert.ToChar('A' + i));
            }
            Console.WriteLine("que2包含元素个数:" + que2.Count+",容量为："+que2._Capacity);
            Console.WriteLine("que2第十个元素为："+que2[9]);
            Console.WriteLine("que2依次出队：");
            for (int i = 0; i < 33; i++)
            {
                Console.Write(que2.Dequeue() + " ");
            }          
            Console.ReadKey();
        }
    }
}
