using System;
using System.Collections;
using System.Collections.Generic;

namespace LinkedListTraversal
{
    class DoublyLinkedList<T> : IEnumerable<T>
    {
        public DoublyLinkedList()
        {
            this.Head = this.Tail = default;
            this.Count = 0;
        }

        private class Node
        {
            public Node(Node prevNode, T value, Node nextNode)
            {
                this.PrevNode = prevNode;
                this.Value = value;
                this.NextNode = nextNode;
            }
            public Node PrevNode { get; set; }
            public T Value { get; set; }
            public Node NextNode { get; set; }
        }

        private Node Head { get; set; }
        private Node Tail { get; set; }
        public int Count { get; private set; }

        public void Add(T value)
        {
            if (this.Count == 0)
            {
                this.Head = new Node(null, value, null);
                this.Tail = this.Head;
                this.Count = 1;
            }

            else
            {
                Node newNode = new Node(this.Tail, value, null);
                this.Tail.NextNode = newNode;
                this.Tail = newNode;
                this.Count++;
            }
        }

        public bool Remove(T value)
        {
            Node currentNode = this.Head;
            if (this.Count == 0)
            {
                throw new InvalidOperationException();
            }

           else if (this.Count == 1)
            {
                if (currentNode.Value.Equals(value))
                {
                    this.Head = this.Tail = default;
                    this.Count = 0;
                    return true;
                }                  
            }

            else if (this.Count > 1)
            {
                while (currentNode != null)
                {
                    if (currentNode.Value.Equals(value) && currentNode.Equals(this.Head)) // removed element is this.Head
                    {
                        currentNode.NextNode.PrevNode = null;
                        this.Head = currentNode.NextNode;
                        Count--;
                        return true;
                    }

                    else if(currentNode.Value.Equals(value) && currentNode.Equals(this.Tail)) // removed element is this.Tail
                    { 
                        currentNode.PrevNode.NextNode = null;
                        this.Tail = currentNode.PrevNode.NextNode;
                        Count--;
                        return true;
                    }

                    else if (currentNode.Value.Equals(value)) // removed element is in the middle
                    {
                        currentNode.PrevNode.NextNode = currentNode.NextNode;
                        currentNode.NextNode.PrevNode = currentNode.PrevNode;
                        Count--;
                        return true;
                    }

                    currentNode = currentNode.NextNode;
                }
            }

            return false;
        }

        public IEnumerator<T> GetEnumerator()
        {
            Node currentNode = this.Head;

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
    }
}
