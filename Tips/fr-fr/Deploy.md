# À propos du déploiement

Ici, vous pouvez gérer les produits Office actuellement installés et les packs linguistiques. Si vous n'avez pas installé Office, vous pouvez faire une nouvelle installation.

Vous pouvez interroger le numéro de version et la date de sortie sur chaque canal dans Version Information. Après cela, vous pouvez spécifier la version au moment du téléchargement ou de l'installation. S'il n'est pas spécifié, la dernière version sera spécifiée par défaut.

**Note: Office ne peut être installé que sur votre disque système. Ceci est déterminé par Microsoft.**

## Contenu

---

1. Module d'installation
2. Paramètre du canal
3. Nouvelle installation
4. Ajouter ou supprimer des produits/packs de langues
5. ID de produit Office 365
6. Fichiers d'installation
7. Télécharger les fichiers d'installation
8. Configuration d'Office

## Module d'installation

---

Office Deployment Tool est un outil officiel de Microsoft pour le déploiement d'Office, et Office Tool Plus prend en charge presque tous ses paramètres.
Le module Office Tool Plus est un petit module que nous avons développé pour installer Office. Ses fonctionnalités ne sont pas aussi puissantes que l'outil de déploiement Office, mais elles permettent également à Office d'être installé sans problème.

[Site officiel de l'outil de déploiement Office](https://aka.ms/ODT)

[Options de configuration pour l'outil de déploiement office](https://docs.microsoft.com/fr-fr/DeployOffice/configuration-options-for-the-office-2016-deployment-tool)

[Outil de personnalisation office](https://config.office.com/deploymentsettings)

**Si vous souhaitez installer Office 2019 Volume dans Windows 7, veuillez changer de module pour Office Tool Plus !**

`Note: Lorsque vous avez des problèmes d'installation avec l'outil de déploiement Office, essayez le module Office Tool Plus !`

## Paramètre du canal

---

`Office, Visio, Project 2019 [Volume] prennent uniquement en charge Office 2019 Perpetual Enterprise Channel et ne peuvent pas être mélangés avec d'autres produits (comme Office 365).`
Si vous souhaitez installer Visio alors qu'Office 365 est installé, choisissez Visio 2016 Retail/Volume ou Visio 2019 Retail (Project est le même).

Office 2016/2019 [Retail]/365 peut choisir d'autres canaux (sauf Office 2019 Perpetual Enterprise Channel). Nous vous recommandons d'utiliser le canal mensuel et les employés de bureau qui ne se soucient pas des nouvelles fonctionnalités peuvent choisir le canal semi-annuel. **Si vous rencontrez des problèmes avec Targeted/Insider/Dogfood Channel, veuillez les résoudre vous-même.**

## Nouvelle installation

---

Avant de commencer, nous vous recommandons de lire d'abord la section Réglage du canal.

Cliquez sur le bouton [+ Ajouter un produit] et sélectionner ce que vous voulez. Pour Office / Visio, vous pouvez décocher les applications indésirables ** (Groove signifie OneDrive Entreprise, Lync signifie Skype Entreprise)**.

Cliquez sur le bouton [+ Ajouter un module linguistique] et sélectionner votre langue. Si vous n'avez pas spécifié de module linguistique, Office Tool Plus correspondra à la langue du système par défaut (s'il ne peut pas être adapté, [fr-fr] - Français (FR) sera installé comme langue principale).

Cliquez ensuite sur le bouton [Déployer Office] pour démarrer.

`Note: Si vous avez ajouté manuellement des modules linguistiques, veuillez ajouter au moins un module linguistique de type [Complet].`

## Ajouter ou supprimer des produits/packs de langues

---

Si Office est déjà installé sur votre ordinateur, vous pouvez ajouter ou supprimer des produits/packs de langue via Office Tool Plus.

### Ajouter des produits/packs de langues

Il suffit de cliquer sur le bouton [Ajouter le produit] /[Ajouter le pack de langue] et de sélectionner ce que vous voulez.

`Note: Pour éviter les problèmes, n'ajoutez PAS un pack produit/langue installé.`

### Modifier les applications

Si vous souhaitez modifier une application(s) pour un produit, sélectionner d'abord ce produit, puis vérifiez les applications recherchées, décochez les applications indésirables, cliquez finalement sur le bouton [Office de déploiement].

### Supprimer les produits/packs de langues

Cochez les produits/modules linguistiques que vous souhaitez désinstaller dans la liste, puis cliquez sur le sous-menu "Désinstaller les produits / modules linguistiques sélectionnés" du bouton [Déployer Office] pour démarrer.

## ID de produit Office 365

---

```txt
Office 365 ProPlus		O365ProPlusRetail
Office 365 Enterprise E3		O365ProPlusRetail
Office 365 Enterprise E4		O365ProPlusRetail
Office 365 Enterprise E5		O365ProPlusRetail
Office 365 Midsize		O365ProPlusRetail
Office 365 Business		O365BusinessRetail
Office 365 Business Premium	O365BusinessRetail
Office Small Business Premium	O365SmallBusPremRetail
Office 365 Home			O365HomePremRetail
Office 365 Personal		O365HomePremRetail
```

Pour plus d'informations, veuillez visiter [ID de produit pris en charge par l'outil de déploiement d'Office pour Click-to-Run](https://docs.microsoft.com/fr-fr/office365/troubleshoot/installation/product-ids-supported-office-deployment-click-to-run)

## Fichiers d'installation

---

Les fichiers d'installation sont le paquet d'installation pour Office. Office Tool Plus peut télécharger des fichiers d'installation Office à partir de serveurs Microsoft et faire des images ISO. Après avoir téléchargé les fichiers d'installation, vous pouvez utiliser l'installation hors connexion ou les partager à d'autres pour économiser de la bande passante ou réduire le temps.

Le canal détermine quelle version du bureau vous pouvez installer, nous vous recommandons donc de lire la section Deréglage de la chaîne en premier.

Cliquez sur le sous-menu "Télécharger les fichiers d'installation" des fichiers d'installation Gérer pour démarrer. Vous pouvez le configurer vous-même ou utiliser les paramètres par défaut d'Office Tool Plus, puis cliquez sur le bouton [Démarrer] pour télécharger.

![Télécharger les fichiers d'installation](https://server.coolhub.top/OfficeTool/images/en-us/DownloadPanel.png)

### Plus d'informations

[Aperçu des canaux de mise à jour pour Office 365 ProPlus](https://docs.microsoft.com/fr-fr/DeployOffice/overview-of-update-channels-for-office-365-proplus)

[Historique de mise à jour pour Office 365 ProPlus](https://docs.microsoft.com/fr-fr/officeupdates/update-history-office365-proplus-by-date)

[Canal de mise à jour pour Office 2019](https://docs.microsoft.com/fr-fr/DeployOffice/office2019/update#update-channel-for-office-2019)

## Télécharger les fichiers d'installation

---

En plus de télécharger des fichiers d'installation à l'aide de l'outil de déploiement Office, Office Tool Plus inclut également Thunder, permettant aux utilisateurs de télécharger rapidement des fichiers d'installation Office. Ils n'ont aucune différence dans les fonctions de base, mais seul Thunder prend en charge l'affichage des progrès de téléchargement, la fixation des limites de vitesse, et la définition de proxy.` S'il y a un problème avec le téléchargement Thunder, s'il vous plaît essayer de passer le moteur à l'outil de déploiement office.

### Réglage de la limite de vitesse du tonnerre

Pour définir la limite de vitesse lors de l'utilisation du téléchargement Thunder, veuillez cliquer sur la vitesse de téléchargement lors du téléchargement, puis définir la limite de vitesse dans la boîte de vitesse pop-up. Pour annuler la limite de vitesse, entrez 0.

## Configuration d'Office

---

`Sur le côté droit de la page de déploiement, vous pouvez appeler le panneau configuration d'office.`
Office Tool Plus prend en charge la modification du canal de mise à jour Office et prend également en charge la modification du propriétaire affiché dans Office. Une fois modifié, cliquez sur [Enregistrer] pour appliquer les paramètres.

De plus, si vous rencontrez un problème avec Office, vous pouvez essayer de corriger Office ici.

**Note: Si vous cliquez sur [Reload], la liste des produits et packs de langues sur la gauche sera rechargée et certains paramètres seront réinitialisés par défaut.**
