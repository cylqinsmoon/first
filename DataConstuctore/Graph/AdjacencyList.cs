using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Graph
{
    class AdjacencyList<T>
    {
        //嵌套类,表示存放于数组中的表头结点
        public class Vertex<TValue>
        {
            public TValue data;//数据
            public Node firstEdge;//邻接点链表头指针
            public Boolean visited;//访问标志，遍历时使用
            public Vertex(TValue value)//构造方法
            {
                data = value;
            }
        }
        //嵌套类,表示链表中的表结点
        public class Node
        {
            public Vertex<T> adjvex;//邻接点域
            public Node next;//下一个邻接点指针域
            public Node(Vertex<T> value)
            {
                adjvex = value;
            }
        }
        //成员
        List<Vertex<T>> items;//图的顶点集合
        //方法
        public AdjacencyList() : this(10) { }//构造方法
        public  AdjacencyList(int capacity)//指定容量的构造方法
        {
            items = new List<Vertex<T>>(capacity);
        }
        //查找图中是否包含某项
        public bool Contains(T item)
        {
            foreach(Vertex<T> v in items)
            {
                if(v.data.Equals(item))
                {
                    return true;
                }
            }
            return false;
        }
        //查找指定项并返回
        private Vertex<T> Find(T item)
        {
            foreach(Vertex<T> v in items)
            {
                if(v.data.Equals(item))
                {
                    return v;
                }
            }
            return null;
        }
        //添加一个顶点
        public void AddVertex(T item)
        {
            //不允许插入重复值
            if(Contains(item))
            {
                throw new ArgumentException("插入了重复的顶点！");
            }
            items.Add(new Vertex<T>(item));
        }
        //添加有向边
        private void AddDiretedEdge(Vertex<T> fromVer,Vertex<T> toVer)
        {
            if(fromVer.firstEdge==null)//无邻接点时
            {
                fromVer.firstEdge = new Node(toVer);
            }
            else
            {
                Node tmp, node = fromVer.firstEdge;
                do
                {
                    //检查是否添加了重复边
                    if (node.adjvex.data.Equals(toVer.data))
                    {
                        throw new ArgumentException("添加了重复的边！");
                    }
                    tmp = node;
                    node = node.next;
                } while (node != null);
                tmp.next = new Node(toVer);//添加到链表末尾
            }
        }
        //添加无向边
        public void AddEdge(T from,T to)
        {
            Vertex<T> fromVer = Find(from);//找到起始顶点
            if(fromVer==null)
            {
                throw new ArgumentException("头顶点并不存在！");
            }
            Vertex<T> toVer = Find(to);//找到结束顶点
            if(toVer==null)
            {
                throw new ArgumentException("尾顶点并不存在！");
            }
            //无向边的两个顶点都需记录边信息
            AddDiretedEdge(fromVer, toVer);
            AddDiretedEdge(toVer,fromVer);
        }
        //测试打印
        public override string ToString()
        {
            //打印每个顶点和它的邻接点
            string s = string.Empty;
            foreach(Vertex<T> v in items)
            {
                s += v.data.ToString() + ":";
                if(v.firstEdge!=null)
                {
                    Node tmp = v.firstEdge;
                    while(tmp!=null)
                    {
                        s += tmp.adjvex.data.ToString();
                        tmp = tmp.next;
                    }
                }
                s += "\r\n";
            }
            return s;
        }
        //初始化visited访问标志
        private void InitVisited()
        {
            foreach(Vertex<T> v in items)
            {
                v.visited = false;
            }
        }
        //使用递归进行深度优先遍历
        private void DFS(Vertex<T> v)
        {
            v.visited = true;
            Console.Write(v.data + " ");
            Node node = v.firstEdge;//访问顺序与添加边顺序有关，与添加的点顺序有关
            while(node!=null)
            {
                //如果邻接点未被访问，则递归访问它的边
                if(!node.adjvex.visited)
                {
                    DFS(node.adjvex);//递归
                }
                node = node.next;
            }
        }
        public void DFSTraverse()
        {
            InitVisited();//将visited标志全部设置为false
            //若图为非连通图，需访问不同的顶点
            foreach(Vertex<T> v in items)
            {
                if(!v.visited)//当visited为false表示未被访问
                {
                    DFS(v);
                }
            }
        }
        //使用队列进行广度优先遍历
        public void BFS(Vertex<T> v)
        {
            //创建一个队列
            Queue<Vertex<T>> queue = new Queue<Vertex<T>>();
            Console.Write(v.data + " ");
            v.visited = true;
            queue.Enqueue(v);
            while(queue.Count>0)//只要队列不为空就循环
            {
                Vertex<T> w = queue.Dequeue();
                Node node = w.firstEdge;
                while(node!=null)
                {
                    //如果邻接点未被访问，则递归访问它的边
                    if(!node.adjvex.visited)
                    {
                        Console.Write(node.adjvex.data + " ");
                        node.adjvex.visited = true;
                        queue.Enqueue(node.adjvex);
                    }
                    node = node.next;//访问下一个邻接点
                }
            }
        }
        //广度优先遍历
        public void BFSTraverse()
        {
            InitVisited();
            foreach(Vertex<T> v in items)
            {
                if(!v.visited)
                {
                    BFS(v);
                }
            }
        }
    }
}
