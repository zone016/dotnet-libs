# As bibliotecas para dotnet (e nativo) da Área 16

Diferente do seu repositório de mesmo propósito, [py-libs](https://github.com/zone016/py-libs), este também suporta builds nativas para Windows, Linux e macOS (algumas coisas embarcadas também serão suportadas). No geral, você sempre vai precisar da última LTS do dotnet SDK disponível em seu host, bem como a versão mais recente não-preview.

> **Nota**: No momento, dotnet 8 (LTS) e 9 são utilizados.

É utilizado o `dotnet-tools` para gerenciar as ferramentas necessárias para desenvolvimento, então a primeira coisa que você precisa fazer é rodar o comando `dotnet tool restore` na raiz do repositório. *Pull-requests* são muito bem vindas, desde que você tenha certeza de estar usando nosso pre-commit hook para garantir a qualidade do código com o `dotnet-format`.

Todas as bibliotecas e qualquer outro artefato desse repositório são licenciados sob a [licença MIT](https://github.com/zone016/dotnet-libs/blob/main/LICENSE.txt), a menos que especificado de outra forma.
