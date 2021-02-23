using System;
using System.Collections;
using System.Collections.Generic;

namespace CustomLinkedList
{
    public class LinkedList<T> : IEnumerable<T>
    {
        public LinkedList()
        {
            this.Head = this.Tail = default;
            this.Count = 0;
        }

        private class Node
        {
            public Node(Node previousNode, T value, Node nextNode)
            {
                this.PreviousNode = previousNode;
                this.Value = value;
                this.NextNode = nextNode;
            }

            public Node PreviousNode { get; set; }
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
                this.Head = this.Tail = new Node(null, element, null);
                this.Count++;
            }
            else
            {
                var newNode = new Node(null, element, this.Head);
                this.Head.PreviousNode = newNode;
                this.Head = newNode;
                this.Count++;
            }
        }

        public void AddLast(T element)
        {
            if (this.Count == 0)
            {
                this.Head = this.Tail = new Node(null, element, null);
                this.Count++;
            }
            else
            {
                var newNode = new Node(this.Tail, element, null);
                this.Tail.NextNode = newNode;
                this.Tail = newNode;
                this.Count++;
            }
        }

        public T RemoveFirst()
        {
            if (this.Count == 0)
            {
                throw new Exception("Doubly list is empty!");
            }
            var firstNode = this.Head;
            var secondNode = this.Head.NextNode;
            secondNode.PreviousNode = null;
            firstNode.NextNode = null;
            this.Head = secondNode;
            this.Count--;
            return firstNode.Value;
        }

        public T RemoveLast()
        {
            if (this.Count == 0)
            {
                throw new Exception("Doubly list is empty!");
            }
            var lastNode = this.Tail;
            var previousNode = this.Tail.PreviousNode;
            previousNode.NextNode = null;
            lastNode.PreviousNode = null;
            this.Tail = previousNode;
            this.Count--;
            return lastNode.Value;
        }

        public IEnumerator<T> GetEnumerator()
        {
            var currentNode = this.Head;
            for (int i = 0; i < this.Count; i++)
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
            var newArray = new T[this.Count];
            var currentNode = this.Head;
            for (int i = 0; i <= newArray.Length - 1; i++)
            {
                newArray[i] = currentNode.Value;
                currentNode = currentNode.NextNode;
            }
            return newArray;
        }
    }
}
