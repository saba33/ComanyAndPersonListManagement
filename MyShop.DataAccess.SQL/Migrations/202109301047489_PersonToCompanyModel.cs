namespace MyShop.DataAccess.SQL.Migrations
{
    using System;
    using System.Data.Entity.Migrations;
    
    public partial class PersonToCompanyModel : DbMigration
    {
        public override void Up()
        {
            CreateTable(
                "dbo.PersonToCompanyModels",
                c => new
                    {
                        Id = c.String(nullable: false, maxLength: 128),
                        CompanyName = c.String(),
                        RelatedPersonName = c.String(),
                    })
                .PrimaryKey(t => t.Id);
            
        }
        
        public override void Down()
        {
            DropTable("dbo.PersonToCompanyModels");
        }
    }
}
