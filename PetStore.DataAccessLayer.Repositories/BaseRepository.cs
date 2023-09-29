using System.Diagnostics.CodeAnalysis;
using System.Linq.Expressions;
using Microsoft.EntityFrameworkCore;
using PetStore.DataAccessLayer.Models;
using PetStore.DataAccessLayer.Repositories.Interfaces;

namespace PetStore.DataAccessLayer.Repositories;

[ExcludeFromCodeCoverage]
public abstract class BaseRepository<TEntity> : IRepository<TEntity> where TEntity : BaseModel
{
    internal readonly PetStoreContext Context;
    internal readonly DbSet<TEntity> DbSet;

    public BaseRepository(PetStoreContext context)
    {
        Context = context;
        // TODO: Uncomment when it's time to add a SQL database.
        // DbSet = context.Set<TEntity>();
    }

    public virtual void Delete(TEntity entityToDelete, string email)
    {
        DbSet.Attach(entityToDelete);

        entityToDelete.DestroyedAt = DateTimeOffset.UtcNow;
        entityToDelete.DestroyedBy = email;

        Context.Entry(entityToDelete).State = EntityState.Modified;
    }

    public virtual void Delete(long? id, string email)
    {
        var entityToDelete = DbSet.FirstOrDefault(a => a.Id == id);
        if (entityToDelete == null)
            throw new KeyNotFoundException($"Entry with ID {id} doesn't exist");

        entityToDelete.DestroyedAt = DateTimeOffset.UtcNow;
        entityToDelete.DestroyedBy = email;

        Context.Entry(entityToDelete).State = EntityState.Modified;
    }

    public virtual void Delete(List<TEntity> entitiesToDelete, string email)
    {
        entitiesToDelete.ForEach(entityToDelete => Delete(entityToDelete, email));
    }

    public virtual IEnumerable<TEntity?> Get(Expression<Func<TEntity, bool>>? filter = null,
        Func<IQueryable<TEntity>, IOrderedQueryable<TEntity>>? orderBy = null, string? includeProperties = "",
        bool noTracking = false)
    {
        IQueryable<TEntity> query = DbSet;

        if (filter != null) query = query.Where(filter);

        if (!string.IsNullOrWhiteSpace(includeProperties))
            foreach (var includeProperty in includeProperties.Split(',', StringSplitOptions.RemoveEmptyEntries))
                query = query.Include(includeProperty);

        query = query.Where(a => a.DestroyedAt == null && a.DestroyedBy == null);

        if (noTracking)
            query = query.AsNoTracking();

        if (orderBy != null)
            return CheckSoftDelete(orderBy(query).ToArray());
        return CheckSoftDelete(query.ToArray());
    }

    public List<TEntity?> GetAll()
    {
        var query = GetQueryWithAllIncludes();

        query = query.Where(a => a.DestroyedAt == null && a.DestroyedBy == null);

        return CheckSoftDelete(query.ToArray());
    }

    public virtual TEntity? GetById(long? id)
    {
        var query = GetQueryWithAllIncludes();

        query = query.Where(a => a.DestroyedAt == null && a.DestroyedBy == null &&
                                 a.Id == id);

        return CheckSoftDelete(query.FirstOrDefault());
    }

    public virtual bool ExistsById(long? id)
    {
        return DbSet.Any(a => a.Id == id);
    }

    public virtual void DeleteById(long? id, string identifier)
    {
        var entity = DbSet.FirstOrDefault(a => a.Id == id);
        if (entity == null)
            return;

        entity.DestroyedAt = DateTimeOffset.UtcNow;
        entity.DestroyedBy = identifier;

        DbSet.Update(entity);
    }

    public virtual void Insert(TEntity entity, string identifier)
    {
        if (DbSet.Any(a => a.Id == entity.Id))
            return;

        entity.CreatedAt = DateTimeOffset.UtcNow;
        entity.CreatedBy = identifier;

        DbSet.Add(entity);
    }

    public virtual void Update(TEntity entity, string identifier)
    {
        DbSet.Attach(entity);

        entity.UpdatedAt = DateTimeOffset.UtcNow;
        entity.UpdatedBy = identifier;

        Context.Entry(entity).State = EntityState.Modified;
    }

    public virtual void Save()
    {
        Context.SaveChanges();
    }

    public virtual void SaveAndStopTracking()
    {
        Context.SaveChanges();

        foreach (var entry in Context.ChangeTracker.Entries())
            entry.State = EntityState.Detached;
    }

    public abstract IQueryable<TEntity> GetQueryWithAllIncludes();
    public abstract TEntity? CheckSoftDelete(TEntity? entity);

    public List<TEntity?> CheckSoftDelete(TEntity?[]? entities)
    {
        if (entities == null || !entities.Any())
            return new List<TEntity?>();

        for (var i = 0; i < entities.Length; i++)
            entities[i] = CheckSoftDelete(entities[i]);

        return entities.ToList();
    }
}