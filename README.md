#NOTE: I am not gunna update this server to 27.5 because the build (1439425927) is still bugged as hell.

#Build Status: [![Build status](https://img.shields.io/appveyor/ci/ossimc82/fabiano-swagger-of-doom/master.svg)](https://ci.appveyor.com/project/ossimc82/fabiano-swagger-of-doom)

## How to run this on my own server?

**Notice:** This guide is based on http://www.mpgh.net/forum/showthread.php?t=959037

1. Compile `server.sln` with Visual Studio 2015 or higher in `Release` mode.
2. Install [XAMPP](https://www.apachefriends.org) and configure a user/database called `rotmgprod`, import `db\rotmgprod.sql` to get the right tables. **Do not allow outside connections if you don't set a password!**
3. Add the following line to `%systemroot%\System32\drivers\etc\hosts` on the server: `127.0.0.1 c453.pw`
3. Start `bin\Release\server.exe` as Administrator (required for access to port 80)
4. Start `bin\Release\wServer.exe`
5. Visit http://c453.pw in your browser to play.

## How to allow clients to connect to my server?

1. Configure your firewall to allow outside connections.
2. On the client side add `se.rv.er.ip c453.pw` to `%systemroot%\System32\drivers\etc\hosts`
3. Visit http://c453.pw in your browser to play.

Alternatively you can use [RABCDAsm](https://github.com/CyberShadow/RABCDAsm) to modify `AssembleeGameClient201409192100.swf` to directly connect to your server domain/IP (this method is not recommended if you are just trying to play with some friends):

1. `abcexport AssembleeGameClient201409192100.swf`
2. `rabcdasm AssembleeGameClient201409192100-1.abc`
3. Replace all occurrences of `c453.pw` with your domain/IP in all `*.asasm` files.
4. `rabcasm AssembleeGameClient201409192100-1\AssembleeGameClient201409192100-1.main.asasm`
5. `abcreplace AssembleeGameClient201409192100.swf 1 AssembleeGameClient201409192100-1\AssembleeGameClient201409192100-1.main.abc`

**Do not contact me for help, I have none to offer.**

##Additional License information

You are free to use this source as long as u credit this guys:

- ossimc82/Fabian Fischer
- C453
- Trapped
- Donran
- creepylava
- Krazyshank
- Barm
- Nilly
- sebastianfra12 for some more behaviors
- Kieron for making 1 behavior
- everyone else that have contributed to this project on mpgh or any other site

And you are not "WintersQ" and "I Don't Love You" on MPGH
