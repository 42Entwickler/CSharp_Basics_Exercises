using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace PriorityQueueMA
{
    public enum PersonTypes { Normal, Vip }
    public class MyPriorityQueue
    {
        public double PercentageFilled { get; }
        public int Size { get; }

        public MyPriorityQueue(int size)
        {

        }
        public void Push(string name, PersonTypes type = PersonTypes.Normal)
        {
            throw new NotImplementedException();
        }
        public string Pop()
        {
            return null;
        }
    }
}
