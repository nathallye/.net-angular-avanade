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
	TYPEID          INT identity(1,1)   PRIMARY KEY,
	TYPEDESCRIPTION VARCHAR(250)        NOT NULL,
	MARKETED        CHAR(1)
);
```

Tudo pronto para a implementação!

## Implementação EF Core

### Classe de Contexto

Para que nossa aplicação possa utilizar as facilidades do framework EF Core, precisamos criar a classe de contexto, ou classe de acesso à base. A `classe de contexto` será uma subclasse de **System.Data.Entity.DbContext**, que tem a responsabilidade de interação com os objetos e com o banco de dados. Dentro do namespace `Repository`, adicione uma pasta com o nome `Context`, em seguida adicione uma classe com o nome de `DataBaseContext`:

<div align="center">
  <img width="700" src="https://user-images.githubusercontent.com/86172286/204895549-c15e0386-6ef1-4fee-8adf-4ddb54d3787e.png">
</div>

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

Agora é preciso deixar nosso modelo vinculado à nossa tabela. Para isso, vamos usar algumas anotações disponíveis nos namespaces `System.ComponentModel.DataAnnotations` e `System.ComponentModel.DataAnnotations.Schema`. São três (3) as anotações principais, a primeira é `[Table]`, usada para classe; a segunda é `[Key]`, que identifica a chave primária, e a terceira é `[Column]`, para associar a propriedade da classe com a coluna da tabela:

``` C#
using System;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;

namespace FiapSmartCityMVC.Models
{
  [Table("PRODUCTTYPEEF")]
  public class ProductTypeEF
  {
    [Key]
    [DatabaseGenerated(DatabaseGeneratedOption.Identity)]

    [Column("TYPEID")]
    public int TypeId { get; set; }

    [Column("TYPEDESCRIPTION")]
    [Required(ErrorMessage = "Descrição obrigatória!")]
      [StringLength(50,
        MinimumLength = 3,
        ErrorMessage = "A descrição deve ter, no mínimo 3 e, no máximo, 50 caracteres.")]
    [Display(Name = "Descrição:")]
    public string TypeDescription { get; set; }

    [Column("MARKETED")]
    [Display(Name = "Comercializado: ")]
    public bool Marketed { get; set; }
  }
}
```

### Outras anotações

O Entity Framework disponibiliza outras anotações além das relatadas na seção anterior. É possível determinar tamanho de campos, definir uma chave estrangeira, determinar que o campo é requerido, dizer que um atributo não será mapeado com nenhuma coluna do banco de dados etc. Segue a lista dos mais utilizados:

- MaxLength;
- MinLength;
- StringLength;
- NotMapped;
- ForeingKey;
- InverseProperty.

### Operações

Temos implementado nossa classe de contexto, junto com a propriedade `DbSet`, nosso modelo está com as anotações necessárias, assim, temos o conjunto de Contexto, `DbSet` e `Model` preparados para executar operações no banco de dados com os recursos do Entity Framework.

Precisamos implementar as operações, porém precisamos entender um pouco do ciclo de vida de uma entidade no EF, desse modo ficará mais fácil entender as operações. 

Temos cinco (5) estados para uma entidade no EF, são eles:

- **Detached** – a entidade (model) não está vinculada ao contexto, ou seja, não será persistida, alterada ou removida do banco de dados.
- **Unchanged** – a entidade está vinculada ao contexto, porém não sofreu nenhuma alteração. Toda consulta retornada do banco de dados tem por estado padrão o Unchanged.
- **Added** – indica que a entidade foi marcada para ser adicionada no banco de dados pelo contexto.
- **Modified** – a entidade teve alguma informação alterada, nesse caso o contexto precisa atuar para persistir a entidade no banco de dados.
- **Deleted** – indica que a entidade foi marcada para ser removida pelo contexto. 

Entendido o estado de cada entidade, vamos às operações. No projeto FiapSmartCityMVC, temos o componente da camada de acesso a dados (ProductTypeRepository) com cinco (5) métodos que correspondem a comando SQL no banco de dados. 

Um a um, vamos converter o código desses métodos para o uso dos recursos do EF. A versão atual utiliza recursos da biblioteca ADO.NET e possui comandos SQL descritos dentro de cada um deles. Com o EF, os comandos SQL serão removidos, a quantidade de linhas será reduzida e os comandos, simplificados.

### Add

O bloco abaixo apresenta o método para a inserção de dados utilizando as propriedades do EF. Note a forma de uso, que inclui a criação da classe de contexto, adicionado os valores pelo objeto modelo com uso do método Add, e por fim, o método que efetiva a gravação dos dados:

``` C#
using System.Data.SqlClient;
using System.Data;

using FiapSmartCityMVC.Models;
using FiapSmartCityMVC.Repository.Context;

namespace FiapSmartCityMVC.Repository
{
  public class ProductTypeRepositoryEF
  {
    private readonly DataBaseContext context;

    public ProductTypeRepositoryEF()
    {
      // Criando um instância da classe de contexto do EntityFramework
      context = new DataBaseContext();
    }
    
    public void Create(ProductTypeEF productType)
    {
      // Adiciona o objeto preenchido pelo usuário
      context.ProductTypeEF.Add(productType);
      // Salva as alterações no banco
      context.SaveChanges();
    }
  }
}
```

### Modified – Update

Segue o exemplo para remoção de um objeto da base de dados. Essa operação necessita alterar o estado do registro para modified e depois efetivar a transação:

``` C#
using System.Data.SqlClient;
using System.Data;

using FiapSmartCityMVC.Models;
using FiapSmartCityMVC.Repository.Context;

namespace FiapSmartCityMVC.Repository
{
  public class ProductTypeRepositoryEF
  {
    private readonly DataBaseContext context;

    public ProductTypeRepositoryEF()
    {
      // Criando um instância da classe de contexto do EntityFramework
      context = new DataBaseContext();
    }
    
    public void Create(ProductTypeEF productType)
    {
      // Adiciona o objeto preenchido pelo usuário
      context.ProductTypeEF.Add(productType);
      // Salva as alterações no banco
      context.SaveChanges();
    }

    public void Update(ProductTypeEF productType)
    {
      // Informa o contexto que um objeto foi alterado
      context.ProductTypeEF.Update(productType);
      // Salva as alterações no banco
      context.SaveChanges();
    }
  }
}
```

### Delete

Seguindo a linha do Update, a forma de exclusão altera o estado do objeto e efetiva a alteração, porém, antes de tentar efetuar a exclusão, será necessário criar uma instância da classe model e associar o Id de exclusão:

``` C#
using System.Data.SqlClient;
using System.Data;

using FiapSmartCityMVC.Models;
using FiapSmartCityMVC.Repository.Context;

namespace FiapSmartCityMVC.Repository
{
  public class ProductTypeRepositoryEF
  {
    private readonly DataBaseContext context;

    public ProductTypeRepositoryEF()
    {
      // Criando um instância da classe de contexto do EntityFramework
      context = new DataBaseContext();
    }
    
    public void Create(ProductTypeEF productType)
    {
      // Adiciona o objeto preenchido pelo usuário
      context.ProductTypeEF.Add(productType);
      // Salva as alterações no banco
      context.SaveChanges();
    }

    public void Update(ProductTypeEF productType)
    {
      // Informa o contexto que um objeto foi alterado
      context.ProductTypeEF.Update(productType);
      // Salva as alterações no banco
      context.SaveChanges();
    }

    public void Delete(int id)
    {
      // Criar um tipo produto apenas com o Id
      var productType = new ProductTypeEF()
      {
          TypeId = id
      };

      context.ProductTypeEF.Remove(productType);
      context.SaveChanges();
    }
  }
}
```

### Find

O método Findserá o responsável por recuperar os dados de um registro, consultando por meio de um Id:

``` C#
using System.Data.SqlClient;
using System.Data;

using FiapSmartCityMVC.Models;
using FiapSmartCityMVC.Repository.Context;

namespace FiapSmartCityMVC.Repository
{
  public class ProductTypeRepositoryEF
  {
    private readonly DataBaseContext context;

    public ProductTypeRepositoryEF()
    {
      // Criando um instância da classe de contexto do EntityFramework
      context = new DataBaseContext();
    }

    public ProductTypeEF Read(int id)
    {
      // Recuperando o objeto TipoProduto de um determinado Id
      return context.ProductTypeEF.Find(id);
    }
    
    public void Create(ProductTypeEF productType)
    {
      // Adiciona o objeto preenchido pelo usuário
      context.ProductTypeEF.Add(productType);
      // Salva as alterações no banco
      context.SaveChanges();
    }

    public void Update(ProductTypeEF productType)
    {
      // Informa o contexto que um objeto foi alterado
      context.ProductTypeEF.Update(productType);
      // Salva as alterações no banco
      context.SaveChanges();
    }

    public void Delete(int id)
    {
      // Criar um tipo produto apenas com o Id
      var productType = new ProductTypeEF()
      {
          TypeId = id
      };

      context.ProductTypeEF.Remove(productType);
      context.SaveChanges();
    }
  }
}
```

### List

Recupera todos os registros de tipos de produto, o famoso `SELECT * ` será substituído por um simples método do EF. O método de listagem requisita a importação do namespace **System.Linq**:

``` C#
using System.Data.SqlClient;
using System.Data;

using FiapSmartCityMVC.Models;
using FiapSmartCityMVC.Repository.Context;

namespace FiapSmartCityMVC.Repository
{
  public class ProductTypeRepositoryEF
  {
    private readonly DataBaseContext context;

    public ProductTypeRepositoryEF()
    {
      // Criando um instância da classe de contexto do EntityFramework
      context = new DataBaseContext();
    }

    public IList<ProductTypeEF> GetAll()
    {
      // Retorna a lista de tipos de produtos
      return context.ProductTypeEF.ToList();
    }

    public ProductTypeEF Read(int id)
    {
      // Recuperando o objeto TipoProduto de um determinado Id
      return context.ProductTypeEF.Find(id);
    }
    
    public void Create(ProductTypeEF productType)
    {
      // Adiciona o objeto preenchido pelo usuário
      context.ProductTypeEF.Add(productType);
      // Salva as alterações no banco
      context.SaveChanges();
    }

    public void Update(ProductTypeEF productType)
    {
      // Informa o contexto que um objeto foi alterado
      context.ProductTypeEF.Update(productType);
      // Salva as alterações no banco
      context.SaveChanges();
    }

    public void Delete(int id)
    {
      // Criar um tipo produto apenas com o Id
      var productType = new ProductTypeEF()
      {
          TypeId = id
      };

      context.ProductTypeEF.Remove(productType);
      context.SaveChanges();
    }
  }
}
```

## Operações Avançadas

Até essa seção, foram apresentados os recursos básicos do Entity Framework, recursos esses que possibilitam executar as operações de CRUD em uma aplicação com banco de dados. 

As operações de `Insert`, `Update` e `Delete` não possuem forma avançada, pois sempre são executadas em um registro. `Já as operações de consulta podem possuir formas complexas para o retorno de dados`, por exemplo, o tratamento de relacionamento, ligações entre dois ou mais dados do sistema e filtro de informações.

### LINQ

LINQ é o acrônimo de Language Integrated Query, foi adicionado ao .NET framework versão 3.5 (ano de 2008) nas linguagens C# e VB.Net com o objetivo de efetuar consulta em diversas fontes de dados com uma sintaxe unificada, teve sua inspiração na linguagem SQL. É formada por um conjunto de métodos chamados operadores de consulta, tipos anônimos e expressões lambda. Abaixo, segue uma lista de possíveis exemplos de uso:

- Filtrar informações em vetores.
- Filtrar informações em lista do tipo `IEnumerable<T>`.
- Consultar dados em arquivos XML.
- Gerenciar dados relacionais com objetos.
- Consulta de objetos do tipo `DataSet`.

### OrderBy

O primeiro exemplo apresentado será para `ordenar pela descrição os tipos de produto do site FiapSmartCityMVC`. Será usado um `Extension Method OrderBy` e uma expressão lambda para definir qual atributo será usado para ordenar:

``` C#
using System.Data.SqlClient;
using System.Data;

using FiapSmartCityMVC.Models;
using FiapSmartCityMVC.Repository.Context;

namespace FiapSmartCityMVC.Repository
{
  public class ProductTypeRepositoryEF
  {
    private readonly DataBaseContext context;

    public ProductTypeRepositoryEF()
    {
      // Criando um instância da classe de contexto do EntityFramework
      context = new DataBaseContext();
    }

    public IList<ProductTypeEF> ListOrderedByName() // Listar Ordenado Por Nome
    {
      var list =
        context.ProductTypeEF.OrderBy(t => t.TypeDescription).ToList<ProductTypeEF>();

      return list;
    }
  }
}
```

### Where

Vamos usar novamente `Extension Method OrderBy` e uma expressão lambda, mas o objetivo agora é filtrar informações da lista. A sugestão para esse exemplo é exibir na lista apenas os tipos que são comercializados:

``` C#
using System.Data.SqlClient;
using System.Data;

using FiapSmartCityMVC.Models;
using FiapSmartCityMVC.Repository.Context;

namespace FiapSmartCityMVC.Repository
{
  public class ProductTypeRepositoryEF
  {
    private readonly DataBaseContext context;

    public ProductTypeRepositoryEF()
    {
      // Criando um instância da classe de contexto do EntityFramework
      context = new DataBaseContext();
    }

    public IList<ProductTypeEF> ListOrderedByName() // Listar Ordenado Por Nome
    {
      var list =
        context.ProductTypeEF.OrderBy(t => t.TypeDescription).ToList<ProductTypeEF>();

      return list;
    }

    public IList<ProductTypeEF> ListMarketedTypes() // Listar Tipos Comercializados
    {
      // Filtro com Where
      var list =
        context.ProductTypeEF.Where(t => t.Marketed == false)
          .OrderByDescending(t => t.TypeDescription).ToList<ProductTypeEF>();

      return list;
    }
  }
}
```

No próximo exemplo, o método recebe como parâmetro o valor do filtro para o campo comercializado:

``` C#
using System.Data.SqlClient;
using System.Data;

using FiapSmartCityMVC.Models;
using FiapSmartCityMVC.Repository.Context;

namespace FiapSmartCityMVC.Repository
{
  public class ProductTypeRepositoryEF
  {
    private readonly DataBaseContext context;

    public ProductTypeRepositoryEF()
    {
      // Criando um instância da classe de contexto do EntityFramework
      context = new DataBaseContext();
    }

    public IList<ProductTypeEF> ListOrderedByName() // Listar Ordenado Por Nome
    {
      var list =
        context.ProductTypeEF.OrderBy(t => t.TypeDescription).ToList<ProductTypeEF>();

      return list;
    }

    public IList<ProductTypeEF> ListMarketedTypes() // Listar Tipos Comercializados
    {
      // Filtro com Where
      var list =
        context.ProductTypeEF.Where(t => t.Marketed == false)
          .OrderByDescending(t => t.TypeDescription).ToList<ProductTypeEF>();

      return list;
    }

    public IList<ProductTypeEF> ListTypesSoldCriterion(bool selection) // Listar Tipos Comercializados Critério
    {
      // Filtro com Where
      var list =
        context.ProductTypeEF.Where(t => t.Marketed == selection)
          .OrderByDescending(t => t.TypeDescription).ToList<ProductTypeEF>();

      return list;
    }
  }
}
```

Outro exemplo de Where, uma consulta com dois campos como filtro:

``` C#
using System.Data.SqlClient;
using System.Data;

using FiapSmartCityMVC.Models;
using FiapSmartCityMVC.Repository.Context;

namespace FiapSmartCityMVC.Repository
{
  public class ProductTypeRepositoryEF
  {
    private readonly DataBaseContext context;

    public ProductTypeRepositoryEF()
    {
      // Criando um instância da classe de contexto do EntityFramework
      context = new DataBaseContext();
    }

    public IList<ProductTypeEF> ListOrderedByName() // Listar Ordenado Por Nome
    {
      var list =
        context.ProductTypeEF.OrderBy(t => t.TypeDescription).ToList<ProductTypeEF>();

      return list;
    }

    public IList<ProductTypeEF> ListMarketedTypes() // Listar Tipos Comercializados
    {
      // Filtro com Where
      var list =
        context.ProductTypeEF.Where(t => t.Marketed == false)
          .OrderByDescending(t => t.TypeDescription).ToList<ProductTypeEF>();

      return list;
    }

    public IList<ProductTypeEF> ListTypesSoldCriterion(bool selection) // Listar Tipos Comercializados Critério
    {
      // Filtro com Where
      var list =
        context.ProductTypeEF.Where(t => t.Marketed == selection)
          .OrderByDescending(t => t.TypeDescription).ToList<ProductTypeEF>();

      return list;
    }

    public IList<ProductTypeEF> ListMarketedTypes() // Listar Tipos Comercializados
    {
      // Filtro com Where
      var list =
        context.ProductTypeEF.Where(t => t.Marketed == false)
          .OrderByDescending(t => t.TypeDescription).ToList<ProductTypeEF>();

      return list;
    }
  }
}
```

### Contains

Veja o exemplo de filtro por parte da descrição do tipo de produto:

``` C#
using System.Data.SqlClient;
using System.Data;

using FiapSmartCityMVC.Models;
using FiapSmartCityMVC.Repository.Context;

namespace FiapSmartCityMVC.Repository
{
  public class ProductTypeRepositoryEF
  {
    private readonly DataBaseContext context;

    public ProductTypeRepositoryEF()
    {
      // Criando um instância da classe de contexto do EntityFramework
      context = new DataBaseContext();
    }

    public IList<ProductTypeEF> ListOrderedByName() // Listar Ordenado Por Nome
    {
      var list =
        context.ProductTypeEF.OrderBy(t => t.TypeDescription).ToList<ProductTypeEF>();

      return list;
    }

    public IList<ProductTypeEF> ListMarketedTypes() // Listar Tipos Comercializados
    {
      // Filtro com Where
      var list =
        context.ProductTypeEF.Where(t => t.Marketed == false)
          .OrderByDescending(t => t.TypeDescription).ToList<ProductTypeEF>();

      return list;
    }

    public IList<ProductTypeEF> ListTypesSoldCriterion(bool selection) // Listar Tipos Comercializados Critério
    {
      // Filtro com Where
      var list =
        context.ProductTypeEF.Where(t => t.Marketed == selection)
          .OrderByDescending(t => t.TypeDescription).ToList<ProductTypeEF>();

      return list;
    }

    public IList<ProductTypeEF> ListMarketedTypes() // Listar Tipos Comercializados
    {
      // Filtro com Where
      var list =
        context.ProductTypeEF.Where(t => t.Marketed == false)
          .OrderByDescending(t => t.TypeDescription).ToList<ProductTypeEF>();

      return list;
    }

    public IList<ProductTypeEF> ListTypesPartDescription(string partDescription) // Listar Tipos Parte Descrição
    {
      // Filtro com Where e Contains
      var list =
        context.ProductTypeEF.Where(t => t.TypeDescription.Contains(partDescription))
          .ToList<ProductTypeEF>();

      return list;
    }
  }
}
```

## Relacionamentos

Chegamos ao ponto de avançarmos nossas pesquisas fazendo ligações entre duas informações relacionadas. Até aqui trabalhamos apenas com uma entidade que foi a `ProductTypeEF`, assim, para seguirmos, será necessária a criação de uma nova entidade. 

A nova entidade receberá o nome de `ProductEF` e será associada ao `ProductTypeEF`, `pois cada produto deve ser qualificado com um tipo`. O diagrama abaixo apresenta essa ligação:

<div align="center">
  <img width="700" src="https://user-images.githubusercontent.com/86172286/205099831-4f28a300-fdf0-45a8-a977-680110bfa28f.png">
</div>

Como estamos usando a estratégia de **Database First**, é necessária a criação da tabela no banco de dados. O código abaixo apresenta o script SQL para criação da tabela e a chave estrangeira para a tabela de tipo de produto:

``` SQL
use FiapSmartCityMVC;

CREATE TABLE PRODUCTEF (
  PRODUCTID				     INT identity(1,1)    PRIMARY KEY,
  PRODUCTNAME			     VARCHAR(70)          NOT NULL,
  FEATURES				     VARCHAR(100)         NOT NULL,
  AVERAGEPRICE			   money,
  LOGOTIPO      		   VARCHAR(200)         NOT NULL,
  ACTIVE  				     INT,
  TYPEID				       INT,
  CONSTRAINT FK_TYPEID FOREIGN KEY (TYPEID) REFERENCES PRODUCTTYPEEF(TYPEID)
);
```

Tabela criada, precisamos anotar nosso modelo e criar o `DbSet` para a manipulação. As anotações usadas são as mesmas do exemplo anterior: `[Table]`, `[Key]` e `[Column]`, mas a classe de modelo terá duas particularidades, são elas:

- **(Foreing Key)** – Atributo que representa a chave estrangeira, será mapeado como uma coluna.
- **(Navigation Property)** – Atributo que representa o modelo da tabela relacionada, e não receberá nenhuma anotação.

A seguir temos a versão final da classe de modelo `ProductEF`:

``` C#
using FiapSmartCityMVC.Models;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;

namespace FiapSmartCityMVC.Models
{
  [Table("PRODUCTEF")]
  public class ProductEF
  {
    [Key]
    [Column("PRODUCTID")]
    public int ProductId { get; set; }

    [Column("PRODUCTNAME")]
    public string ProductName { get; set; }

    [Column("FEATURES")]
    public string Features { get; set; } // Características

    [Column("AVERAGEPRIVE")]
    public double AveragePrice { get; set; } // preço médio

    [Column("LOGOTIPO")]
    public string Logotipo { get; set; }

    [Column("ACTIVE")]
    public bool Active { get; set; } // ativos

    // Foreing Key
    [Column("TYPEID")]
    // Referência para classe TipoProduto/ProductType
    public int TypeId { get; set; }
  }
}
```

Em nossa classe de contexto **(DataBaseContext)** é preciso adicionar a propriedade `DbSet` para o modelo produto:

``` C#
public DbSet<ProductEF> ProductEF { get; set; }
```

### Relacionamento umpara um

O relacionamento um para um será o primeiro demonstrado como exemplo. O objetivo será buscar um produto em nossa base e, em seu retorno, trazer os dados do tipo a que está associado (Id e descrição). Como estamos falando do domínio “Produto”, para organizar nossa aplicação vamos adicionar uma nova classe no **namespace Repository**, o nome será `ProductRepositoryEF` e a partir dela vamos adicionar os métodos para buscas avançadas. 

A busca do produto será feita pelo método a partir de dois **Extension Methods**. O primeiro é o método `Include`, que recebe como parâmetro o nome da `Navigation Property` declarado no modelo. O segundo é o método `FirstOrDefault`, responsável por filtrar o produto com o identificador desejado:

``` C#
public Produto Read(int id)
{
	var prod = context.ProductEF.Include(t => t.Type)
		.FirstOrDefault(p => p.ProductId == id);
	return prod;
}
```

Veja na figura a ligação entre as entidades com o método `Include`, o nome passado como parâmetro para o método é o nome do atributo definido para ser a Navigation Property:

<div align="center">
  <img width="700" src="https://user-images.githubusercontent.com/86172286/204895026-325f1b9b-c3b1-419e-b1b6-00d5db0a362b.png">
</div>

Para validar a consulta, pode ser feita uma chamada do método **BuscarPorId** e com a opção **QuickWatch** do Debug é possível verificar o conteúdo do objeto Produto retornado na consulta:

<div align="center">
  <img width="700" src="https://user-images.githubusercontent.com/86172286/204895106-b438d7b3-54c6-4b12-b4a4-57470494e499.png">
</div>

### Relacionamento um para muitos

Para representar esse relacionamento, vamos fazer o processo inverso, assim, dado um tipo de produto, vamos recuperar todos os produtos associados. O código para executar essa operação é semelhante ao anterior, ou seja, devemos usar o método `Include` para recuperar a lista produto. 

Porém, antes de implementar o código para recuperar as informações, faz-se necessário criar uma *Navigation Property* na classe `ProductTypeEF` que será uma lista de elementos `ProductEF`:

``` C#
using FiapSmartCityMVC.Models;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;

namespace FiapSmartCityMVC.Models
{
  [Table("PRODUCTEF")]
  public class ProductEF
  {
    [Key]
    [Column("PRODUCTID")]
    public int ProductId { get; set; }

    [Column("PRODUCTNAME")]
    public string ProductName { get; set; }

    [Column("FEATURES")]
    public string Features { get; set; } // Características

    [Column("AVERAGEPRIVE")]
    public double AveragePrice { get; set; } // preço médio

    [Column("LOGOTIPO")]
    public string Logotipo { get; set; }

    [Column("ACTIVE")]
    public bool Active { get; set; } // ativos

    // Foreing Key
    [Column("TYPEID")]
    // Referência para classe TipoProduto/ProductType
    public int TypeId { get; set; }

    // Navigation Property
    public ProductType Tipo { get; set; 
  }
}
```

Agora podemos implementar nossa consulta. Vamos declarar o método ListarProdutosPorTipo na classe ProdutoRepository, que fará uma consulta a uma entidade tipo de produto, com o método Include devemos adicionar a entidade de produto para conseguir operar o relacionamento entre os elementos.Segue a implementação do método:

``` C#
public IList<ProductEF> BrowseProductsByType(int typeId) // ConsultarProdutosPorTipo
{
	// Consulta a lista de produtos de um determinado tipo.
	var productType =
		context.ProductType
			.Include(t => t.Products)
			.FirstOrDefault(t => t.TypeId == typeId);

	return productType.Products;
}
```

A abaixo podemos visualizar a janela **QuickWatch** da execução do método **BrowseProductsByType** com o conteúdo da lista produtos preenchidos:

<div align="center">
  <img width="700" src="https://user-images.githubusercontent.com/86172286/204895224-c406f7f9-0c0d-47e1-8bf8-712e09668911.png">
</div>
