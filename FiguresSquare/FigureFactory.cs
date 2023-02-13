using Newtonsoft.Json;
using System;
using System.Collections.Generic;
using static FiguresSquare.DataConstants;
namespace FiguresSquare
{
    public static class FigureFactory
    {
        public static IFigure CreateFigure(string jsonData)
        {
            if (string.IsNullOrEmpty(jsonData))
                throw new ArgumentNullException("Data is null or empty");

            //1. Получаем данные в неком заданном формате (Например - JSON)
            //2. Обрабатываем данные и определяем тип фигуры. Исходя из типа фигуры создаем экземпляр соответсвующего класса

            var dataDict = JsonConvert.DeserializeObject<Dictionary<string, object>>(jsonData);

            if (!dataDict.TryGetValue(DataConstants.FIGURE_TYPE_NAME, out object figureTypeObj))
                throw new ArgumentException("Incorrect data format, Parameter \"Name\" is not found");
            string figureType = (string)figureTypeObj;

            switch (figureType)
            {
                case CIRCLE_NAME: return CreateCircle(dataDict);

                case TRIANGLE_NAME: return CreateTriangle(dataDict);

                default:
                    {
                        //Возвращаем null или выбрасываем исключение в зависимости от того, какая политика требуется конечному пользователю
                        return null;
                    }
            }
        }

        static IFigure CreateCircle(Dictionary<string, object> data)
        {
            if (!data.TryGetValue(RADIUS_NAME, out object radiusObj))
                throw new ArgumentException($"Data is not contains {RADIUS_NAME} field");

            return new FigureCircle((double)radiusObj);
        }
        static IFigure CreateTriangle(Dictionary<string, object> data)
        {
            //Аналогичная реализация...
            throw new NotImplementedException();
        }

        public static double CalculateFigureSquare(string data)
        {
            return CreateFigure(data).GetSquare();
        }
    }
}
