using System.Linq.Expressions;

namespace CommonExtensions
{

    public static class EnumerableExtensions
    {

        /// <summary>
        /// Adds or updates an item in a collection
        /// </summary>
        /// <typeparam name="T">The type of object</typeparam>
        /// <param name="list">the collection</param>
        /// <param name="item">the object to add</param>
        /// <param name="comparer">an expression that uniquely identifies the object in the collection</param>
        public static ICollection<T> AddOrUpdate<T>(this ICollection<T> list, T item, Expression<Func<T, bool>> comparer)
        {

            if (item == null) throw new ArgumentNullException(nameof(item));

            Func<T, bool> expression = null;
            try
            {
                expression = comparer.Compile();
            }
            catch (Exception)
            {
                throw;
            }
            var existing = list.FirstOrDefault(expression);

            if (existing == null)
            {
                list.Add(item);
            }
            else
            {
                list.Remove(existing);

                list.Add(item);
            }
            return list;
        }

        public static IDictionary<string, string> AddOrUpdateKey(this IDictionary<string, string> dict, KeyValuePair<string, string> newVal)
        {

            dict.TryGetValue(newVal.Key, out var oldVal);

            if (oldVal == null)
            {
                dict.Add(newVal);
            }
            else
            {
                dict[newVal.Key] = newVal.Value;

            }
            return dict;
        }



    }


}
