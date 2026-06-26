# Atomes

L'onglet `Infos atome` affiche et permet de configurer les informations relatives aux atomes contenus dans le cristal. La liste des atomes s'affiche dans la partie supérieure ; un clic sur un atome affiche ses informations détaillées dans la partie inférieure.

!!! warning
    Après avoir modifié un atome, appuyez sur le bouton `Add` ou `Replace`. À défaut, les informations de l'atome ne seront pas enregistrées dans la liste.

## Opérations sur la liste des atomes

- `Add` — ajoute le nouvel atome configuré à la liste.
- `Replace` — remplace l'atome actuellement sélectionné par l'atome configuré.
- `Up` / `Down` — déplace l'atome sélectionné vers le haut ou le bas dans l'ordre.
- `Delete` — supprime l'atome sélectionné de la liste.

## Élément et position

- `Label` — saisissez l'étiquette de l'atome.
- `Element` — configurez l'élément.
- `X`, `Y`, `Z` — configurez les coordonnées fractionnaires de l'atome. Saisissez un nombre réel compris entre 0 et 1. Des fractions telles que 1/2 ou 2/3 peuvent également être saisies.
- `Occ` — spécifiez le taux d'occupation par un nombre réel compris entre 0 et 1.

**Origin shift** permet de décaler la position de l'origine à l'aide de boutons prédéfinis ou d'une valeur quelconque.

## Facteur de température (Debye-Waller factor)

- **Notation** — sélectionnez `U` ou `B`.
- **Model** — sélectionnez isotrope (Isotropy) ou anisotrope (Anisotropy).
- Saisissez chaque composante du facteur de température (`B##` ou `U##`).

## Facteur de diffusion (Scattering factor)

Configurez la valence et la composition isotopique utilisées lors du calcul du facteur de diffusion atomique.

- **X-ray** — sélectionnez la valence utilisée pour le calcul du facteur de diffusion atomique élastique pour les rayons X. Les paramètres sont fondés sur *International Tables for Crystallography volume C*.
- **Electron** — sélectionnez la valence du facteur de diffusion atomique élastique pour les électrons. Les paramètres sont fondés sur Peng (1998, *Acta Cryst.* A54, 481-485).
- **Neutron** — sélectionnez la composition isotopique pour le calcul de la longueur de diffusion élastique des neutrons. Vous pouvez choisir `Natural isotope abundance` (abondance isotopique naturelle) ou `Custom isotope abundance` (réglage personnalisé).
