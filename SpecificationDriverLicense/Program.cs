using SpecificationDriverLicense;
using System.Data;
using System.Text.Json;

int edadParaEvaluar = 18 ;

var person = new PersonModel
{
    Altura = 6,
    Id = 1,
    Edad = 24,
    Nombre = "Vaxi Drez"
};


var result = EvaluateDriverLicenceByEdad(edadParaEvaluar, person) ? $"{person.Nombre} obtuvo la licencia" : "Licencia negada";

Console.WriteLine(result);

bool EvaluateDriverLicenceByEdad(int edadParaEvaluar, PersonModel personModel)
{
    var specification = new DriverLicenseBySpecification(edadParaEvaluar);

    return specification.IsCumpleReglas(personModel);
}


var personData = File.ReadAllText(@"person.json");
var persons = JsonSerializer.Deserialize<List<PersonModel>>(personData);

var personsWithLicense = EvaluateColletionPeronByLicenseDriver(persons, edadParaEvaluar);

personsWithLicense.ToList().ForEach(person => Console.WriteLine($"{person.Nombre}  {person.Edad} obtuvo la licencia"));

IEnumerable<PersonModel> EvaluateColletionPeronByLicenseDriver (IEnumerable<PersonModel> personsModel, int edadParaEvaluar)
{
    return personsModel.Where(x => EvaluateDriverLicenceByEdad(edadParaEvaluar, x));
}