using System;

namespace apertureLabsRoboticArm
{
    class Router
    {
        // Set instance variables
        public bool running = true;
        RobotArm RoboArm = new RobotArm();
        public void Run()
        {
            while (running == true);
            {
            Console.Write(PrintWelcomeMessage());
                // Create a run function that:
                    // shows the operator a list of commands they can do
                    // Save the chosen number to a variable
                    // Run the chosen number over a switch case
                    // That runs a method on the Robot arm instance
            }
            PrintFarewellMessage();
        }

        String[] actions = {
            "PLACE the robot arm to get started",
            "DETECT if the test tube is full or empty",
            "DROP some solution in the test tube",
            "MOVE the one position N, S, E or W",
            "REPORT the current position and status of test tube below",
            "EXIT operation of Robotic Arm"
        };

          private void RouteAction(action)
          {
            switch (action)
            {
                case 1:
                    RoboArm.place;
                    break;
                case 2:
                    RoboArm.detect;
                    break;
                case 3:
                    RoboArm.drop;
                    break;
                case 4:
                    RoboArm.move;
                    break;
                case 5:
                    RoboArm.report;
                    break;
                case 6:
                    stop();
                    break;
                default:
                    Console.WriteLine("Please choose 1, 2, 3, 4, 5 or 6");
                    break;
            }
          }
        
        private void DisplayMenu() 
        {
            // Loop over and print out all the actions, with 
            // the operator presses 1, 2 or 3 etc to choose.
        }

        private void stop() 
        {
            running = false;
        }

        private String PrintWelcomeMessage()
        {
            return( 
                    @"
                    ------------
                    Welcome to Aperture labs
                    Please select one of the following commands:
                    ------------"
            );
        }

        private String PrintFarewellMessage()
        {
            return( 
                    @"
                    ------------
                    Goodbye
                    ------------"
            );
        }
    }
}