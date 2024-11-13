using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace task8
{
    internal class Program
    {
        public class MyVector<T>
        {
            public T[] elementData; // Массив для хранения элементов вектора
            public int elementCount; // Количество элементов в векторе
            public int capacityIncrement; // Значение, на которое увеличивается ёмкость вектора

            public MyVector(int initialCapacity, int capacityIncrement)
            {
                if (initialCapacity < 0) throw new ArgumentOutOfRangeException("initialCapacity");
                elementData = new T[capacityIncrement];
                elementCount = 0;
                this.capacityIncrement = initialCapacity;
            }

            public MyVector(int initialCapacity)
            {
                if (initialCapacity < 0) throw new ArgumentNullException("vector");
                capacityIncrement = 0;
                elementData = new T[capacityIncrement];
            }

            public MyVector()
            {
                int initialCapacity = 10;
                capacityIncrement = 0;
                elementData = new T[initialCapacity];

            }


            public MyVector(T[] a)
            {
                if (a == null) throw new ArgumentNullException("vector");
                elementData = new T[a.Length];
                Array.Copy(a, elementData, a.Length);
                elementCount = a.Length;
                capacityIncrement = 0;
            }

            public void EnsureCapacity(int minCapacity)
            {
                int newCapacity;
                if (elementData.Length < minCapacity)
                {
                    if (capacityIncrement > 0) newCapacity = elementData.Length + capacityIncrement;
                    else newCapacity = elementData.Length * 2;
                    if (newCapacity < minCapacity) newCapacity = minCapacity;
                    T[] newVector = new T[newCapacity];
                    Array.Copy(elementData, newVector, elementCount);
                    elementData = newVector;
                }

            }


            public void Add(T e)
            {
                EnsureCapacity(elementCount + 1);
                elementData[elementCount++] = e;

            }

            public void addAll(T[] a)
            {
                if (a == null) throw new ArgumentNullException("vector");
                EnsureCapacity(elementCount + a.Length);
                Array.Copy(a, 0, elementData, elementCount, a.Length);
                elementCount += a.Length;
            }

            public void Clear()
            {
                Array.Clear(elementData, 0, elementCount);
                elementCount = 0;
            }


            //(object o)
            //HashSet<T> set = new HashSet<T>(elementData);
            //if(!set.Contains(e))
            //    return -1;
            public int IndexOf(object o)
            {

                if (o == null)
                {
                    for (int i = 0; i < elementCount; i++)
                    {
                        if (elementData[i] == null) return i;

                    }
                }
                else
                {
                    for (int i = 0; i < elementCount; i++)
                    {
                        if (o.Equals(elementData[i])) return i;

                    }
                }
                return -1;
            }

            public bool Contains(object o)
            {
                return IndexOf(o) >= 0;
            }

            public bool ContainsAll(T[] a)
            {
                if (a == null) throw new ArgumentNullException("vector");
                foreach (var i in a)
                {
                    if (!Contains(i)) return false;

                }
                return true;
            }

            public bool IsEmpty()
            {
                return elementCount == 0;
            }


            public void RemoveAt(int ind)
            {
                if (ind >= elementCount || ind < 0) throw new ArgumentOutOfRangeException("index");
                elementCount--;
                if (ind < elementCount) Array.Copy(elementData, ind + 1, elementData, ind, elementCount - ind);
            }

            public void Remove(object o)
            {
                int ind = IndexOf(o);
                if (ind >= 0)
                {
                    RemoveAt(ind);
                }
            }

            public void RemoveAll(T[] a)
            {
                if (a == null) throw new ArgumentNullException("vector");
                foreach (var i in a)
                {
                    Remove(i);
                }
            }

            public void RetainAll(T[] a)
            {
                if (a == null) throw new ArgumentNullException("vector");
                for (int i = 0; i < elementCount;)
                {
                    if (Array.IndexOf(a, elementData[i]) < 0)
                    {
                        RemoveAt(i);
                    }
                    else
                    {
                        i++;
                    }
                }
            }

            public int Size()
            {
                return elementCount;
            }


            public T[] ToArray()
            {
                T[] values = new T[elementCount];
                Array.Copy(elementData, values, elementCount);
                return values;
            }

            public T[] ToArray(T[] a)
            {
                if (a == null)
                {
                    return ToArray();
                }
                else
                {
                    if (a.Length < elementCount)
                    {
                        T[] values = new T[elementCount];
                        Array.Copy(elementData, values, a.Length);
                        return values;
                    }
                    else
                    {
                        Array.Copy(elementData, 0, a, 0, elementCount);
                        if (a.Length > elementCount) a[elementCount] = default(T);
                        return a;
                    }

                }
            }
            public void Add(int index, T e)
            {
                if (index < 0 || index > elementCount) throw new ArgumentOutOfRangeException("index");
                EnsureCapacity(elementCount + 1);
                Array.Copy(elementData, index, elementData, index + 1, elementCount - index);
                elementData[index] = e;
                elementCount++;
            }

            public void AddAll(int index, T[] a)
            {
                if (a == null)
                {
                    throw new ArgumentNullException("a");
                }
                if (index < 0 || index > elementCount) throw new ArgumentOutOfRangeException("index");

                EnsureCapacity(elementCount + a.Length);
                Array.Copy(elementData, index, elementData, index + a.Length, elementCount - index);
                Array.Copy(a, 0, elementData, index, a.Length);
                elementCount += a.Length;
            }
            public T Get(int index)
            {
                if (index < 0 || index > elementCount) throw new ArgumentOutOfRangeException("index");
                return elementData[index];

            }

            public int LastIndexOf(object o)
            {
                if ((object)o == null) throw new ArgumentNullException("o");

                if (o == null)
                {
                    for (int i = elementCount - 1; i >= 0; i--)
                    {
                        if (elementData[i] == null) return i;

                    }
                }
                else
                {
                    for (int i = elementCount - 1; i >= 0; i--)
                    {
                        if (o.Equals(elementData[i])) return i;

                    }
                }
                return -1;

            }

            public T Remove(int index)
            {
                if (index < 0 || index > elementCount) throw new ArgumentOutOfRangeException("index");
                T element = elementData[index];
                Remove(element);
                return element;
            }

            public void Set(int index, T e)
            {
                if (index < 0 || index > elementCount) throw new ArgumentOutOfRangeException("index");
                elementData[index] = e;
            }

            public MyVector<T> SubList(int fromIndex, int toIndex)
            {
                if (fromIndex < 0 || toIndex > elementCount || fromIndex > toIndex) throw new ArgumentOutOfRangeException("index");
                T[] subArray = new T[toIndex - fromIndex];
                Array.Copy(elementData, fromIndex, subArray, 0, toIndex - fromIndex);
                return new MyVector<T>(subArray);
            }




            public T FirstElement()
            {
                if (elementCount <= 0) throw new ArgumentOutOfRangeException("vector");
                return elementData[0];
            }


            public T LastElement()
            {
                if (elementCount <= 0) throw new ArgumentOutOfRangeException("vector");
                return elementData[elementCount - 1];
            }


            public void RemoveElementAt(int ind)
            {
                if (ind >= elementCount || ind < 0) throw new ArgumentOutOfRangeException("index");
                elementCount--;
                if (ind < elementCount) Array.Copy(elementData, ind + 1, elementData, ind, elementCount - ind);
            }

            public void RemoveRange(int begin, int end)
            {
                if (begin < 0 || end > elementCount || begin > end) throw new ArgumentOutOfRangeException("index");
                Array.Copy(elementData, end + 1, elementData, begin, elementCount - (end + 1));
                elementCount -= end - begin;
                Array.Clear(elementData, elementCount, end - begin);
            }

        }

        public class MyStack<T> : MyVector<T>
        {

            public void Push(T item)
            {
                Add(item);
            }

            public T Pop()
            {
                if (IsEmpty()) throw new InvalidOperationException("stack is empty");
                T item = elementData[elementCount - 1];
                RemoveAt(elementCount - 1);
                return item;
            }

            public T Peek()
            {
                if (IsEmpty()) throw new InvalidOperationException("stack is empty");
                T item = elementData[elementCount - 1];
                return item;
            }

            public bool Empty()
            {
                if (IsEmpty()) return true;
                else return false;
            }
             public int Search(T item)
            {
                if (IsEmpty()) throw new InvalidOperationException("stack is empty");
                for (int i = elementCount - 1; i >= 0; i--)
                {
                    if (Object.Equals(elementData[i], item)) return elementCount - 1;
                   
                }
                 return -1;
            }
        } 

        static void Main(string[] args)
        {
        }
    }
}
