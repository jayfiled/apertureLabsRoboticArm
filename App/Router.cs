using System;

namespace apertureLabsRoboticArm
{
    class Router
    {
        //Initialize an instance of the robot arm
        public void Run()
        {
            PrintWelcomeMessage();
            Console.Write(PrintWelcomeMessage());
            // Create a run function that:
                // prints a welcome message
                // shows the operator a list of commands they can do
                // and loops while the user wants to keep using the arm
            
            // Function that executes the operators commands on the robot arm
        }

        private String PrintWelcomeMessage()
        {
            return( 
                    @"
                    ------------
                    Welcome to Aperture labs
                    Please select one of the following commands to get started.
                    ------------"
            );
        }
    }
}