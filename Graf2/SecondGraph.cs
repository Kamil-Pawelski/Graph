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

        public void GenerateConnectedGraph(uint numberOfEdge)
        {

            if (numberOfEdge - 1 < size)
            {
                Console.WriteLine("To less edge to create ");
                return;
            }
            List<List<uint>> adjacencyList = new List<List<uint>>();

            for (uint i = 0; i < size; i++)
            {
                List<uint> neighbors = new List<uint>();
                for (uint j = 0; j < size; j++)
                {
                    if (i != j)
                    {
                        neighbors.Add(j);
                    }
                }
                adjacencyList.Add(neighbors);
            }
            List<uint> indices = new List<uint>();
            for (uint i = 0; i < size; i++)
            {
                indices.Add(i);
            }
            Random random = new Random();
            int from, to;
            uint wage;
            for (int i = (int)(size - 1); i >= 0; i--)
            {
                from = random.Next(i);
                to = (int)indices[random.Next(i)];
                while (from == to)
                {
                    from = random.Next(i);
                    to = (int)indices[random.Next(i)];  
                }
                wage = (uint)random.Next(1000);
                points[(uint)from].Add(new Edge((uint)to, wage));
                adjacencyList[from].Remove((uint)to);
                indices.Remove((uint)to);
            }
            indices = new List<uint>();
            for (uint i = 0; i < size; i++)
            {
                indices.Add(i);
            }
            numberOfEdge -= size;
            for (int i = (int)numberOfEdge; i >= 0; i--)
            {
                int fromIndex = random.Next(indices.Count);
                from = (int)indices[fromIndex];
                int fromAdjacencyIndex = random.Next(adjacencyList[from].Count);
                to = (int)adjacencyList[from][fromAdjacencyIndex];
                wage = (uint)random.Next(1000);
                points[(uint)from].Add(new Edge((uint)to, wage));
                adjacencyList[from].RemoveAt(fromAdjacencyIndex);
                if (adjacencyList[from].Count == 0)
                {
                    indices.RemoveAt(fromIndex);
                }
            }
        }
        public void PrintGraph()
        {

            for (uint i = 0; i < size; i++)
            {
                points[i] = points[i].OrderBy(edge => edge.End).ToList();
                foreach (Edge edge in points[i])
                {
                    Console.WriteLine($"[{i},{edge.End}] = {edge.Wage}");
                }
                Console.WriteLine();
            }
        }

        public bool DoesEdgeExist(uint startPoint, uint end)
        {
            if (points.ContainsKey(startPoint))
            {
                List<Edge> edges = points[startPoint];
                foreach (Edge edge in edges)
                {
                    if (edge.End == end)
                    {
                        return true;
                    }
                }
            }

            return false;
        }
    }
}
