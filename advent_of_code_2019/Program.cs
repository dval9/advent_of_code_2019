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
            //Problem1(@"..\..\problem1.txt");
            Problem2(@"..\..\problem2.txt");
            //Problem3(@"..\..\problem3.txt");
            //Problem4(@"..\..\problem4.txt");
            //Problem5(@"..\..\problem5.txt");
            //Problem6(@"..\..\problem6.txt");
            //Problem7(@"..\..\problem7.txt");
            //Problem8(@"..\..\problem8.txt");
            //Problem9(@"..\..\problem9.txt");
            //Problem10(@"..\..\problem10.txt");
            //Problem11(@"..\..\problem11.txt");
            //Problem12(@"..\..\problem12.txt");
            //Problem13(@"..\..\problem13.txt");
            //Problem14(@"..\..\problem14.txt");
            //Problem15(@"..\..\problem15.txt");
            //Problem16(@"..\..\problem16.txt");
            //Problem17(@"..\..\problem17.txt");
            //Problem18(@"..\..\problem18.txt");
            //Problem19(@"..\..\problem19.txt");
            //Problem20(@"..\..\problem20.txt");
            //Problem21(@"..\..\problem21.txt");
            //Problem22(@"..\..\problem22.txt");
            //Problem23(@"..\..\problem23.txt");
            //Problem24(@"..\..\problem24.txt");
            //Problem25(@"..\..\problem25.txt");
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

            //program = new int[9] { 1, 1, 1, 4, 99, 5, 6, 0, 99 };

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
            ip++;
            return program;
        }

        /// <summary>
        /// DAY 3
        /// Part 1: 
        /// Part 2: 
        /// </summary>
        /// <param name="__input">File name to read the input</param>
        static void Problem3(string __input)
        {
            string part1 = "";
            string part2 = "";
            var line = File.ReadAllLines(__input);

            Console.WriteLine("Day 3, Problem 1: " + part1);
            Console.WriteLine("Day 3, Problem 2: " + part2);
        }

        /// <summary>
        /// DAY 4
        /// Part 1: 
        /// Part 2: 
        /// </summary>
        /// <param name="__input">File name to read the input</param>
        static void Problem4(string __input)
        {
            string part1 = "";
            string part2 = "";
            var line = File.ReadAllLines(__input);

            Console.WriteLine("Day 4, Problem 1: " + part1);
            Console.WriteLine("Day 4, Problem 2: " + part2);
        }

        /// <summary>
        /// DAY 5
        /// Part 1: 
        /// Part 2: 
        /// </summary>
        /// <param name="__input">File name to read the input</param>
        static void Problem5(string __input)
        {
            string part1 = "";
            string part2 = "";
            var line = File.ReadAllLines(__input);

            Console.WriteLine("Day 5, Problem 1: " + part1);
            Console.WriteLine("Day 5, Problem 2: " + part2);
        }

        /// <summary>
        /// DAY 6
        /// Part 1: 
        /// Part 2: 
        /// </summary>
        /// <param name="__input">File name to read the input</param>
        static void Problem6(string __input)
        {
            string part1 = "";
            string part2 = "";
            var line = File.ReadAllLines(__input);

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
            var line = File.ReadAllLines(__input);

            Console.WriteLine("Day 25, Problem 1: " + part1);
            Console.WriteLine("Day 25, Problem 2: " + part2);
        }
    }
}
