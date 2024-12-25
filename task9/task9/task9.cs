using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Linq;
using System.Text;
using System.Text.RegularExpressions;
using System.Threading.Tasks;
using MyStack;


namespace task9
{
    internal class task9
    {

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
            string expression = "a+3*b";
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

