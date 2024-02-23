# BdfNet

.NET library for loading Glyph Bitmap Distribution Format (BDF) fonts.

## Example

```csharp
var font = BdfFont.Load("courR14.bdf");
var aChar = font.Characters[0x61];

for (var row = 0; row < aChar.Height; row++)
{
    for (var col = 0; col < aChar.Width; col++)
    {
        Console.Write(aChar.Bitmap[row, col] == 1 ? "*" : " ");
    }
    
    Console.WriteLine();
}
```

```
  ***  
 *   * 
     * 
 ***** 
*    * 
*    * 
 **** *

```