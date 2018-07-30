using System;
using System.Collections.Generic;
using System.Linq;
using BenchmarkDotNet;
using BenchmarkDotNet.Attributes;
using BenchmarkDotNet.Running;
using lib;
using Xunit;

namespace test {
    public class PracticeTests {
        Practice _p = new Practice ();

        public PracticeTests () {

        }

        [Fact]
        public void Test1 () {
            List<int> ints = new List<int> { 1, 2, 3 };

            var squredlist = ints
                .Select (i => _p.Squared (i))
                .ToList ();

            Assert.Equal (4, squredlist[1]);

        }

        [Fact]
        public void TestStringInterpolation () {
            Console.WriteLine (_p.StringInterpolate (1, 2));
        }

        [Fact]
        public void TestForDates () {
            var dates = _p.GetDates ();
            dates.ForEach (d =>
                Console.WriteLine ($"{d:dd-MMM-yyyy}"));
        }

        [Fact]
        public void TestRead () {
            var text =
                _p.Read (@"/Users/HomeLaptop/Documents/VSCode/c#/C#_practice_lib/lib/PracticeLib.cs");
            Console.WriteLine (text);
        }

        [Fact]
        public void BuildSelectTextBox () {
            MethodChaining.BuildSelectBox ();
        }

        [Fact]
        public void MapTest () {

            String s = "";
            string result = s.Map ((q) => s + "hello");
            Assert.Equal ("hello", result);

        }

        [Fact]
        public void TestForNullReferences () {
            var o = _p.NullReferences ();
            Assert.NotNull (o);
        }

        [Fact]
        public void TestForReferenceValueChanges () {
            var o = _p.NullReferences ();
            Assert.Equal (o.ToString (), "hello world");
        }
        [Fact]
        public void TestAddFuncTwoNos(){
            var actual = _p.AddFunc(1)(12);
            var actuals = new int[]{1,2,3,4,5}.Select(s => _p.AddFunc(s)(5)).ToArray();
            Assert.Equal(10,actuals[4]);
        }
    }
}