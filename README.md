# scand

From this tutorial: https://code.msdn.microsoft.com/ASPNET-MVC-5-Security-And-44cbdb97

-----------------------------------------------------------------------------------------------------

To run the web app, you will likely need Microsoft SQL Server Management Studio.
  1. Server name: scand.database.windows.net
  2. Authentication: SQL Server Authentication
  3. Login: scandadmin
  4. Password: C@p$t0n3
  
-----------------------------------------------------------------------------------------------------

First, you have to update the NuGet packages. To do this, follow these steps:
  1. Navigate to the Tools menu dropdown on the top of VS
  2. Go down to NuGet Package Manager > Packet Manager Console
  3. Paste "Update-Package Microsoft.CodeDom.Providers.DotNetCompilerPlatform -r"
  4. Hit enter

-----------------------------------------------------------------------------------------------------

Now you should be able to run the web app. Navigate to this page: ~/Account/Login

To login, use these credentials:

username: scandadmin

password: $Password123

-----------------------------------------------------------------------------------------------------

From the admin login, you can create new roles.

-----------------------------------------------------------------------------------------------------

Registration for new users also works now.
