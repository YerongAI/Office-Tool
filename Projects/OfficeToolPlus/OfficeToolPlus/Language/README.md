# Office Tool Plus Localization

XAML files are localized files used by Office Tool Plus. We recommend that you use VScode or another editor for translation.

## Precautions

Don't change any string or word like this:

```xml
<!-- Channels Name -->
\n
\t
%UserName%
%year%
%language%
&#x000A;
#
```

### Example

#### Original

---

Office (**%architecture%**) couldn't be installed because you have the **%currentArchitecture%** Office installed on your computer:`&#x000A;&#x000A;`**%currentProduct%**`&#x000A;`32 bit and 64 bit versions of Office programs don't get along, so you can only have one type installed at a time. Please try installing the **%currentArchitecture%** version of Office instead, or uninstall your other **%currentArchitecture%** Office programs and try this installation again.

#### Show

---

Office (**64 Bit**) couldn't be installed because you have the **32 Bit** Office installed on your computer:

**Office 365 ProPlus**

32 bit and 64 bit versions of Office programs don't get along, so you can only have one type installed at a time. Please try installing the **32 Bit** version of Office instead, or uninstall your other **32 Bit** Office programs and try this installation again.

## How to Test

When you finished translation, open Office Tool Plus and switch to settings page, click Load localization file and select your translation.

## How to Submit

You can use GitHub to submit your translation, or you can send me your file via [E-mail](mailto:yerong@coolhub.top)

Thank you!
