using System;

namespace apertureLabsRoboticArm
{
    class RobotArm
    {
        // Instance variable for current position (x, y).
        public int[] currentPosition = { 0, 0 };

        // Instantiate the classes 'testTubePlate' and 'lcdScreen' for reference within the methods.
        public TestTubePlate testTubePlate = new TestTubePlate();
        public LcdScreen lcdScreen = new LcdScreen();

        // 
        bool keepPromptingForInput = true;

        public void place()
        {
            // To ensure that you can't execute other actions before the place() method.
            testTubePlate.readyForOperation = true;

            // Get input from user about where to place the robot arm and save it to the
            // robot arm's current position.
            try
            {
                currentPosition[0] = loopUntilTrue("x");
                currentPosition[1] = loopUntilTrue("y");
            }
            catch
            {
                lcdScreen.error();
            }

            lcdScreen.ShowCurrentPosition(currentPosition);
        }

        public void detect(int posX, int posY)
        {
            // Checks if the testTubePlate is ready for operation.
            if (isPlateReady())
            {
                if (testTubePlate.grid[posY][posX] == 1)
                {
                    lcdScreen.ShowTestTubeFullStatus(1);
                }
                else
                {
                    lcdScreen.ShowTestTubeFullStatus(0);
                }
                // Check y first, then check the X'th element of it
                // if it's a 1 then it's full, if not it's empty.
            }
            else
            {
                lcdScreen.PlateIsntReady();
            }
        }

        public void drop(int posX, int posY)
        {
            // Checks if the testTubePlate is ready for operation
            if (isPlateReady())
            {
                if (testTubePlate.grid[posY][posX] == 0)
                {
                    testTubePlate.grid[posY][posX] = 1;
                }
                else
                {
                    lcdScreen.ShowTestTubeFullStatus(1);
                }
            }
            else
            {
                lcdScreen.PlateIsntReady();
            }
        }

        public void move()
        {
            // Checks if the testTubePlate is ready for operation
            if (isPlateReady())
            {
                Console.WriteLine("Which directions would you like to move in?");
                Console.WriteLine("Press 'N' to move North (up), 'S' to move South (down), 'E' to move East (right) and 'W' for West (left)");
                String direction = Console.ReadLine().ToUpper();
                switch (direction)
                {
                    case "N":
                        if (isWithinGrid((currentPosition[1] + 1)))
                        {
                            currentPosition[1] += 1;
                        }
                        else
                        {
                            Console.WriteLine("You are at the edge already, please use S, E or W");
                        }
                        lcdScreen.ShowCurrentPosition(currentPosition);
                        break;
                    case "S":
                        if (isWithinGrid((currentPosition[1] - 1)))
                        {
                            currentPosition[1] -= 1;
                        }
                        else
                        {
                            Console.WriteLine("You are at the edge already, please use N, E or W");
                        }
                        lcdScreen.ShowCurrentPosition(currentPosition);
                        break;
                    case "E":
                        if (isWithinGrid((currentPosition[0] + 1)))
                        {
                            currentPosition[0] += 1;
                        }
                        else
                        {
                            Console.WriteLine("You are at the edge already, please use N, S or W");
                        }
                        lcdScreen.ShowCurrentPosition(currentPosition);
                        break;
                    case "W":
                        if (isWithinGrid((currentPosition[0] - 1)))
                        {
                            currentPosition[0] -= 1;
                        }
                        else
                        {
                            Console.WriteLine("You are at the edge already, please use N, S or E");
                        }
                        lcdScreen.ShowCurrentPosition(currentPosition);
                        break;
                    default:
                        Console.WriteLine("Please choose the letters N, S, E or W");
                        break;
                }

            }
            else
            {
                lcdScreen.PlateIsntReady();
            }
        }

        public void report(int posX, int posY)
        {
            // Checks if the testTubePlate is ready for operation
            if (isPlateReady())
            {
                lcdScreen.ShowCurrentPosition(currentPosition);

                // checks the status of the test tube in the current position 
                if (testTubePlate.grid[posY][posX] == 0)
                {
                    lcdScreen.ShowTestTubeFullStatus(0);
                }
                else
                {
                    lcdScreen.ShowTestTubeFullStatus(1);
                }
            }
            else
            {
                lcdScreen.PlateIsntReady();
            }

        }

        // Below are the helper methods to check the state of things within the app.

        // A loop to keep prompting the user if their placement of the 
        // arm is within the test tube grid.
        public int loopUntilTrue(string axis)
        {
            int axisPositionInput;
            do
            {
                axisPositionInput = lcdScreen.getPlacement(axis);
                if (isWithinGrid(axisPositionInput))
                {
                    keepPromptingForInput = false;
                    lcdScreen.inputWithinGrid("ok");
                }
                else
                {
                    keepPromptingForInput = true;
                    lcdScreen.inputWithinGrid(axis);
                }
            } while (keepPromptingForInput);

            return axisPositionInput;
        }

        // A method to ensure that you call the place action first.
        public bool isPlateReady()
        {
            if (testTubePlate.readyForOperation == true)
            {
                return true;
            }
            else
            {
                return false;
            }
        }

        // Method to check if input is within the test tube grid boundaries.
        public static bool isWithinGrid(int position)
        {
            int innerEdgeOfTheGrid = 0;
            int outerEdgeOfTheGrid = 4;

            if (position >= innerEdgeOfTheGrid && position <= outerEdgeOfTheGrid)
            {
                return true;
            }
            else
            {
                return false;
            }
        }
    }
}