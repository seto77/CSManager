# Solução de problemas

Reunimos aqui problemas comuns e suas soluções.

- **Não inicia / o runtime do .NET não é encontrado** — a execução do CSManager requer o **.NET Desktop Runtime 8** ou superior. Se não estiver instalado, obtenha-o na página de distribuição da Microsoft.
- **Falha ao carregar o COD** — `Ler banco de dados COD (### cristais)` baixa, na primeira vez, um arquivo grande (mais de 800 MB) da internet. Verifique a conexão de rede e o espaço livre em disco e tente novamente mais tarde.
- **Não é possível abrir o arquivo de banco de dados** — verifique se o arquivo `*.cdb3` não está corrompido, foi movido ou foi salvo em outra versão. Ao usar o AMCSD / COD diretamente, é possível recarregá-los por `Ler banco de dados AMCSD (### cristais)` / `Ler banco de dados COD (### cristais)`.
- **Desempenho lento com bancos de dados grandes** — em bancos de dados de grande escala, como o COD, a pesquisa e o carregamento podem demorar. Filtre pelos critérios necessários antes de operar.
- **Não é possível integrar com o PDIndexer / ReciPro** — verifique se o software de destino está em execução. A transferência automática na seleção é feita por meio da área de transferência (consulte [Interação com outros softwares](6-interoperation.md)).

Relate problemas não listados aqui na página de [Issues](https://github.com/seto77/CSManager/issues) no GitHub.
