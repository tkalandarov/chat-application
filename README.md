# chat-application
My live chat application powered by ASP.NET 5.0 + EF Core + SignalR + JavaScript

App implements simple authorization/authentication functionality using <b>Microsoft ASP.NET Core Identity</b>. 
The data is supposed to be stored on a local <b>MS SQL Server</b> instance (this can be simply changed by tweaking <b>NuGet</b> packages and <b>Startup.cs</b> file).
Do not forget to also modify conncection string in appsettings.json file!

When you run a build, you can test the functionality by opening two browser tabs - one regular and one incognito - and access the app by addressing <b>localhost:port</b>.
When authenticated in both tabs, you will see two sample users (not clickable) and the accounts that you just created. Now, you can start sending messages from one tab to another and see how SignalR works in real-time.
