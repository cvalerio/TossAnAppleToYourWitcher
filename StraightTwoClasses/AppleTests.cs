using System;
using System.Linq;
using Microsoft.VisualStudio.TestTools.UnitTesting;

namespace TossAnAppleToYourWitcher
{
    [TestClass]
    public class AppleTests
    {
        [TestMethod]
        public void CanMoveFromHandToBox()
        {
            var box = new Box(10);
            var apple = new Apple(Apple.AppleKind.Golden);
            apple.MoveToBox(box, 7);
            Assert.IsTrue(object.ReferenceEquals(apple, box.Apples.ElementAt(7)), "Apple not found in box position 7");
            Assert.IsTrue(object.ReferenceEquals(box, apple.Box), "Apple is not set in the right box");
        }

        [TestMethod]
        public void CanMoveFromOneBoxToAnother()
        {
            var pinkBox = new Box(10);
            var redBox = new Box(10);
            var apple = new Apple(Apple.AppleKind.RedDelicious);
            pinkBox.AddApple(apple, 0);
            apple.MoveToBox(redBox, 3);
            Assert.IsTrue(object.ReferenceEquals(apple, redBox.Apples.ElementAt(3)), "Apple not found in red box position 3");
            Assert.IsTrue(object.ReferenceEquals(redBox, apple.Box), "Apple is not set in the right box");
            Assert.AreEqual(-1, pinkBox.GetApplePosition(apple));
        }

        [TestMethod]
        public void CannotMoveToNullBox()
        {
            var box = new Box(10);
            var apple = new Apple(Apple.AppleKind.Golden);
            apple.MoveToBox(box, 7);
            Assert.ThrowsException<ArgumentNullException>(() => apple.MoveToBox(null, 0));
        }

        [TestMethod]
        public void CannotMoveOutOfBoxBoundaries()
        {
            var box = new Box(10);
            var apple = new Apple(Apple.AppleKind.Golden);
            Assert.ThrowsException<IndexOutOfRangeException>(() => apple.MoveToBox(box, -1), "Apple can be moved at -1");
            Assert.ThrowsException<IndexOutOfRangeException>(() => apple.MoveToBox(box, 10), "Apple can be moved at 10");
        }

    }
}