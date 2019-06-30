using System;
using NUnit.Framework;

namespace apertureLabsRoboticArm
{
    [TestFixture]

    class RobotArmTests
    {
        [TestCase()]
        public void RobotArmObjectShouldInstantiateTheView()
        {

        }
        
        [TestCase()]
        public void FunctionsRunBeforePlaceShouldFail()
        {
            // Run other functions before 'place' and should receive feedback.
        }

        [TestCase()]
        public void PlaceMethodShouldHandleWrongInput()
        {
            // If the position entered is outside the boundary, display a message
        }

        [TestCase()]
        public void PlaceMethodShouldHandleCorrectInput()
        {
            // If the position entered is inside the boundary, display a message
        }

        [TestCase()]
        public void PlaceMethodShouldToggleTestTubePlateSetUpVariable()
        {
            // Should toggle to true, so other functions can be run
        }

    }
}