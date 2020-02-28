using System;
using System.Linq;
using Microsoft.VisualStudio.TestTools.UnitTesting;

namespace TossAnAppleToYourWitcher
{
    [TestClass]
    public class BoxTests
    {
        [TestMethod]
        public void BoxHasApples()
        {
            var box = new Box(10);
            Assert.AreEqual(10, box.Apples.Count());
            Assert.IsNull(box.Apples.ElementAt(0));
        }

        [TestMethod]
        public void CanAddAppleToBox()
        {
            var box = new Box(10);
            var apple = new Apple(Apple.AppleKind.Golden);
            box.AddApple(apple, 0);
            Assert.IsTrue(object.ReferenceEquals(apple, box.Apples.ElementAt(0)), "Apple not found in box position 0");
            Assert.IsTrue(object.ReferenceEquals(box, apple.Box), "Apple is not set in the right box");
        }

        [TestMethod]
        public void CannotAddNullAppleToBox()
        {
            var box = new Box(10);
            Assert.ThrowsException<ArgumentNullException>(() => box.AddApple(null, 0));
        }

        [TestMethod]
        public void CannotAddAppleOutsideBoxBoundaries()
        {
            var box = new Box(10);
            var apple = new Apple(Apple.AppleKind.PinkLady);
            Assert.ThrowsException<IndexOutOfRangeException>(() => box.AddApple(apple, -1), "Apple can be inserted at -1");
            Assert.ThrowsException<IndexOutOfRangeException>(() => box.AddApple(apple, 10), "Apple can be inserted at 10");
        }

        [TestMethod]
        public void CannotAddAppleInOccupiedPosition()
        {
            var box = new Box(10);
            var granny = new Apple(Apple.AppleKind.GrannySmith);
            var pink = new Apple(Apple.AppleKind.PinkLady);
            box.AddApple(granny, 2);
            Assert.ThrowsException<ArgumentException>(() => box.AddApple(pink, 2));
        }

        [TestMethod]
        public void CanRemoveApple()
        {
            var box = new Box(10);
            var apple = new Apple(Apple.AppleKind.GrannySmith);
            box.AddApple(apple, 5);
            box.RemoveApple(apple);
            Assert.IsNull(apple.Box);
            Assert.AreEqual(-1, box.GetApplePosition(apple));
        }

        [TestMethod]
        public void CanGetApplePosition()
        {
            var box = new Box(10);
            var apple = new Apple(Apple.AppleKind.RedDelicious);
            box.AddApple(apple, 7);
            Assert.AreEqual(7, box.GetApplePosition(apple));
        }
    }
}
