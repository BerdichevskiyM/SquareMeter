using System;
using Microsoft.VisualStudio.TestTools.UnitTesting;


namespace SquareMeter.UnitTests
{
    [TestClass]
    public class BaseTest
    {
        [TestMethod]
        public void CheckCircleSquare()
        {
            CircleMeter circleMeter = new CircleMeter(1f);
            Assert.AreEqual(Math.PI, circleMeter.GetSquare(), 1f);
            circleMeter._radius = 0f;
            Assert.AreEqual(0f, circleMeter.GetSquare());
            circleMeter._radius = 12.5f;
            Assert.AreEqual(Math.PI * 12.5f * 12.5f, circleMeter.GetSquare(), 1f);
        }

        [TestMethod]
        public void CheckTriangleSquare()
        {
            TriangleMeter triangleMeter = new TriangleMeter(12f, 8f, 7f);
            Assert.AreEqual(26.906f, triangleMeter.GetSquare(), 0.7f);
            triangleMeter[0] = 5f;
            Assert.AreEqual(17.321f, triangleMeter.GetSquare(), 0.7f);
            triangleMeter = new TriangleMeter(1f, 1f, 1f);
            Assert.AreEqual(0.433f, triangleMeter.GetSquare(), 0.7f);
            triangleMeter = new TriangleMeter(0f, 0f, 0f);
            Assert.AreEqual(0f, triangleMeter.GetSquare());
        }

        [TestMethod]
        public void CheckRightTriangleSquare()
        {
            TriangleMeter triangleMeter = new TriangleMeter(12f, 8.485f, 8.485f);
            Assert.AreEqual(1f / 2f * 8.485f * 8.485f, triangleMeter.GetSquare(), 0.7f);
            triangleMeter = new TriangleMeter(13f, 5.494f, 11.782f);
            Assert.AreEqual(1f / 2f * 5.494f * 11.782f, triangleMeter.GetSquare(), 0.7f);
            triangleMeter = new TriangleMeter(8f, 17f, 15f);
            Assert.AreEqual(1f / 2f * 8f * 15f, triangleMeter.GetSquare(), 0.1f);
        }

        [TestMethod]
        public void CheckTriangleExceptions()
        {
            Exception exception = Assert.ThrowsException<Exception>(() => new TriangleMeter(3f, 56f, 4f));
            Assert.AreEqual("Impossible set side size: triangle inequality doesn't work.", exception.Message);
            exception = Assert.ThrowsException<Exception>(() => new TriangleMeter(378f, 56f, 4f));
            Assert.AreEqual("Impossible set side size: triangle inequality doesn't work.", exception.Message);
            TriangleMeter triangleMeter = new TriangleMeter(4f, 4f, 7f);
            exception = Assert.ThrowsException<Exception>(() => triangleMeter[2] = 10f);
            Assert.AreEqual("Impossible set side size: triangle inequality doesn't work.", exception.Message);
            exception = Assert.ThrowsException<Exception>(() => triangleMeter[3] = 10f);
            Assert.AreEqual("Side index is outside the bounds of the allowable side count.", exception.Message);
            exception = Assert.ThrowsException<Exception>(() => triangleMeter[-1] = 10f);
            Assert.AreEqual("Side index is outside the bounds of the allowable side count.", exception.Message);
            try
            {
                _ = triangleMeter[0];
                Assert.Fail();
            }
            catch(Exception ex)
            {
                Assert.IsTrue(ex is AssertFailedException);
            }
        }
    }
}
