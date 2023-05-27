namespace Graf2
{
    class Program
    {
        static void Main(string[] args)
        {
            MatrixGraph matrix = new MatrixGraph(10);
            SecondGraph points = new SecondGraph(10);
            matrix.GenerateConnectedGraph(20);
            matrix.PrintGraph();
            
        }
    }
}