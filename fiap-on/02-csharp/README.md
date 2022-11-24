# C#

## Introdução

O C# é uma linguagem simples, orientada a objetos, que combina a produtividade e o poder de linguagem, como C e C++. O fato de ser uma linguagem relativamente nova não apresenta problemas com documentação, pois oferece um grande acerto de documentos e exemplos on-line, além de livros, artigos, fóruns de discussões, blogs, repositórios de exemplos e outros materiais de referência. 

## Instruções básicas

### Tipos de variáveis

O Quadro Tipos primitivos mostra os tipos primitivos de variáveis do C#. Os tipos listados são conhecidos como tipos primitivos ou `value types`. Na linguagem C#, todas as variáveis e constantes são fortemente tipadas, toda declaração de método requer a especificação do tipo de cada parâmetro de entrada e também a especificação do tipo do retorno.

<div align='center'>
  <img width="700" src="https://user-images.githubusercontent.com/86172286/203656597-bfd833b5-c27c-44e5-adf9-ea87cfe36f6b.png">
</div>

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

<div align='center'>
  <img width="700" src="https://user-images.githubusercontent.com/86172286/203656648-5ccd65af-62d8-4cf7-9ba9-5fd6866dae1c.png">
</div>

Exemplos:

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
[modificador de acesso] class [NomeDaClasse] 
{

}
```

<div align='center'>
  <img width="700" src="https://user-images.githubusercontent.com/86172286/203656922-62f26f94-9e53-4ff7-817d-b9a326531612.png">
</div>

<div align='center'>
  <img width="700" src="https://user-images.githubusercontent.com/86172286/203656947-e34dbb90-9f54-428c-b451-044cec13d88a.png">
</div>

#### Atributos

As propriedades definidas na seção anterior (código, nome do curso, nome do instrutor, carga horária, quantidade mínima e máxima de alunos) serão transformadasem atributos da nossa classe. Os atributos serão os responsáveis por armazenar as informações do objeto. 

No código escrito para definir a classe, os atributos são declarados como variáveis, podendo ser do tipo de um outro objetoou tipo primitivo do C#. A declaração de um atributo é igual àdeclaração de uma variável, porém na boa prática de C#,os atributos devem ser escritos com a primeira letra em maiúsculo (UperCamelCase).

As variáveis que definem um atributo em uma classe são chamadas de variáveis de instância, pois só é possível armazenar informação nessa variável após a instanciação da Classe, ou seja, no objeto.

<div align='center'>
  <img width="700" src="https://user-images.githubusercontent.com/86172286/203667125-f4144b67-ec6f-4ee2-ab07-03896ebd24c3.png">
</div>

#### Métodos

São os responsáveis pela `execução das ações nos objetos`. Eles dão comportamento ao objeto e são executados ao receber uma mensagem em tempo de execução da classe.

Diferentemente da linguagem Java, em C# todo `método` deve ter seu nome ini`ciado com letra maiúscula`, assim como os atributos de uma classe. Todo o método tem acesso aos dados armazenados nas propriedades da instância, sendo capaz de controlá-los e alterá-los

Todos os métodos necessitam de quatro informações para sua implementação, são elas: `modificador de acesso`, `tipo de retorno`, `nome do método` e `argumentos` (não obrigatório).Para nossa classe Curso/`Course`, vamos elaborar o primeiro método que terá a responsabilidade de criar um novo curso. Esse método receberá o nome do curso e o nome do instrutor:

``` C#
using System;

namespace AppCourses
{
  public class Course
  {
    int Code;
    string NameCourse;
    string NameInstructor;
    int Workload;
    int MinStudents;
    int MaxStudents;

    public void CreateCourse(string name, string instructor)
    {
      this.NameCourse = name;
      this.NameInstructor = instructor;
    }
  }
}
```

A palavra reservada `void`, indica que esse método não retorna nenhuma informação depois da execução.

Agora temos a necessidade de criar dois novos métodos. O primeiro é responsável por matricular um aluno no curso. O segundo tem a função de recuperar a quantidade máxima de alunos aceitos pelo curso, assim, precisamos definir um tipo de dado que será retornado no método e também codificar o método para retornar ainformação necessária. 

O retorno de informações por um método é feito por meio da palavra reservada `return`:

``` C#
using System;

namespace AppCourses
{
  public class Course
  {
    int Code;
    string NameCourse;
    string NameInstructor;
    int Workload;
    int MinStudents;
    int MaxStudents;

    public void CreateCourse(string name, string instructor)
    {
      this.NameCourse = name;
      this.NameInstructor = instructor;
    }

    public bool EnrollStudent(int nameStudent)
    {
      // verificar a quantidade de alunos
      return true;
    }

    public int GetMaxStudents()
    {
      // Retorna o valor do atributo
      return this.MaxStudents;
    }
  }
}
```

#### Construtores

De forma resumida, um construtor é um método especial executado assim que uma nova instância da classe é criada. Na maioria dos casos, os construtores são responsáveis pela alocação de recursos e definição inicial dos atributos do objeto. 

Todas as classes possuem pelo menos um construtor. Caso o desenvolvedor não implemente nenhum construtor na classe, a linguagem cria o construtor-padrão ou `default`. Esse construtor não recebe nenhum parâmetro e não possui nenhum bloco de código implementado.

Existem três particularidades no construtor que o diferenciam de um método, são elas:
  - O construtor não tem especificação de retorno.
  - Não utiliza a palavra return, pois nunca retorna nenhum valor.
  - É obrigatório ter o mesmo nome da classe.

Para fixar o conhecimento, vamos adicionar alguns construtores à classe Curso/`Course`, com a ideia de inicializar os objetos com valores predefinidos.

<div align='center'>
  <img width="700" src="https://user-images.githubusercontent.com/86172286/203667067-979648df-6cd3-4b23-b27e-7a62648c1c0f.png">
</div>

Agora podemos criar objetos do tipo Curso/`Course` com três formas de instanciar a classe. 
A primeira delas foi mantida como padrão; a segunda podemos afirmar que substitui o método `CreateCourse` implementado nos exemplos anteriores; e, por fim, o terceiro construtor, que inicializa o objeto do tipo curso com nome e capacidades mínima e máxima já definidos.

``` C#
using System;
using AppCourses.Class;

namespace AppCourses
{
  class Program
  {
    static void Main(string[] args)
    {
      // Construtor padrão
      Course courseXamarin = new Course();
      courseXamarin.CreateCourse("Xamarin", "Flavio Moreni");

      // Definindo nome do curso e instrutor
      Course courseIonic = new Course("Ionic", "Antonio Coutinho");

      // Definindo nome do curso e capacidade mínima e máxima
      Course courseNode = new Course("Node.js", 5, 40);
    }
  }
}
```

#### Modificadores de acesso

O objetivo de se utilizar modificadores de acesso é prover segurança entre os componentes de um sistema. Os modificadores são palavras-chave que determinam o `nível de acesso` em `classes`, `construtores`, `métodos` e `propriedades`. 

A linguagem C# possui `cinco modificadores de acesso`, são eles: `public`, `protected internal`, `protected`, `internal` e `private`. Para cada tipo de objeto, o C# tem um modificador-padrão, ou seja, quando o desenvolvedor não declara nenhum modificador, o framework.NET define automaticamente os seguintes modificadores:
  - Classes – padrão `internal`.
  - Atributos de classe – padrão `private`.
  - Membros de estrutura – padrão `private`.
  - Namespace, interfaces e  e numeradores – padrão `public`, esses tipos não podem sofrer alteração nos modificadores, sempre serão públicos.

Além das definições de modificadores-padrão, cada modificador tem uma definição de acesso. O  quadro apresenta todos os modificadores, os  componentes que podem ser aplicados e os níveis de acesso permitidos:

<div align='center'>
  <img width="700" src="https://user-images.githubusercontent.com/86172286/203667017-51d2a069-c6a9-406e-938c-749865e57eda.png">
</div>

Para validar os modificadores e os acessos permitidos, vamos aplicar algumas alterações na classe Curso/`Course`. Nos atributos da classe, devemos aplicar cada um dos tipos do quadro; em um dos construtores, aplicaremos o modificador private, e assim faremos em cada um dos métodos:

``` C#
using System;

namespace AppCourses
{
  public class Course
  {
    int Code;
    internal string NameCourse;
    public string NameInstructor;
    private int Workload;
    protected int MinStudents;
    protected internal int MaxStudents;

    public Course()
    {
      // construtor padrão
    }

    protected internal Course(string name, string instructor)
    {
      this.NameCourse = name;
      this.NameInstructor = instructor;
    }

    public void CreateCourse(string name, string instructor)
    {
      this.NameCourse = name;
      this.NameInstructor = instructor;
    }

    private bool EnrollStudent(int nameStudent)
    {
      // verificar a quantidade de alunos
      return true;
    }

    private int GetMaxStudents()
    {
      // Retorna o valor do atributo
      return MaxStudents;
    }
  }
}
```

Com as alterações na classe `Course`, podemos usar nossa classe `Program.cs` para validar os acessos. Na classe Program.cs, vamos criar uma `instância` da classe Course e tentar acessar  todos os atributos:

``` C#
using System;
using AppCourses.Class;

namespace AppCourses
{
  class Program
  {
    static void Main(string[] args)
    {
      Course course1 = new Course();

      course1.Code = 1;
      course1.NameCourse = "Course";
      course1.NameInstructor = "Instructor";
      course1.Workload = 40;
      course1.MinStudents = 10;
      course1.MaxStudents = 50;
    }
  }
}
```

Podemos notar que três linhas ficaram sinalizadas e apresentam problemas de compilação. A razão desses problemas é a permissão de acesso que foi concedida aos atributos `Codigo/Code`, `CargaHoraria/Workload`e `MinimoAlunos/MinStudents`, impossibilitando o acesso pela classe Program.



Em seguida, vamos efetuar os testes com os construtores:

``` C#
using System;
using AppCourses.Class;

namespace AppCourses
{
  class Program
  {
    static void Main(string[] args)
    {
      Course course1 = new Course();

      course1.Code = 1;
      course1.NameCourse = "Course";
      course1.NameInstructor = "Instructor";
      course1.Workload = 40;
      course1.MinStudents = 10;
      course1.MaxStudents = 50;

      Course course2 = new Course("Course", "Instructor");
      Course course3 = new Course("Node.js", 5, 40);
    }
  }
}
```

Podemos notar que a instância `course3` apresenta erro, pois seu perfil de acesso foi declarado como `private`, assim, não é permitido o acesso de fora da classe `Course`.



Para finalizar, o último exemplo traz os acessos aos métodos:

``` C#
using System;
using AppCourses.Class;

namespace AppCourses
{
  class Program
  {
    static void Main(string[] args)
    {
      Course course1 = new Course();

      course1.Code = 1;
      course1.NameCourse = "Course";
      course1.NameInstructor = "Instructor";
      course1.Workload = 40;
      course1.MinStudents = 10;
      course1.MaxStudents = 50;

      course1.CreateCourse("name", "instructor");
      course1.EnrollStudent("student");
      course1.GetMaxStudents();

      Course course2 = new Course("Course", "Instructor");
      Course course3 = new Course("Node.js", 5, 40);
    }
  }
}
```

É possível notar que os métodos `MatricularAluno/EnrollStudent()` e `ConsultarMaximoAlunos/GetMaxStudents()` apresentam erro de acesso na chamada da classe Program.cs.



A forma fácil de corrigir esses problemas é declarando todos os atributos, construtores e métodos como públicos/`public`, assim não teremos mais problemas de acesso. 

Mas, muita atenção, essa estratégia é apenas para resolvermos os erros e continuar executando nossa aplicação. Projetos profissionais requerem níveis bem definidos de acesso aos componentes.