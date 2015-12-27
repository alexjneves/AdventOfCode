namespace Day7.Instruction.Instructions
{
    internal interface IInstruction
    {
        bool ExecutedSuccessfully { get; }
        void Execute(ICircuit circuit);
    }
}