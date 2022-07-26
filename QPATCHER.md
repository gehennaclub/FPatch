# QPatcher
Apply patch from everywhere with QPatcher

1. Copy QPatcher & the dependencies where you want to apply patch
2. Copy `patch.fpp` on the same directory
3. Run QPatcher

## Edit QPatcher

Original Source Code
```CSHARP
FPatch.Core fpatch = new FPatch.Core(null, null);

fpatch.load("fpatch.fpp");
fpatch.apply();

Console.ReadLine();
```

#### Auto closing
Remove the line that keeps the console opened
```CSHARP
Console.ReadLine();
```
