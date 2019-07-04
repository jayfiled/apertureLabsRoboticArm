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
            Console.WriteLine(PrintWelcomeMessage());
            while (running == true)
            {
            DisplayMenu();
            string MenuChoice = Console.ReadLine();
            RouteAction(MenuChoice);
            }
            Console.WriteLine(PrintFarewellMessage());
        }

        String[] actions = {
            "PLACE the robot arm to get started",
            "DETECT if the test tube is full or empty",
            "DROP some solution in the test tube",
            "MOVE the one position N, S, E or W",
            "REPORT the current position and status of test tube below",
            "EXIT operation of Robotic Arm"
        };

          private void RouteAction(string MenuChoice)
          {
            switch (MenuChoice)
            {
                case "1":
                    RoboArm.Place();
                    break;
                case "2":
                    RoboArm.Detect(RoboArm.currentPosition[0], RoboArm.currentPosition[1]);
                    break;
                case "3":
                    RoboArm.Drop(RoboArm.currentPosition[0], RoboArm.currentPosition[1]);
                    break;
                case "4":
                    RoboArm.Move();
                    break;
                case "5":
                    RoboArm.Report(RoboArm.currentPosition[0], RoboArm.currentPosition[1]);
                    break;
                case "6":
                    stop();
                    break;
                default:
                    Console.WriteLine("Please choose 1, 2, 3, 4, 5 or 6");
                    break;
            }
          }
        
        private void DisplayMenu() 
        {
            for (int i = 0; i < actions.Length; i++)
            {
                string action = actions[i];
                Console.WriteLine("{0}: {1}",i+1, action);
            }
                Console.WriteLine("   >> ");
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
                    ------------------------
                    Goodbye, thank you for using Aperture's Robotic Arms
                    ------------------------"
            );
        }
    }
}