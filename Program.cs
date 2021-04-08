﻿using System;
using System.Collections.Generic;
using System.IO;
using System.Text;
namespace ASA_lab1
{
    class Program
    {
        const int min = 10;
        const int max = 1000;
        const int generatedNumbersToGenerate = 11;
        const int numberOfBuckets = 11;
        static Random rand = new Random();
        static RB redBlack = new RB();
        static double[] generatedNumbers = new double[generatedNumbersToGenerate];
        static void Main(string[] args)
        {
            generateDouble(ref generatedNumbers);
            //linkedListOperations();
            //arrayOperations();
            redBlackTreeOperations();
        }

        public static void redBlackTreeOperations()
        {
            RB redBlack = new RB();
            for (int i = 0; i < generatedNumbers.Length; i++)
            {
                if (i % 2 == 0)
                {
                    redBlack.Insert(generatedNumbers[i]);
                }
            }
            Console.WriteLine(redBlack.Print(redBlack.root));
            for (int i = 0; i < generatedNumbers.Length; i++)
            {
                redBlack.Find(generatedNumbers[i]);
            }
        }
        public static void arrayOperations()
        {
            double[,] buckets = new double[numberOfBuckets,generatedNumbersToGenerate];
            addNumbersToBucketArray(ref buckets, generatedNumbers);
            printDoubleArray(buckets);
            Console.WriteLine();
            InsertionSortArray(ref buckets);
        }
        public static void printDoubleArray(double[,] buckets)
        {
            for (int i = 0; i < numberOfBuckets; i++)
            {
                Console.Write(i + ".  ");
                for (int j = 0; j < generatedNumbersToGenerate; j++)
                {
                    
                    if (buckets[i, j] != 0)
                    {
                        Console.Write( buckets[i, j] + " ---> ");
                    }
                }
                Console.WriteLine();
            }
        }

        public static void InsertionSortArray(ref double[,] buckets)
        {
            for (int i = 0; i < numberOfBuckets; i++)
            {
                double[] items = returnArrayRow(buckets,i);
                double currentdata;
                int n = items.Length;
                for (int z = 1; z < n; ++z)
                {
                    currentdata = items[z];
                    int j = z - 1;


                    while (j >= 0 && items[j] > currentdata)
                    {
                        items[j + 1] = items[j];
                        j = j - 1;
                    }
                    items[j + 1] = currentdata;
                }
                Console.Write(i + ".  ");
                printArray(items);
            }

        }
        public static double[] returnArrayRow(double[,] buckets, int row)
        {
            double[] newArray = new double[generatedNumbersToGenerate];
            for (int i = 0; i < generatedNumbersToGenerate; i++)
            {
                newArray[i] = buckets[row, i];
            }
            return newArray;
        }

        public static void addNumbersToBucketArray(ref double[,] buckets, double[] generatedNumbers)
        {
            for (int i = 0; i < generatedNumbers.Length; i++)
            {
                double convertedNumber = convertNumbersToDouble(generatedNumbers[i]);

                Console.Write(convertedNumber + " ");
                for (int j = 0; j < numberOfBuckets; j++)
                {
                    int firstNumber = getFirstNumber(convertedNumber);
                    if (firstNumber == j)
                    {
                        int indx2 = returnIndex(buckets,j);
                        buckets[j,indx2] = convertedNumber;
                        break;
                    }
                }
            }
            Console.WriteLine();
        }
        public static int returnIndex(double[,] buckets, int row)
        {
            double[] newArray = new double[generatedNumbersToGenerate];
            for (int i = 0; i < generatedNumbersToGenerate; i++)
            {
                if (buckets[row,i]==0)
                {
                    return i;
                }
            }
            return -1;
        }
        public static void linkedListOperations()
        {
            MyDataList buckets = new MyDataList();
            for (double i = 0; i < numberOfBuckets; i++)
                buckets.Push(i);

            //printLinkedList(buckets);

            Console.WriteLine("Linked List spausdinimai: ");

            addNumbersToLinkedList(ref buckets, generatedNumbers);
            InsertionSortLinkedList(ref buckets);
            printLinkedList(buckets);
            //foreach (double item in generatedNumbers)
            //{
            //    Console.WriteLine(item + ", ");
            //}

            reverseConvert(buckets);

            //redBlackTreeLinkedList(generatedNumbers);
            
            //InsertionSort(ref generatedNumbersBucket);
            //printArray(generatedNumbers);
            //InsertionSort(generatedNumbers[]);
        }

        public static void reverseConvert(MyDataList buckets)
        {
            for (int i = 0; i < numberOfBuckets; i++)
            {
                MyDataList bucket = buckets.getListedList(i);
                for (int j = 0; j < bucket.getCount(); j++)
                {
                    double reversedValue = convertDoubleToNumbers(bucket.getData(j));
                    Console.Write(reversedValue + ", ");
                }
                Console.WriteLine();
            }

        }
        public static void printLinkedList(MyDataList buckets)
        {
            Console.WriteLine();
            buckets.printSurface();
        }

        public static void printArray(double[] generatedNumbers)
        {
            for (int i = 0; i < generatedNumbers.Length; i++)
            {
                if (generatedNumbers[i]!=0)
                Console.Write(generatedNumbers[i] + " ---> ");
            }
            Console.WriteLine();
        }

        public static void InsertionSortLinkedList(ref MyDataList bucketList)
        {
            for (int z = 0; z < numberOfBuckets; z++)
            {
                MyDataList items = bucketList.getListedList(z);
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

        public static void addNumbersToLinkedList(ref MyDataList buckets, double[] generatedNumbers)
        {
            for (int i = 0; i < generatedNumbers.Length; i++)
            {
                double currentNumberInFloat = convertNumbersToDouble(generatedNumbers[i]);

                Console.Write(currentNumberInFloat + " ");

                for (int j = 0; j < numberOfBuckets; j++)
                {
                    int firstNumber = getFirstNumber(currentNumberInFloat);
                    if (firstNumber == j)
                    {
                        buckets.PushByIndexNode(j,currentNumberInFloat);
                        break;
                    }
                }
            }
        }

        public static void generateDouble(ref double[] numArray)
        {
            for (int i = 0; i < generatedNumbersToGenerate; i++)
            {
                numArray[i] = Math.Round((rand.NextDouble() * (max - min) + min),3);
            }
        }

        public static double convertNumbersToDouble(double numberToConvert)
        {
            return Math.Round(((numberToConvert - min) / (max - min)), 2);

        }
        
        public static double convertDoubleToNumbers(double doubleToConvert)
        {
            return Math.Round(((doubleToConvert * (max - min) + min)), 2);
        }

        public static int getFirstNumber(double number)
        {
            return (int)(number * 10);
        }
    }
}
