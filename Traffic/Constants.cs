namespace CARS
{
    using System;

    public static class Constants
    {
        public const int WindowWidth = 50;
        public const int WindowHeight = 34;
        public const int PlayfieldWidth = 33;
        public const int PlayfieldHeight = WindowHeight;

        public const int InitialPlayerXCord = (PlayfieldWidth / 2) - 1; //in the middle
        public const int InitialPlayerYCord = PlayfieldHeight - 4; // because CarHeight == 4

        public const int ScoreXCord = Constants.PlayfieldWidth + 2;
        public const int ScoreYCord = 5;
        public const int LevelXCord = Constants.ScoreXCord;
        public const int LevelYCord = ScoreYCord + 1;
        public const int SpeedXCord = Constants.ScoreXCord;
        public const int SpeedYCord = LevelYCord + 1;
        public const int GameOverXCord = Constants.ScoreXCord;
        public const int GameOverYCord = SpeedYCord + 1;

        public const int InitialScorePoints = 0;
        public const int InitialLevel = 1;
        public const int ScorePointsPerCycleInLevel = 3;
        public const int CyclesPerLevel = 40;
        public const int BonusPointsPerLevel = 1000;

        public const int InitialSpeedPoints = 30;
        public const int SpeedPointsPerLevel = 30;
        public const int MaxSpeedPoints = 150;

        public const int InitialSleepPoints = MaxSpeedPoints + InitialSpeedPoints;

        public const ConsoleColor InitialPlayerColor = ConsoleColor.Red;
        public const ConsoleColor InitialTrafficColor = ConsoleColor.White;
        public const ConsoleColor GridColor = ConsoleColor.Cyan;
        public const ConsoleColor SpeedColor = ConsoleColor.Green;
        public const ConsoleColor LevelColor = ConsoleColor.Green;
        public const ConsoleColor ScoreColor = ConsoleColor.Green;
        public const ConsoleColor GameOverColor = ConsoleColor.Red;

        public static readonly string[] CarModel = {    
                                                    " # ",
                                                    "###",
                                                    " # ",
                                                    "# #"
                                                 };
        public static readonly int CarWidth = CarModel[0].Length;
        public static readonly int CarHeight = CarModel.Length;        
    }
}
