namespace FoodApp.Client.Shared
{
    // todo -> move to core project / shared project
    public record IndexedEntity<TEntity>(TEntity Entity, int? Index);
}
