using Microsoft.EntityFrameworkCore;
using RecensysCoreRepository.Entities;
using Task = RecensysCoreRepository.Entities.Task;

namespace RecensysCoreRepository.EF
{
    /*
     * https://ef.readthedocs.io/en/latest/platforms/netcore/new-db-sqlite.html
     */
    public class RecensysContext : DbContext, IDbContext
    {
        public DbSet<Article> Articles { get; set; }
        public DbSet<Criteria> Criterias { get; set; }
        public DbSet<Data> Data { get; set; }
        public DbSet<Field> Fields { get; set; }
        public DbSet<Stage> Stages { get; set; }
        public DbSet<StageRole> StageRoles { get; set; }
        public DbSet<Strategy> Strategies { get; set; }
        public DbSet<Study> Studies { get; set; }
        public DbSet<Task> Tasks { get; set; }
        public DbSet<TaskType> TaskTypes { get; set; }
        public DbSet<User> Users {get; set; }

        protected override void OnModelCreating(ModelBuilder modelBuilder)
        {
            modelBuilder.Entity<UserStageRelation>()
                .HasKey(a => new { a.StageId, a.StageRoleId, a.UserId});
            modelBuilder.Entity<UserStudyRelation>()
                .HasKey(a => new { a.StudyId, a.UserId });
            modelBuilder.Entity<StrategyFieldRelation>()
                .HasKey(a => new { a.FieldId, a.StrategyId });
            modelBuilder.Entity<StageFieldRelation>()
                .HasKey(a => new {a.FieldId, a.FieldTypeId, a.StageId});
        }

        protected override void OnConfiguring(DbContextOptionsBuilder optionsBuilder)
        {
            optionsBuilder.UseSqlite("Filename=./blog.db");
            //optionsBuilder.UseSqlServer(@"Server=(localdb)\mssqllocaldb;Database=MyDatabase;Trusted_Connection=True;");
        }

        public new DbSet<T> Set<T>() where T : class, IEntity
        {
            return base.Set<T>();
        }
    }
}
