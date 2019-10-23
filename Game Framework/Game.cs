using Game_Framework;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using Raylib;
using RL = Raylib.Raylib;
using System.IO;

namespace Game_Framework
{
    class Game
    {
        public static readonly int SizeX = 16;
        public static readonly int SizeY = 16;
        //whether or not the Game should finish Running and exit
        public static bool Gameover = false;

        private static Scene _currentScene;

        public Game()
        {
            RL.InitWindow(640, 640, "Hello World");
            RL.SetTargetFPS(15);
           
        }

        private void Init()
        {
            //make rooms
            Room startingroom = LoadRoom("StartRoom.txt");
            Room northRoom = LoadRoom("Room2.txt");

            Enemy enemy = new Enemy("enemy.png");
            void StartNorthRoom()
            {
                enemy.X = 4;
                enemy.Y = 4;
            }

            northRoom.OnStart += StartNorthRoom;
            startingroom.North = northRoom;
            //add walls in startingroom
            startingroom.AddEntity(new Wall(0, 0));
            startingroom.AddEntity(new Wall(1, 0));
            startingroom.AddEntity(new Wall(3, 0));
            startingroom.AddEntity(new Wall(4, 0));
            startingroom.AddEntity(new Wall(5, 0));
            startingroom.AddEntity(new Wall(6, 0));
            //add walls in nothroom
            for (int i = 0; i < northRoom.SizeX; i++)
            {
                if (i != 2)
                {
                    northRoom.AddEntity(new Wall(i, northRoom.SizeY - 1));
                }
            }
            for (int i = 0; i < northRoom.SizeX; i++)
            {
                northRoom.AddEntity(new Wall(i, 0));
            }
            for (int i = 1; i < northRoom.SizeY - 1; i++)
            {
                northRoom.AddEntity(new Wall(0, i));
            }
            for (int i = 1; i < northRoom.SizeY - 1; i++)
            {
                northRoom.AddEntity(new Wall(northRoom.SizeX - 1, i));
            }
            //add walls in startingroom
            for (int i = 0; i < startingroom.SizeX; i++)
            {
                if (i != 2)
                {
                    startingroom.AddEntity(new Wall(i, 0));
                }
            }
            for (int i = 0; i < startingroom.SizeX; i++)
            {
                startingroom.AddEntity(new Wall(i, startingroom.SizeY - 1));
            }
            for (int i = 1; i < startingroom.SizeY - 1; i++)
            {
                startingroom.AddEntity(new Wall(0, i));
            }
            for (int i = 1; i < startingroom.SizeY - 1; i++)
            {
                startingroom.AddEntity(new Wall(startingroom.SizeX - 1, i));
            }

            //add player
            Player player = new Player("player.png");
            player.X = 15;
            player.Y = 15;

            //add enemy to northroom
            startingroom.AddEntity(player);
            northRoom.AddEntity(enemy);

            CurrentScene = startingroom;
        }

        public void Run()
        {
            Init();

            //bind exit to escape
            //PlayerInput.AddKeyEvent(Exit, ConsoleKey.Escape);




            //Loop until the game is over
            while (!Gameover && !RL.WindowShouldClose())
            {
                _currentScene.Update();

                RL.BeginDrawing();                
                _currentScene.Draw();
                RL.EndDrawing();

                PlayerInput.ReadKey();
            }

            RL.CloseWindow();
        }
        public static Scene CurrentScene
        {
            set
            {
                _currentScene = value;
                _currentScene.Start();
            }
            get
            {
                return _currentScene;
            }
        }

        //Exit program
        public void Exit()
        {
            Game.Gameover = true;
        }
        
        private Room LoadRoom(string path)
        {
            StreamReader reader = new StreamReader(path);

            int width, height;
            Int32.TryParse(reader.ReadLine(), out width);
            Int32.TryParse(reader.ReadLine(), out height);

            Room room = new Room(width, height);

            for (int y = 0; y < height; y++)
            {
                for (int x = 0; x < width; x++)
                {
                    if (reader.ReadLine() == "1")
                    {
                        room.AddEntity(new Wall(x, y));
                    }
                    if (reader.ReadLine() == "@")
                    {
                        Player player = new Player("player.jpg");
                        player.X = x;
                        player.Y = y;
                        room.AddEntity(player);
                    }
                    else
                    {
                        Console.WriteLine("Invalid Room Size");
                        Console.ReadKey();
                        return new Room();
                    }
                }
            }
            return room;
        }
       
        private Entity LoadEntity(StreamReader reader)
        {
            string row = reader.ReadLine();
            for (int i = 0; i < row.Length; i++)
            {

            }
        }
    }
}
