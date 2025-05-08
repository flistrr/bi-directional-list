using System;
using System.Collections;
using System.Collections.Generic;

namespace List
{
    class BiDirectionalList : IEnumerable<double>
    {
        private Node? head;
        private Node? tail;

        public double FindAvarage(){
            if(this == null) throw new EmptyListException();
            int count = 0;
            double sum = 0;
            foreach (var item in this){
                count++;
                sum += item;
            }
            return sum/count;
        }

        public void AddToBeginning(double data)
        {
            Node newNode = new Node(data);
            if (head != null)
            {
                newNode.Next = head;
                head.Prev = newNode;
            }
            head = newNode;
            if (tail == null)
            {
                tail = newNode;
            }
        }

        public int FindFirstEntryOfElementBelowAvarage(){
            var current = head;
            if(current == null) throw new EmptyListException();
            int index = 0;
            while(current != null){
                if(current.Data < FindAvarage()){
                    return index;
                }
                current = current.Next;
                index++;
            }
            return index;
        }

        public double FindMaxElement(){
            var current = head;
            if(current == null) throw new EmptyListException();
            double max = 0;
            while(current != null){
                if(current.Data > max){
                    max = current.Data;
                }
                current = current.Next;
            }
            return max;
        }

        public double FindSumAfterMaxElement(){
            var current = tail;
            double result = 0;
            while(current != null){
                if(current.Data == FindMaxElement()){
                    return result;
                }
                result += current.Data;
                current = current.Prev;
            }
            return result;
        }


        public BiDirectionalList NewListGreaterThanNumber(double number){
            var newBiDirectionalList = new BiDirectionalList();
            var current = head;
            while(current != null){
                if(current.Data > number){
                    newBiDirectionalList.AddToBeginning(current.Data);
                }
                current = current.Next;
            }
            
            return newBiDirectionalList;
        }

        public BiDirectionalList NewListWithoutElementsBeforeMax(){
            var newBiDirectionalList = new BiDirectionalList();
            var current = tail;
            while(current.Data != FindMaxElement()){
                newBiDirectionalList.AddToBeginning(current.Data);
                current = current.Prev;
            }
            newBiDirectionalList.AddToBeginning(FindMaxElement());
            return newBiDirectionalList;
        }

        public IEnumerator<double> GetEnumerator()
        {
            var current = head;
            while (current != null)
            {
                yield return current.Data;
                current = current.Next;
            }
        }

        IEnumerator IEnumerable.GetEnumerator() => GetEnumerator();
    }

    class Program
    {
        static void Main(string[] args)
        {
            BiDirectionalList list = new BiDirectionalList();

            Random rng = new Random();

            for (int i = 0; i < 5; i++)
            {
                list.AddToBeginning(Math.Round(rng.NextDouble() * 10, 2));
            }
            
            int index = list.FindFirstEntryOfElementBelowAvarage();

            foreach (double item in list)
            {
                if(index == 0) {
                    Console.WriteLine(item + " <- first element below avarage =)");
                }
                else{
                    Console.WriteLine(item);
                }
                index--;
            }          

            Console.WriteLine("Avarage: " + Math.Round(list.FindAvarage(), 2));
            Console.WriteLine("Max element: " + Math.Round(list.FindMaxElement(), 2));
            Console.WriteLine("Sum after max element: " + Math.Round(list.FindSumAfterMaxElement(), 2));


            
            Console.WriteLine("Enter the number to create a new list from the first one but without elements below it: ");
            double yourNumber = Convert.ToDouble(Console.ReadLine());

            var newList = list.NewListGreaterThanNumber(yourNumber);
            Console.WriteLine("New list with elements greater than " + yourNumber + ": ");

            foreach (double item in newList)
            {
                Console.WriteLine(item);
            }

            var newList2 = list.NewListWithoutElementsBeforeMax();
            Console.WriteLine("New list without elements before max element: ");

            foreach (double item in newList2)
            {
                Console.WriteLine(item);
            }
        }
    }
}

