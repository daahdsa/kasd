using System;
using System.Collections.Generic;
using System.Linq;
using System.Reflection;
using System.Reflection.Emit;
using System.Runtime.InteropServices;
using System.Text;
using System.Threading;
using System.Threading.Tasks;

namespace task10
{
    internal class Program
    {
        public class Heap
        {
            List<int> heap;

            public Heap(int[] elements)
            {
                heap = new List<int>(elements);
                BuildHeap();
            }

            private void Swap(int x, int y)
            {
                int t = heap[x];
                heap[x] = heap[y];
                heap[y] = t;
            }

            public void Heapify(int i)
            {
                int left = 2 * i + 1;
                int right = 2 * i + 2;

                int largest = i;
                if (left < heap.Count() && heap[left] > heap[largest]) largest = left;
                if (right < heap.Count() && heap[right] > heap[largest]) largest = right;

                if (largest != i)
                {
                    Swap(i, largest);
                    Heapify(largest);
                }
            }
            public void BuildHeap()
            {
                int startIndex = (heap.Count / 2) - 1;
                for (int i = startIndex; i >= 0; i--)
                {
                    Heapify(i);
                }
            }

            public int MaxH()
            {
                if (heap.Count() == 0) throw new InvalidOperationException("");
                return heap[0];
            }
            public int PopMaxH()
            {
                if (heap.Count() == 0) throw new InvalidOperationException("");
                int MaxH = heap[0];
                heap[0] = heap[heap.Count - 1];

                heap.RemoveAt(heap.Count - 1);
                Heapify(0);
                return MaxH;
            }



            public void IncreaseKey(int index, int newValue)
            {
                if (newValue < heap[index]) throw new ArgumentException("newaValue");
                heap[index] = newValue;
                while (index > 0 && heap[(index - 1) / 2] < heap[index])
                {
                    Swap(index, (index - 1) / 2);
                    index = (index - 1) / 2;
                }
            }


            public void InsertValue(int value)
            {
                heap.Add(value);
                int index = heap.Count - 1;
                while (index > 0 && heap[(index - 1) / 2] < heap[index])
                {
                    Swap(index, (index - 1) / 2);
                    index = (index - 1) / 2;
                }

            }

            public static Heap Merge(Heap heap1, Heap heap2)
            {
                List<int> mergedHeap = new List<int>(heap1.heap);
                mergedHeap.AddRange(heap2.heap);
                return new Heap(mergedHeap.ToArray());
            }

            public void Print()
            {
                Console.WriteLine("MaxH = " + heap[0]);
                PrintHeap(0, 0);
                
            }

            private void PrintHeap(int index, int level)
            {
                if (index >= heap.Count)
                    return;

                PrintHeap(2 * index + 1, level + 1);

                for (int i = 0; i < level; i++)
                {
                    Console.Write("   ");
                }

                Console.WriteLine(heap[index]);

                PrintHeap(2 * index + 2, level + 1);
            }
        }


        static void Main(string[] args)
        {
            int[] array = { 19, 1, 25, 3, 7, 17, 2, 36, 100 };
            Heap heap = new Heap(array);

            heap.Print();

            Console.WriteLine(" ");

            Console.WriteLine("MaxH = " + heap.MaxH());

            heap.PopMaxH();

            Console.WriteLine("new MaxH = " + heap.MaxH());
            heap.Print();
            Console.WriteLine(" ");


            heap.IncreaseKey(4, 200);
            Console.WriteLine("changed increase key");

            heap.Print();
            Console.WriteLine(" ");
            heap.InsertValue(50);

            int[] ar2 = { 60, 70, 80 };
            Heap heap2 = new Heap(ar2);

            Heap heap3 = new Heap(array);

            heap3 = Heap.Merge(heap, heap2);
            heap3.Print();
            Console.WriteLine(" ");

            Console.ReadKey();
        }
    }
}

