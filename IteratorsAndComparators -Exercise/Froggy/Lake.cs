using System.Collections;
using System.Collections.Generic;

namespace Froggy
{
    class Lake : IEnumerable<int>
    {
        public Lake(int[]stones)
        {
            this.Stones = new List<int>(stones);
        }

        public List<int> Stones { get; }

        public IEnumerator<int> GetEnumerator()
        {
            for (int i = 0; i < this.Stones.Count; i++)
            {
                if (i % 2 == 0)
                {
                    yield return this.Stones[i];
                }
            }

            for (int i = this.Stones.Count-1; i >= 0; i--)
            {
                if (i % 2 != 0)
                {
                    yield return this.Stones[i];
                }
            }       
        }

        IEnumerator IEnumerable.GetEnumerator()
        {
            return this.GetEnumerator();
        }
    }
}
