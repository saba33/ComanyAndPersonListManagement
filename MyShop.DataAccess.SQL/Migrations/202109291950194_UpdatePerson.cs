namespace MyShop.DataAccess.SQL.Migrations
{
    using System;
    using System.Data.Entity.Migrations;
    
    public partial class UpdatePerson : DbMigration
    {
        public override void Up()
        {
            
        }
        
        public override void Down()
        {
            CreateTable(
                "dbo.PersonCompanies",
                c => new
                    {
                        Person_Id = c.String(nullable: false, maxLength: 128),
                        Company_Id = c.String(nullable: false, maxLength: 128),
                    })
                .PrimaryKey(t => new { t.Person_Id, t.Company_Id });
            
            CreateIndex("dbo.PersonCompanies", "Company_Id");
            CreateIndex("dbo.PersonCompanies", "Person_Id");
            AddForeignKey("dbo.PersonCompanies", "Company_Id", "dbo.Companies", "Id", cascadeDelete: true);
            AddForeignKey("dbo.PersonCompanies", "Person_Id", "dbo.People", "Id", cascadeDelete: true);
        }
    }
}
