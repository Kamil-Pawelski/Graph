using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Graf2
{
    public struct Edge
    {
        private uint end;
        private uint wage;
        public uint End { get { return end; } }
        public uint Wage { get { return wage; } }
        public Edge(uint end, uint wage)
        {
            this.end = end;
            this.wage = wage;
        }
    }
}
