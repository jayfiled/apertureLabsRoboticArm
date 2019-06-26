using System;
using NUnit.Framework;

namespace apertureLabsRoboticArm
{
    [TestFixture]
    class ProgramTests
    {
        [TestCase()]
        public void Should_Instansiate_Router_Object()
        {
            Router r = new Router();
            Assert.IsNotNull(r);
        }
    }
}