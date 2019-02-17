using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Tree
{
    class Program
    {
        static void Main(string[] args)
        {
            BinaryTree bTree = new BinaryTree("xvbc[#;a#RE##U");
            Console.Write("先序遍历:");
            bTree.PreOrder(bTree.Head);
            Console.WriteLine();
            Console.Write("中序遍历:");
            bTree.MidOrder(bTree.Head);
            Console.WriteLine();
            Console.Write("后序遍历：");
            bTree.AfterOrder(bTree.Head);
            Console.WriteLine();
            Console.Write("广度优先遍历：");
            bTree.LevelOrder();          
            Console.ReadKey();
        }
    }
}
