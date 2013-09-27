namespace PMS.Migrations
{
    using System;
    using System.Data.Entity.Migrations;
    
    public partial class AddedColumnFinancialYearOnModelCashRequisition : DbMigration
    {
        public override void Up()
        {
            AddColumn("dbo.CashRequisitions", "FinancialYear", c => c.String(nullable: false));
        }
        
        public override void Down()
        {
            DropColumn("dbo.CashRequisitions", "FinancialYear");
        }
    }
}
