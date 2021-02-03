using System;
using System.Collections.Generic;
using System.IO;

namespace DictVotes
{
    class Program
    {
        static void Main(string[] args)
        {
            var path = @"c:\temp\in.txt";
            Dictionary<string, int> votes = new Dictionary<string, int>();
            try
            {
                using (StreamReader sr = File.OpenText(path))
                {
                    while (!sr.EndOfStream)
                    {
                        string[] line = sr.ReadLine().Split(',');
                        try
                        {
                            votes.Add(line[0], int.Parse(line[1]));
                        }
                        catch (ArgumentException)
                        {
                            votes[line[0]] += int.Parse(line[1]);
                        }
                    }
                }
            }
            catch (IOException e)
            {
                Console.WriteLine(e.Message);
            }

            foreach (var vote in votes)
            {
                Console.WriteLine(vote.Key + ": " + vote.Value);
            }
        }
    }
}