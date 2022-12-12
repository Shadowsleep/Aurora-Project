using AuroraProject.Core.Specifications;
using AuroraProject.Core.Validations;
using Microsoft.EntityFrameworkCore;

namespace AuroraProject.Data.Repository
{
    internal class EvaluatorOfSpecification<T> where T : class
    {
        internal IQueryable<T> GetQuery(IQueryable<T> inputQuery, ISpecification<T> specification)
        {
            ExceptionValidate.EqualNull(specification, $"Parameter: @specification Não pode ser nulo");

            var query = inputQuery;

            query = query.Where(specification.WhereLambda);

            query = specification.IncludesLambda.Aggregate(query, (current, include) => current.Include(include));

            query = specification.IncludeStrings.Aggregate(query, (current, include) => current.Include(include));

            if (specification.OrderBy != null)
            {
                query = query.OrderBy(specification.OrderBy);
            }
            else if (specification.OrderByDescending != null)
            {
                query = query.OrderByDescending(specification.OrderByDescending);
            }

            if (specification.IsPagingEnabled)
            {
                query = query.Skip(specification.Skip * specification.Take)
                             .Take(specification.Take);
            }

            return query;
        }
    }
}
