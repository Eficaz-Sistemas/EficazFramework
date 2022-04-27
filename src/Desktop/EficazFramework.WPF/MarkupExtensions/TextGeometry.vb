Namespace MarkupExtensions

    Public Class TextGeometry
        Inherits Markup.MarkupExtension

        Public Property Text As String = Nothing
        Public Property FontFamily As FontFamily = System.Windows.Application.Current.TryFindResource("Font_SegoeMDL2Assets")
        Public Property FontSize As Double = 12

        Public Sub New(ByVal Text As String)
            Me.Text = Text
        End Sub

        Public Overrides Function ProvideValue(serviceProvider As IServiceProvider) As Object
            Return Me.ProvideValue(Me.Text)
        End Function

        Public Overloads Function ProvideValue(ByVal text As String) As Geometry
            If String.IsNullOrEmpty(text) Then Return Nothing
            Try
                Dim finalgeometry As Geometry = Nothing
                If Me.FontFamily Is Nothing Then Me.FontFamily = New FontFamily("Segoe UI")
                Dim tface As New Typeface(Me.FontFamily, FontStyles.Normal, FontWeights.Medium, FontStretches.Normal)
                Dim t As New FormattedText(text, Globalization.CultureInfo.CurrentUICulture, FlowDirection.LeftToRight, tface, Me.FontSize, Brushes.Black)
                finalgeometry = t.BuildGeometry(New Point(0, 0))
                Return finalgeometry
            Catch ex As Exception
                Return Nothing
            End Try
        End Function


    End Class

End Namespace

