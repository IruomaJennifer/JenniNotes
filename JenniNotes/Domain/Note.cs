
namespace JenniNotes.Domain
{
    public class Note : Entity
    {
        protected Note(){}
        public Note(string caption, string description)
        {
            Caption = caption;
            Description = description;
            Created = DateTime.UtcNow;
            TimeStamp = DateTime.UtcNow;
        }
        public virtual string Caption { get; protected set; }
        public virtual string Description { get; protected set; }
        public virtual DateTime Created { get; protected set; }
        public virtual DateTime TimeStamp { get; protected set; }
        public virtual IList<Chore> Chores { get; protected set; } = new List<Chore>();

        public virtual void AddAChore(Chore chore)
        {
            Chores.Add(chore);
        }

        public virtual void SetChores(IList<Chore> chores)
        {
            Chores = chores;
        }
    }
}
