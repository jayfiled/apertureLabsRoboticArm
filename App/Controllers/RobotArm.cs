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
                LcdScreen.error();
            }

            lcdScreen.showCurrentPosition(currentPosition);
        }

        public void detect(int posX, int posY)
        {
            // Checks if the testTubePlate is ready for operation.
            if (isPlateReady())
            {
                if (testTubePlate.grid[posY][posX] == 1)
                {
                    lcdScreen.showTestTubeFullStatus(1);
                }
                else
                {
                    lcdScreen.showTestTubeFullStatus(0);
                }
                // Check y first, then check the X'th element of it
                // if it's a 1 then it's full, if not it's empty.
            }
            else
            {
                lcdScreen.plateIsntReady();
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
                    lcdScreen.showTestTubeFullStatus(1);
                }
            }
            else
            {
                lcdScreen.plateIsntReady();
            }
        }

        public void move()
        {
            // Checks if the testTubePlate is ready for operation
            if (isPlateReady())
            {
                String direction = lcdScreen.printAndGetMoveCommands();
                switch (direction)
                {
                    case "N":
                        if (isWithinGrid((currentPosition[1] + 1)))
                        {
                            currentPosition[1] += 1;
                        }
                        else
                        {
                            lcdScreen.inputWithinGrid("edge");
                        }
                        lcdScreen.showCurrentPosition(currentPosition);
                        break;
                    case "S":
                        if (isWithinGrid((currentPosition[1] - 1)))
                        {
                            currentPosition[1] -= 1;
                        }
                        else
                        {
                            lcdScreen.inputWithinGrid("edge");
                        }
                        lcdScreen.showCurrentPosition(currentPosition);
                        break;
                    case "E":
                        if (isWithinGrid((currentPosition[0] + 1)))
                        {
                            currentPosition[0] += 1;
                        }
                        else
                        {
                            lcdScreen.inputWithinGrid("edge");
                        }
                        lcdScreen.showCurrentPosition(currentPosition);
                        break;
                    case "W":
                        if (isWithinGrid((currentPosition[0] - 1)))
                        {
                            currentPosition[0] -= 1;
                        }
                        else
                        {
                            lcdScreen.inputWithinGrid("edge");
                        }
                        lcdScreen.showCurrentPosition(currentPosition);
                        break;
                    default:
                        Console.WriteLine("Please choose the letters N, S, E or W");
                        break;
                }

            }
            else
            {
                lcdScreen.plateIsntReady();
            }
        }

        public void report(int posX, int posY)
        {
            // Checks if the testTubePlate is ready for operation
            if (isPlateReady())
            {
                lcdScreen.showCurrentPosition(currentPosition);

                // checks the status of the test tube in the current position 
                if (testTubePlate.grid[posY][posX] == 0)
                {
                    lcdScreen.showTestTubeFullStatus(0);
                }
                else
                {
                    lcdScreen.showTestTubeFullStatus(1);
                }
            }
            else
            {
                lcdScreen.plateIsntReady();
            }

        }

        // Below are the helper methods to check the state of things within the app.

        // A loop to keep prompting the user if their placement of the 
        // arm is within the test tube grid.
        public int loopUntilTrue(string axis)
        {
            bool keepPromptingForInput = true;
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