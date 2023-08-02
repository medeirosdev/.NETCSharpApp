# Aplicação AutomaHelp

## Sobre o Projeto
- Uma Interface web feita em C# ASP.NET que aceita arquivos .CSV e trata seus dados, em seguida, salva em um banco de dados( MySQL ) para poder ser analisado mais tarde em uma das abas.


## Guia de Instalação
### Pré-requisitos
Instale em seu computador se não tiver esses requisitos, estes são essenciais para iniciar a aplicação.
- [.NET Core SDK](https://dotnet.microsoft.com/download) (versão 3.1 ou superior)
- [MySQL Server](https://dev.mysql.com/downloads/) (ou PostgreSQL, ou outro banco de dados relacional)


## Passo 1: Clonar o repositório
Clone este repositório em sua máquina local usando o seguinte comando:

```bash
git clone git@github.com:medeirosdev/.NETCSharpApp.git
```

## Passo 2: Altere a URL de conexão com o banco de dados no ProdutoService
Exemplo:

```bash
public String ConnectionString = "server=127.0.0.1;user=root;database=testwebapi2;port=3306;password=SENHA";
```

Localização da String: 
WebApplication1/NovaPasta/ProdutoService

## Passo 3 : Inicie o Projeto
Se estiver no Visual Studio, apenas clique no topo da IDE na seta verde, se estiver apenas por linha de comando, use:
```bash
dotnet run
```


### Guia de Rotas

| Rota                      | Descrição                                           |
| ------------------------- | --------------------------------------------------- |
| \Home\ErroView            | Rota para exibir a view de erro.                   |
| \Home\SuccessView         | Rota para exibir a view de sucesso.                |
| \Home\Sobre               | Rota para exibir informações sobre a empresa ou projeto.  |
| \Home\ProdutosImportados2  | Rota para exibir a lista de produtos importados.   |
| \Home\                    | Rota para Importar o arquivo CSV da aplicação      |
| \Home\ImportarProduto     | Rota para a página de importação de produtos.      |


### Algumas Dependências usadas e Informações mais técnicas
    <PackageReference Include="CsvHelper" Version="30.0.1" />
    <PackageReference Include="Dapper" Version="2.0.143" />
    <PackageReference Include="MySql.Data" Version="8.1.0" />
    <PackageReference Include="Npgsql" Version="7.0.4" />

### Arquitetura de Software Utilizada
- MVC Básico com adição do Service, já que , por boas práticas, a separação e simplicação do código torna a aplicação mais simples, escalável e mais fácil de manutenção.
- É uma aplicação relativamente pequena, portanto não foi necessário abstrações das funções relacionadas ao Banco de dados.
  
