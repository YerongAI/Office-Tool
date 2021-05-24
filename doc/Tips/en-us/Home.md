# Welcome

---

Office Tool Plus is a powerful and useful tool for Office deployments.

Office Tool Plus is based on [Microsoft's Office Deployment Tool](https://aka.ms/ODT) and [OSPP](https://docs.microsoft.com/en-us/DeployOffice/vlactivation/tools-to-manage-volume-activation-of-office).

[Telegram group](https://otp.landian.vip/grouplink/telegram.html)

[Telegram channel](https://t.me/otp_channel)

## Office Tool Plus Shortcut Keys

---

- <kbd>Esc</kbd>: Go back.
- <kbd>F1</kbd>: Help.
- <kbd>F5</kbd>: Reload Office information (On deploy page).
- <kbd>Ctrl + 1</kbd>: Switch to deploy page.
- <kbd>Ctrl + 2</kbd>: Switch to activate page.
- <kbd>Ctrl + 3</kbd>: Switch to toolbox page.
- <kbd>Ctrl + 4</kbd>: Switch to convert documents page.
- <kbd>Ctrl + T</kbd>: Display settings panel.
- <kbd>Ctrl + B</kbd>: Display about panel.

## Office Tool Plus In-application Commands

---

`Commands are not case-sensitive, executed in the order they entered.` If the path contains spaces, use the double quotes to include the path.

**/setImage path** Set the background image. Path to image, support PNG and JPG, support local and HTTP path.

**/clImage** Reset background image.

**/getKey product-ID** Get the product key, return GVLK for volume products, normal key for other products. Example product id: ProPlus2019Volume

**/osppILByID product-ID** Install Office licenses for a product, example product id: MondoVolume

**/osppinpkey:value** Install Office product key. Example: /osppinpkey:XXXXX-XXXXX-XXXXX-XXXXX-XXXXX

**/osppunpkey:value** Uninstall key for Office product. Example: /osppunpkey:XXXXX

**/osppactcid:value** Activates product with user-provided Confirmation ID. Value parameter is required.

**/osppsethst:value** Set KMS host. Example: /osppsethst:kms.example.com

**/osppsetprt:value** Set port for KMS host. Example: /osppsetprt:1688

**/osppact** Activate Office product.

For more information, please visit: [Tools to manage volume activation of Office](https://docs.microsoft.com/en-us/deployoffice/vlactivation/tools-to-manage-volume-activation-of-office)
