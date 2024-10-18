using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Classwork
{
    internal class Program
    {
        static void merge(int[] arr,int left ,int mid,int right)
        {
            int n1 = mid - left + 1;
            int n2 = right - mid;

            int[] L = new int[n1]; 
            int[] R = new int[n2];
            int i = 0;
            int j = 0;
            for( i = 0; i < n1; ++i)
            {
                L[i] = arr[left+i];
            }
            for( j = 0; j < n2; ++j)
            {
                R[j] = arr[mid+1+j];
            }

            int k = left;
            i = 0;
            j = 0;
            while(i<n1 && j < n2)
            {
                if (L[i] <= R[j])
                {
                    arr[k] = L[i];
                    i++;
                }
                else
                {
                    arr[k] = R[j];
                    j++;
                }
                k++;
            }
            while (i < n1)
            {
                arr[k] = L[i];
                i++;
                k++;
            }

            while (j < n2)
            {
                arr[k] = R[j];
                j++;
                k++;
            }


        }
        static void mergeSort(int[] arr,int left,int right)
        {
            if (left < right)
            {
                int mid = left + (right - left) / 2;

                mergeSort(arr, left, mid);
                mergeSort(arr, mid+1, right);

                merge(arr, left, mid, right);
            }
        }
        static void Main(string[] args)
        {
            int[] arr = { 12, 0, 10, -20, 0, 3, 1, 2, 3, 4, -190 };
            mergeSort(arr,0, arr.Length-1);

            for (int i = 0; i < arr.Length; ++i)
                Console.Write(arr[i] + "|");
            Console.WriteLine();

            Console.WriteLine("Custom Stack");

            Stack customStack = new Stack();

            customStack.Push(0);
            customStack.Push(10);
            customStack.Print();

            Console.ReadLine();
        }
        

    }
    internal class Stack
    {
        static int max = 10000;
        int top;
        int[] stack = new int[max];

        public Stack()
        {
            top = -1;
        }

        internal bool Push(int data)
        {
            if (top >= max - 1) 
                return false;
            else
            {
                stack[++top] = data; 
                return true;
            }
        }

        internal int Pop()
        {
            if (top < 0)
                return 0; 
            else
            {
                int value = stack[top--];
                return value;
            }
        }

        internal void Peek()
        {
            if (top < 0) return;
            else
                Console.WriteLine($"Top element is {stack[top]}");
        }

        internal void Print()
        {
            if (top < 0)
            {
                Console.WriteLine("Stack is empty.");
                return;
            }
            else
            {
                for (int i = top; i >= 0; i--)
                    Console.WriteLine(stack[i]);
            }
        }
    }
}
