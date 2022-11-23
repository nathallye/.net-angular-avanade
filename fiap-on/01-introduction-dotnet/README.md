# Introdução à Plataforma .NET

## História

Na década de 1990, a Microsoft tinha como produto principal as linguagens Visual Basic e Visual C++, que possuíam suporte de execução apenas na plataforma Windows. No final dessa década, iniciou-se a aceitação de linguagens independentes de plataforma de execução, tendo o Java como uma das mais conhecidas e usadas.

## Criação do CSharp(C#)

Com o avanço das linguagens de programação (entre elas,o Java e o Delphi) e de dispositivos eletrônicos, as linguagens de programação foram obrigadas a criar recursos de execução para diversos dispositivos e plataformas. Como primeira estratégia, a Microsoft adotou a linguagem Java com o nome de J++, em um acordo de licenciamento com a Sun MicroSystems para o uso da linguagem na plataforma Windows. Esse acordo não foi suficiente, pois a exigência da época era executar essa linguagem em múltiplas plataformas e dispositivos.

Assim, a nova estratégia da empresa foi a criação de uma nova linguagem independente de licenciamentos e acordos, com grande foco em independência de plataforma e dispositivo. Essa iniciativa foi criada a partir do projeto COOL (C-like Object Oriented Language), que teve como base outras linguagens, como: Java, C, C++, Smalltalk, Delphi e Visual Basic (VB).

O projeto COOL foi renomeado para C# 1.0 (C Sharp 1.0) e lançado em conjunto com o .NET Framework em 2002. Desde essa época, a linguagem passou por várias atualizações, a versão mais atual é a 7.0, que teve como uma das grandes melhorias a implementação de chamadas assíncronas, além da evolução na velocidade de execução de comandos. 

O Framework .NET é um ambiente para a execução de programas de computador que fornece uma variedade de serviços aos aplicativos em execução.

  - CLR (Common Language Runtime), responsável por gerenciar a execução de aplicativos.
 
  - Biblioteca de classes, responsável em prover uma coleção de componentes e códigos que os desenvolvedores possam usar em seus softwares.

Em resumo, o Framework .NET é um `ambiente de execução de código e bibliotecas usado por desenvolvedores para criar e executar programas`. Assim como o Java e outras linguagens, utiliza do conceito de máquina virtual, que cria uma camada entre o sistema operacional e a aplicação. 

O componente responsável por esse isolamento entre aplicação e sistema operacional é o CLR (Common Language Runtime).Porém,o CLR possui mais responsabilidades do que somente o isolamento entre aplicação e sistema operacional.O CLR também é responsável por: 

  - Gerenciamento de memória.
  - Tipos comuns de variáveis.
  - Bibliotecas para tipos exclusivos de projetos (por exemplo: projetos de internet, acesso a banco de dados, projetos de aplicativos móveis e outros).
  - Compatibilidade de versão.
  - Multiplataforma (por exemplo: Windows 7, Windows 8, Windows 8.1, Windows 10, Windows Phone e Xbox 360)
  - Execuções paralelas com diferentes versões do framework.

## IDE Visual Studio

O ambiente de desenvolvimento ou IDE (Integrated Development Environment) do .NET Framework é chamado de Visual Studio. É a ferramenta de suporte ao desenvolvimento das linguagens C# (C Sharp), Visual Basic .NET (VB.NET), C, C++ e Xamarin.

### Produtos suportados

O Visual Studio oferece suporte a três linguagens de programação, são elas: 
  - Microsoft Visual C++.
  - Microsoft Visual C#.
  - Microsoft Visual Basic (VB.NET). 
  Possui também o Microsoft Visual Web Developer, plataforma para desenvolvimento de aplicações ou serviços web, para os quais se deve usar as bibliotecas do pacote ASP.NET podendo-seescolher entre as linguagens C# ou VB.NET.

## Primeiro projeto

### Criação de um Projeto console

- Vamos em `Create a new project` e selecionar o template `Console App`;

- Feito isso, na janela de configuração do novo projeto vamos definir o nome e o diretório que queremos salvá-lo.

### Estrutura do projeto

O `espaço de trabalho` para o desenvolvedor no Visual Studio é conhecido como `solution`, ou “solução”, em português. No sistema de arquivos do computador, toda solução é apresentada por arquivo com a extensãos `ln`.

A solução é responsável por agrupar vários projetos .NET, permitindo a navegação entre eles e a compilação de todos ao mesmo tempo.O projeto .NET é o responsável pelo agrupamento do código-fonte, ícones, imagens, xml, dll e qualquer outra fonte que será compilada. No sistema de arquivo, um projeto é apresentado pela extensão .csproj (C#) ou .vbproj (VB). 

![image](https://user-images.githubusercontent.com/86172286/203596858-0b2fc13f-2abb-493b-9bad-462fd1fe06cb.png)

### Escrevendo o código

Anteriormente, foram executados os passos para a criação de um projeto C# do tipo Console Application, que por padrão gera a classe `Program.cs`, a qual será responsável pela `execução dos nossos comandos`. 

``` C#
using System;

namespace FiapHelloWorld // namespace(pacote/modulo)
{
  class Program // classe
  {
    static void Main(string[] args) // método
    {
      
    }
  }
}
```

Agora, vamos inserir algumas linhas de código e executar o primeiro programa. Com um duplo clique no arquivo `Program.cs`, disponível na janela `Solutions Explorer`, podemos editar o conteúdo do programa e inserir as linhas de código necessárias. Assim, vamos inserir uma linha para a impressão de uma mensagem na tela e outra linha que mantém a janela para a visualização do usuário até que uma tecla seja pressionada:

``` C#
using System;

namespace FiapHelloWorld 
{
  class Program 
  {
    static void Main(string[] args)
    {
      Console.WriteLine("Fiap - Ola C#"); 
      
      Console.Read(); // trecho para manter a janela aberta
    }
  }
}
```

### Compilando e executando

A forma mais simples e prática para executar uma plicação criadano Visual Studio é pressionando a tecla `F5`. Com o projeto aberto, pressione a tecla F5 e observe o resultado.

Para encerrar a execução do programa, na tela de exibição da mensagem “Fiap - Ola C#”, pressione a tecla Enter, ou na janela do Visual Studio aperte “Shift + F5”.

A tecla F5 é a forma mais simples de compilação e execução de projetos, mas é possível realizar outras ações no Visual Studio para facilitar o dia a dia do desenvolvedor, como: compilar todos os projetos de uma solução, compilar apenas um projeto sem executá-lo, limpar compilações anteriorese até efetuar uma análise do código criado. 

Essas ações podem ser acionadas pelo menu `Build`, na barra superior da ferramenta. Outro atalho para compilação e execução éa barra de tarefas `Standard`, que apresenta botões para execução, encerramento, continuação em caso de debug e outras funções não relacionadas àexecução e compilação.

### Organizando o projeto(Criando Namespaces e Classes)

Para organizar nossos projetos em C#, precisamos falar de namespaces. Essa palavra é reservada no C#, `responsável por declarar um escopo ou bloco que contém um conjunto de classes relacionadas`. Também pode ser usada para `controlar o acesso entre conjunto de classes de namespaces diferentes`.

![image](https://user-images.githubusercontent.com/86172286/203597065-d3d68523-7caf-4db6-baf8-b51b028d34cb.png)

Por padrão, o Visual Studio define como primeiro namespaceo nome do projeto.

O padrão definido pela Microsoft para a criação de namespaces deve seguir o do exemplo abaixo:
`NomeDaEmpresa.NomeDoProjeto.ModuloDoSistema`

E outra boa prática que vamos adotar é a criação das pastas na estrutura do nome usado para o namespace. 
Exemplo: `...\FiapHelloWorld\FiapHelloWorld\Models`

![image](https://user-images.githubusercontent.com/86172286/203597115-2b40c0cc-9867-46f0-b9a7-adfb2368c5a7.png)

![image](https://user-images.githubusercontent.com/86172286/203597138-ac955892-7d6c-4c08-8fc4-4b6ad0743427.png)

Para a criação de um namespace, basta clicar com o botão direito no projeto C#, escolher a opção `Add > New Folder` e `digitar o nome da pasta`. 
Para o nosso exemplo, será criada uma pasta com o nome `Models`. Para entender o uso do namespace, vamos clicar com o botão direito na pasta Models e selecione a opção `Add > Class`.Em seguida, vamos selecionar a opção `Class` e definir o nome de `HelloModel`.

Analisando o código-fonte da classe criada, pode-se notar que foi definido o namespace `FiapHelloWorld.Models` como padrão. Pois bem, é possível definir outro nome para um namespace sem mudar o nome da pasta, porém, por questão de bom senso, vamos mantê-los sempre iguais. 

``` C#
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace FiapHelloWorld.Models
{
  internal class HelloModel
  {
  }
}
```

Dentro de um namespace, é possível criar, além de classes, outros tipos de componentes, como: `interface`, `struct`, `enum`, `delegate`.

O Visual studio por padrão não declara a classe/`class` como pública/`public`, então iremos fazer essa declaração manualmente para conseguirmos acessar essa classe de uma forma geral:

``` C#
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace FiapHelloWorld.Models
{
  public class HelloModel
  {
  }
}
```

Feito isso, para entendermos o uso do modelo, iremos declarar uma propriedade publica/`public` do tipo `string` chamada Mensagem/`Message` que irá receber como valor a string "Olá Model C#":

``` C#
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace FiapHelloWorld.Models
{
  public class HelloModel
  {
    public string Message = "Olá Model C#";
  }
}
```

Agora para usarmos esse modelo/`model` iremos voltar na classe `Program.cs` e usar a classe modelo e imprimir o texto declarado na propriedade `Message`.
Primeiramente iremos criar uma instância desse `Models.HelloModel` que irá chamar `helloModel`:

``` C#
using System;

namespace FiapHelloWorld 
{
  class Program 
  {
    static void Main(string[] args) 
    {
      Models.HelloModel helloModel = new Models.HelloModel();

      Console.Read(); 
    }
  }
}
```

Se quisermos abreviar a chamada da classe podemos chamar/importar esse diretório `Models` usando a palavra reservada `using`:

``` C#
using System;
using FiapHelloWorld.Models;

namespace FiapHelloWorld 
{
  class Program 
  {
    static void Main(string[] args) 
    {
      HelloModel helloModel = new Models.HelloModel();

      Console.Read(); 
    }
  }
}
```

Feito isso, conseguimos imprimir a mensagem de chamando a propriedade `Message` de dentro da instância `helloModel`:

``` C#
using System;
using FiapHelloWorld.Models;

namespace FiapHelloWorld 
{
  class Program 
  {
    static void Main(string[] args) 
    {
      HelloModel helloModel = new Models.HelloModel();
      Console.WriteLine(helloModel.Message);

      Console.Read(); 
    }
  }
}
```

### Debug

Quando temos a necessidade de validar alguns pontos do código e navegar pelas classes do projeto durante a execução a fim de entender o que acontece com nossas classes, atributos e comandos, vamos usar as ferramentas do Visual Studio para depuração.

Vamos iniciar pela classe do modelo (Models\HelloModel.cs). Vamos abrir a classe no editor e posicionar o cursor na linha de criação do atributo Message. Com a tecla `F9` ou um clique na margem esquerda da janela do editor, podemos adicionar um ponto de interrupção (`breakpoint`). 

![image](https://user-images.githubusercontent.com/86172286/203597263-ee6da547-bfde-49be-82b1-14dc527d1c20.png)

Para `testar o breakpoint`, execute o projeto (`F5`) e espere até o Visual Studio interromper a execução ao chegar na linha selecionada. Com a execução interrompida na linha selecionada,algumas ações para ajudar na compreensão do programa podem ser tomadas. A seguir,vamos ver detalhes das ações mais comuns de debug.

#### Immediate Window

É uma ferramenta para inserir comandos, mudar valores de variáveisou testar regrasem tempo de execução.A janela Immediate Windowsé exibida no rodapédo Visual Studio no momentoda execução do aplicativo, ou pode ser aberta no menu `Debug > Windows > Immediate` ou `Crtl + Alt + I`.

Dentro da janela, podemos inserir linhas de código C# para alterar valores ou acessar o conteúdo e verificar valores. A tecla enter executa a alteração.

![image](https://user-images.githubusercontent.com/86172286/203597325-d2640ceb-0d18-4c02-97b0-dd7b215ea2c3.png)

#### Quick Watch

É a forma mais rápida de acessar conteúdos de variáveis, objetos ou expressões durante a execução em modo debug. A janela `Quick Watch` pode ser acessada clicando com o botão direito sobre a variável e selecionando a opção QuickWatch... ou pela tecla `Shift + F9`.

![image](https://user-images.githubusercontent.com/86172286/203597418-089566fc-7544-4a68-821a-6a343e96087b.png)
