namespace EFTask.Migrations
{
    using System;
    using System.Data.Entity.Migrations;
    
    public partial class AddedClient : DbMigration
    {
        private Guid anonymousClientGuid = Guid.Parse("32ef3f0a-12c7-4641-a076-7f1d54050b7c");

        public override void Up()
        {
            CreateTable(
                "dbo.Clients",
                c => new
                    {
                        ID = c.Guid(nullable: false),
                        Login = c.String(nullable: false),
                        FirstName = c.String(nullable: false),
                        SecondName = c.String(nullable: false),
                    })
                .PrimaryKey(t => t.ID);

            Sql(String.Format("INSERT INTO dbo.Clients (id, login, firstname, secondname) VALUES ('{0}', 'anonymous', 'anon', 'anon')", anonymousClientGuid));

            AddColumn("dbo.Payments", "Client", c => c.Guid(nullable: false, defaultValue: anonymousClientGuid));
            CreateIndex("dbo.Payments", "Client");
            AddForeignKey("dbo.Payments", "Client", "dbo.Clients", "ID", cascadeDelete: true);
        }
        
        public override void Down()
        {
            DropForeignKey("dbo.Payments", "Client", "dbo.Clients");
            DropIndex("dbo.Payments", new[] { "Client" });
            DropColumn("dbo.Payments", "Client");
            DropTable("dbo.Clients");
        }
    }
}
