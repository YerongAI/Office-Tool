# Informacje o wdrożeniu

Tutaj możesz zarządzać aktualnie zainstalowanymi produktami Office i pakietami językowymi. Jeśli nie masz zainstalowanego pakietu Office, możesz wykonać nową instalację.

Możesz sprawdzić numer wersji i datę wydania na każdym kanale w Informacji o wersji. Następnie możesz określić wersję w momencie pobierania lub instalacji. Jeśli nie zostanie określony, najnowsza wersja zostanie określona domyślnie.

**Uwaga: pakiet Office można zainstalować tylko na dysku systemowym. Jest to określane przez Microsoft.**

## Spis treści

---

1. Moduł instalacyjny
2. Ustawienia kanałów
3. Świeża instalacja
4. Dodaj lub usuń produkty/pakiety językowe
5. Identyfikator produktu Office 365
6. Pliki instalacyjne
7. Pobierz pliki instalacyjne
8. Konfiguracja pakietu Office

## Moduł instalacyjny

---

Office Deployment Tool to oficjalne narzędzie Microsoft do wdrażania pakietu Office, a Office Tool Plus obsługuje prawie wszystkie ustawienia parametrów.
Moduł Office Tool Plus to mały moduł, który opracowaliśmy w celu zainstalowania pakietu Office. Jego funkcjonalność nie jest tak potężna jak narzędzie Office Deployment Tool, ale umożliwia także płynną instalację pakietu Office.

[Oficjalna strona narzędzia Office Deployment Tool](https://aka.ms/ODT)

[Opcje konfiguracji dla narzędzia Office Deployment Tool](https://docs.microsoft.com/en-us/DeployOffice/configuration-options-for-the-office-2016-deployment-tool)

[Office Customization Tool](https://config.office.com/deploymentsettings)

**Jeśli chcesz zainstalować pakiet Office 2019 Volume w systemie Windows 7, zmień moduł na Office Tool Plus!**

Uwaga: Jeśli masz problemy z instalacją za pomocą narzędzia Office Deployment Tool, wypróbuj moduł Office Tool Plus!

## Ustawienia kanału

---

Office, Visio, Project 2019 [Volume] obsługuje tylko kanał Office 2019 Perpetual Enterprise Channel i nie można go łączyć z innymi produktami (jak Office 365).
Jeśli chcesz zainstalować Visio, gdy masz Office 365, wybierz Visio 2016 Retail/Volume lub Visio 2019 Retail (Projekt jest taki sam).

Office 2016/2019 [Retail]/365 może wybrać inne kanały (z wyjątkiem pakietu Office 2019 Perpetual Enterprise Channel). Zalecamy korzystanie z kanału miesięcznego, a pracownicy biurowi, którym nie zależy na nowych funkcjach, mogą wybrać kanał półroczny. **Jeśli masz problemy z kanałem docelowym/poufnym/Dogfood, rozwiąż je samodzielnie.**

## Świeża instalacja

---

Przed rozpoczęciem zalecamy przeczytanie sekcji Ustawienia kanału.

Kliknij przycisk [+Dodaj produkt] i wybierz, co chcesz. W przypadku Office/Visio możesz odznaczyć niechciane aplikacje **(Groove oznacza OneDrive dla Firm, Lync oznacza Skype dla Firm)**.

Kliknij przycisk [+Dodaj pakiet językowy] i wybierz język. Jeśli nie określisz pakietu językowego, pakiet Office Tool Plus domyślnie będzie pasował do języka systemowego (jeśli nie można go dostosować, jako główny język zostanie zainstalowany [en-us]-angielski (USA)).

Następnie kliknij przycisk [Wdróż pakiet Office], aby rozpocząć.

`Uwaga: Jeśli ręcznie dodałeś pakiety językowe, dodaj co najmniej jeden pakiet językowy typu [Pełny].

## Dodaj lub usuń produkty/pakiety językowe

---

Jeśli pakiet Office jest już zainstalowany na komputerze, możesz dodawać lub usuwać produkty/pakiety językowe za pomocą pakietu Office Tool Plus.

### Dodaj produkty/pakiety językowe

Po prostu kliknij przycisk [+Dodaj produkt]/[+Dodaj pakiet językowy] i wybierz, co chcesz.

Uwaga: Aby uniknąć problemów, NIE dodawaj zainstalowanego produktu/pakietu językowego.

### Zmień produkty

Jeśli masz produkt z kilkoma zainstalowanymi aplikacjami, takimi jak Office 365, w tym Word, PowerPoint, Excel, Outlook itp. Jeśli chcesz odinstalować aplikację, najpierw wybierz ten produkt, a następnie odznacz niechciane aplikacje, a następnie kliknij [Wdróż pakiet Office ].

### Usuń produkty/pakiety językowe

Sprawdź na liście produkty/pakiety językowe, które chcesz odinstalować, a następnie kliknij podmenu „Odinstaluj wybrane produkty/pakiety językowe” przycisku [Wdróż pakiet Office], aby rozpocząć.

## Identyfikator produktu Office 365

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
Office 365 Home		O365HomePremRetail
Office 365 Personal		O365HomePremRetail
```

Aby uzyskać więcej informacji, odwiedź stronę [Identyfikatory produktu obsługiwane przez narzędzie Office Deployment Tool for Click-to-Run](https://docs.microsoft.com/en-us/office365/troubleshoot/administration/product-ids-supported-office-deployment-click-to-run)

## Pliki instalacyjne

---

Pliki instalacyjne to pakiet instalacyjny dla pakietu Office. Office Tool Plus może pobierać pliki instalacyjne pakietu Office z serwerów Microsoft i tworzyć obrazy ISO. Po pobraniu plików instalacyjnych możesz użyć instalacji offline lub udostępnić je innym, aby zaoszczędzić przepustowość lub skrócić czas.

Kanał określa, którą wersję pakietu Office można zainstalować, dlatego zalecamy najpierw przeczytanie sekcji Ustawienia kanału.

Kliknij podmenu „Pobierz pliki instalacyjne” w oknie Zarządzaj plikami instalacyjnymi, aby rozpocząć. Możesz go skonfigurować samodzielnie lub użyć domyślnych ustawień Office Tool Plus, a następnie kliknąć przycisk [Start], aby pobrać.

![Pobierz pliki instalacyjne](https://server.coolhub.top/OfficeTool/images/en-us/DownloadPanel.png)

### Więcej informacji

[Przegląd kanałów aktualizacji dla Office 365 ProPlus](https://docs.microsoft.com/en-us/DeployOffice/overview-of-update-channels-for-office-365-proplus)

[Historia aktualizacji dla Office 365 ProPlus](https://docs.microsoft.com/en-us/officeupdates/update-history-office365-proplus-by-date)

[Aktualizacja kanału dla pakietu Office 2019](https://docs.microsoft.com/en-us/DeployOffice/office2019/update#update-channel-for-office-2019)

## Pobierz pliki instalacyjne

---

Oprócz pobierania plików instalacyjnych za pomocą narzędzia Office Deployment Tool, Office Tool Plus zawiera także Thunder, umożliwiając użytkownikom szybkie pobieranie plików instalacyjnych pakietu Office. Nie mają one różnicy w podstawowych funkcjach, ale tylko Thunder obsługuje wyświetlanie postępu pobierania, ustawianie ograniczeń prędkości i ustawianie proxy. Jeśli występuje problem z pobieraniem Thunder, spróbuj przełączyć silnik na narzędzie Office Deployment Tool.

### Ustawienie ograniczenia prędkości Thunder

Aby ustawić ograniczenie prędkości podczas korzystania z pobierania Thunder, kliknij prędkość pobierania podczas pobierania, a następnie ustaw ograniczenie prędkości w wyskakującym oknie zachęty. Aby anulować ograniczenie prędkości, wprowadź 0.

## Konfiguracja pakietu Office

---

Po prawej stronie strony wdrażania możesz wywołać panel Konfiguracja pakietu Office.
Office Tool Plus obsługuje modyfikowanie kanału aktualizacji pakietu Office, a także obsługuje modyfikowanie właściciela wyświetlanego w pakiecie Office. Po edycji kliknij [Zapisz], aby zastosować ustawienia.

Również jeśli masz problem z pakietem Office, możesz spróbować naprawić pakiet Office tutaj.

**Uwaga: jeśli klikniesz [Przeładuj], lista produktów i pakietów językowych po lewej stronie zostanie ponownie załadowana, a niektóre ustawienia zostaną przywrócone do wartości domyślnych.**
