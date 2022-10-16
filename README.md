# ProjetoInternalTalent

Criar um projeto apresentando os conceitos vistos nos cursos realizados.

Requisitos:

	- Utilizar os seguintes tipos primitivos (int, bool, datetime, string, arrays (Lista ou Coleções))
	- Ter 1 exemplo de cada pilar de OOP
	- Ter 1 exemplo de Design Pattern (Criação, Comportamento ou estrutura)
	- Ter um relacionamento entre os objetos (1:1 ou 1:n ou n:n)
	- Utilizar um ORM
	- Ter um teste de unidade
	- Utlizar o Swagger para documentar a API
	- Criar um README.md
	- Código precisa estar versionado no Github
	- Precisa estar fazendo o build através do Github Actions (Continuos Integration)
	- Utilizar Conventional Commits
  
Tecnologias:

	- Dotnet core 5
	- Entity Framework
	- Automapper
	- Logger
	- Github
	- SQL Server

Importante: se você está tentando atualizar o banco de dados com "dotnet ef database update" no linux, e
está tendo a seguinte mensagem de erro: 

Strings.PlatformNotSupported_DataSqlClient

Adicione em seu csproj a seguinte instrução:

	  <Target Name="PostBuild" AfterTargets="PostBuildEvent">
	    <Exec Command="cp $(OutDir)runtimes/unix/lib/netcoreapp3.1/Microsoft.Data.SqlClient.dll $(OutDir)" />
	  </Target>
