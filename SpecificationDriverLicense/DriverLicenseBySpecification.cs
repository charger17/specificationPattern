using System.Linq.Expressions;

namespace SpecificationDriverLicense
{
    public class DriverLicenseBySpecification : ExpressionSpecification<PersonModel>
    {
        public DriverLicenseBySpecification(int edadParaEvaluar) : base(x => x.Edad > edadParaEvaluar)
        {

        }
        
    }
}
