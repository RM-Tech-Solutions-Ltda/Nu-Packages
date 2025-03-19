Criação de pacotes Nuget

- Criando a library
-> Dentro do diretório destino:
	- Criação do projeto de testes primeiramente
		-> dotnet new xunit -o MinhaOrganizacao.NomePacote.UnitTests
		-> Instalar pacotes de testes, Ex. FluentAssertions.
		-> Pensar nos testes que devem ser implementados para cobrir o que será necessário para ter confiança de que o código funciona corretamente.
	
	- Criação do projeto tipo ClassLib
		-> dotnet new classlib -o MinhaOrganizacao.NomePacote

	- Adicionar referencia no projeto de teste ao projeto de classlib
		-> dotnet add reference ..\MinhaOrganizacao.NomePacote\

	- Implementar todas as lógicas de código e de testes necessárias.

	- dentro do diretório do pacote a ser criado:
		- Criação do pacote
			-> dotnet pack -c release -o dist

-> criando a solution do projeto
	-> dotnet new sln
	-> dotnet sln add .\MinhaOrganizacao.NomePacote\
	-> dotnet sln add .\MinhaOrganizacao.NomePacote.UnitTests\	


-> Gerando pacote via Visual Studio
	-> botão direito no projeto de classlib
	-> selecionar propriedades.
	-> Ajustar configurações necessárias.
	-> aba de opções -> Compilação -> "Pacote MinhaOrganizacao.NomePacote"
		assim gerando o pacote dentro da bin

-> adicionando seu pacote a um projeto
	-> dotnet add package MinhaOrganizacao.NomePacote -s "caminho do pacote"(~\MinhaOrganizacao.NomePacote\MinhaOrganizacao.NomePacote\dist(ou bin)\)

-> adicionando via Visual Studio
	-> Ferramentas -> Opções -> Pesquisar por: Nuget -> Gerenciador de Pacotes do Nuget -> Origem do Pacote
		-> Adicionar nova origem de pacotes referenciando seu repositório local de pacotes.



