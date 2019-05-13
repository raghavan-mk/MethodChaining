using System;
using System.Collections.Generic;
using System.IO;
using System.Text;
using System.Threading.Tasks;

namespace tpl {
    class Program {
        static async Task Main (string[] args) {
            Console.WriteLine(Test().Result);
            Console.WriteLine("i do not like to wait");
            await DoSomethingAsync();
          
        }

        static async Task<int> Test(){
            await Task.Delay(10000).ConfigureAwait(false);
            return 1;
        }

        static async Task<int> DoSomethingAsync() => await Task.Run(() => 1).ConfigureAwait(false);
    }
}