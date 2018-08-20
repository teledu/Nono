using System;

namespace Nono
{
    public class Program
    {
        static void Main(string[] args)
        {
            foreach (var initializer in BoardBuilder.Initializers)
            {
                var board = new Board();
                initializer(board);
                board.Solve();
                Console.WriteLine(board.ToString());
                Console.WriteLine();
                Console.WriteLine("==================================================================");
                Console.WriteLine();
            }
        }
    }
}
