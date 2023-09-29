using System.Linq.Expressions;

namespace PetStore.DataAccessLayer.Repositories.Interfaces;

public interface IRepository<TEntity> where TEntity : class
{
    /// <summary>
    ///     Deletes an entity
    /// </summary>
    /// <param name="entityToDelete">Entity to delete</param>
    /// <param name="email">Identifier of user that deletes the entity</param>
    void Delete(TEntity entityToDelete, string email);

    /// <summary>
    ///     Deletes an entity
    /// </summary>
    /// <param name="id">ID of entity to delete</param>
    /// <param name="email">Identifier of user that deletes the entity</param>
    void Delete(Guid id, string email);

    /// <summary>
    ///     Deletes a list of entities
    /// </summary>
    /// <param name="entitiesToDelete">List of entities to delete</param>
    /// <param name="email">Identifier of user that deletes the entities</param>
    void Delete(List<TEntity> entitiesToDelete, string email);

    /// <summary>
    ///     Filters the entities
    /// </summary>
    /// <param name="filter">Filter to apply on entities</param>
    /// <param name="orderBy">Ordering to apply on entities</param>
    /// <param name="includeProperties">Specifies, which properties should be included in query</param>
    /// <param name="noTracking">Specifies, whether the entities returned should be tracked by EF ChangeTracker</param>
    /// <returns></returns>
    IEnumerable<TEntity?> Get(
        Expression<Func<TEntity, bool>>? filter = null,
        Func<IQueryable<TEntity>, IOrderedQueryable<TEntity>>? orderBy = null,
        string? includeProperties = "", bool noTracking = false);

    /// <summary>
    ///     Gets all entities from the repository
    /// </summary>
    /// <returns>Returns all entities from the repository without EF Core tracking</returns>
    List<TEntity?> GetAll();

    /// <summary>
    ///     Gets an entity by its ID
    /// </summary>
    /// <param name="id">ID of Entity</param>
    /// <returns>Returns entity if found, null if not</returns>
    TEntity? GetById(Guid id);

    /// <summary>
    ///     Checks if the entity exists by specified ID
    /// </summary>
    /// <param name="id">ID of the entity</param>
    /// <returns>Returns true if exists, false if not</returns>
    bool ExistsById(Guid id);

    /// <summary>
    ///     Soft-deletes the entity with specified ID
    /// </summary>
    /// <param name="id">ID of the entity</param>
    /// <param name="identifier">Identifier of the user that deletes the entity</param>
    void DeleteById(Guid id, string identifier);

    /// <summary>
    ///     Inserts an entity
    /// </summary>
    /// <param name="entity">Entity to insert</param>
    /// <param name="identifier">Identifier of user that inserts the entity</param>
    void Insert(TEntity entity, string identifier);

    /// <summary>
    ///     Updates an entity
    /// </summary>
    /// <param name="entity">Entity to update</param>
    /// <param name="identifier">Identifier of user that inserts the entity</param>
    void Update(TEntity entity, string identifier);

    /// <summary>
    ///     Saves changes to the database
    /// </summary>
    void Save();

    /// <summary>
    ///     Saves changes to the database and removes all tracked changes from ChangeTracker
    /// </summary>
    void SaveAndStopTracking();

    /// <summary>
    ///     Gets a query that will return an entity with all properties included
    /// </summary>
    /// <returns></returns>
    IQueryable<TEntity> GetQueryWithAllIncludes();

    /// <summary>
    ///     Checks properties of specified entity if those are soft-deleted
    /// </summary>
    /// <param name="entity">Entity to check</param>
    /// <returns>Returns entity with removed soft-deleted properties</returns>
    TEntity? CheckSoftDelete(TEntity? entity);

    /// <summary>
    ///     Checks properties of specified entities if those are soft-deleted
    /// </summary>
    /// <param name="entities">Entities to check</param>
    /// <returns>Returns entities with removed soft-deleted properties</returns>
    List<TEntity?> CheckSoftDelete(TEntity?[] entities);
}