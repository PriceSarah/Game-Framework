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
        //Scene currently running
        private static Scene _currentScene;
        //Scene were about to enter
        private static Scene _nextScene;
        //Camera for the 3D view
        private Camera3D _camera;

        public Game()
        {
            RL.InitWindow(640, 640, "Hello World");
            RL.SetTargetFPS(15);

            
        }

        public static Scene CurrentScene
        {
            set
            {
                _nextScene = value;
            }
            get
            {
                return _currentScene;
            }
        }

        private void Init()
        {
            //make rooms
            Room startingroom = LoadRoom("StartRoom.txt");
            Room northRoom = LoadRoom("room2.txt");

            

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

                //Start Scene
                if (_currentScene != _nextScene)
                {
                    _currentScene = _nextScene;
                    _currentScene.Start();
                }

                //Update the active scene
                _currentScene.Update();

                //int mouseX = (RL.GetMouseX() + 640) / 16;
                //int mouseY = (RL.GetMouseY() + 640) / 16;
                //Raylib.Vector3 cameraPosition = new Raylib.Vector3(-10, -10, -10);
                //Raylib.Vector3 cameraTarget = new Raylib.Vector3(mouseX, mouseY, 240);
                //Raylib.Vector3 cameraUp = new Raylib.Vector3(1, 1, 1);

                //_camera = new Camera3D(cameraPosition, cameraTarget, cameraUp);

                RL.BeginDrawing();
                //RL.BeginMode3D(_camera);
                _currentScene.Draw();
                //RL.EndMode3D();
                RL.EndDrawing();
            }

            RL.CloseWindow();
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
                string row = reader.ReadLine();
                for (int x = 0; x < width; x++)
                {
                    char tile = row[x];
                    switch (tile)
                    {
                        case '1':
                            room.AddEntity(new Wall(x, y));
                            break;

                        case '@':
                            Player p = new Player();
                            p.X = x;
                            p.Y = y;
                            room.AddEntity(p);
                            Entity sword = new Entity('/', "images/tile133.png");
                            p.AddChild(sword);
                            sword.X += 0.5f;
                            sword.Y += 0.5f;
                            room.AddEntity(sword);
                            break;
                        case 'e':
                            Enemy e = new Enemy();
                            e.X = x;
                            e.Y = y;
                            room.AddEntity(e);
                            break;
                    }
                   
                }
            }
            return room;
        }
        
    }

    /* private Entity LoadEntity(StreamReader reader)
     {
         char tile = Convert.ToChar(reader.Read());
         switch (tile)
         {
             case 1:
         }
     }*/
}

