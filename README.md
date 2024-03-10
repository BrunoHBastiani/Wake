# API de Produtos - WAKE

API documentada com o SWAGGER

<br>![Imagem da API](WakeProducts.jpg)<br>

### Requisitos para executar o projeto no Windows:

* Visual Studio
    * https://visualstudio.microsoft.com/pt-br/downloads/
* GIT 
    * https://git-scm.com/download/win
* Docker (Docker Desktop, WSL, etc. No meu caso, estou usando docker desktop) 
    * https://www.docker.com/products/docker-desktop/
* SGBD Postgres de sua preferência. No meu caso, estou usando o Beekeeper
    * https://www.beekeeperstudio.io/get

## Inicializando o Projeto

Escolha um diretório de sua preferência e clone o projeto.
```
git clone https://github.com/BrunoHBastiani/Wake.git
```

Garanta que o docker está em execução para os próximos passos:

1. Rode o comando `docker-compose up -d` na raiz da solução, onde é encontrado o arquivo docker-compose.yml
2. Coloque o projeto **Wake.Products.Data** como Projeto de Inicialização
3. Abra o Package Manager Console no Visual Studio com o **Wake.Products.Data** como projeto padrão
4. Rode o comando **Update-Database** para que seja aplicada a migration no banco de dados
5. Coloque o projeto **Wake.Products.API** como Projeto de Inicialização
6. Rode o projeto utilizando HTTPS

Para validar se tudo deu certo, a API deve buildar e iniciar sem erros, e você conseguirá conectar com o banco de dados utilizando essas credenciais:

      USER: admin
      PASSWORD: admin
      DATABASE: wakedb

## Decisões de desenvolvimento do Projeto

Esse projeto foi desenvolvido idealizando um cenário real, onde me imaginei desenvolvendo um sistema para um e-commerce para decidir qual arquitetura, padrões de projeto e outras caracteristicas de projeto eu iria usar.
A partir deste cenário, adicionei alguma complexidade ao projeto para que pudesse simular cenários de pico de uso do sistema, como ocorre na black friday, por exemplo.

Tendo isso em mente, optei por seguir com a Arquitetura Limpa, onde o foco da aplicação é no domínio, onde as camadas internas desconhecem as camadas externas. Também segui os princípios SOLID e alguns princípios do DDD, como domínios ricos, para uma melhor organização e para separar corretamente o que é uma complexidade de negócio e o que é uma complexidade técnica,  e utilizando padrões de desenvolvimento simples como o repository para desacoplar e abstrair o banco de dados.

Uma alternativa interessante para esse caso, seria utilizar o padrão arquitetural CQRS, onde a camada de dados é segregada em Commands (modificações no banco de dados) e Queries (buscas no banco de dados), pois além de evitar a bagunça da camada de dados no código durante a sua evolução, também é possível utilizar um banco de dados e/ou um ORM diferente para cada uma das duas camadas propostas. Neste caso, utilizaria o DAPPER como ORM na camada de busca e ter a liberdade de otimizar as consultas, pois poderia trazer um desempenho melhor em nesse cenário crítico.

Também desenvolvi esse projeto pensando em uma possível migração para microsserviços. Portanto, desenvolvi a API com separação em módulo totalmente desacoplada de qualquer outra API que possa ser criada futuramente na evolução do produto.


![Clean Architecture Image.](https://miro.medium.com/v2/resize:fit:1400/0*iU9Ks05_GTtGh6zV.jpg "Clean Architecture Image.")

## Entity Framework e .NET

Projeto desenvolvido com EF Core e .NET 8.0, utilizando Code First, onde eu modelo minhas entidades e mapeio elas informando o nome que devem ter na base e algumas outras caracteristicas, e a partir delas, o EF Core gera o banco de dados.
Utilizei o code first para criar a base já populada com cinco produtos.

## Explicação dos Projetos

**Minha solução está dividida em 4 camadas:**

* **Application**
    * Esta camada representa lógica de aplicação, responsável pelas funcionalidades do sistema. 
* **Domain**
    * Esta camada representa o núcleo da minha aplicação, onde estão centralizadas as principais entidades e lógica de negócio da minha aplicação
* **Infrastructure**
    * Esta camada representa as informações de infraestrutura do sistema, bem como configurações de ambiente e serviços externos. Utilizei essa camada para a configuração do meu banco de dados e repositories
* **Web**
    * Esta camada representa a apresentação, onde o usuário interage com direta ou indiretamente com o sistema. Utilizei essa camada para a implementação da minha API de produtos 

**Também criei dois projetos para demonstrar alguns testes simples:**

* **Wake.Products.UnitTests**
    * Responsável por testar as lógicas de negócio e de aplicação, bem como as unidades dentro do sistema
* **Wake.Products.IntegrationTests**
    * Responsável por testar as integrações do sistema, como a integração das funcionalidades da API, como a integração e funcionalidades voltadas para o banco de dados.

## GitHub Actions

Gatilho do workflow foi configurado para rodar sempre que é feito um "push" na master. Está configurado para realizar o build da aplicação e rodar os testes unitários e de integração, sempre usando .NET 8.0.x
