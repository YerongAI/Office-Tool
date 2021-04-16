## Implementeer Office

---

Op de pagina kunt u Office beheren en installeren. **Vanwege de beperkingen van Microsoft kunt u Office alleen op uw systeemstation installeren.**

In applicaties, ***Lync*** staat voor ***Skype voor Bedrijven***，***Groove*** stands for ***OneDrive voor bedrijven***. Bing is een extensie voor Chrome en Edge enz. Ga voor meer informatie naar [Microsoft Search in Bing en Microsoft 365 Apps voor ondernemingen](https://docs.microsoft.com/nl-nl/deployoffice/microsoft-search-bing).

Wijzig de waarde van, om te bepalen waar bestanden in de downloadmodus moeten worden opgeslagen  ***Bronpad*** in ***Installatie instellingen***.

### Inhoud

---

1. Implementatie modus
2. Office Update kanaal
3. Implementatie Module
4. Office Applicatie Voorkeuren
5. Meer Informatie

### Implementatiemodus

---

Een nieuwe installatie is een manier om Office te installeren op een computer die nog nooit eerder is geïnstalleerd.

OAan de andere kant kunt u producten of taalpakketten toevoegen aan uw bestaande Office-installatie. Toepassingen toevoegen aan of verwijderen uit Office-suite.

#### Installeer tijdens het downloaden

*Download alleen de vereiste bestanden. Er worden minder gegevens gebruikt.*

We raden u aan deze te gebruiken bij het wijzigen van een bestaande Office-installatie.

Als u een slechte internetverbinding heeft, kost dit veel tijd.

#### Installeer na download

*Download alle bestanden.*

We raden u aan om het te gebruiken, wanneer u Office op een nieuwe computer installeert.

#### Gebruik een bestaande installatiebron

Om het te gebruiken, moet u een van de CAB bestanden kiezen. Zo niet, dan vallen we terug op *Installeer tijdens downloaden*.

Als u een ISO bestand gebruikt, moet u dit eerst mounten en vervolgens het CAB bestand selecteren.

#### Creëer ISO file

*Vereist Office installatiebestanden die zijn opgeslagen in de Office Tool Plus-directory.* Als dit niet het geval is, download dan eerst de Office installatiebestanden.

U kunt een ISO bestand maken met standaardinstellingen. Configureer hiervoor de Office installatie, zoals het toevoegen van producten en talen, en klik vervolgens op "Start implementatie" om te beginnen met het maken van een ISO bestand.

Als u niet configureert, moet de gebruiker het configureren alsof het normaal wordt gebruikt.

#### Alleen downloaden

De modus start niet met de installatie, download alleen bestanden. Zorg ervoor dat u, voordat u begint met downloaden, een taalpakket toevoegt.

#### Bewerk alleen de configuratie

De modus start de installatie niet, alleen voor het exporteren van XML-bestanden.

### Office updatekanaal

---

`Office 2019 Perpetual Enterprise:`

Alleen voor Office 2019 Volume editie.

**Geen functie updates.**

**Beveiligings updates:** Een keer per maand, op de tweede dinsdag van de maand.

`Huidige kanaal (Normaal):`

**Functie updates:** Zodra ze klaar zijn (meestal één keer per maand), maar niet volgens een vast schema.

**Beveiligings updates:** Een keer per maand, op de tweede dinsdag van de maand.

`Semi-Annual Enterprise Channel:`

**Functie updates:** Tweemaal per jaar (in januari en juli), op de tweede dinsdag van de maand

**Beveiligings updates:** Een keer per maand, op de tweede dinsdag van de maand.

Note: We raden het gebruik van het bètakanaal af.

### Implementeer module

---

De Office Deployment Tool is een officiële Microsoft-tool voor het implementeren van Office.

#### Functies niet ondersteund in de Office Tool Plus Module

- Geen ondersteuning van Configuratie Manager
- Geen ondersteuning van update deadline
- Geen ondersteuning van migratie architectuur
- Geen ondersteuning van geforceerde update.
- Geen ondersteuning van verwijder bestaande MSI versies van Office
- Geen ondersteuning van installeer dezelfde taal als de vorige MSI versie.
- Geen ondersteuning van Office applicatie voorkeuren.

Note: **Gebruik de Office Deployment Tool voor een complete installatie-ervaring.**

### Voorkeuren voor Office toepassingen

---

`Toepassingsvoorkeuren zijn gegevens die door Microsoft worden geleverd, deze teksten zijn automatisch vertaald en kunnen enkele grammaticale fouten bevatten.`

Met deze functie kunt u toepassingsvoorkeuren voor Office apps definiëren, inclusief VBA macromeldingen, standaardbestandslocaties en standaardbestandsindeling.

U kunt nieuwe toepassingsvoorkeuren toepassen op clientcomputers waarop Office al is geïnstalleerd. Klik op "Voorkeuren toepassen op Office toepassingen" in het submenu "XML code weergeven".

De app-voorkeuren worden toegepast op alle bestaande gebruikers van het apparaat en op eventuele nieuwe gebruikers die in de toekomst aan het apparaat worden toegevoegd. Als u toepassingsvoorkeuren toepast wanneer Office apps worden uitgevoerd, worden de voorkeuren toegepast wanneer Office de volgende keer opnieuw wordt opgestart.

### Meer informatie

---

[Office Deployment Tool Official Website](https://aka.ms/ODT)

[Configuratie opties voor de Office Deployment Tool](https://docs.microsoft.com/nl-nl/DeployOffice/configuration-options-for-the-office-2016-deployment-tool)

[Lijst met product ID's die worden ondersteund door de Office Deployment Tool voor Click-to-Run](https://docs.microsoft.com/nl-nl/office365/troubleshoot/installation/product-ids-supported-office-deployment-click-to-run)

[Overzicht van updatekanalen voor Microsoft 365 Apps](https://docs.microsoft.com/nl-nl/deployoffice/overview-update-channels)

[Updategeschiedenis voor Microsoft 365 Apps](https://docs.microsoft.com/nl-nl/officeupdates/update-history-microsoft365-apps-by-date)

[Update kanaal voor Office 2019](https://docs.microsoft.com/nl-nl/DeployOffice/office2019/update#update-channel-for-office-2019)
