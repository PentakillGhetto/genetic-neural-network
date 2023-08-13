using System;
using System.Drawing;
using System.Numerics;

namespace NeuralNetworks
{
    class Population
    {
        public Dot[] dots;
        public int Width { get; set; }
        public int Height { get; set; }
        public float fitnessSum;
        public int GenerationCount { get; private set; }
        public int bestDotIndex = 0;
        public int maxStep = 100;
        Random random;

        public Population(int size, Vector2 goal, Vector2 start)
        {
            dots = new Dot[size];
            for (int i = 0; i < size; i++)
            {
                dots[i] = new Dot(goal, start);
            }
            GenerationCount = 1;
            random = new Random();
        }

        public void Draw(Graphics graphics)
        {
            for (int i = 1; i < dots.Length; i++)
            {
                dots[i].Draw(graphics);
            }
            dots[0].Draw(graphics);
        }

        public void Update()
        {
            for (int i = 0; i < dots.Length; i++)
            {
                if (dots[i].Direction.Current > maxStep)
                {
                    //if the dot has already taken more steps than the best dot has taken to reach the goal
                    dots[i].IsDead = true;//then it dead
                }
                else
                {
                    dots[i].Update(Width, Height);
                }
            }
        }

        public void CalculateFitness()
        {
            for (int i = 0; i < dots.Length; i++)
            {
                dots[i].CalculateFitness();
            }
        }


        //------------------------------------------------------------------------------------------------------------------------------------
        //returns whether all the dots are either dead or have reached the goal
        public bool IsAllDotsDead()
        {
            for (int i = 0; i < dots.Length; i++)
            {
                if (!dots[i].IsDead && !dots[i].IsReachedGoal)
                {
                    return false;
                }
            }

            return true;
        }

        public void NaturalSelection()
        {
            Dot[] newDots = new Dot[dots.Length];//next gen
            SetBestDot();
            CalculateFitnessSum();

            //the champion lives on 
            newDots[0] = dots[bestDotIndex].Clone();
            newDots[0].IsBest = true;
            for (int i = 1; i < newDots.Length; i++)
            {

                //select parent based on fitness
                Dot parent = SelectParent();

                //get baby from them
                newDots[i] = parent.Clone();
            }

            dots = newDots;
            GenerationCount++;
        }

        public void CalculateFitnessSum()
        {
            fitnessSum = 0;
            for (int i = 0; i < dots.Length; i++)
            {
                fitnessSum += dots[i].Fitness;
            }
        }

        //-------------------------------------------------------------------------------------------------------------------------------------

        //chooses dot from the population to return randomly(considering fitness)

        //this function works by randomly choosing a value between 0 and the sum of all the fitnesses
        //then go through all the dots and add their fitness to a running sum and if that sum is greater than the random value generated that dot is chosen
        //since dots with a higher fitness function add more to the running sum then they have a higher chance of being chosen
        private Dot SelectParent()
        {
            float rand = random.Next((int)fitnessSum);


            float runningSum = 0;

            for (int i = 0; i < dots.Length; i++)
            {
                runningSum += dots[i].Fitness;
                if (runningSum >= rand)
                {
                    return dots[i];
                }
            }

            //should never get to this point

            return null;
        }

        //------------------------------------------------------------------------------------------------------------------------------------------
        //mutates all the brains of the babies
        public void Mutate()
        {
            for (int i = 1; i < dots.Length; i++)
            {
                dots[i].Direction.Mutate();
            }
        }

        //---------------------------------------------------------------------------------------------------------------------------------------------
        //finds the dot with the highest fitness and sets it as the best dot
        void SetBestDot()
        {
            float max = 0;
            int maxIndex = 0;
            for (int i = 0; i < dots.Length; i++)
            {
                if (dots[i].Fitness > max)
                {
                    max = dots[i].Fitness;
                    maxIndex = i;
                }
            }

            bestDotIndex = maxIndex;

            //if this dot reached the goal then reset the minimum number of steps it takes to get to the goal
            if (dots[bestDotIndex].IsReachedGoal)
            {
                maxStep = dots[bestDotIndex].Direction.Current;
            }
        }
}
}
