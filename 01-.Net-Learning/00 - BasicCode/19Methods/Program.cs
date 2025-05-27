namespace _19Methods
{
    internal class Program
    {
        static void Main(string[] args)
        {
            //Console.WriteLine("Super Mario walks and walks, jumps and jumps, hits and hits");
            //Console.WriteLine("Super Mario walks and walks, jumps and jumps, hits and hits");
            //Console.WriteLine("Super Mario walks and walks, jumps and jumps, hits and hits");
            //Console.WriteLine("Super Mario walks and walks, jumps and jumps, hits and hits");
            //Console.WriteLine("Super Mario walks and walks, jumps and jumps, hits and hits");
            //Console.WriteLine("Suddenly, hit an invincible");
            //Console.WriteLine("Screen starts flashing");
            //Console.WriteLine("Play invincible background music");
            //Console.WriteLine("Screen stops");
            //Console.WriteLine("Super Mario walks and walks, jumps and jumps, hits and hits");
            //Console.WriteLine("Super Mario walks and walks, jumps and jumps, hits and hits");
            //Console.WriteLine("Super Mario walks and walks, jumps and jumps, hits and hits");
            //Console.WriteLine("Suddenly, hit an invincible");
            //Console.WriteLine("Screen starts flashing");
            //Console.WriteLine("Play invincible background music");
            //Console.WriteLine("Screen stops");

            //After using methods

            //Flash  Play special background music  Screen stops
            Program.PlayGame();
            Program.Invincible();
            Program.PlayGame();
            Program.PlayGame();
            Program.PlayGame();
            Program.PlayGame();
            Program.Invincible();
            Console.ReadKey();

        }

        /// <summary>
        /// Normal game play
        /// </summary>
        public static void PlayGame()
        {
            Console.WriteLine("Super Mario walks and walks, jumps and jumps, hits and hits");
            Console.WriteLine("Super Mario walks and walks, jumps and jumps, hits and hits");
            Console.WriteLine("Super Mario walks and walks, jumps and jumps, hits and hits");
            Console.WriteLine("Super Mario walks and walks, jumps and jumps, hits and hits");
            Console.WriteLine("Super Mario walks and walks, jumps and jumps, hits and hits");
            Console.WriteLine("Suddenly, hit an invincible");
        }
        /// <summary>
        /// Invincible
        /// </summary>
        public static void Invincible()
        {
            Console.WriteLine("Screen starts flashing");
            Console.WriteLine("Play invincible background music");
            Console.WriteLine("Screen stops");
        }
    }
}
