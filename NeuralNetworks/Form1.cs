using System;
using System.Drawing;
using System.Windows.Forms;
using System.Numerics;

namespace NeuralNetworks
{
    public partial class Form1 : Form
    {
        Population population;
        Vector2 start;
        Vector2 goal;
        Graphics graphics;
        Timer timer;

        public Form1()
        {
            InitializeComponent();
            goal = new Vector2(PanelDrawingArea.Width - 10, PanelDrawingArea.Height - 10);
            start = new Vector2(10, 10);
            population = new Population(30, goal, start);
            population.Width = PanelDrawingArea.Width;
            population.Height = PanelDrawingArea.Height;
            graphics = PanelDrawingArea.CreateGraphics();
            timer = new Timer();
            timer.Tick += Timer_Tick;
            KeyDown += Form1_KeyDown;
            KeyUp += Form1_KeyUp;
            timer.Interval = 20;
            timer.Start();
        }

        private void Form1_KeyUp(object sender, KeyEventArgs e)
        {
            if (e.KeyCode == Keys.Space) timer.Start();
        }

        private void Form1_KeyDown(object sender, KeyEventArgs e)
        {
            if (e.KeyCode == Keys.Space) timer.Stop();
        }

        private void Timer_Tick(object sender, EventArgs e)
        {
            PanelDrawingArea.Refresh();

            if (population.IsAllDotsDead())
            {
                population.CalculateFitness();
                labelBestDotFintess.Text = "Fitness лучшей точки: " + population.dots[population.bestDotIndex].Fitness.ToString();
                population.NaturalSelection();
                population.Mutate();
                labelGenCount.Text = "Поколение: " + population.GenerationCount.ToString();

            }
            else
            {
                population.Update();
                labelBestDotStepCount.Text = "Кол-во шагов лучшей точки: " + population.dots[population.bestDotIndex].Direction.Current.ToString();
            }
        }

        private void PanelDrawingArea_Paint(object sender, PaintEventArgs e)
        {
            graphics.FillEllipse(new SolidBrush(Color.Red), goal.X, goal.Y, 10, 10);
            population.Draw(graphics);
        }
    }
}
