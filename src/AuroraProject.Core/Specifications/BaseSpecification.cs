using AuroraProject.Core.Validations;
using System.Linq.Expressions;

namespace AuroraProject.Core.Specifications
{
    public abstract class BaseSpecification<T> : ISpecification<T> where T : class
    {
        protected BaseSpecification(Expression<Func<T, bool>> Where)
        {
            ExceptionValidate.EqualNull(Where, "@Parameter:@Where não pode ser nulo.");

            WhereLambda = Where;
        }

        public Expression<Func<T, bool>> WhereLambda { get; }

        public IList<Expression<Func<T, object>>> IncludesLambda { get; } = new List<Expression<Func<T, object>>>();

        public IList<string> IncludeStrings { get; } = new List<string>();

        public Expression<Func<T, object>> OrderBy { get; private set; }

        public Expression<Func<T, object>> OrderByDescending { get; private set; }

        public int Take { get; private set; }

        public int Skip { get; private set; }

        public bool IsPagingEnabled { get; private set; }

        protected virtual void AddInclude(Expression<Func<T, object>> includeExpression)
        {
            ExceptionValidate.EqualNull(includeExpression, "@Parameter:@includeExpression não pode ser nulo.");

            IncludesLambda.Add(includeExpression);
        }

        protected virtual void AddInclude(string includeString)
        {
            IncludeStrings.Add(includeString);
        }

        protected virtual void ApplyPaging(int skip, int take)
        {
            IsPagingEnabled = true;
            this.Skip = skip;
            this.Take = take;
        }

        public virtual void ApplyOrderBy(Expression<Func<T, object>> orderByExpression)
        {
            ExceptionValidate.EqualNull(orderByExpression, "@Parameter:@orderByExpression não pode ser nulo.");
           
            OrderBy = orderByExpression;
        }

        public virtual void ApplyOrderByDescending(Expression<Func<T, object>> orderByDescendingExpression)
        {
            ExceptionValidate.EqualNull(orderByDescendingExpression, "@Parameter:@orderByDescendingExpression não pode ser nulo.");

            OrderByDescending = orderByDescendingExpression;
        }
    }
}