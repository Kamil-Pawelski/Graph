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
           
            if(numberOfEdge - 1 < size)
            {
                Console.WriteLine("To less edge to create ");
                return;
            }
            List<int> points = new List<int>();
            for(int i = 0; i < size; i++)
            {
                points.Add(i);
            }
            Random random = new Random();
            int from, to, wage;
            for (int i = (int)(size - 1); i >= 0; i--)
            {
                from = random.Next(i);
                to = points[random.Next(i)];
                while (from == to)
                {
                    from = random.Next(i);
                    to = points[random.Next(i)];
                }
                matrix[from, to] = (uint)random.Next(1000);
                points.Remove(to);
            }
            numberOfEdge -= size;
            
            for(int i = (int)numberOfEdge; i >= 0; i--)
            {
                from = random.Next((int)size);
                to = random.Next((int)size);
                wage = random.Next(1000);
                while ((from == to) || (matrix[from, to] != null))
                {
                    from = random.Next((int)size);
                    to = random.Next((int)size);
                }

                matrix[from, to] = (uint)wage;
            }
        }
    }


}
