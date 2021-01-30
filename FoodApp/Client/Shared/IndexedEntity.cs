namespace FoodApp.Client.Shared
{
    public record IndexedEntity<TEntity>(TEntity Entity, int? Index);
}
