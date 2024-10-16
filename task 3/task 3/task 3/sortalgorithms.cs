using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;

namespace task_3
{
    public partial class sortalgorithms : Form
    {
        public sortalgorithms()
        {
            InitializeComponent();
        }


        public static int[] BubbleSort(int[] array)
        {
            for (int i = 0; i < array.Length - 1; i++)
            {
                for (int j = 0; j < array.Length - i - 1; j++)
                {
                    if (array[j] > array[j + 1])
                    {
                        int temp = array[j];
                        array[j] = array[j + 1];
                        array[j + 1] = temp;
                    }
                }
            }
            return array;
        }
        public static int[] ShakerSort(int[] array)
        {
            int leftIndex = 0;
            int rightIndex = array.Length - 1;

            while (leftIndex < rightIndex)
            {
                for (int i = leftIndex; i < rightIndex; ++i)
                {
                    if (array[i] > array[i + 1])
                    {
                        int temp = array[i];
                        array[i] = array[i + 1];
                        array[i + 1] = temp;
                    }
                }
                --rightIndex;

                for (int i = rightIndex; i > leftIndex; --i)
                {
                    if (array[i] < array[i - 1])
                    {
                        int temp = array[i];
                        array[i] = array[i - 1];
                        array[i - 1] = temp;
                    }
                }
                ++leftIndex;
            }

            return array;
        }
        public static int[] CombSort(int[] array)
        {
            double gap = array.Length;
            bool swaps = true;
            while (gap > 1 || swaps)
            {
                gap /= 1.247330950103979;
                if (gap < 1) { gap = 1; }
                int i = 0;
                swaps = false;
                while (i + gap < array.Length)
                {
                    int igap = i + (int)gap;
                    if (array[i] > array[igap])
                    {
                        int swap = array[i];
                        array[i] = array[igap];
                        array[igap] = swap;
                        swaps = true;
                    }
                    i++;
                }
            }
            return array;
        }
        public static int[] InsertionSort(int[] array)
        {
            for (int i = 1; i < array.Length; ++i)
            {
                int key = array[i];
                int j = i - 1;

                while (j >= 0 && array[j] > key)
                {
                    array[j + 1] = array[j];
                    j--;
                }

                array[j + 1] = key;
            }
            return array;
        }

        static void Swap(ref int a, ref int b)
        {
            var t = a;
            a = b;
            b = t;
        }
        public static int[] Shell(int[] array, bool reversed = false)
        {
            var d = array.Length / 2; while (d >= 1)
            {
                for (var i = d; i < array.Length; i++)
                {
                    var j = i; while ((j >= d) && (!reversed && array[j - d] > array[j] || reversed && array[j - d] < array[j]))
                    {
                        Swap(ref array[j], ref array[j - d]);
                        j = j - d;
                    }
                }
                d = d / 2;
            }
            return array;
        }

        public class TreeNode
        {
            public int value { get; set; }
            public TreeNode(int key)
            {
                value = key;
            }

            public TreeNode Right { get; set; }
            public TreeNode Left { get; set; }

            public void Insert(TreeNode root)
            {
                if (root.value < value)
                {
                    if (Left == null) Left = root;
                    else Left.Insert(root);
                }
                else
                {
                    if (Right == null) Right = root;
                    else Right.Insert(root);
                }
            }

            public int[] TransformToArray(List<int> elements = null)
            {
                if (elements == null) elements = new List<int>();
                if (Left != null) Left.TransformToArray(elements);
                elements.Add(value);
                if (Right != null) Right.TransformToArray(elements);
                return elements.ToArray();
            }


        }

        public static int[] TreeSort(int[] array, bool isReverse = false)
        {
            TreeNode root = new TreeNode(array[0]);
            for (int i = 1; i < array.Length; i++) root.Insert(new TreeNode(array[i]));
            int[] newArray = root.TransformToArray();
            for (int i = 0; i < array.Length; i++)
            {
                if (isReverse)
                {
                    array[i] = newArray[array.Length - 1 - i];
                    continue;
                }
                array[i] = newArray[i];
            }
            return array;
        }

        public static int[] GnomeSort(int[] array, bool isReverse = false)
        {
            int index = 0;
            while (index < array.Length)
            {
                if (index == 0) index++;
                if ((!isReverse && array[index] >= array[index - 1]) || (isReverse && array[index] <= array[index - 1])) index++;
                else
                {
                    int temp = array[index];
                    array[index] = array[index - 1];
                    array[index - 1] = temp;
                    index--;
                }

            }
            return array;
        }
        public static int[] SelectionSort(int[] array)
        {

            for (int i = 0; i < array.Length - 1; i++)
            {
                //поиск минимального числа
                int min = i;
                for (int j = i + 1; j < array.Length; j++)
                {
                    if (array[j] < array[min])
                    {
                        min = j;
                    }
                }
                //обмен элементов
                int temp = array[min];
                array[min] = array[i];
                array[i] = temp;
            }
            return array;
        }

        private static void Heapify(int[] array, int n, int i)
        {
            int largest = i;
            int left = 2 * i + 1;
            int right = 2 * i + 2;

            if (left < n && array[left] > array[largest])
                largest = left;

            if (right < n && array[right] > array[largest])
                largest = right;

            if (largest != i)
            {
                int temp = array[i];
                array[i] = array[largest];
                array[largest] = temp;
                Heapify(array, n, largest);
            }
        }
        public static int[] HeapSort(int[] array)
        {
            int n = array.Length;
            for (int i = n / 2 - 1; i >= 0; --i)
                Heapify(array, n, i);

            for (int i = n - 1; i > 0; --i)
            {
                int temp = array[0];
                array[0] = array[i];
                array[i] = temp;
                Heapify(array, i, 0);
            }
            return array;
        }
        public static int[] QuickSort(int[] array, int low, int high)
        {
            if (low < high)
            {
                int pivot = Partition(array, low, high);
                QuickSort(array, low, pivot - 1);
                QuickSort(array, pivot + 1, high);
            }
            return array;
        }
        private static int Partition(int[] array, int low, int high)
        {
            int pivot = array[high];
            int i = (low - 1);
            int temp;
            for (int j = low; j <= high - 1; j++)
            {
                if (array[j] <= pivot)
                {
                    i++;
                    temp = array[i];
                    array[i] = array[j];
                    array[j] = temp;
                }
            }

            temp = array[i + 1];
            array[i + 1] = array[high];
            array[high] = temp;

            return i + 1;
        }

        public static void MergeSort(int[] array)
        {
            MergeSort(array, 0, array.Length - 1);
        }

        private static void MergeSort(int[] arr, int start, int end)
        {
            if (start < end)
            {
                int mid = (start + end) / 2;
                MergeSort(arr, start, mid);
                MergeSort(arr, mid + 1, end);
                Merge(arr, start, mid, end);
            }
        }

        private static void Merge(int[] array, int start, int mid, int end)
        {
            int leftLen = mid - start + 1;
            int rightLen = end - mid;

            int[] leftArray = new int[leftLen];
            int[] rightArray = new int[rightLen];

            for (int i = 0; i < leftLen; i++)
                leftArray[i] = array[start + i];

            for (int i = 0; i < rightLen; i++)
                rightArray[i] = array[mid + 1 + i];
        }

        public static void CountingSort(int[] array)
        {
            int maxValue = array.Max();
            int[] count = new int[maxValue + 1];

            for (int i = 0; i < array.Length; ++i)
                ++count[array[i]];

            for (int i = 1; i < count.Length; ++i)
                count[i] += count[i - 1];

            int[] sortedArray = new int[array.Length];
            for (int i = array.Length - 1; i >= 0; --i)
            {
                sortedArray[--count[array[i]]] = array[i];
            }

            for (int i = 0; i < array.Length; ++i)
                array[i] = sortedArray[i];
        }
        private static void CountingSort(int[] arr, int exp)
        {
            int maxValue = 256;
            int[] count = new int[maxValue];

            for (int i = 0; i < arr.Length; ++i)
                ++count[(arr[i] >> (exp * 8)) & 0xFF];

            for (int i = 1; i < count.Length; ++i)
                count[i] += count[i - 1];

            int[] sortedArr = new int[arr.Length];

            for (int i = arr.Length - 1; i >= 0; --i)
            {
                sortedArr[--count[(arr[i] >> (exp * 8)) & 0xFF]] = arr[i];
            }

            for (int i = 0; i < arr.Length; ++i)
                arr[i] = sortedArr[i];
        }

        public static void RadixSort(int[] arr)
        {
            const int BITS_PER_BYTE = 8;
            for (int exp = BITS_PER_BYTE - 1; exp >= 0; --exp)
            {
                CountingSort(arr, exp);
            }
        }
        ////////////////////////////////

        private static void SwapIfGreater(ref int a, ref int b)
        {
            if (a > b)
            {
                int t = a;
                a = b;
                b = t;
            }
        }

        private static void SwapIfLess(ref int a, ref int b)
        {
            if (a < b)
            {
                int t = a;
                a = b;
                b = t;
            }
        }

        public static void BitonicSort(int[] arr)
        {
            int n = arr.Length;
            for (int d = 1; d < n; d *= 2)
            {
                for (int i = 0; i < n; i += 2 * d)
                {
                    int l = i, r = Math.Min(i + d - 1, n - 1);
                    while (l < r)
                    {
                        if ((l & 1) == 0)
                        {
                            SwapIfGreater(ref arr[l++], ref arr[r]);
                        }
                        else
                        {
                            SwapIfLess(ref arr[l], ref arr[r--]);
                        }
                    }
                }
            }
        }

    }
}
