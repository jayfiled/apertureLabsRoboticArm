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
            // test tube plate's boundaries.
            do
            {
                Console.WriteLine("Which position from 0 - 4 on the x-axis would you like to start?");
                int xAxisStart = System.Convert.ToInt32(Console.ReadLine());
                if (PlacePostitionWithinPlateBoundary(xAxisStart))
                {
                    continueWhileTrue = false;            
                    positionXY[0] = xAxisStart;
                }
                else
                {
                    continueWhileTrue = true;
                }
            } while (continueWhileTrue);

            do
            {
                Console.WriteLine("Which position from 0 - 4 on the y-axis would you like to start?");
                int yAxisStart = System.Convert.ToInt32(Console.ReadLine());
                if (PlacePostitionWithinPlateBoundary(yAxisStart))
                    {
                        continueWhileTrue = false;
                        positionXY[1] = yAxisStart;
                    }
                    else
                    {
                        continueWhileTrue = true;
                    }
            } while (continueWhileTrue);
            return positionXY;
        }

        public void PlateIsntReady()
        {
            String notReady = "The test tube plate isn't ready yet, please use the place command to set it up before proceeding further.";
            Console.WriteLine(notReady);
        }

        // Needs error handling for non-ints
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
        public void ShowCurrentPosition(int[] currentPosition)
        {
            Console.WriteLine("You are now at position X: {0}, Y: {1}", currentPosition[0], currentPosition[1]);
            Console.WriteLine("--------------------------------------" );
            Console.WriteLine("--------------------------------------" );

        }

        public void ShowTestTubeFullStatus(int input)
        {
            if (input == 1)
            {
                Console.WriteLine("It's full");
            }
            if (input == 0)
            {
                Console.WriteLine("It's empty");
            }
            else
            {
                Console.WriteLine("ERR");
            }
        }
    }
}