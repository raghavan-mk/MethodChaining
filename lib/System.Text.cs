using System;
using System.Collections.Generic;
using System.Linq;

namespace System.Text {
        public static class StringBuilderExtn {
            public static StringBuilder AppendFormattedLine (
                    this StringBuilder @this, 
                string format,
                params object[] args) =>     

                 @this
                 .AppendFormat (format,args)
                 .AppendLine ();
        

        public static StringBuilder AppendWhen (
            this StringBuilder @this, 
            Func<bool> predicate,
            Func<StringBuilder,StringBuilder> fn) =>            

            predicate () ? 
                fn (@this): @this;

        public static StringBuilder AppendSequence<T> (this StringBuilder @this,
        IEnumerable<T> seq, 
        Func<StringBuilder,T,StringBuilder> fn ) =>
        
            seq.Aggregate (@this,fn);
        
        
    }
}