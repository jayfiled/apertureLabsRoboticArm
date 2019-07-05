using System;

namespace apertureLabsRoboticArm
{
    class TestTubePlate
    {
        // Will only be set to true after the place method in RobotArm.
        public bool readyForOperation = false;

        public int[][] grid =
        {
            new int[] { 0, 1, 0, 1, 0 },
            new int[] { 0, 0, 1, 0, 0 },
            new int[] { 1, 0, 0, 0, 1 },
            new int[] { 0, 0, 0, 1, 0 },
            new int[] { 1, 1, 1, 0, 0 },

        };
    }
}