using System;
using System.Text.RegularExpressions;

namespace Day7.Instruction
{
    internal sealed class InstructionComponents
    {
        public InstructionExpression LhsExpression { get; }
        public InstructionExpression RhsExpression { get; }
        public InstructionOperator InstructionOperator { get; }
        public Wire OutputWire { get; }

        public InstructionComponents(InstructionExpression lhsExpression, InstructionExpression rhsExpression, InstructionOperator instructionOperator, Wire outputWire)
        {
            LhsExpression = lhsExpression;
            RhsExpression = rhsExpression;
            InstructionOperator = instructionOperator;
            OutputWire = outputWire;
        }

        public static InstructionComponents Parse(string rawInstruction)
        {
            var regex = new Regex(@"(?<lhs>[a-z|0-9]*)\s?(?<operator>[A-Z]*)\s(?<rhs>[a-z|0-9]*)\s?->\s(?<outputWire>[a-z]*)");
            var matches = regex.Match(rawInstruction);

            var lhs = matches.Groups["lhs"].Value;
            var rhs = matches.Groups["rhs"].Value;
            var instructionOperator = matches.Groups["operator"].Value;
            var outputWire = matches.Groups["outputWire"].Value;

            return new InstructionComponents(
                new InstructionExpression(lhs), 
                new InstructionExpression(rhs), 
                ToInstructionOperator(instructionOperator), 
                new Wire(outputWire));
        }

        private static InstructionOperator ToInstructionOperator(string rawInstructionOperator)
        {
            InstructionOperator instructionOperator;
            var success = Enum.TryParse(rawInstructionOperator, true, out instructionOperator);

            return success ? instructionOperator : InstructionOperator.ASSIGNMENT;
        }
    }
}