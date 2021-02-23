
namespace Threeuple
{
    class MyThreeuple<T1, T2, T3>
    {
        public MyThreeuple(T1 firstElement, T2 secondElement, T3 thirdElement)
        {
            this.FirstElement = firstElement;
            this.SecondElement = secondElement;
            this.ThirdElement = thirdElement;
        }

        public T1 FirstElement { get; set; }
        public T2 SecondElement { get; set; }
        public T3 ThirdElement { get; set; }

        public override string ToString()   
        {
            return $"{this.FirstElement} -> {this.SecondElement} -> {this.ThirdElement}";
        }
    }
}
