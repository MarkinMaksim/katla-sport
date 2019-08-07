using System;
using System.Data.Entity.Migrations;

namespace KatlaSport.DataAccess.Migrations{
    public partial class Reworked : DbMigration
    {
        public override void Up()
        {
            CreateTable(
                "dbo.accountants",
                c => new
                    {
                        accountant_id = c.Int(nullable: false, identity: true),
                        accountant_name = c.String(),
                        accountant_surname = c.String(),
                        accountant_age = c.Int(nullable: false),
                        accountant_chiefid = c.Int(nullable: false),
                        accountant_photo = c.String(),
                    })
                .PrimaryKey(t => t.accountant_id)
                .ForeignKey("dbo.accountants", t => t.accountant_chiefid)
                .Index(t => t.accountant_chiefid);

            CreateTable(
                "dbo.report",
                c => new
                    {
                        report_id = c.Int(nullable: false, identity: true),
                        report_company_id = c.Int(nullable: false),
                        report_account_id = c.Int(nullable: false),
                    })
                .PrimaryKey(t => t.report_id)
                .ForeignKey("dbo.accountants", t => t.report_account_id, cascadeDelete: true)
                .ForeignKey("dbo.companys", t => t.report_company_id, cascadeDelete: true)
                .Index(t => t.report_company_id)
                .Index(t => t.report_account_id);

            CreateTable(
                "dbo.companys",
                c => new
                    {
                        company_id = c.Int(nullable: false, identity: true),
                        company_name = c.String(),
                        company_address = c.String(),
                        company_city = c.String(),
                        company_country = c.String(),
                    })
                .PrimaryKey(t => t.company_id);
        }

        public override void Down()
        {
            DropForeignKey("dbo.report", "report_company_id", "dbo.companys");
            DropForeignKey("dbo.report", "report_account_id", "dbo.accountants");
            DropForeignKey("dbo.accountants", "accountant_chiefid", "dbo.accountants");
            DropIndex("dbo.report", new[] { "report_account_id" });
            DropIndex("dbo.report", new[] { "report_company_id" });
            DropIndex("dbo.accountants", new[] { "accountant_chiefid" });
            DropTable("dbo.companys");
            DropTable("dbo.report");
            DropTable("dbo.accountants");
        }
    }
}
