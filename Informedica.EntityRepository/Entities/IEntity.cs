namespace Informedica.EntityRepository.Entities
{
    public interface IEntity<in TEnt, out TId>
        where TEnt : class, IEntity<TEnt, TId>
    {
        TId Id { get; }
        bool IsIdentical(TEnt entity);
        bool IsTransient();
    }
}