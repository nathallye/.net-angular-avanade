# WEB API (RESTFUL)

Após passarmos pelas arquiteturas MVC e ORM, do .NET, vamos descobrir a importância dos `web services`, que são `responsáveis pela ponte entre o nosso sistema e outras aplicações disponíveis`.

O Web Service é a alma dos principais aplicativos dinâmicos. Sabe quando você solicita uma carona pelo Uber ou pede uma comida no iFood? Quem faz esta ligação entre o aplicativo e o sistema do fornecedor é o Web Service! Você está preparado para integrar as suas soluções com outros sistemas?

## Web Services

Expor uma funcionalidade de negócio para ser consumida por um sistema cliente fez parte de todas as soluções para os cenários de negócio que imaginamos. Os Web Services são formas de expormos tais funcionalidades como serviço. O W3C (World Wide Web Consortium) e a OASIS (Organization for the Advancement of Structured Information Standards) são as organizações responsáveis por padronizar os Web Services e empresas como IBM, Microsoft e HP, entre outras participantes do consórcio, apoiaram a criação dos padrões que determinam a tecnologia. Segundo o W3C, a definição de Web Services é:

“A Web Service is a software system designed to support interoperable machine-to-machine interaction over a network.” (W3C Working Group Note, 11 February 2004)

Ou seja, um `sistema de software projetado para suportar a interoperabilidade entre máquinas em uma rede`. Em linhas gerais, podemos dizer que `Web Services são aplicações desenvolvidas para integrar sistemas que se comunicam com fraco acoplamento, por meio de mensagens que trafegam por meio da Internet ou de uma Intranet, partindo e retornando de ambientes heterogêneos`. 

Para essa tecnologia, `pouco importa se o Web Service foi desenvolvido em uma linguagem de programação e é executado em um sistema operacional ou plataforma de hardware completamente diferente` do sistema cliente que consome o serviço. `Para que a interação ocorra, basta que eles se comuniquem utilizando mensagens enviadas sobre o protocolo HTTP`, comumente com os dados serializados nos formatos XML ou JSON. 

Vamos imaginar o cenário de um cliente consultando o saldo bancário, via Mobile Banking. Neste contexto, o App do banco é caracterizado como o sistema cliente, responsável por consumir o serviço do Internet Banking que retornará o saldo bancário. Novamente, abstraindo inúmeros detalhes de infraestrutura e segurança, vejamos como será a solução utilizando Web Services.

O cliente do banco deverá selecionar os números, previamente cadastrados da agência e da conta, para, na sequência, digitar a respectiva senha em um formulário do App e disparar a solicitação de consulta. O aplicativo, então, será responsável por criar uma mensagem serializada no formato XML ou JSON que terá, como parte do conteúdo, os dados fornecidos pelo cliente do banco. Mensagem criada, o App deverá enviá-la pela Internet sobre o protocolo HTTPS para o Web Service responsável pela consulta de saldo do Internet Banking.

Após a autenticação realizada por um componente corporativo, o Web Service do IB será responsável por criar uma mensagem de retorno, igualmente serializada no formato XML ou JSON, que terá, como parte do conteúdo, o saldo da conta. O Web Service retornará a mensagem pela Internet ao sistema cliente (App), também utilizando o protocolo HTTPS. Ao receber a comunicação, o App deverá desserializar a mensagem em um objeto e obter o saldo por meio de um método público do objeto instanciado para, assim, apresentar o valor na tela de consulta do App. 

Claro que o processo foi descrito de forma muito sucinta, não imagine que a codificação da consulta ao saldo da conta corrente estará dentro do código do Web Service. Com certeza, o WS utilizará outros componentes de software que são responsáveis pela consulta de forma corporativa em uma base no mainframe do banco. Estes componentes retornarão o saldo para que o Web Service apenas crie a mensagem e atenda o cliente que consumiu o serviço. 

Estes mesmos componentes que realizam a consulta de saldo para o Web Service atendem a qualquer outro canal que o cliente do banco esteja usando. Trocando em miúdos, se o cliente consultar o saldo da conta corrente pelo IB, por um ATM ou por um caixa do banco, os mesmos componentes de software deverão ser chamados para realizar a consulta e devolver o resultado ao canal chamador. Lembra do acoplamento fraco que tanto comentamos? 

Neste exemplo, utilizamos a tecnologia de Web Services para atender o canal Mobile e empregamos os conceitos da Arquitetura Orientada a Serviços para atender este canal ou a qualquer outro disponibilizado ao cliente que deseja realizar uma consulta de saldo. 

Conceitualmente, pelos exemplos, percebemos que um Web Serviceé um software que possibilita ao provedor de serviços atender a consumidores trocando mensagens pela rede. Os sistemas que se comunicaram pouco sabem sobre as capacidades tecnológicas envolvidas. O App desconhece se o Web Service foi codificado em Java EE, .NET ou PHP e o Web Service não se preocupou se o App foi desenvolvido em Java Android, Swift ou alguma linguagem híbrida.

Isso acontece, pois, tanto na requisição, quanto na resposta, falamos sobre a necessidade de `serializar` as mensagens em formatos específicos XML ou JSON.

Apenas como histórico, na criação dos padrões para Web Services, as empresas participantes do W3C adotaram o protocolo SOAP baseado em XML. O REST surgiu em 2000, na UC Irvine, em uma tese de doutorado (PHD), e passou a compor a definição de Web Services do W3C em meados de 2004.

## Um pouco sobre API

`Uma API ou Web API é uma evolução de um Web Service` e ignora os detalhes de implementação e sintaxe do SOAP, `deixando o tráfego de informação mais leve e a implementação mais simples`. Uma API Web utiliza o `padrão arquitetural REST, que tem como foco a diversidade dos recursos` ou nome (Ex. recursos para Produtos, recursos para Clientes), diferente dos web services SOAP, cujo foco são as operações (Ex.: Consultar Clientes, Cadastrar Clientes etc). A utilização dos serviços no padrão REST passou de uma tendência para uma realidade. Nos últimos anos o crescimento aconteceu de forma exponencial, e um dos grandes colaboradores desse crescimento é a quantidade de serviços usados em aplicativos móveis. Eles precisam ter a complexidade cada vez mais simplificada e também a quantidade dos dados trafegados cada vez mais reduzida.

Assim, o framework `ASP.NET Web API` é uma plataforma ideal e indicada para a construção das aplicações no padrão REST. Em outras palavras, uma API REST não depende de XML para trafegar informações e ignora detalhes de implementação e sintaxe do protocolo. Os formatos mais comuns de um API são JSON, texto e XML, dando ao desenvolvedor o poder de escolha do melhor formato de acordo com sua necessidade. Grandes empresas, como Facebook, Google, Netflix e LinkedIn, passaram a usá-la e disponibilizam APIs a serem usadas por parceiros e usuários dos serviços. O ASP.NET WEB API utiliza HTTP com REST.

## Fundamentos

Como podemos notar, no tópico anterior, falamos sobre Web Services, o surgimento das novas tecnologias e a diferença entre SOAP e REST até chegarmos no ASP.NET WEB API. Mas temos mais fundamentos essenciais para o funcionamento de tudo isso, os mais comuns serão explicados nos tópicos a seguir.

### Protocolo HTTP

Não conseguimos abordar os assuntos abaixo sem falar sobre o HTTP (Hypertext Transfer Protocol), protocolo da camada de aplicação do modelo OSI para transferência dos dados na rede mundial dos computadores. Em outras palavras, `são conjuntos de regras de transmissão dos dados que permitem que máquinas com diferentes configurações possam se comunicar em uma mesma “linguagem/idioma”`. Seu `funcionamento é baseado em requisição e resposta client e server`, ou seja, o client,ao solicitar um recurso na Internet, envia um pacote dos dados com cabeçalhos (Headers) a um URI (Ou URL) e o destinatário ou servidor vai devolver uma resposta que pode ser um recurso ou outro cabeçalho.

### URL

Sigla para *Uniform Resource Locator*(Localizador de Recursos Universal), como o próprio nome diz, `é um endereço, um Host de um recurso` (como um arquivo, uma impressora etc.), que permite o acesso a uma determinada rede disponível; seja Internet ou até mesmo uma rede corporativa como uma empresa (Intranet). Seu funcionamento é basicamente associar um endereço remoto com um nome de recurso na Internet/Intranet. Exemplo de URL: 

- fiap.com.br
- google.com.br
- facebook.com

### URN

Sigla para *Uniform Resource Name*(Nome de Recursos Universal), é o `nome do recurso que será acessado`.Exemplo de URN: 

- index.html
- contato.aspx
- home.php

### URI

É o acrônimo de *Uniform Resource Identifier* (Identificador de Recursos Universal), podendo ser uma página, uma imagem, um vídeo etc., tendo como `principal propósito permitir a interação com o recurso por meio de uma rede`, isto é, um identificador único para que não seja confundido. Exemplo de URI: 

- https://www.facebook.com/zuck
- https://www.fiap.com.br/online/graduacao/bacharelado/sistemas-de-informacao/
- https://www.google.com.br/search?rlz=1C1HIJA_enBR723BR723&ei=fUyPWqryIce5wgTT7pHQAg&q=fiap&oq=fiap&gs_l=psy-ab.3..35i39k1j0i131k1j0l3j0i67k1j0l4.1769.2212.0.2379.4.4.0.0.0.0.810.332.4.4.0....0...1.1.64.psy-ab..0.4.329...0i131i67k1.0.G8Vp2Tigdhk

### URL, URN, URI

URI é a *composição do Protocolo* (**http:// ou https://**), a *localização do recurso* (URL - **fiap.com.br**) e do *nome do recurso* (URN - **/online/graduacao/bacharelado/sistemas-de-informacao/**).

<div align="center">
  <img width="700" src="https://user-images.githubusercontent.com/86172286/205186426-99c90376-8195-4702-b202-4cf59f264a5b.png">
</div>

 ### Verbos HTTP

 Os verbos HTTP são os métodos de requisição usados para `indicar a ação que será executada quando chamamos um recurso de uma API Rest`. Segue a lista dos mais conhecidos e utilizados:
 
 - **GET:** Responsável por buscar/consultar informações por meio de uma URI. É um método idempotente, isto é, não altera nada, não importa quantas vezes a requisitamos, será o mesmo resultado. 
 - **POST:** Responsável por enviar informações com conteúdo embutido no corpo, podendo ser JSON, XML ou texto por meio de uma URI. É utilizado muitas vezes para gravar uma nova informação no sistema.
 - **DELETE:** Responsável por remover informações por uma URI.
 - **PUT:** Responsável por atualizar informações, com conteúdo embutido no corpo, podendo ser XML ou JSON.
 
 Veja alguns exemplos no quadroa baixo:

<div align="center">
  <img width="700" src="https://user-images.githubusercontent.com/86172286/205186049-f9336bf3-ec0a-4d1b-a893-346562930420.png">
</div>

### HTTP Status Code

O Status Code de uma requisição é parte importante de uma Web API, pois com ele é `possível reconhecer facilmente o que aconteceu com a requisição`. O código é um padrão numérico que apresenta o resultado da ação. Seguem alguns exemplos:

- **200 - OK:** A requisição foi bem-sucedida. 
- **201 - Created:** O pedido foi cumprido e resultou em um novo recurso que está sendo criado.
- **401 - Unauthorized:** A URI especificada precisa de autenticação.
- **403 - Forbidden:** Indica que o servidor se recusa a atender à solicitação.
- **404 - Not Found:** O recurso requisitado não foi encontrado. 
- **500 - Internal Server Error:** Indica um erro do servidor ao processar a solicitação.

## Criar o projeto

Para iniciar a criação de um novo serviço ASP.NET WEB API, iremos seguir o mesmo modelo de negócio dos capítulos anteriores, a Fiap Smart City, nossa cidade “virtual”, cada vez mais tecnológica, proporcionando à população melhores condições e sustentabilidade. 

No Visual Studio, primeiramente vamos no menu `Create a New project`, feito isso vamos  selecionar o tipo de projeto `ASP.NET Core Web API` > `Next` e em seguida definir o nome do projeto, o local no sistema dos arquivos e o nome da solução. Para nosso exemplo, vamos usar como nome do projeto e da solução `FiapSmartCityWebAPI`  `Next` > `Create`.

Finalizado a operação de criação, conseguimos verificar a estrutura criada para o nosso projeto. Na janela **Solutions Explorer**, temos nossa solução, nosso projeto da Web API e as pastas Controllers, Models e Views, que são idênticas ao projeto ASP.NET MVC.

<div align="center">
  <img width="700" src="https://user-images.githubusercontent.com/86172286/205186131-c5d7774e-ed8a-4835-9ef2-535f60fc45e9.png">
</div>

**Obs.:** Na versão .NET 6 só vem criada a pasta `Controllers`.

### Modelos

Com o nosso projeto criado, iremos seguir a mesma estrutura que foi explicada no Capítulo ASP.NET MVC. 

Nesse primeiro momento, iremos começar pela camada de modelos, onde criaremos a estrutura dos nossos dados. Em seguida, uma camada de acesso a dados e, para finalizar, nossos controladores. Segue a representação UML para as nossas classes de modelo:

<div align="center">
  <img width="700" src="https://user-images.githubusercontent.com/86172286/205186303-5730940f-71a9-45af-84a7-9c05b764e081.png">
</div>

Os modelos devem ser adicionados nonamespace `Models` do projeto. Para criar o modelo `ProductType`, clique com o `botão direito na pasta Models` e escolha a opção `Add` > `Class`. Defina o nome como ProductType.cs, utilize o Diagrama de Classe e adicione os atributos `TypeId`, `TypeDescription` e `Marketed` com seus respectivos tipos:

``` C#
namespace FiapSmartCityWebAPI.Models
{
  public class ProductType
  {
    public int TypeId { get; set; }
    public string TypeDescription { get; set; }
    public bool Marketed { get; set; }

    public List<Product> Products { get; set; }

    public ProductType() 
    {
      Products = new List<Product>();
    }

    // MOCK - Método para adicionar um produto ao Tipo
    public void Add(Product product)
    {
      this.Products.Add(product);
    }

    // MOCK - Método para remover um produto do tipo
    public void Remove(long id)
    {
      Product product = Products.FirstOrDefault(p => p.ProductId == id);

      Products.Remove(product);
    }

    // MOCK - Método para alterar um produto do tipo
    public void Altera(Product product)
    {
      Remove(product.ProductId);
      Add(product);
    }
  }
}
```

Seguindo os passos anteriores e o Diagrama de Classe, vamos criar a classe para o modelo de `Product`. O diagrama apresenta uma agregação entre `Product` e `ProductType`, sendo, assim, na classe de `Product` precisamos ter uma propriedade do tipo `ProductType`:

``` C#
namespace FiapSmartCityWebAPI.Models
{
  public class Product
  {
    public int ProductId { get; set; }
    public string ProductName { get; set; }
    public string Features { get; set; }
    public double AveragePrice { get; set; }
    public string Logotipo { get; set; }
    public bool Active { get; set; }

    // Referência para classe TipoProduto
    public ProductType ProductTypeId { get; set; }
    
    public Product() 
    { 
    }

    public Product(int productId, string productName, string features, double averagePrice, string logotipo, bool active, ProductType productTypeId)
    {
      ProductId = productId;
      ProductName = productName;
      Features = features;
      AveragePrice = averagePrice;
      Logotipo = logotipo;
      Active = active;
      ProductTypeId = productTypeId;
    }
  }
}
```

## Funcionalidades

Temos dois modelos definidos e criados em nosso projeto, precisamos agora desenvolveros mecanismos para alimentar com dados. Vamos iniciar criando nossa Camada **DAL** e depois nossos controladores, que serão os responsáveis pelas requisições àAPI e também pela validação do fluxo dos nossos serviços. 

### DAL
