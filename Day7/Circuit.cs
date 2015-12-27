using System;
using System.Collections.Generic;

namespace Day7
{
    internal sealed class Circuit : ICircuit
    {
        private readonly IDictionary<string, int> _wireSignals;

        public Circuit()
        {
            _wireSignals = new Dictionary<string, int>();
        }

        public void SetWireSignal(Wire wireIdentifier, int signal)
        {
            if (_wireSignals.ContainsKey(wireIdentifier.Identifier))
            {
                throw new Exception($"Wire {wireIdentifier} has already been set");
            }

            _wireSignals.Add(wireIdentifier.Identifier, signal);
        }

        public bool TryGetWireSignal(Wire wireIdentifier, out int signal)
        {
            return _wireSignals.TryGetValue(wireIdentifier.Identifier, out signal);
        }
    }
}