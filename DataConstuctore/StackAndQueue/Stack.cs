using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace StackAndQueue
{
    class STACK
    {
        //成员
        private object[] _array;//存放元素的数组
        private const int _defaultCapacity = 0;//默认空间
        private int _size;//指示元素个数
        public int Capacity=_defaultCapacity;//指示数组容量
        //属性
        //元素个数
        public virtual int Count
        {
            get
            {
                return this._size;
            }
        }
        //方法
        public STACK()
        {
            this._array = new object[_defaultCapacity];
            this._size = 0;
        }
        public STACK(int initialCapacity)
        {
            if (initialCapacity < 0)
            {
                throw new ArgumentOutOfRangeException("栈空间不能小于零");
            }
            //栈空间不能小于defaultCapacity的值
            if (initialCapacity < _defaultCapacity)
            {
                initialCapacity = _defaultCapacity;
            }
            this._array = new object[initialCapacity];//分配栈空间
            this._size = 0;
        }
        //出栈
        public virtual object Pop()
        {
            if (this._size == 0)
            {
                throw new InvalidOperationException("栈内已无数据");
            }
            object obj2 = this._array[--this._size];//取出栈顶元素
            this._array[this._size] = null;//删除栈顶元素
            return obj2;
        }
        //进栈
        public virtual void Push(object obj)
        {
            //如果空间已满使用新的空间
            if (this._size == this._array.Length)
            {
                //调整空间
                object[] destionationArray = new object[this._array.Length+1];
                Array.Copy(this._array, 0, destionationArray, 0, this._size);
                this._array = destionationArray;
            }
            this._array[this._size++] = obj;
            Capacity = this._array.Length;
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
