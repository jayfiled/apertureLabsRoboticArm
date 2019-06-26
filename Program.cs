using System;

namespace apertureLabsRoboticArm
{
    class Program
    {
        static void Main(string[] args)
        {
            // Test that an instance of router.cs can be created
                // Should have a run function
                // Should print welcome message
            //Start the router
            Router r = new Router();
            r.Run();
        }
    }
}
