# Ashfall.UmbraSync.Api

Contrats partagés entre le plugin Dalamud **UmbraSync** et son serveur relais SignalR. Le paquet ne contient aucune logique métier :

- `IMareHub` et `IMareHubClient` : méthodes du hub et callbacks client ;
- les DTO échangés, sérialisés en MessagePack ;
- les modèles de données partagés (`UserData`, `GroupData`, `CharacterData`…) et leurs enums ;
- les routes HTTP d'authentification et de fichiers (`MareAuth`, `MareFiles`).

## Version

Le numéro majeur du paquet est la valeur de `IMareHub.ApiVersion`. Un client et un serveur ne se connectent que si cette valeur est identique des deux côtés : changer de majeur, c'est rompre le protocole.

- **majeur** : nouvelle `ApiVersion`, le client et le serveur doivent passer ensemble ;
- **mineur** : ajout compatible (nouveau DTO, nouveau champ, nouvelle méthode) ;
- **correctif** : rien ne change sur le fil.

L'assembly et l'espace de noms restent `UmbraSync.API`.

## Licence

AGPL v3 (`LICENSE`). Le code repris de Mare Synchronos avant le commit `46f2443` reste sous licence MIT (`LICENSE_MIT`) ; les deux fichiers sont inclus dans le paquet.

Sources : https://github.com/Ashfall-Codex/UmbraAPI
