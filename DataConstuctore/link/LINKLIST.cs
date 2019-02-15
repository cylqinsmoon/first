using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace ConsoleApplication1
{
    class LINKLIST
    {
        //成员
        private int count;//记录元素个数
        private Node head; //头指针
        //嵌套类，表示单个结点
        private class Node 
        {
            public object item; //数据域
            public LINKLIST.Node next; //指针域，指向后继结点
            public Node(object value)
            {
                item = value;
            }
            public  string PRINT()
            {
                return item.ToString();
            }
        }
        //属性
        //指示链表中元素个数
        public int Count
        {
            get { return count; }
        }
        //索引器
        public object this[int index]
        {
            get { return GetByIndex(index).item; }
            set { GetByIndex(index).item = value; }
        }
        //方法
        //查找指定索引的元素
        private Node GetByIndex(int index)
        {
            if ((index < 0) || (index >= this.count))
            {
                throw new ArgumentOutOfRangeException("索引超出范围");
            }
            Node temNode = this.head;
            //从第一个嵌套类开始循环到第index个嵌套类处
            for (int i = 0; i < index; i++) {
                temNode = temNode.next;
            }
            return temNode;
        }
        //在链表结尾添加元素
        public void Add(object value)
        {
            Node newNode = new Node(value);
            //链表为空的处理
            if (head == null)
            {
                head = newNode;
            }
            else {
                GetByIndex(count - 1).next = newNode;
            }
            count++;
        }
        //在指定索引处插入元素
        public void Insert( int index,object value)
        {
            Node tempNode;
            //在表头插入元素
            if (index == 0)
            {
                if (head == null)
                {
                    head = new Node(value);
                }
                else
                {
                    //不是数组，不需要做任何元素移动
                    tempNode = new Node(value);
                    tempNode.next = head;
                    head = tempNode;
                }
            }
            else
            {
                Node prevNode = GetByIndex(index - 1);//记录插入点前驱结点
                Node nextNode = prevNode.next;//记录后继结点
                tempNode = new Node(value);//新结点
                prevNode.next = tempNode;//建立新结点与前驱结点联系
                tempNode.next = nextNode;//建立新结点与后继结点联系
            }
            count++;
        }
        //删除指定索引元素
        public void RemoveAt(int index)
        {
            //删除表头元素
            if (index == 0)
            {
                head = head.next;
            }
            else
            {
                Node prevNode = GetByIndex(index - 1);
                if (prevNode.next == null)
                {
                    throw new ArgumentOutOfRangeException("索引超出范围");
                }
                prevNode.next = prevNode.next.next;//通过建立上个结点与下个结点之间的直接关系删除元素
            }
            count--;
        }
        //打印链表
        public  string PRINT()
        {
            string s = "";
            for (Node temp = head; temp != null; temp = temp.next)
            {
                s += temp.PRINT() + " ";
            }
            return s;
        }
    }
}
