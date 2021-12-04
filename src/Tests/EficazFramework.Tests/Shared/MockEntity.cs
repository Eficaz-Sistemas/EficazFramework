using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace EficazFramework.Shared;

public class MockClass
{
    public int Id { get; set; }
    public string Name { get; set; }

    [System.Xml.Serialization.XmlAttribute("id")]
    public string Guid { get; set; } = System.Guid.NewGuid().ToString();
}
