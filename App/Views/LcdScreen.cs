using System;

namespace apertureLabsRoboticArm
{
    class LcdScreen
    {
        bool continueWhileTrue = true;
        public int[] Place()
        {
            // Create an array to return to the controller as the X and Y Axis co-ords
            int[] positionXY = new int[2];

            // Get inputs, convert to integer and push to array
            // while loops to stop and provide feedback if the input is outside the 
            // test tube plat's boundaries.
            while (continueWhileTrue)
            {
                Console.WriteLine("Which position from 0 - 4 on the x-axis would you like to start?");
                int xAxisStart = System.Convert.ToInt32(Console.ReadLine());
                if (PlacePostitionWithinPlateBoundary(xAxisStart))
                {
                    continueWhileTrue = true;            
                    positionXY[0] = xAxisStart;
                }
                else
                {
                    continueWhileTrue = false;
                }
            }
            // stuck here ... doesn't a while loop check it's condition at the 
            // end to see if it should run again?
            
            while (continueWhileTrue)
            {
                Console.WriteLine("Which position from 0 - 4 on the y-axis would you like to start?");
                int yAxisStart = System.Convert.ToInt32(Console.ReadLine());
                if (PlacePostitionWithinPlateBoundary(yAxisStart))
                    {
                        continueWhileTrue = true;
                        positionXY[1] = yAxisStart;
                    }
                    else
                    {
                        continueWhileTrue = false;
                    }
            }
            return positionXY;
        }

        public void PlateIsntReady()
        {
            String notReady = "The test tube plate isn't ready yet, please use the place command to set it up before proceeding further.";
            Console.WriteLine(notReady);
        }

        public bool PlacePostitionWithinPlateBoundary(int positionXorY)
        {
            if (positionXorY >= 0 && positionXorY <= 4)
            {
                Console.WriteLine("Nice, thanks.");
                return true;
            }
            else
            {
                Console.WriteLine(
                @"I'm sorry, that isn't within the boundaries
                of the test tube grid - please choose a number
                between 0 and 4."
                 );
                 return false;
            }
        }
        }
}