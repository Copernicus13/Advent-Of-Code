﻿using System;
using AdventOfCode.Common;

namespace AdventOfCode._2015
{
    public class Day5
    {
        public Day5(Part p)
        {
            int result = 0;
            string line;
            while (!string.IsNullOrEmpty(line = Console.ReadLine()))
            {
                if (p == Part.Part1)
                {
                    if (has3Vowels(line) && hasDoubleLetter(line) && isClean(line))
                        ++result;
                }
                else if (p == Part.Part2)
                {
                    if (hasDoublePairOfLetter(line) && hasRepeatedLetter(line))
                        ++result;
                }
            }
            Console.WriteLine(result);
        }

        private bool isClean(string line)
        {
            return !line.Contains("ab") && !line.Contains("cd") &&
                !line.Contains("pq") && !line.Contains("xy");
        }

        private bool hasDoubleLetter(string line)
        {
            char last = '\0';
            foreach (char c in line)
            {
                if (c == last)
                    return true;
                last = c;
            }
            return false;
        }

        private bool has3Vowels(string line)
        {
            int vowels = 0;
            foreach (char c in line)
            {
                if (c == 'a')
                    ++vowels;
                else if (c == 'e')
                    ++vowels;
                else if (c == 'i')
                    ++vowels;
                else if (c == 'o')
                    ++vowels;
                else if (c == 'u')
                    ++vowels;
                if (vowels >= 3)
                    return true;
            }
            return false;
        }

        private bool hasDoublePairOfLetter(string line)
        {
            for (int i = 0; i < line.Length - 3; ++i)
            {
                string current = line.Substring(i);
                if (current.Substring(2).Contains(current.Substring(0, 2)))
                    return true;
            }
            return false;
        }

        private bool hasRepeatedLetter(string line)
        {
            for (int i = 0; i < line.Length - 2; ++i)
            {
                if (line[i] == line[i + 2])
                    return true;
            }
            return false;
        }
    }
}
