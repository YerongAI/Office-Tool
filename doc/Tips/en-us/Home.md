## Welcome

---

Office Tool Plus is a powerful and useful tool for Office deployments.

Office Tool Plus is based on [Microsoft's Office Deployment Tool](https://aka.ms/ODT) and [OSPP](https://docs.microsoft.com/en-us/DeployOffice/vlactivation/tools-to-manage-volume-activation-of-office).

[Telegram group](https://otp.landian.vip/grouplink/telegram.html)

[Telegram channel](https://t.me/otp_channel)

### Office Tool Plus Shortcut Keys

---

- <kbd>Esc</kbd>: Back Home.
- <kbd>F1</kbd>: Help.
- <kbd>F5</kbd>: Reload Office information.
- <kbd>Ctrl + 1</kbd>: Switch to deploy page.
- <kbd>Ctrl + 2</kbd>: Switch to activate page.
- <kbd>Ctrl + 3</kbd>: Switch to toolbox page.
- <kbd>Ctrl + N</kbd>: Display notification panel.
- <kbd>Ctrl + T</kbd>: Display settings panel.
- <kbd>Ctrl + B</kbd>: Display about panel.
- <kbd>Ctrl + P</kbd>: Show/Hide command box.
- <kbd>Ctrl + D</kbd>: Start deploy Office (On deploy page).
- <kbd>Ctrl + O</kbd>: Import XML confuguration (On deploy page).
- <kbd>Ctrl + S</kbd>: Export XML confuguration (On deploy page).
- <kbd>Ctrl + E</kbd>: Show XML codes (On deploy page).

Tip: You can also switch pages using the mouse forward/back button.

### Office Tool Plus Command (Ctrl + P)

---

`Commands are not case-sensitive, executed in the order they entered.` If the path contains spaces, use the double quotes to include the path.

**/setImage [Path]** Set the background image. Path to image, support PNG and JPG, support local and HTTP path.

**/clImage** Reset background image.

**/addProduct [ProductIDs]** Add one or more pruducts. Example: O365ProPlusRetail or O365ProPlusRetail,VisioProRetail

**/addLang [LanguageIDs]** Add one or more language packs, Example: en-us or zh-cn,en-us, using `ja-jp_proof` to add proofing tool for ja-jp.

**/setApps [AppIDs]** Set which applications to install. Example: Word,Excel,PowerPoint, otherwise applications will not be installed.

**/setExApps [AppIDs]** Set which applications not to install. otherwise applications will be installed.

**/deployArch [index]** Set architecture for Office, 0 stands for 32-bit, 1 for 64-bit

**/deployChl [index]** Set update channel for installation. 0 stands for the first item of list, example: 0 means `Office 2019 Enterprise Perpetual`, 3 means `Current Channel`.

**/deployMode [index]** Set deploy mode, 0 stands for the first item of list, example: 0 means `Install while downloading`, 4 means `Download only`.

**/deployModule [index]** Set deploy module, 0 stands for Office Deployment Tool, 1 stands for Office Tool Plus.

**/setSources [Path]** Defines the location of the Office installation files. In download mode, defines where to save the files.

**/setVersion [Version]** Defines which version of Office will be download/installed, example: 16.0.12527.20278

**/refresh** Reload Office information.

**/loadChannels** Load extra channels in deploy page.

**/loadXML [Path]** Load a XML file, support local or HTTP path.

**/startDeploy** Start deploy.

**/installiSlide** Install iSlide.

**/getProductKey [ProductID]** Get the product key, return GVLK for volume products, normal key for other products. Example product id: ProPlus2019Volume

**/osppILByID [ProductID]** Install Office licenses for a product, example product id: MondoVolume

**/osppinpkey:[value]** Install Office product key. Example: /osppinpkey:XXXXX-XXXXX-XXXXX-XXXXX-XXXXX

**/osppunpkey:[value]** Uninstall key for Office product. Example: /osppunpkey:XXXXX

**/osppsethst:[value]** Set KMS host. Example: /osppsethst:kms.example.com

**/osppsetprt:[value]** Set port for KMS host. Example: /osppsetprt:1688

**/osppact** Activate Office product.

For more information, please visit: [Tools to manage volume activation of Office](https://docs.microsoft.com/en-us/deployoffice/vlactivation/tools-to-manage-volume-activation-of-office)
