using System.Linq.Expressions;

namespace SpecificationDriverLicense
{
    public class ExpressionSpecification<T> : ISpecification<T>
    {
        public Expression<Func<T, bool>>? Expression { get; } // where(x => x.altura > 1)

        private Func<T, bool>? _expressionFunc;

        private Func<T, bool> ExpressionFunc => _expressionFunc ?? (_expressionFunc = Expression!.Compile());

        public ExpressionSpecification(Expression<Func<T, bool>> expression)
        {
            Expression = expression;
        }

        public bool IsCumpleReglas(T obj)
        {
            bool result = ExpressionFunc(obj); // {nombre, edad, altura}

            return result;
        }
    }
}
