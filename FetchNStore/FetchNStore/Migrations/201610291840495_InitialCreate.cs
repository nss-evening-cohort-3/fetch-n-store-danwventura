namespace FetchNStore.Migrations
{
    using System;
    using System.Data.Entity.Migrations;
    
    public partial class InitialCreate : DbMigration
    {
        public override void Up()
        {
            CreateTable(
                "dbo.Responses",
                c => new
                    {
                        Response_ID = c.Int(nullable: false, identity: true),
                        Status_Code = c.Int(nullable: false),
                        Method = c.String(nullable: false),
                        URL = c.String(nullable: false),
                        Response_Time = c.String(nullable: false),
                        TimeOfDay = c.DateTime(nullable: false),
                    })
                .PrimaryKey(t => t.Response_ID);
            
        }
        
        public override void Down()
        {
            DropTable("dbo.Responses");
        }
    }
}
