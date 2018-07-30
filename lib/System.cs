using System;

namespace System {

    public class Dispose {
        public static TResult Using<TIDisposable, TResult> (Func<TIDisposable> factory,
            Func<TIDisposable, TResult> fn)
        where TIDisposable : IDisposable {
            using (var disposable = factory ()) {
                return fn (disposable);
            }
        }
    }
    public static class SystemExtn {
        public static TResult Map<TResult, TSource> (this TSource @this, Func<TSource, TResult> fn) => fn (@this);

        public static T Tee<T> (this T @this, Action<T> action) {
            action (@this);
            return @this;
        }
    }
}