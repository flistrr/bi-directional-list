using System;
using System.Collections;
using System.Collections.Generic;
using BiDirectionalList.Exceptions;

namespace BiDirectionalList
{
    class BiDirectionalList : IEnumerable<double>
    {
        private Node? head;
        private Node? tail;

        

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

        public int FindFirstEntryOfElementBelowAvarage(){
            if(this == null) throw new EmptyListException();
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
            if(this == null) throw new EmptyListException();
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
            if(this == null) throw new EmptyListException();
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
            if(this == null) throw new EmptyListException();
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
            if(this == null) throw new EmptyListException();
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

    
}