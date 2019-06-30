using System;

namespace apertureLabsRoboticArm
{
    class LcdScreen
    {
        public void Place()
        {
            Console.WriteLine("Which position from 0 - 4 on the x-axis would you like to start?");
            String xAxisStart = Console.ReadLine();
            Console.WriteLine("Which position from 0 - 4 on the y-axis would you like to start?");
            String yAxisStart = Console.ReadLine();
            return String[] positionXY = {xAxisStart, yAxisStart}
        }
    }
}