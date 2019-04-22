using System;
using System.Collections;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace CustomQueue
{
    public class MyQueue<T> : IEnumerable<T>
    {
        public IEnumerator<T> GetEnumerator()
        {
            Queue<int> t = new Queue<int>();
            t.Enqueue(12);
            throw new NotImplementedException();
        }

        IEnumerator IEnumerable.GetEnumerator()
        {
            throw new NotImplementedException();
        }
    }
}
