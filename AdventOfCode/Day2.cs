﻿using System;
using System.Collections.Generic;
using System.Linq;

namespace AdventOfCode
{
    // Day 2: 1202 Program Alarm
    public class Day2
    {
        private static class OpCode
        {
            internal const int End = 99;

            internal static readonly Dictionary<int, Func<int, int, int>> Actions = new Dictionary<int, Func<int, int, int>>()
            {
                { 1, (augend, addend) => augend + addend },
                { 2, (multiplicand, multiplier) => multiplicand * multiplier }
            };
        }

        public static int[] Parse(string input) => input
                .Split(',')
                .Select(int.Parse)
                .ToArray();

        public static int[] Execute(string input) => Execute(Parse(input));

        public static int[] Execute(int[] program)
        {
            var position = 0;

            while (program[position] != OpCode.End)
            {
                if (OpCode.Actions.ContainsKey(program[position]))
                {
                    program[program[position + 3]] = OpCode.Actions[program[position]](
                        program[program[position + 1]],
                        program[program[position + 2]]
                    );
                    position += 4;
                }
            }

            return program;
        }
    }
}
