using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Collections;

namespace Graph
{
    class Program
    {
        static void Main(string[] args)
        {
            AdjacencyList<int> graph1 = new AdjacencyList<int>();
            //添加顶点
            graph1.AddVertex(1);
            graph1.AddVertex(2);
            graph1.AddVertex(3);
            graph1.AddVertex(4);
            graph1.AddVertex(5);
            graph1.AddVertex(6);
            graph1.AddVertex(10);
            graph1.AddVertex(7);
            graph1.AddVertex(8);
            graph1.AddVertex(9);          
            //添加边
            graph1.AddEdge(1, 2);  
            graph1.AddEdge(1, 4);
            graph1.AddEdge(1, 3);
            graph1.AddEdge(4, 6);           
            graph1.AddEdge(3, 5);
            graph1.AddEdge(10, 8);
            graph1.AddEdge(10,7);
            graph1.AddEdge(8,9);           
            Console.WriteLine("graph1结构为：");
            Console.WriteLine(graph1.ToString());
            Console.WriteLine("深度优先遍历graph1:");
            graph1.DFSTraverse();
            Console.WriteLine();
            Console.WriteLine("广度优先遍历graph1：");
            graph1.BFSTraverse();
            int[,] LJmini = new int[6, 6];
            LJmini[0, 1] = 1;
            LJmini[0, 3] = 3;
            LJmini[3, 4] = 2;
            LJmini[0, 4] = 5;
            LJmini[0, 5] = 5;
            LJmini[1, 2] = 3;
            LJmini[1, 5] = 2;                      
            Console.WriteLine();
            Dijkstra(LJmini, 0);
            Floyd(LJmini);
            Console.ReadKey();
        }
        static void Dijkstra(int[,] cost,int v)//cost为邻接矩阵，v为源点
        {
            int n = cost.GetLength(1);//顶点个数.即Array指定维度数
            int[] s = new int[n];//集合S
            int[] dist = new int[n];//结果集
            int[] path = new int[n];//存放路径
            for (int i = 0; i < n; i++)
            {
                //结果集初始化，将邻接矩阵源点所表示的行数据加进dist集合
                dist[i] = cost[v, i];
                if(cost[v,i]>0)//路径初始化
                {
                    //如果某顶点与源点存在边
                    path[i] = v;
                }
                else//如果某顶点与源点不存在边
                {
                    //它的前一顶点值设为-1
                    path[i] = -1; 
                }
            }
            s[v] = 1;//将抽取出的顶点加进集合S
            path[v] = 0;
            for(int i=0; i<n;i++)
            {
                int u = 0, mindis = int.MaxValue;
                //u表示剩余顶点在dist集合中的最小值所在索引
                for(int j=0;j<n;j++)//寻找dist集合中的最小值
                {
                    if(s[j]==0&&dist[j]>0&&dist[j]<mindis)
                    {
                        u = j;
                        mindis = dist[j];
                    }
                }
                s[u] = 1;//将抽取出来的顶点放入集合S中
                for(int j=0;j<n;j++)
                {
                    if(s[j]==0)//如果顶点不在集合S中
                    {
                        //加入的顶点与其顶点存在边，并且新计算的值小于原值
                        if (cost[u, j] > 0 && (dist[j] == 0 ||
                            dist[u] + cost[u, j] < dist[j]))
                        {
                            //用更小的值代替原值
                            dist[j] = dist[u] + cost[u, j];
                            path[j] = u;//记录加入点路径上的前一顶点
                        }
                    }
                }
            }
            //打印源点到各顶点的路径及距离
            for (int i = 0; i < n; i++)
            {
                if(s[i]==1)
                {
                    Console.Write("从{0}到{1}的最短路径为：", v, i);
                    Console.Write(v + "→");
                    GetPath(path, i, v);
                    Console.Write(i);
                    Console.WriteLine("    路径长度为："+dist[i]);
                }
            }
        }
        static void GetPath(int[] path, int i, int v)
        {
            int k = path[i];
            if (k == v)
            {
                return;
            }
            GetPath(path, k, v);
            Console.Write(k + "→");
        }
        static void Floyd(int[,] cost)
        {
            int n = cost.GetLength(1);//图中顶点个数
            int[,] A = new int[n, n];//存放最短路径长度
            int[,] path = new int[n, n];//存放最短路径信息
            for(int i=0;i<n;i++)
            {
                for(int j=0; j<n;j++)
                {
                    //辅助数组A和path的初始化
                    A[i, j] = cost[i, j];
                    path[i, j] = -1;
                }
            }
            //弗洛伊德算法核心代码
            for(int k=0;k<n;k++)
            {
                for(int i=0;i<n;i++)
                {
                    for(int j=0;j<n;j++)
                    {//如果存在通过中间点k的路径
                        if (i!=j&&A[i,k]!=0&&A[k,j]!=0)
                        {//如果加入中间点k的路径更短
                            if (A[i, j] == 0 || A[i,j]>A[i,k]+A[k,j])
                            {//用新路径代替原路径
                                A[i, j] = A[i, k] + A[k, j];
                                path[i, j] = k;
                            }
                        }
                    }
                }
                //打印最短路径及路径长度
                for(int i=0;i < n;i++)
                {
                    for(int j=0; j<n;j++)
                    {
                        if(A[i,j]==0)
                        {
                            if(i!=j)
                            {
                                Console.WriteLine("从{0}到{1}没有路径",i,j);
                            }
                        }
                        else
                        {
                            Console.Write("从{0}到{1}的路径为：", i, j);
                            Console.Write(i + "→");
                            GetPath2(path, i, j);
                            Console.WriteLine(j);
                            Console.WriteLine("     路径长度为："+A[i,j]);
                        }
                    }
                    Console.WriteLine();
                }
            }
        }
        static void GetPath2(int[,] path,int i,int j)
        {
            int k = path[i, j];
            if(k==-1)
            {
                return;
            }
            GetPath2(path, i, k);
            Console.Write(k + "→");
            GetPath2(path, k, j);
        }
        
    }
}
