using System.IO;
using System.Linq;
using Common;

namespace Day6
{
    public sealed class Day6Solution : IDailyPuzzle
    {
        private const string SantaLightinginstructionsTxt = "SantaLightingInstructions.txt";
        private const int GridLength = 1000;

        private readonly string[] _santaLightingInstructions;
        private readonly Light[,] _lights;

        public Day6Solution()
        {
            _santaLightingInstructions = File.ReadAllLines(SantaLightinginstructionsTxt);
            _lights = new Light[GridLength, GridLength];

            for (var i = 0; i < GridLength; ++i)
            {
                for (var j = 0; j < GridLength; ++j)
                {
                    _lights[i, j] = new Light();
                }
            }
        }

        public int SolvePart1()
        {
            foreach (var instruction in _santaLightingInstructions.Select(SantaLightingInstruction.Parse))
            {
                for (var i = instruction.GridXStart; i < instruction.GridXEnd + 1; ++i)
                {
                    for (var j = instruction.GridYStart; j < instruction.GridYEnd + 1; ++j)
                    {
                        _lights[i, j].ExecuteInstruction(instruction.LightInstruction);
                    }
                }
            }

            var numberOfOnLights = 0;

            for (var i = 0; i < GridLength; ++i)
            {
                for (var j = 0; j < GridLength; ++j)
                {
                    if (_lights[i, j].IsOn())
                    {
                        ++numberOfOnLights;
                    }
                }
            }

            return numberOfOnLights;
        }

        public int SolvePart2()
        {
            return -1;
        }
    }
}
