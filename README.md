# MeguminReactions

## Description

Discord Bot to send private message from an http Request.

## Build

VS 2019
Type: C# .Net Core Console Application
Framework target: .Net 5.0

## Usage

Request example:

```json
{
    "magic_number": "$MagicNumber",
    "target": "$UserID",
    "message": "$Message"
}
```

Listening on:
```
http://localhost:8000/MeguminReactions/
```
