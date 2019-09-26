using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace cs2
{
    class Program
    {
        static Random rnd = new Random();
        static void ShowArr(int[] arr)
        {
            foreach (int el in arr)
                Console.Write($"{el}  ");
            Console.WriteLine();
        }
        static void ShowArr(double[] arr)
        {
            foreach (double el in arr)
                Console.Write($"{el}\t");
            Console.WriteLine();
        }
        static void ShowArr(string[] arr)
        {
            foreach (string el in arr)
                Console.Write($"{el}\t");
            Console.WriteLine();
        }
        static void FillArr(int[] arr, int left = 0, int right = 100)
        {
            for (int i = 0; i < arr.Length; i++)
            {
                arr[i] = rnd.Next(left, right);
            }
        }
        static void SortArr(int[] arr)
        {
            int[] negative = Array.FindAll(arr, (x) => { return x < 0; });
            int[] positive = Array.FindAll(arr, (x) => { return x >= 0; });
            negative.CopyTo(arr, 0);
            positive.CopyTo(arr, negative.Length);
        }
        static void CountEl(int[] arr, int element)
        {
            Console.WriteLine(arr.Count((x) => { return x == element; }));
        }
        static void SumMinToMax(int[] arr)
        {
            int result = 0;
            int minIndex = Array.IndexOf(arr, arr.Min());
            int maxIndex = Array.IndexOf(arr, arr.Max());
            if (minIndex > maxIndex)
            {
                int tmp = minIndex;
                minIndex = maxIndex;
                maxIndex = tmp;
            }
            for (int i = minIndex + 1; i < maxIndex; i++)
            {
                result += arr[i];
            }
            Console.WriteLine(result);
        }
        //Task5
        static void FillArr(int[][] arr, int left = 0, int right = 100)
        {
            for (int i = 0; i < arr.Length; i++)
            {
                for (int j = 0; j < arr[i].Length; j++)
                {
                    arr[i][j] = rnd.Next(left, right);
                }
            }
        }
        static void ShowArr(int[][] arr)
        {
            foreach (int[] el in arr)
            {
                foreach (int value in el)
                    Console.Write(value + "\t");
                Console.WriteLine();
            }
        }
        static void ShiftUp(int[][] arr, int times = 1)
        {
            for (int t = 0; t < times; t++)
            {
                int[] tmp = arr[0];
                for (int i = 0; i < arr.Length - 1; i++)
                {
                    arr[i] = arr[i + 1];
                }
                arr[arr.Length - 1] = tmp;
            }
        }
        static void ShiftDown(int[][] arr, int times = 1)
        {
            for (int t = 0; t < times; t++)
            {
                int[] tmp = arr[arr.Length - 1];
                for (int i = arr.Length - 1; i > 0; i--)
                {
                    arr[i] = arr[i - 1];
                }
                arr[0] = tmp;
            }
        }
        //Task 6
        static void ShowArr(char[,] arr)
        {
            for (int i = 0; i < arr.GetLength(0); i++)
            {
                for (int j = 0; j < arr.GetLength(1); j++)
                {
                    Console.Write(arr[i, j] + " ");
                }
                Console.WriteLine();
            }
        }
        static void FillArr(char[,] arr, char value)
        {
            for (int i = 0; i < arr.GetLength(0); i++)
            {
                for (int j = 0; j < arr.GetLength(1); j++)
                {
                    arr[i, j] = value;
                }
            }
        }
        static string GetMove()
        {
            string tmp = "";
            bool valid = false;
            int number = 0;
            while (!valid)
            {
                Console.Write("Enter number of steps or direction (R - turn right, L - turn left): ");
                tmp = Console.ReadLine();
                switch (tmp)
                {
                    case "R":
                    case "L":
                        valid = true;
                        break;
                    default:
                        if (int.TryParse(tmp, out number))
                            valid = true;
                        else
                            Console.WriteLine("Invalid input. Try again.");
                        break;
                }
            }
            return tmp;
        }
        static void MoveRobot(char[,] arr)
        {
            int[] position = new int[2] { arr.GetLength(0) / 2, arr.GetLength(1) / 2 };
            int[] newPosition = new int[2];
            int[,] dxdy = new int[4, 2] { { -1, 0 }, { 0, 1 }, { 1, 0 }, { 0, -1 } };
            char[] robot = new char[] { '^', '>', 'v', '<' };
            int direction = 0;
            string tmp = "";
            while (true)
            {
                Console.Clear();
                Console.WriteLine("Task 6 ==========");
                arr[position[0], position[1]] = robot[direction];
                ShowArr(arr);
                switch (tmp = GetMove())
                {
                    case "R":
                        if (++direction == dxdy.GetLength(0))
                            direction = 0;
                        break;
                    case "L":
                        if (--direction < 0)
                            direction = dxdy.GetLength(0) - 1;
                        break;
                    default:
                        for (int i = 0; i < Convert.ToInt32(tmp); i++)
                        {
                            arr[position[0], position[1]] = '+';
                            newPosition[0] = position[0] + dxdy[direction, 0];
                            newPosition[1] = position[1] + dxdy[direction, 1];
                            if (newPosition.Min() < 0 || newPosition.Max() == arr.GetLength(0))
                            {
                                arr[position[0], position[1]] = 'x';
                                Console.Clear();
                                Console.WriteLine("Task 6 ==========");
                                ShowArr(arr);
                                Console.WriteLine("Sorry. Your robot crashed in to the wall.");
                                return;
                            }
                            else
                            {
                                position[0] = newPosition[0];
                                position[1] = newPosition[1];
                            }
                        }
                        break;
                }
            }
        }
        static void Main(string[] args)
        {
            Console.WriteLine("Task 1 ==========");
            int[] arr1 = { 1, 2, -4, -55, -7, 10, 100 };
            Console.Write("Arr: ");
            ShowArr(arr1);
            Console.Write("Sorted arr: ");
            SortArr(arr1);
            ShowArr(arr1);
            Console.WriteLine("Press any key to continue.");
            Console.ReadKey();

            Console.WriteLine("Task 2 ==========");
            int number = 0;
            Console.Write("Enter number to find in arr: ");
            number = Convert.ToInt32(Console.ReadLine());
            int[] arr2 = new int[20];
            FillArr(arr2, 0, 10);
            ShowArr(arr2);
            Console.Write($"number of {number} in arr: ");
            CountEl(arr2, 5);
            Console.WriteLine("Press any key to continue.");
            Console.ReadKey();

            Console.WriteLine("Task 3 ==========");
            int[] arr3 = new int[20];
            FillArr(arr3);
            ShowArr(arr3);
            Console.Write("Sum of elements from min to max: ");
            SumMinToMax(arr3);
            Console.WriteLine("Press any key to continue.");
            Console.ReadKey();

            Console.WriteLine("Task 4 ==========");
            string[] names = new string[] { "coffe", "sugar", "milk", "butter" };
            double[] prices = new double[] { 11.2, 32.22, 4.33, 2.4 };
            Console.Write("Names: ");
            ShowArr(names);
            Console.Write("Prices: ");
            ShowArr(prices);
            Array.Sort(prices, names);
            Console.Write("Names: ");
            ShowArr(names);
            Console.Write("Prices: ");
            ShowArr(prices);
            Console.WriteLine("Press any key to continue.");
            Console.ReadKey();

            Console.WriteLine("Task 5 ==========");
            int[][] arr5 = { new int[3], new int[4], new int[5] };
            FillArr(arr5);
            ShowArr(arr5);
            Console.WriteLine("Shift 2 times up");
            ShiftUp(arr5, 2);
            ShowArr(arr5);
            Console.WriteLine("Shift 2 times down");
            ShiftDown(arr5, 2);
            ShowArr(arr5);
            Console.WriteLine("Press any key to continue.");
            Console.ReadKey();

            Console.WriteLine("Task 6 ==========");
            char[,] arr6 = new char[11, 11];
            FillArr(arr6, '-');
            MoveRobot(arr6);
        }
    }
}
