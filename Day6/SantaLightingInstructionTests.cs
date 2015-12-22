using FluentAssertions;
using NUnit.Framework;

namespace Day6
{
    [TestFixture]
    internal sealed class SantaLightingInstructionTests
    {
        [TestCase("toggle 461,550 through 564,900", LightInstruction.Toggle, 461, 564, 550, 900)]
        [TestCase("turn on 606,361 through 892,600", LightInstruction.On, 606, 892, 361, 600)]
        [TestCase("turn off 38,720 through 682,751", LightInstruction.Off, 38, 682, 720, 751)]
        public void Parse_ReturnsExpectedInstruction(string rawInstruction, LightInstruction expectedInstruction,
            int expectedGridXStart, int expectedGridXEnd,
            int expectedGridYStart, int expectedGridYEnd)
        {
            var parsedInstruction = SantaLightingInstruction.Parse(rawInstruction);

            parsedInstruction.LightInstruction.ShouldBeEquivalentTo(expectedInstruction);
            parsedInstruction.GridXStart.Should().Be(expectedGridXStart);
            parsedInstruction.GridXEnd.Should().Be(expectedGridXEnd);
            parsedInstruction.GridYStart.Should().Be(expectedGridYStart);
            parsedInstruction.GridYEnd.Should().Be(expectedGridYEnd);
        }
    }
}