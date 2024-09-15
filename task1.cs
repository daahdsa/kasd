using System;
using System.Collections.Generic;
using System.IO;
using System.Linq;
using System.Reflection;
using System.Runtime.InteropServices;
using System.Text;
using System.Threading.Tasks;

namespace task_1
{
    internal class Program
    {

        static void Main(string[] args)
        {
            string path = @"data.txt";
            var (matrix,vector)= ReadFile(path);
            for (int i = 0; i < 3; i++)
            {
                for (int j = 0; j < 3; j++)
                {
                    Console.Write(matrix[i,j]+ "   ");
                }
                Console.WriteLine();
            }




            if (!IsSym(matrix))
            {
                Console.WriteLine("матрица не симметричная");
                Console.ReadKey();
            }
            double a = FindLength(matrix, vector);
            Console.WriteLine("размерность "+ a);
            Console.ReadKey();

        }


        static (double[,], double[]) ReadFile(string path)
        {
            string line;
                StreamReader sr = new StreamReader(path);
                line = sr.ReadLine();
                int dimension = int.Parse(line);
            double[,] matrix = new double[dimension, dimension];
            double[] vector = new double[dimension];

            for(int i = 0; i < dimension; i++) { 
            string[] s1=sr.ReadLine().Split();
                for(int j = 0; j < dimension; j++)
                {
                    matrix[i,j]= double.Parse(s1[j]);
                }
            }

            string[] s = sr.ReadLine().Split();

            for (int i = 0; i < dimension; i++)
            {
                vector[i] = double.Parse(s[i]);
            }

            sr.Close();
            return (matrix,vector);
        }

        static bool IsSym(double[,] matrix)
        {
            int N=matrix.GetLength(0);


 
            for (int i = 0; i <N ; i++)
            {
                for (int j = 0; j < N; j++)
                {
                    if (matrix[i, j] != matrix[j, i])
                    {
                        return false;                    }
                }
            }
            return true;
        }

       
        static double FindLength(double[,] matrix,double[] vector)
        {
            double result=0;
            for (int i = 0;i < matrix.GetLength(0); i++)
            {
                for(int j = 0;j < matrix.GetLength(1); j++)
                {
                    result += vector[i]* matrix[i, j]*vector[j];

                }
            }
            return Math.Sqrt(result);
        }

    }
}
