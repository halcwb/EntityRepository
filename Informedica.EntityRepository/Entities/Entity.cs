namespace Informedica.EntityRepository.Entities
{
    public abstract class Entity<TEnt, TId> : IEntity<TEnt, TId>
        where TEnt : class, IEntity<TEnt, TId>
    {
        protected Entity()
            : this(default(TId))
        {
        }

        protected Entity(TId id)
        {
            SetId(id);
        }

        #region IEntity<TEnt,TId> Members

        public virtual TId Id { get; protected set; }

        public abstract bool IsIdentical(TEnt entity);

        public virtual bool IsTransient()
        {
            return Id.Equals(default(TId));
        }

        #endregion

        private void SetId(TId id)
        {
            Id = id;
        }
    }
}