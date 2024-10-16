using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;
namespace task_3
{
    public partial class arraygeneration : Form
    {
        public static Random rand = new Random();
        public static int[] Group1Array(int size)
        {
            int[] array = new int[size];
            for (int i = 0; i < size; i++)
            {
                array[i] = rand.Next(0, 1000);
            }
            return array;
        }
        public static int[] Group2Array(int size)
        {
            int[] finalArray = new int[size];
            int curIndex = 0;
            int subArrsize = (int)Math.Pow(10, rand.Next(1, (int)Math.Log(size, 10)) + 1);
            while (size > 0)
            {
                int curSubSize = rand.Next(1, subArrsize);
                if (size - curSubSize < 0) curSubSize = size;
                int[] subArray = new int[curSubSize];
                subArray = Group1Array(curSubSize);
                Array.Sort(subArray);

                for (int i = 0; i < curSubSize; i++)
                {
                    finalArray[curIndex++] = subArray[i];
                }
                size -= curSubSize;
            }
            return finalArray;
        }
        public static int[] Group3Array(int size)
        {
            int[] array = new int[size];
            
            for(int i = 0;i< size;i++)
            {
                array[i] = rand.Next(0, size);
            }
            Array.Sort(array);
            int k = rand.Next(1, size / 5);
            for (int m = 0; m < k; m++)
            {
                int i = rand.Next(0, size);
                int j = rand.Next(0, size);
                int temp = array[i];
                array[i] = array[j];
                array[j] = temp;
            }
            return array;
        }
        public static int[] Group4Array(int size)
        {
            int[] array= new int[size];
            int choice=rand.Next(4);
            switch (choice)
            {
                case 0: 
                    for(int i = 0; i < size; i++)
                    {
                        array[i] = i;
                    }
                    break;
                case 1:
                    for (int i = size-1; i >= 0; --i)
                    {
                        array[i] = i;
                    }
                    break;
                case 2:
                    for (int i = 0; i < size; i++)
                    {
                        array[i] = i;
                    }
                    int k = rand.Next(1, size / 5);
                    for (int m = 0; m < k; m++)
                    {
                        int s = rand.Next(0, size);
                        int j = rand.Next(0, size);
                        int temp = array[s];
                        array[s] = array[j];
                        array[j] = temp;
                    }
                    break;
                case 3:
                    int[] repeat = { 10, 25, 50, 75, 90 };
                    int selectedPer = rand.Next(0, repeat.Length);
                    int percent = repeat[selectedPer];
                    int repeatedValue=rand.Next(0, size);
                    int repeatedCount = size * percent / 100;
                    for(int i = 0; i < repeatedCount; i++)
                    {
                        array[i]=repeatedValue;
                    }
                    for (int i = repeatedCount; i < size; i++)
                    {
                        array[i]=rand.Next(0, size);
                    }
                    array= array.OrderBy(x => rand.Next()).ToArray();
                    
                    break;
            }
            return array;
        }
    }
}