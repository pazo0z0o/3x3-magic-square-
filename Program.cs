using System;
using System.Collections;
using System.Collections.Generic;
using System.Linq;
using System.Runtime.CompilerServices;
using System.Text;
using System.Threading.Tasks;

// {every column, row and diagonal must have the same sum}
//for a 3x3 matrix: 1 + 2 + 3 + 4 + 5 + 6 + 7 + 8 + 9 = 45 / 3 = 15 <---sum we want
//First we arrange them in a grid  in the way shown bellow. 
namespace LoShuMagicSQ
{
    public class sfunc
    {
        public void LoShuSwap(int[,] arr)
        {
            int temp = arr[0, 0];
            arr[0, 0] = arr[2, 2];
            arr[2, 2] = temp;       //swaped 00 and 22

            temp = arr[0, 2];
            arr[0, 2] = arr[2, 0];
            arr[2, 0] = temp; // swaped 02 and 20

        }

        public void sqShow(int i, int j, int[,] arr)
        {
            for (i = 0; i < 3; i++)
            {
                for (j = 0; j < 3; j++)
                {

                    Console.Write($" {arr[i, j]} ");
                }
                Console.WriteLine("\n ");
            }

        }
        public void Verify(int[,] arr)
        {
            int n, m,diag1=0,diag2=0;
           // first we sum  the Lines 
            for ( n = 0; n < 3; n++)
            {
                int sumL = 0;
                for ( m = 0; m < 3; m++)
                {
                    sumL = arr[n,0] + arr[n,1] + arr[n,2];
                   // int sumLines = arr[n, m];
                   // sumL += sumLines;                    
                }
                Console.WriteLine($"Sum of Line {n}: {arr[n,0]} + {arr[n,1]} + {arr[n,2]} = {sumL}");                
            }
            Console.WriteLine("------------------------------");
            // then the Rows 
            for ( m = 0; m < 3; m++)
            {
                int sumR = 0;
                for ( n = 0; n < 3; n++)
                {
                    int sumRows = arr[n, m];
                    sumR += sumRows;
                }
                Console.WriteLine($"Sum of Row {m}: {arr[0,m]} + {arr[1,m]} + {arr[2,m]} = {sumR}");
            }
            Console.WriteLine("------------------------------");

            // int diagonal1 = arr[0,0] + arr[1,1] + arr[2,2];
            // int diagonal2 = arr[2,0] + arr[1,1] + arr[0,2];
            for( n=0;n<3;n++)
            {                              
                 diag1 = diag1 +  arr[n, n];
                 diag2 = diag2 + arr[n, 3 -n -1];
            }
            Console.WriteLine($"Sum of Main Diagonal: {diag1}\n" +
                $"Sum of Off Diagonal: {diag2}");
        }
    
    }

    internal class Program
    {
        static void Main(string[] args)
        {
            Console.WriteLine("Implementation of a 3x3 magic square with the  Lo Shu method."); 
            //We start by 
            int i = 0, j = 0;
            int[,] arr = new int[3, 3]
            {
                {7,4,1},
                {8,5,2},
                {9,6,3}
            };
            
            //first let's show our user the matrix 
            sfunc sq = new sfunc();
            sq.sqShow(i, j, arr);
            
            Console.WriteLine("First step of LoShu method: swap the numbers of the 2 diagonal corners like this : 00<-->22 and 02<-->20.");
            sq.LoShuSwap(arr);
            Console.WriteLine("After the Lo Shu swap the array looks like this ... \n");
            sq.sqShow(i, j, arr);

            Console.WriteLine("Now we need to rotate counter clockwise all the outer column's/line's values, leaving the center (5) square untouched! \n" +
                "I ll start from top left corner (3). \n");
            
            //I'll use a queue to store elements to be swaped temporarily
            int corn00 = arr[0, 0];
            Queue q = new Queue();
            q.Enqueue(corn00);
            
                for (i = 1; i <= 2; i++)
                {
                    q.Enqueue((int)arr[i, 0]);
                    arr[i, 0] = (int)q.Dequeue();

                }
                    for (j = 1; j <= 2; j++)
                    {
                        q.Enqueue((int)arr[2, j]);
                        arr[2, j] = (int)q.Dequeue();

                    }
                    for (i = 1; i >= 0; i--)
                    {
                        q.Enqueue((int)arr[i, 2]);
                        arr[i, 2] = (int)q.Dequeue();

                    }

                    for (j = 1; j >= 0; j--)
                    {
                        q.Enqueue((int)arr[0, j]);
                        arr[0, j] = (int)q.Dequeue();
                       
                    }
                  q.Clear();
                

            Console.WriteLine("The final form of our magic sqare solution, for the 3x3 ordered grid looks like this....\n");
            sq.sqShow(i, j, arr);

            Console.WriteLine("Even though we don't need to, let's verify for the non believers: ");
            sq.Verify(arr);

            //Console.WriteLine("It will work even if you swap r1<-->r3, L1 <--> L3 ");
        }

    }
}




