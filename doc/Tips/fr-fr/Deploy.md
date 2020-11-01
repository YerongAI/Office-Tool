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
4. Plus d’informations

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

*Nécessite des fichiers d'installation d'Office stockés dans le répertoire Office Tool Plus.* Sinon, téléchargez d'abord les fichiers d'installation d'Office.

`Si vous ajoutez des produits ou des modules linguistiques, Office Tool Plus créera une configuration XML lors de la création du fichier ISO. Lorsque les utilisateurs démarrent Office Tool Plus en mode ISO, Office Tool Plus demandera à l'utilisateur s'il souhaite démarrer l'installation.`

#### Télécharger uniquement

Le mode ne démarre pas l’installation, télécharger des fichiers uniquement. Avant de commencer à télécharger, assurez-vous d’ajouter un pack linguistique au moins.

#### Modifier la configuration uniquement

Le mode ne démarre pas l’installation uniquement pour l’exportation de fichiers XML.

### Canal de mise à jour d'Office

---

`Office 2019 Perpetual Enterprise:`

Pour l'édition de volume d'Office 2019 uniquement.

**Aucune mise à jour de fonctionnalité.**

**Mises à jour de sécurité :** Une fois par mois, le deuxième mardi du mois.

`Canal actuel (Normal):`

**Mises à jour de fonctionnalités:** Dès qu’elles sont prêtes (habituellement une fois par mois), mais sans calendrier fixe.

**Mises à jour de sécurité :** Une fois par mois, le deuxième mardi du mois.

`Canal d'entreprise semi-annuel:`

**Mises à jour des fonctionnalités :** Deux fois par an (en janvier et juillet), le deuxième mardi du mois

**Mises à jour de sécurité :** Une fois par mois, le deuxième mardi du mois.

Note: Nous ne recommandons pas d’utiliser le canal bêta.

### Déployer le module

---

L’outil de déploiement Office est un outil Microsoft officiel pour le déploiement d’Office.

#### Fonctionnalités non prises en charge dans le module Outil Office Plus

- Non prise en charge des options de journal
- Ne pas prendre en charge le Gestionnaire de configuration
- Non prise en charge de la date limite de mise à jour
- Non prise en charge de l’architecture de migration
- Pas de prise en charge de la mise à jour de la force.
- Non prise en charge de la suppression des versions MSI existantes d’Office
- Pas de prise en charge de l’installation de la même langue que la version précédente MSI.

Note: **Pour une expérience d’installation complète, assurez-vous d’utiliser l’outil de déploiement Office.**

### Plus d’informations

---

[Site Web officiel de l’outil de déploiement Office](https://aka.ms/ODT)

[Options de configuration pour l’outil de déploiement Office](https://docs.microsoft.com/fr-fr/deployoffice/office-deployment-tool-configuration-options)

[Liste des ID produits pris en charge par l’outil de déploiement Office pour le Click-to-Run](https://docs.microsoft.com/fr-fr/office365/troubleshoot/installation/product-ids-supported-office-deployment-click-to-run)

[Vue d'ensemble des canaux de mise à jour pour les applications Microsoft 365](https://docs.microsoft.com/fr-fr/deployoffice/overview-update-channels)

[Historique des mises à jour pour les applications Microsoft 365](https://docs.microsoft.com/fr-fr/officeupdates/update-history-microsoft365-apps-by-date)

[Mise à jour du canal pour Office 2019](https://docs.microsoft.com/fr-fr/DeployOffice/office2019/update#update-channel-for-office-2019)
