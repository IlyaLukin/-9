using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace ConsoleApp53
{
    public class DoubleList
    {
        public int data;
        public DoubleList next, last;

        public DoubleList()
        {
            data = 0;
            next = null;
            last = null;
        }

        public DoubleList(int d)
        {
            data = d;
            next = null;
            last = null;
        }

        public override string ToString()
        {
            return data.ToString() + " ";
        }
    }

}
