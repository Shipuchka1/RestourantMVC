namespace RestourantManagement.DAL.Model
{
    using System;
    using System.Data.Entity;
    using System.ComponentModel.DataAnnotations.Schema;
    using System.Linq;

    public partial class Model1 : DbContext
    {
        public Model1()
            : base("name=Model1")
        {
        }

        public virtual DbSet<Comment> Comments { get; set; }
        public virtual DbSet<EatType> EatTypes { get; set; }
        public virtual DbSet<Employee> Employees { get; set; }
        public virtual DbSet<Job> Jobs { get; set; }
        public virtual DbSet<Menu> Menu { get; set; }
        public virtual DbSet<Reservation> Reservatiosn { get; set; }

        protected override void OnModelCreating(DbModelBuilder modelBuilder)
        {
            modelBuilder.Entity<EatType>()
                .HasMany(e => e.Menu)
                .WithOptional(e => e.eatType)
                .HasForeignKey(e => e.ItemEatTypeId);

            modelBuilder.Entity<Menu>()
                .Property(e => e.Cost)
                .HasPrecision(19, 4);
        }
    }
}
