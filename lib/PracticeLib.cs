using System;
using System.Collections.Generic;
using System.Drawing;
using System.IO;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace lib {
    public class Practice {

        public void Select () { }

        public TResult Using<TIDisposable, TResult> (Func<TIDisposable> factory, Func<TIDisposable, TResult> fn)
        where TIDisposable : IDisposable {
            using (var disposable = factory ()) {
                return fn (disposable);
            }
        }

        public int Squared (int x) => x * x;

        public string Read (string path) =>

            Using (
                () => new StreamReader (path), //Func<IDisposable> factory
                file => file.ReadToEnd() //Func<IDisposable, String> 
            );

        public IEnumerable<int> SortFunc (IList<int> input) =>
            input.Where (x => x % 2 != 0).
        OrderBy (x => x);

        public IEnumerable<int> Sort (List<int> input) {
            List<int> output = new List<int> ();

            input.ForEach (i => {
                if (i % 2 != 0)
                    output.Add (i);
            });

            return output.OrderBy (x => x);

        }

        public string StringInterpolate (int i, int j) {
            return $"Values with new string format {i}, {j}.And today's date is {DateTime.Now}";
        }

        public List<DateTime> GetDates () =>
            new List<DateTime> {
                DateTime.Parse ("1-2-2010"),
                DateTime.Parse ("1-3-2010"),
                DateTime.Parse ("1-4-2010"),
                DateTime.Parse ("1-5-2010")
            };

        public bool PredicateTest (Predicate<int> fn, int i) {
            return fn (i);
        }

        public object NullReferences () {
            StringBuilder x = new StringBuilder ();
            x.Append ("hello");
            StringBuilder y = x;
            y = null;
            return x;
        }

        public object ReferenceValueChange () {
            StringBuilder x = new StringBuilder ();
            x.Append ("hello");
            StringBuilder y = x;
            y.Append ("world");
            return x;
        }

        public void OutVariables () {
            OutVariableParams (out var x, out var y);
            Console.WriteLine ($"({x}, {y})");
        }

        public void OutVariableParams (out int x, out int y) {
            x = 1;
            y = 2;
        }

        public (string first, int age, string last) TupleReturn () =>
            ("Raghavan", 37, "Iyengar");

        public string ForEachLoop (Dictionary<int, string> inputs) {

            string args = "";

            foreach (var i in inputs) {
                args += i.Value + ",";
            }

            return args.TrimEnd (',');
        }

        public int Add (int x, int y) => x + y;

        public Func<int, int> AddFunc (int x) => y => x + y;

        public List<String> CheckForRefTypes(){
            List<String> ids = new List<string>{
                "1","2","3","4"
            };
            CheckForRefTypes(ref ids);
            return ids;
        }

        public void CheckForRefTypes(ref List<String> ids){
            ids.Add("5");
        }

        public int RefArrays(){
            int[] ints = {1,2,3};
            RefArrays(ints);
            return ints[0];
        }

        public int RefArrays_1(){
            int[] ints = {1,2,3};
            RefArrays_1(ints);
            return ints[0];
        }

        public void RefArrays(params int[] ints){
            ints[0] = 100;            
        }

         public void RefArrays_1(params int[] ints){
            ints = new int[3];
            ints[0] = 101;  
         }
    }
}