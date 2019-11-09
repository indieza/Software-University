"Server=DESKTOP-40U9D0R\SQLEXPRESS;Database=Hospital;Integrated Security=true"
Microsoft.EntityFrameworkCore.SqlServer 2.2.0 - DbContext
EntityFrameworkCore.Tools - Add-Migration
Какъвто тип данни ползваш в Object класа, АБСОЛЮТНО същите трябва да ползваш и в DTO класа!!!!!!!!!!
---------------------------------------------------------------------------------------------------------------------
[Required, MinLength(10), MaxLength(100), Column(TypeName = "NVARCHAR(100)")]
[Required, ForeignKey("Course")]
[StringLength(50, MinimumLength = 3)] - По-надежно е :)
---------------------------------------------------------------------------------------------------------------------
// IMPORT
var users = JsonConvert.DeserializeObject<User[]>(inputJson);
---------------------------------------------------------------------------------------------------------------------
// EXPORT
var json = JsonConvert.SerializeObject(exportedSoldProducts, Formatting.Indented);
---------------------------------------------------------------------------------------------------------------------
DefaultContractResolver contractResolver = new DefaultContractResolver()
{
    NamingStrategy = new CamelCaseNamingStrategy()
};

var json = JsonConvert.SerializeObject(result, new JsonSerializerSettings()

{
    ContractResolver = contractResolver,
    Formatting = Formatting.Indented,
    NullValueHandling = NullValueHandling.Ignore //Ако ти е казано в условието да игнорираш нулевите данни
});
---------------------------------------------------------------------------------------------------------------------
// IMPORT
[XmlType("Category")]
[XmlAttribute(AttributeName = "name")]
var xmlSerializer = new XmlSerializer(typeof(ImportProjectionDto[]), new XmlRootAttribute("Projections"));
var projectionsDto = (ImportProjectionDto[])xmlSerializer.Deserialize(new StringReader(xmlString));
---------------------------------------------------------------------------------------------------------------------
// EXPORT
[XmlType("Product")]
[XmlElement(ElementName = "name")]
var xmlSerializer = new XmlSerializer(typeof(CustomerDto[]), new XmlRootAttribute("Customers"));

var sb = new StringBuilder();
var namespaces = new XmlSerializerNamespaces(new [] {XmlQualifiedName.Empty});
xmlSerializer.Serialize(new StringWriter(sb), customers, namespaces);

return sb.ToString().TrimEnd();
---------------------------------------------------------------------------------------------------------------------
this.CreateMap<ImportUserDto, User>(); // Добавя се в Profile-а на проекта
Mapper.Initialize(x =>
{
    x.AddProfile<ProductShopProfile>(); // В Main метода, за да се използва
});