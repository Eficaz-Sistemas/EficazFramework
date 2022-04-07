namespace EficazFramework.XAML.Resources.Generator;

internal class ServicesReceiver : ISyntaxContextReceiver
{
    public List<ClassDeclarationSyntax> ClassesToRegister { get; } = new List<ClassDeclarationSyntax>();
    
    void ISyntaxContextReceiver.OnVisitSyntaxNode(GeneratorSyntaxContext context)
    {
        if (context.Node is ClassDeclarationSyntax cds)
        {
            var testClass = (INamedTypeSymbol)context.SemanticModel.GetDeclaredSymbol(context.Node)!;
            var attributes = testClass.GetAttributes();
            if (attributes.Where(att => att.GetType() == typeof(IconSourceAttribute)).Count() > 0)
                ClassesToRegister.Add(cds);
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
