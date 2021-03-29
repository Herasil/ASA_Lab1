using System;
using System.Collections.Generic;
using System.IO;
using System.Text;
namespace ASA_lab1
{
    class Program
    {
        const int min = 10;
        const int max = 1000;
        const int numbersToGenerate = 10;
        const int numberOfBuckets = 11;
        static Random rand = new Random();
        static void Main(string[] args)
        {
            MyDataList[] bucketSort = new MyDataList[numberOfBuckets];
            //MyDataList<MyDataList>
            double[] numbers = new double[numbersToGenerate];
            double[] numbersBucket = new double[numberOfBuckets];
            generateDouble(ref numbers);
            MyDataList[] doubleNumbers = new MyDataList[numberOfBuckets];
            for (int i = 0; i < numberOfBuckets; i++)
                doubleNumbers[i] = new MyDataList();



            Console.WriteLine("Linked List spausdinimai: ");
            addNumbersToLinkedList(ref doubleNumbers, numbers);
            printLinkedList(doubleNumbers);
            InsertionSort(ref doubleNumbers);
            printLinkedList(doubleNumbers);



            Console.WriteLine("Array spausdinimai: ");
            printArray(numbers);
            Console.WriteLine("");
            addNumbersToBucket(ref numbersBucket, numbers);
            //InsertionSort(ref numbersBucket);
            //printArray(numbers);
            //InsertionSort(numbers[]);
        }


        public static void printLinkedList(MyDataList[] doubleNumbers)
        {
            Console.WriteLine();
            for (int i = 0; i < numberOfBuckets; i++)
            {
                Console.Write(i + " : ");
                doubleNumbers[i].printAllData();
                Console.Write("    length: " + doubleNumbers[i].getCount());
                Console.WriteLine();

            }
        }

        public static void printArray(double[] numbers)
        {
            Console.WriteLine();
            for (int i = 0; i < numbers.Length; i++)
            {
                Console.Write(numbers[i] + " ");
            }
        }

        public static void InsertionSort(ref MyDataList[] doubleLinkedList)
        {
            for (int z = 0; z < numberOfBuckets; z++)
            {
                MyDataList items = doubleLinkedList[z];
                double currentdata;
                int n = items.getCount();
                for (int i = 1; i < n; ++i)
                {
                    currentdata = items.getData(i);
                    int j = i - 1;


                    while (j >= 0 && items.getData(j) > currentdata)
                    {
                        items.Swap(j + 1, items.getData(j));
                        j = j - 1;
                    }
                    items.Swap(j + 1, currentdata);
                }
            }

        }

        //public static void InsertionSortArray(ref double[] numbers)
        //{
        //    for (int z = 0; z < numberOfLinkedLists; z++)
        //    {
        //        MyDataList items = doubleLinkedList[z];
        //        double currentdata;
        //        int n = items.getCount();
        //        for (int i = 1; i < n; ++i)
        //        {
        //            currentdata = items.getData(i);
        //            int j = i - 1;


        //            while (j >= 0 && items.getData(j) > currentdata)
        //            {
        //                items.Swap(j + 1, items.getData(j));
        //                j = j - 1;
        //            }
        //            items.Swap(j + 1, currentdata);
        //        }
        //    }

        //}

        public static void addNumbersToLinkedList(ref MyDataList[] doubleNumbers, double[] numbers)
        {
            for (int i = 0; i < numbers.Length; i++)
            {
                double currentNumberInFloat = convertNumbersToDouble(numbers[i]);

                Console.Write(currentNumberInFloat + " ");

                for (int j = 0; j < numberOfBuckets; j++)
                {
                    int firstNumber = getFirstNumber(currentNumberInFloat);
                    if (firstNumber == j)
                    {
                        doubleNumbers[j].Push(currentNumberInFloat);
                        break;
                    }
                }
            }
        }

        public static void addNumbersToBucket(ref double[] numbersBucket, double[] numbers)
        {
            for (int i = 0; i < numbers.Length; i++)
            {
                double currentNumberInFloat = convertNumbersToDouble(numbers[i]);

                Console.Write(currentNumberInFloat + " ");

                for (int j = 0; j < numberOfBuckets; j++)
                {
                    int firstNumber = getFirstNumber(currentNumberInFloat);
                    if (firstNumber == j)
                    {
                        numbersBucket[j]=(currentNumberInFloat);
                        break;
                    }
                }
            }
        }


        public static void generateDouble(ref double[] numArray)
        {
            for (int i = 0; i < numbersToGenerate; i++)
            {
                numArray[i] = (rand.NextDouble() * (max - min) + min);
            }
        }

        public static double convertNumbersToDouble(double numberToConvert)
        {
            return Math.Round(((numberToConvert - min) / (max - min)), 2);

        }

        public static int getFirstNumber(double number)
        {
            return (int)(number * 10);
        }
    }
}
