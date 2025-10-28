using System.Linq.Expressions;
using Database;
using Microsoft.EntityFrameworkCore;
using Models.Transums;

namespace Repos.Transums;

public class TransumCommonRepo<TEntity, TKey>(AppDbContext dbContext, Expression<Func<TEntity, TKey>> keySelector)
    where TEntity : class
{
    private readonly AppDbContext _dbContext = dbContext ?? throw new ArgumentNullException(nameof(dbContext));

    private readonly Expression<Func<TEntity, TKey>> _keySelector =
        keySelector ?? throw new ArgumentNullException(nameof(keySelector));

    public async Task<List<TKey>> FetchAllUniqueKeysAsync()
    {
        return await _dbContext.Set<TEntity>()
            .Select(_keySelector)
            .Distinct()
            .ToListAsync();
    }

    public async Task<TEntity?> FetchByKeyAsync(TKey key)
    {
        var entitySet = _dbContext.Set<TEntity>();
        var parameter = Expression.Parameter(typeof(TEntity), "e");
        Expression? comparison = null;

        var keyType = key!.GetType();

        if (keyType.IsValueType && keyType.FullName!.StartsWith("System.ValueTuple") || keyType.IsAnonymousType())
        {
            // Handle multi-key case (tuple or anonymous object)
            var keyMembers = keyType.GetProperties();

            comparison =
                (from prop in keyMembers
                 let entityProp = Expression.Property(parameter, prop.Name)
                 let keyValue = Expression.Constant(prop.GetValue(key))
                 select Expression.Equal(entityProp, keyValue)).Aggregate(comparison,
                    (current, equals) => current == null ? equals : Expression.AndAlso(current, equals));
        }
        else
        {
            // Handle single key case
            var body = Expression.Equal(_keySelector.Body, Expression.Constant(key));
            comparison = body;
            parameter = _keySelector.Parameters.Single();
        }

        var predicate = Expression.Lambda<Func<TEntity, bool>>(comparison!, parameter);
        return await entitySet.SingleOrDefaultAsync(predicate);
    }

    public async Task<List<TEntity>> FetchByPartialKeyAsync(object partialKey)
    {
        var entitySet = _dbContext.Set<TEntity>();
        var parameter = Expression.Parameter(typeof(TEntity), "e");
        Expression? comparison = null;

        var keyMembers = partialKey.GetType().GetProperties();

        comparison =
            (from prop in keyMembers
                let entityProp = Expression.Property(parameter, prop.Name)
                let keyValue = Expression.Constant(prop.GetValue(partialKey))
                select Expression.Equal(entityProp, keyValue)).Aggregate(comparison,
                (current, equals) => current == null ? equals : Expression.AndAlso(current, equals));

        var predicate = Expression.Lambda<Func<TEntity, bool>>(comparison!, parameter);

        return await entitySet.Where(predicate).ToListAsync();
    }


    public async Task<bool> KeyExistsAsync(TKey key)
    {
        var entitySet = _dbContext.Set<TEntity>();
        var parameter = Expression.Parameter(typeof(TEntity), "e");
        Expression? comparison = null;

        var keyType = key!.GetType();

        if (keyType.IsValueType && keyType.FullName!.StartsWith("System.ValueTuple") || keyType.IsAnonymousType())
        {
            // Handle multi-key case (tuple or anonymous object)
            var keyMembers = keyType.GetProperties();

            comparison =
                (from prop in keyMembers
                 let entityProp = Expression.Property(parameter, prop.Name)
                 let keyValue = Expression.Constant(prop.GetValue(key))
                 select Expression.Equal(entityProp, keyValue)).Aggregate(comparison,
                    (current, equals) => current == null ? equals : Expression.AndAlso(current, equals));
        }
        else
        {
            // Handle single key case
            var body = Expression.Equal(_keySelector.Body, Expression.Constant(key));
            comparison = body;
            parameter = _keySelector.Parameters.Single();
        }

        var predicate = Expression.Lambda<Func<TEntity, bool>>(comparison!, parameter);
        return await entitySet.AnyAsync(predicate);
    }

    public async Task<TEntity?> FetchRandomAsync(
        params Expression<Func<TEntity, bool>>[]? predicates)
    {
        var query = _dbContext.Set<TEntity>().AsQueryable();

        if (predicates is { Length: > 0 })
        {
            query = predicates.Aggregate(query, (current, predicate) => current.Where(predicate));
        }

        var count = await query.CountAsync();
        if (count == 0)
            return null;

        var randomIndex = Random.Shared.Next(count);
        return await query.Skip(randomIndex).FirstOrDefaultAsync();
    }

    public async Task<int> FetchCountAsync(
        params Expression<Func<TEntity, bool>>[]? predicates)
    {
        var query = _dbContext.Set<TEntity>().AsQueryable();

        if (predicates is not { Length: > 0 }) return await query.CountAsync();
        query = predicates.Aggregate(query, (current, predicate) => current.Where(predicate));

        return await query.CountAsync();
    }

    public async Task<List<TEntity>> FetchBySortOrderAsync<TOrderBy>(
        Expression<Func<TransumCommonDto, TOrderBy>> orderBy,
        bool descending = false,
        int? limit = null)
    {
        var parameter = Expression.Parameter(typeof(TEntity), "t");
        var body = Expression.Invoke(orderBy, parameter);
        var lambda = Expression.Lambda<Func<TEntity, TOrderBy>>(body, parameter);

        var query = _dbContext.Set<TEntity>().AsQueryable();

        query = descending
            ? query.OrderByDescending(lambda)
            : query.OrderBy(lambda);

        if (limit.HasValue)
            query = query.Take(limit.Value);

        return await query.ToListAsync();
    }

    public async Task<bool> AnyAsync(
        params Expression<Func<TEntity, bool>>[] predicates)
    {
        var query = _dbContext.Set<TEntity>().AsQueryable();

        if (predicates is { Length: > 0 })
        {
            query = predicates.Aggregate(query, (current, predicate) => current.Where(predicate));
        }

        return await query.AnyAsync();
    }
}


public static class TypeExtensions
{
    public static bool IsAnonymousType(this Type type)
    {
        return Attribute.IsDefined(type, typeof(System.Runtime.CompilerServices.CompilerGeneratedAttribute), false)
               && type.IsGenericType && type.Name.Contains("AnonymousType")
               && (type.Name.StartsWith("<>", StringComparison.OrdinalIgnoreCase)
                   || type.Name.StartsWith("VB$", StringComparison.OrdinalIgnoreCase))
               && type.Attributes.HasFlag(System.Reflection.TypeAttributes.NotPublic);
    }
}