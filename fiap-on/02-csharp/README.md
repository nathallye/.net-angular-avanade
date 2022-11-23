# C#

## Introdução

O C# é uma linguagem simples, orientada a objetos, que combina a produtividade e o poder de linguagem, como C e C++. O fato de ser uma linguagem relativamente nova não apresenta problemas com documentação, pois oferece um grande acerto de documentos e exemplos on-line, além de livros, artigos, fóruns de discussões, blogs, repositórios de exemplos e outros materiais de referência. 

## Instruções básicas

### Tipos de variáveis

O Quadro Tipos primitivos mostra os tipos primitivos de variáveis do C#. Os tipos listados são conhecidos como tipos primitivos ou `value types`. Na linguagem C#, todas as variáveis e constantes são fortemente tipadas, toda declaração de método requer a especificação do tipo de cada parâmetro de entrada e também a especificação do tipo do retorno.

As informações de um tipo de variável podem conter detalhes como:

- Espaço em memória que o tipo utiliza.
  - Espaço em memória que o tipo utiliza.
  - Tipo base que é herdado.
  - Endereço de memória.
  - Valor mínimo e valor máximo que pode armazenar.
  - Operações permitidas.

Os tipos primitivos do C# são muito similares aos tipos primitivos do Java, por exemplo: byte, char, double, floatelong usam a mesma palavra reservada nas duas linguagens. Já o tipo boolean do Java foi abreviado para bool.

Com os tipos primitivos do C# apresentados, podemos entender como devemos declarar variáveis, como elas funcionam na aplicação e como interagem em tipos de dados diferentes:

``` C#
using System;

namespace VariableTypes
{
  class Program
  {
    static void Main(string[] args)
    {
      int valueInt = 100;

      // convertendo inteiro para long
      long valueLong = valueInt;

      // convertendo long para double
      double valueDouble = valueLong;
      
      // Imprimindo conteúdo das variáveis
      Console.WriteLine("Valor Inteiro:" + valueInt);
      Console.WriteLine("Valor Long:" + valueLong);
      Console.WriteLine("Valor Double:" + valueDouble);

      // Para a execução até o usuário teclar Enter.
      Console.Read();
    }
  }
}
```

O caso anterior não apresenta incompatibilidade na associação das variáveis do tipo `int`, `long` e `double`, pois todas as interações são feitas atribuindo a variável de menor tamanho  para a variável de maior tamanho. 
Vamos adicionar uma linha no exemplo e tentar associar o valor da variável `long` para a variável `int`:

``` C#
using System;

namespace VariableTypes
{
  class Program
  {
    static void Main(string[] args)
    {
      int valueInt = 100;

      // convertendo inteiro para long
      long valueLong = valueInt;

      // convertendo long para double
      double valueDouble = valueLong;

      // Tentando converter long para int
      valueInt = valueLong;

      // Imprimindo conteúdo das variáveis
      Console.WriteLine("Valor Inteiro: " + valueInt);
      Console.WriteLine("Valor Long: " + valueLong);
      Console.WriteLine("Valor Double: " + valueDouble);

      // Para a execução até o usuário teclar Enter.
      Console.Read();
    }
  }
}
```

A linha onde se encontra o código `valueInt = valueLong;` aponta um erro, impossibilitando a compilação do projeto. A variável do tipo `int` não aceita um valor do tipo `long` sem a declaração de uma conversão. 
Dessa forma, vamos alterar essa linha para adicionar a conversão e executar o programa de exemplo:

``` C#
using System;

namespace VariableTypes
{
  class Program
  {
    static void Main(string[] args)
    {
      int valueInt = 100;

      // convertendo inteiro para long
      long valueLong = valueInt;

      // convertendo long para double
      double valueDouble = valueLong;

      // Tentando converter long para int
      // valueInt = valueLong;

      // declaração de conversação (Parse)
      valueInt = (int) valueLong;

      // Imprimindo conteúdo das variáveis
      Console.WriteLine("Valor Inteiro: " + valueInt);
      Console.WriteLine("Valor Long: " + valueLong);
      Console.WriteLine("Valor Double: " + valueDouble);

      // Para a execução até o usuário teclar Enter.
      Console.Read();
    }
  }
}
```

Tipos mais usados: `int`, `double`, `bool` e `string`.

### Operadores

``` C#
using System;

namespace Operators
{
  class Program
  {
    static void Main(string[] args)
    {
      // Operadores para Cálculos 
      int soma = 10 + 15 + 3;
      int subtracao = soma - 10;
      int multiplicacao = soma * subtracao;
      double divisao = multiplicacao / subtracao;
      
      Console.WriteLine(soma);
      Console.WriteLine(subtracao);
      Console.WriteLine(multiplicacao);
      Console.WriteLine(divisao);

      Console.Read();
    }
  }
}
```

``` C#
using System;

namespace Operators
{
  class Program
  {
    static void Main(string[] args)
    {
      // Atribuição 
      int soma = 10;
      soma += 1; // Valor final 11

      int subtracao = soma;
      subtracao -= 10; // Valor final 1

      int multiplicacao = soma * subtracao;
      multiplicacao *= 3; // Valor final 33

      double divisao = multiplicacao;
      divisao /= soma; // Valor final 3

      Console.WriteLine(soma);
      Console.WriteLine(subtracao);
      Console.WriteLine(multiplicacao);
      Console.WriteLine(divisao);

      Console.Read();
    }
  }
}
```

#### Precedência de operadores

Quando uma expressão C# écomposta por vários operadores, a linguagem determina a sequência de execução de cada uma delas. O Quadro Precedência de operadoresilustra os operadores da linguagem e sua precedência, na ordem do mais alto para o mais baixo, ou seja, os primeiros da lista são executados antes.

### Controle de fluxo

O controle de fluxo é o tema mais comum em qualquer projeto de software, assim todas as linguagens de programação possuemestruturas condicionais muito similares. A estrutura `if`...`else` é uma das mais utilizadas, e sempre é a primeira a ser introduzida no aprendizado de lógica de programação ou no aprendizado de uma linguagem.

Segue um exemplo de condição `if`...`else` simples:

``` C#
using System;

namespace ControlStructures
{
  class Program
  {
    static void Main(string[] args)
    {
      int age = 17;

      if (age >= 18)
      {
        Console.WriteLine("É maior de idade!");
      } else
      {
        Console.WriteLine("Ação não permitida para menor de 18 anos!");
      }

      Console.Read();
    }
  }
}
```

Adicionando o operador condicional AND(&&) para validar o fluxo de uma condição mais complexa:

``` C#
using System;

namespace ControlStructures
{
  class Program
  {
    static void Main(string[] args)
    {
      int age = 17;

      if (age >= 18 && age < 21)
      {
        Console.WriteLine("É maior de idade!");
      } 
      else
      {
        Console.WriteLine("Ação não permitida para menor de 18 anos!");
      }

      Console.Read();
    }
  }
}
```

Com a estrutura if...else, é possível adicionar mais blocos de condição usando a estrutura `else if`:

``` C#
using System;

namespace ControlStructures
{
  class Program
  {
    static void Main(string[] args)
    {
      int age = 20;

      if (age > 15 && age < 18)
      {
          Console.WriteLine("SUB-17");
      }
      else if (age > 18 && age < 21)
      {
          Console.WriteLine("SUB-20");
      }
      else if (age > 21 && age < 24)
      {
          Console.WriteLine("SUB-23");
      }

      Console.Read();
    }
  }
}
```

Por fim, temos a estrutura de controle para escolhas chamada `Switch`:

``` C#
using System;

namespace ControlStructures
{
  class Program
  {
    static void Main(string[] args)
    {
      int age = 16;

      switch (age)
      {
        case 15:
          Console.WriteLine("SUB-15");
          break;
        case 16:
          Console.WriteLine("SUB-16");
          break;
        case 17:
          Console.WriteLine("SUB-17");
          break;
        case 18:
          Console.WriteLine("SUB-18");
          break;
        case 19:
          Console.WriteLine("SUB-19");
          break;
        case 20:
          Console.WriteLine("SUB-20");
          break;
        default: 
          Console.WriteLine("Categoria não definida!");
          break;
      }

        Console.Read();
    }
  }
}
```

### Estruturas de repetições

Essas estruturas são responsáveis pela execução e pelo controle de comandos executados repetidamente. Também  conhecidas como laços, as estruturas de repetição disponíveis na linguagem C# são: `for`, `while`, `do...while` e `foreach`.

#### Estrutura for

Para escrever um laço usando a estrutura `for`, é necessária a declaração de `três partes`, sendo elas: inicialização de uma variável, condição e atualização da variável. A separação de cada uma das partes é feita pelo símbolo `;`:

``` C#
using System;

namespace RepeatingStructures
{
  class Program
  {
    static void Main(string[] args)
    {
      // contando de 0 a 9
      for (int i = 0; i < 10; i++)
      {
        Console.WriteLine(i);
      }

      Console.Read();
    }
  }
}
```

#### Estrutura while

Com uma sintaxe diferente do for, a estrutura `while` necessita apenas da declaração da condição. É uma condição mais simples de entender, porém requer mais linhas de código em comparação com a estrutura for:

``` C#
using System;

namespace RepeatingStructures
{
  class Program
  {
    static void Main(string[] args)
    {
      // contando de 0 a 9
      int i = 0;
      while (i < 10)
      {
        Console.WriteLine(i);
        i++;
      }

      Console.Read();
    }
  }
}
```

#### Estrutura do...while

Essaestrutura é uma variação da estrutura while, a diferença é que a condição é verificada após a execução do bloco de código:

``` C#
using System;

namespace RepeatingStructures
{
  class Program
  {
    static void Main(string[] args)
    {
      // contando de 0 a 9
      int i = 0;
      do
      {
        Console.WriteLine(i);
        i++;
      } while (i < 10);

      Console.Read();
    }
  }
}
```

#### Estrutura foreach

O `foreach` é uma estrutura de laço utilizada basicamente para `percorrer arrays`, `lista` e `coleção`. Pode ser considerado uma forma resumida do for para percorrer dados em uma lista:

``` C#
using System;

namespace RepeatingStructures
{
  class Program
  {
    static void Main(string[] args)
    {
      string[] list = { "Fiap", "Fiap On", "Avanade", "Microsoft" };

      foreach (var item in list)
      {
        Console.WriteLine(item);
      }

      Console.Read();
    }
  }
}
```

### Orientação a objeto

#### Classe e objeto

A definição para Classe é um conjunto de objetos com as mesmas características, formado de propriedades e comportamentos por meio dos seus métodos. Podemos pensar em uma classe, como a forma de organizar o código e o nosso sistema.

O objeto, também conhecido como `instância` de uma classe, é responsável por armazenar os conteúdos de suas `propriedades` e executar comportamento e ações por meio de seus `métodos`.

Exemplo:

Vamos imaginar a necessidade de criação de uma aplicação para controlar cursos.Para cada curso,precisamos das seguintes informações: código, nome do curso, nome do instrutor, carga horária, quantidade mínima e máxima de alunos. Essas informações compõemo nosso modelo de curso para o nosso sistema.

Uma classe na linguagem C# é criada a partir da descrição dos modificadores de acesso,acrescidada palavra `class` e do nome da classe.

```
[modificador de acesso] class [NomeDaClasse] { }
```

