# MeguminReactions

## Description

Discord Bot to send private message from an http Request.

Invite link:
https://discordapp.com/oauth2/authorize?client_id=805126998283911189&scope=bot

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
