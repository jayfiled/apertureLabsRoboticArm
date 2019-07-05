using System;

namespace apertureLabsRoboticArm
{
    class Router
    {
        // Set instance variables.
        public bool running = true;
        RobotArm robotArm = new RobotArm();
        // A loop to display the program's menu after every completed action path. 
        public void run()
        {
            Console.WriteLine(printWelcomeMessage());

            while (running == true)
            {
                displayMenu();
                // Get the action the user wants to perform and run it over a switch statement. 
                try
                {
                    int menuChoice = System.Convert.ToInt32(Console.ReadLine());
                    routeAction(menuChoice);
                }
                catch
                {
                    LcdScreen.error();
                }
            }
            Console.WriteLine(printFarewellMessage());
        }

        String[] actions = {
            "PLACE the robot arm to get started",
            "DETECT if the test tube is full or empty",
            "DROP some solution in the test tube",
            "MOVE the one position N, S, E or W",
            "REPORT the current position and status of test tube below",
            "EXIT operation of Robotic Arm"
        };

        private void routeAction(int menuChoice)
        {
            switch (menuChoice)
            {
                case 1:
                    robotArm.place();
                    break;
                case 2:
                    robotArm.detect(robotArm.currentPosition[0], robotArm.currentPosition[1]);
                    break;
                case 3:
                    robotArm.drop(robotArm.currentPosition[0], robotArm.currentPosition[1]);
                    break;
                case 4:
                    robotArm.move();
                    break;
                case 5:
                    robotArm.report(robotArm.currentPosition[0], robotArm.currentPosition[1]);
                    break;
                case 6:
                    stop();
                    break;
                default:
                    Console.WriteLine("Please choose 1, 2, 3, 4, 5 or 6");
                    break;
            }
        }

        private void displayMenu()
        {
            // Loop over the array of actions and print them out with a number prefix. 
            for (int i = 0; i < actions.Length; i++)
            {
                string action = actions[i];
                Console.WriteLine("{0}: {1}", i + 1, action);
            }
            Console.WriteLine("   >> ");
        }

        private void stop()
        {
            running = false;
        }

        private String printWelcomeMessage()
        {
            return (
                    @"
                    ------------------------
                    Welcome to Aperture labs
                    Please enter the number that corresponds with one of the following commands:
                    ------------------------
                    "
            );
        }

        private String printFarewellMessage()
        {
            return (
                    @"
                    ------------------------
                    Goodbye, thank you for using Aperture's Robotic Arms
                    ------------------------"
            );
        }
    }
}