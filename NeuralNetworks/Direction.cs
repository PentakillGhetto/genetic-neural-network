using System;
using System.Numerics;

namespace NeuralNetworks
{
    class Direction
    {
        public Vector2[] Array { get; private set; }
        public int Current { get; set; }
        Random random;

        public Direction(int size)
        {
            Array = new Vector2[size];
            random = new Random();
            Randomize();
        }

        /// <summary>
        /// Sets all the vectors in directions to a random vector with Length 1
        /// </summary>
        void Randomize()
        {
            for (int i = 0; i < Array.Length; i++)
            {
                Array[i] = new Vector2((float)Math.Cos(random.Next(361)), (float)Math.Sin(random.Next(361)));
            }
        }

        /// <summary>
        /// Mutates the direction by setting some of the directions to random vectors
        /// </summary>
        public void Mutate()
        {
            //chance that any vector in directions gets changed
            float mutationRate = 0.1f;

            for (int i = 0; i < Array.Length; i++)
            {
                float probability = random.Next(101) * 1.0f / 100;
                if (probability < mutationRate)
                {
                    Array[i].X = (float)Math.Cos(random.Next(361));
                    Array[i].Y = (float)Math.Sin(random.Next(361));
                }
            }
        }

        public Direction Clone()
        {
            Direction clone = new Direction(Array.Length);
            for (int i = 0; i < Array.Length; i++)
            {
                clone.Array[i] = Array[i];
            }

            return clone;
        }
    }
}
