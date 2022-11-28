# ASP.NETMVC

## Introdução

Neste módulo, serão apresentados o conceito do padrão arquitetural MVC (Model-View-Controller) e o framework ASP.NET Core MVC 2, responsável pela implementação do padrão arquitetural em projetos Microsoft .NET.

## Padrão MVC

MVC é um padrão arquitetural que divide uma aplicação em três camadas de componentes: modelo, visão e controlador. Usado por muitos desenvolvedores com a intenção de estruturar melhor o código de grandes aplicativose determinar a responsabilidade de cada grupo de componente, o framework MVC é utilizado em aplicativos desktop, mobile e web.

<div align="center">
  <img width="700" src="https://user-images.githubusercontent.com/86172286/204311452-e1a6083b-b037-46a3-b49c-5d674e5ce2d2.png">
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

Para  iniciar  a  criação  de  um  novo  aplicativo,  precisamos  entender  o  modelo de  negócio que  será implementado,  quais  são  seus  domínios,  quais  informações serão  armazenadas  e  manipuladas e quais  funcionalidades  serão  construídas  para os usuários alimentarem nosso negócio.

Assim, vamos usar como exemplo para este capítulo um modelo de negócio da cidade **Fiap City**. Cidade “virtual” que pretende usar intensivamente a tecnologia para criar melhores condições de sustentabilidade para a população. 

O projeto de Internet da **Fiap City** consiste na divulgação de produtos para a pintura de imóveis que não acumulam resíduos, facilitando a limpeza e reduzindo o uso   de   água.   O   portal   de Internet   a   ser   construído   terá   como   contexto   as apresentações  dos  produtos  (tintas),  notícias, captaçãode  moradores  interessados no uso das tintas e investidores interessados em patrocinar a cidade.No  portal,  teremos  dois  tipos  de  usuários/atores.  O  primeiro  tipo  são  os administradores, com  o  papel  de gerenciar  a manutenção  das  informações  de produtos e notícias  e  consultar moradores  e  investidores.  O  segundo  tipo  são  os moradores ou empresas, que poderão consultar informações dos produtos e efetuar um  cadastro  como  interessados  em  uso  ou  parceria. O foco destematerial  será  a parte administrativa.

Vamos criar nosso projeto?

No  Visual  Studio  2022,  selecione  o  `Create a new project`  >  em seguida vamos  selecionar  o  tipo  de  projeto  `ASP.NET Core Web  Application (Model-View-Controller)`.  Na  parte  inferior, temos  caixas  de  texto para definir o nome do projeto, o local no sistema de arquivos e o nome da solução. Para  nosso  exemplo,  vamos  usar `FiapSmartCity` como  nome  do  projeto  e  da solução. Feito isso, vamos em `Next` e vamos selecionar a versão do `.NET` que iremos usar neste projeto, para concluir vamos clicar em `Create`.

Criado  o  projeto,  conseguimos  verificar  sua  estrutura.  Na  janela `Solutions Explorer`,temos nossa solução, novo projeto Web, e na estrutura do projeto foram criadasas  pastas `Controllers`, `Models` e `Views`:

<div align="center">
  <img width="700" src="https://user-images.githubusercontent.com/86172286/204311207-7e7ee638-ff23-4f23-bf86-9053ca32c37e.png">
</div>

### Modelos

Com   o   nosso   projeto   criado,   precisamos   iniciar   o   entendimento   dos componentes do MVC e a implementação do nosso conceito de negócio. Não  existe  uma  regra  para  a  ordem  de  criação  dos  componentes. Algumas equipes   iniciam   a   construção   pela   camada   de   modelos,   pois   possuem   uma modelagem  de  banco  de  dados pré-estabelecida. Outras  iniciam  pela  visão  e controladores,  pois, assim,conseguem  criar  um  protótipo  e  validar  o  fluxo  da aplicação. Para  nossa  primeira  implementação,  vamos  iniciar  pela  camada  de  modelo, na  qual  vamos  representar  nosso  modelo  de  negócio  para  os  **tipos  de  produto**. Inicialmente, teremos apenas 1 (um) tipo de produto (tinta), mas,no futuro, podemos diversificar   para   outros   itens   das   cidades   inteligentes, como:   filtros   de   água, captadores  de  energia  solar  etc:

<div align="center">
  <img width="700" src="https://user-images.githubusercontent.com/86172286/204311570-e0383dd2-17d3-44b5-a262-e2b7b709bcbf.png">
</div>

Os componentes da camada de modelo são simples classes C#, que devem ser   adicionadas   no `namespace Models do   projeto`.   Para   criar   o   modelo `TipoProduto/ProductType`, clique com o `botão direito na pasta Models e escolha a opção Add` > `Class`.  Defina  o  nome  como `ProductType.cs`,  utilize  o Diagrama  de Classe – Produto  e  Categoria e  adicione  os  atributos  `IdTipo/IDType`, `DescricaoTipo/DescriptionType`   e   `Comercializado/Marketed`, com   seus   respectivos   tipos:

``` C#
using System;
    
  namespace FiapSmartCity.Models
  {
    public class ProductType
    {
      public int TypeId { get; set; }
      public String TypeDescription { get; set; }
      public bool Marketed { get; set; }
    }
  }
```

Seguindo os passos anteriores e o diagrama de Classe – Produto  e  Categoria,  vamos  criar a  classe  para  o  modelo  de  `Produto/Product`.  O  diagrama apresenta uma agregação entre `Produto/Product` e `TipoProduto/ProductType`, sendo, assim, na classe de Produto, precisamos ter uma propriedade `TipoProduto/ProductType`:

``` C#
using System;
    
  namespace FiapSmartCity.Models
  {
    public class Product
    {
      public int ProductId { get; set; }
      public String ProductName { get; set; }
      public String Features { get; set; } // Características
      public double AveragePrice { get; set; } // preço médio
      public String Logotipo { get; set; }
      public bool Active { get; set; } // ativos

      // Referência para classe TipoProduto/ProductType
      public ProductType Type { get; set; }
    }
  }
```
