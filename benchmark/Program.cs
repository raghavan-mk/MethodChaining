using System;
using System.Collections.Generic;

using BenchmarkDotNet.Attributes;
using BenchmarkDotNet.Running;

namespace Practice {
    public class Program {
        public static void Main (string[] args) {
            BenchmarkRunner.Run<BchMark>();
        }
    }
    public class BchMark {

        [Benchmark]
        public List<string> InitializeListWithItems () {
            return new List<string> {
                "item0",
                "item1",
                "item2",
                "item3",
                "item4",
                "item5",
                "item6",
                "item7",
                "item8"
            };
        }

        [Benchmark]
        public List<String> CreateList () {
            var list = new List<string> ();
            list.Add ("item0");
            list.Add ("item1");
            list.Add ("item2");
            list.Add ("item3");
            list.Add ("item4");
            list.Add ("item5");
            list.Add ("item6");
            list.Add ("item7");
            list.Add ("item8");
            return list;
        }

    }

}