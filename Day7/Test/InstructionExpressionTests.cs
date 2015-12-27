using FluentAssertions;
using NUnit.Framework;

namespace Day7.Test
{
    [TestFixture]
    internal sealed class InstructionExpressionTests
    {
        [Test]
        public void TryEvaluateExpression_WhenExpressionIsLiteralValue_SetsExpectedLiteralValue()
        {
            const int expectedLiteralValue = 123;

            var instructionExpression = new InstructionExpression(expectedLiteralValue.ToString());

            int actualLiteralValue;
            var success = instructionExpression.TryEvaluateExpression(null, out actualLiteralValue);

            success.ShouldBeEquivalentTo(true);
            actualLiteralValue.Should().Be(expectedLiteralValue);
        }

        [Test]
        public void TryEvaluateExpression_WhenExpressionIsWireIdentifier_AndWireExistsInCircuit_SetsExpectedWireValue()
        {
            const string wireIdentifier = "ab";
            const int expectedWireSignal = 12;

            var circuit = new Circuit();
            circuit.SetWireSignal(new Wire(wireIdentifier), expectedWireSignal);

            var instructionExpression = new InstructionExpression(wireIdentifier);

            int actualWireSignal;
            var success = instructionExpression.TryEvaluateExpression(circuit, out actualWireSignal);

            success.ShouldBeEquivalentTo(true);
            actualWireSignal.Should().Be(expectedWireSignal);
        }

        [Test]
        public void TryEvaluateExpression_WhenExpressionIsWireIdentifier_AndWireDoesNotExistInCircuit_ReturnsFalse()
        {
            var instructionExpression = new InstructionExpression("Non Existent OutputWire Identifier");

            int actualWireSignal;
            var success = instructionExpression.TryEvaluateExpression(new Circuit(), out actualWireSignal);

            success.ShouldBeEquivalentTo(false);
        }
    }
}