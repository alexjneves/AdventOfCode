using System;
using Day7.Instruction.Instructions;

namespace Day7.Instruction
{
    internal sealed class InstructionFactory
    {
        public IInstruction Create(string rawInstruction)
        {
            var components = InstructionComponents.Parse(rawInstruction);

            switch (components.InstructionOperator)
            {
                case InstructionOperator.AND:
                    return new AndInstruction(components.LhsExpression, components.RhsExpression, components.OutputWire);
                case InstructionOperator.OR:
                    return new OrInstruction(components.LhsExpression, components.RhsExpression, components.OutputWire);
                case InstructionOperator.NOT:
                    return new NotInstruction(components.RhsExpression, components.OutputWire);
                case InstructionOperator.LSHIFT:
                    return new LShiftInstruction(components.LhsExpression, components.RhsExpression, components.OutputWire);
                case InstructionOperator.RSHIFT:
                    return new RShiftInstruction(components.LhsExpression, components.RhsExpression, components.OutputWire);
                case InstructionOperator.ASSIGNMENT:
                    return new AssignmentInstruction(components.LhsExpression, components.OutputWire);
                default:
                    throw new Exception($"Unsupported Instruction Operator: {components.InstructionOperator}");
            }
        }
    }
}