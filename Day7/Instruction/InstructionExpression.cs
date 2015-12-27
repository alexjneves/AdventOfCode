namespace Day7
{
    internal sealed class InstructionExpression : IInstructionExpression
    {
        public string Expression { get; }

        public InstructionExpression(string expression)
        {
            Expression = expression;
        }

        public bool TryEvaluateExpression(ICircuit circuit, out int output)
        {
            if (int.TryParse(Expression, out output))
            {
                return true;
            }

            return circuit.TryGetWireSignal(new Wire(Expression), out output);
        }
    }
}