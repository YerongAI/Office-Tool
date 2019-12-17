# Informacje o aktywacji

Jeśli aktywacja pakietu Office nie powiodła się za pomocą tego narzędzia, najpierw sprawdź działanie (w poniższych instrukcjach są kroki). Jeśli problem nadal występuje, spróbuj sprawdzić system operacyjny. Po udanej aktywacji wszystko jest gotowe do pracy.

## Spis treści

---

1. Zainstaluj licencję/zmień licencję
2. Aktywuj licencję (Aktywuj Office)
3. Sprawdź Serwer KMS
4. Status aktywacji zapytania
5. Zarządzaj aktywacją pakietu Office
6. Ogólne klucze licencji zbiorczych (GVLK)

## Zainstaluj licencję

---

Po zainstalowaniu licencję można aktywować odpowiednim kluczem.
Na przykład: jeśli chcesz, aby Twój Office 2016 Retail->Office 2016 Volume, po prostu zainstaluj licencję Office 2016 Volume.
Po instalacji stara licencja nie zostanie zastąpiona. Możemy mieć wiele licencji na jedno oprogramowanie.

Jeśli chcesz zainstalować lokalne pliki licencji, po prostu kliknij przycisk [...].

Uwaga: Jeśli wersja Office oparta na C2R jest zainstalowana na twoim komputerze, Office Tool Plus spróbuje odczytać wszystkie dostępne licencje i wyświetli je w rozwijanym polu. W przeciwnym razie zostaną wyświetlone tylko wbudowane licencje zbiorowe.

## Aktywuj licencję

---

Uwaga: jedynym sposobem aktywacji Office 365 jest zalogowanie się na swoje konto Office 365.

### Aktywacja online

Przed aktywacją upewnij się, że Twój klucz jest prawidłowy, a wersja jest poprawna. Wprowadź klucz i kliknij przycisk [Zainstaluj klucz], a następnie kliknij [Aktywuj], Office zostanie aktywowany pomyślnie. Można to również zrobić w pakiecie Office.
Po pomyślnej aktywacji pakiet Office pozostanie aktywny.

### Aktywacja telefonem

Upewnij się, że klucz można wykorzystać do aktywacji telefonu i zainstaluj klucz. W podmenu przycisku [Zainstaluj klucz] kliknij „Wyświetl identyfikator instalacji”. Po uzyskaniu identyfikatora potwierdzenia wprowadź swój identyfikator potwierdzenia bez czerni i kliknij podmenu „Zainstaluj identyfikator potwierdzenia”.
Po pomyślnej aktywacji pakiet Office pozostanie aktywny.

### Aktywacja KMS

Upewnij się, że masz zainstalowane wersje Office z licencjami zbiorowymi. Jeśli nie wiesz, czy jest to wersja zbiorcza, zainstaluj odpowiednie licencje zbiorowe. Na przykład, jeśli chcesz aktywować pakiet Office 2016, po prostu zainstaluj licencję zbiorczą Office 2016. Następnie musisz wprowadzić prawidłowy adres serwera KMS, `nie zapomnij przycisku [Ustaw adres serwera]. Gdy wszystko jest poprawnie skonfigurowane, sieć działa normalnie, a serwer KMS działa normalnie, kliknij przycisk [Aktywuj]. Powodzenie? Ciesz się

## Sprawdź serwer KMS

---

Wprowadź adres serwera KMS i kliknij podmenu „Sprawdź stan KMS”.

Ogólnie zostaną zwrócone następujące wyniki:
Łączenie z 192.168.123.1:1688 ... udane
Wysyłanie żądania aktywacji (KMS V4) 1 z 1->03612-00206-524-247319-03-1100-14393.0000-2802018

„pomyślny” oznacza, że ​​możesz połączyć się z serwerem, „Wysłanie żądania aktywacji” oznacza, że ​​serwer działa.

Jeśli tego nie widziałeś, może występować problem z tym serwerem lub siecią KMS.

## Zapytanie Status aktywacji

---

Kliknij przycisk [Wyświetl informacje o aktywacji] poniżej, aby sprawdzić informacje o licencji dla zainstalowanych kluczy.

Uwaga: pakiet Office jest aktywowany tylko wtedy, gdy status licencji to ---LICENCJONOWANY--- .

## Zarządzaj aktywacją pakietu Office

---

### Odinstaluj klucz produktu pakietu Office

Kliknij przycisk [Wyświetl informacje o aktywacji] poniżej, aby sprawdzić informacje o licencji dla zainstalowanych kluczy.

Skopiuj 5 ostatnich znaków zainstalowanego klucza produktu niepotrzebnej licencji, wklej go w polu wejściowym Zarządzanie kluczami, a następnie kliknij podmenu „Odinstaluj klucz”.

![Odinstaluj klucz produktu pakietu Office](https://server.coolhub.top/OfficeTool/images/en-us/UninstallKey.png)

### Odinstaluj wszystkie klucze produktów pakietu Office

W podmenu Zarządzanie kluczami możesz odinstalować wszystkie klucze.
Po odinstalowaniu wszystkich kluczy wszystkie aktywacje zostaną wyczyszczone, musisz ponownie aktywować pakiet Office.


### Wyczyść wszystkie licencje Office

W podmenu Zarządzanie licencjami możesz wyczyścić licencje.
Po wyczyszczeniu wszystkich licencji należy naprawić pakiet Office przy pierwszym otwarciu aplikacji Office (pakiet Office zresetuje licencje do wartości domyślnych).
Lub możesz zainstalować licencję ręcznie. Następnie możesz ponownie aktywować pakiet Office.

** Podmenu „Wyczyść aktywację” oznacza, że ​​zostaną wykonane wszystkie powyższe operacje. **

## Ogólne klucze licencji zbiorczych (GVLK)

---

Przed użyciem GVLK upewnij się, że masz zainstalowane wersje Office z licencją Volume.
Jeśli nie wiesz, czy jest to wersja woluminowa, zainstaluj odpowiednie licencje zbiorcze przed użyciem GVLK.
Aktywacja pakietu Office za pośrednictwem usługi KMS wymaga adresu serwera KMS, w przeciwnym razie nie będzie można aktywować pakietu Office.

Aby uzyskać więcej informacji, odwiedź [GVLKs dla KMS i aktywacji Office 2019 i Office 2016 w oparciu o Active Directory](https://docs.microsoft.com/en-us/DeployOffice/vlactivation/gvlks)

```txt
GVLK pakietu Office 2019

Office Pro Plus 2019	NMMKJ-6RK4F-KMJVX-8D9MJ-6MWKP
Office Standard 2019	6NWWJ-YQWMR-QKGCB-6TMB3-9D9HK
Project Pro 2019		B4NPR-3FKK7-T2MBV-FRQ4W-PKD2B
Project Std 2019		C4F7P-NCP8C-6CQPT-MQHV9-JXD2M
Visio Pro 2019		9BGNQ-K37YR-RQHF2-38RQ3-7VCBB
Visio Std 2019		7TQNQ-K3YQQ-3PFH7-CCPPM-X4VQ2
Access 2019		9N9PT-27V4Y-VJ2PD-YXFMF-YTFQT
Excel 2019		TMJWT-YYNMB-3BKTF-644FC-RVXBD
Outlook 2019		7HD7K-N4PVK-BHBCQ-YWQRW-XW4VK
PowerPoint 2019		RRNCX-C64HY-W2MM7-MCH9G-TJHMQ
Publisher 2019		G2KWX-3NW6P-PY93R-JXK2T-C9Y9V
Skype for Business	NCJ33-JHBBY-HTK98-MYCV8-HMKHJ
Word 2019		PBX3G-NWMT6-Q7XBW-PYJGG-WXD33

GVLK pakietu Office 2016

Office Pro Plus 2016	XQNVK-8JYDB-WJ9W3-YJ8YR-WFG99
Office Standard 2016	JNRGM-WHDWX-FJJG3-K47QV-DRTFM
Office Mondo 2016	HFTND-W9MK4-8B7MJ-B6C4G-XQBR2
Project Pro 2016		WGT24-HCNMF-FQ7XH-6M8K7-DRTW9
Project Std 2016		D8NRQ-JTYM3-7J2DX-646CT-6836M
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

### Klucz wdzięku dla detalicznej usługi Office 365 Pro Plus

DRNV7-VGMM2-B3G9T-4BF84-VMFTK

Jeśli nie wiesz, co to jest, nie używaj go. Nie można go użyć do aktywacji pakietu Office.
