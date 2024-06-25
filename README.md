# As bibliotecas para dotnet (e nativo) da Área 16

[![Última *release*](https://github.com/zone016/dotnet-libs/actions/workflows/publish.yml/badge.svg?event=push)](https://github.com/zone016/dotnet-libs/actions/workflows/publish.yml)

Diferente do seu repositório de mesmo propósito, [py-libs](https://github.com/zone016/py-libs), este também suporta builds nativas para Windows, Linux e macOS (algumas coisas embarcadas também serão suportadas). Já agradeçeu a comunidade dotnet pelo AOT hoje?

No geral, você sempre vai precisar da última LTS do dotnet SDK/runtime disponível em seu host caso utilize em builds intermediárias.

## Bibliotecas

Existe muitas bibliotecas aqui, e um dia eu espero sinceramente ter tudo documentado. Por enquanto te desejo boa sorte.

> Não considere nenhum pacote aqui como estável, a menos que esteja marcado como tal. Ainda que marcado como estável, não é garantido que não haja bugs.

## Adicionando ao seu projeto

Utilizamos o [GitHub Packages](https://github.com/features/packages) para distribuir nossas bibliotecas e ferramentas de linha de comando, então você precisa seguir [as instruções de autenticação e configuração](https://docs.github.com/en/packages/working-with-a-github-packages-registry/working-with-the-nuget-registry#authenticating-to-github-packages) de pacotes do GitHub para adicionar nossos pacotes ao seu projeto.

> **Nota**: Você precisa de um token de acesso pessoal com permissões de leitura de pacotes para adicionar nossos pacotes ao seu projeto. E não tem uma outra forma de fazer isso.

Caso tenha algum problema ou dúvida, abra uma *issue* e vamos te ajudar.

## Colaborando

É utilizado o `dotnet-tools` para gerenciar as ferramentas necessárias para desenvolvimento, então a primeira coisa que você precisa fazer é rodar o comando `dotnet tool restore` na raiz do repositório. *Pull-requests* são muito bem vindas, desde que você tenha certeza de estar usando nosso pre-commit hook para garantir a qualidade do código com o `dotnet-format`. Somente interações assinadas são aceitas.

## Licença

Todas as bibliotecas e qualquer outro artefato desse repositório são licenciados sob a [licença MIT](https://github.com/zone016/dotnet-libs/blob/main/LICENSE.txt), a menos que especificado de outra forma.
