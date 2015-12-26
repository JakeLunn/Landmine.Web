# Landmine.Web

ASP.NET MVC5 App for http://landminegame.com

[![Build status](https://ci.appveyor.com/api/projects/status/m3wito7vhc03sd87/branch/master?svg=true)](https://ci.appveyor.com/project/akatakritos/landmine-web/branch/master)

## Building

This solution requires Visual Studio 2015 and uses C# 6 features. You can use 
[VS2015 Community Edition](https://www.visualstudio.com/en-us/downloads/download-visual-studio-vs.aspx)
for free.

## Running

You will need SQL Server for the database (SQL Server Express is fine). Update the
`DefaultConnection` connection string in `~/Web.config` or create the `HobbyDB` database
on your server.

You can also use SQL Server LocalDB by using a connection string like this:

```xml
<add name="DefaultConnection" connectionString="Data Source=(LocalDb)\v11.0;AttachDbFilename=|DataDirectory|\landmine.mdf;Integrated Security=True" providerName="System.Data.SqlClient"/>
```

The database should be auotmatically migrated.

## Tests

Tests are in `Landmine.Tests` and use [xUnit.net](https://xunit.github.io/) as the runner and
[NFluent](http://www.n-fluent.net/) as the assertion library.

If you have Resharper, there is an extension in `Resharper` - `Extension Manager` that will teach 
the unit test explorer to find xUnit tests. Otherwise, you can install the nuget package 
[xunit.runner.visualstudio](https://www.nuget.org/packages/xunit.runner.visualstudio).

## Javascript

The main javascript for the game is at https://github.com/akatakritos/landmine.js and
is distrubted through bower.

The integration javascript is written in TypeScript and lives at `~/Scripts/LM`.

## Contributing

Fork and submit pull requests. Please include unit tests when possible.