using System;

namespace apertureLabsRoboticArm
{
    class RobotArm
    {
        // Instance variable for current position (x, y)
        public int[] currentPosition = { 0, 0 };


        // Instantiate the testTubePlate
        public TestTubePlate testTubePlate = new TestTubePlate();


        // Instantiate the view
        public LcdScreen lcdScreen = new LcdScreen();


        // Each method will ask the view for input if necessary

        public void Place()
        {
            // Sets the testTubePlate object's 'readyForOperation' instance variable to true
            testTubePlate.readyForOperation = true;
            // Checks the boundaries

            // Get input from User about where to place the robot arm and save it to the
            // robot arm's current position
            int[] moveTo = lcdScreen.Place();
            currentPosition[0] = moveTo[0];
            currentPosition[1] = moveTo[1];

            lcdScreen.ShowCurrentPosition(currentPosition);
        }

        public void Detect(int posX, int posY)
        {
            // Checks if the testTubePlate is ready for operation
            if (IsPlateIsReady())
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

        public void Drop(int posX, int posY)
        {
            // Checks if the testTubePlate is ready for operation
            if (IsPlateIsReady())
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

        public void Move()
        {
            // Checks if the testTubePlate is ready for operation
            if (IsPlateIsReady())
            {
                Console.WriteLine("Which directions would you like to move in?");
                Console.WriteLine("Press 'N' to move North (up), 'S' to move South (down), 'E' to move East (right) and 'W' for West (left)");
                String direction = Console.ReadLine().ToUpper();
                switch (direction)
                {
                    case "N":
                        if (IsWithinGrid((currentPosition[1] + 1)))
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
                        if (IsWithinGrid((currentPosition[1] - 1)))
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
                        if (IsWithinGrid((currentPosition[0] + 1)))
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
                        if (IsWithinGrid((currentPosition[0] - 1)))
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

        public void Report(int posX, int posY)
        {
            // Checks if the testTubePlate is ready for operation
            if (IsPlateIsReady())
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

        // Method to check the state of the readyForOperation var in TestTubePlate

        public bool IsPlateIsReady()
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

        // Method to check the boundaries

        public bool IsWithinGrid(int positionXorY)
        {
            if (positionXorY >= 0 && positionXorY <= 4)
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