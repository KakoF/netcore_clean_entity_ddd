No diretório do projeto, criei a pasta src

DENTRO DE SRC...


-----------------------------------------------------------------------------------------------------------
- Primeiro passo, criar a solution:
(A solution é apenas um container de um ou mais projetos relacionados, juntamente com a informação de Build)

* dotnet new --name <NomeSolution>

------------------------------------------------------------------------------------------------------------

- Segundo passo, criar a Web Api(webapi):

* dotnet new webapi -n application -o Api.Application --no-https
(-n name, -o output saida onde o projeto será criado, no-https não precisa do protocolo seguro no momento, caso subir a aplicação deve seta-lo que sim posteriormente)

* dotnet sln add Api.Application
(Após criar o projeto, precisa-se adicionar a api na solution)


------------------------------------------------------------------------------------------------------------

- Terceiro passo, criar o Domain(classlib):

* dotnet new classlib -n Domain -o Api.Domain -f netcoreapp3.1  
(-n name, -o output saida onde o projeto será criado, -f qual versão do framework eu quero utilizar)

* dotnet sln add Api.Domain
(Após criar o projeto, precisa-se adicionar a api na solution)


------------------------------------------------------------------------------------------------------------

- Quarto passo, criar o CrossCutting(classlib "corte cruzado" projeto que pode ter chamada para api de terceiros):

* dotnet new classlib -n CrossCutting -o Api.CrossCutting -f netcoreapp3.1  
(-n name, -o output saida onde o projeto será criado, -f qual versão do framework eu quero utilizar)

* dotnet sln add Api.CrossCutting
(Após criar o projeto, precisa-se adicionar a api na solution)


------------------------------------------------------------------------------------------------------------

- Quinto passo, criar o Data(classlib):

* dotnet new classlib -n Data -o Api.Data -f netcoreapp3.1  
(-n name, -o output saida onde o projeto será criado, -f qual versão do framework eu quero utilizar)

* dotnet sln add Api.Data
(Após criar o projeto, precisa-se adicionar a api na solution)


------------------------------------------------------------------------------------------------------------

- Sexto passo, criar o Service(classlib):

* dotnet new classlib -n Service -o Api.Service -f netcoreapp3.1  
(-n name, -o output saida onde o projeto será criado, -f qual versão do framework eu quero utilizar)

* dotnet sln add Api.Service
(Após criar o projeto, precisa-se adicionar a api na solution)
