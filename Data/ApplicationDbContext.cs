using DomainModels;
using DomainModels.Request.Roles;
using EntityModels;
using Microsoft.EntityFrameworkCore;

namespace Data
{
    public class ApplicationDbContext : DbContext
    {
        public ApplicationDbContext(DbContextOptions<ApplicationDbContext> options) : base(options) { }
        protected override void OnModelCreating(ModelBuilder modelBuilder)
        {
            modelBuilder.Entity<AttendanceReport>(
            eb =>
            {
                eb.HasNoKey();
            });

            modelBuilder.ApplyConfiguration(new RoleConfiguration());
                

            base.OnModelCreating(modelBuilder);
        }
        public virtual DbSet<Institute> Institutes { get; set; }
        public virtual DbSet<UserDomainModel> Users { get; set; }
        public virtual DbSet<Role> Role { get; set; }
        public virtual DbSet<Standard> Standards { get; set; }
        public virtual DbSet<Subject> Subjects { get; set; }
        public virtual DbSet<Student> Students { get; set; }
        public virtual DbSet<Division> Divisions { get; set; }
        public virtual DbSet<StudentAttendance> StudentAttendances { get;set; }
        public virtual DbSet<TimeTableManagementDomainModel> TimeTableManagement { get; set; }
        public virtual DbSet<FeesManagementModel> FeesManagement { get; set; }
        public virtual DbSet<StaffAttendance> StaffAttendance { get; set; }

    }
}
