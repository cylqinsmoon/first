using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Tree
{
    class Node
    {
        //成员变量
        private object _data;//数据
        private Node _left;//左子树
        private Node _right;//右子树
        public object Data
        {
            get { return _data; }
        }
        public Node Left
        {
            get { return _left; }
            set { _left = value; }
        }
        public Node Right
        {
            get { return _right; }
            set { _right = value; }
        }
        //构造方法
        public Node(object data)
        {
            _data = data;
        }
        public override string ToString()
        {
            return _data.ToString();
        }
    }
}
