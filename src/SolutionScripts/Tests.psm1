# Executa os testes e contr�i a tabela de cobertura de c�digo do Coverlet
Function Coverage() {
	Process {
		dotnet test /p:CollectCoverage=true
	}
}