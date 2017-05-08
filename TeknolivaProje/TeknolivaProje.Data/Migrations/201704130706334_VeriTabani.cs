namespace TeknolivaProje.Data.Migrations
{
  using System.Data.Entity.Migrations;
    
    public partial class VeriTabani : DbMigration
    {
        public override void Up()
        {
            CreateTable(
                "dbo.CITY",
                c => new
                    {
                        CITY_ID = c.Int(nullable: false, identity: true),
                        CITY_NAME = c.String(nullable: false, maxLength: 50),
                        CREATE_UID = c.String(nullable: false, maxLength: 20),
                        CREATE_DATE = c.DateTime(nullable: false, storeType: "date"),
                        LASTUPD_UID = c.String(nullable: false, maxLength: 20),
                        LASTUPD_DATE = c.DateTime(nullable: false, storeType: "date"),
                    })
                .PrimaryKey(t => t.CITY_ID)
                .ForeignKey("dbo.SYSADM_USER", t => t.CREATE_UID)
                .ForeignKey("dbo.SYSADM_USER", t => t.LASTUPD_UID)
                .Index(t => t.CREATE_UID)
                .Index(t => t.LASTUPD_UID);
            
            CreateTable(
                "dbo.ROUTE",
                c => new
                    {
                        ROUTE_ID = c.Int(nullable: false, identity: true),
                        ROUTE_NAME = c.String(nullable: false, maxLength: 100),
                        CITY_ID = c.Int(nullable: false),
                        ROUTE_TYPE_ID = c.Int(nullable: false),
                        TOT_DURATION = c.Decimal(nullable: false, precision: 3, scale: 0),
                        PERON_NO = c.Decimal(nullable: false, precision: 2, scale: 0),
                        VEHICLE_TYPE = c.Decimal(nullable: false, precision: 1, scale: 0),
                        CREATE_UID = c.String(nullable: false, maxLength: 20),
                        CREATE_DATE = c.DateTime(nullable: false, storeType: "date"),
                        LASTUPD_UID = c.String(nullable: false, maxLength: 20),
                        LASTUPD_DATE = c.DateTime(nullable: false, storeType: "date"),
                    })
                .PrimaryKey(t => t.ROUTE_ID)
                .ForeignKey("dbo.ROUTE_TYPE", t => t.ROUTE_TYPE_ID)
                .ForeignKey("dbo.SYSADM_USER", t => t.CREATE_UID)
                .ForeignKey("dbo.SYSADM_USER", t => t.LASTUPD_UID)
                .ForeignKey("dbo.CITY", t => t.CITY_ID)
                .Index(t => t.CITY_ID)
                .Index(t => t.ROUTE_TYPE_ID)
                .Index(t => t.CREATE_UID)
                .Index(t => t.LASTUPD_UID);
            
            CreateTable(
                "dbo.ROUTE_TYPE",
                c => new
                    {
                        ROUTE_TYPE_ID = c.Int(nullable: false, identity: true),
                        ROUTE_TYPE_NAME = c.String(nullable: false, maxLength: 50),
                        CREATE_UID = c.String(nullable: false, maxLength: 20),
                        CREATE_DATE = c.DateTime(nullable: false, storeType: "date"),
                        LASTUPD_UID = c.String(nullable: false, maxLength: 20),
                        LASTUPD_DATE = c.DateTime(nullable: false, storeType: "date"),
                    })
                .PrimaryKey(t => t.ROUTE_TYPE_ID)
                .ForeignKey("dbo.SYSADM_USER", t => t.CREATE_UID)
                .ForeignKey("dbo.SYSADM_USER", t => t.LASTUPD_UID)
                .Index(t => t.CREATE_UID)
                .Index(t => t.LASTUPD_UID);
            
            CreateTable(
                "dbo.SYSADM_USER",
                c => new
                    {
                        SYSADM_UID = c.String(nullable: false, maxLength: 20),
                        FIRST_NAME = c.String(nullable: false, maxLength: 30),
                        LAST_NAME = c.String(nullable: false, maxLength: 30),
                        USERNAME = c.String(nullable: false, maxLength: 30),
                        PASSWORD = c.String(nullable: false, maxLength: 30),
                    })
                .PrimaryKey(t => t.SYSADM_UID);
            
            CreateTable(
                "dbo.STATION",
                c => new
                    {
                        STATION_ID = c.Int(nullable: false, identity: true),
                        STATION_NAME = c.String(nullable: false, maxLength: 100),
                        ROUTE_ID = c.Int(nullable: false),
                        STATION_NO = c.Decimal(nullable: false, precision: 2, scale: 0),
                        ARRIVAL_TIME = c.String(nullable: false, maxLength: 5),
                        DEPARTURE_TIME = c.String(nullable: false, maxLength: 5),
                        CREATE_UID = c.String(nullable: false, maxLength: 20),
                        CREATE_DATE = c.DateTime(nullable: false, storeType: "date"),
                        LASTUPD_UID = c.String(nullable: false, maxLength: 20),
                        LASTUPD_DATE = c.DateTime(nullable: false, storeType: "date"),
                    })
                .PrimaryKey(t => t.STATION_ID)
                .ForeignKey("dbo.SYSADM_USER", t => t.CREATE_UID)
                .ForeignKey("dbo.SYSADM_USER", t => t.LASTUPD_UID)
                .ForeignKey("dbo.ROUTE", t => t.ROUTE_ID)
                .Index(t => t.ROUTE_ID)
                .Index(t => t.CREATE_UID)
                .Index(t => t.LASTUPD_UID);
            
        }
        
        public override void Down()
        {
            DropForeignKey("dbo.ROUTE", "CITY_ID", "dbo.CITY");
            DropForeignKey("dbo.STATION", "ROUTE_ID", "dbo.ROUTE");
            DropForeignKey("dbo.STATION", "LASTUPD_UID", "dbo.SYSADM_USER");
            DropForeignKey("dbo.STATION", "CREATE_UID", "dbo.SYSADM_USER");
            DropForeignKey("dbo.ROUTE", "LASTUPD_UID", "dbo.SYSADM_USER");
            DropForeignKey("dbo.ROUTE_TYPE", "LASTUPD_UID", "dbo.SYSADM_USER");
            DropForeignKey("dbo.ROUTE_TYPE", "CREATE_UID", "dbo.SYSADM_USER");
            DropForeignKey("dbo.ROUTE", "CREATE_UID", "dbo.SYSADM_USER");
            DropForeignKey("dbo.CITY", "LASTUPD_UID", "dbo.SYSADM_USER");
            DropForeignKey("dbo.CITY", "CREATE_UID", "dbo.SYSADM_USER");
            DropForeignKey("dbo.ROUTE", "ROUTE_TYPE_ID", "dbo.ROUTE_TYPE");
            DropIndex("dbo.STATION", new[] { "LASTUPD_UID" });
            DropIndex("dbo.STATION", new[] { "CREATE_UID" });
            DropIndex("dbo.STATION", new[] { "ROUTE_ID" });
            DropIndex("dbo.ROUTE_TYPE", new[] { "LASTUPD_UID" });
            DropIndex("dbo.ROUTE_TYPE", new[] { "CREATE_UID" });
            DropIndex("dbo.ROUTE", new[] { "LASTUPD_UID" });
            DropIndex("dbo.ROUTE", new[] { "CREATE_UID" });
            DropIndex("dbo.ROUTE", new[] { "ROUTE_TYPE_ID" });
            DropIndex("dbo.ROUTE", new[] { "CITY_ID" });
            DropIndex("dbo.CITY", new[] { "LASTUPD_UID" });
            DropIndex("dbo.CITY", new[] { "CREATE_UID" });
            DropTable("dbo.STATION");
            DropTable("dbo.SYSADM_USER");
            DropTable("dbo.ROUTE_TYPE");
            DropTable("dbo.ROUTE");
            DropTable("dbo.CITY");
        }
    }
}
