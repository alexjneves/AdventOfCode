namespace Day7.Instruction.Instructions
{
    internal sealed class LShiftInstruction : DoubleExpressionInstruction
    {
        public LShiftInstruction(IInstructionExpression lhsExpression, IInstructionExpression rhsExpression, Wire outputWire) : base(lhsExpression, rhsExpression, outputWire)
        {
        }

        protected override int ApplyInstruction(int lhsSignal, int rhsSignal) => lhsSignal << rhsSignal;
    }
}