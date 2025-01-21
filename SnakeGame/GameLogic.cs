using Microsoft.Xna.Framework;
using Microsoft.Xna.Framework.Input;
using System.Collections.Generic;

namespace SnakeGame
{
    public static class GameLogic
    {
        public static GameState CurrentState = GameState.Menu;
        public static Maps ChoosedMap = Maps.Winter;

        public const int CellSize = 35;
        public const int GridWidth = 17;
        public const int GridHeight = 17;
        private const double MoveInterval = 0.15;

        public static List<Point> Snake = new List<Point>();
        public static Point Food;
        private static Point Direction = new Point(1, 0);

        public static int Score = 0;
        public static int HighScore = 0;
        public static double CountdownTimer = 3;
        private static double MoveTimer = 0;
        public static bool IsGameOver = false;

        public static void ResetGame()
        {
            Snake.Clear();
            Snake.Add(new Point(5, 5));
            Direction = new Point(1, 0);
            Score = 0;
            SpawnFood();
            IsGameOver = false;
            CountdownTimer = 3;
            CurrentState = GameState.Menu;
        }

        public static void Update(GameTime gameTime)
        {
            var keyboard = Keyboard.GetState();

            switch (CurrentState)
            {
                case GameState.Menu:
                    if (keyboard.IsKeyDown(Keys.NumPad1) || keyboard.IsKeyDown(Keys.D1))
                    {
                        CurrentState = GameState.CountdownWinter;
                        ChoosedMap = Maps.Winter;
                    }
                    else if ((keyboard.IsKeyDown(Keys.NumPad2) || keyboard.IsKeyDown(Keys.D2)) && GameLogic.HighScore >= 10)
                    {
                        CurrentState = GameState.CountdownForest;
                        ChoosedMap = Maps.Forest;
                    }
                    break;

                case GameState.CountdownWinter:
                    CountdownTimer -= gameTime.ElapsedGameTime.TotalSeconds;
                    if (CountdownTimer <= 0)
                    {
                        CurrentState = GameState.Playing;
                    }
                    break;
                
                case GameState.CountdownForest:
                    CountdownTimer -= gameTime.ElapsedGameTime.TotalSeconds;
                    if (CountdownTimer <= 0)
                    {
                        CurrentState = GameState.Playing;
                    }
                    break;

                case GameState.Playing:
                    HandleInput();
                    MoveTimer += gameTime.ElapsedGameTime.TotalSeconds;

                    if (MoveTimer >= MoveInterval)
                    {
                        MoveTimer = 0;
                        MoveSnake();
                    }
                    break;

                case GameState.GameOver:
                    if (keyboard.IsKeyDown(Keys.Enter))
                    {
                        ResetGame();
                    }
                    break;
            }
        }

        private static void HandleInput()
        {
            var keyboard = Keyboard.GetState();

            if ((keyboard.IsKeyDown(Keys.Up) || keyboard.IsKeyDown(Keys.W)) && Direction.Y != 1)
                Direction = new Point(0, -1);
            else if ((keyboard.IsKeyDown(Keys.Down) || keyboard.IsKeyDown(Keys.S)) && Direction.Y != -1)
                Direction = new Point(0, 1);
            else if ((keyboard.IsKeyDown(Keys.Left) || keyboard.IsKeyDown(Keys.A)) && Direction.X != 1)
                Direction = new Point(-1, 0);
            else if ((keyboard.IsKeyDown(Keys.Right) || keyboard.IsKeyDown(Keys.D)) && Direction.X != -1)
                Direction = new Point(1, 0);
        }

        private static void MoveSnake()
        {
            var newHead = Snake[0] + Direction;

            if (newHead.X < 0 || newHead.Y < 0 || newHead.X >= GridWidth || newHead.Y >= GridHeight || Snake.Contains(newHead))
            {
                IsGameOver = true;
                CurrentState = GameState.GameOver;
                return;
            }

            Snake.Insert(0, newHead);

            if (newHead == Food)
            {
                AssetLoader.EatSoundInstance.Volume = 0.2f;
                AssetLoader.EatSoundInstance.IsLooped = false;
                AssetLoader.EatSoundInstance.Play();
                if (ChoosedMap == Maps.Winter)
                {
                    Score++;
                } else if (ChoosedMap == Maps.Forest)
                {
                    Score += 2;
                }
                UpdateHighScore();
                SpawnFood();
            }
            else
            {
                Snake.RemoveAt(Snake.Count - 1);
            }
        }

        private static void SpawnFood()
        {
            var random = new System.Random();
            Food = new Point(random.Next(GridWidth), random.Next(GridHeight));
        }

        private static void UpdateHighScore()
        {
            if (Score > HighScore)
            {
                HighScore = Score;
            }
        }
    }
}