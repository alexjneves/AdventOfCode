namespace Day7
{
    internal interface IInstructionExpression
    {
        string Expression { get; }
        bool TryEvaluateExpression(ICircuit circuit, out int output);
    }
}