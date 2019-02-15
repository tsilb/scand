# scand

From this tutorial: https://code.msdn.microsoft.com/ASPNET-MVC-5-Security-And-44cbdb97

-----------------------------------------------------------------------------------------------------

First, you have to update the NuGet packages. To do this, follow these steps:
  1. Navigate to the Tools menu dropdown on the top of VS
  2. Go down to NuGet Package Manager > Packet Manager Console
  3. Paste "Update-Package Microsoft.CodeDom.Providers.DotNetCompilerPlatform -r"
  4. Hit enter

In the Web.config file, the <connectionStrings> is connected to a local SQL database on my computer so I'm not sure if you all will be able to access it. I believe we need to configure a cloud hosted Azure SQL database.
  
Once, we set up the Azure SQL database. We need to run the following query:

-----------------------------------------------------------------------------------------------------

USE MASTER;   

IF EXISTS (SELECT [name] FROM sys.databases WHERE [name] = 'AttendanceDB' )   
BEGIN   
ALTER DATABASE AttendanceDB SET SINGLE_USER WITH ROLLBACK IMMEDIATE   
DROP DATABASE AttendanceDB ;   
END     
   
CREATE DATABASE AttendanceDB   
GO   
   
USE AttendanceDB 

-----------------------------------------------------------------------------------------------------

Now you should be able to run the web app. Navigate to this page: ~/Account/Login

To login, use these credentials:

  username: admin

  password: password123
