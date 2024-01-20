# BdfNet

.NET library for loading Glyph Bitmap Distribution Format (BDF) fonts.

## Example

```csharp
var font = BdfFont.Load("courR14.bdf");
var aChar = font.Characters[0x61];

for (int row = 0; row < aChar.Height; row++)
{
    for (int col = 0; col < aChar.Width; col++)
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