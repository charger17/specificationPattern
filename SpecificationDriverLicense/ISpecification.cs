namespace SpecificationDriverLicense
{
    public interface ISpecification<in T>
    {

        bool IsCumpleReglas(T obj);
    }
}
