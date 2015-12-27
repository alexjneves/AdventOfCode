namespace Day7.Instruction.Instructions
{
    internal abstract class DoubleExpressionInstruction : IInstruction
    {
        private readonly IInstructionExpression _lhsExpression;
        private readonly IInstructionExpression _rhsExpression;
        private readonly Wire _outputWire;

        public bool ExecutedSuccessfully { get; private set; }

        protected DoubleExpressionInstruction(IInstructionExpression lhsExpression, IInstructionExpression rhsExpression, Wire outputWire)
        {
            _lhsExpression = lhsExpression;
            _rhsExpression = rhsExpression;
            _outputWire = outputWire;
        }

        protected abstract int ApplyInstruction(int lhsSignal, int rhsSignal);

        public void Execute(ICircuit circuit)
        {
            var lhsSignal = 0;
            var rhsSignal = 0;

            ExecutedSuccessfully = _lhsExpression.TryEvaluateExpression(circuit, out lhsSignal) &&
                                   _rhsExpression.TryEvaluateExpression(circuit, out rhsSignal);

            if (ExecutedSuccessfully)
            {
                var outputWireSignal = ApplyInstruction(lhsSignal, rhsSignal);
                circuit.SetWireSignal(_outputWire, outputWireSignal);
            }
        }
    }
}