using Microsoft.EntityFrameworkCore;
using HotDesk_task.Data.Entities;

namespace HotDesk_task.Data;

public class HotDesk_task_DbContext : DbContext
{
    public DbSet<Employee> Employees { get; set; }
    public DbSet<Workplace> Workplaces { get; set; }
    public DbSet<Reservation> Reservations { get; set; }
    public DbSet<Equipment> Equipments { get; set; }
    public DbSet<EquipmentForWorkplace> EquipmentForWorkplaces { get; set; }

    public HotDesk_task_DbContext(DbContextOptions options) : base(options)
    {
        // DbContext.Configuration.ProxyCreationEnabled = true;    
        // DbContext.Configuration.LazyLoadingEnabled = true;  
    }

    protected override void OnConfiguring(DbContextOptionsBuilder optionsBuilder)
        => optionsBuilder
            .UseLazyLoadingProxies();

    protected override void OnModelCreating(ModelBuilder builder)
    {
        builder.Entity<Employee>().ToTable("Employee");
        builder.Entity<Employee>().HasKey(e => e.EmployeeId);

        builder.Entity<Workplace>().ToTable("Workplace");
        builder.Entity<Workplace>().HasKey(w => w.WorkplaceId);

        builder.Entity<Reservation>().ToTable("Reservation");
        builder.Entity<Reservation>().HasKey(r => r.ReservationId);

        builder.Entity<Equipment>().ToTable("Equipment");
        builder.Entity<Equipment>().HasKey(e => e.EquipmentId);

        builder.Entity<EquipmentForWorkplace>().ToTable("EquipmentForWorkplace");
        builder.Entity<EquipmentForWorkplace>().HasKey(ew => ew.EFW_Id);

        // builder.Entity<Employee>()
        //     .HasMany(e => e.Reservations)
        //     .WithOne(r => r.Employee)
        //     .HasForeignKey(r => r.IdEmployee);

        builder.Entity<Reservation>()
            .HasOne(r => r.Employee)
            .WithMany(e => e.Reservations)
            .HasForeignKey(r => r.IdEmployee);

        // builder.Entity<Workplace>()
        //     .HasMany(w => w.Reservations)
        //     .WithOne(r => r.Workplace)
        //     .HasForeignKey(r=>r.IdWorkplace);

        builder.Entity<Reservation>()
            .HasOne(r => r.Workplace)
            .WithMany(w => w.Reservations)
            .HasForeignKey(r => r.IdWorkplace);

        // builder.Entity<Workplace>()
        //     .HasMany(w => w.EquipmentForWorkplace)
        //     .WithOne(ew => ew.Workplace)
        //     .HasForeignKey(ew=>ew.IdWorkplace);

        builder.Entity<EquipmentForWorkplace>()
            .HasOne(ew => ew.Workplace)
            .WithMany(w => w.EquipmentForWorkplace)
            .HasForeignKey(ew => ew.IdWorkplace);

        // builder.Entity<Equipment>()
        //     .HasMany(e => e.EquipmentForWorkplace)
        //     .WithOne(ew => ew.Equipments)
        //     .HasForeignKey(ew=>ew.IdEquipment);

        builder.Entity<EquipmentForWorkplace>()
            .HasOne(ew => ew.Equipments)
            .WithMany(e => e.EquipmentForWorkplace)
            .HasForeignKey(ew => ew.IdEquipment);
    }
}