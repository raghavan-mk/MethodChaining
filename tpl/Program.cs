using System;
using System.Collections.Generic;
using System.IO;
using System.Text;
using System.Threading.Tasks;

namespace tpl {
    class Program {
        static void Main (string[] args) {
            Console.WriteLine(Test().Result);
            Console.WriteLine("i do not like to wait");
          
        }

        static async Task<int> Test(){
            await Task.Delay(10000).ConfigureAwait(false);
            return 1;
        }
    }
}