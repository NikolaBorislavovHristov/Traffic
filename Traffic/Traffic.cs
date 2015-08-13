namespace CARS
{
    using System;
    using System.Collections.Generic;
    using System.Threading;

    public class Traffic
    {
        public static void Main()
        {
            int score;
            int level;
            int speed;
            Car playerCar;
            List<Car> trafficCars;

            Initialize(out score, out level, out speed, out playerCar, out trafficCars);

            for (int cycle = 0; true; cycle++)
            {
                ConfigureNextLevel(ref score, ref level, ref speed, cycle);

                score = CalculateScore(score, level);

                //every 4th cycle create new traffic car
                if (cycle % Constants.CarHeight == 0)
                {
                    AddRandomTrafficCar(trafficCars);
                }

                ClearField();

                PrintGrid();

                PrintScore(score);

                PrintLevel(level);

                PrintSpeed(speed);

                PrintAllCars(playerCar, trafficCars);

                CheckForCarCrash(playerCar, trafficCars);

                MovePlayerCar(playerCar);

                MoveTrafficCars(trafficCars);

                Sleep(speed);
            }
        }

        private static void Initialize(out int score, out int level, out int speed, out Car playerCar, out List<Car> trafficCars)
        {
            Console.BufferWidth = Console.WindowWidth = Constants.WindowWidth;
            Console.BufferHeight = Console.WindowHeight = Constants.WindowHeight;
            Console.CursorVisible = false;

            score = Constants.InitialScorePoints;
            level = Constants.InitialLevel;
            speed = Constants.InitialSpeedPoints;
            playerCar = new Car(Constants.InitialPlayerXCord, Constants.InitialPlayerYCord, Constants.InitialPlayerColor);
            trafficCars = new List<Car>();
        }

        private static void ConfigureNextLevel(ref int score, ref int level, ref int speed, int cycle)
        {
            if (cycle % Constants.CyclesPerLevel == 0 &&
                cycle != 0)
            {
                score += Constants.BonusPointsPerLevel;
                if (speed < Constants.MaxSpeedPoints)
                {
                    speed += Constants.SpeedPointsPerLevel;
                }
                level++;
            }
        }

        private static int CalculateScore(int score, int level)
        {
            score += Constants.ScorePointsPerCycleInLevel * level;
            return score;
        }

        private static void AddRandomTrafficCar(List<Car> trafficCars)
        {
            Random possitionGenerator = new Random();

            int maxGeneratedPossition = Constants.PlayfieldWidth / Constants.CarWidth;
            //random X possition [0 3 6 9 12 ...]
            int initialTrafficCarXCord = (possitionGenerator.Next(0, maxGeneratedPossition * 100) / 100) * Constants.CarWidth;


            int initialTrafficCarYCord = 0;

            Car newTrafficCar = new Car(initialTrafficCarXCord, initialTrafficCarYCord, Constants.InitialTrafficColor);

            trafficCars.Add(newTrafficCar);
        }

        private static void ClearField()
        {
            Console.Clear();
        }

        private static void PrintGrid()
        {
            Console.ForegroundColor = Constants.GridColor;
            for (int row = 0; row < Constants.PlayfieldHeight; row++)
            {
                Console.SetCursorPosition(Constants.PlayfieldWidth, row);
                Console.Write('|');
            }
        }

        private static void PrintScore(int score)
        {
            Console.ForegroundColor = Constants.ScoreColor;
            Console.SetCursorPosition(Constants.ScoreXCord, Constants.ScoreYCord);
            Console.Write("Score: {0}", score);
        }

        private static void PrintLevel(int level)
        {
            Console.ForegroundColor = Constants.LevelColor;
            Console.SetCursorPosition(Constants.LevelXCord, Constants.LevelYCord);
            Console.Write("Level: {0}", level);
        }

        private static void PrintSpeed(int speed)
        {
            Console.ForegroundColor = Constants.SpeedColor;
            Console.SetCursorPosition(Constants.SpeedXCord, Constants.SpeedYCord);
            Console.Write("Speed: {0}", speed);
        }

        private static void PrintAllCars(Car playerCar, List<Car> trafficCars)
        {
            playerCar.Print();

            foreach (Car car in trafficCars)
            {
                car.Print();
            }
        }

        private static void CheckForCarCrash(Car playerCar, List<Car> trafficCars)
        {
            foreach (Car car in trafficCars)
            {
                if (car.X == playerCar.X &&
                    car.Y > playerCar.Y - Constants.CarHeight)
                {
                    PrintGameOver();
                    Restart();
                }
            }
        }

        private static void Restart()
        {
            Main();
        }

        private static void PrintGameOver()
        {
            Console.SetCursorPosition(Constants.GameOverXCord, Constants.GameOverYCord);
            Console.ForegroundColor = Constants.GameOverColor;
            Console.Write("GAME OVER!");
            Console.SetCursorPosition(Constants.GameOverXCord, Constants.GameOverYCord + 1);
            Console.Write("Press any key!");
            Console.ReadKey();
        }

        private static void MovePlayerCar(Car playerCar)
        {
            ConsoleKeyInfo pressedKey = new ConsoleKeyInfo();
            while (Console.KeyAvailable)
            {
                pressedKey = Console.ReadKey(true);
            }
            if (pressedKey.Key != 0)
            {
                playerCar.Move(pressedKey.Key);
            }
        }

        private static void MoveTrafficCars(List<Car> trafficCars)
        {
            for (int index = 0; index < trafficCars.Count; )
            {
                //if current car reach the bottom of the play field
                if (trafficCars[index].Y == Constants.PlayfieldHeight - Constants.CarHeight)
                {
                    trafficCars.RemoveAt(index);
                }
                else
                {
                    trafficCars[index].Move(ConsoleKey.DownArrow);
                    index++;
                }
            }
        }

        private static void Sleep(int speed)
        {
            int sleep = Constants.InitialSleepPoints - speed;
            Thread.Sleep(sleep);
        }
    }
}
