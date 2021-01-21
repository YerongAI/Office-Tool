# Office Tool Plus Localization

XAML files are localized files used by Office Tool Plus. We recommend that you use VScode or another editor for translation.

## Precautions

Don't change any strings or words like this:

```xml
<!-- Channels Name -->
{0}
{1}
&#x000A;
```

## Verify Error Code

An error code like **0xC004E015** or **0x2**, you can check the content by run command ```slui 0x2a 0xC004E015```.

## How To Test Your Translation (For V8)

1. Save your translation file to a path, like ```D:\Test\de-de.xaml```.

2. Open Office Tool Plus.

3. Press <kbd>Ctrl+P</kbd>, type command  ```/LoadDict D:\Test\de-de.xaml```

4. Press <kbd>Enter</kbd> and Office Tool Plus will load the dictionary.

5. To remove your dictionary, type command and run ```/ClDict```.
