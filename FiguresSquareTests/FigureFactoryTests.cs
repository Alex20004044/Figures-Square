using FiguresSquare;
using Newtonsoft.Json;
using NUnit.Framework;
using System;
using System.Collections.Generic;
using static FiguresSquare.DataConstants;
using static FiguresSquareTests.TestConstants;

namespace FiguresSquareTests
{
    class FigureFactoryTests
    {
        [Test]
        public void CreateCircleTest()
        {
            Dictionary<string, object> data = new Dictionary<string, object>();
            data.Add(FIGURE_TYPE_NAME, CIRCLE_NAME);
            data.Add(RADIUS_NAME, 10.0);
            string jsonData = JsonConvert.SerializeObject(data);

            IFigure figure = FigureFactory.CreateFigure(jsonData);
            Assert.That(figure.GetSquare(), Is.EqualTo(10 * 10 * Math.PI).Within(ACCURACY));
            Assert.That(figure, Is.TypeOf<FigureCircle>());
        }

        [Test]
        public void GetCircleSquareTest()
        {
            Dictionary<string, object> data = new Dictionary<string, object>();
            data.Add(FIGURE_TYPE_NAME, CIRCLE_NAME);
            data.Add(RADIUS_NAME, 10.0);
            string jsonData = JsonConvert.SerializeObject(data);

            Assert.That(FigureFactory.CalculateFigureSquare(jsonData), Is.EqualTo(10 * 10 * Math.PI).Within(ACCURACY));
        }

        //Также необходимы тесты на появления исключений в случае некорректных данных
        //И тесты создания других фигур
    }
}
