﻿using System;
using System.Collections;
using System.Collections.Generic;

namespace CreateLinkedList 
{
    public class LinkedList<T> : IEnumerable<T>
    {
        public LinkedList()
        {
            this.Head = default;
            this.Tail = default;
            this.Count = 0;
        }
        private class Node
        {
            public Node(T value, Node nextNode)
            {
                this.Value = value;
                this.NextNode = nextNode;
            }

            public T Value { get; set; }
            public Node NextNode { get; set; }
        }
        private Node Head { get; set; }
        private Node Tail { get; set; }
        public int Count { get; private set; }

        public void AddFirst(T element)
        {
            if (this.Count == 0)
            {
                var newNode = new Node(element, null);
                this.Head = this.Tail = newNode;
            }
            else
            {
                var newNode = new Node(element, this.Head);
                this.Head = newNode;
            }
            this.Count++;
        }

        public void AddLast(T element)
        {
            if (this.Count == 0)
            {
                var newNode = new Node(element, null);
                this.Head = this.Tail = newNode;
            }
            else
            {
                var newNode = new Node(element, null);
                this.Tail.NextNode = newNode;
                this.Tail = newNode;
            }
            this.Count++;
        }

        public T RemoveFirst()
        {
            if (this.Head == this.Tail)
            {
                var currentNode = Head;
                this.Head = default;
                this.Tail = default;
                this.Count = 0;
                return currentNode.Value;
            }
            if (this.Count > 1 )
            {
                var previousHeadValue = this.Head.Value;
                var nextNode = this.Head.NextNode;
                this.Head = nextNode;
                this.Count--;
                return previousHeadValue;
            }
            else
            {
                throw new Exception("LinkedList is empty!");
            }
        }

        public T RemoveLast()
        {
            if (this.Head == this.Tail)
            {
                var currentNode = Head;
                this.Head = default;
                this.Tail = default;
                this.Count = 0;
                return currentNode.Value;
            }
            if (this.Count > 1)
            {
                var previousTail = this.Tail;
                var currentNode = this.Head;
                while (currentNode.NextNode != Tail)
                {
                    currentNode = currentNode.NextNode;
                }

                currentNode.NextNode = null;
                this.Count--;
                this.Tail = currentNode;
                return previousTail.Value;
            }

            else
            {
                throw new Exception("LinkedList is empty!");
            }
        }

        public IEnumerator<T> GetEnumerator()
        {
            var currentNode = this.Head;
            while (currentNode != null)
            {            
                yield return currentNode.Value;
                currentNode = currentNode.NextNode;
            }
        }

        IEnumerator IEnumerable.GetEnumerator()
        {
            return GetEnumerator();
        }

        public T[] ToArray()         
        {
            T[] newArray = new T[this.Count];
            var currentNode = this.Head;
            for (int counter = 0; counter < this.Count; counter++)
            {
                newArray[counter] = currentNode.Value;
                currentNode = currentNode.NextNode;
            }

            return newArray;
        }
    }   
}
