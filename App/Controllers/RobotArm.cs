using System;

namespace apertureLabsRoboticArm
{
    class RobotArm
    {
    // Instance variable for current position (x, y)
        public int[] currentPosition = { 0, 0 };


    // Instantiate the testTubePlate
        public TestTubePlate plate = new TestTubePlate();


    // Instantiate the view
        public LcdScreen LcdScreen = new LcdScreen();


    // Each method will ask the view for input if necessary

        public void Place()
        {
            // Sets the plate object's 'readyForOperation' instance variable to true
            plate.readyForOperation = true;
            // Checks the boundaries

            // Get input from User about where to place the robot arm and save it to the
            // robot arm's current position
            int[] moveTo = LcdScreen.Place();
            currentPosition[0] = moveTo[0];
            currentPosition[1] = moveTo[1];
    
            LcdScreen.ShowCurrentPosition(currentPosition);
        }

        public void Detect(int posX, int posY)
        {
            // Checks if the plate is ready for operation
            if (IsPlateIsReady())
            {                
                if (plate.grid[posY][posX] == 1)
                {
                    LcdScreen.ShowTestTubeFullStatus(1);
                }
                else
                {
                    LcdScreen.ShowTestTubeFullStatus(0);
                }
                // Check y first, then check the X'th element of it
                // if it's a 1 then it's full, if not it's empty.
            }
            else
            {
                LcdScreen.PlateIsntReady();
            }    
        }

        public void Drop()
        {
            // Checks if the plate is ready for operation
            if (IsPlateIsReady())
            {
                // Checks the boundaries
                // if (isWithinGrid)
                //{
                    // Do the drop method
                //}
                //else
                //{
                    // Ask LCD screen to say it isn't within the grid
                //}
            }
            else
            {
                LcdScreen.PlateIsntReady();
            }    
        }

        public void Move()
        {
            // Checks if the plate is ready for operation
            if (IsPlateIsReady())
            {
                // Checks the boundaries
                // if (isWithinGrid)
                //{
                    // Do the move method
                //}
                //else
                //{
                    // Ask LCD screen to say it isn't within the grid
                //}
            }
            else
            {
                LcdScreen.PlateIsntReady();
            } 
        }

        public void Report()
        {
            // Checks if the plate is ready for operation
            if (IsPlateIsReady())
            {
                // Checks the boundaries
                // if (isWithinGrid)
                //{
                    // Do the detect method
                //}
                //else
                //{
                    // Ask LCD screen to say it isn't within the grid
                //}
            }
            else
            {
                LcdScreen.PlateIsntReady();
            } 

        }

        // Method to check the state of the readyForOperation var in TestTubePlate

        public bool IsPlateIsReady()
        {
            if (plate.readyForOperation == true)
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