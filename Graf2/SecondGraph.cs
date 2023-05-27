using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Graf2
{
    public class SecondGraph
    {
        private Dictionary<uint, List<Edge>> points;
        private uint size;
        public SecondGraph(uint size) { 
            points = new Dictionary<uint, List<Edge>>();
            this.size = size;
            for (uint i = 0; i < size; i++)
            {
                points[i] = new List<Edge>();
            }
        }

        public void AddEdge(uint from, uint to, uint wage)
        {
            try
            {
                if(to >= size)
                {
                    throw new IndexOutOfRangeException();
                }

                points[from].Add(new Edge(to, wage));
            }
            catch (IndexOutOfRangeException e)
            {
                Console.WriteLine(e.Message);
            }
        }

        public void PrintEdgesFromPoint(uint point)
        {
            try
            {
                Console.WriteLine($"Edges for {point}");
                foreach(Edge edge in points[point])
                {
                    Console.WriteLine($"[{point},{edge.End}] = {edge.Wage}");
                }
            }
            catch (IndexOutOfRangeException e)
            {
                Console.WriteLine(e.Message);
            }
        }
    }
}
