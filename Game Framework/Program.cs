using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Game_Framework
{
    class Program
    {      
        static void Main(string[] args)
        {

            
            Game game = new Game();
            game.Run();
        }

        static void Examples()
        {

            
            Console.WriteLine(new Matrix3(1, 4, 7, 2, 5, 8, 3, 6, 9) * new Matrix3(9, 6, 3, 8, 5, 2, 7, 4, 1));
            Console.WriteLine();
            Console.WriteLine(new Matrix3(90, 54, 18, 114, 69, 24, 138, 84, 30) * new Vector3(2, 4, 6));


            /*
             Vector3 up  = new Vector3(0f, 1f, 0f);

            Vector3 playerLoc = new Vector3(10f, 0f, 18f);
            Vector3 enemyLoc = new Vector3(-7.5f, 0f, 9f);
            Vector3 enemyDir = new Vector3(0.857f, 0f, -0.514f);
            Vector3 enemyForward = new Vector3(0.857f, 9f, -0.514f); 


            Vector3 enemyToPlayer = playerLoc - enemyLoc;

            Console.WriteLine("Distance from enemy to player: " + enemyToPlayer);

            if (enemyDir.Dot(enemyToPlayer) > 0)
            {
                Console.WriteLine("Player is in front of enemy");
            }
            else
            {
                Console.WriteLine("Player is behind the enemy");
            }

            Vector3 enemyLeft = enemyDir.Cross(up);

            if (enemyLeft.Dot(enemyToPlayer) > 0)
            {
                Console.WriteLine("Player is to the left of the enemy");
            }               
            else
            {
                Console.WriteLine("Player is to the right of ther enemy");
            }

            if (enemyForward.Angle(enemyToPlayer) <= Math.PI / 4 || enemyForward.Angle(enemyToPlayer) >= 7 * Math.PI / 4)
            {
                Console.WriteLine("I'VE GOT YOU IN MY SIGHTS");
            }

            */
            Console.ReadKey();
        }
    }
}
