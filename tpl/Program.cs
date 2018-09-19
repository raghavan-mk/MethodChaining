using System;
using System.IO;
using System.Threading.Tasks;

namespace tpl {
    class Program {
        static void Main (string[] args) {

            Task<string> t = Task.Factory.StartNew (() => {
                using (StreamReader sr = new StreamReader 
                (@"/Users/HomeLaptop/Documents/VSCode/c#/C#_practice_lib/console/Program.cs")) {
                    return sr.ReadToEnd ();
                }
            });

            // var result = await t;

            Task t2 = t.ContinueWith ((a) => {
                Console.WriteLine (a.Result);
            });

            Console.WriteLine("Waiting...");
            Console.WriteLine("Still waiting...");

        }
    }
}