Imports System.Windows.Markup

Namespace MarkupExtensions

    <MarkupExtensionReturnType(GetType(Object))>
    Public Class Binding
        Inherits MarkupExtension

        Public Sub New()
            MyBase.New()
        End Sub

        Public Sub New(ByVal binding As Binding)
            MyBase.New()
        End Sub

        Public Overrides Function ProvideValue(serviceProvider As IServiceProvider) As Object
            Return MyClass.ProvideValue(serviceProvider)
        End Function

    End Class

End Namespace