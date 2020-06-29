using System;
using System.Threading;

namespace Roman.Ambinder.Infra.Common.ExtensionsAndHelpers
{
    public static class InterlockedHelpers
    {
        public static T InterlockedAny<T>(ref T source, Func<T, T> modify)
           where T : class, IEquatable<T>
        {
            while (true)
            {
                var currentValue = source;
                var newValue = modify(currentValue);

                var valueBeforeChange = Interlocked.CompareExchange(ref source,
                    newValue,
                    currentValue);

                if (valueBeforeChange == currentValue)
                    return currentValue;
            }
        }
    }
}
