# Átomos

Na aba `Info. de átomos`, exibem-se e configuram-se as informações dos átomos contidos no cristal. A lista de átomos é exibida na parte superior e, ao clicar em cada átomo, suas informações detalhadas são exibidas na parte inferior.

!!! warning
    Após editar um átomo, pressione o botão `Add` ou `Replace`. Caso contrário, as informações do átomo não serão salvas na lista.

## Operações da lista de átomos

- `Add` — adiciona o átomo configurado como novo item na lista.
- `Replace` — substitui o átomo atualmente selecionado pelo átomo configurado.
- `Up` / `Down` — move a posição do átomo selecionado para cima ou para baixo.
- `Delete` — exclui o átomo selecionado da lista.

## Elemento e posição

- `Label` — insere o rótulo do átomo.
- `Element` — define o elemento.
- `X`, `Y`, `Z` — define as coordenadas fracionárias do átomo. Insira números reais de 0 a 1. Frações como 1/2 ou 2/3 também podem ser inseridas.
- `Occ` — especifica a ocupação como um número real de 0 a 1.

Em **Origin shift**, é possível deslocar a posição da origem com botões de predefinição ou com qualquer valor.

## Fator de temperatura (Debye-Waller factor)

- **Notation** — selecione `U` ou `B`.
- **Model** — selecione isotrópico (Isotropy) ou anisotrópico (Anisotropy).
- Insira cada componente do fator de temperatura (`B##` ou `U##`).

## Fator de dispersão (Scattering factor)

Configura a valência e a composição isotópica usadas no cálculo do fator de dispersão atômico.

- **X-ray** — seleciona a valência usada no cálculo do fator de dispersão atômico elástico para raios X. Os parâmetros baseiam-se em *International Tables for Crystallography volume C*.
- **Electron** — seleciona a valência do fator de dispersão atômico elástico para feixe de elétrons. Os parâmetros baseiam-se em Peng (1998, *Acta Cryst.* A54, 481-485).
- **Neutron** — seleciona a composição isotópica para calcular o comprimento de espalhamento elástico de nêutrons. É possível escolher `Natural isotope abundance` (abundância isotópica natural) ou `Custom isotope abundance` (definição personalizada).
