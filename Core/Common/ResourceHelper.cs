using System;
using System.IO;
using System.Linq;
using System.Reflection;
using System.Threading.Tasks;

namespace FoodApp.Core.Common
{
    /// <summary>
    /// Helper class for methods involving project resources
    /// </summary>
    public static class ResourceHelper
    {
        #region Public Methods
        /// <summary>
        /// Read resource by file name
        /// </summary>
        /// <param name="fileName">
        /// File name. Must be unique. The applied filter is a "contains" filter since the assembly path is included in the manifset resource name.
        /// </param>
        /// <param name="assembly">Assembly where resource can be found</param>
        /// <returns>Resource file contents</returns>
        /// <seealso cref="ReadEmbedded(Func{string, bool}, Assembly)"/>
        public static Task<string> ReadEmbedded(string fileName, Assembly assembly = null)
        {
            return ReadEmbedded(f => f.Contains(fileName), assembly);
        }
        #endregion
        #region Private Methods
        /// <summary>
        /// Read Embedded Resource
        /// </summary>
        /// <param name="resourceNameFilter">
        /// Filter to locate the resource. Must be unique.
        /// </param>
        /// <param name="assembly">
        /// Assembly resource is located in. If not provided, this defaults to the entry assembly.
        /// </param>
        /// <returns>The contents of the resource file</returns>
        private static Task<string> ReadEmbedded(Func<string, bool> resourceNameFilter, Assembly assembly = null)
        {
            assembly ??= Assembly.GetEntryAssembly();
            var resourceName = assembly.GetManifestResourceNames().Single(resourceNameFilter);
            using var stream = assembly.GetManifestResourceStream(resourceName);
            using var reader = new StreamReader(stream);
            return reader.ReadToEndAsync();
        }
        #endregion
    }
}
