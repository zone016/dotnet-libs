# As bibliotecas para dotnet (e nativo) da Área 16

[![Última *release*](https://github.com/zone016/dotnet-libs/actions/workflows/publish.yml/badge.svg?event=push)](https://github.com/zone016/dotnet-libs/actions/workflows/publish.yml)

Diferente do seu repositório de mesmo propósito, [py-libs](https://github.com/zone016/py-libs), este também suporta builds nativas para Windows, Linux e macOS (algumas coisas embarcadas também serão suportadas). Já agradeçeu a comunidade dotnet pelo AOT hoje?

No geral, você sempre vai precisar da última LTS do dotnet SDK/runtime disponível em seu host caso utilize em builds intermediárias.

## Bibliotecas

Não vamos listar aqui coisas de teste, então segue a lista:

| **Namespace**                                     | **Descrição**                                                                                   |
| ------------------------------------------------- | ----------------------------------------------------------------------------------------------- |
| [`Zone016.Nexus`](./Zone016.Nexus)                | Cliente minimalista da API do [Nexus OSS](https://www.sonatype.com/products/sonatype-nexus-oss) |
| [`Zone016.Nexus.Schema`](./Zone016.Nexus.Schema/) | Esquemas de dados para o cliente do Nexus OSS                                                   |
| [`Zone016.Printer`](./Zone016.Printer/)           | Uma forma menos ruim de lidar com _stdout_ e _stderr_                                           |
| [`Zone016.Process`](./Zone016.Process/)           | Abstrações para processos e execução de comandos                                                |
| [`Zone016.Project`](./Zone016.Project/)           | Coisas para lidar com projetos dotnet e suas particularidades                                   |
| [`Zone016.Reflector`](./Zone016.Reflector/)       | Uma DSL para reflexão de tipos e objetos                                                        |
| [`Zone016.Boxer`](./Zone016.Boxer/)               | Cliente para APIs de coisas de CTF                                                              |

## Adicionando ao seu projeto

Utilizamos o [GitHub Packages](https://github.com/features/packages) para distribuir nossas bibliotecas e ferramentas de linha de comando, então você precisa seguir [as instruções de autenticação e configuração](https://docs.github.com/en/packages/working-with-a-github-packages-registry/working-with-the-nuget-registry#authenticating-to-github-packages) de pacotes do GitHub para adicionar nossos pacotes ao seu projeto.

> **Nota**: Você precisa de um token de acesso pessoal com permissões de leitura de pacotes para adicionar nossos pacotes ao seu projeto. E não tem uma outra forma de fazer isso.

Caso tenha algum problema ou dúvida, abra uma _issue_ e vamos te ajudar.

## Colaborando

É utilizado o `dotnet-tools` para gerenciar as ferramentas necessárias para desenvolvimento, então a primeira coisa que você precisa fazer é rodar o comando `dotnet tool restore` na raiz do repositório. _Pull-requests_ são muito bem vindas, desde que você tenha certeza de estar usando nosso pre-commit hook para garantir a qualidade do código com o `dotnet-format`. Somente interações assinadas são aceitas.

## Licença

Todas as bibliotecas e qualquer outro artefato desse repositório são licenciados sob a [licença MIT](https://github.com/zone016/dotnet-libs/blob/main/LICENSE.txt), a menos que especificado de outra forma.
