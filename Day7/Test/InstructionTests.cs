using Day7.Instruction.Instructions;
using NUnit.Framework;

namespace Day7.Test
{
    [TestFixture]
    internal sealed class AndInstructionTests : InstructionTestBase
    {
        protected override IInstruction CreateInstruction() => new AndInstruction(LhsExpression, RhsExpression, OutputWire);

        protected override int ExpectedOutputWireSignal => LhsExpressionValue & RhsExpressionValue;
    }

    [TestFixture]
    internal sealed class OrInstructionTests : InstructionTestBase
    {
        protected override IInstruction CreateInstruction() => new OrInstruction(LhsExpression, RhsExpression, OutputWire);

        protected override int ExpectedOutputWireSignal => LhsExpressionValue | RhsExpressionValue;
    }

    [TestFixture]
    internal sealed class NotInstructionTests : InstructionTestBase
    {
        protected override IInstruction CreateInstruction() => new NotInstruction(LhsExpression, OutputWire);

        protected override int ExpectedOutputWireSignal => ~LhsExpressionValue;
    }

    [TestFixture]
    internal sealed class LShiftInstructionTests : InstructionTestBase
    {
        protected override IInstruction CreateInstruction() => new LShiftInstruction(LhsExpression, RhsExpression, OutputWire);

        protected override int ExpectedOutputWireSignal => LhsExpressionValue << RhsExpressionValue;
    }

    [TestFixture]
    internal sealed class RShiftInstructionTests : InstructionTestBase
    {
        protected override IInstruction CreateInstruction() => new RShiftInstruction(LhsExpression, RhsExpression, OutputWire);

        protected override int ExpectedOutputWireSignal => LhsExpressionValue >> RhsExpressionValue;
    }

    [TestFixture]
    internal sealed class AssignmentInstructionTests : InstructionTestBase
    {
        protected override IInstruction CreateInstruction() => new AssignmentInstruction(LhsExpression, OutputWire);

        protected override int ExpectedOutputWireSignal => LhsExpressionValue;
    }
}