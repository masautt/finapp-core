using System.Linq.Expressions;
using Database;
using Microsoft.EntityFrameworkCore;

namespace Repos.Transums.Shared;

public class TransumCommonRepo<TEntity, TKey>(AppDbContext dbContext, Expression<Func<TEntity, TKey>> keySelector)
    where TEntity : class
{
    private readonly AppDbContext _dbContext = dbContext ?? throw new ArgumentNullException(nameof(dbContext));
    private readonly Expression<Func<TEntity, TKey>> _keySelector = keySelector ?? throw new ArgumentNullException(nameof(keySelector));

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

        if ((keyType.IsValueType && keyType.FullName!.StartsWith("System.ValueTuple")) || keyType.IsAnonymousType())
        {
            // Handle multi-key case (tuple or anonymous object)
            var keyMembers = keyType.GetProperties();

            foreach (var prop in keyMembers)
            {
                var entityProp = Expression.Property(parameter, prop.Name);
                var keyValue = Expression.Constant(prop.GetValue(key));
                var equals = Expression.Equal(entityProp, keyValue);
                comparison = comparison == null ? equals : Expression.AndAlso(comparison, equals);
            }
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

    public async Task<TEntity?> FetchRandomAsync() =>
        await _dbContext.Set<TEntity>().OrderBy(e => Guid.NewGuid()).FirstOrDefaultAsync();

    public async Task<int> FetchCountAsync() =>
        await _dbContext.Set<TEntity>().CountAsync();
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