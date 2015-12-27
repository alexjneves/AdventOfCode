namespace Day7
{
    internal interface ICircuit
    {
        void SetWireSignal(Wire wireIdentifier, int signal);
        bool TryGetWireSignal(Wire wireIdentifier, out int signal);
    }
}