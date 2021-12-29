# Executa os testes e contrói a tabela de cobertura de código do Coverlet
Function Coverage() {
	Process {
		dotnet test --no-build /p:CollectCoverage=true
	}
}