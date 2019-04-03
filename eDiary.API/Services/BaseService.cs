using eDiary.API.Models.EF.Interfaces;
using System;
using System.Linq;
using System.Linq.Expressions;
using System.Threading.Tasks;

namespace eDiary.API.Services
{
    public interface IEntity
    {
        int Id { get; set; }
    }

    public abstract class BaseService
    {
        /// <summary>
        /// Search for an entity in the provided repository by condition. Returns an entity if it exists.
        /// </summary>
        /// <typeparam name="TEntity">Entity type</typeparam>
        /// <param name="repository"></param>
        /// <param name="condition"></param>
        /// <returns></returns>
        protected async Task<TEntity> FindEntityAsync<TEntity>(IRepository<TEntity> repository,
            Expression<Func<TEntity, bool>> condition) where TEntity : class
        {
            var e = (await repository.GetByConditionAsync(condition)).FirstOrDefault();
            return e ?? throw new Exception("Entity not found");
        }
    }
}
