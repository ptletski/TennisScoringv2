using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using TennisScoringRules;
using System.Diagnostics;

namespace TennisScoringTest
{
    class Program
    {
        static void Main(string[] args)
        {
            TestGameScorer.ExecuteTestSuite();
            TestGamePlay.ExecuteTestSuite();
            TestSinglesMatchScorer.ExecuteTestSuite();
            TestSinglesTennisMatch.ExecuteTestSuite();

            Console.WriteLine("Tests Complete");
            Console.ReadKey();
        }
    }
}
