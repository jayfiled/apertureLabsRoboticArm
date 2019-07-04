using System;
using NUnit.Framework;

// Test function naming conventions:
// TheMethodOnTheTest_TheTestScenario
// Expected behavior, i.e.
// CanBeCancelledBy_SameUserCancellingReservation_ReturnTrue()

namespace apertureLabsRoboticArm
{
    [TestFixture]

    class RobotArmTests
    {
        // Arrange
        RobotArm r = new RobotArm();

        [TestCase()]
        public void RobotArmObjectShouldInstantiateTheView()
        {
            // Assert
            Assert.IsNotNull(r.LcdScreen);
        }

        [TestCase()]
        public void FunctionsRunBeforePlaceShouldFail()
        {
            // results
            bool[] expectedResults = { false, true };
            bool[] actualResults = new bool[2];

            // Run other functions before 'place' and should receive feedback.
            r.Detect(1, 0);
            actualResults[0] = r.IsPlateIsReady();
            r.plate.readyForOperation = true;
            actualResults[1] = r.IsPlateIsReady();

            Assert.AreEqual(expectedResults, actualResults);

            //revert changes
            r.plate.readyForOperation = false;

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