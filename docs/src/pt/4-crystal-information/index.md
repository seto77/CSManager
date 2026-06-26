---
title: Informações do cristal
---

# Informações do cristal

Na área de informações do cristal (controle `Crystal Information`), exibem-se e editam-se as constantes de célula, a simetria, as posições atômicas, as referências e outros dados do cristal selecionado. Também é possível carregar qualquer cristal arrastando e soltando um arquivo CIF ou AMC nessa área.

!!! warning "Confirme as alterações com `Adicionar` / `Substituir`"
    Ao fazer alterações no cristal, pressione sempre o botão `Adicionar` ou `Substituir`. Caso contrário, as alterações não serão salvas na lista de cristais e se perderão.

Na parte superior, são exibidas informações comuns, como o nome do cristal (`Name`) e a composição química (`Formula`); com `Reset`, é possível redefinir todas as informações do cristal. Na parte inferior, há abas para configurar a simetria, os átomos, as referências e outros dados.

## Abas

- [Informações básicas](1-basic-information.md) — constantes de célula, simetria, volume, densidade etc. (aba `Info. básica`)
- [Átomos](2-atoms.md) — posições atômicas, ocupação, fatores de temperatura, fatores de dispersão (aba `Info. de átomos`)
- [Ligações e poliedros de coordenação](3-bonds-polyhedra.md) — configurações de desenho de ligações e poliedros de coordenação (aba `Ligações & Poliedros`)
- [Referências](4-references.md) — informações bibliográficas de citação (aba `Ref.`)

## Menu de contexto

Ao clicar com o botão direito em uma área vazia do controle, é possível realizar as seguintes operações.

- `Importar de CIF ou AMC...` — importa a estrutura cristalina nos formatos CIF / AMC.
- `Exportar para CIF` — exporta o cristal atual no formato CIF.
- `Send this crystal to other software` — envia o cristal selecionado para o PDIndexer, o ReciPro ou outros softwares.
- `Informação de simetria` — abre uma janela com detalhes sobre a simetria (número sequencial do grupo espacial, grupo de Laue e grupo pontual, regras de aparição, posições de Wyckoff, cálculos geométricos de planos do cristal e eixos de zona etc.).
- `Reverter constantes de célula` — restaura as constantes de célula aos valores existentes logo após o carregamento.
- `Converter para o grupo espacial P1` / `Converter em superestrutura` / `Alterar configuração de eixos/origem` — realizam conversões de grupo espacial ou de rede.
