using System;

namespace ThaiGame
{
    public class Bone
    {
        private static readonly Random Rnd = new Random();
        private int _number;

        public int Number
        {
            get => _number;
            set
            {
                if (value < 1 || value > 6)
                    throw new ArgumentOutOfRangeException(nameof(Number));
                _number = value;
            }
        }

        public int ThrowBone() => Number = Rnd.Next(1, 6);

        public static int operator +(Bone bone1, Bone bone2) => bone1.Number + bone2.Number;
    }
}