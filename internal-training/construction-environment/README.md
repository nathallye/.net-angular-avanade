# C#, .NET & AngularJS

Estudos sobre C#, .NET & AngularJS.

## Passo a passo de ambientação

1. Baixar extensão no VSCODE: Angular Language Service

Link: https://marketplace.visualstudio.com/items?itemName=Angular.ng-template

2. Baixar extensão no VSCODE: angular2-inline

Link: https://marketplace.visualstudio.com/items?itemName=natewallace.angular2-inline

3. Baixar o SQL Server Management Studio (SSMS)

Link: https://learn.microsoft.com/pt-br/sql/ssms/download-sql-server-management-studio-ssms?view=sql-server-ver16

Link para baixar direto: https://aka.ms/ssmsfullsetup

4. Baixar o Visual Studio Community

Link: https://visualstudio.microsoft.com/pt-br/free-developer-offers/

E nele as Cargas de Trabalho que iremos usar:

![image](https://user-images.githubusercontent.com/86172286/203126144-9cfb3927-51f7-4177-b8ba-ea0b424c07e7.png)

E os Componentes Individuais:

![image](https://user-images.githubusercontent.com/86172286/203127574-7b50c7c0-22b6-4818-94b3-9189d88ae362.png)

Feito isso, podemos instalar.

## Criação de um serviço de Banco de Dados SQL no Azure

- Primeiramente, vamos na tela principal do portal do Azure em `Azure services(Serviços do Azure)` > `SQL servers(Servidor SQL)`:

![1 1](https://user-images.githubusercontent.com/86172286/203431702-d4dfda43-b201-4648-aa5d-5107f061e3d7.jpg)

- Se o `SQL servers(Servidor SQL)` não aparecer nos serviços recentes, podemos buscá-lo na caixa de pesquisa acima:

![1 2](https://user-images.githubusercontent.com/86172286/203432036-fc6bbfc1-e439-4e0b-88ad-a546788bae1d.jpg)

![1 3](https://user-images.githubusercontent.com/86172286/203432212-80d1d183-abca-4760-8c8f-8a98c26b3f32.jpg)

- Feito isso, vamos clicar nele e em seguida no botão `Create(Criar)`:

![2](https://user-images.githubusercontent.com/86172286/203433284-62681373-d2f1-4730-a3ea-15e27b9c42cf.jpg)

### Project details(Detalhes do projeto)

- Na tela de criação do servidor de banco de dados SQL, primeiramente vamos criar um novo `Resource group(Grupo de recursos)` indo em `Create new(Criar novo)`:

![3](https://user-images.githubusercontent.com/86172286/203434927-fdabf47a-9738-45fe-932c-dee607e5dfbd.jpg)

- Inserindo o nome desse novo grupo de recurso podemos clicar em `OK` para selecioná-lo:

![5](https://user-images.githubusercontent.com/86172286/203434365-30ba13af-1c31-49ab-a7ab-f6c1da14f83f.jpg)

### Server details(Detalhes do servidor)

- Após isso, em `Server name(Nome do Servidor)` vamos atribuir um nome a esse servidor SQL:

![7](https://user-images.githubusercontent.com/86172286/203435131-fb363305-482f-47e6-b1d3-a30dfb64e0d5.jpg)

- Em seguida, em `Location(Localização)` iremos selecionar a região desse servidor SQL:

![8](https://user-images.githubusercontent.com/86172286/203435917-edeb411c-607e-4cbe-aa59-d47ce7355c52.jpg)

![9](https://user-images.githubusercontent.com/86172286/203435931-c5b6c323-8e54-46d7-a1de-f5226b8e4404.jpg)

### Authentication(Autenticação)

- Concluindo, iremos definir o `Authentication method(Método de autenticação)` para acessar esse servidor SQL. Nesse caso, iremos usar o método `SQL authentication(autenticação SQL)`, ao selecionarmos esse método será necessário criar o `Server admin login(Login do administrador do servidor)` e o `Password(Senha)`:

![10](https://user-images.githubusercontent.com/86172286/203437122-72e79be8-9e58-49a7-abf3-361852ec20a6.jpg)

- Feito isso, podemos clicar no botão abaixo `Review + create(Revisar + criar)`. Será exibida uma tela com o resumo das informações desse servidor antes de criar, e para finalizar podemos clicar em `Create(Criar)`.

- Ao finalizar a criação do nosso Servidor SQL podemos acessá-lo indo em `Go to resource(Ir para o recurso)`:

![13](https://user-images.githubusercontent.com/86172286/203437803-dc7bbab3-c79e-4da9-a27f-2eeba0e693d8.jpg)

### Acessando o servidor criado

- Nessa tela conseguimos as informações necessárias para acessar esse servidor na nossa máquina via `SQL Server Management Studio`:

![14](https://user-images.githubusercontent.com/86172286/203438106-1438a854-f241-4018-a760-b05ed892f1ea.jpg)

- Para isso, vamos abrir o `Microsoft SQL Server Management Studio` e inserir as informações do nosso servidor SQL criado no Azure:

<img width="800" src="https://user-images.githubusercontent.com/86172286/203438437-3bcd2b96-c674-4c31-8ae7-33f04aa01ff6.jpg">

- Vamos receber um aviso que o nosso IP não tem acesso ao servidor. Para abtermos o acesso vamos em `Sign In...` e na janela do navegador que irá abrir vamos acessar nossa conta do Azure, feito isso conseguimos permitir o acesso desse endereço IP no nosso servidor:

<img width="800" src="https://user-images.githubusercontent.com/86172286/203438931-57d46e71-39d3-4d0a-9106-e9a8b52ec7a4.jpg">

<img width="800" src="https://user-images.githubusercontent.com/86172286/203438947-dbf2607a-e9e2-430c-9668-81335e15ff4d.jpg">



