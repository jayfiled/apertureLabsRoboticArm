using System;

namespace apertureLabsRoboticArm
{
    class RobotArm
    {
    // Instance variable for current position (x, y)
        public int[] currentPosition = { 0, 0 };


    // Instantiate the testTubePlate

    // Instantiate the view
        public LcdScreen LcdScreen = new LcdScreen();


    // Each method will ask the view for input if necessary

        public void Place()
        {
            // Sets the plate object's 'set up?' instance variable to true
            // Checks the boundaries

            // Get input from User about where to place the robot arm and save it to the
            // robot arm's current position
            int[] moveTo = LcdScreen.Place();
            currentPosition[0] = moveTo[0];
            currentPosition[1] = moveTo[1];
        }

        public void Detect()
        {
            // Checks for existence of plate obj
            // Checks the boundaries
            Console.WriteLine("Hi from the detect method!");
        }

        public void Drop()
        {
            // Checks for existence of plate obj
            // Checks the boundaries
            Console.WriteLine("Hi from the drop method!");
            
        }

        public void Move()
        {
            // Checks for existence of plate obj
            // Checks the boundaries
            Console.WriteLine("Hi from the move method!");
        }

        public void Report()
        {
            // Checks for existence of plate obj
            // Checks the boundaries
            Console.WriteLine("Hi from the report method!");

        }

        // Method to check the existence of plate Obj
        
        // Method to check the boundaries
    }
}