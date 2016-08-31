using System;
using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.ChangeTracking;
using RecensysCoreRepository.Entities;

namespace RecensysCoreRepository.EF
{
    public interface IDbContext : IDisposable
    {
        int SaveChanges();
        DbSet<T> Set<T>() where T : class, IEntity;
        EntityEntry Entry(object o);
    }
}
