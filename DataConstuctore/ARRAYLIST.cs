using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace ConsoleApplication1
{
    class ARRAYLIST
    {
        //成员变量
        private const int _defaultCapacity = 1;//默认初始容量
        private object[] _items;
        private int _size;//指示当前元素个数
        //属性
        public virtual int Capacity {//指示ARRAYLIST的存储空间
            get {
                return this._items.Length; 
            }
            set {
                if (value != this._items.Length)
                {
                    if (value < this._size)
                    {
                        throw new ArgumentOutOfRangeException("容量太小");
                    }
                    if (value > 0)
                    {
                        //开辟一块新的内存空间存储元素
                        object[] destinationArray = new object[value];
                        if (this._size > 0)
                        {
                            //把元素搬迁到新的空间内
                            Array.Copy(this._items, 0, destinationArray, 0, this._size);
                        }
                        this._items = destinationArray;
                    }
                    else //最小空间为_defaultCapacity所指定的数目
                    {
                        this._items = new object[_defaultCapacity];
                    }
                }
            }
        }
        public virtual int Count {
            get {
                return this._size;
            }
        }
        //索引器
        public virtual object this[int index] {
            //获取指定索引的元素值
            get {
                if ((index < 0) || (index >= this._size))
                {
                    throw new ArgumentOutOfRangeException("索引超出范围");
                }
                return this._items[index];
            }
            //设置指定索引的元素值
            set {
                if ((index < 0) || (index >= this._size))
                {
                    throw new ArgumentOutOfRangeException("索引超出范围");
                }
                this._items[index] = value;
            }
        }
        //元素个数为零时的数组状态
        private static readonly object[] emptyArray = new object[0];//只读数组
        //方法
        public ARRAYLIST()//默认构造方法
        { //避免元素个数为零时访问出错
            this._items = emptyArray;
        }
        //指定ARRAYLIST初始容量的构造方法
        public ARRAYLIST(int capacity) {
            if (capacity < 0)
            {
                //当容量参数为负数时引发异常
                throw new ArgumentOutOfRangeException("ARRAYLIST的容量不能为负值");
            }
            //按照capacity参数指定的长度的值初始化数组
            this._items = new object[capacity];
        }
        //添加元素方法
        public virtual int Add(object value) {
            //当空间满时
            if (this._size == this._items.Length) {
                //调整空间
                this.EnsureCapacity(this._size + 1);
            }
            this._items[this._size] = value;//添加元素
            return this._size++;//使长度加一
        }
        //动态调整数组的空间
        private void EnsureCapacity(int min) {
            if (this._items.Length < min) {
                //空间加1
                int num = (this._items.Length == 0) ? 
                    _defaultCapacity : (this._items.Length + 1);
                if (num < min) {
                    num = min;
                }
                //调用Capacity的set访问器按照num的值调整数组空间
                this.Capacity = num; 
            }
        }
        //在指定索引处插入指定元素
        public virtual void Insert(int index, object value) {
            if ((index < 0) || (index > this._size)) {
                //注意条件的设置，索引大于元素个数，只有在与原元素挨着才可后移插入
                throw new ArgumentOutOfRangeException("索引超出范围");
            }
            if (this._size == this._items.Length) {
                //当空间满时调整空间
                this.EnsureCapacity(this._size + 1);
            }
            if (index < this._size) {
                //插入点后面所有元素向后移动一位
                Array.Copy(this._items, index, this._items, index + 1, this._size - index);
            }
            this._items[index] = value;//数组指定位置赋值
            this._size++;//数组长度加一
        }
        //移除指定索引的元素
        public virtual void RemoveAt(int index) {
            if ((index < 0) || (index >= this._size))
            {
                throw new ArgumentOutOfRangeException("索引超出范围");
            }
            this._size--;//使长度减一
            if (index < this._size) {
                //使被删除元素后的所有元素向前移一位
                Array.Copy(this._items,index+1,this._items,index,this._size-index);
            }
            this._items[this._size] = null;//最后一位空出的元素置空
            this.TrimToSize();
        }
        //裁剪空间，使存储空间正好适合元素个数
        public virtual void TrimToSize() {
            this.Capacity = this._size;
        }
    }
}
