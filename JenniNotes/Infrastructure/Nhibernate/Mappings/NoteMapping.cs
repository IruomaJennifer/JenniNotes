using JenniNotes.Domain;

namespace JenniNotes.Infrastructure.Nhibernate.Mappings
{
    public class NoteMapping : BaseMapping<Note>
    {
        public NoteMapping()
        {
            Table("Notes");
            Map(n => n.Caption);
            Map(n => n.Description);
            Map(n => n.Created);
            Map(n => n.TimeStamp);
            HasMany(n => n.Chores).Cascade.All().Inverse();
        }
    }
}
