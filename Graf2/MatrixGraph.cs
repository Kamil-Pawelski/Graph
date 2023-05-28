using System;
using System.Collections.Generic;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Graf2
{
    public class MatrixGraph
    {
        public uint?[,] matrix;
        private uint size;
        private Random random = new Random();

        public MatrixGraph(uint size)
        {
            matrix = new uint?[size, size];
            this.size = size;
            for (int i = 0; i < size; i++)
            {
                for (int j = 0; j < size; j++)
                {
                    matrix[i, j] = null;
                }
            }
        }

        public void AddEdge(uint from, uint to, uint wage)
        {

            try
            {
                if (matrix[from, to] == null)
                    matrix[from, to] = wage;
                
                
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
                for (int i = 0; i < size; i++)
                {
                    if (matrix[point, i] != null)
                        Console.WriteLine($"[{point},{i}] = {matrix[point,i]}");
                }
            }
            catch (IndexOutOfRangeException e)
            {
                Console.WriteLine(e.Message);
            }
        }

        public void PrintGraph()
        {

            for (uint i = 0; i < size; i++)
            {
                for (uint j = 0; j < size; j++)
                {
                    if (matrix[i, j] != null)
                    {
                        Console.WriteLine($"[{i},{j}] = {matrix[i, j]}");
                    }
                }
                Console.WriteLine();
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
            for(uint i = 0; i < size; i++)
            {
                indices.Add(i);
            }
            int from, to, wage;
            for (int i = (int)(size - 1); i >= 0; i--)
            {
                from = random.Next(i);
                to = (int)indices[random.Next(i)];
                while (from == to)
                {
                    from = random.Next(i);
                    to = (int)indices[random.Next(i)];
                }
                matrix[from, to] = (uint)random.Next(1,1000);
                adjacencyList[from].Remove((uint)to);
                indices.Remove((uint)to);
            }
            indices = new List<uint>();
            for (uint i = 0; i < size; i++)
            {
                indices.Add(i);
            }
            numberOfEdge -= size;
            
            for(int i = (int)numberOfEdge; i >= 0; i--)
            {

                int fromIndex = random.Next(indices.Count);
                from = (int)indices[fromIndex];
                int fromAdjacencyIndex = random.Next(adjacencyList[from].Count);
                to = (int)adjacencyList[from][fromAdjacencyIndex];
                wage = random.Next(1,1000);

                matrix[from, to] = (uint)wage;
                adjacencyList[from].RemoveAt(fromAdjacencyIndex);
                if(adjacencyList[from].Count == 0){
                    indices.RemoveAt(fromIndex);
                }
            }
        }

    }


}
