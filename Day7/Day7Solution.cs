using System;
using System.Collections.Generic;
using System.IO;
using System.Linq;
using System.Text.RegularExpressions;
using Common;
using Day7.Instruction.Instructions;

namespace Day7
{
    public class Day7Solution : IDailyPuzzle
    {
        private const string RawInstructionsFile = "RawInstructions.txt";
        private const string WireAKey = "a";
        private const string AssignmentOfBPattern = @"^\d+\s->\sb$";
        private const int Part1Answer = 46065;

        private readonly IList<string> _rawInstructions;

        public Day7Solution()
        {
            _rawInstructions = File.ReadLines(RawInstructionsFile).ToList();
        }

        public int SolvePart1()
        {
            return DetermineWireSignalFromInstructions(WireAKey, _rawInstructions);
        }

        public int SolvePart2()
        {
            var rawInstructions = new List<string>(_rawInstructions);
            rawInstructions.RemoveAll(ri => Regex.IsMatch(ri, AssignmentOfBPattern));

            rawInstructions.Add($"{Part1Answer} -> b");

            return DetermineWireSignalFromInstructions(WireAKey, rawInstructions);
        }

        private static int DetermineWireSignalFromInstructions(string wireKey, IEnumerable<string> rawInstructions)
        {
            var circuit = new Circuit();

            var instructionFactory = new InstructionFactory();
            var instructions = rawInstructions.Select(instructionFactory.Create).ToList();

            WireCircuit(circuit, instructions);

            return GetWireSignal(wireKey, circuit);
        }

        private static void WireCircuit(ICircuit circuit, IList<IInstruction> instructions)
        {
            do
            {
                foreach (var instruction in instructions)
                {
                    instruction.Execute(circuit);
                }

                instructions = instructions.Where(i => i.ExecutedSuccessfully == false).ToList();
            } while (instructions.Any());
        }

        private static int GetWireSignal(string wireKey, ICircuit circuit)
        {
            int wireSignal;

            if (!circuit.TryGetWireSignal(new Wire(wireKey), out wireSignal))
            {
                throw new Exception($"Wire {wireKey} does not exist in circuit");
            }

            return wireSignal;
        }
    }
}
