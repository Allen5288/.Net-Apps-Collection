namespace _180MultidimensionalArrays
{
    internal class Program
    {
        static void Main(string[] args)
        {
            //Declare two-dimensional array
            int[,] array2D = new int[3, 4];  // 3 rows 4 columns two-dimensional array

            //Declare and initialize
            int[,] array2D_another = {
                { 1, 2, 3, 4 },
                { 5, 6, 7, 8 },
                { 9, 10, 11, 12 }
            };

            // Access elements of two-dimensional array

            int value = array2D[1, 2];  // Access second row third column element, result is 7

            //Traverse two-dimensional array
            array2D[2, 3] = 15;  // Modify third row fourth column value to 15

            for (int i = 0; i < array2D.GetLength(0); i++)  // Traverse rows
            {
                for (int j = 0; j < array2D.GetLength(1); j++)  // Traverse columns
                {
                    Console.Write(array2D[i, j] + " ");
                }
                Console.WriteLine();
            }


            int[,,] array3D = new int[3, 3, 3];  // 3x3x3 three-dimensional array


        }
    }
}
