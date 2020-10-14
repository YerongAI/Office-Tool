## Benvenuto

---

Office Tool Plus è uno strumento potente e utile per le distribuzioni di Office.

Office Tool Plus si basa su [Strumenti di distribuzione di Microsoft Office](https://aka.ms/ODT ) and [OSPP](https://docs.microsoft.com/it-it/DeployOffice/vlactivation/tools-to-manage-volume-activation-of-office ).

[Gruppo Telegram](https://otp.landian.vip/grouplink/telegram.html )

[Canale Telegram](https://t.me/otp_channel )

[WeChat group](https://otp.landian.vip/grouplink/wechat.html )

### Office Tool Plus Tasti di Scelta Rapida

---

- <kbd>Esc</kbd>: Torna alla Home.
- <kbd>F1</kbd>: Aiuto.
- <kbd>F5</kbd>: Aggiorna e reimposta Informazioni.
- <kbd>Ctrl + 1</kbd>: Passa alla pagina di distribuzione.
- <kbd>Ctrl + 2</kbd>: Passa alla pagina di attivazione.
- <kbd>Ctrl + 3</kbd>: Passa alla pagina degli strumenti.
- <kbd>Ctrl + N</kbd>: Visualizza pannello notifiche.
- <kbd>Ctrl + T</kbd>: Visualizza pannello impostazioni.
- <kbd>Ctrl + B</kbd>: Visualizza pannello informazioni.
- <kbd>Ctrl + P</kbd>: Mostra/Nascondi casella di comando.
- <kbd>Ctrl + D</kbd>: Avvia distribuzione di Office (Sulla pagina distribuzione).
- <kbd>Ctrl + O</kbd>: Importa configurazione XML (Sulla pagina distribuzione).
- <kbd>Ctrl + S</kbd>: Esporta configurazione XML (Sulla pagina distribuzione).
- <kbd>Ctrl + E</kbd>: Visualizza codici XML (Sulla pagina distribuzione).

Suggerimento: È inoltre possibile passare da una pagina all'altra utilizzando il pulsante avanti/indietro del mouse.

### Office Tool Plus Comandi (Ctrl + P)

---

Puoi accedere direttamente alle funzioni che desideri tramite i comandi e puoi anche eseguire le impostazioni batch! I comandi non fanno distinzione tra maiuscole e minuscole e vengono eseguiti nell'ordine di inserimento. Se il percorso contiene spazi, utilizzare "" (virgolette doppie) per racchiudere il percorso.

**/setImage [Path]** Specifica manualmente l'immagine di sfondo, Path: percorso dell'immagine di sfondo (supporta JPG, PNG, supporta il percorso locale e il percorso HTTP)

**/clImage** Cancella l'immagine di sfondo corrente

**/addProduct [ProductID]** Aggiunge uno o più prodotti, ID prodotto esempio: O365ProPlusRetail, VisioProRetail

**/addLang [LanguageID]** Aggiunge uno o più pacchetti lingua, ID pacchetto lingua esempio: it-it per aggiungere un pacchetto lingua completo, it-it_proof per aggiungere gli strumenti di correzione

**/setApps [AppsID]** Imposta quali applicazioni installare, usa le virgole per separare ogni ID applicazione, ad esempio: Word, Excel, PowerPoint, le applicazioni che non sono impostate non verranno installate

**/setExApps [AppsID]** Imposta le applicazioni da non installare, usare lo stesso metodo di /setApps

**/deployArch [index]** Imposta l'architettura, 0 significa 32 bit, 1 significa 64 bit

**/deployChl [index]** Imposta il canale, 0 rappresenta la versione a lungo termine del canale aziendale di Office 2019, 6 rappresenta il canale di sviluppo

**/deployMode [index]** Imposta la modalità di distribuzione, 0 significa installa durante il download, 5 significa solo configura

**/deployModule [index]** Imposta il modulo di installazione, 0 significa Strumenti di Distribuzione di Office, 1 significa Office Tool Plus

**/setSources [Path]** Specifica dove ottenere i file di installazione di Office durante l'installazione di Office. Se è vuoto, utilizza CDN di Office come origine. In modalità download, questo attributo viene utilizzato per definire dove archiviare i file di installazione di Office

**/setVersion [Version]** Specifica quale versione di Office deve essere utilizzata durante il download/installazione di Office, ad esempio 16.0.12527.20278

**/refresh** Ricarica tutti i dati della pagina di distribuzione

**/loadChannels** Carica canali aggiuntivi nella pagina di distribuzione

**/loadXML [Path]** Carica un file XML, supporta percorsi locali e HTTP

**/startDeploy** Avvia la distribuzione

**/osppILByID [ProductID]** Installa la licenza Office del prodotto specificato, Product ID ad esempio: MondoVolume

**/osppinpkey:[value]** Installa la chiave di Office specificata, ad esempio:/osppinpkey:XXXXX-XXXXX-XXXXX-XXXXX-XXXXX

**/osppunpkey:[value]** Disinstalla la chiave di Office specificata, ad esempio:/osppunpkey:XXXXX

**/osppsethst:[value]** Imposta l'indirizzo host KMS, ad esempio:/osppsethst:kms.example.com

**/osppsetprt:[value]** Imposta la porta dell'host KMS, il valore predefinito è 1688, ad esempio:/osppsetprt:1688

**/osppact** Attiva i prodotti di Office

L'uso di altri parametri OSPP è simile. Basta aggiungere la parola ospp prima di ogni comando. Il file della guida OSPP può essere trovato nel [documento ufficiale Microsoft](https://docs.microsoft.com/it-it/deployoffice/vlactivation/tools-to-manage-volume-activation-of-office )
