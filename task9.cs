using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Linq;
using System.Text;
using System.Text.RegularExpressions;
using System.Threading.Tasks;


namespace task9
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



            public override string ToString()
            {
               
StringBuilder sb = new StringBuilder();
                for (int i = 0; i < elementCount; i++)
                {
                    sb.Append(elementData[i]);
                    if (i < elementCount - 1)
                    {
                        sb.Append(" ");
                    }
                }
                return sb.ToString();
         
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


        private static int OperatorPrecendence(string op)
        {
            switch (op) {

            case "+":
            case "-":
                    return 1;
            case "*": 
            case "/":
            case "//":
            case "%":
                    return 2;
            case "^":
            case "sqrt":
            case "abs":
            case "sign":
            case "sin":
            case "cos":
            case "tan":
            case "ln":
            case "lg":
            case "min":
            case "max":
            case "exp":
                    return 3;
            case "floor":
                    return 4;
            default:
                    return 0;
            }
        }

        public static double PerformOperaton(double a,double b, string op)
        {
            switch (op)
            {
                case "+":
                    return a + b;

                case "-":
                    return a - b;

                case "*":
                    return a * b;
                case "/":
                    if (b==0) throw new DivideByZeroException("b=0");
                    return a / b;

                case "%":
                    return a%b;

                case "^":
                    return Math.Pow(a,b);
                case "min":
                    return Math.Min(a, b);
                case "max":
                    return Math.Max(a, b);
                case "//":
                    if (b == 0) throw new DivideByZeroException("b=0");
                    return (int)a / b;
                default:
                    throw new InvalidOperationException("");

            }
        }


        public static double PerformUnarOperaton(double a, string op)
        {
            switch (op)
            {
 
                case "abs":
                    return Math.Abs(a);

                case "sin":
                    return Math.Sin(a);
                case "cos":
                    return Math.Cos(a);

                case "tan":
                    return Math.Tan(a);
                case "ln":
                    if (a < 0) throw new InvalidOperationException("");
                    return Math.Log(a);
                case "lg":
                    return Math.Log10(a);
                case "exp":
                    return Math.Exp(a);
                case "sign":
                    return Math.Sign(a);
                  
                case "floor":
                    return Math.Floor(a);
                default:
                    throw new InvalidOperationException("");

            }
        }


        private static double CalculateRPN(string[] ops)
        {
            MyStack<double> stack = new MyStack<double>();
            int step = 1;
            foreach (string op in ops)
            {
                Console.WriteLine($"step: {step} op: {op} stack: {stack} ");
                step++;

                if (double.TryParse(op, out double number)) stack.Push(number);
                else if (op == ")" || op == "(") continue;
                else if (op == "abs" || op == "sin" || op == "cos" || op == "tan" || op == "ln" || op == "lg" || op == "exp" || op == "sign" || op == "floor")
                {
                    double a = stack.Pop();
                    stack.Push(PerformUnarOperaton(a, op));
                }
                else {
                    double b = stack.Pop();
                    double a = stack.Pop();
                    stack.Push(PerformOperaton(a, b, op));
                }

            }
            
            return stack.Pop();
        }


            private static string[] ToRPN(string expression)
            {
                var pattern = @"(\d+\.\d+|\d+|\b(abs|sign|sqrt|sin|cos|tan|ln|log|exp|min|max)|[+\-*/^%()])";

            MyStack<string> stack = new MyStack<string>();

            List<string> output = new List<string>();


            var matches= Regex.Matches(expression, pattern);
            string[] tokens = new string[matches.Count];
            for (int i = 0; i < matches.Count; i++)
            {
                tokens[i]= matches[i].Value;
            }
            foreach(string  token in tokens)
            {
                if (double.TryParse(token, out _)) output.Add(token);
                else if (token == "(") stack.Push(token);
                else if (token == ")") {
                    while (stack.Size() > 0&& stack.Peek()!="(") {
                        output.Add(stack.Pop());
                    }
                    if (stack.Size() > 0 && stack.Peek() == "(") stack.Pop();
                }
                else
                {
                    while (stack.Size() > 0 && OperatorPrecendence(stack.Peek())>=OperatorPrecendence(token))
                    {
                        output .Add(stack.Pop());
                    }
                    stack.Push(token);
                }

            }
            while(stack.Size()>0) output.Add(stack.Pop());
            return output.ToArray();
            }
           

        


        static void Main(string[] args)
        {
            string expression = "b + 4 * 2 / (1 - a) ^ 2";
            string varstring = "a=5 b=3";
            Dictionary<string, double> variables = new Dictionary<string, double>();
            string[] varPairs = varstring.Split(' ');
            foreach (string pair in varPairs)
            {
                string[] parts= pair.Split('=');
                if (parts.Length == 2 && double.TryParse(parts[1], out double value)) variables[parts[0]] = value;
                else { Console.WriteLine("ошибка"); return; }
            }
            foreach(var v in variables)
            {
                expression = expression.Replace(v.Key, v.Value.ToString());
            }
            string[] strings = ToRPN(expression);
            
            Console.WriteLine(string.Join(" ",strings));
            double result=CalculateRPN(strings);
            Console.WriteLine(result);
            Console.ReadKey();
        }
        
    }



       
} 

