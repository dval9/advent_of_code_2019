using System;
using System.Collections.Generic;
using System.Linq;
using System.IO;
using System.Text.RegularExpressions;

namespace advent_of_code_2019
{
    class Program
    {
        static void Main(string[] args)
        {
            //Problem1(@"..\..\..\problem1.txt");
            //Problem2(@"..\..\..\problem2.txt");
            //Problem3(@"..\..\..\problem3.txt");
            //Problem4(@"..\..\..\problem4.txt");
            //Problem5(@"..\..\..\problem5.txt");
            Problem6(@"..\..\..\problem6.txt");
            //Problem7(@"..\..\..\problem7.txt");
            //Problem8(@"..\..\..\problem8.txt");
            //Problem9(@"..\..\..\problem9.txt");
            //Problem10(@"..\..\..\problem10.txt");
            //Problem11(@"..\..\..\problem11.txt");
            //Problem12(@"..\..\..\problem12.txt");
            //Problem13(@"..\..\..\problem13.txt");
            //Problem14(@"..\..\..\problem14.txt");
            //Problem15(@"..\..\..\problem15.txt");
            //Problem16(@"..\..\..\problem16.txt");
            //Problem17(@"..\..\..\problem17.txt");
            //Problem18(@"..\..\..\problem18.txt");
            //Problem19(@"..\..\..\problem19.txt");
            //Problem20(@"..\..\..\problem20.txt");
            //Problem21(@"..\..\..\problem21.txt");
            //Problem22(@"..\..\..\problem22.txt");
            //Problem23(@"..\..\..\problem23.txt");
            //Problem24(@"..\..\..\problem24.txt");
            //Problem25(@"..\..\..\problem25.txt");
            Console.ReadLine();
        }

        /// <summary>
        /// DAY 1
        /// Part 1: Calculate fuel required for ship. For each module fuel = mass / 3 - 2
        /// Part 2: Calculate additional fuel to compensate for fuel
        /// </summary>
        /// <param name="__input">File name to read the input</param>
        static void Problem1(string __input)
        {
            string part1 = "";
            string part2 = "";
            var line = File.ReadAllLines(__input);

            int fuel1 = 0;
            foreach (var l in line)
                fuel1 += int.Parse(l) / 3 - 2;

            part1 = fuel1.ToString();

            int fuel2 = 0;
            foreach (var l in line)
            {
                var fuel = int.Parse(l) / 3 - 2;
                var additionl_fuel = fuel / 3 - 2;
                while (additionl_fuel > 0)
                {
                    fuel += additionl_fuel;
                    additionl_fuel = additionl_fuel / 3 - 2;
                }
                fuel2 += fuel;
            }

            part2 = fuel2.ToString();

            Console.WriteLine("Day 1, Problem 1: " + part1);
            Console.WriteLine("Day 1, Problem 2: " + part2);
        }

        /// <summary>
        /// DAY 2
        /// Part 1: Simulate Intcode program, and return value at position 0
        /// Part 2: 
        /// </summary>
        /// <param name="__input">File name to read the input</param>
        static void Problem2(string __input)
        {
            string part1 = "";
            string part2 = "";
            char[] delims = { ',' };
            var line = File.ReadAllLines(__input)[0].Split(delims, StringSplitOptions.RemoveEmptyEntries);

            int[] program = Array.ConvertAll(line, s => int.Parse(s));
            program[1] = 12;
            program[2] = 2;

            part1 = IntCodeComputer(program)[0].ToString();

            for (int i = 0; i <= 99; i++)
            {
                for (int j = 0; j <= 99; j++)
                {
                    program = Array.ConvertAll(line, s => int.Parse(s));
                    program[1] = i;
                    program[2] = j;

                    if (IntCodeComputer(program)[0] == 19690720)
                    {
                        part2 = (100 * i + j).ToString();
                        i = 100;
                        j = 100;
                    }
                }
            }


            Console.WriteLine("Day 2, Problem 1: " + part1);
            Console.WriteLine("Day 2, Problem 2: " + part2);
        }

        static int[] IntCodeComputer(int[] program)
        {
            int ip = 0;
            while (program[ip] != 99)
            {
                switch (program[ip])
                {
                    case 1:
                        program[program[ip + 3]] = program[program[ip + 1]] + program[program[ip + 2]];
                        ip += 4;
                        break;
                    case 2:
                        program[program[ip + 3]] = program[program[ip + 1]] * program[program[ip + 2]];
                        ip += 4;
                        break;
                }
            }

            return program;
        }

        /// <summary>
        /// DAY 3
        /// Part 1: Find intersection between wires, calculate manhattan distance for minimum
        /// Part 2: Find intersection between wires, calculate shortest path on both wires
        /// </summary>
        /// <param name="__input">File name to read the input</param>
        static void Problem3(string __input)
        {
            string part1 = "";
            string part2 = "";
            char[] delims = { ',' };
            var line = File.ReadAllLines(__input);

            var wire1 = new Dictionary<(int, int), int>();
            var wire2 = new Dictionary<(int, int), int>();
            int x1 = 0, x2 = 0, y1 = 0, y2 = 0, c1 = 0, c2 = 0;

            var line1 = line[0].Split(delims, StringSplitOptions.RemoveEmptyEntries);
            var line2 = line[1].Split(delims, StringSplitOptions.RemoveEmptyEntries);
            foreach (var s in line1)
            {
                switch (s[0])
                {
                    case 'R':
                        for (int i = 0; i < int.Parse(s.Substring(1)); i++)
                        {
                            x1++;
                            if (!wire1.ContainsKey((x1, y1)))
                                wire1.Add((x1, y1), c1);
                            c1++;
                        }
                        break;
                    case 'L':
                        for (int i = 0; i < int.Parse(s.Substring(1)); i++)
                        {
                            x1--;
                            if (!wire1.ContainsKey((x1, y1)))
                                wire1.Add((x1, y1), c1);
                            c1++;
                        }
                        break;
                    case 'U':
                        for (int i = 0; i < int.Parse(s.Substring(1)); i++)
                        {
                            y1++;
                            if (!wire1.ContainsKey((x1, y1)))
                                wire1.Add((x1, y1), c1);
                            c1++;
                        }
                        break;
                    case 'D':
                        for (int i = 0; i < int.Parse(s.Substring(1)); i++)
                        {
                            y1--;
                            if (!wire1.ContainsKey((x1, y1)))
                                wire1.Add((x1, y1), c1);
                            c1++;
                        }
                        break;
                }
            }
            foreach (var s in line2)
            {
                switch (s[0])
                {
                    case 'R':
                        for (int i = 0; i < int.Parse(s.Substring(1)); i++)
                        {
                            x2++;
                            if (!wire2.ContainsKey((x2, y2)))
                                wire2.Add((x2, y2), c2);
                            c2++;
                        }
                        break;
                    case 'L':
                        for (int i = 0; i < int.Parse(s.Substring(1)); i++)
                        {
                            x2--;
                            if (!wire2.ContainsKey((x2, y2)))
                                wire2.Add((x2, y2), c2);
                            c2++;
                        }
                        break;
                    case 'U':
                        for (int i = 0; i < int.Parse(s.Substring(1)); i++)
                        {
                            y2++;
                            if (!wire2.ContainsKey((x2, y2)))
                                wire2.Add((x2, y2), c2);
                            c2++;
                        }
                        break;
                    case 'D':
                        for (int i = 0; i < int.Parse(s.Substring(1)); i++)
                        {
                            y2--;
                            if (!wire2.ContainsKey((x2, y2)))
                                wire2.Add((x2, y2), c2);
                            c2++;
                        }
                        break;
                }
            }

            var intersect = wire1.Keys.Intersect(wire2.Keys);
            part1 = intersect.Min(x => Math.Abs(x.Item1) + Math.Abs(x.Item2)).ToString();
            part2 = (intersect.Min(x => wire1[x] + wire2[x]) + 2).ToString();

            Console.WriteLine("Day 3, Problem 1: " + part1);
            Console.WriteLine("Day 3, Problem 2: " + part2);
        }

        /// <summary>
        /// DAY 4
        /// Part 1: Count strings matching criteria, digits must ascend, must have matching pair, be within input range.
        /// Part 2: Must have ONLY matching pairs, not longer.
        /// </summary>
        /// <param name="__input">File name to read the input</param>
        static void Problem4(string __input)
        {
            string part1 = "";
            string part2 = "";
            char[] delims = { '-' };
            var line = File.ReadAllLines(__input);
            int min = int.Parse(line[0].Split(delims, StringSplitOptions.RemoveEmptyEntries)[0]);
            int max = int.Parse(line[0].Split(delims, StringSplitOptions.RemoveEmptyEntries)[1]);

            int count1 = 0;
            int count2 = 0;
            for (int i = min; i <= max; i++)
            {
                var num = i.ToString();
                var sort = num.OrderBy(x => x);
                if (Enumerable.SequenceEqual(num, sort) && sort.GroupBy(x => x).Where(x => x.Count() >= 2).Count() > 0)
                    count1++;
                if (Enumerable.SequenceEqual(num, sort) && sort.GroupBy(x => x).Where(x => x.Count() == 2).Count() > 0)
                    count2++;
            }

            part1 = count1.ToString();
            part2 = count2.ToString();

            Console.WriteLine("Day 4, Problem 1: " + part1);
            Console.WriteLine("Day 4, Problem 2: " + part2);
        }

        /// <summary>
        /// DAY 5
        /// Part 1: Update IntCode program simulator, add input/output and immediate values
        /// Part 2: Add jumps and equal tests
        /// </summary>
        /// <param name="__input">File name to read the input</param>
        static void Problem5(string __input)
        {
            string part1 = "";
            string part2 = "";
            char[] delims = { ',' };
            var line = File.ReadAllLines(__input)[0].Split(delims, StringSplitOptions.RemoveEmptyEntries);

            int[] program = Array.ConvertAll(line, s => int.Parse(s));
            List<int> input = new List<int> { 1 };
            List<int> output = new List<int>();
            IntCodeComputerV2(program, input, output);

            part1 = output[output.Count - 1].ToString();

            program = Array.ConvertAll(line, s => int.Parse(s));
            input = new List<int> { 5 };
            output = new List<int>();
            IntCodeComputerV2(program, input, output);

            part2 = output[output.Count - 1].ToString();

            Console.WriteLine("Day 5, Problem 1: " + part1);
            Console.WriteLine("Day 5, Problem 2: " + part2);
        }

        static int[] IntCodeComputerV2(int[] program, List<int> input, List<int> output)
        {
            int ip = 0;
            while (program[ip] != 99)
            {
                int opcode = program[ip] % 100;
                var parameters = (program[ip] / 100).ToString().Reverse().Select(x => int.Parse(x.ToString())).ToList();
                parameters.Add(0);

                switch (opcode)
                {
                    case 1:
                        int a = parameters[0] == 0 ? program[program[ip + 1]] : program[ip + 1];
                        int b = parameters[1] == 0 ? program[program[ip + 2]] : program[ip + 2];
                        program[program[ip + 3]] = a + b;
                        ip += 4;
                        break;
                    case 2:
                        a = parameters[0] == 0 ? program[program[ip + 1]] : program[ip + 1];
                        b = parameters[1] == 0 ? program[program[ip + 2]] : program[ip + 2];
                        program[program[ip + 3]] = a * b;
                        ip += 4;
                        break;
                    case 3:
                        program[program[ip + 1]] = input[0];
                        ip += 2;
                        break;
                    case 4:
                        a = parameters[0] == 0 ? program[program[ip + 1]] : program[ip + 1];
                        output.Add(a);
                        ip += 2;
                        break;
                    case 5:
                        a = parameters[0] == 0 ? program[program[ip + 1]] : program[ip + 1];
                        b = parameters[1] == 0 ? program[program[ip + 2]] : program[ip + 2];
                        ip = a != 0 ? b : ip + 3;
                        break;
                    case 6:
                        a = parameters[0] == 0 ? program[program[ip + 1]] : program[ip + 1];
                        b = parameters[1] == 0 ? program[program[ip + 2]] : program[ip + 2];
                        ip = a == 0 ? b : ip + 3;
                        break;
                    case 7:
                        a = parameters[0] == 0 ? program[program[ip + 1]] : program[ip + 1];
                        b = parameters[1] == 0 ? program[program[ip + 2]] : program[ip + 2];
                        program[program[ip + 3]] = a < b ? 1 : 0;
                        ip += 4;
                        break;
                    case 8:
                        a = parameters[0] == 0 ? program[program[ip + 1]] : program[ip + 1];
                        b = parameters[1] == 0 ? program[program[ip + 2]] : program[ip + 2];
                        program[program[ip + 3]] = a == b ? 1 : 0;
                        ip += 4;
                        break;
                }
            }

            return program;
        }

        /// <summary>
        /// DAY 6
        /// Part 1: Count the number of direct and indirect orbits.
        /// Part 2: Count distance to traverse from YOU to SAN.
        /// </summary>
        /// <param name="__input">File name to read the input</param>
        static void Problem6(string __input)
        {
            string part1 = "";
            string part2 = "";
            char[] delims = { ')' };
            var line = File.ReadAllLines(__input);
            //line = new string[] { "COM)B", "B)C", "C)D", "D)E", "E)F", "B)G", "G)H", "D)I", "E)J", "J)K", "K)L", "K)YOU", "I)SAN" };

            int count = 0;
            Dictionary<string, string> orbits = new Dictionary<string, string>();
            Queue<string> planets = new Queue<string>();
            foreach (var l in line)
            {
                var x = l.Split(delims, StringSplitOptions.RemoveEmptyEntries);
                orbits.Add(x[1], x[0]);
                planets.Enqueue(x[1]);
            }

            while (planets.Count != 0)
            {
                var x = planets.Dequeue();
                count++;
                if (orbits.ContainsKey(x))
                    planets.Enqueue(orbits[x]);
            }
            count -= orbits.Keys.Count;
            part1 = count.ToString();

            var key = "YOU";
            var path1 = new List<string>();
            while (orbits.ContainsKey(key))
            {
                path1.Add(orbits[key]);
                key = orbits[key];
            }
            key = "SAN";
            var path2 = new List<string>();
            while (orbits.ContainsKey(key))
            {
                path2.Add(orbits[key]);
                key = orbits[key];
            }
            var intersects = path1.Intersect(path2);
            part2 = (path1.Except(intersects).Count() + path2.Except(intersects).Count()).ToString();

            Console.WriteLine("Day 6, Problem 1: " + part1);
            Console.WriteLine("Day 6, Problem 2: " + part2);
        }

        /// <summary>
        /// DAY 7
        /// Part 1: 
        /// Part 2: 
        /// </summary>
        /// <param name="__input">File name to read the input</param>
        static void Problem7(string __input)
        {
            string part1 = "";
            string part2 = "";
            char[] delims = { ',' };
            var line = File.ReadAllLines(__input);

            Console.WriteLine("Day 7, Problem 1: " + part1);
            Console.WriteLine("Day 7, Problem 2: " + part2);
        }

        /// <summary>
        /// DAY 8
        /// Part 1: 
        /// Part 2: 
        /// </summary>
        /// <param name="__input">File name to read the input</param>
        static void Problem8(string __input)
        {
            string part1 = "";
            string part2 = "";
            char[] delims = { ',' };
            var line = File.ReadAllLines(__input);

            Console.WriteLine("Day 8, Problem 1: " + part1);
            Console.WriteLine("Day 8, Problem 2: " + part2);
        }

        /// <summary>
        /// DAY 9
        /// Part 1: 
        /// Part 2: 
        /// </summary>
        /// <param name="__input">File name to read the input</param>
        static void Problem9(string __input)
        {
            string part1 = "";
            string part2 = "";
            char[] delims = { ',' };
            var line = File.ReadAllLines(__input);

            Console.WriteLine("Day 9, Problem 1: " + part1);
            Console.WriteLine("Day 9, Problem 2: " + part2);
        }

        /// <summary>
        /// DAY 10
        /// Part 1: 
        /// Part 2: 
        /// </summary>
        /// <param name="__input">File name to read the input</param>
        static void Problem10(string __input)
        {
            string part1 = "";
            string part2 = "";
            char[] delims = { ',' };
            var line = File.ReadAllLines(__input);

            Console.WriteLine("Day 10, Problem 1: " + part1);
            Console.WriteLine("Day 10, Problem 2: " + part2);
        }

        /// <summary>
        /// DAY 11
        /// Part 1: 
        /// Part 2: 
        /// </summary>
        /// <param name="__input">File name to read the input</param>
        static void Problem11(string __input)
        {
            string part1 = "";
            string part2 = "";
            char[] delims = { ',' };
            var line = File.ReadAllLines(__input);

            Console.WriteLine("Day 11, Problem 1: " + part1);
            Console.WriteLine("Day 11, Problem 2: " + part2);
        }

        /// <summary>
        /// DAY 12
        /// Part 1: 
        /// Part 2: 
        /// </summary>
        /// <param name="__input">File name to read the input</param>
        static void Problem12(string __input)
        {
            string part1 = "";
            string part2 = "";
            char[] delims = { ',' };
            var line = File.ReadAllLines(__input);

            Console.WriteLine("Day 12, Problem 1: " + part1);
            Console.WriteLine("Day 12, Problem 2: " + part2);
        }

        /// <summary>
        /// DAY 13
        /// Part 1: 
        /// Part 2: 
        /// </summary>
        /// <param name="__input">File name to read the input</param>
        static void Problem13(string __input)
        {
            string part1 = "";
            string part2 = "";
            char[] delims = { ',' };
            var line = File.ReadAllLines(__input);

            Console.WriteLine("Day 13, Problem 1: " + part1);
            Console.WriteLine("Day 13, Problem 2: " + part2);
        }

        /// <summary>
        /// DAY 14
        /// Part 1: 
        /// Part 2: 
        /// </summary>
        /// <param name="__input">File name to read the input</param>
        static void Problem14(string __input)
        {
            string part1 = "";
            string part2 = "";
            char[] delims = { ',' };
            var line = File.ReadAllLines(__input);

            Console.WriteLine("Day 14, Problem 1: " + part1);
            Console.WriteLine("Day 14, Problem 2: " + part2);
        }

        /// <summary>
        /// DAY 15
        /// Part 1: 
        /// Part 2: 
        /// </summary>
        /// <param name="__input">File name to read the input</param>
        static void Problem15(string __input)
        {
            string part1 = "";
            string part2 = "";
            char[] delims = { ',' };
            var line = File.ReadAllLines(__input);

            Console.WriteLine("Day 15, Problem 1: " + part1);
            Console.WriteLine("Day 15, Problem 2: " + part2);
        }

        /// <summary>
        /// DAY 16
        /// Part 1: 
        /// Part 2: 
        /// </summary>
        /// <param name="__input">File name to read the input</param>
        static void Problem16(string __input)
        {
            string part1 = "";
            string part2 = "";
            char[] delims = { ',' };
            var line = File.ReadAllLines(__input);

            Console.WriteLine("Day 16, Problem 1: " + part1);
            Console.WriteLine("Day 16, Problem 2: " + part2);
        }

        /// <summary>
        /// DAY 17
        /// Part 1: 
        /// Part 2: 
        /// </summary>
        /// <param name="__input">File name to read the input</param>
        static void Problem17(string __input)
        {
            string part1 = "";
            string part2 = "";
            char[] delims = { ',' };
            var line = File.ReadAllLines(__input);

            Console.WriteLine("Day 17, Problem 1: " + part1);
            Console.WriteLine("Day 17, Problem 2: " + part2);
        }

        /// <summary>
        /// DAY 18
        /// Part 1: 
        /// Part 2: 
        /// </summary>
        /// <param name="__input">File name to read the input</param>
        static void Problem18(string __input)
        {
            string part1 = "";
            string part2 = "";
            char[] delims = { ',' };
            var line = File.ReadAllLines(__input);

            Console.WriteLine("Day 18, Problem 1: " + part1);
            Console.WriteLine("Day 18, Problem 2: " + part2);
        }

        /// <summary>
        /// DAY 19
        /// Part 1: 
        /// Part 2: 
        /// </summary>
        /// <param name="__input">File name to read the input</param>
        static void Problem19(string __input)
        {
            string part1 = "";
            string part2 = "";
            char[] delims = { ',' };
            var line = File.ReadAllLines(__input);

            Console.WriteLine("Day 19, Problem 1: " + part1);
            Console.WriteLine("Day 19, Problem 2: " + part2);
        }

        /// <summary>
        /// DAY 20
        /// Part 1: 
        /// Part 2: 
        /// </summary>
        /// <param name="__input">File name to read the input</param>
        static void Problem20(string __input)
        {
            string part1 = "";
            string part2 = "";
            char[] delims = { ',' };
            var line = File.ReadAllLines(__input);

            Console.WriteLine("Day 20, Problem 1: " + part1);
            Console.WriteLine("Day 20, Problem 2: " + part2);
        }

        /// <summary>
        /// DAY 21
        /// Part 1: 
        /// Part 2: 
        /// </summary>
        /// <param name="__input">File name to read the input</param>
        static void Problem21(string __input)
        {
            string part1 = "";
            string part2 = "";
            char[] delims = { ',' };
            var line = File.ReadAllLines(__input);

            Console.WriteLine("Day 21, Problem 1: " + part1);
            Console.WriteLine("Day 21, Problem 2: " + part2);
        }

        /// <summary>
        /// DAY 22
        /// Part 1: 
        /// Part 2: 
        /// </summary>
        /// <param name="__input">File name to read the input</param>
        static void Problem22(string __input)
        {
            string part1 = "";
            string part2 = "";
            char[] delims = { ',' };
            var line = File.ReadAllLines(__input);

            Console.WriteLine("Day 22, Problem 1: " + part1);
            Console.WriteLine("Day 22, Problem 2: " + part2);
        }

        /// <summary>
        /// DAY 23
        /// Part 1: 
        /// Part 2: 
        /// </summary>
        /// <param name="__input">File name to read the input</param>
        static void Problem23(string __input)
        {
            string part1 = "";
            string part2 = "";
            char[] delims = { ',' };
            var line = File.ReadAllLines(__input);

            Console.WriteLine("Day 23, Problem 1: " + part1);
            Console.WriteLine("Day 23, Problem 2: " + part2);
        }

        /// <summary>
        /// DAY 24
        /// Part 1: 
        /// Part 2: 
        /// </summary>
        /// <param name="__input">File name to read the input</param>
        static void Problem24(string __input)
        {
            string part1 = "";
            string part2 = "";
            char[] delims = { ',' };
            var line = File.ReadAllLines(__input);

            Console.WriteLine("Day 24, Problem 1: " + part1);
            Console.WriteLine("Day 24, Problem 2: " + part2);
        }

        /// <summary>
        /// DAY 25
        /// Part 1: 
        /// Part 2: 
        /// </summary>
        /// <param name="__input">File name to read the input</param>
        static void Problem25(string __input)
        {
            string part1 = "";
            string part2 = "";
            char[] delims = { ',' };
            var line = File.ReadAllLines(__input);

            Console.WriteLine("Day 25, Problem 1: " + part1);
            Console.WriteLine("Day 25, Problem 2: " + part2);
        }
    }
}
