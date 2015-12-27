namespace Day7.Instruction.Instructions
{
    internal abstract class SingleExpressionInstruction : IInstruction
    {
        private readonly IInstructionExpression _expression;
        private readonly Wire _outputWire;

        public bool ExecutedSuccessfully { get; private set; }

        protected SingleExpressionInstruction(IInstructionExpression expression, Wire outputWire)
        {
            _expression = expression;
            _outputWire = outputWire;
        }

        protected abstract int ApplyInstruction(int signal);

        public void Execute(ICircuit circuit)
        {
            int signal;
            ExecutedSuccessfully = _expression.TryEvaluateExpression(circuit, out signal);

            if (ExecutedSuccessfully)
            {
                var outputWireSignal = ApplyInstruction(signal);
                circuit.SetWireSignal(_outputWire, outputWireSignal);
            }
        }
    }
}