## À propos du déploiement

---

Ici, vous pouvez gérer les produits Office actuellement installés et les packs linguistiques. Si vous n'avez pas installé Office, vous pouvez faire une nouvelle installation.

Vous pouvez interroger le numéro de version et la date de sortie sur chaque canal dans Version Information. Après cela, vous pouvez spécifier la version au moment du téléchargement ou de l'installation. S'il n'est pas spécifié, la dernière version sera spécifiée par défaut.

**Note: Office ne peut être installé que sur votre disque système. Ceci est déterminé par Microsoft.**

### Contenu

---

1. Mode de déploiement
2. Canal de mise à jour Office
3. Module de déploiement
4. Préférences des applications Office
5. Plus d’informations

### Module d'installation

---

L’installation fraîche est un moyen d’installer Office sur une machine qui n’a jamais été installée auparavant.

D’autre part, vous pouvez ajouter des produits ou des modules linguistiques à votre installation Office. Ajoutez ou supprimez des applications de la suite Office.

#### Installer pendant le téléchargement

*Télécharger uniquement les fichiers requis. Moins de données utilisées.*

Nous vous recommandons de l’utiliser lors de la modification d’une installation Office.

Si vous avez une mauvaise connexion Internet, cela prendra beaucoup de temps.

#### Installer après téléchargement

*Télécharger tous les fichiers.*

Nous vous recommandons de l’utiliser lors de l’installation d’Office sur une nouvelle machine.

#### Utiliser une source d’installation existante

Pour l’utiliser, vous devez choisir l’un des fichiers CAB. Si ce n’est pas le cas, nous nous replions sur *Installer pendant le téléchargement*.

Si vous utilisez un fichier ISO, vous devez d’abord le monter, puis sélectionner le fichier CAB.

#### Créer un fichier ISO

*Nécessite des fichiers d'installation d'Office stockés dans le répertoire Office Tool Plus.* Sinon, télécharger d'abord les fichiers d'installation d'Office.

Vous pouvez créer un fichier ISO avec les paramètres par défaut. Pour ce faire, configurez l'installation d'Office, comme l'ajout de produits et de langues, puis cliquez sur «Démarrer le déploiement» pour commencer à créer le fichier ISO.

Si vous ne configurez pas, l'utilisateur devra le configurer comme s'il était utilisé normalement.

#### Télécharger uniquement

Le mode ne démarre pas l’installation, télécharger des fichiers uniquement. Avant de commencer à télécharger, assurez-vous d’ajouter un pack linguistique au moins.

#### Modifier la configuration uniquement

Le mode ne démarre pas l’installation uniquement pour l’exportation de fichiers XML.

### Canal de mise à jour d'Office

---

`Office 2019 Perpetual Enterprise:`

Pour l'édition de volume d'Office 2019 uniquement.

**Aucune mise à jour de fonctionnalité.**

**Mises à jour de sécurité:** Une fois par mois, le deuxième mardi du mois.

`Canal actuel (Normal):`

**Mises à jour de fonctionnalités:** Dès qu’elles sont prêtes (habituellement une fois par mois), mais sans calendrier fixe.

**Mises à jour de sécurité:** Une fois par mois, le deuxième mardi du mois.

`Canal d'entreprise semi-annuel:`

**Mises à jour des fonctionnalités:** Deux fois par an (en janvier et juillet), le deuxième mardi du mois

**Mises à jour de sécurité:** Une fois par mois, le deuxième mardi du mois.

Note: Nous ne recommandons pas d’utiliser le canal bêta.

### Déployer le module

---

L’outil de déploiement Office est un outil Microsoft officiel pour le déploiement d’Office.

#### Fonctionnalités non prises en charge dans le module Outil Office Plus

- Ne pas prendre en charge le gestionnaire de configuration
- Non prise en charge de la date limite de mise à jour
- Non prise en charge de l’architecture de migration
- Pas de prise en charge de la mise à jour de la force.
- Non prise en charge de la suppression des versions MSI existantes d’Office
- Pas de prise en charge de l’installation de la même langue que la version précédente MSI.
- Ne prend pas en charge les préférences des applications Office.

Note: **Pour une expérience d’installation complète, assurez-vous d’utiliser l’outil de déploiement Office.**

### Préférences des applications Office

---

`Les préférences de l'application sont des données fournies par Microsoft, ces textes sont traduits automatiquement et peuvent contenir des erreurs grammaticales.`

La fonction vous permet de définir les préférences d'application pour les applications Office, y compris les notifications de macro VBA, les emplacements de fichier par défaut et le format de fichier par défaut.

Vous pouvez appliquer de nouvelles préférences d'application aux ordinateurs clients sur lesquels Office est déjà installé. Cliquez sur "Application des préférences pour les applications Office" dans le sous-menu "Afficher le code XML".

Les préférences de l'application sont appliquées à tous les utilisateurs existants de l'appareil et à tous les nouveaux utilisateurs ajoutés à l'appareil à l'avenir. Si vous appliquez les préférences d'application lorsque les applications Office sont en cours d'exécution, les préférences seront appliquées lors du prochain redémarrage d'Office.

### Plus d’informations

---

[Site Web officiel de l’outil de déploiement Office](https://aka.ms/ODT)

[Options de configuration pour l’outil de déploiement Office](https://docs.microsoft.com/fr-fr/deployoffice/office-deployment-tool-configuration-options)

[Liste des ID produits pris en charge par l’outil de déploiement Office pour le Click-to-Run](https://docs.microsoft.com/fr-fr/office365/troubleshoot/installation/product-ids-supported-office-deployment-click-to-run)

[Vue d'ensemble des canaux de mise à jour pour les applications Microsoft 365](https://docs.microsoft.com/fr-fr/deployoffice/overview-update-channels)

[Historique des mises à jour pour les applications Microsoft 365](https://docs.microsoft.com/fr-fr/officeupdates/update-history-microsoft365-apps-by-date)

[Mise à jour du canal pour Office 2019](https://docs.microsoft.com/fr-fr/DeployOffice/office2019/update#update-channel-for-office-2019)
