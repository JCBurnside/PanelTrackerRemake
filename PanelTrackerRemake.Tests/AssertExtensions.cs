namespace PanelTrackerRemake.Tests
{
    using System;
    using System.Collections.Generic;
    using System.Text;

    public class AssertExtensions : Xunit.Assert
    {
        public static void ContainsAll<T>(IEnumerable<T> expected, IEnumerable<T> actual)
        {
            foreach (T t in expected)
            {
                Contains(t, actual);
            }
        }

        public static void ContainsAll<TKey, TValue>(IEnumerable<(TKey, TValue)> expected, IDictionary<TKey, TValue> actual)
        {
            foreach ((TKey key, TValue value) in expected)
            {
                TValue val = Contains(key, actual);
                Equal(value, val);
            }
        }
    }
}
