namespace FoodApp.Core.Common.Guards
{
    /// <summary>
    /// Guard Partial - Shared methods
    /// </summary>
    public static partial class Guard
    {
        /// <summary>
        /// Get full name of property, relative to parent
        /// </summary>
        /// <typeparam name="TContext">Type of parent that has property</typeparam>
        /// <param name="propertyName"></param>
        /// <returns></returns>
        public static string GetFullPropertyIdentifier<TContext>(string propertyName)
        {
            return $"{typeof(TContext).FullName}.{propertyName}";
        }
    }
}
