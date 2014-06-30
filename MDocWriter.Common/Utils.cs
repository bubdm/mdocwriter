using System;
using System.Collections.Generic;
using System.Collections.ObjectModel;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace MDocWriter.Common
{
    using System.IO;

    public static class Utils
    {
        #region Private Constants
        private const int InitialPrime = 23;
        private const int FactorPrime = 29;
        #endregion

        /// <summary>
        /// Gets the hash code for an object based on the given array of hash
        /// codes from each property of the object.
        /// </summary>
        /// <param name="hashCodesForProperties">The array of the hash codes
        /// that are from each property of the object.</param>
        /// <returns>The hash code.</returns>
        public static int GetHashCode(params int[] hashCodesForProperties)
        {
            unchecked
            {
                return hashCodesForProperties.Aggregate(InitialPrime, (current, code) => current * FactorPrime + code);
            }
        }

        public static string GetUniqueName(IEnumerable<string> source, string leading)
        {
            var intList = new List<int> { 0 };

            foreach (var str in source)
            {
                if (str.StartsWith(leading))
                {
                    var remaining = str.Substring(leading.Length, str.Length - leading.Length).Trim();
                    int val;
                    if (int.TryParse(remaining, out val))
                    {
                        intList.Add(val);
                    }
                }
            }
            return string.Format("{0} {1}", leading, intList.Max() + 1);
        }

        public static string GetBase64OfFile(string fileName)
        {
            var bytes = File.ReadAllBytes(fileName);
            return Convert.ToBase64String(bytes);
        }

        #region Extension Methods
        public static void Remove<T> (this ObservableCollection<T> source, Func<T, bool> predicate)
        {
            if (source == null) throw new ArgumentNullException("source");
            var item = source.FirstOrDefault(predicate);
            if (item == null) return;
            source.Remove(item);
        }
        #endregion
    }
}
