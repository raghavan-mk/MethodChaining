using System;
using System.Collections.Generic;
using System.IO;
using System.Linq;
using System.Text;

namespace lib {

    public class MethodChaining {

        private static string BuildSelectBox (IDictionary<int, string> options, string id, bool includeUnknown) {

            var html = new StringBuilder ();
            html.AppendFormat ("<select id=\"{0}\" name=\"{0}\">", id);
            html.AppendLine ();

            if (includeUnknown) {
                html.AppendLine ("\t<option>Unknown</option>");
            }

            foreach (var opt in options) {
                html.AppendFormat ("\t<option value=\"{0}\">{1}</option>", opt.Key, opt.Value);
                html.AppendLine ();
            }

            html.AppendLine ("</select>");

            return html.ToString ();
        }

        public static TResult Using<TIDisposable, TResult> (TIDisposable factory, Func<TIDisposable, TResult> fn)
        where TIDisposable : IDisposable {
            using (var disposable = factory) {
                return fn (disposable);
            }
        }
        public static void BuildSelectBox () {

            byte[] buffer;

            using (var stream = GetStream())
            {
                buffer = new byte[stream.Length];
                stream.Read(buffer, 0, (int)stream.Length);
            }

            var options =
                Encoding
                    .UTF8
                    .GetString(buffer)
                    .Split(new[] { Environment.NewLine, }, StringSplitOptions.RemoveEmptyEntries)
                    .Select((s, ix) => Tuple.Create(ix, s))
                    .ToDictionary(k => k.Item1, v => v.Item2);

            var selectBox = BuildSelectBox(options, "theDoctors", true);

            Console.WriteLine(selectBox);

            Console.ReadLine();
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