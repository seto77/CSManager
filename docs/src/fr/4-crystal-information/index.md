---
title: Informations cristallines
---

# Informations cristallines

La zone des informations cristallines (le contrôle `Crystal Information`) affiche et permet de modifier les paramètres de maille, la symétrie, les positions atomiques, les références, etc. du cristal sélectionné. Vous pouvez également charger n'importe quel cristal en faisant glisser-déposer un fichier CIF ou AMC sur cette zone.

!!! warning "Validez les modifications avec `Ajouter` / `Remplacer`"
    Si vous apportez des modifications à un cristal, veillez à appuyer sur le bouton `Ajouter` ou `Remplacer`. À défaut, les modifications ne seront pas enregistrées dans la liste des cristaux et seront perdues.

En haut sont affichées les informations communes telles que le nom du cristal (`Name`) et la composition chimique (`Formula`), et `Reset` permet de réinitialiser toutes les informations du cristal. En bas se trouvent des onglets permettant de configurer la symétrie, les atomes, les références, etc.

## Onglets

- [Informations de base](1-basic-information.md) — paramètres de maille, symétrie, volume, densité, etc. (onglet `Infos de base`)
- [Atomes](2-atoms.md) — positions atomiques, taux d'occupation, facteurs de température, facteurs de diffusion (onglet `Infos atome`)
- [Liaisons et polyèdres de coordination](3-bonds-polyhedra.md) — réglages d'affichage des liaisons et des polyèdres de coordination (onglet `Liaisons & polyèdres`)
- [Références](4-references.md) — informations bibliographiques citées (onglet `Réf.`)

## Menu contextuel

Un clic droit sur une zone vide du contrôle permet d'effectuer les opérations suivantes.

- `Importer depuis CIF ou AMC...` — importe une structure cristalline au format CIF / AMC.
- `Exporter en CIF` — exporte le cristal actuel au format CIF.
- `Send this crystal to other software` — envoie le cristal sélectionné vers PDIndexer, ReciPro, etc.
- `Informations de symétrie` — ouvre une fenêtre détaillée sur la symétrie (numéro d'ordre du groupe d'espace, groupe de Laue et groupe ponctuel, règles d'apparition, position de Wyckoff, calculs géométriques des plans cristallins et des axes de zone, etc.).
- `Rétablir les paramètres de maille` — rétablit les paramètres de maille aux valeurs présentes juste après le chargement.
- `Convertir en groupe d'espace P1` / `Convertir en surstructure` / `Modifier le réglage des axes/de l'origine` — effectuent des transformations du groupe d'espace ou du réseau.
