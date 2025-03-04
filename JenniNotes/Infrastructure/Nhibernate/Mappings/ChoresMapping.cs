using JenniNotes.Domain;

namespace JenniNotes.Infrastructure.Nhibernate.Mappings
{
    public class ChoresMapping : BaseMapping<Chore>
    {
        public ChoresMapping()
        {
            Table("Chores");
            Map(c => c.Description);
            Map(c => c.IsDone);
            Map(c => c.Created);
            Map(c => c.DueDate);
            References(c => c.Note);
        }
    }
}
