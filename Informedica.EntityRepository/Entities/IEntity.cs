namespace Informedica.EntityRepository.Entities
{
    public interface IEntity<in TEnt, out TId> 
        where TEnt: IEntity<TEnt, TId>
    {
        TId Id { get; }
        bool IsIdentical(TEnt entity);
        bool IsTransient();
    }
}