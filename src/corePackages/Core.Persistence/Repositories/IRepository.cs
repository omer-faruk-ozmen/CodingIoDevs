using System.Linq.Expressions;

namespace Core.Persistence.Repositories;

internal interface IRepository<T> : IQuery<T> where T : Entity
{
    T Get(Expression<Func<T,bool>> predicate);


}