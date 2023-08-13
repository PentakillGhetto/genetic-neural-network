using System.Drawing;
using System.Numerics;

namespace NeuralNetworks
{
    class Dot
    {
        public Vector2 Start { get; set; }
        public Vector2 CurrentPosition { get; set; }
        public Vector2 Velocity { get; set; }
        public Vector2 Acceleration { get; set; }
        public Vector2 Goal { get; set; }
        public Direction Direction { get; set; }
        public bool IsDead;
        public bool IsReachedGoal;
        public bool IsBest;
        public float Fitness { get; private set; }

        public Dot() : this (Vector2.Zero, new Vector2(10, 10))
        {

        }

        public Dot(Vector2 goal, Vector2 start)
        {
            CurrentPosition = start;
            Velocity = Vector2.Zero;
            Goal = goal;
            Direction = new Direction(100);
        }

        /// <summary>
        /// Moves the dot according to the brains directions
        /// </summary>
        public void Move()
        {
            // if there are still directions left...
            if (Direction.Current < Direction.Array.Length)
            {
                // then set the acceleration as the next vector in the direcitons array
                Acceleration = Direction.Array[Direction.Current];
                Direction.Current++;
            }
            else
            {
                // if at the end of the directions array then the dot is dead
                IsDead = true;
                return;
            }

            Velocity = Vector2.Add(Velocity, Acceleration);

            // add velocity to current position
            CurrentPosition = Vector2.Add(CurrentPosition, Velocity);
        }

        /// <summary>
        /// Calls the move function and check for collisions
        /// </summary>
        public void Update(int width, int height)
        {
            if (!IsDead && !IsReachedGoal)
            {
                Move();
                if (CurrentPosition.X < 1 || CurrentPosition.Y < 1 || CurrentPosition.X > width || CurrentPosition.Y > height)
                {
                    IsDead = true;
                }
                else if (Vector2.Distance(CurrentPosition, Goal) < 5)
                {
                    IsReachedGoal = true;
                }
            }
        }


        public void CalculateFitness()
        {
            if (IsReachedGoal)
            {
                //if the dot reached the goal then the fitness is based on the amount of steps it took to get there
                Fitness = 1f + 100.0f/Direction.Current;
            }
            else
            {
                float f = Vector2.Distance(Start, Goal);
                //if the dot didn't reach the goal then the fitness is based on how close it is to the goal
                float distanceToGoal = Vector2.Distance(CurrentPosition, Goal);
                Fitness = (f - distanceToGoal) / f;
            }
        }

        public void Draw(Graphics graphics)
        {
            if (this.IsBest)
            {
                graphics.FillEllipse(new SolidBrush(Color.Green), CurrentPosition.X, CurrentPosition.Y, 8, 8);
            }
            else
            {
                graphics.FillEllipse(new SolidBrush(Color.Black), CurrentPosition.X, CurrentPosition.Y, 4, 4);
            }
        }

        public Dot Clone()
        {
            Dot clone = new Dot();
            clone.Direction = Direction.Clone();
            clone.Goal = Goal;
            return clone;
        }
    }
}
