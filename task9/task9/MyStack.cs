using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using MyVector;

namespace MyStack
{

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
}
