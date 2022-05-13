namespace EficazFramework.Tests.Generators;

//[TestFixture]
public class SvgToDictionary : BaseTest<EficazFramework.Generators.Svg.ModelBuilder>
{
    public SvgToDictionary() : base(OutputKind.DynamicallyLinkedLibrary) { }

    //[Test]
    public void ImplementedClassTest()
    {
        var source = @"<?xml version=""1.0"" standalone=""no""?>;
< !DOCTYPE svg PUBLIC "" -//W3C//DTD SVG 1.1//EN"" ""http://www.w3.org/Graphics/SVG/1.1/DTD/svg11.dtd"" >
<svg xmlns=""http://www.w3.org/2000/svg"" xmlns:xlink=""http://www.w3.org/1999/xlink"" version=""1.1"">
    <glyph glyph-name=""ic_fluent_accessibility_32_regular"" unicode=""&#xfcb7;"" arabic-form=""initial"" 
           d=""M211 398q0 17 11.5 28.5t27.5 11.5t27.5 -11.5t11.5 -28t-11.5 -28t-27.5 -11.5t-27.5 11.5t-11.5 27.5zM250 469q-17 0 -31.5 -7.5t-24.5 -21t-13 -29.5t1 -32l-71 25q-19 6 -36.5 -3t-24 -27.5t2 -36t26.5 -24.5l93 -32v-59q0 -3 -2 -7l-56 -115q-8 -18 -1.5 -36.5
           t24 -27t36.5 -2.5t27 24l50 102l49 -102q6 -12 16.5 -19t23.5 -8t25 4.5t19 16.5t8 24t-5 24l-56 115q-2 3 -2 7v59l93 32q18 7 26.5 24.5t2 36t-24 27.5t-36.5 3l-71 -25q4 16 1 32t-13 29.5t-24.5 21t-31.5 7.5zM79 364q2 6 8.5 9t12.5 1l119 -41q31 -10 62 0l119 41
           q9 3 16 -3t5.5 -15.5t-10.5 -13.5l-98 -33q-7 -3 -11.5 -9t-4.5 -13v-65q0 -11 5 -20l56 -115q4 -9 -1.5 -17.5t-15 -7.5t-13.5 10l-50 101q-5 12 -16.5 16t-23 0t-16.5 -16l-50 -101q-4 -9 -13.5 -10t-15 7.5t-1.5 17.5l56 115q5 9 5 20v65q0 7 -4.5 13t-11.5 9l-98 33
           q-6 3 -9 9t-1 13z"" />
</svg>";
        var trees = GetAllGeneratedOutput(source);
        trees.Count.Should().Be(2);
        trees[1].Should().Contain("internal class IconSourceAttribute : System.Attribute");
        trees[1].Should().Contain("internal class IconPackMemberAttribute : System.Attribute");
    }

}
