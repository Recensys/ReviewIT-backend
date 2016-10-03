using System;
using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.ChangeTracking;
using RecensysCoreRepository.Entities;

namespace RecensysCoreRepository.EF
{
    public interface IRecensysContext : IDisposable
    {
        DbSet<Article> Articles { get; }
        DbSet<Criteria> Criterias { get; }
        DbSet<Data> Data { get; }
        DbSet<Field> Fields { get; }
        DbSet<Stage> Stages { get; }
        DbSet<StageRole> StageRoles { get; }
        DbSet<Strategy> Strategies { get; }
        DbSet<Study> Studies { get; }
        DbSet<Task> Tasks { get; }
        DbSet<TaskType> TaskTypes { get; }
        DbSet<User> Users { get; }

        int SaveChanges();
        DbSet<T> Set<T>() where T : class, IEntity;
        EntityEntry Entry(object o);
    }
}