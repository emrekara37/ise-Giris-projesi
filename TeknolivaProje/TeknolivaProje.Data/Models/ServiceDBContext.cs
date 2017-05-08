namespace TeknolivaProje.Data.Models
{
  using System.Data.Entity;

  public class ServiceDBContext : DbContext
  {
   
    public ServiceDBContext()
        : base("name=ServiceDBContext")
    {
    }

    protected override void OnModelCreating(DbModelBuilder modelBuilder)
    {

      modelBuilder.Entity<CITY>()
        .HasMany(e => e.ROUTE)
        .WithRequired(e => e.CITY)
        .WillCascadeOnDelete();


      modelBuilder.Entity<ROUTE>()
        .HasMany(e => e.STATION)
        .WithRequired(e => e.ROUTE)
        .WillCascadeOnDelete();

      modelBuilder.Entity<ROUTE_TYPE>()
        .HasMany(e => e.ROUTE)
        .WithRequired(e => e.ROUTE_TYPE)
        .WillCascadeOnDelete();

   

      modelBuilder.Entity<SYSADM_USER>()
        .HasMany(e => e.CITY)
        .WithRequired(e => e.SYSADM_USER)
        .HasForeignKey(e => e.CREATE_UID)
        .WillCascadeOnDelete(false);

      modelBuilder.Entity<SYSADM_USER>()
        .HasMany(e => e.CITY1)
        .WithRequired(e => e.SYSADM_USER1)
        .HasForeignKey(e => e.LASTUPD_UID)
        .WillCascadeOnDelete(false);

      modelBuilder.Entity<SYSADM_USER>()
        .HasMany(e => e.ROUTE)
        .WithRequired(e => e.SYSADM_USER)
        .HasForeignKey(e => e.CREATE_UID)
        .WillCascadeOnDelete(false);

      modelBuilder.Entity<SYSADM_USER>()
        .HasMany(e => e.ROUTE1)
        .WithRequired(e => e.SYSADM_USER1)
        .HasForeignKey(e => e.LASTUPD_UID)
        .WillCascadeOnDelete(false);

      modelBuilder.Entity<SYSADM_USER>()
        .HasMany(e => e.ROUTE_TYPE)
        .WithRequired(e => e.SYSADM_USER)
        .HasForeignKey(e => e.CREATE_UID)
        .WillCascadeOnDelete(false);

      modelBuilder.Entity<SYSADM_USER>()
        .HasMany(e => e.ROUTE_TYPE1)
        .WithRequired(e => e.SYSADM_USER1)
        .HasForeignKey(e => e.LASTUPD_UID)
        .WillCascadeOnDelete(false);

      modelBuilder.Entity<SYSADM_USER>()
        .HasMany(e => e.STATION)
        .WithRequired(e => e.SYSADM_USER)
        .HasForeignKey(e => e.CREATE_UID)
        .WillCascadeOnDelete(false);

      modelBuilder.Entity<SYSADM_USER>()
        .HasMany(e => e.STATION1)
        .WithRequired(e => e.SYSADM_USER1)
        .HasForeignKey(e => e.LASTUPD_UID)
        .WillCascadeOnDelete(false);
    }
  }

 
}