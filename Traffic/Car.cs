namespace CARS
{
    using System;

    public class Car
    {
        private int x;
        private int y;

        public Car(int x, int y, ConsoleColor color)
        {
            this.X = x;
            this.Y = y;
            this.Color = color;
        }

        public int X
        {
            get
            {
                return this.x;
            }
            private set
            {
                if (value < 0 ||
                    this.X > Constants.PlayfieldWidth - Constants.CarWidth)
                {
                    throw new ArgumentOutOfRangeException("X coordinate is out of range");
                }

                this.x = value;
            }
        }

        public int Y
        {
            get
            {
                return this.y;
            }
            private set
            {
                if (value < 0 || 
                    value > Constants.PlayfieldHeight - Constants.CarHeight)
                {
                    throw new ArgumentOutOfRangeException("Y coordinate is out of range");
                }

                this.y = value;
            }
        }

        public ConsoleColor Color { get; private set; }

        public void Print()
        {
            Console.ForegroundColor = this.Color;
            for (int row = 0; row < Constants.CarHeight; row++)
            {
                Console.SetCursorPosition(this.X, this.Y + row);
                Console.Write(Constants.CarModel[row]);
            }
        }

        public void Move(ConsoleKey direction)
        {
            switch (direction)
            {
                case ConsoleKey.LeftArrow:
                    if (this.X > 0)
                    {
                        this.X -= Constants.CarWidth;
                    }
                    break;
                case ConsoleKey.RightArrow:
                    if (this.X < Constants.PlayfieldWidth - Constants.CarWidth)
                    {
                        this.X += Constants.CarWidth;
                    }
                    break;
                case ConsoleKey.DownArrow:
                    if (this.Y < Constants.PlayfieldHeight - Constants.CarHeight)
                    {
                        this.Y++;
                    }
                    break;
                default:
                    break;
            }
        }
    }
}