## Welkom

---

Office Tool Plus is een krachtig en handig hulpmiddel voor Office implementaties.

Office Tool Plus is gebaseerd op [Microsoft's Office Deployment Tool](https://aka.ms/ODT) and [OSPP](https://docs.microsoft.com/nl-nl/DeployOffice/vlactivation/tools-to-manage-volume-activation-of-office).

[Telegram groep](https://otp.landian.vip/grouplink/telegram.html)

[Telegram kanaal](https://t.me/otp_channel)

### Office Tool Plus sneltoetsen

---

- <kbd>Esc</kbd>: Terug naar Home.
- <kbd>F1</kbd>: Help.
- <kbd>F5</kbd>: Laad Office informatie opnieuw.
- <kbd>Ctrl + 1</kbd>: Schakel over naar de implementatie pagina.
- <kbd>Ctrl + 2</kbd>: Schakel om de pagina te activeren.
- <kbd>Ctrl + 3</kbd>: Schakel over naar de toolbox pagina.
- <kbd>Ctrl + N</kbd>: Geef het meldingspaneel weer.
- <kbd>Ctrl + T</kbd>: Geef het instellingenpaneel weer.
- <kbd>Ctrl + B</kbd>: Vertoning over paneel.
- <kbd>Ctrl + P</kbd>: Toon/Verberg opdrachtvenster.

Tip: U kunt ook van pagina wisselen met de muisknop vooruit/achteruit.

### Office Tool Plus Commando (Ctrl + P)

---

`Commando's zijn niet hoofdlettergevoelig en worden uitgevoerd in de volgorde waarin ze zijn ingevoerd.`Als het pad spaties bevat, gebruik dan de dubbele aanhalingstekens om het pad op te nemen.

**/setImage [Path]** Stel de achtergrondafbeelding in. Pad naar afbeelding, ondersteuning voor PNG en JPG, ondersteuning voor lokaal en HTTP-pad.

**/clImage** Reset achtergrondafbeelding.

**/addProduct [ProductIDs]** Voeg een of meer producten toe. Voorbeeld: O365ProPlusRetail of O365ProPlusRetail, VisioProRetail

**/addLang [LanguageIDs]** Voeg een of meer taalpakketten toe, bijvoorbeeld: en-us of zh-cn, en-us, met `ja-jp_proof` om proofing tool toe te voegen voor ja-jp.

**/setApps [AppIDs]** Stel in welke applicaties u wilt installeren. Voorbeeld: Word, Excel, PowerPoint, anders worden applicaties niet geïnstalleerd.

**/setExApps [AppIDs]** Stel in welke applicaties niet moeten worden geïnstalleerd. anders worden applicaties geïnstalleerd.

**/deployArch [index]** Stel architectuur in voor Office, 0 staat voor 32-bits, 1 voor 64-bits.

**/deployChl [index]** Stel het updatekanaal in voor installatie. 0 staat voor het eerste item van de lijst, bijvoorbeeld: 0 betekent `Office 2019 Enterprise Perpetual`, 3 betekend `Huidige Channel`.

**/deployMode [index]** Stel de implementatiemodus in, 0 staat voor het eerste item van de lijst, bijvoorbeeld: 0 betekent `Installeer tijdens downloaden`, 4 betekent `Alleen Downloaden`.

**/deployModule [index]** Stel implementeer module in, 0 staat voor Office Deployment Tool, 1 staat voor Office Tool Plus.

**/setSources [Path]** Bepaalt de locatie van de Office-installatiebestanden. Bepaalt in de downloadmodus waar de bestanden moeten worden opgeslagen.

**/setVersion [Version]** Bepaalt welke versie van Office wordt gedownload / geïnstalleerd, bijvoorbeeld: 16.0.12527.20278

**/refresh** Laad Office informatie opnieuw.

**/loadChannels** Laad extra kanalen op de implementatie pagina.

**/loadXML [Path]** Laad een XML bestand, ondersteun een lokaal of HTTP pad.

**/startDeploy** Start implementatie.

**/installiSlide** Installeer iSlide.

**/getKey [ProductID]** Verkrijg de productsleutel, retourneer GVLK voor volumeproducten, normale sleutel voor andere producten. Voorbeeld product id: ProPlus2019Volume

**/osppILByID [ProductID]** Installeer Office-licenties voor een product, bijvoorbeeld product id: MondoVolume

**/osppinpkey:[value]** Installeer de Office productsleutel. Bijvoorbeeld: /osppinpkey:XXXXX-XXXXX-XXXXX-XXXXX-XXXXX

**/osppunpkey:[value]** Verwijder de sleutel van het Office-product. bijvoorbeeld: /osppunpkey:XXXXX

**/osppsethst:[value]** Stel KMS host in. Bijvoorbeeld: /osppsethst:kms.example.com

**/osppsetprt:[value]** Stel poort in voor KMS host. Bijvoorbeeld: /osppsetprt:1688

**/osppact** Activeer Office product.

Voor meer informatie kunt u terecht op: [Tools om volumeactivering van Office te beheren](https://docs.microsoft.com/nl-nl/deployoffice/vlactivation/tools-to-manage-volume-activation-of-office)
