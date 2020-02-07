# À propos de l'activation

```txt
Si vous activez Office a échoué avec cet outil, s'il vous plaît vérifier votre opération d'abord (Il ya des étapes dans les instructions ci-dessous). Si le problème existe toujours, s'il vous plaît essayer de vérifier votre système d'exploitation. Après l'activation réussie, tout est prêt à partir.
```

## Contenu

---

1. Installer la licence/changer de licence
2. Activer la licence (Activer Office)
3. Vérifier le serveur KMS
4. Statut d'activation de requête
5. Gérer l'activation Office
6. Clés de licence de volume générique (GVLKs)

## Installation de la licence

---

Une fois qu'une licence est installée, elle peut être activée avec la clé correspondante.
Par exemple: Si vous voulez que votre Bureau 2016 Retail -- Office 2016 Volume, il vous suffit d'installer la licence Volume Office 2016.
Après l'installation, l'ancienne licence ne sera pas annulée. Ainsi, nous pouvons avoir plusieurs licences pour un logiciel.

Si vous souhaitez installer vos fichiers de licence locaux, il vous suffit de cliquer sur le bouton [...].

`Note: Si la version C2R d'Office est installée sur votre ordinateur, Office Tool Plus tentera de lire toutes les licences disponibles et de les afficher dans la boîte de déclassement. Dans le cas contraire, seules les licences de volume intégrées seront affichées.`

## Activer la licence

---

`Note: La seule façon d'activer Office 365 est de vous connecter à votre compte Office 365.`

### Activation en ligne

`S'il vous plaît assurez-vous que votre clé est valide et la version est correcte avant l'activation.` Entrer la clé et cliquez sur le bouton [Installer la clé], puis cliquez sur [Activer], Office sera activé avec succès. Cela peut également être fait dans Office.
Après l'activation réussie, Office restera actif.

### Activation par téléphone

`Assurez-vous que votre clé peut être utilisée pour l'activation du téléphone` et installer la clé. Dans le sous-menu du bouton [Clé d'installation], cliquez sur "Afficher l'ID d'installation". Après avoir obtenu l'ID de confirmation, entrez votre ID de confirmation sans noir et cliquez sur le sous-menu "Installer l'ID de confirmation".
Après l'activation réussie, Office restera actif.

### Activation KMS

Veuillez vous assurer que vous disposez de versions sous licence en volume d'Office. Si vous ne savez pas s'il s'agit d'une version en volume, veuillez installer les licences en volume correspondantes. Par exemple, si vous souhaitez activer Office 2016, installez simplement la licence en volume Office 2016. Ensuite, vous devez entrer une adresse de serveur KMS valide, `n'oubliez pas le bouton [Définir l'adresse du serveur]`. Lorsque tout est correctement configuré, le réseau est normal et le serveur KMS est normal, cliquez sur le bouton [Activer]. Succès ? Profitez-en !

## Vérifier le serveur KMS

---

Entrer une adresse serveur KMS et cliquez sur le sous-menu "Vérifier l'état KMS".

Les résultats suivants seront retournés en général:
Se connecter à 192.168.123.1:1688 ... réussi
Envoi de la demande d'activation (KMS V4) 1 sur 1  -> 03612-00206-524-247319-03-1100-14393.0000-2802018

"réussi" signifie que vous pouvez vous connecter au serveur, "Envoyer une demande d'activation" signifie que le serveur fonctionne.

Si vous n'avez pas vu cela, il peut y avoir un problème avec ce serveur ou réseau KMS.

## Statut d'activation de requête

---

Cliquez sur le bouton [Afficher les informations d'activation] ci-dessous pour interroger les informations de licence pour les clés installées.

`Note: L'office n'est activé que lorsque l'état de la licence est ---AUTORISÉ--- .`

## Gérer l'activation Office

---

### Désinstaller la clé de produit Office

Cliquez sur le bouton [Afficher les informations d'activation] ci-dessous pour interroger les informations de licence pour les clés installées.

Copiez les 5 derniers caractères de la clé de produit installée de la licence inutile, collez-la dans la boîte d'entrée de gestion des clés, puis cliquez sur le sous-menu "Désinstaller la clé".

![Désinstaller la clé de produit Office](https://server.coolhub.top/OfficeTool/images/en-us/UninstallKey.png)

### Désinstaller toutes les clés de produit Office

Dans le sous-menu de gestion des clés, vous pouvez désinstaller toutes les clés.
Une fois que toutes les clés sont désinstallées, toutes les activations seront effacées, vous devez réactiver Office.

### Supprimer toutes les licences Office

Dans le sous-menu de la gestion des licences, vous pouvez effacer les licences.
Une fois que toutes les licences sont effacées, vous devez réparer Office à la première fois que vous ouvrez l'application Office (Office réinitialisera les licences par défaut).
Ou vous pouvez installer la licence manuellement. Après cela, vous pouvez activer Office à nouveau.

**Le sous-menu "Activation transparent" signifie que toutes les opérations ci-dessus seront effectuées.**

## Clés de licence de volume générique (GVLKs)

---

S'il vous plaît assurez-vous que vous avez volume sous licence versions d'Office installé avant d'utiliser GVLKs.
Si vous ne savez pas s'il s'agit d'une version volume, veuillez installer les licences volume correspondantes avant d'utiliser GVLKs.
Activer Office via KMS nécessite une adresse serveur KMS, sinon Office ne peut pas être activé.

Pour plus d'informations, veuillez visiter [GVLKs for KMS and Active Directory-based activation of Office 2019 et Office 2016](https://docs.microsoft.com/fr-fr/DeployOffice/vlactivation/gvlks)

```txt
Office 2019 GVLKs

Office Pro Plus 2019	NMMKJ-6RK4F-KMJVX-8D9MJ-6MWKP
Office Standard 2019	6NWWJ-YQWMR-QKGCB-6TMB3-9D9HK
Project Pro 2019	B4NPR-3FKK7-T2MBV-FRQ4W-PKD2B
Project Std 2019	C4F7P-NCP8C-6CQPT-MQHV9-JXD2M
Visio Pro 2019		9BGNQ-K37YR-RQHF2-38RQ3-7VCBB
Visio Std 2019		7TQNQ-K3YQQ-3PFH7-CCPPM-X4VQ2
Access 2019		9N9PT-27V4Y-VJ2PD-YXFMF-YTFQT
Excel 2019		TMJWT-YYNMB-3BKTF-644FC-RVXBD
Outlook 2019		7HD7K-N4PVK-BHBCQ-YWQRW-XW4VK
PowerPoint 2019		RRNCX-C64HY-W2MM7-MCH9G-TJHMQ
Publisher 2019		G2KWX-3NW6P-PY93R-JXK2T-C9Y9V
Skype for Business	NCJ33-JHBBY-HTK98-MYCV8-HMKHJ
Word 2019		PBX3G-NWMT6-Q7XBW-PYJGG-WXD33

Office 2016 GVLKs

Office Pro Plus 2016	XQNVK-8JYDB-WJ9W3-YJ8YR-WFG99
Office Standard 2016	JNRGM-WHDWX-FJJG3-K47QV-DRTFM
Office Mondo 2016	HFTND-W9MK4-8B7MJ-B6C4G-XQBR2
Project Pro 2016	WGT24-HCNMF-FQ7XH-6M8K7-DRTW9
Project Std 2016	D8NRQ-JTYM3-7J2DX-646CT-6836M
Visio Pro 2016		69WXN-MBYV6-22PQG-3WGHK-RM6XC
Visio Std 2016		NY48V-PPYYH-3F4PX-XJRKJ-W4423
Access 2016		GNH9Y-D2J4T-FJHGG-QRVH7-QPFDW
Excel 2016		9C2PK-NWTVB-JMPW8-BFT28-7FTBF
OneNote 2016		DR92N-9HTF2-97XKM-XW2WJ-XW3J6
Outlook 2016		R69KK-NTPKF-7M3Q4-QYBHW-6MT9B
PowerPoint 2016		J7MQP-HNJ4Y-WJ7YM-PFYGF-BY6C6
Publisher 2016		F47MM-N3XJP-TQXJ9-BP99D-8K837
Skype for Business	869NQ-FJ69K-466HW-QYCP2-DDBV6
Word 2016		WXY84-JN2Q9-RBCCQ-3Q3J3-3PFJ6
```

### Clé de grâce Office 365 Pro Plus Retail

DRNV7-VGMM2-B3G9T-4BF84-VMFTK

Si vous ne savez pas ce que c'est, s'il vous plaît ne pas l'utiliser. Et il ne peut pas être utilisé pour activer Office.
