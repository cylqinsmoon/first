using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace StackAndQueue
{
    class QUEUE
    {
        //成员
        private object[] _array;//存放元素的数组
        private int _growFactor;//增长因子
        private int _head;//队头指针
        private const int _MinimumGrow = 4;//最小增长值
        private const int _ShrinkThreshold = 0x20;//初始容量  16进制的20,即10进制的32
        private int _size;//指示元素个数
        private int _tail;//队尾指针
        public int _Capacity=_ShrinkThreshold;//指示队列容量
        //属性
        //指示元素个数
        public virtual int Count
        {
            get
            {
                return this._size;
            }
        }
        //方法
        //构造方法
        public QUEUE(int capacity, float growFactor)
        {
            //capacity参数指定初始容量，growFactor参数指定增长因子
            if (capacity < 0)
            {
                throw new ArgumentOutOfRangeException("初始容量不能小于0");
            }
            if ((growFactor < 1.0) || (growFactor > 10.0))
            {
                //增长因子必须在1到10之间
                throw new ArgumentOutOfRangeException("增长因子必须在1到10之间");
            }
            this._array = new object[capacity];//初始化数组
            this._head = 0;
            this._tail = 0;
            this._size = 0;
            this._growFactor = (int)(growFactor * 100f);
        }
        public QUEUE() : this(_ShrinkThreshold, 2f)
        {
        }
        //内存搬家
        private void SetCapacity(int capacity)
        {
            //建立新的数组
            object[] destinationArray = new object[capacity];
            if (this._head < this._tail)
            {
                //当头指针在尾指针前面时
                Array.Copy(this._array, this._head, destinationArray, 0, this._size);
            }
            else//当头指针在尾指针后面时
            {
                Array.Copy(this._array,this._head,destinationArray,0,this._array.Length-this._head);
                Array.Copy(this._array,0,destinationArray,this._array.Length-this._head,this._tail);
            }
            this._array = destinationArray;
            this._head = 0;
            this._tail = (this._size == capacity) ? 0 : this._size;
        }
        //入队
        public virtual void Enqueue(object obj)
        {
            //当数组满员
            if(this._size==this._array.Length)
            {
                //计算新容量
                int capacity = (int)((this._array.Length * this._growFactor) / 100L);
                if (capacity < (this._array.Length + _MinimumGrow))
                {
                    capacity = this._array.Length + _MinimumGrow;
                }
                //调整容量
                this.SetCapacity(capacity);
                this._Capacity = capacity;
            }
            this._array[this._tail] = obj;
            this._tail = (this._tail + 1) % this._array.Length;
            this._size++;           
        }
        public virtual object Dequeue()
        {
            if (this._size == 0)
            {
                throw new ArgumentOutOfRangeException("队列为空");
            }
            object obj2 = this._array[this._head];
            this._array[this._head] = null;
            this._head = (this._head + 1) % this._array.Length;
            this._size--;
            return obj2;
        }
        //索引器
        public virtual object this[int index]
        {
            //获取指定索引的元素值
            get
            {
                if ((index < 0) || (index >= this._size))
                {
                    throw new ArgumentOutOfRangeException("索引超出范围");
                }
                return this._array[index];
            }
            //设置指定索引的元素值
            set
            {
                if ((index < 0) || (index >= this._size))
                {
                    throw new ArgumentOutOfRangeException("索引超出范围");
                }
                this._array[index] = value;
            }
        }
    }
}
