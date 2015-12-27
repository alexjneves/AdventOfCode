namespace Day7.Instruction
{
    internal interface IInstructionExpression
    {
        string Expression { get; }
        bool TryEvaluateExpression(ICircuit circuit, out int output);
    }
}