namespace EficazFramework.Tests.Generators;

//[TestFixture]
public class XamlIconGeneratorTest : BaseTest<EficazFramework.Generators.XAML.XamlIconsGenerator>
{
    public XamlIconGeneratorTest() : base(OutputKind.DynamicallyLinkedLibrary, true) { }

    //Testes iniciais de compilação e execução
    [Test]
    public void EmptyCodeTest()
    {
        var source = @"namespace EficazFramework.Icons { }";
        var trees = GetAllGeneratedOutput(source);
        trees.Count.Should().Be(2);
        trees[1].Should().NotContain("<Geometry x:Key");
    }

    [Test]
    public void ImplementedClassTest()
    {
        var source = @"using System.Collections.Generic;
        namespace EficazFramework.Icons
        {
            public class IconPack1
            { 
                [EficazFramework.Generators.XAML.IconPackMember]
                public IDictionary<string, string> Pack => new Dictionary<string, string>
                {
                    {""Abacus"", ""M5 5H7V11H5V5M10 5H8V11H10V5M5 19H7V13H5V19M10 13H8V19H10V17H15V15H10V13M2 21H4V3H2V21M20 3V7H13V5H11V11H13V9H20V15H18V13H16V19H18V17H20V21H22V3H20Z""}
                };
            }

            public class IconPack2
            { 
                [EficazFramework.Generators.XAML.IconPackMember]
                public IDictionary<string, string> Pack => new Dictionary<string, string>
                {
                    {""Abacus"",""M5 5H7V11H5V5M10 5H8V11H10V5M5 19H7V13H5V19M10 13H8V19H10V17H15V15H10V13M2 21H4V3H2V21M20 3V7H13V5H11V11H13V9H20V15H18V13H16V19H18V17H20V21H22V3H20Z""},
                    { ""AbjadArabic"",""M12 4C10.08 4 8.5 5.58 8.5 7.5C8.5 8.43 8.88 9.28 9.5 9.91C7.97 10.91 7 12.62 7 14.5C7 17.53 9.47 20 12.5 20C14.26 20 16 19.54 17.5 18.66L16.5 16.93C15.28 17.63 13.9 18 12.5 18C10.56 18 9 16.45 9 14.5C9 12.91 10.06 11.53 11.59 11.12L16.8 9.72L16.28 7.79L11.83 9C11.08 8.9 10.5 8.28 10.5 7.5C10.5 6.66 11.16 6 12 6C12.26 6 12.5 6.07 12.75 6.2L13.75 4.47C13.22 4.16 12.61 4 12 4Z""},
                    { ""AbjadHebrew"",""M3.9 4L9 10.03C7.58 10.17 6.36 11.18 6 12.59L4 20H6.07L7.92 13.11C8.09 12.46 8.69 12 9.36 12H10.69L17.47 20H20.1L15 13.97C16.42 13.83 17.64 12.82 18 11.41L20 4H17.93L16.08 10.89C15.91 11.54 15.31 12 14.64 12H13.31L6.53 4Z""},
                    { ""AbTesting"",""M4 2A2 2 0 0 0 2 4V12H4V8H6V12H8V4A2 2 0 0 0 6 2H4M4 4H6V6H4M22 15.5V14A2 2 0 0 0 20 12H16V22H20A2 2 0 0 0 22 20V18.5A1.54 1.54 0 0 0 20.5 17A1.54 1.54 0 0 0 22 15.5M20 20H18V18H20V20M20 16H18V14H20M5.79 21.61L4.21 20.39L18.21 2.39L19.79 3.61Z""},
                    { ""AbugidaDevanagari"",""M8 3V5H11C12.32 5 13.41 5.83 13.82 7H6V9H14V10H12C9.25 10 7 12.25 7 15C7 17.75 9.25 20 12 20C12.77 20 13.45 19.73 14 19.3V21H16V17H14C13.55 17.62 12.83 18 12 18C10.33 18 9 16.67 9 15C9 13.33 10.33 12 12 12H16V9H18V7H15.9C15.43 4.72 13.41 3 11 3H8Z""}
                };
            }
        }";
        var trees = GetAllGeneratedOutput(source);
        trees.Count.Should().Be(2);
        trees[0].Should().Contain(@"<Geometry x:Key=""Icon.IconPack1.Abacus"" >");
        trees[1].Should().Contain(@"<Geometry x:Key=""Icon.IconPack2.Abacus"" >");
        trees[1].Should().Contain(@"<Geometry x:Key=""Icon.IconPack2.AbjadArabic"" >");
        trees[1].Should().Contain(@"<Geometry x:Key=""Icon.IconPack2.AbjadHebrew"" >");
        trees[1].Should().Contain(@"<Geometry x:Key=""Icon.IconPack2.AbTesting"" >");
        trees[1].Should().Contain(@"<Geometry x:Key=""Icon.IconPack2.AbugidaDevanagari"" >");

    }

}