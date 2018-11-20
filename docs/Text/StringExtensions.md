# Extensions for `System.String`

## System.String.SafeTrim methods
Safely trim a `System.String`, returns `string.Empty` in case of `null`.

__Overloads__
* [SafeTrim()](#safetrim)
* [SafeTrim(char[])](#safetrimchar)

---
### SafeTrim()
Removes all leading and trailing white-space characters from the current `System.String` object, returns `string.Empty` in case of `null`.

```csharp
public static string SafeTrim(this string text);
```

this is shortcut to:
```csharp
return (text ?? string.Empty).Trim()
```

---
### SafeTrim(char[])
Removes all leading and trailing occurrences of a set of characters specified in an array from the current `System.String` object, returns `string.Empty` in case of `null`.

```csharp
public static string SafeTrim(this string text, params char[] trimChars);
```

this is shortcut to:
```csharp
return (text ?? string.Empty).Trim(trimChars)
```