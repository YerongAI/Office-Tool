## Witamy

---

Office Tool Plus to potężne i przydatne narzędzie do wdrożeń pakietu Office.

Office Tool Plus jest oparty na [Microsoft Office Deployment Tool](https://aka.ms/ODT) i [OSPP](https://docs.microsoft.com/pl-pl/DeployOffice/vlactivation/tools-to-manage-volume-activation-of-office).

[Grupa telegramów](https://otp.landian.vip/grouplink/telegram.html)

[Kanał telegramu](https://t.me/otp_channel)

### Office Tool Plus Skróty klawiszowe

---

- <kbd>Esc</kbd>: Powrót do głównego okna.
- <kbd>F1</kbd>: Pomoc.
- <kbd>F5</kbd>: ponowne załadowanie informacji pakietu Office.
- <kbd>Ctrl + 1</kbd>: Przełącz na stronę wdrażania.
- <kbd>Ctrl + 2</kbd>: Przełącz, aby aktywować stronę.
- <kbd>Ctrl + 3</kbd>: Przełącz na stronę przybornika.
- <kbd>Ctrl + N</kbd>: Wyświetl panel powiadomień.
- <kbd>Ctrl + T</kbd>: Panel ustawień wyświetlania.
- <kbd>Ctrl + B</kbd>: Wyświetl informacje o panelu.
- <kbd>Ctrl + P</kbd>: Pokaż/Ukryj okno poleceń.
- <kbd>Ctrl + D</kbd>: Rozpocznij wdrażanie pakietu Office (na stronie wdrażania).
- <kbd>Ctrl + O</kbd>: Importuj konfigurację XML (na stronie wdrażania).
- <kbd>Ctrl + S</kbd>: Eksportuj konfigurację XML (na stronie wdrażania).
- <kbd>Ctrl + E</kbd>: Pokaż kody XML (na stronie wdrażania).

Porada: Możesz także przełączać strony za pomocą przycisku myszy do przodu/do tyłu.

### Office Tool Plus, polecenie (Ctrl + P)

---

`W poleceniach nie jest rozróżniana wielkość liter, są one wykonywane w kolejności, w jakiej zostały wprowadzone.` Jeśli ścieżka zawiera spacje, użyj podwójnych cudzysłowów, aby dołączyć ścieżkę.

**/setImage [Path]** Ustaw obraz tła. Ścieżka do obrazu, obsługa PNG i JPG, obsługa ścieżki lokalnej i HTTP.

**/clImage** Resetowanie obrazu tła.

**/addProduct [ProductID]** Dodaj jeden lub więcej produktów. Przykład: O365ProPlusRetail lub O365ProPlusRetail, VisioProRetail

**/addLang [LanguageID]** Dodaj co najmniej jeden pakiet językowy, przykład: en-us lub pl-pl, en-us, używając polecenia `pl-pl_proof`, aby dodać narzędzie sprawdzające dla pl-pl.

**/setApps [AppsID]** Ustaw aplikacje do zainstalowania. Przykład: Word, Excel, PowerPoint, w przeciwnym razie aplikacje nie zostaną zainstalowane.

**/setExApps [AppsID]** Ustaw aplikacje, których nie chcesz instalować. w przeciwnym razie aplikacje zostaną zainstalowane.

**/deployArch [indeks]** Ustaw architekturę dla pakietu Office, 0 oznacza 32-bit, 1 64-bit

**/deployChl [index]** Ustaw kanał aktualizacji do instalacji. 0 oznacza pierwszą pozycję na liście, na przykład: 0 oznacza `Office 2019 Enterprise Perpetual`, 3 oznacza `Bieżący kanał`.

**/deployMode [index]** Ustaw tryb wdrażania, 0 oznacza pierwszy element listy, na przykład: 0 oznacza `Instaluj podczas pobierania`, 4 oznacza `Tylko pobieranie`.

**/deployModule [indeks]** Ustaw moduł wdrażania, 0 oznacza Office Deployment Tool, 1 oznacza Office Tool Plus.

**/setSources [ścieżka]** Określa lokalizację plików instalacyjnych pakietu Office. W trybie pobierania określa, gdzie zapisać pliki.

**/setVersion [Version]** Określa, która wersja pakietu Office zostanie pobrana/zainstalowana, na przykład: 16.0.12527.20278

**/refresh** Załaduj ponownie informacje pakietu Office.

**/loadChannels** Załaduj dodatkowe kanały na stronie wdrażania.

**/loadXML [Ścieżka]** Załaduj plik XML, obsługa ścieżki lokalnej lub HTTP.

**/startDeploy** Rozpocznij wdrażanie.

**/osppILByID [ProductID]** Zainstaluj licencje pakietu Office dla produktu, na przykład: MondoVolume

**/osppinpkey: [wartość]** Zainstaluj klucz produktu pakietu Office. Przykład: /osppinpkey: XXXXX-XXXXX-XXXXX-XXXXX-XXXXX

**/osppunpkey: [wartość]** Klucz odinstalowania produktu Office. Przykład: /osppunpkey: XXXXX

**/osppsethst: [wartość]** Ustawia hosta KMS. Przykład: /osppsethst:kms.example.com

**/osppsetprt: [wartość]** Ustaw port dla hosta KMS. Przykład: /osppsetprt: 1688

**/osppact** Aktywuj produkt Office.

Aby uzyskać więcej informacji, odwiedź: [Narzędzia do zarządzania zbiorczą aktywacją pakietu Office](https://docs.microsoft.com/pl-pl/deployoffice/vlactivation/tools-to-manage-volume-activation-of-office)
