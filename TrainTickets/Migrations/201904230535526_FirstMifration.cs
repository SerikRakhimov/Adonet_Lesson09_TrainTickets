namespace TrainTickets.Migrations
{
    using System;
    using System.Data.Entity.Migrations;
    
    public partial class FirstMifration : DbMigration
    {
        public override void Up()
        {
            CreateTable(
                "dbo.Cars",
                c => new
                    {
                        Id = c.Guid(nullable: false),
                        Number = c.String(),
                        TrainId = c.Int(),
                        Train_Id = c.Guid(),
                    })
                .PrimaryKey(t => t.Id)
                .ForeignKey("dbo.Trains", t => t.Train_Id)
                .Index(t => t.Train_Id);
            
            CreateTable(
                "dbo.Places",
                c => new
                    {
                        Id = c.Guid(nullable: false),
                        Number = c.String(),
                        CarId = c.Int(),
                        Price = c.Int(nullable: false),
                        Pay = c.Boolean(nullable: false),
                        CardNumber = c.String(),
                        Fio = c.String(),
                        Car_Id = c.Guid(),
                    })
                .PrimaryKey(t => t.Id)
                .ForeignKey("dbo.Cars", t => t.Car_Id)
                .Index(t => t.Car_Id);
            
            CreateTable(
                "dbo.Trains",
                c => new
                    {
                        Id = c.Guid(nullable: false),
                        Number = c.String(),
                        StationFrom = c.String(),
                        StationTo = c.String(),
                        Data = c.DateTime(nullable: false),
                    })
                .PrimaryKey(t => t.Id);
            
        }
        
        public override void Down()
        {
            DropForeignKey("dbo.Cars", "Train_Id", "dbo.Trains");
            DropForeignKey("dbo.Places", "Car_Id", "dbo.Cars");
            DropIndex("dbo.Places", new[] { "Car_Id" });
            DropIndex("dbo.Cars", new[] { "Train_Id" });
            DropTable("dbo.Trains");
            DropTable("dbo.Places");
            DropTable("dbo.Cars");
        }
    }
}
