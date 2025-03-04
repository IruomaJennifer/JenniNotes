using FluentNHibernate.Mapping;
using JenniNotes.Domain;

namespace JenniNotes.Infrastructure.Nhibernate.Mappings
{
    public class BaseMapping<T> : ClassMap<T> where T : Entity
    {
        public BaseMapping()
        {
            Id(m => m.Id).GeneratedBy.GuidComb();
        }
    }
}
