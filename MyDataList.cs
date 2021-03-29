using System;
using System.Collections.Generic;
using System.Text;

namespace ASA_lab1
{
    abstract class DataList
    {
        //protected int length;
        //public int Length { get { return length; } }
        public abstract double Head();
        public abstract double Next();

        public abstract double getData(int z);
        public abstract void Swap(int a, double b);

        //public Tz Data;
        public void Print(int n)
        {
            Console.Write(" {0:F5} ", Head());
            for (int i = 1; i < n; i++)
                Console.Write(" {0:F5} ", Next());
            Console.WriteLine();
        }
    }

    class MyDataList : DataList
    {
       
        MyLinkedListNode headNode;
        MyLinkedListNode prevNode;
        MyLinkedListNode currentNode;
        private int Count;
        //constructor
        public MyDataList()
        {
            Count = 0;
        }

        public void Push(double number)
        {
            if (headNode == null)
                headNode = new MyLinkedListNode(number);
            else
                GetLast().nextNode = new MyLinkedListNode(number);
            Count++;

        }


        //get head
        public override double Head()
        {
            currentNode = headNode;
            prevNode = null;
            return currentNode.data;
        }

        //get node by index
        public override double getData(int z)
        {
            if (z == 0)
                return headNode.data;
            currentNode = headNode;
            for (int i = 1; i < Count; i++)
            {
                currentNode = currentNode.nextNode;
                if (z == i)
                {
                    return currentNode.data;
                }
            }
            return -1;
        }

        public override double Next()
        {
            prevNode = currentNode;
            currentNode = currentNode.nextNode;
            return currentNode.data;
        }
       
        private MyLinkedListNode GetLast()
        {
            MyLinkedListNode node = headNode;
            while(node.nextNode !=  null)
                node = node.nextNode;
            return node;
        }
        public override void Swap(int a, double b)
        {
            Head();
            for (int i = 0; i < Count; i++)
            {
                if (a == i)
                {
                    currentNode.data = b;
                    break;
                }
                Next();

            }
        }


        public int getCount()
        {
            return Count;
        }




        public void printAllData()
        {
            if(headNode != null) { 
            MyLinkedListNode node = headNode;
            Console.Write(node.data + " -> ");
            while (node.nextNode != null)
            {
               
                node = node.nextNode;
                    Console.Write(node.data + " -> ");
                }
            }
            Console.Write("null");
        }

        class MyLinkedListNode
        {
            public MyLinkedListNode nextNode { get; set; }
            public double data { get; set; }
            public MyLinkedListNode(double data)
            {
                this.data = data;
            }
        }
    }
}
