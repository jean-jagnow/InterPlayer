# InterPlayer API

### Sobre
Este é um projeto de teste para validação de **Senhas** via **API**.

### Pré-requisitos

* [.NET 6.0 SDK](https://dotnet.microsoft.com/download/dotnet/6.0)
* Visual Studio

Foi utilizado a versão do `.NET 6` incluindo pactotes auxiliares:

* [FluentValidation](https://fluentvalidation.net)
* [MediatR](https://github.com/jbogard/MediatR)
* [Swashbuckle](https://github.com/domaindrivendev/Swashbuckle.AspNetCore)


### Estrutura
>InterPlayer.Core 

>InterPlayer.Application

>WebAPI

>InterPlayer.Core.Tests

### Como rodar

~~~
> git clone https://github.com/jean-jagnow/InterPlayer
> cd InterPlayer
> dotnet restore
> dotnet build
> cd src\WebAPI
> dotnet run
~~~

