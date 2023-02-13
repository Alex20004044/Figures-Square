using FiguresSquare;
using NUnit.Framework;
using System;
using System.Collections.Generic;
using System.Text;
using static FiguresSquareTests.TestConstants;
namespace FiguresSquareTests
{
    class FigureTriangleTests
    {
        [Test]
        public void TriangleCreationTest()
        {
            FigureTriangle triangle = new FigureTriangle(3, 4, 5);

            Assert.That(triangle.A, Is.EqualTo(3).Within(ACCURACY));
            Assert.That(triangle.B, Is.EqualTo(4).Within(ACCURACY));
            Assert.That(triangle.C, Is.EqualTo(5).Within(ACCURACY));

            Assert.That(triangle.GetSquare(), Is.EqualTo(3*4/2).Within(ACCURACY));
            //Также следует протестировать создание треугольника с другим порядком передачи сторон в конструктор
            //...
        }

        [Test]
        public void TriangleIsRightTest()
        {
            FigureTriangle triangle = new FigureTriangle(3, 4, 5);
            Assert.That(triangle.IsRightTriangle(), Is.True);
        }

        [Test]
        public void TriangleIsNotRightTest()
        {
            FigureTriangle triangle = new FigureTriangle(4, 4, 5);
            Assert.That(triangle.IsRightTriangle(), Is.False);
        }
        [Test]
        public void TriangleIncorrectSidesCreationTest()
        {
            Assert.Throws<ArgumentException>(() => new FigureTriangle(-1, 4, 5));
            Assert.Throws<ArgumentException>(() => new FigureTriangle(4, -1, 5));
            Assert.Throws<ArgumentException>(() => new FigureTriangle(3, 4, -1));

            Assert.Throws<ArgumentException>(() => new FigureTriangle(100, 4, 5));
            Assert.Throws<ArgumentException>(() => new FigureTriangle(4, 100, 5));
            Assert.Throws<ArgumentException>(() => new FigureTriangle(3, 4, 100));
        }
        [Test]
        public void TriangleZeroSideCreationTest()
        {
            Assert.Throws<ArgumentException>(()=>new FigureTriangle(0, 0, 0));
        }
        [Test]
        public void TrianglePosInfinityCreationTest()
        {
            Assert.Throws<ArgumentException>(() => new FigureTriangle(double.PositiveInfinity, 10, 20));
        }

    }
}
