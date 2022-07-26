# FPatch
🍭 File Patcher

**Version: 1.3.2**

#### Table of contents

1. [Environment](#Environment)
2. [Informations](#Informations)
3. [Build a patch](#building-a-patch)

## Environment

Original file
`test.txt`
```
THIS IS A TEST
```

## Informations

- All the patches: `patch.fpp`
- A backup of the patched file is made: `filename.extention.bak`
- The patches not added to the list won't be saved in the patch file
- Patch file format:
```JSON
{
    "patch" : {
        "version" : "1.0.0",
        "author" : "neo",
        "content": [
            {
                "file" : "test.txt",
                "status" : 0,
                "payload" : {
                    "start" : 8,
                    "payload" : [
                        65,
                        32,
                        80,
                        65,
                        84,
                        67,
                        72,
                        69,
                        68,
                        32,
                        84,
                        69,
                        83,
                        84,
                        32
                    ],
                    "method" : 0
                }
            }
        ]
    },
    "settings": {
        "version" : "1.3.2"
    }
}
```

## Build a patch

**The goal of the patch is to change the text in `text.txt`**

### Client

```CSHARP
FPatch.Core fpatch = new FPatch.Core("<PATCH AUTHOR>", "<PATCH VERSION>");
```

- (string) PATCH AUTHOR: your username
- (string) PATCH VERSION: to know wich version will be used as patch

##### Example

```CSHARP
FPatch.Core fpatch = new FPatch.Core("neo", "1.0.0");
```

### Patch

```CSHARP
fpatch.create_and_add("<FILE TO PATCH>", "<OFFSET>", "<BYTES EDITED>");
```
The function `fpatch.create_and_add()` creates a patch and add it to the list of the patches to add for your mod
This is just a simple `fpatch.create()` with a `fpatch.add()`.
If you want to create a patch without adding it to the patch list just use `fpatch.create()` but remember that your `patch.fpp` will contains only the patches added to the list

- (string) FILE TO PATCH: the file path to patch
- (Uint32) OFFSET: the index where the patch will start
- (UInt32[]) BYTES EDITED: the patch


##### Example

```CSHARP
fpatch.create_and_add("test.txt", 0x00000008, new UInt32[]
{
    (UInt32)'N',
    (UInt32)'O',
    (UInt32)'T',
    (UInt32)' ',
    (UInt32)'A',
    (UInt32)' ',
    (UInt32)'T',
    (UInt32)'E',
    (UInt32)'S',
    (UInt32)'T'
});
```

### Entire payload build

`fpatch.apply();` apply all the patches added in the list
```CSHARP
fpatch.apply();
```

The function `fpatch.save()` saves all the patches added to teh list in json, the output is `patch.fpp`

```CSHARP
fpatch.save();
```

```CSHARP
FPatch.Core fpatch = new FPatch.Core("neo", "1.0.0");

fpatch.create_and_add("test.txt", 0x00000008, new UInt32[]
{
    (UInt32)'N',
    (UInt32)'O',
    (UInt32)'T',
    (UInt32)' ',
    (UInt32)'A',
    (UInt32)' ',
    (UInt32)'T',
    (UInt32)'E',
    (UInt32)'S',
    (UInt32)'T'
});

fpatch.apply();
fpatch.save();
```

#### Console
```
 _____ _____     _       _
|   __|  _  |___| |_ ___| |_
|   __|   __| .'|  _|  _|   |
|__|  |__|  |__,|_| |___|_|_|
               Author: neo
version: 1.0.0

[ . ] Creating patch: 8
[ . ] Adding patch to model: 8
[ . ] Starting patch
[ > ] Applying patch 8
[ > ] Checking file: True
[ > ] Building backup
[ + ] Backup built
[ > ] Loading bytes
[ + ] 14 bytes loaded
[ > ] Saving bytes
[ + ] 18 bytes saved
[ + ] Patch applied
[ + ] All patch applied
[ . ] Saving model
[ + ] Model saved
```

`test.txt`
```
THIS IS NOT A TEST
```
