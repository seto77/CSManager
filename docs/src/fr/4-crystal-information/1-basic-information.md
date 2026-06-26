# Informations de base

L'onglet `Infos de base` affiche et permet de configurer les paramètres de maille et la symétrie du cristal.

## Paramètres de maille et symétrie

- **Cell constants** — affiche et permet de configurer les paramètres de maille. L'unité de longueur est l'Å (10⁻¹⁰ m). Lorsque la symétrie spécifiée impose des contraintes sur les paramètres de maille (par exemple, pour un cristal cubique : a = b = c, α = β = γ = 90°), ils sont reconfigurés automatiquement.
- **Symmetry** — configure la symétrie de manière hiérarchique. Vous spécifiez le `Crystal system` (système cristallin), le `Point group` (groupe ponctuel) et le `Space group` (groupe d'espace). Faites attention au réglage des axes pour le groupe d'espace. Si vous saisissez une chaîne de groupe d'espace dans `Search`, les candidats s'affichent dans la liste de droite (la casse est prise en compte).

## Valeurs calculées

Si les informations atomiques sont renseignées, les valeurs suivantes sont calculées et affichées.

- **Cell Volume** — le volume de la maille élémentaire.
- **Cell Mass** — la masse de la maille élémentaire.
- **Molar Volume** / **Molar Mass** — le volume et la masse par mole.
- **Z** — le nombre de formules unitaires contenues dans la maille élémentaire.
- **Density** — la densité.
- **Color of Profile** — la couleur de tracé des pics de diffraction. Un clic ouvre une fenêtre de configuration de la couleur.

Des informations de symétrie plus détaillées (différentes notations du groupe de Laue et du groupe ponctuel, règles d'apparition, position de Wyckoff, calculs géométriques des plans cristallins et des axes de zone) sont accessibles via `Informations de symétrie` dans le menu contextuel.
