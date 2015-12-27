using Day7.Instruction.Instructions;
using FluentAssertions;
using NSubstitute;
using NUnit.Framework;

namespace Day7.Test
{
    [TestFixture]
    internal abstract class InstructionTestBase
    {
        protected const int LhsExpressionValue = 17;
        protected const int RhsExpressionValue = 3;

        protected Wire OutputWire;
        protected IInstructionExpression LhsExpression;
        protected IInstructionExpression RhsExpression;

        private ICircuit _circuit;

        protected abstract IInstruction CreateInstruction();
        protected abstract int ExpectedOutputWireSignal { get; }

        [SetUp]
        public void SetUp()
        {
            _circuit = Substitute.For<ICircuit>();
            OutputWire = new Wire("DefaultWire");
        }

        [Test]
        public void Execute_WhenExpressionsFailToEvaluate_ExecutedSuccessfullyIsFalse()
        {
            LhsExpression = new InstructionExpressionBuilder().WithFailure().Build();
            RhsExpression = new InstructionExpressionBuilder().WithFailure().Build();

            var instruction = CreateInstruction();
            instruction.Execute(_circuit);

            instruction.ExecutedSuccessfully.Should().BeFalse();
        }

        [Test]
        public void Execute_WhenExpressionsSuccessfullyEvaluate_SetsOutputWireWithExpectedValue()
        {
            LhsExpression = new InstructionExpressionBuilder()
                .WithSuccess()
                .WithResultingValue(LhsExpressionValue)
                .Build();

            RhsExpression = new InstructionExpressionBuilder()
                .WithSuccess()
                .WithResultingValue(RhsExpressionValue)
                .Build();

            var instruction = CreateInstruction();
            instruction.Execute(_circuit);

            instruction.ExecutedSuccessfully.Should().BeTrue();
            _circuit.Received().SetWireSignal(OutputWire, ExpectedOutputWireSignal);
        }
    }
}