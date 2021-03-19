## Bienvenue

---

Office Tool Plus est un outil puissant et utile pour les déploiements Office.

Office Tool Plus est basé sur [l’outil de déploiement Office de Microsoft](https://aka.ms/ODT) et [OSPP](https://docs.microsoft.com/fr-fr/DeployOffice/vlactivation/tools-to-manage-volume-activation-of-office).

[Groupe Telegram](https://otp.landian.vip/grouplink/telegram.html)

[Canal Telegram](https://t.me/otp_channel)

### Touches de raccourci Office Tool Plus

---

- <kbd>Esc</kbd>: Retour à l'accueil.
- <kbd>F1</kbd>: Aide.
- <kbd>F5</kbd>: Recharger les informations Office.
- <kbd>Ctrl + 1</kbd>: Basculer vers la page de déploiement.
- <kbd>Ctrl + 2</kbd>: Basculer pour activer la page.
- <kbd>Ctrl + 3</kbd>: Passer à la page de la boîte à outils.
- <kbd>Ctrl + N</kbd>: Afficher le panneau de notification.
- <kbd>Ctrl + T</kbd>: Afficher le panneau des paramètres.
- <kbd>Ctrl + B</kbd>: Afficher à propos du panneau.
- <kbd>Ctrl + P</kbd>: Afficher/Cacher la zone de commande.

Conseil: Vous pouvez également changer de page à l’aide du bouton avant/arrière de la souris.

### Commande Office Tool Plus (Ctrl + P)

---

`Les commandes ne sont pas sensibles à la casse, exécutées dans l’ordre qu’elles ont entré.` Si le chemin d’accès contient des espaces, utilisez les guillemets doubles pour inclure le chemin d’accès.

**/setImage [Path]** Définisser l’image d’arrière-plan. Chemin d’accès à l’image, prise en charge PNG et JPG, prise en charge du chemin d’accès local et HTTP.

**/clImage** Réinitialiser l’image d’arrière-plan.

**/addProduct [ProductIDs]** Ajouter un ou plusieurs produits. Exemple: O365ProPlusRetail or O365ProPlusRetail,VisioProRetail

**/addLang [LanguageIDs]** Ajouter un ou plusieurs modules linguistiques, Exemple: en-us ou zh-cn,en-us, using `ja-jp_proof` pour ajouter un outil de vérification pour ja-jp.

**/setApps [AppIDs]** Définisser les applications à installer. Exemple: Word,Excel,PowerPoint, sinon les applications ne seront pas installées.

**/setExApps [AppIDs]** Définisser les applications à ne pas installer. sinon des applications seront installées.

**/deployArch [index]** Définir l’architecture pour Office, 0 signifie 32 bits, 1 pour 64 bits

**/deployChl [index]** Définisser le canal de mise à jour pour l’installation. 0 signifie le premier élément de liste, par exemple: 0 signifie `Office 2019 Entreprise perpétuelle`, 3 signifie `Chaîne actuelle`.

**/deployMode [index]** Définir le mode de déploiement, 0 signifie le premier élément de liste, par exemple: 0 signifie `Installer pendant le téléchargement`, 4 signifie `Télécharger uniquement`.

**/deployModule [index]** Définir le module de déploiement, 0 stands pour l’outil de déploiement Office, 1 est pour Office Tool Plus.

**/setSources [Path]** Définir l’emplacement des fichiers d’installation Office. En mode téléchargement, définit où enregistrer les fichiers.

**/setVersion [Version]** Définir la version d’Office qui sera téléchargée/installée, par exemple: 16.0.12527.20278

**/refresh** Recharger les informations Office.

**/loadChannels** Charger des canaux supplémentaires dans la page de déploiement.

**/loadXML [Path]** Charger un fichier XML, prenez en charge le chemin d’accès local ou HTTP.

**/startDeploy** Démarrer le déploiement.

**/installiSlide** Installer iSlide.

**/getKey [ProductID]** Obtener la clé du produit, renvoyer GVLK pour les produits en volume, clé normale pour d’autres produits. Exemple d’id produit: ProPlus2019Volume

**/osppILByID [ProductID]** Installer des licences Office pour un produit, par exemple: MondoVolume

**/osppinpkey:[value]** Installer la clé de produit Office. Exemple: /osppinpkey:XXXXX-XXXXX-XXXXX-XXXXX-XXXXX

**/osppunpkey:[value]** Désinstaller la clé pour le produit Office. Exemple: /osppunpkey:XXXXX

**/osppsethst:[value]** Définisser l’hôte KMS. Exemple: /osppsethst:kms.example.com

**/osppsetprt:[value]** Définisser le port pour l’hôte KMS. Exemple: /osppsetprt:1688

**/osppact** Activer le produit Office.

Pour plus d’informations, veuillez visiter: [Outils pour gérer l’activation en volume d’Office](https://docs.microsoft.com/fr-fr/deployoffice/vlactivation/tools-to-manage-volume-activation-of-office)
