using System;

namespace apertureLabsRoboticArm
{
    class TestTubePlate
    {
        // Will only be set to true after the Place method in RobotArm
        public bool readyForOperation = false;

        // The grid of test tubes
        // public int[] Row4 = { 1, 1, 1, 0, 0 };

        // public int[] Row3 = { 0, 0, 0, 1, 0 };

        // public int[] Row2 = { 1, 0, 0, 0, 1 };

        // public int[] Row1 = { 0, 0, 1, 0, 0 };

        // public int[] Row0 = { 0, 1, 0, 1, 0 };

        public int[][] grid = 
        {
            new int[] { 0, 1, 0, 1, 0 },
            new int[] { 0, 0, 1, 0, 0 },
            new int[] { 1, 0, 0, 0, 1 },
            new int[] { 0, 0, 0, 1, 0 },
            new int[] { 1, 1, 1, 0, 0 },

        };

        //public int[][] grid = new int[][] {  Row0 ,  Row1 ,  Row2 ,  Row3, Row4  };


    }
}