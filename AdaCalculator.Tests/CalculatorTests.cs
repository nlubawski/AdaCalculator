using AdaCalculator;
using Moq;
using Shouldly;

namespace AdaCalculatorTeste
{
    public class CalculatorTests
    {
        private readonly CalculatorMachine _sut;
        private readonly Mock<ICalculator> _mock;
        public CalculatorTests()
        {
            _mock = new Mock<ICalculator>();
            _sut = new CalculatorMachine(_mock.Object);
        }

        [Theory]
        [InlineData("sum", 10, 4, 14)]
        [InlineData("sum", 10, -4, 6)]
        [InlineData("sum", 10, 0, 10)]
        public void CalculatorMachine_SumIntegers_IsValid(string operation, double firstNumber, double secondNumber, double resultado)
        {
            _mock.Setup(x => x.Calculate(operation, firstNumber, secondNumber)).Returns((operation, resultado));
            _sut.Calculate(operation, firstNumber, secondNumber);
            _mock.Verify(x => x.Calculate(operation, firstNumber, secondNumber), Times.Once);
        }


        [Theory]
        [InlineData("subtract", 10, 4, 6)]
        [InlineData("subtract", 10, -2, 12)]
        [InlineData("subtract", 10, 0, 10)]
        [InlineData("subtract", 0, 0, 0)]
        public void CalculatorMachine_SubtractionIntegers_IsValid(string operation, double firstNumber, double secondNumber, double resultado)
        {
            _mock.Setup(x => x.Calculate(operation, firstNumber, secondNumber)).Returns((operation, resultado));
            _sut.Calculate(operation, firstNumber, secondNumber);
            _mock.Verify(x => x.Calculate(operation, firstNumber, secondNumber), Times.Once);
        }

        [Theory]
        [InlineData("multiply", 10, 2, 20)]
        [InlineData("multiply", 10, -2, -20)]
        [InlineData("multiply", 10, -3, -30)]
        [InlineData("multiply", 10, 0, 0)]
        [InlineData("multiply", 0, 3, 0)]
        [InlineData("multiply", 3, 0, 0)]
        public void CalculatorMachine_MultiplicationIntegers_IsValid(string operation, double firstNumber, double secondNumber, double resultado)
        {
            _mock.Setup(x => x.Calculate(operation, firstNumber, secondNumber)).Returns((operation, resultado));
            _sut.Calculate(operation, firstNumber, secondNumber);
            _mock.Verify(x => x.Calculate(operation, firstNumber, secondNumber), Times.Once);
        }

        [Theory]
        [InlineData("divide", 10, 2, 5)]
        [InlineData("divide", 10, -2, -5)]
        [InlineData("divide", -10, 2, -5)]
        [InlineData("divide", -10, -2, 5)]
        [InlineData("divide", 10, 0, double.PositiveInfinity)]
        public void CalculatorMachine_DivisionIntegers_IsValid(string operation, double firstNumber, double secondNumber, double resultado)
        {
            _mock.Setup(x => x.Calculate(operation, firstNumber, secondNumber)).Returns((operation, resultado));
            _sut.Calculate(operation, firstNumber, secondNumber);
            _mock.Verify(x => x.Calculate(operation, firstNumber, secondNumber), Times.Once);
        }

    }
}