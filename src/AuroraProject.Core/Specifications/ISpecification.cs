using System.Linq.Expressions;

namespace AuroraProject.Core.Specifications
{
    public interface ISpecification<T> where T : class
    {
        /// <summary>
        /// Expressão lambda para realizar o filtro where.
        /// </summary>
        Expression<Func<T, bool>> WhereLambda { get; }
        
        /// <summary>
        /// Lista de parametros lambda com os includes para realizar os joins.
        /// </summary>
        IList<Expression<Func<T, object>>> IncludesLambda { get; }
        /// <summary>
        /// Lista de parametros string com os includes para realizar os joins. 
        /// </summary>
        IList<string> IncludeStrings { get; }
        /// <summary>
        /// Expressão lambda para realizar ordenação ascendente.
        /// </summary>
        Expression<Func<T, object>> OrderBy { get; }
        /// <summary>
        /// Expressão lambda para realizar ordenação descendente.
        /// </summary>
        Expression<Func<T, object>> OrderByDescending { get; }
        /// <summary>
        /// Pegar quantidade de registros no retorno do select feito pelo EF core. 
        /// </summary>
        int Take { get; }
        /// <summary>
        /// Pular quantidade de registro no retorno do select feito pelo EF core. 
        /// </summary>
        int Skip { get; }
        /// <summary>
        /// Habilitar paginação.
        /// </summary>
        bool IsPagingEnabled { get; }
    }
}
