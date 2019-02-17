using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Collections;

namespace Tree
{
    class BinaryTree
    {
        //成员变量
        private Node _head;//头指针
        private string cStr;//用于构造二叉树的字符串
        public Node Head
        {
            get { return _head; }
        }
        //构造方法
        public BinaryTree(string constructStr)
        {
            cStr = constructStr;//保存构造字符串
            //实际存储的信息只有一个头节点的指针
            _head = new Node(cStr[0]);//添加头结点
            Add(_head, 0);
        }
        private void Add(Node parent,int index)
        {
            int leftIndex = 2 * index + 1;//计算左孩子索引
            if(leftIndex<cStr.Length)//如果索引没有超过字符串长度
            {
                if(cStr[leftIndex]!='#')
                {
                    //添加左孩子
                    parent.Left = new Node(cStr[leftIndex]);
                    //递归调用Add方法给左孩子添加孩子结点
                    Add(parent.Left, leftIndex);
                }
            }
            int rightIndex = 2 * index + 2;//计算有孩子索引
            if (rightIndex < cStr.Length)
            {
                if (cStr[rightIndex]!='#')
                {
                    parent.Right = new Node(cStr[rightIndex]);
                    Add(parent.Right, rightIndex);
                }
            }
        }
        //先序遍历
        public void PreOrder(Node node)
        {

            //if(node!=null)
            //{
            //    Console.Write(node);
            //    PreOrder(node.Left);
            //    PreOrder(node.Right);
            //}
            Stack<Node> stack = new Stack<Node>();
            Node currentNode = node;
            Node tmp;
            while (currentNode != null || !(stack.Count == 0))
            {
                while (currentNode != null)//一直往一个方向走
                {
                    Console.Write(currentNode.Data + " ");
                    stack.Push(currentNode);
                    currentNode = currentNode.Left;
                }
                if (!(stack.Count == 0))//变换方向
                {
                    tmp = stack.Pop();
                    currentNode = tmp.Right;
                }
            }

        }
        //中序遍历
        public void MidOrder(Node node)
        {
            if(node!=null)
            {
                MidOrder(node.Left);
                Console.Write(node);
                MidOrder(node.Right);
            }
        }
        //后序遍历
        public void AfterOrder(Node node)
        {
            if(node!=null)
            {
                AfterOrder(node.Left);
                AfterOrder(node.Right);
                Console.Write(node);
            }
        }
        //广度优先遍历
        public void LevelOrder()
        {
            Queue queue = new Queue();
            queue.Enqueue(_head);//把根结点压入队列
            while(queue.Count>0)
            {
                Node node = (Node)queue.Dequeue();//出队
                Console.Write(node);
                if(node.Left!=null)
                {
                    queue.Enqueue(node.Left);
                }
                if(node.Right!=null)
                {
                    queue.Enqueue(node.Right);
                }
            }
        }
    }
}
