
namespace EficazFramework.Tests.Shared;

public class MockClass
{
    public int Id { get; set; }
    public string Name { get; set; } = "";

    [System.Xml.Serialization.XmlAttribute("id")]
    public string Guid { get; set; } = System.Guid.NewGuid().ToString();
}

public class MockList : List<MockClass>
{
    public MockList()
    {
        Add(new MockClass { Id = 1, Name = "Mock 1" });
        Add(new MockClass { Id = 2, Name = "Mock 2" });
        Add(new MockClass { Id = 3, Name = "Mock 3" });
    }
}