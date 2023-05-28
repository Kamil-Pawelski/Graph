namespace Graf2
{
    class Program
    {
        static void Main(string[] args)
        {
            MatrixGraph matrix = new MatrixGraph(10);
            SecondGraph points = new SecondGraph(10);
            matrix.GenerateConnectedGraph(88);
            matrix.PrintGraph();
            Console.WriteLine("Drugi graf");
            points.GenerateConnectedGraph(88);
            points.PrintGraph();
            
        }
    }
}