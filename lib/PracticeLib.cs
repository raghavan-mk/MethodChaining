using System;
using System.Collections.Generic;
using System.IO;
using System.Linq;

namespace lib {
    public class Practice {
        public void Select () { }

        public int Squared (int x) => x * x;

        public string Read (string path) =>

            Using<StreamReader, String> (
                () => new StreamReader (path), //Func<IDisposable> factory
                file => file.ReadToEnd () //Func<IDisposable, String> 
            );

        public TResult Using<TIDisposable, TResult> (
            Func<TIDisposable> factory,
            Func<TIDisposable, TResult> map
        ) where TIDisposable : IDisposable {
            using (var disposable = factory ()) {
                return map (disposable);
            }
        }

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

        public bool PredicateTest(Predicate<int> fn,int i){
            return fn(i);
        }
    }
}