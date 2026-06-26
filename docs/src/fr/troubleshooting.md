# Dépannage

Voici un récapitulatif des problèmes courants et de leurs solutions.

- **Impossible de lancer / le runtime .NET est introuvable** — le fonctionnement de CSManager nécessite **.NET Desktop Runtime 8** ou une version ultérieure. S'il n'est pas installé, procurez-le-vous depuis la page de distribution de Microsoft.
- **Échec du chargement de COD** — `Lire la base COD (### cristaux)` télécharge lors du premier usage un fichier volumineux (plus de 800 Mo) depuis Internet. Vérifiez la connexion réseau et l'espace disque disponible, puis réessayez ultérieurement.
- **Impossible d'ouvrir le fichier de base de données** — vérifiez que le fichier `*.cdb3` n'est pas endommagé, déplacé ou enregistré avec une autre version. Si vous utilisez AMCSD / COD telles quelles, vous pouvez les recharger depuis `Lire la base AMCSD (### cristaux)` / `Lire la base COD (### cristaux)`.
- **Lenteur avec une grande base de données** — avec des bases de données volumineuses comme COD, la recherche et le chargement peuvent prendre du temps. Filtrez selon les critères nécessaires avant d'effectuer vos opérations.
- **Impossible d'établir l'interopérabilité avec PDIndexer / ReciPro** — vérifiez que le logiciel cible de l'interopérabilité est en cours d'exécution. Le transfert automatique à la sélection s'effectue via le presse-papiers (voir [Interopérabilité](6-interoperation.md)).

Pour tout problème non mentionné ici, veuillez le signaler via les [Issues](https://github.com/seto77/CSManager/issues) GitHub.
