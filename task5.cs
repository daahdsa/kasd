using System;
using System.Collections.Generic;
using System.IO;
using System.Linq;
using System.Text;
using System.Text.RegularExpressions;
using System.Threading.Tasks;

namespace task_5
{
    internal class Program
    {

            public class MyArrayList<T>
            {
                public T[] elementData;
                int size;

                public MyArrayList()
                {
                    elementData = new T[0];
                    size = 0;
                }

                public MyArrayList(T[] a)
                {
                    if (a == null) throw new ArgumentNullException("array");
                    elementData = new T[a.Length];
                    Array.Copy(a, elementData, a.Length);
                    size = a.Length;
                }

                public MyArrayList(int capacity)
                {
                    if (capacity < 0) throw new ArgumentOutOfRangeException("capacity");
                    elementData = new T[capacity];
                    size = 0;
                }

                public void EnsureCapacity(int minCapacity)
                {
                    int newCapacity;
                    if (elementData.Length < minCapacity)
                    {
                        if (elementData.Length == 0) newCapacity = 0;
                        else newCapacity = (elementData.Length * 3) / 2 + 1;
                        if (newCapacity < minCapacity) newCapacity = minCapacity;
                        T[] newArr = new T[newCapacity];
                        Array.Copy(elementData, newArr, size);
                        elementData = newArr;

                    }

                }


                public void Add(T e)
                {
                    EnsureCapacity(size + 1);
                    elementData[size++] = e;

                }

                public void addAll(T[] a)
                {
                    if (a == null) throw new ArgumentNullException("array");
                    EnsureCapacity(size + a.Length);
                    Array.Copy(a, 0, elementData, size, a.Length);
                    size += a.Length;
                }

                public void Clear()
                {
                    Array.Clear(elementData, 0, size);
                    size = 0;
                }


                //(object o)
                //HashSet<T> set = new HashSet<T>(elementData);
                //if(!set.Contains(e))
                //    return -1;
                public int IndexOf(object o)
                {

                    if (o == null)
                    {
                        for (int i = 0; i < size; i++)
                        {
                            if (elementData[i] == null) return i;

                        }
                    }
                    else
                    {
                        for (int i = 0; i < size; i++)
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
                    if (a == null) throw new ArgumentNullException("array");
                    foreach (var i in a)
                    {
                        if (!Contains(i)) return false;

                    }
                    return true;
                }

                public bool IsEmpty()
                {
                    return size == 0;
                }


                public void RemoveAt(int ind)
                {
                    if (ind >= size || ind < 0) throw new ArgumentOutOfRangeException("index");
                    size--;
                    if (ind < size) Array.Copy(elementData, ind + 1, elementData, ind, size - ind);
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
                    if (a == null) throw new ArgumentNullException("array");
                    foreach (var i in a)
                    {
                        Remove(i);
                    }
                }

                public void RetainAll(T[] a)
                {
                    if (a == null) throw new ArgumentNullException("array");
                    for (int i = 0; i < size;)
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
                    return size;
                }


                public T[] ToArray()
                {
                    T[] values = new T[size];
                    Array.Copy(elementData, values, size);
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
                        if (a.Length < size)
                        {
                            T[] values = new T[size];
                            Array.Copy(elementData, values, a.Length);
                            return values;
                        }
                        else
                        {
                            Array.Copy(elementData, 0, a, 0, size);
                            if (a.Length > size) a[size] = default(T);
                            return a;
                        }

                    }
                }
                public void Add(int index, T e)
                {
                    if (index < 0 || index > size) throw new ArgumentOutOfRangeException("index");
                    EnsureCapacity(size + 1);
                    Array.Copy(elementData, index, elementData, index + 1, size - index);
                    elementData[index] = e;
                    size++;
                }

                public void AddAll(int index, T[] a)
                {
                    if (a == null)
                    {
                        throw new ArgumentNullException("a");
                    }
                    if (index < 0 || index > size) throw new ArgumentOutOfRangeException("index");

                    EnsureCapacity(size + a.Length);
                    Array.Copy(elementData, index, elementData, index + a.Length, size - index);
                    Array.Copy(a, 0, elementData, index, a.Length);
                    size += a.Length;
                }
                public T Get(int index)
                {
                    if (index < 0 || index > size) throw new ArgumentOutOfRangeException("index");
                    return elementData[index];

                }

                public int LastIndexOf(object o)
                {
                    if ((object)o == null) throw new ArgumentNullException("o");

                    if (o == null)
                    {
                        for (int i = size - 1; i >= 0; i--)
                        {
                            if (elementData[i] == null) return i;

                        }
                    }
                    else
                    {
                        for (int i = size - 1; i >= 0; i--)
                        {
                            if (o.Equals(elementData[i])) return i;

                        }
                    }
                    return -1;

                }

                public T Remove(int index)
                {
                    if (index < 0 || index > size) throw new ArgumentOutOfRangeException("index");
                    T element = elementData[index];
                    Remove(element);
                    return element;
                }

                public void Set(int index, T e)
                {
                    if (index < 0 || index > size) throw new ArgumentOutOfRangeException("index");
                    elementData[index] = e;
                }

                public MyArrayList<T> SubList(int fromIndex, int toIndex)
                {
                    if (fromIndex < 0 || toIndex > size || fromIndex > toIndex) throw new ArgumentOutOfRangeException("index");
                    T[] subArray = new T[toIndex - fromIndex];
                    Array.Copy(elementData, fromIndex, subArray, 0, toIndex - fromIndex);
                    return new MyArrayList<T>(subArray);
                }
            }

    static void Main(string[] args)
        {
            string path = "data.txt";

            string pattern = @"<\/?[A-Za-z][A-Za-z0-9]*>";

            MyArrayList <string> uniqueTags= new MyArrayList<string>();

            MyArrayList <string> seenTags = new MyArrayList<string>();



            foreach (var line in File.ReadLines(path)){
                foreach(Match match in Regex.Matches(line, pattern))
                {
                    
                    string originalTag = match.Value;
                    string normailzeTag = NormalizeTag(originalTag);
                    if (!seenTags.Contains(normailzeTag))
                    {
                        seenTags.Add(normailzeTag);
                        uniqueTags.Add(originalTag);
                    }
                }
            }
            foreach (var tag in uniqueTags.ToArray())
            {
                Console.WriteLine(tag);
            }


            Console.ReadKey();
            
        }


        static string NormalizeTag(string tag)
        {
            return tag.Trim('<', '>', '/').ToLower();
        }


    }
}
