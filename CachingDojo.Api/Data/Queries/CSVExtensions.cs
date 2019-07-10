namespace CachingDojo.Data.Queries
{
    using System;
    using System.Collections.Generic;
    using System.IO;
    using System.Linq;
    using System.Threading.Tasks;
    using CsvHelper;

    /// <summary>
    /// Get Data
    /// </summary>
    public static partial class CSVExtensions<T>
    {
        /// <summary>
        /// Gets the by asynchronous.
        /// </summary>
        /// <param name="file">The file.</param>
        /// <returns></returns>
        public static IList<T> GetByAsync(string file)
        {
            IList<T> data;
            using (var reader = new StreamReader($@"{Environment.CurrentDirectory}\Data\{file}.csv"))
            {
                using (var csvReader = new CsvReader(reader))
                {
                    data = csvReader.GetRecords<T>().ToList();
                }
            }
            return data;
        }

    }
}
