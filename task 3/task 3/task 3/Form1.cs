using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Diagnostics;
using System.Drawing;
using System.IO;
using System.Linq;
using System.Runtime.Remoting.Metadata.W3cXsd2001;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;
using ZedGraph;

namespace task_3
{
    public partial class task3 : Form
    {
        static int size;
        List<int[]> listOfArrays = new List<int[]>();


        public task3()
        {
            InitializeComponent();
        }
        public class SortResult
        {
            public string Algorithm { get; set; }
            public long TimeElapsed { get; set; }
            public int ArraySize { get; set; }

            public int[] SortedResult;
        }

        private Dictionary<string, Dictionary<int, double>> CalculateAverageTime(List<SortResult> results)
        {
            var groupedResults = results.GroupBy(r => r.Algorithm);

            Dictionary<string, Dictionary<int, double>> averageTimeBySize = new Dictionary<string, Dictionary<int, double>>();

            foreach (var group in groupedResults)
            {
                string algorithm = group.Key;

                var avgTimeBySize = group.GroupBy(r => r.ArraySize)
                                         .ToDictionary(g => g.Key, g => g.Average(r => r.TimeElapsed));

                averageTimeBySize[algorithm] = avgTimeBySize;
            }

            return averageTimeBySize;
        }

        List<SortResult> sortResults = new List<SortResult>();


        private void button2_Click(object sender, EventArgs e)
        {
            int selectedAlg = comboBox1.SelectedIndex;

           

            foreach (int[] array in listOfArrays)
            {
                int[] currentArr = new int[array.Length];

                switch (selectedAlg)
                {
                    case 0:
                 
           

                            Array.Copy(array, currentArr, array.Length);
                            Stopwatch sw = Stopwatch.StartNew();
                            
                   
                        currentArr = sortalgorithms.BubbleSort(currentArr);
                        sw.Stop();

                        sortResults.Add(new SortResult
                        {
                            Algorithm = "Cортировка пузырьком",
                            TimeElapsed = sw.ElapsedMilliseconds,
                            ArraySize = currentArr.Length,
                            SortedResult = currentArr
                        }) ;
                            /////////////////
                            currentArr = new int[array.Length];

                            Array.Copy(array, currentArr, array.Length);
                            sw = Stopwatch.StartNew();
                        currentArr = sortalgorithms.InsertionSort(currentArr);
                            sw.Stop();

                            sortResults.Add(new SortResult
                            {
                                Algorithm = "Cортировка вставками",
                                TimeElapsed = sw.ElapsedMilliseconds,
                                ArraySize = currentArr.Length,
                                 SortedResult = currentArr
                            });
                            ///////////////////

                            currentArr = new int[array.Length];

                            Array.Copy(array, currentArr, array.Length);
                            sw = Stopwatch.StartNew();
                        currentArr = sortalgorithms.SelectionSort(currentArr);
                            sw.Stop();

                            sortResults.Add(new SortResult
                            {
                                Algorithm = "Cортировка выбором",
                                TimeElapsed = sw.ElapsedMilliseconds,
                                ArraySize = currentArr.Length,
                                 SortedResult = currentArr
                            });

                            ///////////////////

                            currentArr = new int[array.Length];

                            Array.Copy(array, currentArr, array.Length);
                 
                            sw = Stopwatch.StartNew();
                        currentArr = sortalgorithms.ShakerSort(currentArr);

                        sw.Stop();

                  
                     

                            sortResults.Add(new SortResult
                            {
                                Algorithm = "Cортировка шейкером",
                                TimeElapsed = sw.ElapsedMilliseconds,
                                ArraySize = currentArr.Length,
                                SortedResult = currentArr
                            });
                            
                            //////////////////////
                            currentArr = new int[array.Length];

                            Array.Copy(array, currentArr, array.Length);
                            sw = Stopwatch.StartNew();
                        currentArr = sortalgorithms.GnomeSort(currentArr);
                            sw.Stop();

                            sortResults.Add(new SortResult
                            {
                                Algorithm = "Cортировка гномья",
                                TimeElapsed = sw.ElapsedMilliseconds,
                                ArraySize = currentArr.Length,
                                 SortedResult = currentArr
                            });
                        break;
                    case 1:

                        Array.Copy(array, currentArr, array.Length);
                            sw = Stopwatch.StartNew();
                            sortalgorithms.BitonicSort(currentArr);
                            sw.Stop();

                            sortResults.Add(new SortResult
                            {
                                Algorithm = "Cортировка битонная",
                                TimeElapsed = sw.ElapsedMilliseconds,
                                ArraySize = currentArr.Length
                            });
                            ///////////////
                            currentArr = new int[array.Length];

                            Array.Copy(array, currentArr, array.Length);
                            sw = Stopwatch.StartNew();
                            sortalgorithms.Shell(currentArr);
                            sw.Stop();

                            sortResults.Add(new SortResult
                            {
                                Algorithm = "Cортировка Шелла",
                                TimeElapsed = sw.ElapsedMilliseconds,
                                ArraySize = currentArr.Length
                            });
                            /////////////////
                            currentArr = new int[array.Length];

                            Array.Copy(array, currentArr, array.Length);
                            sw = Stopwatch.StartNew();
                            sortalgorithms.TreeSort(currentArr);
                            sw.Stop();

                            sortResults.Add(new SortResult
                            {
                                Algorithm = "Cортировка дерева",
                                TimeElapsed = sw.ElapsedMilliseconds,
                                ArraySize = currentArr.Length
                            });
                        break;
                    case 2:
                 
                            Array.Copy(array, currentArr, array.Length);
                            sw = Stopwatch.StartNew();
                            sortalgorithms.CombSort(currentArr);
                            sw.Stop();

                            sortResults.Add(new SortResult
                            {
                                Algorithm = "Cортировка расческой",
                                TimeElapsed = sw.ElapsedMilliseconds,
                                ArraySize = currentArr.Length
                            });
                            ///////////////
                            currentArr = new int[array.Length];

                            Array.Copy(array, currentArr, array.Length);
                            sw = Stopwatch.StartNew();
                            sortalgorithms.HeapSort(currentArr);
                            sw.Stop();

                            sortResults.Add(new SortResult
                            {
                                Algorithm = "Cортировка пирамидальная",
                                TimeElapsed = sw.ElapsedMilliseconds,
                                ArraySize = currentArr.Length
                            });
                            /////////////////
                            currentArr = new int[array.Length];
                            int high = currentArr.Length, low = 0;
                            Array.Copy(array, currentArr, array.Length);
                            sw = Stopwatch.StartNew();
                            sortalgorithms.QuickSort(currentArr, low, high-1);
                            sw.Stop();

                            sortResults.Add(new SortResult
                            {
                                Algorithm = "Cортировка быстрая",
                                TimeElapsed = sw.ElapsedMilliseconds,
                                ArraySize = currentArr.Length
                            });
                            /////////////////
                            currentArr = new int[array.Length];

                            Array.Copy(array, currentArr, array.Length);
                            sw = Stopwatch.StartNew();
                            sortalgorithms.CountingSort(currentArr);
                            sw.Stop();

                            sortResults.Add(new SortResult
                            {
                                Algorithm = "Cортировка слиянием",
                                TimeElapsed = sw.ElapsedMilliseconds,
                                ArraySize = currentArr.Length
                            });
                            /////////////////
                            currentArr = new int[array.Length];

                            Array.Copy(array, currentArr, array.Length);
                            sw = Stopwatch.StartNew();
                            sortalgorithms.MergeSort(currentArr);
                            sw.Stop();

                            sortResults.Add(new SortResult
                            {
                                Algorithm = "Cортировка подсчетом",
                                TimeElapsed = sw.ElapsedMilliseconds,
                                ArraySize = currentArr.Length
                            });
                            /////////////////
                            currentArr = new int[array.Length];

                            Array.Copy(array, currentArr, array.Length);
                            sw = Stopwatch.StartNew();
                            sortalgorithms.RadixSort(currentArr);
                            sw.Stop();

                            sortResults.Add(new SortResult
                            {
                                Algorithm = "Cортировка поразрядная",
                                TimeElapsed = sw.ElapsedMilliseconds,
                                ArraySize = currentArr.Length
                            });
                      
                        break;
                }
            }            
            var averageTime=CalculateAverageTime(sortResults);
            DrawGraph(averageTime);
            MessageBox.Show("график нарисован");

        }

    

        private void DrawGraph(Dictionary<string, Dictionary<int, double>> data)
        {
            GraphPane pane = zedGraphControl1.GraphPane;
            pane.CurveList.Clear();
            int max = 1000;
            pane.Title.Text = "Среднее время сортировки по размерам массива";
            pane.XAxis.Title.Text = "Размер массива";
            pane.YAxis.Title.Text = "Среднее время (мс)";

            Color[] colors = { Color.Red, Color.Green, Color.Blue, Color.Orange, Color.Purple };
            int colorIndex = 0;

            foreach (var algorithmData in data)
            {
                string algorithmName = algorithmData.Key;
                var sizeToTime = algorithmData.Value;

                PointPairList points = new PointPairList();
                foreach (var entry in sizeToTime)
                {
                    int arraySize = entry.Key;
                    double averageTime = entry.Value;
                    points.Add(arraySize, averageTime);
                    max = (int)points.Last().X;
                }
                
                LineItem curve = pane.AddCurve(algorithmName, points, colors[colorIndex % colors.Length], SymbolType.Circle);
                colorIndex++;

                pane.XAxis.Scale.Max = max;
            }
            pane.XAxis.MajorGrid.IsVisible = true;
            pane.YAxis.MajorGrid.IsVisible = true;
           

            zedGraphControl1.AxisChange();
            zedGraphControl1.Invalidate();
        }

        private void button1_Click_1(object sender, EventArgs e)
        {
            listOfArrays.Clear();
            int selectedAlg = comboBox1.SelectedIndex;
            int selectedArr = comboBox2.SelectedIndex;
            int[] array1 = new int[10];
            int[] array2 = new int[100];
            int[] array3 = new int[1000];
            int[] array4 = new int[10000];
            int[] array5 = new int[100000];

            switch (selectedAlg)
            {
                case 0:
                    for (int i = 0; i < 20; i++)
                    {
                        if (selectedArr == 0)
                        {
                            array1 = arraygeneration.Group1Array(10);
                            array2 = arraygeneration.Group1Array(100);
                            array3 = arraygeneration.Group1Array(1000);
                        }
                        else if (selectedArr == 1)
                        {
                            array1 = arraygeneration.Group2Array(10);
                            array2 = arraygeneration.Group2Array(100);
                            array3 = arraygeneration.Group2Array(1000);
                        }
                        else if (selectedArr == 2)
                        {
                            array1 = arraygeneration.Group3Array(10);
                            array2 = arraygeneration.Group3Array(100);
                            array3 = arraygeneration.Group3Array(1000);
                        }
                        else if (selectedArr == 3)
                        {
                            array1 = arraygeneration.Group4Array(10);
                            array2 = arraygeneration.Group4Array(100);
                            array3 = arraygeneration.Group4Array(1000);
                        }
                        listOfArrays.Add(array1);
                        listOfArrays.Add(array2);
                        listOfArrays.Add(array3);
                    }
                    break;
                case 1:
                    for (int i = 0; i < 20; i++)
                    {
                        if (selectedArr == 0)
                        {
                            array1 = arraygeneration.Group1Array(10);
                            array2 = arraygeneration.Group1Array(100);
                            array3 = arraygeneration.Group1Array(1000);
                            array4 = arraygeneration.Group1Array(10000);
                        }
                        else if (selectedArr == 1)
                        {
                            array1 = arraygeneration.Group2Array(10);
                            array2 = arraygeneration.Group2Array(100);
                            array3 = arraygeneration.Group2Array(1000);
                            array4 = arraygeneration.Group1Array(10000);

                        }
                        else if (selectedArr == 2)
                        {
                            array1 = arraygeneration.Group3Array(10);
                            array2 = arraygeneration.Group3Array(100);
                            array3 = arraygeneration.Group3Array(1000);
                            array4 = arraygeneration.Group1Array(10000);

                        }
                        else if (selectedArr == 3)
                        {
                            array1 = arraygeneration.Group4Array(10);
                            array2 = arraygeneration.Group4Array(100);
                            array3 = arraygeneration.Group4Array(1000);
                            array4 = arraygeneration.Group1Array(10000);

                        }
                        listOfArrays.Add(array1);
                        listOfArrays.Add(array2);
                        listOfArrays.Add(array3);
                        listOfArrays.Add(array4);
                    }


                    break;
                case 2:
                    for (int i = 0; i < 20; i++)
                    {
                        if (selectedArr == 0)
                        {
                            array1 = arraygeneration.Group1Array(10);
                            array2 = arraygeneration.Group1Array(100);
                            array3 = arraygeneration.Group1Array(1000);
                            array4 = arraygeneration.Group1Array(10000);
                            array5 = arraygeneration.Group1Array(100000);
                        }
                        else if (selectedArr == 1)
                        {
                            array1 = arraygeneration.Group2Array(10);
                            array2 = arraygeneration.Group2Array(100);
                            array3 = arraygeneration.Group2Array(1000);
                            array4 = arraygeneration.Group1Array(10000);
                            array5 = arraygeneration.Group1Array(100000);


                        }
                        else if (selectedArr == 2)
                        {
                            array1 = arraygeneration.Group3Array(10);
                            array2 = arraygeneration.Group3Array(100);
                            array3 = arraygeneration.Group3Array(1000);
                            array4 = arraygeneration.Group1Array(10000);
                            array5 = arraygeneration.Group1Array(100000);


                        }
                        else if (selectedArr == 3)
                        {
                            array1 = arraygeneration.Group4Array(10);
                            array2 = arraygeneration.Group4Array(100);
                            array3 = arraygeneration.Group4Array(1000);
                            array4 = arraygeneration.Group1Array(10000);
                            array5 = arraygeneration.Group1Array(100000);


                        }
                        listOfArrays.Add(array1);
                        listOfArrays.Add(array2);
                        listOfArrays.Add(array3);
                        listOfArrays.Add(array4);
                        listOfArrays.Add(array5);


                    }
                    break;
            }
          if(listOfArrays.Count>0)  MessageBox.Show("массивы сгенерированы");
           else MessageBox.Show("нет");

        }

       

        private void button3_Click(object sender, EventArgs e)
        {
            string filePath = "saved.txt";


            using (StreamWriter writer = new StreamWriter(filePath))
            {

                writer.WriteLine("Сгенерированные массивы:");

                for (int i = 0; i < listOfArrays.Count; i++)
                {
                    writer.WriteLine($"Массив {i + 1}:");
                    writer.WriteLine(string.Join(", ", listOfArrays[i]));
                    writer.WriteLine();
                }


                writer.WriteLine("Результаты сортировки:");

                foreach (var result in sortResults)
                {
                    writer.WriteLine($"Алгоритм: {result.Algorithm}");
                    writer.WriteLine($"Размер массива: {result.ArraySize}");
                    writer.WriteLine($"Время выполнения: {result.TimeElapsed} мс");
                    writer.WriteLine("Отсортированный массив:");
                    writer.WriteLine(string.Join(", ", result.SortedResult));
                    writer.WriteLine();
                }
            }

            MessageBox.Show($"Результаты успешно сохранены в файл: {filePath}");
        }
    }






}






