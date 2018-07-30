using System;
using System.Collections.Generic;
using System.IO;
using System.Linq;
using System.Text;
using BenchmarkDotNet;

namespace lib {

    public class MethodChaining {

        private static  Func<IDictionary<int,string>, string> BuildSelectBox (string id, bool includeUnknown) =>
            options =>
                new StringBuilder ()
                .AppendFormattedLine ("<select id=\"{0}\" name=\"{0}\">", id)
                .AppendWhen (() => includeUnknown, (s) => s.AppendLine ("\t<option>Unknown</option>"))
                .AppendSequence (options, (s, opt) =>
                    s.AppendFormattedLine ("\t<option value=\"{0}\">{1}</option>", opt.Key, opt.Value))
                .AppendLine ("</select>")
                .ToString ();

        public static void BuildSelectBox () {

            Dispose.Using<Stream, byte[]> (() => GetStream (),
                    (stream) => new byte[stream.Length].Tee ((b) => stream.Read (b, 0, (int) stream.Length)))
                .Map (Encoding.UTF8.GetString)
                .Split (new [] { Environment.NewLine, }, StringSplitOptions.RemoveEmptyEntries)
                .Select ((s, ix) => Tuple.Create (ix, s))
                .ToDictionary (k => k.Item1, v => v.Item2)
                .Map (BuildSelectBox ("theDoctors", true))
                .Tee ((s)=>Console.WriteLine(s));
        }

        public static Stream GetStream () {
            var doctors =
                String.Join (
                    Environment.NewLine,
                    new [] {
                        "Hartnell",
                        "Troughton",
                        "Pertwee",
                        "T. Baker",
                        "Davison",
                        "C. Baker",
                        "McCoy",
                        "McGann",
                        "Hurt",
                        "Eccleston",
                        "Tennant",
                        "Smith",
                        "Capaldi"
                    });

            var buffer = Encoding.UTF8.GetBytes (doctors);
            var stream = new MemoryStream ();
            stream.Write (buffer, 0, buffer.Length);
            stream.Position = 0L;
            return stream;

        }
    }
}