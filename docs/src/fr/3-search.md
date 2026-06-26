# Recherche

Le panneau de recherche permet de filtrer la base de données cristalline chargée selon divers critères. Activez la case à cocher du critère souhaité, saisissez une valeur, puis appuyez sur le bouton `Rechercher` ou sur la touche Entrée pour exécuter la recherche. Plusieurs critères peuvent être spécifiés simultanément.

## Critères de recherche

- `Name` — recherche par nom de cristal.
- `Éléments` — l'appui sur le bouton `Tableau périodique` ouvre une fenêtre distincte permettant de sélectionner les éléments à rechercher. Chaque bouton d'élément change d'état à chaque appui (peut être inclus / doit être inclus / doit être exclu). Les boutons « may or not include » / « must include » / « must exclude » en haut de la fenêtre permettent de modifier l'état de tous les éléments en une seule fois.
- `Référence` — recherche à partir des informations bibliographiques telles que le titre de l'article, le nom de la revue ou les noms des auteurs.
- `Système cristallin` — filtre par système cristallin.
- `Param. de maille` — spécifie les paramètres de maille et une tolérance. Les éléments pour lesquels une tolérance nulle est saisie sont ignorés.
- `Distances d` — spécifie la distance d (espacement interréticulaire) d'un plan cristallin et une tolérance, puis recherche les cristaux possédant une distance d comprise dans cette plage. Si `Ignorer le facteur de diffusion` est activé, la recherche s'effectue sans tenir compte de l'intensité de diffraction (facteur de structure), en incluant les plans cristallins en violation des règles d'extinction. Dans le cas contraire, le facteur de structure est pris en compte et la recherche ne porte que sur les 20 plans cristallins d'intensité la plus élevée.
- `Densité` — spécifie la densité et une tolérance.
