namespace EficazFramework.Tests;

public abstract class BaseTest<TSourceGenerator> where TSourceGenerator : ISourceGenerator
{
    private readonly OutputKind outputKind;

    public BaseTest(OutputKind outputKind)
    {
        this.outputKind = outputKind;
    }
    
    protected (string, string) GetGeneratedOutput(string source)
    {
        var outputCompilation = CreateCompilation(source);
        var trees = outputCompilation.SyntaxTrees.Reverse().Take(2).Reverse().ToList();
        foreach (var tree in trees)
        {
            TestContext.Out.WriteLine(System.IO.Path.GetFileName(tree.FilePath) + ":");
            TestContext.Out.WriteLine(tree.ToString());
        }
        return (trees.First().ToString(), trees[1].ToString());
    }

    protected List<string> GetAllGeneratedOutput(string source)
    {
        var outputCompilation = CreateCompilation(source);
        var trees = outputCompilation.SyntaxTrees.Reverse().Take(2).Reverse().ToList();
        foreach (var tree in trees)
        {
            TestContext.Out.WriteLine(System.IO.Path.GetFileName(tree.FilePath) + ":");
            TestContext.Out.WriteLine(tree.ToString());
        }
        return trees.Select(t => t.ToString()).ToList();
    }

    protected Compilation CreateCompilation(string source, bool isResource = false)
    {
        var syntaxTree = CSharpSyntaxTree.ParseText(source);

        var references = new List<MetadataReference>();
        foreach (var assembly in AppDomain.CurrentDomain.GetAssemblies())
            if (!assembly.IsDynamic && !string.IsNullOrWhiteSpace(assembly.Location))
                references.Add(MetadataReference.CreateFromFile(assembly.Location));

        var compilation = CSharpCompilation.Create("ef",
                                                   new SyntaxTree[] { syntaxTree },
                                                   references,
                                                   new CSharpCompilationOptions(outputKind));

        ISourceGenerator generator = Activator.CreateInstance<TSourceGenerator>();
        
        var driver = CSharpGeneratorDriver.Create(generator);
        driver.RunGeneratorsAndUpdateCompilation(compilation, out var outputCompilation, out var generateDiagnostics);

        var compileDiagnostics = outputCompilation.GetDiagnostics();

        if (!isResource)
            compileDiagnostics.Any(d => d.Severity == DiagnosticSeverity.Error).Should().BeFalse("Failed: " + compileDiagnostics.FirstOrDefault()?.GetMessage());
        
        if (!isResource)
            generateDiagnostics.Any(d => d.Severity == DiagnosticSeverity.Error).Should().BeFalse("Failed: " + generateDiagnostics.FirstOrDefault()?.GetMessage());
        
        return outputCompilation;
    }
}
