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
        static double[] generatedNumbers = new double[generatedNumbersToGenerate];
        static void Main(string[] args)
        {
            generateDouble(ref generatedNumbers);
            //linkedListOperations();
            arrayOperations();
        }

        public static void arrayOperations()
        {
            double[,] buckets = new double[numberOfBuckets,generatedNumbersToGenerate];
            addNumbersToBucketArray(ref buckets, generatedNumbers);
            for (int i = 0; i < numberOfBuckets; i++)
            {
                Console.Write(i + ".  ");
                for (int j = 0; j < generatedNumbersToGenerate; j++)
                {
                    if (buckets[i,j]!=0)
                    {
                        Console.Write( buckets[i, j] + " ---> ");
                    }

                }
                Console.WriteLine();
            }
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

            //Console.WriteLine("Linked List spausdinimai: ");

            addNumbersToLinkedList(ref buckets, generatedNumbers);
            InsertionSortLinkedList(ref buckets);
            printLinkedList(buckets);
            //foreach (double item in generatedNumbers)
            //{
            //    Console.WriteLine(item + ", ");
            //}

            reverseConvert(buckets);


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
            Console.WriteLine();
            for (int i = 0; i < generatedNumbers.Length; i++)
            {
                Console.Write(generatedNumbers[i] + " ");
            }
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
                numArray[i] = (rand.NextDouble() * (max - min) + min);
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
