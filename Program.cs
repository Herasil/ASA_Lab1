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
        const int generatedNumbersToGenerate = 10;
        const int numberOfBuckets = 11;
        static Random rand = new Random();
        static void Main(string[] args)
        {
            MyDataList[] bucketSort = new MyDataList[numberOfBuckets];
            //MyDataList<MyDataList>
            double[] generatedNumbers = new double[generatedNumbersToGenerate];
            double[] generatedNumbersBucket = new double[numberOfBuckets];
            generateDouble(ref generatedNumbers);
       
            MyDataList[] buckets = new MyDataList[numberOfBuckets];
            for (int i = 0; i < numberOfBuckets; i++)
                buckets[i] = new MyDataList();



            Console.WriteLine("Linked List spausdinimai: ");
            addNumbersToLinkedList(ref buckets, generatedNumbers);
            printLinkedList(buckets);
            InsertionSort(ref buckets);
            printLinkedList(buckets);



            Console.WriteLine("Array spausdinimai: ");
            printArray(generatedNumbers);
            Console.WriteLine("");
            addNumbersToBucket(ref generatedNumbersBucket, generatedNumbers);


            //InsertionSort(ref generatedNumbersBucket);
            //printArray(generatedNumbers);
            //InsertionSort(generatedNumbers[]);
        }


        public static void printLinkedList(MyDataList[] buckets)
        {
            Console.WriteLine();
            for (int i = 0; i < numberOfBuckets; i++)
            {
                Console.Write(i + " : ");
                buckets[i].printAllData();
                Console.Write("    length: " + buckets[i].getCount());
                Console.WriteLine();

            }
        }

        public static void printArray(double[] generatedNumbers)
        {
            Console.WriteLine();
            for (int i = 0; i < generatedNumbers.Length; i++)
            {
                Console.Write(generatedNumbers[i] + " ");
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

        //public static void InsertionSortArray(ref double[] generatedNumbers)
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

        public static void addNumbersToLinkedList(ref MyDataList[] buckets, double[] generatedNumbers)
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
                        buckets[j].Push(currentNumberInFloat);
                        break;
                    }
                }
            }
        }

        public static void addNumbersToBucket(ref double[] generatedNumbersBucket, double[] generatedNumbers)
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
                        generatedNumbersBucket[j]=(currentNumberInFloat);
                        break;
                    }
                }
            }
        }


        public static void generateDouble(ref double[] numArray)
        {
            for (int i = 0; i < generatedNumbersToGenerate; i++)
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
