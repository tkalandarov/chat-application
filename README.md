# chat-application
My live chat application powered by ASP.NET 5.0 + EF Core + SignalR + JavaScript

App implements simple authorization/authentication functionality using <b>Microsoft ASP.NET Core Identity</b>. 
The data is supposed to be stored on a local <b>MS SQL Server</b> instance (this can be simply changed by tweaking <b>NuGet</b> packages and <b>Startup.cs</b> file).
Do not forget to also modify conncection string in appsettings.json file!

When you run a build, you can test the functionality by opening two browser tabs - one regular and one incognito - and access the app by addressing <b>localhost:port</b>.
When authenticated in both tabs, you will see two sample users (not clickable) and the accounts that you just created. Now, you can start sending messages from one tab to another and see how SignalR works in real-time.

<h2>Screenshots</h2>
<p>Authentication page:</p>
<a href="https://ibb.co/LSsMnHc"><img src="https://i.ibb.co/WnRQgjM/Screenshot-17.png" alt="Screenshot-17" border="0"></a>
<br/><br/>
<p>Main page:</p>
<a href="https://ibb.co/WB2YMS9"><img src="https://i.ibb.co/j3r1Q7K/Screenshot-18.png" alt="Screenshot-18" border="0"></a>
<br/><br/>
<p>Project structure:</p>
<a href="https://ibb.co/d4S66sW"><img src="https://i.ibb.co/0ykZZpD/Capture.png" alt="Capture" border="0"></a>
