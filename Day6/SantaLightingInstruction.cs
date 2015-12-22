using System.Text.RegularExpressions;

namespace Day6
{
    internal sealed class SantaLightingInstruction
    {
        private const char Separator = ',';
        public LightInstruction LightInstruction { get; }
        public int GridXStart { get; }
        public int GridXEnd { get; }
        public int GridYStart { get; }
        public int GridYEnd { get; }

        public SantaLightingInstruction(LightInstruction lightInstruction, int gridXStart, int gridXEnd, int gridYStart, int gridYEnd)
        {
            LightInstruction = lightInstruction;
            GridXStart = gridXStart;
            GridXEnd = gridXEnd;
            GridYStart = gridYStart;
            GridYEnd = gridYEnd;
        }

        public static SantaLightingInstruction Parse(string rawInstruction)
        {
            var lightInstruction = LightInstruction.Toggle;

            if (rawInstruction.Contains("on"))
            {
                lightInstruction = LightInstruction.On;
            }
            else if (rawInstruction.Contains("off"))
            {
                lightInstruction = LightInstruction.Off;
            }

            var regex = new Regex(@"([0-9,\,]*) through ([0-9,\,]*)");

            var match = regex.Match(rawInstruction);

            var firstCoordinates = match.Groups[1].Value.Split(Separator);
            var secondCoordinates = match.Groups[2].Value.Split(Separator);

            var gridXStart = int.Parse(firstCoordinates[0]);
            var gridXEnd = int.Parse(secondCoordinates[0]);

            var gridYStart = int.Parse(firstCoordinates[1]);
            var gridYEnd = int.Parse(secondCoordinates[1]);

            return new SantaLightingInstruction(lightInstruction, gridXStart, gridXEnd, gridYStart, gridYEnd);
        }
    }
}