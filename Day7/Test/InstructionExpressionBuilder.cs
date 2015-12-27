using NSubstitute;

namespace Day7.Test
{
    internal sealed class InstructionExpressionBuilder
    {
        private bool _evaluationSuccess;
        private int _evaluationResultValue;

        public InstructionExpressionBuilder()
        {
            _evaluationSuccess = true;
            _evaluationResultValue = 0;
        }

        public InstructionExpressionBuilder WithResultingValue(int value)
        {
            _evaluationResultValue = value;
            return this;
        }

        public InstructionExpressionBuilder WithSuccess()
        {
            _evaluationSuccess = true;
            return this;
        }

        public InstructionExpressionBuilder WithFailure()
        {
            _evaluationSuccess = false;
            return this;
        }

        public IInstructionExpression Build()
        {
            var instructionExpression = Substitute.For<IInstructionExpression>();

            int outValue;
            instructionExpression.TryEvaluateExpression(Arg.Any<ICircuit>(), out outValue).Returns(
                callInfo =>
                {
                    callInfo[1] = _evaluationResultValue;
                    return _evaluationSuccess;
                }
            );

            return instructionExpression;
        }
    }
}