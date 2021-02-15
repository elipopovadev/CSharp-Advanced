namespace CreateLinkedList
{
    public class Node
    {
        public Node(int value, Node nextNode)
        {
            this.Value = value;
            this.NextNode = nextNode;
        }

        public int Value { get; set; }
        public Node NextNode { get; set; }
    }
}
