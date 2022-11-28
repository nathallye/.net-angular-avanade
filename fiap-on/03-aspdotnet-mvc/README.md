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

## Implementando ASP.NET CoreMVC2

### Funcionalidades

Já temos dois modelos/models definidos e criados em nosso projeto, precisamos agora criar os mecanismos para deixar disponível a manipulação pelos usuários. Vamos iniciar com nosso modelo `ProductType`, que, para poder ser manipulado, deverá possuir os seguintes comportamentos ou funcionalidades:•

- Criação de um novo tipo.
- Remoção de um tipo existente.
- Alteração da descrição ou de comercialização.
- Listagem dos tipos já existentes no sistema.

#### Controllerse Actions

Em um projeto ASP.NET Core MVC2, `toda solicitação do usuário feita pelo navegador será recebida e gerenciada por um Controller`, ficando este `responsável por receber o pedido, acionar os componentes necessários e gerar a resposta para o navegador`. Podemos criar um Controller para cada funcionalidade da nossa aplicação (por exemplo: `CriarTipoProduto/CreateProductType`, `ExcluirTipoProduto/DeleteProductType`, `AlterarTipoProduto/UpdateProductType` e `ListaTipos/ListTypes`), essa abordagem funciona, mas `não é recomendada`. Para organizar melhor nossas funcionalidades, temos os conceitos das `Actions`. As `ações (Actions) nada mais são do que métodos adicionados na classe de controle com o objetivo de organizar e padronizar ainda mais nosso código`. Com o uso das Actions, devemos criar um controlador para cada domínio e ações para cada funcionalidade (por exemplo: `ControllerTipoProduto/ControllerProductType`, Actions `Criar/Create`, `Excluir/Delete`, `Alterar/Update` e `Listar/List`).

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

Controller criado, agora podemos fazer o primeiro teste. Pressione a tecla F5 e aguarde o navegador-padrão do seu computador ser aberto. Com o navegador aberto, complemente o endereço com o `caminho/ProductType` e pressione enter. O navegador irá exibir uma tela de erro informando que nenhuma View com o nome de Index foi encontrada. Apesar de apresentar uma mensagem de erro, significa que nosso teste foi bem-sucedido, pois, afinal, não criamos a View.




