using System;

namespace apertureLabsRoboticArm
{
    class LcdScreen
    {
        public int[] Place()
        {
            // Create an array to return to the controller as the X and Y Axis co-ords
            int[] positionXY = new int[2];

            // Get inputs, convert to integer and push to array
            Console.WriteLine("Which position from 0 - 4 on the x-axis would you like to start?");
            int xAxisStart = System.Convert.ToInt32(Console.ReadLine());
            positionXY[0] = xAxisStart;
            Console.WriteLine("Which position from 0 - 4 on the y-axis would you like to start?");
            int yAxisStart = System.Convert.ToInt32(Console.ReadLine());
            positionXY[1] = yAxisStart;
            return positionXY;
        }

        public void PlateIsntReady()
        {
            String notReady = "The test tube plate isn't ready yet, please use the place command to set it up before proceeding further.";
            Console.WriteLine(notReady);
        }

        public void SelectionNotWithinPlateBoundary()
        {
            Console.WriteLine(
                @"I'm sorry, that isn't within the boundaries
                of the test tube grid - please choose a number
                between 0 and 4."
                 );
        }
    }
}