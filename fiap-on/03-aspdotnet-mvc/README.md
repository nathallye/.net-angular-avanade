# ASP.NET MVC

## Introdução

Neste módulo, serão apresentados o conceito do padrão arquitetural MVC (Model-View-Controller) e o framework ASP.NET Core MVC 2, responsável pela implementação do padrão arquitetural em projetos Microsoft .NET.

## Padrão MVC

MVC é um padrão arquitetural que divide uma aplicação em três camadas de componentes: modelo, visão e controlador. Usado por muitos desenvolvedores com a intenção de estruturar melhor o código de grandes aplicativose determinar a responsabilidade de cada grupo de componente, o framework MVC é utilizado em aplicativos desktop, mobile e web.

<div align="center">
  <img width="700" src="https://user-images.githubusercontent.com/86172286/204312165-d608bd1e-b4ef-42a6-879f-ca5efe6546c3.png">
</div>

A lista a seguir traz com detalhes a responsabilidade de cada componente:

- **Modelo (Model)** – É o componente do aplicativo responsável pela lógica do negócio e pelo modelo de dados. Será responsável por validar, recuperar e armazenar o estado das informações em uma base de dados. O modelo também é usado para notificar sua Visão (view) para resposta atualizada ao usuário do aplicativo.

- **Visão (View)** – Componente de interface com o usuário, tem a responsabilidade de exibir dados atualizados dos modelos. Pode usar tabelas para a exibição de grandes conteúdos ou listas, ou formulários para a digitação de dados que serão armazenados na base de dados.

- **Controlador (Controller)** – É o responsável pelo fluxo da aplicação e gerencia as interações dos usuários, definindo quais modelos devem ser acionados e selecionando qual visão (view) será apresentada para o usuário.

O framework.NET também oferece outro padrão para desenvolvimento de aplicação web,chamado *WebForms*. Esse padrão também é conhecido como tradicional e tem um conceito de postback, que não adota os conceitos do framework MVC.

A estrutura MVC tem como principais características a separação de conceitos, tornando cada componente responsável por um assunto, e a reutilização de código. Com o uso do padrão MVC, podemos extrair algumas vantagens do desenvolvimento de uma aplicação, tais como:

- Facilidade de desenvolvimento de testes. 
- Facilidade de gerenciamento da complexidade, devido à separação das camadas. Esse fator também ajuda na integração de grandes equipes de desenvolvedores.
- Ter controle completo do comportamento do aplicativo. O modelo **WebForms** utiliza o estado da informação armazenado na página e controlado pelo servidor (ViewState).
- Processamento centralizado das solicitações em um único controlador.

## Criando projeto ASP.NET Core MVC2

Para iniciar a criação de um novo aplicativo, precisamos entender o modelo de negócio que será implementado, quais são seus domínios, quais informações serão armazenadas e manipuladas e quais funcionalidades serão construídas para os usuários alimentarem nosso negócio.

Assim, vamos usar como exemplo para este capítulo um modelo de negócio da cidade **Fiap City**. Cidade “virtual” que pretende usar intensivamente a tecnologia para criar melhores condições de sustentabilidade para a população. 

O projeto de Internet da **Fiap City** consiste na divulgação de produtos para a pintura de imóveis que não acumulam resíduos, facilitando a limpeza e reduzindo o uso de água. O portal de Internet a ser construído terá como contexto as apresentações dos produtos (tintas), notícias, captaçãode moradores interessados no uso das tintas e investidores interessados em patrocinar a cidade.No portal, teremos dois tipos de usuários/atores. O primeiro tipo são os administradores, com o papel de gerenciar a manutenção das informações de produtos e notícias e consultar moradores e investidores. O segundo tipo são os moradores ou empresas, que poderão consultar informações dos produtos e efetuar um cadastro como interessados em uso ou parceria. O foco destematerial será a parte administrativa.

Vamos criar nosso projeto?

No Visual Studio 2022, selecione o `Create a new project` > em seguida vamos selecionar o tipo de projeto `ASP.NET Core Web Application (Model-View-Controller)`. Na parte inferior, temos caixas de texto para definir o nome do projeto, o local no sistema de arquivos e o nome da solução. Para nosso exemplo, vamos usar `FiapSmartCity` como nome do projeto e da solução. Feito isso, vamos em `Next` e vamos selecionar a versão do `.NET` que iremos usar neste projeto, para concluir vamos clicar em `Create`.

Criado o projeto, conseguimos verificar sua estrutura. Na janela `Solutions Explorer`,temos nossa solução, novo projeto Web, e na estrutura do projeto foram criadasas pastas `Controllers`, `Models` e `Views`:

<div align="center">
  <img width="700" src="https://user-images.githubusercontent.com/86172286/204311207-7e7ee638-ff23-4f23-bf86-9053ca32c37e.png">
</div>

### Modelos

Com o nosso projeto criado, precisamos iniciar o entendimento dos componentes do MVC e a implementação do nosso conceito de negócio. Não existe uma regra para a ordem de criação dos componentes. Algumas equipes iniciam a construção pela camada de modelos, pois possuem uma modelagem de banco de dados pré-estabelecida. Outras iniciam pela visão e controladores, pois, assim,conseguem criar um protótipo e validar o fluxo da aplicação. Para nossa primeira implementação, vamos iniciar pela camada de modelo, na qual vamos representar nosso modelo de negócio para os **tipos de produto**. Inicialmente, teremos apenas 1 (um) tipo de produto (tinta), mas,no futuro, podemos diversificar para outros itens das cidades inteligentes, como: filtros de água, captadores de energia solar etc:

<div align="center">
  <img width="700" src="https://user-images.githubusercontent.com/86172286/204312410-e0cbe8f6-f5be-4b40-95e5-58fd2ef28d32.png">
</div>

Os componentes da camada de modelo são simples classes C#, que devem ser adicionadas no `namespace Models do projeto`. Para criar o modelo `TipoProduto/ProductType`, clique com o `botão direito na pasta Models e escolha a opção Add` > `Class`. Defina o nome como `ProductType.cs`, utilize o Diagrama de Classe – Produto e Categoria e adicione os atributos `IdTipo/IDType`, `DescricaoTipo/DescriptionType` e `Comercializado/Marketed`, com seus respectivos tipos:

``` C#
using System;
    
  namespace FiapSmartCity.Models
  {
    public class ProductType
    {
      public int TypeId { get; set; }
      public string TypeDescription { get; set; }
      public bool Marketed { get; set; }
    }
  }
```

Seguindo os passos anteriores e o diagrama de Classe – Produto e Categoria, vamos criar a classe para o modelo de `Produto/Product`. O diagrama apresenta uma agregação entre `Produto/Product` e `TipoProduto/ProductType`, sendo, assim, na classe de Produto, precisamos ter uma propriedade `TipoProduto/ProductType`:

``` C#
using System;
    
  namespace FiapSmartCity.Models
  {
    public class Product
    {
      public int ProductId { get; set; }
      public string ProductName { get; set; }
      public string Features { get; set; } // Características
      public double AveragePrice { get; set; } // preço médio
      public string Logotipo { get; set; }
      public bool Active { get; set; } // ativos

      // Referência para classe TipoProduto/ProductType
      public ProductType Type { get; set; }
    }
  }
```

## Implementando ASP.NET CoreMVC 2

### Funcionalidades

Já temos dois modelos/models definidos e criados em nosso projeto, precisamos agora criar os mecanismos para deixar disponível a manipulação pelos usuários. Vamos iniciar com nosso modelo `ProductType`, que, para poder ser manipulado, deverá possuir os seguintes comportamentos ou funcionalidades:•

- Criação de um novo tipo.
- Remoção de um tipo existente.
- Alteração da descrição ou de comercialização.
- Listagem dos tipos já existentes no sistema.

#### Controllers e Actions

Em um projeto ASP.NET Core MVC 2, `toda solicitação do usuário feita pelo navegador será recebida e gerenciada por um Controller`, ficando este `responsável por receber o pedido, acionar os componentes necessários e gerar a resposta para o navegador`. Podemos criar um Controller para cada funcionalidade da nossa aplicação (por exemplo: `CriarTipoProduto/CreateProductType`, `ExcluirTipoProduto/DeleteProductType`, `AlterarTipoProduto/UpdateProductType` e `ListaTipos/ListTypes`), essa abordagem funciona, mas `não é recomendada`. Para organizar melhor nossas funcionalidades, temos os conceitos das `Actions`. As `ações (Actions) nada mais são do que métodos adicionados na classe de controle com o objetivo de organizar e padronizar ainda mais nosso código`. Com o uso das Actions, devemos criar um controlador para cada domínio e ações para cada funcionalidade (por exemplo: `ControllerTipoProduto/ControllerProductType`, Actions `Criar/Create`, `Excluir/Delete`, `Alterar/Update` e `Listar/List`).

Todo `Controller` necessita de uma `Action`, caso não seja criada, nada será executado. Além da pasta Controller (namespace), a criação de Controllers e Actions deve seguir algumas particularidades:

- O nome da classe do controlador deverá ter o sufixo Controller no nome (por exemplo: TipoProdutoControlller).- Os métodos que representam as ações devem ser declarados como públicos.
- Os métodos Actions não podem ser declarados como static. 
- Os métodos Actions só podem ser sobrecarregados (overloading) com uso de Anotações (Attributes).
- O mapeamento-padrão adota o nome de `Index` para a Action inicial de um Controller. 
- O retorno mais comum de uma Action é um componente View em HTML implementado pela classe ActionResult. 
- É possível criar uma Action sem resposta.
- Uma Action tem o mapeamento um-para-um, ou seja, deve ser implementada para executar apenas uma ação.

As Actions podem ser implementadas com algumas responsabilidades diferentes, como de apresentar uma View ao usuário, por exemplo, ações que serão responsáveis por retornar um arquivo para download. 
Abaixo, segue a especificação dos vários tipos de retorno de uma Action, os quais são implementados pela classe `ActionResult`:

<div align="center">
  <img width="700" src="https://user-images.githubusercontent.com/86172286/204358454-9c15cc15-9b3e-45f0-8a7f-0014ff69ab89.png">
</div>

#### Implementando Controllers

Clique com o botão direito do mouse na pasta Controllers do projeto e selecione a opção `Add` > `Controller`, o Visual Studio apresentará a janela `Add Scaffold`. Selecione a opção `MVC Controller – Empty`:

<div align="center">
  <img width="700" src="https://user-images.githubusercontent.com/86172286/204358688-fd7bab1e-6040-4182-acf9-f4d9b8254e05.png">
</div>

<div align="center">
  <img width="700" src="https://user-images.githubusercontent.com/86172286/204358720-298bd7e0-c187-49ab-a59d-4ddf4334dc56.png">
</div>

O próximo passo é definir o nome do controlador, que  será `TipoProdutoController/ProductTypeController` em nosso projeto. Clique no botão `Add` e aguarde a criação. Lembre-se, todo Controller deverá ter o sufixo Controller em seu nome:

<div align="center">
  <img width="700" src="https://user-images.githubusercontent.com/86172286/204359004-e5f03782-1009-4609-96ee-0117696a9a3e.png">
</div>

Agora podemos observar a classe criada no namespace Controllers; no código da classe Controller, é possível ver a importação do namespace **Microsoft.AspNetCore.Mvc** e a extensão da classe **Microsoft.AspNetCore.Mvc.Controller**. Como padrão da criação de todo Controller, a `action Index` foi adicionada na classe, por meio do método de mesmo nome, e o retorno é um objeto do tipo `ActionResult`:

<div align="center">
  <img width="700" src="https://user-images.githubusercontent.com/86172286/204359050-33455d16-cff9-484a-8737-906ae947bf3f.png">
</div>

Controller criado, agora podemos fazer o primeiro teste. Pressione a tecla F5 e aguarde o navegador-padrão do seu computador ser aberto. Com o navegador aberto, complemente o endereço com o `localhost:7120/ProductType` e pressione enter. O navegador irá exibir uma tela de erro informando que nenhuma View com o nome de Index foi encontrada. Apesar de apresentar uma mensagem de erro, significa que nosso teste foi bem-sucedido, pois, afinal, não criamos a View.

#### Associando uma View e Controller

Anteriormente, criamos e testamos nosso Controller, porém a validação da execução foi feita por meio da tela de erro, informando que não existe uma `View` para ser exibida. Então, vamos criar a primeira View e validar a execução do nosso Controller. A View será uma página HTML com uma mensagem de texto informando o nome do Controller e da Action. 

Com o Controller `ProductTypeController` aberto na janela de edição, clique com o botão direto sobre o nome da Action Index e selecione a opção `Add View` (uma janela com detalhes da viewserá apresentada). Mantenha o nome de `Index` e o template como `Empty`. No rodapé da janela, remova a opção `Use a layout page` e para finalizar clique no botão `Add`:

<div align="center">
  <img width="700" src="https://user-images.githubusercontent.com/86172286/204360980-8150adc5-eb88-4ad3-b5b8-5c7357f014c5.png">
</div>

Com a View concluída, verifique na janela `Solution Explorers` e na pasta `Views` foram adicionados uma subpasta `ProductType` e um arquivo `Index.cshtml` (arquivo da View):

<div align="center">
  <img width="700" src="https://user-images.githubusercontent.com/86172286/204361085-5c69b609-f5be-4a6e-8c25-13c86adf70ad.png">
</div>

Nosso próximo passo é editar o arquivo `Index.cshtml` e, no bloco `<body>`, adicionar uma mensagem com o nome do Controller e a Action à qual a View pertence:

``` HTML
@{
  Layout = null;
}

<!DOCTYPE html>
<html>
<head>
  <meta name="viewport" content="width=device-width" />
  <title>Index</title>
</head>
<body>
  <div>
    Executando Controller <b>ProductType</b> e a Action <b>Index</b>
  </div>
</body>
</html>
```

Arquivo editado, voltamos a testar nosso Controller. Pressione F5, aguarde o navegador ser carregado, informe o `localhost:7120/Product/Index` ou apenas `localhost:7120/ProductType` e tecle Enter. Assim nosso Controller será executado novamente e a `ViewIndex` que acabamos de construir será retornada para o navegador:

<div align="center">
  <img width="700" src="https://user-images.githubusercontent.com/86172286/204361172-03bb8817-3fd2-4d9a-b381-75d60206a063.png">
</div>

#### Método de retorno – View()

O Controller e a Action criados até este ponto retornam para a requisição a visão do mesmo nome da ação por meio método View(). O `método View()` apresenta algumas sobrecargas, as quais permitem passagem de parâmetros para informar resultados diferentes, como outra View. Podemos alterar a View-padrão,passando uma string como parâmetro, ou informar um objeto que será usado para a renderização da View. A figura abaixo lista todas as sobrecargas permitidas para o retorno do método `View()`:

<div align="center">
  <img width="700" src="https://user-images.githubusercontent.com/86172286/204361341-9977613c-f33d-4b49-ae43-950214238785.png">
</div>

### Rotas e navegação

#### Convenções

O framework ASP.NET Core MVC 2 usa uma simples `convenção para associar Actions dos Controllers às Views`. Para o nosso exemplo, o Controller `ProductTypeController`, foi criada uma subpasta com o nome `TypeProduct` dentro da pasta `Views`, e para o Action `Index` foi criado o arquivo `Index.cshtml`. 

A convenção de nomes e estrutura das pastas é associar as Views aos Controllers. Essas convenções são simples e fáceis. Seguindo a padronização de nomes, já temos boa parte do trabalho reduzido e delegado para o framework. Tiramos a responsabilidade de o nosso código definir essas associações e deixamos com o framework. Com isso, ficam claras a facilidade e a simplicidade de seseguir as recomendações de uso das nomenclaturas e estruturas criadas e sugeridas pelo ASP.NET Core MVC2.

#### Rotas da URL

Analisando a URL da aplicação `http://localhost:7120/ProductType/Index`, o primeiro bloco apresenta o protocolo, nome do servidor e a porta de comunicação; o segundo bloco representa: 

- **ProductType** – Controller responsável por gerenciar a execução. 
- **Index** – Action que atenderá à requisição. 

A composição entre Controller e Action é conhecidacomo `Rota` e todo projeto ASP.NET Core MVC 2 possui uma classe C# responsável por essa configuração. Na janela da Solution Explorer, navegue até a classe `Startup.cs` e abra o código do método `Configure`. A Figura a seguir, exibe o conteúdo da classe `Startup.cs`:

<div align="center">
  <img width="700" src="https://user-images.githubusercontent.com/86172286/204406673-ab4f90bc-2e21-472e-94ac-591b9fc20a01.png">
</div>

**Obs.:** A nova versão do .NET unificou `Startup.cs` e `Program.cs` em um único arquivo: `Program.cs`.

O bloco de código do método `Configure` é o responsável por interceptar todas as chamadas do aplicativo, analisar o caminho da URL requisitada e mapear para o Controller e a Action correspondentes. Podemos notar que no código da implementação `routes.MapRoute()` da Figura.  Temos  um  padrão  na propriedade url `{controller}/{action}/{id}` definindo que os caminhos deverão ser compostos pelo nome do controle, ação e id (valores opcionais). 

Ainda no `MapRoute`, temos uma definição **default**, que define quais `Controller` e `Action` deverão ser executados; caso nenhuma informação seja informada na url, o padrão é o Controller chamado Home e a Action Index. 

Podemos alterar o controlador-padrão de Home para `ProductType` e executar o aplicativo novamente, assim será possível acessar nossa funcionalidade usando apenas a url<http://localhost:7120/>. 

Embora essas configurações possam ser alteradas, é recomendado manter o padrão. Assim, vamos manter o ControllerHome como padrão. Para não deixar nossa aplicação sem uma apresentação inicial, vamos executar os passos dos capítulos anteriores e criar um novo Controller (`HomeController`) e uma View (`Index.cshtml`). Na View, devemos escrever uma mensagem para identificar que estamos navegando pela homepage:

``` C#
using FiapSmartCityMVC.Models;
using Microsoft.AspNetCore.Mvc;
using System.Diagnostics;

namespace FiapSmartCityMVC.Controllers
{
  public class HomeController : Controller
  {
    private readonly ILogger<HomeController> _logger;

    public HomeController(ILogger<HomeController> logger)
    {
      _logger = logger;
    }

    public IActionResult Index()
    {
      return View();
    }

    public IActionResult Privacy()
    {
      return View();
    }

    [ResponseCache(Duration = 0, Location = ResponseCacheLocation.None, NoStore = true)]
    public IActionResult Error()
    {
      return View(new ErrorViewModel { RequestId = Activity.Current?.Id ?? HttpContext.TraceIdentifier });
    }
  }
}
```

``` HTML
@{
  Layout = null;
}

<!DOCTYPE html>
<html>
<head>
  <meta name="viewport" content="width=device-width" />
  <title>Index</title>
</head>
<body>
  <div>
    <h1>Nossa home-page.</h1>
  </div>
</body>
</html>
```

**Obs.:** A versão atual do .NET já trás isso configurado por default.

Vamos executar novamente o aplicativo, podemos notar que a nossa `homepage` será apresentada como página inicial. Vamos acessar os endereços abaixo no navegador e verificar que todos vão exibir a mesma visão (homepage):

- http://localhost:6588/
- http://localhost:6588/Home
- http://localhost:6588/Home/Index

#### Views

Até este ponto, vimos que as Views no framework ASP.NET Core MVC 2 são arquivos `.cshtml` com base em HTML e que, por convenção,são salvas na pasta `Views` e na subpasta com o `nome do Controller associado`.Apenas com o uso de HTML sabemos que não é possível ter dinamismo para manipular e persistir informações em nossa base de dados. Para isso, o ASP.NET Core MVC2 possui o mecanismo de `view engine`, que usa a linguagem `C# com a marcação Razor`. Podemos fazer uma relação com JSP da linguagem Java e a Expression Language(EL) que facilita os famosos `scriptlets`.

#### ASP.NET Razor

O Razor é um dos mecanismos do ASP.NET Core MVC 2 responsáveis por construir nossas `Views dinâmicas`;antes de seu lançamento, o mecanismo-padrãoer a o ASPX, que usava como base scriptlets ASP.NET puro. Ainda disponível para a criação de projetos MVC, não é recomendado pelo framework.

Em 2011, integrado com a versão do ASP.NET MVC 3, foi lançado o view engine Razor com o objetivo de simplificar a codificação na camada View. O Razor trouxe alguns benefícios significativos para os desenvolvedores, segue uma lista deles:

- Usa a linguagem C# como base deseus scriptlets.
- Apresenta sintaxe limpa, reduzindo o código.
- Simplifica o acesso aos componentes Model.
- Permite escrever testes unitários apenas para a camada Views.
- Uso do autocomplete (IntelliSense) para completar sintaxe de código no Visual Studio.
- Facilita o uso de layouts predefinidos para todo o site.

Para identificar uma expressão Razor em um arquivo `.cshtml`, basta observar blocos de código iniciados pelo caractere `@`:

``` HTML
@{
  Layout = null;
}

<!DOCTYPE html>
<html>
<head>
  <meta name="viewport" content="width=device-width" />
  <title>Homepage</title>
</head>
<body>
  <div>
    <h1>Nossa home-page.</h1>
  </div>

  @{
    for (int i = 0; i < 10; i++)
    {
      <p>@i</p>
    }
  }
</body>
</html>
```

#### Tags Helpers

O framework ASP.NET Core MVC 2 disponibiliza os componentes auxiliadores para o desenvolvimento dos componentes Views. Os Auxiliadores de Marcação fazem com que o código do lado do servidor participe da criação e renderização de elementos HTML. O `ImageTagHelper` interno pode acrescentar um número de versão ao nome da imagem, assim, `sempre que a imagem é alterada, o servidor gera uma nova versão` exclusiva para a imagem, de modo que os clientes tenham a garantia de obter a imagem atual. Existem auxiliadores para todos os elementos HTML comuns (por exemplo: formulários, links, imagens, botões e outros). Abaixo temos o quadro “Tags Helpers”, com os Tag Helpers disponíves no ASP.NET Core MVC 2:

<div align="center">
  <img width="700" src="https://user-images.githubusercontent.com/86172286/204406913-a1b416c0-4763-4677-a0f5-0ce4568116a6.png">
</div>

Para demonstração, a Figura Exemplo de uso de HtmlHelpers, apresenta a sintaxe para a criação de uma caixa de texto usando o helper fortemente tipado e o código HTML gerado depois que oview engine renderiza o código da View:

<div align="center">
  <img width="700" src="https://user-images.githubusercontent.com/86172286/204406959-1adbd529-9c80-4507-82b3-2b368289178c.png">
</div>

#### Listando dados na tela (View)

No bloco anterior, fomos apresentados ao view engine Razor e aos helpers para criar componentes HTML, além de conhecermos os conceitos de rotas, Controllers e convenções. Agora precisamos colocar em prática e implementar nosso projeto. O nosso Controller `ProductType` possui apenas uma simples ação para exemplificar o funcionamento da associação `Controller` > `Action` > `View`. É preciso adicionar os comportamentos: `cadastro`, `alteração`, `exclusão` e `consulta` (**CRUD**).

Para não perdermos tempo criando e configurando nosso banco de dados, vamos partir para uma estratégia de simulação, também conhecida como Mock. Essa estratégia simula os comandos de integração com as tabelas da base de dados. Dessa forma, será possível testar os componentes do MVC e o fluxo de navegação a fim de, posteriormente, criar apenas o código de integração como banco de dados. 

A ideia desta seção é criar uma listagem de dados para os tipos de produtos da `FiapSmartCity`. Para cada informação listada, será necessário criar uma ação que será implementada posteriormente para consultar, editar, excluir, e uma opção para criar um novo tipo. Vamos usar a Action e a View já criadas e adicionar nosso código.

Na Action Index do `ProductTypeController`, vamos criar um atributo do tipo lista e adicionar três objetos do modelo `ProductType`. Nesse momento, vamos simular que temos os seguintes produtos: Tinta, Filtro de água e Captador de energia. No método de retorno, vamos passar como parâmetro o atributo lista:

``` C#
using Microsoft.AspNetCore.Mvc;
using System.Reflection;
using FiapSmartCityMVC.Models;

namespace FiapSmartCityMVC.Controllers
{
  public class ProductTypeController : Controller
  {
    public IActionResult Index()
    {
      // Criando o atributo da lista
      IList<Models.ProductType> listType = new List<ProductType>();

      // Adicionando na lista o TipoProduto da Tinta
      listType.Add(new ProductType()
      {
        TypeId = 1,
        TypeDescription = "Tinta",
        Marketed = true
      });

      listType.Add(new ProductType()
      {
        TypeId = 2,
        TypeDescription = "Filtro de água",
        Marketed = true
      });

      listType.Add(new ProductType()
      {
        TypeId = 3,
        TypeDescription = "Captador de energia",
        Marketed = false
      });

      // Retornando para View a lista de Tipos
      return View(listType);
    }
  }
}
```

Com a lista de tipos de produtos criada de forma simulada e retornada para a View, agora precisamos implementar o mecanismo de exibição e a criação das futuras ações. O objetivo para o componente View é criar uma tabela que apresenta a lista dos dados. Para cada item da lista, serão criados três (3) hiperlinks (Editar, Excluir e Consultar) e, por fim, um (1) hiperlink para cadastrar um novo tipo.

A codificação para as tags **Razor** da nossa implementação deverá compreender: a declaração `@model` para definir o tipo do objeto modelo, um bloco `@foreach` para listar os elementos da lista e as declarações `asp-controller`, `asp-action` e `asp-route-id` para os hiperlinks de edição, exclusão, cadastro e consulta. Nosso objeto modelo é uma lista, com isso, devemos especificar na declaração `@modelo` tipo `IEnumerable`:

``` HTML
@model IEnumerable<FiapSmartCityMVC.Models.ProductType>

@{
    Layout = null;
}

<!DOCTYPE html>
<html>
<head>
  <meta name="viewport" content="width=device-width" />
  <title>Tipo de Produto</title>
</head>
<body>
  <h1>Tipo de Produto</h1>
  <p>
    <!-- uso de TagHelpers para definir o Controller e a Action -->
    <a asp-controller="ProductType" asp-action="Create">Novo Tipo</a>
  </p>
  <table class="table" border="1">
    <tr>
      <th>Id</th>
      <th>Descrição</th>
      <th></th>
    </tr>

    @foreach (var item in Model)
    {
      <tr>
        <td>
          <label>@item.TypeId</label>
        </td>
        <td>
          <label>@item.TypeDescription</label>
        </td>
        <td>
          <!-- asp-route-id é usado para informar o Id do Item selecionado. -->
          <a asp-controller="ProductType"
            asp-action="Update"
            asp-route-id="@item.TypeId">Editar</a>

          <a asp-controller="ProductType"
            asp-action="Read"
            asp-route-id="@item.TypeId">Consultar</a>

          <a asp-controller="ProductType"
            asp-action="Delete"
            asp-route-id="@item.TypeId">Excluir</a>
        </td>
      </tr>
    }
  </table>
</body>
</html>
```

Vamos executar a aplicação. Pressione a tecla F5 e, no navegador, informe o caminho `localhost:7120/ProductType`. Depois, aguarde o carregamento da lista de tipos de produtos:

<div align="center">
  <img width="700" src="https://user-images.githubusercontent.com/86172286/204412888-059a1e1b-6156-4e35-a1aa-b0d1ca5b861f.png">
</div>

#### Inserindo dados (View e Controller)

Avançando na implementação do nosso projeto, precisamos criar os elementos do framework MVC que permitem ao usuário preencher os dados de tipo de produto e simular a gravação na base de dados.

Ainda no mesmo Controller, vamos adicionar dois novos métodos (Actions). Os dois métodos vão receber o nome `Cadastrar/Create`. Pode parecer estranho, mas vamos adotar o mesmo nome para testar a forma particular de sobrecarga de métodos em Controllers. 

Tendo os dois métodos com o mesmo nome, a diferenciação será feita de duas formas: a primeira é com o uso de uma anotação que define qual o verbo HTTP (Get ou Post) que a Action irá aceitar em execução. A segunda forma é por meio de um parâmetro, um dos métodos receberá como model `TypeProduct`:

<div align="center">
  <img width="700" src="https://user-images.githubusercontent.com/86172286/204417471-53c9646c-495b-4293-922f-215e911d0f0a.png">
</div>

Para usar as anotações que indicam qual o verbo HTTP é usado no método, é necessário declarar acima da implementação do método, com as seguintes expressões: `[HttpGet]`, `[HttpPost]`. A simulação de gravação dos dados no banco de dados será feita pelo comando `Debug.Print()` do namespace `System.Diagnostics`:

``` C#
using Microsoft.AspNetCore.Mvc;
using System.Reflection;
using FiapSmartCityMVC.Models;
using System.Diagnostics;

namespace FiapSmartCityMVC.Controllers
{
  public class ProductTypeController : Controller
  {
    public IActionResult Index()
    {
      // Criando o atributo da lista
      IList<Models.ProductType> listType = new List<ProductType>();

      // Adicionando na lista o TipoProduto da Tinta
      listType.Add(new ProductType()
      {
        TypeId = 1,
        TypeDescription = "Tinta",
        Marketed = true
      });

      listType.Add(new ProductType()
      {
        TypeId = 2,
        TypeDescription = "Filtro de água",
        Marketed = true
      });

      listType.Add(new ProductType()
      {
        TypeId = 3,
        TypeDescription = "Captador de energia",
        Marketed = false
      });

      // Retornando para View a lista de Tipos
      return View(listType);
    }

    // Anotação de uso do Verb HTTP Get
    [HttpGet]
    public IActionResult Create()
    {
      // Imprime a mensagem de execução
      Debug.Print("Executou a Action Register()");

      // Retorna para a View Cadastrar um 
      // objeto modelo com as propriedades em branco 
      return View(new ProductType ());
    }

    // Anotação de uso do Verb HTTP Post
    [HttpPost]
    public IActionResult Create(ProductType productType)
    {
      // Imprime os valores do modelo
      // Debug.Print do System.Diagnostics
      Debug.Print("Descrição: " + productType.TypeDescription);
      Debug.Print("Comercializado: " + productType.Marketed);

      // Simila que os dados foram gravados.
      Debug.Print("Gravando o Tipo de Produto");

      // Substituímos o return View()
      // pelo método de redirecionamento
      return RedirectToAction("Index", "ProductType");
    }
  }
}
```

Implementado o nosso Controller, o próximo passo é criar uma View para fornecer um formulário e elementos para a digitação dos dados. Seguindo as convenções do framework, a View terá o mesmo nome da Action `Cadastrar/Create`. Deverá fazer uso dos tag helpers `asp-controller` e `asp-action` para a criação do formulário, além dos elementos HTML puros para posicionamento e formatação da tela.

Resultado da View `Cadastrar/Register`:

``` HTML
@model FiapSmartCityMVC.Models.ProductType;

@{
    Layout = null;
}

<!DOCTYPE html>

<html>
<head>
  <meta name="viewport" content="width=device-width" />
  <title>Tipo de Produto - Cadastrar</title>
</head>
<body>
  <h1>Tipo de Produto - Cadastrar</h1>

  <!-- formulário HTML com Tag Helpers-->
  <form asp-action="Create" asp-controller="ProductType" method="post">
    <div class="form-horizontal">
      <hr />

      <div class="form-group">
        <label>Descrição</label>
        <div class="col-md-10">
          <!-- Caixa de Texto -->
          <input asp-for="TypeDescription" />
        </div>
      </div>

      <div class="form-group">
        <label>Comercializado</label>
        <div class="checkbox">
          <!-- CheckBox -->
          <input asp-for="Marketed" />
        </div>
      </div>

      <div class="form-group">
        <div class="col-md-offset-2 col-md-10">
          <input type="reset" value="Limpar" class="btn btn-default" />
          <!-- HTML Simple para envio dos dados do formulário -->
          <input type="submit" value="Cadastrar" class="btn btn-default" />
        </div>
      </div>
      <hr />
    </div>
  </form>

  <div>
    <a asp-controller="ProductType" asp-action="Index">Voltar</a>
  </div>

</body>
</html>
```

Podemos usar duas estratégias para validar na implementação. Uma delas é adicionando `breakpoints` nos trechos de código do Controller e, com a tela `F10`, `percorrer linha a linha` para acompanhar a execução. E a outra forma é observar pela `janela Output` do Visual Studio as `mensagens que são impressas pelo comando System.Diagnostics.Debug.Print()`:

<div align="center">
  <img width="700" src="https://user-images.githubusercontent.com/86172286/204417551-77c9e6fa-0491-4231-90f3-289d82aaf63e.png">
</div>

Execute a aplicação e acesse a lista de tipos. No link “Novo Tipo”, simule um cadastro de tipo, use breakpoints ou a janela Output para acompanhar os dados digitados. Lembre-se, como estamos usando trechos de código para simulação, os dados da lista não serão alterados.

#### Editando dados (View e Controller)

O fluxo de edição possui algumas semelhanças com o de cadastro. Podemos nos basear no código criado na seção anterior e, com poucas alterações, será possível implementar a edição do tipo de produto. 

Seguemos métodos que devem ser criados para a edição:

<div align="center">
  <img width="700" src="https://user-images.githubusercontent.com/86172286/204420043-a247c8e4-29a6-401d-8c59-ca0a31ab1e32.png">
</div>

Implementação da Action de `Update` do controller `TypeProductController`:

``` C#
using Microsoft.AspNetCore.Mvc;
using System.Reflection;
using FiapSmartCityMVC.Models;
using System.Diagnostics;

namespace FiapSmartCityMVC.Controllers
{
  public class ProductTypeController : Controller
  {
    // ACTION INDEX
    public IActionResult Index()
    {
      // Criando o atributo da lista
      IList<Models.ProductType> listType = new List<ProductType>();

      // Adicionando na lista o TipoProduto da Tinta
      listType.Add(new ProductType()
      {
        TypeId = 1,
        TypeDescription = "Tinta",
        Marketed = true
      });

      listType.Add(new ProductType()
      {
        TypeId = 2,
        TypeDescription = "Filtro de água",
        Marketed = true
      });

      listType.Add(new ProductType()
      {
        TypeId = 3,
        TypeDescription = "Captador de energia",
        Marketed = false
      });

      // Retornando para View a lista de Tipos
      return View(listType);
    }

    // ACTION CREATE
    // Anotação de uso do Verb HTTP Get
    [HttpGet]
    public IActionResult Create()
    {
      // Imprime a mensagem de execução
      Debug.Print("Executou a Action Register()");

      // Retorna para a View Cadastrar um 
      // objeto modelo com as propriedades em branco 
      return View(new ProductType ());
    }

    // Anotação de uso do Verb HTTP Post
    [HttpPost]
    public IActionResult Create(ProductType productType)
    {
      // Imprime os valores do modelo
      // Debug.Print do System.Diagnostics
      Debug.Print("Descrição: " + productType.TypeDescription);
      Debug.Print("Comercializado: " + productType.Marketed);

      // Simila que os dados foram gravados.
      Debug.Print("Gravando o Tipo de Produto");

      // Substituímos o return View()
      // pelo método de redirecionamento
      return RedirectToAction("Index", "ProductType");
    }

    // ACTION UPDATE
    [HttpGet]
    public IActionResult Update(int Id)
    {
      // Imprime a mensagem de execução
      Debug.Print("Consultando o Tipo com Id = " + Id);

      // Cria o modelo que SIMULA a consulta no  banco de dados
      ProductType productType = new ProductType()
      {
        TypeId = Id,
        TypeDescription = "Tinta",
        Marketed = true
      };

      // Retorna para a View o objeto modelo 
      // com as propriedades preenchidas com dados do banco de dados 
      return View(productType);
    }

    [HttpPost]
    public IActionResult Update(ProductType productType)
    {
      // Imprime os valores do modelo
      System.Diagnostics.Debug.Print("Descrição: " + productType.TypeDescription);
      System.Diagnostics.Debug.Print("Comercializado: " + productType.Marketed);

      // Simila que os dados foram gravados.
      System.Diagnostics.Debug.Print("Gravando o Tipo Editado");

      // Substituímos o return View()
      // pelo método de redirecionamento
      return RedirectToAction("Index", "ProductType");
    }
  }
}
```

Para a View `Editar/Update`, podemos reaproveitar todo o código-fonte criado na View `Cadastrar/Create`. Com muito cuidado revise os caminhos usados para o post do formulário. Altere o título da página e adicione um componente do tipo hidden,que irá armazenar o Id do tipo. É preciso armazenar o Id do tipo de produto, pois, na execução do comando de atualização no banco de dados (Update), devemos informar a chave primária:

``` HTML
@model FiapSmartCityMVC.Models.ProductType;

@{
  Layout = null;
}

<!DOCTYPE html>

<html>
<head>
  <meta name="viewport" content="width=device-width" />
  <title>Tipo de Produto - Editar</title>
</head>
<body>
  <h1>Tipo de Produto - Editar</h1>

  <!-- formulário HTML com Tag Helpers-->
  <form asp-action="Update" asp-controller="ProductType" method="post">
    <input type="hidden" asp-for="TypeId" />

    <div class="form-horizontal">
      <hr />

      <div class="form-group">
        <label>Descrição</label>
        <div class="col-md-10">
          <!-- Caixa de Texto -->
          <input asp-for="TypeDescription" />
        </div>
      </div>

      <div class="form-group">
        <label>Comercializado</label>
        <div class="checkbox">
          <!-- CheckBox -->
          <input asp-for="Marketed" />
        </div>
      </div>

      <div class="form-group">
        <div class="col-md-offset-2 col-md-10">
          <input type="reset" value="Limpar" class="btn btn-default" />
          <!-- HTML Simple para envio dos dados do formulário -->
          <input type="submit" value="Gravar ALteração" class="btn btn-default" />
        </div>
      </div>
      <hr />
    </div>
  </form>

  <div>
    <a asp-controller="ProductType" asp-action="Index">Voltar</a>
  </div>

</body>
</html>
```

Execute a aplicação e acesse a lista de tipos. No link “Editar” de um tipo, simule a atualização de um tipo, use breakpoints ou a janela Output para acompanhar os dados digitados. Lembre-se, como estamos usando trechos de código para simulação, os dados da lista não serão alterados.

#### Consultando dados (View e Controller)

Para criar o fluxo de consulta de dados, podemos replicar parte do trabalho do fluxo de edição (update). No Controller,devemos usar apenas o método que utiliza o verbo HTTP Get, e, para a View, podemos remover a criação de formulário e substituir os elementos de edição (input) por simples labels. Segue o método para a consulta dos dados:

<div align="center">
  <img width="700" src="https://user-images.githubusercontent.com/86172286/204422370-d98afb18-c956-4542-82b9-40810ac97933.png">
</div>

Implementação da Action de `Read` do controler `TypeProductController`:

``` C#
using Microsoft.AspNetCore.Mvc;
using System.Reflection;
using FiapSmartCityMVC.Models;
using System.Diagnostics;

namespace FiapSmartCityMVC.Controllers
{
  public class ProductTypeController : Controller
  {
    // ACTION INDEX
    public IActionResult Index()
    {
      // Criando o atributo da lista
      IList<Models.ProductType> listType = new List<ProductType>();

      // Adicionando na lista o TipoProduto da Tinta
      listType.Add(new ProductType()
      {
        TypeId = 1,
        TypeDescription = "Tinta",
        Marketed = true
      });

      listType.Add(new ProductType()
      {
        TypeId = 2,
        TypeDescription = "Filtro de água",
        Marketed = true
      });

      listType.Add(new ProductType()
      {
        TypeId = 3,
        TypeDescription = "Captador de energia",
        Marketed = false
      });

      // Retornando para View a lista de Tipos
      return View(listType);
    }

    // ACTION CREATE
    // Anotação de uso do Verb HTTP Get
    [HttpGet]
    public IActionResult Create()
    {
      // Imprime a mensagem de execução
      Debug.Print("Executou a Action Register()");

      // Retorna para a View Cadastrar um 
      // objeto modelo com as propriedades em branco 
      return View(new ProductType ());
    }

    // Anotação de uso do Verb HTTP Post
    [HttpPost]
    public IActionResult Create(ProductType productType)
    {
      // Imprime os valores do modelo
      // Debug.Print do System.Diagnostics
      Debug.Print("Descrição: " + productType.TypeDescription);
      Debug.Print("Comercializado: " + productType.Marketed);

      // Simila que os dados foram gravados.
      Debug.Print("Gravando o Tipo de Produto");

      // Substituímos o return View()
      // pelo método de redirecionamento
      return RedirectToAction("Index", "ProductType");
    }

    // ACTION UPDATE
    [HttpGet]
    public IActionResult Update(int Id)
    {
      // Imprime a mensagem de execução
      Debug.Print("Consultando o Tipo com Id = " + Id);

      // Cria o modelo que SIMULA a consulta no  banco de dados
      ProductType productType = new ProductType()
      {
        TypeId = Id,
        TypeDescription = "Tinta",
        Marketed = true
      };

      // Retorna para a View o objeto modelo 
      // com as propriedades preenchidas com dados do banco de dados 
      return View(productType);
    }

    [HttpPost]
    public IActionResult Update(ProductType productType)
    {
      // Imprime os valores do modelo
      System.Diagnostics.Debug.Print("Descrição: " + productType.TypeDescription);
      System.Diagnostics.Debug.Print("Comercializado: " + productType.Marketed);

      // Simila que os dados foram gravados.
      System.Diagnostics.Debug.Print("Gravando o Tipo Editado");

      // Substituímos o return View()
      // pelo método de redirecionamento
      return RedirectToAction("Index", "ProductType");
    }

    // ACTION READ
    [HttpGet]
    public IActionResult Read(int Id)
    {
      // Imprime a mensagem de execução
      Debug.Print("Consultando o Tipo com Id = " + Id);

      // Cria o modelo que SIMULA a consulta no  banco de dados
      ProductType productType = new ProductType()
      {
        TypeId = Id,
        TypeDescription = "Tinta",
        Marketed = true
      };

      // Retorna para a View o objeto modelo 
      // com as propriedades preenchidas com dados do banco de dados 
      return View(productType);
    }
  }
}
```

Criando a View `Read`, reaproveitando o código da View `Update` para ter funcionalidade de apenas exibir os dados. Relembrando, devemos remover o bloco do form e substituir os elementos de input:

``` HTML
@model FiapSmartCityMVC.Models.ProductType;

@{
  Layout = null;
}

<!DOCTYPE html>
<html>
<head>
  <meta name="viewport" content="width=device-width" />
  <title>Tipo de Produto - Consultar</title>
</head>
<body>
  <h1>Tipo de Produto - Consultar</h1>
  <div class="form-horizontal">
    <hr />

    <div class="form-group">
      <label><b>Descrição:</b></label>
      <div class="col-md-10">
        <span>@Model.TypeDescription</span>
      </div>
    </div>

    <div class="form-group">
      <label><b>Comercializado:</b></label>
      <div class="checkbox">
        <span>@Model.Marketed</span>
      </div>
    </div>
    <hr />
  </div>
  <div>
    <a asp-controller="ProductType" asp-action="Index">Voltar</a>
  </div>

</body>
</html>
```

#### Removendo dados (View e Controller)

Diferentemente dos demais fluxos, a remoção será feita apenas por uma Action, não utilizaremos View. Segue o método para a consulta dos dados: 

<div align="center">
  <img width="700" src="https://user-images.githubusercontent.com/86172286/204423172-97802f4a-1f5a-421a-8160-47d1815e4523.png">
</div>

Implementação da Action `Delete` do controller `TypeProductController`:

``` C#
using Microsoft.AspNetCore.Mvc;
using System.Reflection;
using FiapSmartCityMVC.Models;
using System.Diagnostics;

namespace FiapSmartCityMVC.Controllers
{
  public class ProductTypeController : Controller
  {
    // ACTION INDEX
    public IActionResult Index()
    {
      // Criando o atributo da lista
      IList<Models.ProductType> listType = new List<ProductType>();

      // Adicionando na lista o TipoProduto da Tinta
      listType.Add(new ProductType()
      {
        TypeId = 1,
        TypeDescription = "Tinta",
        Marketed = true
      });

      listType.Add(new ProductType()
      {
        TypeId = 2,
        TypeDescription = "Filtro de água",
        Marketed = true
      });

      listType.Add(new ProductType()
      {
        TypeId = 3,
        TypeDescription = "Captador de energia",
        Marketed = false
      });

      // Retornando para View a lista de Tipos
      return View(listType);
    }

    // ACTION CREATE
    // Anotação de uso do Verb HTTP Get
    [HttpGet]
    public IActionResult Create()
    {
      // Imprime a mensagem de execução
      Debug.Print("Executou a Action Register()");

      // Retorna para a View Cadastrar um 
      // objeto modelo com as propriedades em branco 
      return View(new ProductType ());
    }

    // Anotação de uso do Verb HTTP Post
    [HttpPost]
    public IActionResult Create(ProductType productType)
    {
      // Imprime os valores do modelo
      // Debug.Print do System.Diagnostics
      Debug.Print("Descrição: " + productType.TypeDescription);
      Debug.Print("Comercializado: " + productType.Marketed);

      // Simila que os dados foram gravados.
      Debug.Print("Gravando o Tipo de Produto");

      // Substituímos o return View()
      // pelo método de redirecionamento
      return RedirectToAction("Index", "ProductType");
    }

    // ACTION UPDATE
    [HttpGet]
    public IActionResult Update(int Id)
    {
      // Imprime a mensagem de execução
      Debug.Print("Consultando o Tipo com Id = " + Id);

      // Cria o modelo que SIMULA a consulta no  banco de dados
      ProductType productType = new ProductType()
      {
        TypeId = Id,
        TypeDescription = "Tinta",
        Marketed = true
      };

      // Retorna para a View o objeto modelo 
      // com as propriedades preenchidas com dados do banco de dados 
      return View(productType);
    }

    [HttpPost]
    public IActionResult Update(ProductType productType)
    {
      // Imprime os valores do modelo
      System.Diagnostics.Debug.Print("Descrição: " + productType.TypeDescription);
      System.Diagnostics.Debug.Print("Comercializado: " + productType.Marketed);

      // Simila que os dados foram gravados.
      System.Diagnostics.Debug.Print("Gravando o Tipo Editado");

      // Substituímos o return View()
      // pelo método de redirecionamento
      return RedirectToAction("Index", "ProductType");
    }

    // ACTION READ
    [HttpGet]
    public IActionResult Read(int Id)
    {
      // Imprime a mensagem de execução
      Debug.Print("Consultando o Tipo com Id = " + Id);

      // Cria o modelo que SIMULA a consulta no  banco de dados
      ProductType productType = new ProductType()
      {
        TypeId = Id,
        TypeDescription = "Tinta",
        Marketed = true
      };

      // Retorna para a View o objeto modelo 
      // com as propriedades preenchidas com dados do banco de dados 
      return View(productType);
    }

    // ACTION DELETE
    [HttpGet]
    public IActionResult Delete(int Id)
    {
      // Imprime a mensagem de execução
      Debug.Print("Excluir o Tipo com Id = " + Id);

      // Substituímos o return View()
      // pelo método de redirecionamento
      return RedirectToAction("Index", "TypeProduct");
    }
  }
}
```

Execute a aplicação e acompanhe as mensagens na janela Output a fim devalidar todo o fluxo das operações.

### Layout pages e identidade visual

Apesar de criar componentes View, não implementamos recursos visuais mais profissionais, usamos a estratégia de manter o funcionamento apenas. Passaremos a incrementar nossa camada visual, dando um tom mais profissional com componentes do framework ASP.NET Core MVC 2 para facilitar a evolução do aplicativo. Para isso, vamos usar a biblioteca Bootstrap, pois,além de ser uma biblioteca bemdifundida,foi utilizada em módulos anteriores.

#### Instalando Bootstrap

A primeira alteração em nosso projeto será a instalação da biblioteca Bootstrap, utilizando a ferramenta `Nuget` disponível no Visual Studio. 

O Nuget é um `gerenciador de pacotes` da tecnologia .NET com o qual possível usar pacotes de bibliotecas externas ou construir bibliotecas para ser usadas por outros desenvolvedores. O Nuget possui um repositório central que armazena todos os pacotes, os quais podem ser utilizados por qualquer desenvolvedor da plataforma .NET. Para mais informações, consulte: `https://www.nuget.org/`.

A versão ASP.NET Core MVC já disponibiliza o Bootstrap na criação no projeto, assim não é necessário realizar a instalação. É possível encontrar as pastas e os arquivos da biblioteca na pasta `wwwroot`,disponível na `Solution Explorer` do Visual Studio:

<div align="center">
  <img width="700" src="https://user-images.githubusercontent.com/86172286/204567714-65f53ea6-e0ea-4deb-8c8d-f05404eae86d.png">
</div>

#### Criando Layouts

O uso do Bootstrap obriga todas as páginas HTML do site a importar as referências para os arquivos da biblioteca (.css e .js). Com o uso dos recursos de Layouts, vamos centralizar as importações em um único ponto do projeto. E mais, todos os websites possuem padrões e áreas comuns em todas as páginas, como: cabeçalho, logotipo, menu, rodapé e outros que a criatividade permitir. Os recursos de Layouts do MVC permitem criar uma única vez os padrões e a partes comuns e usar por todo o projeto sem muito esforço de código. 

Como estamos trabalhando com nossa camada de visualização, devemos trabalhar bastante no `namespace Views` do projeto. `Por convenção, nossos layouts devem ficar em uma subpasta chamada Shared, dentro da pasta Views`. 

Na pasta Shared, vamos abrir o arquivo `_Layout.cshtml`, limpar e adaptar o código HTML para o nosso projeto:

<div align="center">
  <img width="700" src="https://user-images.githubusercontent.com/86172286/204567922-540410b5-eb13-4593-9e5a-b8dcfbdcdb8c.png">
</div>

É possível notar que o arquivo de layout tem seu `conteúdo muito similar` a um `HTML` ou uma `View .cshtml` e também possui algumas `tags Razor` declaradas inicialmente. 

Iremos falar sobre as tags `@ViewBag` e `@RenderBody` logo mais, antes precisamos inserir as tags HTML para o uso do Bootstrap. No corpo da tag `<head>`, é necessário incluir a tag `<link>` com referência ao arquivo `.css` do Bootstrap. É possível fazer isso usando a tag HTML pura, mas, para explorar os recursos do framework, vamos usar o recurso do símbolo `~`, que permite que você transforme caminhos de arquivos relativos para caminhos semi-absolutos, ou seja, não importa o endereço em que sua View é exibida, a tag apontará para o caminho correto dos arquivos de estilo, javascript e imagem:

``` HTML
<head>
  <meta charset="utf-8" />
  <meta name="viewport" content="width=device-width, initial-scale=1.0" />
  <title>FiapSmartCityMVC</title>

  <!-- importando bootstrap e o css do nosso site-->
  <link rel="stylesheet" href="~/lib/bootstrap/dist/css/bootstrap.css" />
  <link rel="stylesheet" href="~/css/site.css" />
</head>
```

Finalizada a importação do arquivo de estilo, é preciso importar os arquivos de script; para isso é adotada a composição da tag HTML `<script>` e novamente a o recurso do símbolo `~`:

``` HTML
<head>
  <meta charset="utf-8" />
  <meta name="viewport" content="width=device-width, initial-scale=1.0" />
  <title>FiapSmartCityMVC</title>

  <!-- importando bootstrap e o css do nosso site-->
  <link rel="stylesheet" href="~/lib/bootstrap/dist/css/bootstrap.css" />
  <link rel="stylesheet" href="~/css/site.css" />
</head>

<body>
  <!-- importando as libs JavaScript -->
  <script src="~/lib/jquery/dist/jquery.js"></script>
  <script src="~/lib/bootstrap/dist/js/bootstrap.bundle.js"></script>
  <script src="~/js/site.js" asp-append-version="true"></script>
</body>
```

Para incrementar um pouco mais nosso aplicativo, vamos adicionar uma seção de cabeçalho e rodapé. O cabeçalho será composto por um menu de opção com links para as funcionalidades Tipo de Produto(ProductType) e Produto(Product) - implementado futuramente - o rodapé terá uma seção de contato da **FiapSmartCity**. Esse conteúdo será inserido dentro da tag `<body>`, pois agora ele faz parte do conteúdo visível ao usuário:

``` HTML
<!DOCTYPE html>
<html>
<head>
  <meta charset="utf-8" />
  <meta name="viewport" content="width=device-width, initial-scale=1.0" />
  <title>FiapSmartCityMVC</title>

  <!-- importando bootstrap e o css do nosso site-->
  <link rel="stylesheet" href="~/lib/bootstrap/dist/css/bootstrap.css" />
  <link rel="stylesheet" href="~/css/site.css" />
</head>
<body>
  <header>
    <nav class="navbar navbar-expand-sm navbar-toggleable-sm navbar-light bg-white border-bottom box-shadow mb-3">
      <div class="container">
        <a class="navbar-brand" asp-area="" asp-controller="Home" asp-action="Index">FiapSmartCity</a>
        <button class="navbar-toggler" type="button" data-toggle="collapse" data-target=".navbar-collapse" 
          aria-controls="navbarSupportedContent"
          aria-expanded="false" aria-label="Toggle navigation">
          <span class="navbar-toggler-icon"></span>
        </button>
        <div class="navbar-collapse collapse d-sm-inline-flex flex-sm-row-reverse">
          <ul class="navbar-nav flex-grow-1">
            <li class="nav-item">
              <a class="nav-link text-dark" asp-area="" asp-controller="Home" asp-action="Index">Home</a>
            </li>
            <li class="nav-item">
              <a class="nav-link text-dark" asp-area="" asp-controller="ProductType" asp-action="Index">Tipo Produtos</a>
            </li>
          </ul>
        </div>
      </div>
    </nav>
  </header>
  <div class="container">
    @RenderBody()
  </div>

  <footer class="border-top footer text-muted">
    <div class="container">
      <p><b>Fiap Smart City - Copyright &copy; 2020</b></p>
      <p>Av. Lins de Vasconcelos, 1222 e 1264 - Aclimação - São Paulo/SP</p>
      <p><a href="tel:+551133858010" class="nav-link">11 3385-8010</a></p>
    </div>
  </footer>

  <!-- importando as libs JavaScript -->
  <script src="~/lib/jquery/dist/jquery.js"></script>
  <script src="~/lib/bootstrap/dist/js/bootstrap.bundle.js"></script>
  <script src="~/js/site.js" asp-append-version="true"></script>

</body>
</html>
```

Entre nosso cabeçalho e rodapé, existe a tag Razor **@RenderBody()**, pois bem, aqui está nosso segredo! 

A tag `@RenderBody()` é a responsável por e`specificar o ponto em que o conteúdo da View será renderizado`, ou seja, o conteúdo HTML da View será inserido no espaço da tag `@RenderBody()`. 

Para juntar o quebra-cabeça do Layout e da View, é necessário especificar para nossas Views o nome do arquivo de layout, que é feito pelo bloco `@{ Layout }` do arquivo `.cshtml`. Edite no arquivo `Views\ProductType\Index.cshtml` a declaração do layout logo após a tag `@model`. É recomendado remover todo o conteúdo HTML duplicado entre View e Layout, para não gerar nenhuma quebra ou incompatibilidade no HTML final:

``` HTML
@model IEnumerable<FiapSmartCityMVC.Models.ProductType>

@{
  Layout = "~/Views/Shared/_Layout.cshtml"; <!-- Referência para o @RenderBody()-->
}

<h1>Tipo de Produto</h1>
<p>
  <!-- uso de TagHelpers para definir o Controller e a Action -->
  <a asp-controller="ProductType" asp-action="Create">Novo Tipo</a>
</p>

<table class="table" border="1">
  <tr>
    <th>Id</th>
    <th>Descrição</th>
    <th></th>
  </tr>

  @foreach (var item in Model)
  {
    <tr>
      <td>
        <label>@item.TypeId</label>
      </td>
      <td>
        <label>@item.TypeDescription</label>
      </td>
      <td>
        <!-- asp-route-id é usado para informar o Id do Item selecionado. -->
        <a asp-controller="ProductType"
          asp-action="Update"
          asp-route-id="@item.TypeId">Editar</a>

        <a asp-controller="ProductType"
          asp-action="Read"
          asp-route-id="@item.TypeId">Consultar</a>

        <a asp-controller="ProductType"
          asp-action="Delete"
          asp-route-id="@item.TypeId">Excluir</a>
      </td>
    </tr>
  }
</table>
```

Execute o projeto e navegue para a tela de listagem de tipos (Index.cshtml): 

<div align="center">
  <img width="700" src="https://user-images.githubusercontent.com/86172286/204568121-e44abd2a-389a-4b7f-b499-e03067326e04.png">
</div>

Com o layout aplicado na tela de listagem, podemos passar para as demais Views e fazer uso do layout, utilizando a tag `@{ Layout }`. E com a remoção das partes comuns, aplique em todas as Views da funcionalidade de tipo de produto.

#### Validações

Até o momento, criamos um fluxo de navegação, adicionamos um cabeçalho e um rodapé padrão para o site por meio de Layout e usamos algumas facilidades do framework ASP.NET Core MVC 2, `porém não inserimos nenhum tipo de validação de dados, deixando que qualquer informação digitada pelo usuário seja aceita no website`. 

É preciso criar bloqueios que não permitama digitação de quaisquer dados nos formulários do sistema, para isso, serão apresentadas algumas técnicas com o uso de recursos do framework paraaimplementação de validações.

##### Validação pelo Controller

Para as validações no `Controller`, tomaremos como base a `Action Cadastrar()` do ProductTypeController. Nela,será adicionada a validação que não permitirá o cadastro de um tipo sem que a descrição seja digitada.

Antes de apresentar a codificação, precisamos saber que todos os `Controllers` do framework possuem uma propriedade chamada `ModelState`, `em que podemos adicionar uma coleção de mensagens de erro e usá-la para controlar nosso fluxo ou deixar as mensagens disponíveis para nossas Views`. A regra aplicada para nosso exemplo deverá ser implementada com os seguintes passos:

- Validar o conteúdo da descrição digitada.
- Adicionar uma mensagem de erro ao ModelState.
- Validar se existe algum erro no ModelState.
- Encontrou erro no ModelState – manter o usuário na tela do formulário e exibir a mensagem de erro.
- Não encontrou erro no ModelState – simular o cadastro no banco de dados e direcionar o usuário para a tela de lista.

Segue o do Controller com a regra de validação:

``` C#
// Anotação de uso do Verb HTTP Post
[HttpPost]
public IActionResult Create(ProductType productType)
{
  // Validando o Campo Descricao
  if (string.IsNullOrEmpty(productType.TypeDescription))
  {
    // Adicionando a mensagem de Erro para descrição em branco
    ModelState.AddModelError("Descricao", "Descrição obrigatória!");
  }

  // Se o ModelState não tem nenhum erro
  if (ModelState.IsValid)
  {
    // Simila que os dados foram gravados.
    Debug.Print("Descrição: " + productType.TypeDescription);
    Debug.Print("Comercializado: " + productType.TypeDescription);
    Debug.Print("Gravando o Tipo de Produto");

    return RedirectToAction("Index", "ProductType");

    // Encontrou um erro no preenchimento do campo descriçao
  }
  else
  {
    // retorna para tela do formulário
    return View(productType);
  }
}
```

Nosso `Controller` já valida a entrada de dados, porém ainda não informa para o usuário a mensagem de erro.O Razor, com a tag **asp-validation-summary**, vai ajudar nossa aplicação com isso. A tag **asp-validation-summary** renderiza ou exibe em nosso HTML todas as mensagens que foram adicionadas na propriedade `ModelState`, assim, precisamos inseri-la em nossa `View`:

``` HTML
<!-- formulário HTML com Tag Helpers-->
<form asp-action="Create" asp-controller="ProductType" method="post">
  <div class="form-horizontal">
    <hr />

    <!-- Trecho de validação para se existe mensagem a ser exibida -->
    @if (!Html.ViewData.ModelState.IsValid)
    {
      <!-- Tag para exibição da lista de erros -->
      <div asp-validation-summary="All" class="alert alert-danger"></div>
    }
  <!--[...]-->
  </div>
```

Fluxo em execução e a mensagem de erro exibida na tela:

<div align="center">
  <img width="700" src="https://user-images.githubusercontent.com/86172286/204654389-31ef6bcf-fa21-45b7-8ea3-5a14bed5fd8b.png">
</div>

**Obs.:** É criada uma validação automática por especificarmos no model ProductType que TypeDescript é obrigatório, afim de deixar somente uma mensagem de erro deixei esse atributo como opctional (`public string? TypeDescription { get; set; }`).

Implementamos nossa primeira validação, porém cabe uma análise para aplicação futura. Nosso exemplo contou com apenas um atributo sendo validado, você consegue imaginar um formulário com dez campos para a digitação do usuário? Teríamos que criar dez ou mais condições de verificação, correto? No próximo bloco, vamos avaliar uma alteração para esse nosso problema.

##### Validação com Data Annotations

Usando anteriormente as validações pelo nosso `Controller`, elas são funcionais, porém apresentam alguns pontos negativos, como a digitação de muitas linhas de código que não são reaproveitáveis.

Aqui entram as `Data Annotations`, que têm o `mesmo objetivo de validação de dados, porém com algumas vantagens`:

- Simplicidade.
- Produtividade.
- Reúso.
- Redução de erros.

As anotações serão `utilizadas na nossa camada de modelo`, assim, `além de validar a entrega de dados nos componentes View e Controller`, podemos usá-las na camada de acesso a dados. 

Para o nosso exemplo, vamos inserir duas validações na propriedade descrição do modelo de tipo de projeto. Precisamos importar o namespace using **System.ComponentModel.DataAnnotations** e,com as simples `[](chaves)` acima da declaração do atributo, escrevemos a validação:

``` C#
using System;
using System.ComponentModel.DataAnnotations;

namespace FiapSmartCityMVC.Models
{
  public class ProductType
  {
    public int TypeId { get; set; }

    [Required(ErrorMessage = "Descrição obrigatória!")]
      [StringLength(50,
        MinimumLength = 3,
        ErrorMessage = "A descrição deve ter, no mínimo 3 e, no máximo, 50 caracteres.")]
    public string TypeDescription { get; set; }
    public bool Marketed { get; set; }
  }
}
```

Depois de inserir nossas anotações no modelo, vamos remover a validação feita no Controller:

``` C#
// Anotação de uso do Verb HTTP Post
[HttpPost]
public IActionResult Create(ProductType productType)
{
  // Validando o Campo Descricao
  //if (string.IsNullOrEmpty(productType.TypeDescription))
  //{
    // Adicionando a mensagem de Erro para descrição em branco
  //  ModelState.AddModelError("Description", "Descrição obrigatória!");
  //}

  // Se o ModelState não tem nenhum erro
  if (ModelState.IsValid)
  {
    // Simila que os dados foram gravados.
    Debug.Print("Descrição: " + productType.TypeDescription);
    Debug.Print("Comercializado: " + productType.TypeDescription);
    Debug.Print("Gravando o Tipo de Produto");

    return RedirectToAction("Index", "ProductType");

  // Encontrou um erro no preenchimento do campo descriçao
  }
  else
  {
    // retorna para tela do formulário
    return View(productType);
  }
}
```

Além das anotações do exemplo anterior, que foram usadas para validar o conteúdo de um campo e o tamanho máximo de caracteres digitados, está disponível uma série de outras validações, como: intervalo de números, validação de e-mail, expressões regulares e tipo de dados. Abaixo,segue o quadro com as anotações mais comuns de validação e a sintaxe de uso:

<div align="center">
  <img width="700" src="https://user-images.githubusercontent.com/86172286/204658310-55ec438a-ab79-4975-9132-d9d3a5b776a4.png">
</div>

#### Data Annotationse as Views

Conseguimos validar nossos dados usando as Data Annotations, mas podemos explorar um pouco mais de recursos e padronizar nossa aplicação.

O objetivo agora é usar as `tags Razors para inserir os rótulos em nossos formulários` e configurar a descrição do rótulo em nosso modelo. Outro ponto é exibir a `mensagem de erro de validação em cada um dos campos`.

O primeiro passo é inserira anotação Display nos atributos do nosso `Model ProductType`:

``` C#
using System;
using System.ComponentModel.DataAnnotations;

namespace FiapSmartCityMVC.Models
{
  public class ProductType
  {
    public int TypeId { get; set; }

    [Required(ErrorMessage = "Descrição obrigatória!")]
      [StringLength(50,
        MinimumLength = 3,
        ErrorMessage = "A descrição deve ter, no mínimo 3 e, no máximo, 50 caracteres.")]
      [Display(Name="Descrição:")]
    public string TypeDescription { get; set; }

    public bool Marketed { get; set; }
  }
}
```

O segundo passo é inserir no rótulo descritivo do campo a propriedade `asp-for` e incluir um elemento span abaixo da caixa de texto com a propriedade `asp-validation-for` para exibir a mensagem de erro do campo específico:

``` HTML
@model FiapSmartCityMVC.Models.ProductType;

@{
    Layout = "~/Views/Shared/_Layout.cshtml";
}

<h1>Tipo de Produto - Cadastrar</h1>

<!-- formulário HTML com Tag Helpers-->
<form asp-action="Create" asp-controller="ProductType" method="post">
  <div class="form-horizontal">
    <hr />

    <!-- Trecho de validação para se existe mensagem a ser exibida -->
    @if (!Html.ViewData.ModelState.IsValid)
    {
      <!-- Tag para exibição da lista de erros -->
      <!--  <div asp-validation-summary="All" class="alert alert-danger"></div> -->
    }

    <div class="form-group">
      <label asp-for="TypeDescription" class="control-label"></label>
      <input asp-for="TypeDescription" class="form-control col-md-4" />
      <span asp-validation-for="TypeDescription" class="text-danger"></span>
    </div>

    <div class="form-group">
      <label asp-for="Marketed" class="control-label"></label>
      <input asp-for="Marketed" />
    </div>

    <div class="form-group">
      <div class="col-md-offset-2 col-md-10">
        <input type="reset" value="Limpar" class="btn btn-default" />
        <!-- HTML Simple para envio dos dados do formulário -->
        <input type="submit" value="Cadastrar" class="btn btn-default" />
      </div>
    </div>
    <hr />
  </div>
</form>

<div>
  <a asp-controller="ProductType" asp-action="Index">Voltar</a>
</div>
```

Os erros ficaram assim:

<div align="center">
  <img width="700" src="https://user-images.githubusercontent.com/86172286/204665976-12dbfcda-9ef9-442f-9483-1d3d4d212662.png">
</div>

`Removemos o bloco da tag asp-validation-summary` para `evitar a duplicidade das mensagens de erro na tela do usuário`. 

#### Mensagens de sucesso com TempData

Chegou a hora de mostrarao usuário as mensagens informando que as operações foram efetuadas com sucesso, pois, até aqui, apresentamos apenas mensagem de erro.

O recurso usado dessa vez é o `TempData`, que tem a função de `armazenar um valor de objeto em uma curta sessão de tempo entre requisições`. É acessado pelo conjunto chave-valor, pode ser `criado e acessado pelas Views e Controllere` tem o seu conteúdo mantido até o momento que algum componente o recupere.

Vamos aplicar o conceito nas camadas de Controller e Views, respectivamente. Porém, antes de aplicar as mensagens em nossos fluxos é necessário efetuar uma pequena configuração na classe Startup.cs no método Configure. É necessário mudar o possionamento da linha **app.UseCookiePolicy()** para a última linha de configuração do projeto.

**Obs.:** Na nova versão do .NET não temos o arquivo Startup.cs.

Na `Action Create` do `ProductTypeController`, é necessário adicionar uma linha de comando que grava uma mensagem de sucesso na `TempData`. Essa mensagem será adicionada ao fluxo de sucesso do cadastro:

``` C#
// Anotação de uso do Verb HTTP Post
[HttpPost]
public IActionResult Create(ProductType productType)
{
  if (ModelState.IsValid)
  {
    // Simila que os dados foram gravados.
    Debug.Print("Descrição: " + productType.TypeDescription);
    Debug.Print("Comercializado: " + productType.TypeDescription);
    Debug.Print("Gravando o Tipo de Produto");

    // Gravação efetuada com sucesso.
    // Gravando mensagem de sucesso na TempData
    @TempData["message"] = "Tipo cadastrado com sucesso!";

    return RedirectToAction("Index", "ProductType");

  // Encontrou um erro no preenchimento do campo descriçao
  }
  else
  {
    // retorna para tela do formulário
    return View(productType);
  }
}
```

Mensagem de sucesso inserida na `TempData`, agora precisamos exibir para o usuário. Lembre-se, `quando o usuário finaliza um cadastro com sucesso, ele é direcionado para a View de lista de tipos`, assim, a exibição do valor da TempData `precisa ser inserida na Views/ProductType/Index.cshtml`:

``` HTML
@model IEnumerable<FiapSmartCityMVC.Models.ProductType>

@{
  Layout = "~/Views/Shared/_Layout.cshtml";
}

<h1>Tipo de Produto</h1>
<p>
  <!-- uso de TagHelpers para definir o Controller e a Action -->
  <a asp-controller="ProductType" asp-action="Create">Novo Tipo</a>
</p>

<!-- Verifica se a chave "Mensagem" existe no TempData -->
@if (@TempData["Message"] != null)
{
  <div class="alert alert-success" role="alert">
    <!-- Imprime para o usuário a mensagem -->
    @TempData["Message"]
  </div>
}

<table class="table" border="1">
  <tr>
    <th>Id</th>
    <th>Descrição</th>
    <th></th>
  </tr>

  @foreach (var item in Model)
  {
    <tr>
      <td>
        <label>@item.TypeId</label>
      </td>
      <td>
        <label>@item.TypeDescription</label>
      </td>
      <td>
        <!-- asp-route-id é usado para informar o Id do Item selecionado. -->
        <a asp-controller="ProductType"
          asp-action="Update"
          asp-route-id="@item.TypeId">Editar</a>

        <a asp-controller="ProductType"
          asp-action="Read"
          asp-route-id="@item.TypeId">Consultar</a>

        <a asp-controller="ProductType"
          asp-action="Delete"
          asp-route-id="@item.TypeId">Excluir</a>
      </td>
    </tr>
  }
</table>
```

Execute a aplicação, faça o fluxo de cadastro de um novo tipo e verifique a mensagem de sucesso ao final do fluxo:

<div align="center">
  <img width="700" src="https://user-images.githubusercontent.com/86172286/204668274-63d8d4f7-3b0c-44e4-8765-954a2274c657.png">
</div>

### Acesso ao banco de dados

#### ADO.NET

Chegamos ao momento de conectar nosso projeto ao nosso banco de dados e remover nossos códigos simulados (mock). Para isso, o framework .NET disponibiliza um conjunto de classes e interfaces responsáveis por prover acesso e mecanismos de manipulação de dados. 

Esses conjuntos de classes, ou essa biblioteca, são chamados `ADO.NET (ActiveX Data Objects)`. Para aqueles que são familiarizados com a linguagem Java,  podemos comparar o ADO.NET com as bibliotecas java JDBC. `Suas classes são acessadas pelo namespace System.Data`. A Figura Classes ADO.NET apresenta o conceito das bibliotecas ADO.NET:

<div align="center">
  <img width="700" src="https://user-images.githubusercontent.com/86172286/204672988-2dc0249b-8282-4dc0-a949-4830de35e20b.png">
</div>

##### Configurando acesso

Um dos primeiros passos para o trabalho com banco de dados é a configuração inicial, que consiste em baixar as bibliotecas necessárias e configurar usuário, senha, endereço do banco de dados, porta e outros requisitos. 

Em nosso exemplo, vamos usar o banco de dados `SQL Server`, assim é necessário baixar via `Nuget Package Manager` a biblioteca para o cliente de acesso ao SQL Server. Faça uma busca pelo nuget **Sytem.Data.SqlClient**, selecione e solicite a instalação.

Biblioteca para acesso do banco instalada, agora precisamos configurar o caminho do banco de dados, usuário, senha e os demais requisitos. Para não ficar repetindo as configurações em todas as classes de acesso ao banco de dados, vamos adicionar essas informações no arquivo de configuração do projeto `appsettings.json` uma única vez, assim, qualquer alteração será facilitada por estar um único ponto. 

O `appsettings.json` é um arquivo no formato JSON que contém as configurações do projeto. Agora, precisamos inserir a configuração do nosso banco de dados.

**Obs.:** Para recuperarmos a connection string do nosso banco no SQL Server, no Visual Studio vamos em `View` > `SQL Server Object Explorer` > clicando com o botão direito do mouse sobre o banco de dados local, indo na opção `Properties`. Vai abrir uma nova janela onde contém um campo chamado `Connetion String` e vamos copiá-la.

Abra o arquivo `appsettings.json` (raiz do projeto) e acrescente a configuração da String de conexão para acesso ao banco de dados SQL Server. O nome da string de conexão será `FiapSmartCityConnection`:

``` JSON
{
  "Logging": {
    "LogLevel": {
      "Default": "Information",
      "Microsoft.AspNetCore": "Warning"
    }
  },
  "AllowedHosts": "*",
  "ConnectionStrings": {
    "FiapSmartCityConnection": "Data Source=(localdb)\\MSSQLLocalDB;Initial Catalog=FiapSmartCityMVC;Integrated Security=True;Connect Timeout=30;Encrypt=False;TrustServerCertificate=False;ApplicationIntent=ReadWrite;MultiSubnetFailover=False"
  }
}
```

Com a configuração pronta e disponível para acesso da nossa aplicação ao SQL Server, já é possível efetuar a conexão e executar comandos em nossa base.

##### Componentes ADO.NET

