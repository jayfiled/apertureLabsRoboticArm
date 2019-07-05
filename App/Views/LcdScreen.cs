using System;

namespace apertureLabsRoboticArm
{
    class LcdScreen
    {
        // Interaction for the place menu action.
        public int getPlacement(string axis)
        {
            Console.WriteLine("Which position from 0 - 4 on the {0}-axis would you like to start?", axis);
            int position = System.Convert.ToInt32(Console.ReadLine());
            return position;
        }

        // Feedback if you don't run the place menu action first.
        public void plateIsntReady()
        {
            String notReady = "The test tube plate isn't ready yet, please use the place command to set it up before proceeding further.";
            Console.WriteLine(notReady);
            Console.WriteLine("--------------------------------------");
            Console.WriteLine("--------------------------------------");
        }

        public void showCurrentPosition(int[] currentPosition)
        {
            Console.WriteLine("You are now at position X: {0}, Y: {1}", currentPosition[0], currentPosition[1]);
            Console.WriteLine("--------------------------------------");
            Console.WriteLine("--------------------------------------");

        }

        public void showTestTubeFullStatus(int input)
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

        // A method to handle the different types of errors when input is given that is outside
        // the test tube grid area for the PLACE and MOVE actions in the RobotArm class.
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
                case "ok":
                    Console.WriteLine(@"Nice, thanks.
                                    ");
                    return true;
                default:
                    Console.WriteLine("Something went wrong, please restart and try again");
                    return false;
            }

        }

        public String printAndGetMoveCommands()
        {
            Console.WriteLine("Which directions would you like to move in?");
            Console.WriteLine(@"
                                Press 'N' to move North (up), 'S' to move South (down),
                                'E' to move East (right) and 'W' for West (left)
                                ");
            return Console.ReadLine().ToUpper();
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