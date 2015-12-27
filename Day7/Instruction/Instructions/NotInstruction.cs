namespace Day7.Instruction.Instructions
{
    internal sealed class NotInstruction : SingleExpressionInstruction
    {
        public NotInstruction(IInstructionExpression expression, Wire outputWire) : base(expression, outputWire)
        {
        }

        protected override int ApplyInstruction(int signal) => ~signal;
    }
}