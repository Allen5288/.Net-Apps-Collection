using System;

namespace SmallConsoleGameMapPlayer
{
    class Program
    {
        // Constants for map symbols
        const int PlayerA = 1;
        const int PlayerB = 2;
        const int Mine = 3;
        const int SpaceTimeTunnel = 4;
        const int LuckyRoulette = 5;
        const int Pause = 6;
        const int EmptyBlock = 0;

        // Map size
        const int MapSize = 100;

        static void Main(string[] args)
        {
            // Display game title and instructions
            DisplayGameTitle();
            
            // Initialize map
            int[] map = InitializeMap();
            
            // Player positions
            int playerAPosition = 0;
            int playerBPosition = 0;
            
            // Game state
            bool gameOver = false;
            bool playerATurn = true;
            bool playerAPaused = false;
            bool playerBPaused = false;
            
            // Main game loop
            while (!gameOver)
            {
                Console.Clear();
                
                // Display map
                DrawMap(map, playerAPosition, playerBPosition);
                
                // Check win condition
                if (playerAPosition >= MapSize - 1)
                {
                    Console.WriteLine("\nPlayer A wins!");
                    gameOver = true;
                    continue;
                }
                else if (playerBPosition >= MapSize - 1)
                {
                    Console.WriteLine("\nPlayer B wins!");
                    gameOver = true;
                    continue;
                }
                
                // Determine current player
                char currentPlayer = playerATurn ? 'A' : 'B';
                int currentPosition = playerATurn ? playerAPosition : playerBPosition;
                
                // Check if current player is paused
                if ((playerATurn && playerAPaused) || (!playerATurn && playerBPaused))
                {
                    Console.WriteLine($"\nPlayer {currentPlayer} is paused for this turn.");
                    if (playerATurn)
                        playerAPaused = false;
                    else
                        playerBPaused = false;
                    
                    playerATurn = !playerATurn;
                    Console.WriteLine("Press any key to continue...");
                    Console.ReadKey();
                    continue;
                }
                
                Console.WriteLine($"\nPlayer {currentPlayer}'s turn.");
                Console.WriteLine("Press any key to roll the dice...");
                Console.ReadKey();
                
                // Roll dice (1-6)
                Random random = new Random();
                int steps = random.Next(1, 7);
                Console.WriteLine($"Player {currentPlayer} rolled a {steps}!");
                
                // Update position
                if (playerATurn)
                {
                    playerAPosition += steps;
                    if (playerAPosition >= MapSize) 
                        playerAPosition = MapSize - 1;
                }
                else
                {
                    playerBPosition += steps;
                    if (playerBPosition >= MapSize) 
                        playerBPosition = MapSize - 1;
                }
                
                // Process map events
                if (playerATurn)
                {
                    ProcessMapEvent(map, ref playerAPosition, ref playerBPosition, playerATurn, ref playerAPaused, ref playerBPaused);
                }
                else
                {
                    ProcessMapEvent(map, ref playerBPosition, ref playerAPosition, playerATurn, ref playerBPaused, ref playerAPaused);
                }
                
                // Check for player collision
                if (playerAPosition == playerBPosition && playerAPosition > 0)
                {
                    if (playerATurn)
                    {
                        Console.WriteLine("Player A landed on Player B! Player B moves back 6 spaces!");
                        playerBPosition -= 6;
                        if (playerBPosition < 0) playerBPosition = 0;
                    }
                    else
                    {
                        Console.WriteLine("Player B landed on Player A! Player A moves back 6 spaces!");
                        playerAPosition -= 6;
                        if (playerAPosition < 0) playerAPosition = 0;
                    }
                }
                
                // Switch turns
                playerATurn = !playerATurn;
                
                Console.WriteLine("Press any key to continue...");
                Console.ReadKey();
            }
            
            Console.WriteLine("\nGame Over! Thanks for playing!");
            Console.WriteLine("Press any key to exit...");
            Console.ReadKey();
        }
        
        static void DisplayGameTitle()
        {
            Console.Clear();
            Console.WriteLine("======================================");
            Console.WriteLine("        MAP PLAYER ADVENTURE         ");
            Console.WriteLine("======================================");
            Console.WriteLine("\nWelcome to Map Player Adventure!");
            Console.WriteLine("\nGame Rules:");
            Console.WriteLine("• Players take turns rolling a dice (1-6) to move.");
            Console.WriteLine("• Landing on another player: The other player moves back 6 spaces.");
            Console.WriteLine("• Mine (X): Move back 6 spaces.");
            Console.WriteLine("• Space-Time Tunnel (O): Move forward 10 spaces.");
            Console.WriteLine("• Lucky Roulette (L): Either swap positions or make opponent move back 6 spaces.");
            Console.WriteLine("• Pause (P): Skip next turn.");
            Console.WriteLine("• Empty Block ([]): Nothing happens.");
            Console.WriteLine("• First player to reach the end wins!");
            Console.WriteLine("\nSymbols:");
            Console.WriteLine("A: Player A");
            Console.WriteLine("B: Player B");
            Console.WriteLine("X: Mine");
            Console.WriteLine("O: Space-Time Tunnel");
            Console.WriteLine("L: Lucky Roulette");
            Console.WriteLine("P: Pause");
            Console.WriteLine("[]: Empty Block");
            Console.WriteLine("\nPress any key to start the game...");
            Console.ReadKey();
        }
        
        static int[] InitializeMap()
        {
            int[] map = new int[MapSize];
            
            // Initialize all blocks as empty
            for (int i = 0; i < MapSize; i++)
            {
                map[i] = EmptyBlock;
            }
            
            // Add special events randomly
            Random random = new Random();
            
            // Add mines (10% of map)
            AddSpecialEvents(map, Mine, MapSize / 10, random);
            
            // Add space-time tunnels (5% of map)
            AddSpecialEvents(map, SpaceTimeTunnel, MapSize / 20, random);
            
            // Add lucky roulettes (5% of map)
            AddSpecialEvents(map, LuckyRoulette, MapSize / 20, random);
            
            // Add pauses (5% of map)
            AddSpecialEvents(map, Pause, MapSize / 20, random);
            
            return map;
        }
        
        static void AddSpecialEvents(int[] map, int eventType, int count, Random random)
        {
            int added = 0;
            while (added < count)
            {
                int position = random.Next(1, MapSize - 1); // Don't place on start or end
                if (map[position] == EmptyBlock)
                {
                    map[position] = eventType;
                    added++;
                }
            }
        }
        
        static void DrawMap(int[] map, int playerAPosition, int playerBPosition)
        {
            Console.WriteLine("\n--- Game Map ---\n");
            
            // Draw the map in sections of 20 blocks per line
            const int blocksPerLine = 20;
            
            for (int i = 0; i < MapSize; i += blocksPerLine)
            {
                for (int j = i; j < i + blocksPerLine && j < MapSize; j++)
                {
                    // If player is here, show player symbol
                    if (j == playerAPosition && j == playerBPosition)
                    {
                        Console.Write("AB "); // Both players on same spot
                    }
                    else if (j == playerAPosition)
                    {
                        Console.Write("A  "); // Player A
                    }
                    else if (j == playerBPosition)
                    {
                        Console.Write("B  "); // Player B
                    }
                    else
                    {
                        // Otherwise show map symbol
                        switch (map[j])
                        {
                            case Mine:
                                Console.Write("X  ");
                                break;
                            case SpaceTimeTunnel:
                                Console.Write("O  ");
                                break;
                            case LuckyRoulette:
                                Console.Write("L  ");
                                break;
                            case Pause:
                                Console.Write("P  ");
                                break;
                            default:
                                Console.Write("[] ");
                                break;
                        }
                    }
                }
                Console.WriteLine();
            }
            
            // Display player positions
            Console.WriteLine($"\nPlayer A position: {playerAPosition + 1}/{MapSize}");
            Console.WriteLine($"Player B position: {playerBPosition + 1}/{MapSize}");
        }
        
        static void ProcessMapEvent(int[] map, ref int activePlayerPosition, ref int otherPlayerPosition, bool isPlayerA, ref bool activePlayerPaused, ref bool otherPlayerPaused)
        {
            char activePlayerChar = isPlayerA ? 'A' : 'B';
            char otherPlayerChar = isPlayerA ? 'B' : 'A';
            
            // Check the map element at the player's position
            switch (map[activePlayerPosition])
            {
                case Mine:
                    Console.WriteLine($"Player {activePlayerChar} stepped on a Mine! Moving back 6 spaces.");
                    activePlayerPosition -= 6;
                    if (activePlayerPosition < 0) activePlayerPosition = 0;
                    break;
                    
                case SpaceTimeTunnel:
                    Console.WriteLine($"Player {activePlayerChar} entered a Space-Time Tunnel! Moving forward 10 spaces.");
                    activePlayerPosition += 10;
                    if (activePlayerPosition >= MapSize) activePlayerPosition = MapSize - 1;
                    break;
                    
                case LuckyRoulette:
                    Console.WriteLine($"Player {activePlayerChar} spun the Lucky Roulette!");
                    Random random = new Random();
                    bool swapPositions = random.Next(2) == 0;
                    
                    if (swapPositions)
                    {
                        Console.WriteLine($"Positions swapped between Player {activePlayerChar} and Player {otherPlayerChar}!");
                        int temp = activePlayerPosition;
                        activePlayerPosition = otherPlayerPosition;
                        otherPlayerPosition = temp;
                    }
                    else
                    {
                        Console.WriteLine($"Player {activePlayerChar} bombed Player {otherPlayerChar}! Player {otherPlayerChar} moves back 6 spaces.");
                        otherPlayerPosition -= 6;
                        if (otherPlayerPosition < 0) otherPlayerPosition = 0;
                    }
                    break;
                    
                case Pause:
                    Console.WriteLine($"Player {activePlayerChar} landed on Pause! Will skip next turn.");
                    activePlayerPaused = true;
                    break;
                    
                default:
                    // Empty block, nothing happens
                    break;
            }
        }
    }
}
