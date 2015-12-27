using Day7.Instruction;
using FluentAssertions;
using NUnit.Framework;

namespace Day7.Test
{
    [TestFixture]
    internal sealed class InstructionComponentsTests
    {
        [TestCase("lx -> a", "lx", InstructionOperator.ASSIGNMENT, "", "a")]
        [TestCase("1 AND bh -> bi", "1", InstructionOperator.AND, "bh", "bi")]
        [TestCase("ih AND ij -> ik", "ih", InstructionOperator.AND, "ij", "ik")]
        [TestCase("lw OR lv -> lx", "lw", InstructionOperator.OR, "lv", "lx")]
        [TestCase("NOT p -> q", "", InstructionOperator.NOT, "p", "q")]
        [TestCase("hb LSHIFT 1 -> hv", "hb", InstructionOperator.LSHIFT, "1", "hv")]
        [TestCase("bn RSHIFT 2 -> bo", "bn", InstructionOperator.RSHIFT, "2", "bo")]
        public void Parse_ReturnsExpectedInstructionComponents(string rawInstruction, string expectedLhsExpression, 
            InstructionOperator expectedInstructionOperator, string expectedRhsExpression, string expectedOutputWireIdentifier)
        {
            var actualInstructionComponents = InstructionComponents.Parse(rawInstruction);

            actualInstructionComponents.LhsExpression.Expression.Should().Be(expectedLhsExpression);
            actualInstructionComponents.RhsExpression.Expression.Should().Be(expectedRhsExpression);
            actualInstructionComponents.InstructionOperator.Should().Be(expectedInstructionOperator);
            actualInstructionComponents.OutputWire.Identifier.Should().Be(expectedOutputWireIdentifier);
        }
    }
}