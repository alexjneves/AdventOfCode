using System;
using System.Collections.Generic;
using System.IO;
using System.Linq;
using Common;

namespace Day6
{
    public sealed class Day6Solution : IDailyPuzzle
    {
        private const string SantaLightinginstructionsTxt = "SantaLightingInstructions.txt";
        private const int GridLength = 1000;

        private readonly IEnumerable<SantaLightingInstruction> _santaLightingInstructions;

        public Day6Solution()
        {
            _santaLightingInstructions = File.ReadAllLines(SantaLightinginstructionsTxt).Select(SantaLightingInstruction.Parse);
        }

        public int SolvePart1()
        {
            var lights = InitialiseLightGrid<OnOffLight>();

            ExecuteInstructions(lights);

            return ExecuteLightAggregateFunction(light => light.IsOn() ? 1 : 0, lights);
        }

        public int SolvePart2()
        {
            var lights = InitialiseLightGrid<DynamicBrightnessLight>();

            ExecuteInstructions(lights);

            return ExecuteLightAggregateFunction(light => light.Brightness, lights);
        }

        private static T[,] InitialiseLightGrid<T>() where T : Light, new()
        {
            var lights = new T[GridLength, GridLength];

            for (var i = 0; i < GridLength; ++i)
            {
                for (var j = 0; j < GridLength; ++j)
                {
                    lights[i, j] = new T();
                }
            }

            return lights;
        }

        private void ExecuteInstructions(Light[,] lights)
        {
            foreach (var instruction in _santaLightingInstructions)
            {
                for (var i = instruction.GridXStart; i < instruction.GridXEnd + 1; ++i)
                {
                    for (var j = instruction.GridYStart; j < instruction.GridYEnd + 1; ++j)
                    {
                        lights[i, j].ExecuteInstruction(instruction.LightInstruction);
                    }
                }
            }
        }

        private static int ExecuteLightAggregateFunction<T>(Func<T, int> aggregateFunction, T[,] lights) where T : Light
        {
            var result = 0;

            for (var i = 0; i < GridLength; ++i)
            {
                for (var j = 0; j < GridLength; ++j)
                {
                    result += aggregateFunction(lights[i, j]);
                }
            }

            return result;
        }
    }
}
