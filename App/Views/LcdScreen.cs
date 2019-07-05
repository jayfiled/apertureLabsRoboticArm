using System;

namespace apertureLabsRoboticArm
{
    class LcdScreen
    {
        public int getPlacement(string axis)
        {
            // Get inputs, convert to integer and push to array
            // while loops to stop and provide feedback if the input is outside the 
            // test tube plate's boundaries.

            Console.WriteLine("Which position from 0 - 4 on the {0}-axis would you like to start?", axis);
            int position = System.Convert.ToInt32(Console.ReadLine());
            return position;
        }

        public void PlateIsntReady()
        {
            String notReady = "The test tube plate isn't ready yet, please use the place command to set it up before proceeding further.";
            Console.WriteLine(notReady);
            Console.WriteLine("--------------------------------------");
            Console.WriteLine("--------------------------------------");
        }

        // Needs error handling for non-ints.
        public bool PlacePostitionWithinPlateBoundary(int positionXorY)
        {
            if (positionXorY >= 0 && positionXorY <= 4)
            {
                return inputWithinGrid("ok");
            }
            else
            {
                return inputWithinGrid("bothOutside");
            }
        }
        public void ShowCurrentPosition(int[] currentPosition)
        {
            Console.WriteLine("You are now at position X: {0}, Y: {1}", currentPosition[0], currentPosition[1]);
            Console.WriteLine("--------------------------------------");
            Console.WriteLine("--------------------------------------");

        }

        public void ShowTestTubeFullStatus(int input)
        {
            if (input == 1)
            {
                Console.WriteLine("It's full");
                Console.WriteLine("--------------------------------------");
            }
            else if (input == 0)
            {
                Console.WriteLine("It's empty");
                Console.WriteLine("--------------------------------------");
            }
            else
            {
                Console.WriteLine("ERR");
                Console.WriteLine("--------------------------------------");

            }
        }

        public bool inputWithinGrid(string status)
        {
            switch (status)
            {
                case "edge":
                    Console.WriteLine("You are at the edge already, please try another direction");
                    return false;
                case "x":
                    Console.WriteLine(
                    @"
                    I'm sorry, the X axis input isn't within the boundaries
                    of the test tube grid - please choose a number
                    between 0 and 4.
                    ");
                    return false;
                case "y":
                    Console.WriteLine(
                    @"
                    I'm sorry, the Y axis input isn't within the boundaries
                    of the test tube grid - please choose a number
                    between 0 and 4.
                    ");
                    return false;
                case "bothOutside":
                    Console.WriteLine(
                    @"I'm sorry, neither the X or the Y axis inputs aren't within the boundaries
                        of the test tube grid - please choose a number
                        between 0 and 4.
                        "
                    );
                    return false;
                case "ok":
                    Console.WriteLine(@"Nice, thanks.
                                    ");
                    return true;
                default:
                    Console.WriteLine("Something went wrong, please restart and try again");
                    return false;
            }

        }

        public static void error()
        {
            Console.WriteLine(@"
                                Error! You are only able to enter numbers! 
                                Please try again.
                                ");
        }
    }
}