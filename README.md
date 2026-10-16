website
=======

Source and content for www.nnug.no

Running locally
---------------

Requires the [.NET 10 SDK](https://dotnet.microsoft.com/download).

    dotnet run --project src/WebSite

In the `Development` environment the site uses the canned Meetup responses in
`src/WebSite/App_Data_DesignTime` (`UseDesignTimeData` in `appsettings.Development.json`).
In any other environment it calls the Meetup API.

    dotnet test
