namespace EficazFramework.Generators.XAML;

internal class XamlIconServicesReceiver : ISyntaxContextReceiver
{
    public Dictionary<ClassDeclarationSyntax, PropertyDeclarationSyntax> ClassesToRegister { get; } = new();

    public bool ShouldCreate { get; set; } = false;

    void ISyntaxContextReceiver.OnVisitSyntaxNode(GeneratorSyntaxContext context)
    {
        if (context.Node is ClassDeclarationSyntax cds)
        {
            var testClass = (INamedTypeSymbol)context.SemanticModel.GetDeclaredSymbol(context.Node)!;
            Console.WriteLine($"Inspecting class {testClass.Name}");

            var member = cds.Members.Where(p => p.GetType() == typeof(PropertyDeclarationSyntax) &&
                                           p.AttributeLists.Any(a => a.ToString().Contains("IconPackMember"))).FirstOrDefault();
            if (member != null)
            {
                Console.WriteLine($"Found member {((PropertyDeclarationSyntax)member).Identifier.Text} into class {cds.Identifier.Text}");
                ClassesToRegister.Add(cds, member as PropertyDeclarationSyntax);
            }

            //var testClass = (INamedTypeSymbol)context.SemanticModel.GetDeclaredSymbol(context.Node)!;

            //var attributes = testClass.GetAttributes();
            //if (attributes.Where(att => att.GetType().Name == "").Count() > 0)
            //    ClassesToRegister.Add(testClass.Name, cds);
        }

        //if (syntaxNode is InvocationExpressionSyntax
        //{
        //    Expression: MemberAccessExpressionSyntax
        //    {
        //        Name.Identifier.ValueText: "AddServicesToDI"
        //    }
        //} invocationSyntax)
        //{
        //    InvocationSyntaxNode = invocationSyntax;
        //    HasCallToMethod = true;
        //}
    }
}
