using FluentMigrator;

namespace JenniNotes.Infrastructure.Migrations
{
    [Migration(202502181246)]
    public class InitialMigration : Migration
    {
        public override void Up()
        {
            Create.Table("Notes")
                 .WithColumn("Id").AsGuid().PrimaryKey()
                 .WithColumn("Caption").AsString().Nullable()
                 .WithColumn("Description").AsString().NotNullable()
                 .WithColumn("Created").AsDateTime().NotNullable()
                 .WithColumn("TimeStamp").AsDateTime().NotNullable();

            Create.Table("Chores")
                 .WithColumn("Id").AsGuid().PrimaryKey()
                 .WithColumn("Description").AsString().Nullable()
                 .WithColumn("IsDone").AsBoolean().NotNullable()
                 .WithColumn("Created").AsDateTime().NotNullable()
                 .WithColumn("DueDate").AsDateTime().NotNullable()
                 .WithColumn("Note_id").AsGuid().ForeignKey("FK_NotesId_Chore", "Notes", "Id");
        }
        public override void Down()
        {
            Delete.Table("Notes");
            Delete.Table("Chores");
        }

       
    }
}
