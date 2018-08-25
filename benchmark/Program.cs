using System;
using BenchmarkDotNet.Attributes;
using BenchmarkDotNet.Characteristics;
using BenchmarkDotNet.Configs;
using BenchmarkDotNet.Environments;
using BenchmarkDotNet.Jobs;
using BenchmarkDotNet.Running;
using lib;

namespace Practice {

    public class Program {

        public static void Main (string[] args) {

            Console.WriteLine ("Benchmarking...");
            BenchmarkRunner.Run<BchMark> ();
        }
    }

    //[Config (typeof (Config))]
    [ShortRunJob]
    public class BchMark {

        // private class Config : ManualConfig {
        //     public Config () {

        //         Add (new Job (EnvironmentMode.Clr, RunMode.Short) {
        //             Run = { LaunchCount = 3, WarmupCount = 5, IterationCount = 10 },
        //             Accuracy = { MaxRelativeError = 0.01 }
        //         });

        //     }

        // [Benchmark]
        // public void BuildSelectBox () {
        //     MethodChaining.BuildSelectBox ();
        // }

        // [Benchmark]
        // public void BuildSelectBox_0 () {
        //     MethodChaining.BuildSelectBox_0 ();
        // }

        [Benchmark]
        public void Test () {
            for(int i=0;i<1000;i++)
                Console.WriteLine(i);
        }

    }

}