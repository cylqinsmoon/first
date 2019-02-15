using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace ConsoleApplication1
{
    class ARRAYLIST
    {
        //��Ա����
        private const int _defaultCapacity = 1;//Ĭ�ϳ�ʼ����
        private object[] _items;
        private int _size;//ָʾ��ǰԪ�ظ���
        //����
        public virtual int Capacity {//ָʾARRAYLIST�Ĵ洢�ռ�
            get {
                return this._items.Length; 
            }
            set {
                if (value != this._items.Length)
                {
                    if (value < this._size)
                    {
                        throw new ArgumentOutOfRangeException("����̫С");
                    }
                    if (value > 0)
                    {
                        //����һ���µ��ڴ�ռ�洢Ԫ��
                        object[] destinationArray = new object[value];
                        if (this._size > 0)
                        {
                            //��Ԫ�ذ�Ǩ���µĿռ���
                            Array.Copy(this._items, 0, destinationArray, 0, this._size);
                        }
                        this._items = destinationArray;
                    }
                    else //��С�ռ�Ϊ_defaultCapacity��ָ������Ŀ
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
        //������
        public virtual object this[int index] {
            //��ȡָ��������Ԫ��ֵ
            get {
                if ((index < 0) || (index >= this._size))
                {
                    throw new ArgumentOutOfRangeException("����������Χ");
                }
                return this._items[index];
            }
            //����ָ��������Ԫ��ֵ
            set {
                if ((index < 0) || (index >= this._size))
                {
                    throw new ArgumentOutOfRangeException("����������Χ");
                }
                this._items[index] = value;
            }
        }
        //Ԫ�ظ���Ϊ��ʱ������״̬
        private static readonly object[] emptyArray = new object[0];//ֻ������
        //����
        public ARRAYLIST()//Ĭ�Ϲ��췽��
        { //����Ԫ�ظ���Ϊ��ʱ���ʳ���
            this._items = emptyArray;
        }
        //ָ��ARRAYLIST��ʼ�����Ĺ��췽��
        public ARRAYLIST(int capacity) {
            if (capacity < 0)
            {
                //����������Ϊ����ʱ�����쳣
                throw new ArgumentOutOfRangeException("ARRAYLIST����������Ϊ��ֵ");
            }
            //����capacity����ָ���ĳ��ȵ�ֵ��ʼ������
            this._items = new object[capacity];
        }
        //���Ԫ�ط���
        public virtual int Add(object value) {
            //���ռ���ʱ
            if (this._size == this._items.Length) {
                //�����ռ�
                this.EnsureCapacity(this._size + 1);
            }
            this._items[this._size] = value;//���Ԫ��
            return this._size++;//ʹ���ȼ�һ
        }
        //��̬��������Ŀռ�
        private void EnsureCapacity(int min) {
            if (this._items.Length < min) {
                //�ռ��1
                int num = (this._items.Length == 0) ? 
                    _defaultCapacity : (this._items.Length + 1);
                if (num < min) {
                    num = min;
                }
                //����Capacity��set����������num��ֵ��������ռ�
                this.Capacity = num; 
            }
        }
        //��ָ������������ָ��Ԫ��
        public virtual void Insert(int index, object value) {
            if ((index < 0) || (index > this._size)) {
                //ע�����������ã���������Ԫ�ظ�����ֻ������ԭԪ�ذ��Ųſɺ��Ʋ���
                throw new ArgumentOutOfRangeException("����������Χ");
            }
            if (this._size == this._items.Length) {
                //���ռ���ʱ�����ռ�
                this.EnsureCapacity(this._size + 1);
            }
            if (index < this._size) {
                //������������Ԫ������ƶ�һλ
                Array.Copy(this._items, index, this._items, index + 1, this._size - index);
            }
            this._items[index] = value;//����ָ��λ�ø�ֵ
            this._size++;//���鳤�ȼ�һ
        }
        //�Ƴ�ָ��������Ԫ��
        public virtual void RemoveAt(int index) {
            if ((index < 0) || (index >= this._size))
            {
                throw new ArgumentOutOfRangeException("����������Χ");
            }
            this._size--;//ʹ���ȼ�һ
            if (index < this._size) {
                //ʹ��ɾ��Ԫ�غ������Ԫ����ǰ��һλ
                Array.Copy(this._items,index+1,this._items,index,this._size-index);
            }
            this._items[this._size] = null;//���һλ�ճ���Ԫ���ÿ�
            this.TrimToSize();
        }
        //�ü��ռ䣬ʹ�洢�ռ������ʺ�Ԫ�ظ���
        public virtual void TrimToSize() {
            this.Capacity = this._size;
        }
    }
}
