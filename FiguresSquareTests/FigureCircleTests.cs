using FiguresSquare;
using NUnit.Framework;
using System;
using System.Collections.Generic;
using System.Text;
using static FiguresSquareTests.TestConstants;
namespace FiguresSquareTests
{
    class FigureCircleTests
    {

        [Test]
        public void CircleCreationTest()
        {
            FigureCircle circle = new FigureCircle(2);

            Assert.That(circle.Radius, Is.EqualTo(2).Within(ACCURACY));
            Assert.That(circle.GetSquare(), Is.EqualTo(2 * 2 * Math.PI).Within(ACCURACY));
        }
        [Test]
        public void CircleIncorrectRadiusCreationTest()
        {
            Assert.Throws<ArgumentException>(() => new FigureCircle(-1));
        }
        [Test]
        public void CircleZeroRadiusCreationTest()
        {
            FigureCircle circle = new FigureCircle(0);

            Assert.That(circle.Radius, Is.EqualTo(0).Within(ACCURACY));
            Assert.That(circle.GetSquare(), Is.EqualTo(0).Within(ACCURACY));
        }
        [Test]
        public void CirclePosInfinityRadiusCreationTest()
        {
            FigureCircle circle = new FigureCircle(double.PositiveInfinity);

            Assert.That(circle.Radius, Is.EqualTo(double.PositiveInfinity).Within(ACCURACY));
            Assert.That(circle.GetSquare(), Is.EqualTo(double.PositiveInfinity).Within(ACCURACY));
        }
    }
}
