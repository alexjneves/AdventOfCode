using System;
using System.Collections.Generic;
using System.IO;
using System.Linq;
using Common;
using Day7.Instruction.Instructions;

namespace Day7
{
    public class Day7Solution : IDailyPuzzle
    {
        private const string RawInstructionsFile = "RawInstructions.txt";
        private const string Part1Wire = "a";

        private readonly IList<IInstruction> _instructions;

        public Day7Solution()
        {
            var instructionFactory = new InstructionFactory();
            var rawInstructions = File.ReadLines(RawInstructionsFile);

            _instructions = rawInstructions.Select(instructionFactory.Create).ToList();
        }

        public int SolvePart1()
        {
            var circuit = new Circuit();
            var instructions = new List<IInstruction>(_instructions);

            do
            {
                foreach (var instruction in instructions)
                {
                    instruction.Execute(circuit);
                }

                instructions = instructions.Where(i => i.ExecutedSuccessfully == false).ToList();
            } while (instructions.Any());

            int resultSignal;
            circuit.TryGetWireSignal(new Wire(Part1Wire), out resultSignal);

            return resultSignal;
        }

        public int SolvePart2()
        {
            return -1;
        }
    }
}
