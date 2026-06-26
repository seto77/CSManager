# Pesquisa

No painel de pesquisa, é possível filtrar o banco de dados de cristais carregado por diversos critérios. Ative a caixa de seleção do critério desejado, insira o valor e pressione o botão `Pesquisar` ou a tecla Enter para executar a pesquisa. Vários critérios podem ser especificados ao mesmo tempo.

## Critérios de pesquisa

- `Name` — pesquisa pelo nome do cristal.
- `Elementos` — ao pressionar o botão `Tabela Periódica`, abre-se uma janela separada na qual é possível selecionar os elementos a pesquisar. Cada botão de elemento alterna seu estado a cada clique (pode incluir / deve incluir / deve excluir). Os botões "may or not include" / "must include" / "must exclude" na parte superior da janela permitem alternar de uma só vez o estado de todos os elementos.
- `Referência` — pesquisa por informações bibliográficas, como nome do artigo, nome da revista ou nome dos autores.
- `Sistema Cristalino` — filtra por sistema cristalino.
- `Parâm. célula` — especifica as constantes de célula e a faixa de tolerância. Os itens cuja tolerância for igual a zero são ignorados.
- `Distância d` — especifica o valor d (espaçamento interplanar) dos planos do cristal e a faixa de tolerância, e pesquisa os cristais que possuem valores d dentro dessa faixa. Quando `Ignorar fator de dispersão` está ativado, a intensidade de difração (fator de estrutura cristalina) não é considerada, e a pesquisa inclui também os planos do cristal que violam as regras de extinção. Quando desativado, o fator de estrutura cristalina é considerado e a pesquisa abrange apenas os 20 planos de maior intensidade.
- `Densidade` — especifica a densidade e a faixa de tolerância.
