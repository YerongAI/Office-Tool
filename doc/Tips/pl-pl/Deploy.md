## Wdrażanie pakietu Office

---

Na tej stronie możesz zarządzać pakietem Office i instalować go. **Ze względu na ograniczenia firmy Microsoft możesz zainstalować pakiet Office tylko na dysku systemowym.**

W aplikacjach ***Lync*** to skrót od ***Skype for Business***，***Groove*** to skrót od ***OneDrive dla firm***. Bing to rozszerzenie dla Chrome i Edge itp. Aby uzyskać więcej informacji, odwiedź [Microsoft Search in Bing and Microsoft 365 Apps for Enterprise](https://docs.microsoft.com/pl-pl/deployoffice/microsoft-search-bing).

Aby zdefiniować miejsce zapisywania plików w trybie pobierania, zmień wartość ***Ścieżka źródłowa*** w ***Ustawienia instalacji***.

### Spis treści

---

1. Tryb wdrażania
2. Kanał aktualizacji pakietu Office
3. Wdróż moduł
4. Office Applications Preferences
5. Więcej informacji

### Tryb wdrażania

---

Nowa instalacja oznacza zainstalowanie pakietu Office na komputerze, którego nigdy wcześniej nie instalowano.

Z drugiej strony możesz dodawać produkty lub pakiety językowe do istniejącej instalacji pakietu Office. Dodaj lub usuń aplikacje z pakietu Office.

#### Zainstaluj podczas pobierania

*Pobierz tylko wymagane pliki. Wykorzystano mniej danych.*

Zalecamy użycie go podczas zmiany istniejącej instalacji pakietu Office.

Jeśli masz słabe połączenie internetowe, zajmie to dużo czasu.

#### Zainstaluj po pobraniu

*Pobierz wszystkie pliki.*

Zalecamy użycie go podczas instalowania pakietu Office na nowym komputerze.

#### Użyj istniejącego źródła instalacji

Aby z niego skorzystać, musisz wybrać dowolny z plików CAB. Jeśli nie, wrócimy do *Zainstaluj podczas pobierania*.

Jeśli używasz pliku ISO, musisz go najpierw zamontować, a następnie wybrać plik CAB.

#### Utwórz plik ISO

*Wymaga plików instalacyjnych pakietu Office przechowywanych w katalogu Office Tool Plus.* Jeśli nie, najpierw pobierz pliki instalacyjne pakietu Office.

You can create an ISO file with default settings. To do so, configure Office installation, such as adding products and languages, then click "Start deploy" to begin creating ISO file.

If you do not configuration, the user will need to configure it as if it were used normally.

#### Tylko pobierz

Tryb nie rozpocznie instalacji, pobierz tylko pliki. Przed rozpoczęciem pobierania upewnij się, że dodałeś przynajmniej pakiet językowy.

#### Edytuj tylko konfigurację

Tryb nie rozpocznie instalacji, tylko do eksportu plików XML.

### Kanał aktualizacji pakietu Office

---

`Office 2019 Perpetual Enterprise:`

Tylko dla wersji Office 2019 Volume.

**Brak aktualizacji funkcji.**

**Aktualizacje zabezpieczeń:** raz w miesiącu, w drugi wtorek miesiąca.

`Bieżący kanał (normalny):`

**Aktualizacje funkcji:** gdy tylko będą gotowe (zwykle raz w miesiącu), ale bez ustalonego harmonogramu.

**Aktualizacje zabezpieczeń:** raz w miesiącu, w drugi wtorek miesiąca.

`Półroczny kanał korporacyjny:`

**Aktualizacje funkcji:** Dwa razy w roku (w styczniu i lipcu), w drugi wtorek miesiąca

**Aktualizacje zabezpieczeń:** raz w miesiącu, w drugi wtorek miesiąca.

Uwaga: nie zalecamy korzystania z kanału beta.

### Wdrażanie modułu

---

Narzędzie do wdrażania pakietu Office to oficjalne narzędzie firmy Microsoft do wdrażania pakietu Office.

#### Funkcje nieobsługiwane w module Office Tool Plus

- Brak obsługi opcji dziennika
- Brak obsługi programu Configuration Manager
- Brak obsługi terminu aktualizacji
- Brak obsługi migracji architektury
- Brak obsługi wymuszonej aktualizacji.
- Brak obsługi usuwania istniejących wersji MSI pakietu Office
- Brak obsługi instalacji w tym samym języku, co w poprzedniej wersji MSI.
- Not support of Office applications preferences.

Uwaga: **Aby uzyskać pełną instalację, użyj narzędzia do wdrażania pakietu Office.**

### Office Applications Preferences

---

`Application preferences are data provided by Microsoft, these texts are machine translated and may contain some grammatical errors.`

The function allow you defines application preferences for Office Apps, including VBA Macro notifications, default file locations, and default file format.

You can apply new application preferences to client computers that already have Office installed. Click "Applying preferences for Office applications" in the "View XML code" submenu.

The app preferences are applied to all existing users of the device and any new users added to the device in the future. If you apply application preferences when Office apps are running, the preferences will be applied when Office is next restarted.

### Więcej informacji

---

[Oficjalna witryna internetowa Office Deployment Tool](https://aka.ms/ODT)

[Opcje konfiguracji dla narzędzia do wdrażania pakietu Office](https://docs.microsoft.com/pl-pl/DeployOffice/configuration-options-for-the-office-2016-deployment-tool)

[Lista identyfikatorów produktów obsługiwanych przez narzędzie Office Deployment Tool dla technologii kliknij, aby uruchomić Click-to-Run](https://docs.microsoft.com/en-us/office365/troubleshoot/installation/product-ids-supported-office-deployment-click-to-run)

[Omówienie kanałów aktualizacji aplikacji Microsoft 365](https://docs.microsoft.com/pl-pl/deployoffice/overview-update-channels)

[Historia aktualizacji dla aplikacji Microsoft 365](https://docs.microsoft.com/pl-pl/officeupdates/update-history-microsoft365-apps-by-date)

[Kanał aktualizacji dla pakietu Office 2019](https://docs.microsoft.com/pl-pl/DeployOffice/office2019/update#update-channel-for-office-2019)
