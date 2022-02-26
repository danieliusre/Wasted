# Wasted

[API](https://wastedapi.azurewebsites.net/swagger/index.html)
[Web Application](https://wastedapp.azurewebsites.net/)

## For collaborators:

Project is built using .NET and Blazor (ASP.NET), both using C# as main programming language.

To start working with the project, please install:
1. .NET SDK (https://dotnet.microsoft.com/download/dotnet/5.0 -> SDK Version 5.0.400)
2. .NET EF tools (dotnet tool install --global dotnet-ef)
3. Install Docker (https://docs.docker.com/get-docker/) (Non-unix user will also need to enable virtualization, more about that: https://www.virtualmetric.com/blog/how-to-enable-hardware-virtualization)
4. Set up SQL Server container (Tutorial: https://www.sqlshack.com/how-to-set-up-and-run-sql-server-docker-image/) (All the commands work in Windows too)
5. Install Azure Data Studio or SQL Server Management Studio for accessing the database.

Clone repository to your preferable IDE 

To seed database and create all the tables used in the application (Visual Studio Code will be used for this tutorial):
  1. Open terminal with shortcut (CTRL + \` or CTRL + SHIFT + \` ) or use toolbar option Terminal -> New Terminal
  2. Execute command: dotnet ef database update
  3. If everything worked properly, database structure should be in your local database (connect to it with any tool mentioned above and check)
  
To start API project (Visual Studio Code will be used for this tutorial):
  1. Open terminal with shortcut (CTRL + \` or CTRL + SHIFT + \` ) or use toolbar option Terminal -> New Terminal
  2. Get your terminal location to API folder (write to terminal "cd ./src/Wasted.API" or full path to the src folder e.g "cd C:\_Projects\Wasted\src\Wasted.API")
  3. Use command "dotnet watch run". Web browser should open with url "http://localhost:3000".
 
To start WEB project (Visual Studio Code will be used for this tutorial):
  1. Open terminal with shortcut (CTRL + \` or CTRL + SHIFT + \` ) or use toolbar option Terminal -> New Terminal
  2. Get your terminal location to WEB folder (write to terminal "cd ./src/Wasted.WEB" or full path to the src folder e.g "cd C:\_Projects\Wasted\src\Wasted.WEB")
  3. Use command "dotnet watch run". Web browser should open with url "http://localhost:5000".
  4. Done, start to edit the pages, don't forget to save them and have fun :).


<hr>

 ## Functionality
 Our app aims to minimize food waste by maximizing convenient shopping and making it easier to keep track of your pantry.
 <br>Each user has unique acces to these features: 
 

 ## •_Tips_ 
 ### community-based experience-sharing page, where you can find and share tips and tricks on how to store food, plan your meals and much more.
<img src=images/tips.png width="700" >

## •_Product list_ 
### convenient way to make sure that you don't miss out on important items on your next trip to the nearest grocery store
<img src=images/productList.png width="700">

## •_Recipe calculator_ 
### a way to keep track of your products and get notified about items that wil shortly expire. In addition, find meals which you can make using products you have.
<img src=images/recipeCalc.png width="700">

## •_Fridge_ 
### page to see all your products while planning your shopping list
<img src=images/fridge.png width="700">

