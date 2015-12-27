namespace Day7.Instruction.Instructions
{
    internal sealed class AssignmentInstruction : SingleExpressionInstruction
    {
        public AssignmentInstruction(IInstructionExpression expression, Wire outputWire) : base(expression, outputWire)
        {
        }

        protected override int ApplyInstruction(int signal) => signal;
    }
}