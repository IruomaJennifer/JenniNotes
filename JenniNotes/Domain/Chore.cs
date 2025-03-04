namespace JenniNotes.Domain
{
    public class Chore : Entity
    {
        protected Chore() { }

        public Chore(string description, DateTime dueDate)
        {
            Description = description;
            DueDate = dueDate;
            IsDone = false;
            Created = DateTime.UtcNow;
        }
        public virtual Chore SetNote(Note note)
        {
            Note = note;
            return this;
        }
        public virtual string Description { get; set; }
        public virtual bool IsDone { get; set; }
        public virtual DateTime Created { get; set; }
        public virtual DateTime DueDate { get; set; }
        public virtual Note Note { get; protected set; }

    }
}
