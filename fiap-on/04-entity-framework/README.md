# Entity Framework

## Introdução

O Entity Frameworkou EF é um conjunto de tecnologias ADO.NET que permite a você `mapear seus objetos de modelos com entidade de banco de dados`, podemos comparar o EF ao JPA da tecnologia Java. 

É um framework testado e estabilizado por muitos anos para f`acilitar o acesso à base de dados, sem a necessidade de criações de camadas de conexões robustas ou até mesmo sem instruções SQL`. Sua primeira versão foi lançada em meados de 2008, fazendo parte do .NET 3.5 SP1 e do Visual Studio 2008, e a partir do EF4.1 já começa a ser enviado ao NuGet.org, sendo uns dos pacotes mais baixados da atualidade.

Sabemos que o Entity Framework possui muitos assuntos detalhados, os quais são desbravados em livros e em diversos conteúdos. A cada necessidade e hábito, devemos analisar a melhor forma de implementação do EF, seguem algumas:

- Criar um banco de dados escrevendo apenas códigos, use o conceito de **Code First** para definir seu modelo e então gerar o banco de dados.
- Criar um banco de dados usando caixas de diálogos do Visual Studio para adicionar os modelos e então gerar o banco de dados, use conceito de **Model First**.
- Usar um banco de dados existente para criar seus modelos, use o conceito de **Database First**.

A proposta é adicionar a biblioteca do Entity Framework em nosso projeto FiapSmartCityMVC. Será preciso adicionar bibliotecas no projeto .NET, criar tabelas e relacionamentos no SQL Serber, remover os trechos de código que usam o padrão convencional ADO.NET e escrever os comandos para o EF.

Vamos iniciar pela instalação da biblioteca do EF para SQL Server, acesse o Nuget, faça uma busca por SQL Server e selecione a instalação da biblioteca **Microsoft.EntityFrameworkCore.SqlServer**.

Não é preciso efetuar nenhuma alteração nesse arquivo, pois anteriormente já adicionamos a string de conexão para o banco de dados SQL Server.

Precisamos ter uma tabela para conseguir executar o trabalho com o EF, nos exemplos anteriores foi utilizada a tabela `ProductTYpe`, vamos seguir usando a mesma. 

Com a utilização dessa tabela anteriormente criada, vamos ter um problema no uso do EF, porém isso servirá como parte do aprendizado. O SQL Server e EF são *case-sensitive*, ou seja, diferenciam maiúscula e minúscula, note que a tabela Product Type possui seu nome e atributos declarados em caixa-alta. Com isso, serão necessários um trabalho maior e um pouco de digitação de código. Caso a tabela usada para trabalhar com o EF tenha suas colunas declaradas com o mesmo nome dos atributos de um modelo, pouca digitação ou quase nada será necessário para o funcionamento do EF .Abaixo, segue o script para criação da tabela `Product Type` no banco de dados SQL Server:

``` SQL
use FiapSmartCityMVC;

CREATE TABLE PRODUCTTYPEEF (
	TYPEID    INT identity(1,1)   PRIMARY KEY,
	TYPEDESCRIPTION VARCHAR(250)  NOT NULL,
	MARKETED  CHAR(1)
);
```

Tudo pronto para a implementação!

## Implementação EF Core

### Classe de Contexto

Para que nossa aplicação possa utilizar as facilidades do framework EF Core, precisamos criar a classe de contexto, ou classe de acesso à base. A `classe de contexto` será uma subclasse de **System.Data.Entity.DbContext**, que tem a responsabilidade de interação com os objetos e com o banco de dados. Dentro do namespace `Repository`, adicione uma pasta com o nome `Context`, em seguida adicione uma classe com o nome de `DataBaseContext`:




Agora é necessário declarar a classe `DataBaseContext` como uma subclasse de `System.Data.Entity.DbContext`:

``` C#
using Microsoft.EntityFrameworkCore;

using FiapSmartCityMVC.Models;
using FiapSmartCityMVC.Repository.Context;

namespace FiapSmartCityMVC.Repository.Context
{
  public class DataBaseContext : DbContext
  {
  }
}
```

Em seguida, vamos sobrescrever o método `OnConfiguring` classe para declarar qual a string de conexão a ser:

``` C#
using Microsoft.EntityFrameworkCore;

using FiapSmartCityMVC.Models;
using FiapSmartCityMVC.Repository.Context;

namespace FiapSmartCityMVC.Repository.Context
{
  public class DataBaseContext : DbContext
  {
    protected override void OnConfiguring(DbContextOptionsBuilder optionsBuilder)
    {
      if (!optionsBuilder.IsConfigured)
      {
        var config = new ConfigurationBuilder().SetBasePath(Directory.GetCurrentDirectory()).AddJsonFile("appsettings.json").Build();
        optionsBuilder.UseSqlServer(config.GetConnectionString("FiapSmartCityConnection"));
      }
    }
  }
}
```

No método `OnModelCreating`, vamos fazer duas configurações no EF e na conexão de dado:

``` C#
using Microsoft.EntityFrameworkCore;

using FiapSmartCityMVC.Models;
using FiapSmartCityMVC.Repository.Context;

namespace FiapSmartCityMVC.Repository.Context
{
  public class DataBaseContext : DbContext
  {
    protected override void OnConfiguring(DbContextOptionsBuilder optionsBuilder)
    {
      if (!optionsBuilder.IsConfigured)
      {
        var config = new ConfigurationBuilder().SetBasePath(Directory.GetCurrentDirectory()).AddJsonFile("appsettings.json").Build();
        optionsBuilder.UseSqlServer(config.GetConnectionString("FiapSmartCityConnection"));
      }
    }

    protected override void OnModelCreating(ModelBuilder modelBuilder)
    {

    }
  }
}
```

### DbSet

Vimos anteriormente a classe de contexto e algumas configurações particulares para nosso exemplo. Mas ainda precisamos incluir alguns itens na classe de contexto (**DataBaseContext**) para seguirmos com os mapeamos entre tabela e classes.

O item a ser incluído na classe de contexto é o objeto `DbSet`, que tem a `responsabilidade de representar uma entidade e permitir a manipulação com as operações de criação, leitura, gravação e exclusão`. 

Na classe `DataBaseContext`, é necessário declarar uma propriedade do tipo de DbSet para representar a entidade de ProductType:

``` C#
using Microsoft.EntityFrameworkCore;

using FiapSmartCityMVC.Models;
using FiapSmartCityMVC.Repository.Context;

namespace FiapSmartCityMVC.Repository.Context
{
  public class DataBaseContext : DbContext
  {

    public DbSet<ProductTypeEF> ProductTypeEF { get; set; }

    protected override void OnConfiguring(DbContextOptionsBuilder optionsBuilder)
    {
      if (!optionsBuilder.IsConfigured)
      {
        var config = new ConfigurationBuilder().SetBasePath(Directory.GetCurrentDirectory()).AddJsonFile("appsettings.json").Build();
        optionsBuilder.UseSqlServer(config.GetConnectionString("FiapSmartCityConnection"));
      }
    }

    protected override void OnModelCreating(ModelBuilder modelBuilder)
    {

    }
  }
}
```

### Models e anotações

Entity frameworkPágina 10{}}}Código-fonte 4.3–Criando o DbSet para Tipo ProdutoFonte: Elaborado pelo autor (2018)4.2.3 Models e anotaçõesAgora é preciso deixar nosso modelo vinculado à nossa tabela. Para isso, vamos usar algumas anotações  disponíveis  nos namespaces System.ComponentModel.DataAnnotationse System.ComponentModel.DataAnnotations.Schema. São três (3) as anotações principais, a primeira é [Table], usada para classe; a segunda é [Key], que identifica a chave primária, e a terceira é [Column], para associar a propriedade da classe com a coluna da tabela.

O código apresenta a classe TipoProdutocom as anotações para o funcionamento do EF. Segue:



### Outras anotações

O EntityFrameworkdisponibiliza outras anotações além das relatadas na seção anterior. É possível determinar tamanho de campos, definir uma chave estrangeira, determinar que o campo é requerido, dizer que um atributo não será mapeado com nenhuma coluna do banco de dados etc. Segue a lista dos mais utilizados:MaxLength MinLengthStringLengthNotMapped ForeingKeyInverseProperty

### Operações

Temos implementado nossa classe de contexto, junto com a propriedade DbSet, nosso modelo está com as anotações necessárias, assim, temos o conjunto de Contexto, DbSete Modelpreparados para executar operações no banco de dados com os recursos do Entity Framework

Precisamos implementar as operações, porém precisamos entender um pouco do ciclo de vida de uma entidade no EF, desse modo ficará mais fácil entender as operações. Temos cinco (5) estados para uma entidade no EF, são eles:Detached –a entidade (model) não está vinculada ao contexto, ou seja, não será persistida, alterada ou removida do banco de dados.Unchanged –a entidade está vinculada ao contexto, porém não sofreu nenhuma alteração. Toda consulta retornada do banco de dados tem por estado padrão o Unchanged.Added –indica que a entidade foi marcada para ser adicionada no banco de dados pelo contexto.Modified –a entidade teve alguma informação alterada, nesse caso o contexto precisa atuar para persistir a entidade no banco de dados.Deleted –indica que a entidade foi marcada para ser removida pelo contexto.A figura “Estado das entidadesdo EF”apresenta os estados e as possíveis transições:



Entendido o estado de cada entidade, vamos às operações. No projeto FiapSmartCity,temos o componente da camada de acesso a dados (TipoProdutoRepository) com cinco (5) métodos que correspondem a comando SQL no banco de dados. Um a um, vamos converter o código desses métodos para o uso dos recursos do EF. A versão atual utiliza recursos da biblioteca ADO.NET e possui comandosSQL descritos dentro de cada um deles. Com o EF, os comandos SQL serão removidos, a quantidade de linhas será reduzida e os comandos, simplificados.

