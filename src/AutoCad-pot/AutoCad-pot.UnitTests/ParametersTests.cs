﻿namespace AutoCad_pot.UnitTests
{
    using AutoCad_pot.Model;
    using NUnit.Framework;

    /// <summary>
    /// Тестирование класса Parameters
    /// </summary>
    [TestFixture(Description = "Модульные тесты класса Parameter.")]
    public class ParametersTests
    {
        private Parameters _parameters;

        [SetUp]
        public void CreateParameters()
        {
            _parameters = new Parameters();
        }

        [TestCase(ParameterType.PotHeight, Parameters.MinPotHeight,
            "Метод возвращает некорректное минимальное значение параметра PotHeight.",
            TestName =
                "Тест метода GetMinValue: Получить минимальное значение параметра 'PotHeight'.")]
        public void Test_GetMinValue_CorrectValue(ParameterType parameterType,
            double expectedValue, string message)
        {
            var actualValue = _parameters.GetMinValue(parameterType);
            Assert.AreEqual(expectedValue, actualValue, message);
        }

        [TestCase(ParameterType.PotHeight, Parameters.MaxPotHeight,
            "Метод возвращает некорректное минимальное значение параметра PotHeight.",
            TestName =
                "Тест метода GetMaxValue: Получить минимальное значение параметра 'PotHeight'.")]
        public void Test_GetMaxValue_CorrectValue(ParameterType parameterType,
            double expectedValue, string message)
        {
            var actualValue = _parameters.GetMaxValue(parameterType);
            Assert.AreEqual(expectedValue, actualValue, message);
        }
        [TestCase(3,2, "Метод возвращает некорректное максимальное "
                       + "значение параметра HandlesHeight.",
            TestName =
            "Тест метода UpdateMaxHandlesHeight: Получить обновлённое значение"
            + " параметра 'HandlesHeight'.")]
        public void Test_UpdateMaxHandlesHeight_CorrectValue(
            double value,
            double exceptedValue,
            string message)
        {
            _parameters.SetValue(ParameterType.HandlesThickness, value);
            var actualValue = _parameters.GetMaxValue(ParameterType.HandlesHeight);
            Assert.AreEqual(exceptedValue, actualValue, message);
        }
        [TestCase(ParameterType.PotHeight, 170,
            "Метод задает некорректное значение параметра 'PotHeight'.")]
        public void Test_SetValue_CorrectValue(ParameterType parameterType,
            double expectedValue, string message)
        {
            _parameters.SetValue(parameterType, expectedValue);
            var actualValue = _parameters.GetValue(parameterType);
            Assert.AreEqual(expectedValue, actualValue, message);
        }

        [TestCase(ParameterType.PotHeight, 2000,
            "Метод задает некорректное значение параметра 'PotHeight'.")]
        public void Test_SetValue_WrongValue(ParameterType parameterType,
            double unexpectedValue, string message)
        {
            _parameters.SetValue(parameterType, unexpectedValue);
            var actualValue = _parameters.GetValue(parameterType);
            Assert.AreNotEqual(unexpectedValue, actualValue, message);
        }

        [TestCase(3, 1.5, "Метод возвращает некорректное минимальное "
                        + "значение параметра HandlesHeight.",
            TestName =
                "Тест метода UpdateMinHandlesHeight: Получить обновлённое значение"
                + " параметра 'HandlesHeight'.")]
        public void Test_UpdateMinHandlesHeight_CorrectValue(
            double value,
            double exceptedValue,
            string message)
        {
            _parameters.SetValue(ParameterType.HandlesThickness, value);
            var actualValue = _parameters.GetMinValue(ParameterType.HandlesHeight);
            Assert.AreEqual(exceptedValue, actualValue, message);
        }

        [TestCase(ParameterType.PotHeight, Parameters.MinPotHeight,
            "Метод возвращает некорректное текущее значение параметра PotHeight.",
            TestName =
                "Тест метода GetValue: Получить текущее значение параметра 'PotHeight'.")]
        public void Test_GetValue_CorrectValue(ParameterType parameterType,
            double expectedValue, string message)
        {
            var actualValue = _parameters.GetValue(parameterType);
            Assert.AreEqual(expectedValue, actualValue, message);
        }

        [TestCase(ParameterType.PotHeight, "200",
            "Значение не подходит в диапазон",
            TestName = "Тест метода Validate: "
                       + "валидация правильного значения'.")]
        public void Test_Validate_CorrectValue(ParameterType parameterType, string value,
            string message)
        {
            Assert.IsTrue(_parameters.Validate(parameterType, value), message);
        }

        [TestCase(ParameterType.PotHeight, "",
            "Значение подходит в диапазон",
            TestName = "Тест метода Validate: "
                       + "валидация пустого значения'.")]
        [TestCase(ParameterType.PotHeight, "0",
            "Значение подходит в диапазон",
            TestName = "Тест метода Validate: "
                       + "валидация нулевого значения'.")]
        public void Test_Validate_WrongValue(ParameterType parameterType, string value,
            string message)
        {
            Assert.IsFalse(_parameters.Validate(parameterType, value), message);
        }
    }
}