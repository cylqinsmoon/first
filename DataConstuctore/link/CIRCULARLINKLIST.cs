using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace ConsoleApplication1
{
    class CIRCULARLINKLIST
    {
        //成员
        private int count;//记录元素个数
        private Node tail;//尾指针
        private Node currentPrev;//使用前驱结点来标识当前结点
        //循环链表的主要思想利用前驱结点指示当前结点，做到尾结点的前驱结点是头结点，从而实现循环
        //嵌套类，表示结点
        private class Node
        {
            public object item;//数据域
            public Node(object value)
            {
                item = value;
            }
            public CIRCULARLINKLIST.Node next;//指针域，指向后继结点
            public override string ToString()
            {
                return item.ToString();
            }
        }
        //属性
        //索引器
        public object this[int index]
        {
            get { return GetByIndex(index).item; }
            set { GetByIndex(index).item = value; }
        }
        public int Count
        {
            get { return count; }
        }
        //指示当前结点中的值
        public object Current
        {
            get { return currentPrev.next.item; }
        }
        //方法
        //查找指定索引的元素
        private Node GetByIndex(int index)
        {
            if ((index < 0) || (index >= this.count))
            {
                throw new ArgumentOutOfRangeException("索引超出范围");
            }
            Node temNode = this.tail;
            //从第一个嵌套类开始循环到第index个嵌套类处
            for (int i = 0; i < index; i++)
            {
                temNode = temNode.next;
            }
            return temNode;
        }
        //在链表结尾添加元素
        public void Add(object value)
        {
            Node newnode = new Node(value);
            //链表为空处理方式
            if (tail == null)
            {
                tail = newnode;
                currentPrev = newnode;
                tail.next = newnode;
            }
            else
            {
                newnode.next = tail.next;//新结点指针域指向头结点
                tail.next = newnode;//原尾结点指向新结点
                if (currentPrev == tail)//???判断意义，前驱结点不是一直等于尾结点吗？
                {
                    currentPrev = newnode;
                }
                tail = newnode;
            }
            count++;
        }
        //删除当前结点
        public void RemoveCurrentNode()
        {
            //链表为空
            if (tail == null)
            {
                throw new NullReferenceException("集合中没有任何元素");
            }
            //当只有一个元素时，删除后为空
            else if (count == 1)
            {
                tail = null;
                currentPrev = null;
            }
            else
            {
                //当删除的是尾指针所指向的结点时
                if (currentPrev.next == tail)//???
                {
                    tail = currentPrev;
                }
                currentPrev.next = currentPrev.next.next;
            }
            count--;
        }
        //移动当前结点
        public void Move(int step)
        {
            if (step < 0)
            {
                throw new ArgumentOutOfRangeException("移动步数不能小于零");
            }
            //表为空
            if (tail == null)
            {
                throw new NullReferenceException("集合中没有任何元素");
            }
            for (int i = 0; i < step; i++)
            {
                currentPrev = currentPrev.next;
            }
        }
        public override string ToString()
        {
            if (tail == null)
            {
                return string.Empty;
            }
            string s = "";
            Node temp = tail.next;
            for (int i = 0; i < count; i++)
            {
                s += temp.ToString() + " ";
                temp = temp.next;
            }
            return s;
        }
    }
}