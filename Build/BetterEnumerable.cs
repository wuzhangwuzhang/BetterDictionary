﻿using System.Collections.Generic;

namespace System.Linq
{
    public static class BetterEnumerable
    {
        /// <summary>
        ///     Creates a <see cref="T:BetterDictionary`2" /> from an
        ///     <see cref="T:System.Collections.Generic.IEnumerable`1" /> according to a specified key selector function.
        /// </summary>
        /// <returns>A <see cref="T:BetterDictionary`2" /> that contains keys and values.</returns>
        /// <param name="source">
        ///     An <see cref="T:System.Collections.Generic.IEnumerable`1" /> to create a
        ///     <see cref="T:BetterDictionary`2" /> from.
        /// </param>
        /// <param name="keySelector">A function to extract a key from each element.</param>
        /// <typeparam name="TSource">The type of the elements of <paramref name="source" />.</typeparam>
        /// <typeparam name="TKey">The type of the key returned by <paramref name="keySelector" />.</typeparam>
        /// <exception cref="T:System.ArgumentNullException">
        ///     <paramref name="source" /> or <paramref name="keySelector" /> is null.-or-<paramref name="keySelector" /> produces
        ///     a key that is null.
        /// </exception>
        /// <exception cref="T:System.ArgumentException">
        ///     <paramref name="keySelector" /> produces duplicate keys for two elements.
        /// </exception>
        public static BetterDictionary<TKey, TSource> ToBetterDictionary<TSource, TKey>(
            this IEnumerable<TSource> source,
            Func<TSource, TKey> keySelector)
        {
            return source.ToBetterDictionary(keySelector, IdentityFunction<TSource>.Instance, null);
        }

        /// <summary>
        ///     Creates a <see cref="T:BetterDictionary`2" /> from an
        ///     <see cref="T:System.Collections.Generic.IEnumerable`1" /> according to a specified key selector function and key
        ///     comparer.
        /// </summary>
        /// <returns>A <see cref="T:BetterDictionary`2" /> that contains keys and values.</returns>
        /// <param name="source">
        ///     An <see cref="T:System.Collections.Generic.IEnumerable`1" /> to create a
        ///     <see cref="T:BetterDictionary`2" /> from.
        /// </param>
        /// <param name="keySelector">A function to extract a key from each element.</param>
        /// <param name="comparer">An <see cref="T:System.Collections.Generic.IEqualityComparer`1" /> to compare keys.</param>
        /// <typeparam name="TSource">The type of the elements of <paramref name="source" />.</typeparam>
        /// <typeparam name="TKey">The type of the keys returned by <paramref name="keySelector" />.</typeparam>
        /// <exception cref="T:System.ArgumentNullException">
        ///     <paramref name="source" /> or <paramref name="keySelector" /> is null.-or-<paramref name="keySelector" /> produces
        ///     a key that is null.
        /// </exception>
        /// <exception cref="T:System.ArgumentException">
        ///     <paramref name="keySelector" /> produces duplicate keys for two elements.
        /// </exception>
        public static BetterDictionary<TKey, TSource> ToBetterDictionary<TSource, TKey>(
            this IEnumerable<TSource> source,
            Func<TSource, TKey> keySelector, IEqualityComparer<TKey> comparer)
        {
            return source.ToBetterDictionary(keySelector, IdentityFunction<TSource>.Instance, comparer);
        }

        /// <summary>
        ///     Creates a <see cref="T:BetterDictionary`2" /> from an
        ///     <see cref="T:System.Collections.Generic.IEnumerable`1" /> according to specified key selector and element selector
        ///     functions.
        /// </summary>
        /// <returns>
        ///     A <see cref="T:BetterDictionary`2" /> that contains values of type
        ///     <paramref name="TElement" /> selected from the input sequence.
        /// </returns>
        /// <param name="source">
        ///     An <see cref="T:System.Collections.Generic.IEnumerable`1" /> to create a
        ///     <see cref="T:BetterDictionary`2" /> from.
        /// </param>
        /// <param name="keySelector">A function to extract a key from each element.</param>
        /// <param name="elementSelector">A transform function to produce a result element value from each element.</param>
        /// <typeparam name="TSource">The type of the elements of <paramref name="source" />.</typeparam>
        /// <typeparam name="TKey">The type of the key returned by <paramref name="keySelector" />.</typeparam>
        /// <typeparam name="TElement">The type of the value returned by <paramref name="elementSelector" />.</typeparam>
        /// <exception cref="T:System.ArgumentNullException">
        ///     <paramref name="source" /> or <paramref name="keySelector" /> or <paramref name="elementSelector" /> is null.-or-
        ///     <paramref name="keySelector" /> produces a key that is null.
        /// </exception>
        /// <exception cref="T:System.ArgumentException">
        ///     <paramref name="keySelector" /> produces duplicate keys for two elements.
        /// </exception>
        public static BetterDictionary<TKey, TElement> ToBetterDictionary<TSource, TKey, TElement>(
            this IEnumerable<TSource> source,
            Func<TSource, TKey> keySelector, Func<TSource, TElement> elementSelector)
        {
            return ToBetterDictionary(source, keySelector, elementSelector, null);
        }

        /// <summary>
        ///     Creates a <see cref="T:BetterDictionary`2" /> from an
        ///     <see cref="T:System.Collections.Generic.IEnumerable`1" /> according to a specified key selector function, a
        ///     comparer, and an element selector function.
        /// </summary>
        /// <returns>
        ///     A <see cref="T:BetterDictionary`2" /> that contains values of type
        ///     <paramref name="TElement" /> selected from the input sequence.
        /// </returns>
        /// <param name="source">
        ///     An <see cref="T:System.Collections.Generic.IEnumerable`1" /> to create a
        ///     <see cref="T:BetterDictionary`2" /> from.
        /// </param>
        /// <param name="keySelector">A function to extract a key from each element.</param>
        /// <param name="elementSelector">A transform function to produce a result element value from each element.</param>
        /// <param name="comparer">An <see cref="T:System.Collections.Generic.IEqualityComparer`1" /> to compare keys.</param>
        /// <typeparam name="TSource">The type of the elements of <paramref name="source" />.</typeparam>
        /// <typeparam name="TKey">The type of the key returned by <paramref name="keySelector" />.</typeparam>
        /// <typeparam name="TElement">The type of the value returned by <paramref name="elementSelector" />.</typeparam>
        /// <exception cref="T:System.ArgumentNullException">
        ///     <paramref name="source" /> or <paramref name="keySelector" /> or <paramref name="elementSelector" /> is null.-or-
        ///     <paramref name="keySelector" /> produces a key that is null.
        /// </exception>
        /// <exception cref="T:System.ArgumentException">
        ///     <paramref name="keySelector" /> produces duplicate keys for two elements.
        /// </exception>
        public static BetterDictionary<TKey, TElement> ToBetterDictionary<TSource, TKey, TElement>(
            this IEnumerable<TSource> source,
            Func<TSource, TKey> keySelector, Func<TSource, TElement> elementSelector, IEqualityComparer<TKey> comparer)
        {
            if (source == null)
            {
                throw new ArgumentNullException(nameof(source));
            }
            if (keySelector == null)
            {
                throw new ArgumentNullException(nameof(keySelector));
            }
            if (elementSelector == null)
            {
                throw new ArgumentNullException(nameof(elementSelector));
            }
            var dictionary = new BetterDictionary<TKey, TElement>(comparer);
            foreach (var source1 in source)
            {
                dictionary.Add(keySelector(source1), elementSelector(source1));
            }
            return dictionary;
        }

        internal class IdentityFunction<TElement>
        {
            public static Func<TElement, TElement> Instance
            {
                get { return x => x; }
            }
        }
    }
}