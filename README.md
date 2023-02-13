# b-it-test
Customer Manager Web app ( plain JS front end, .Net Core, MS SQL Server)


## Application stack 


### 1/ Pure javascript front end 
Basic grid, quick add customer name to insert record, that can be modified inline. 

Immediate next improvements:
- improve stlying overall 
- replace js library with jquery, knockoujs, vuejs or Kendo (latest free library required subcription so deferred) 
- UI validation
- use pop-up for quick add customer 
- add delete feature 

### 2/ .Net Core CRUD API, setupMS .Net Core scaffolding  
- see  https://localhost:|port|/swagger/index.html  

Immediate next improvements:
  - use DTOS for security and throttling 
  - use SignInManager for getting user Id when updating database records
  - improve endpoint documentation using annotations  
  - clean up redundant endpoints  


### 3/ Custome repo with Customers table in aspNet Security tables. 

  Immediate next improvements:
  - move Customer Table into separate database
  - redesign interfaces to allow use of non-Sql data sources
  - replace Dapper with more powerful ORM 
  
  
 ### 4 / Tests 
 
  Immediate next improvements:
  - API controller tests
  - Mock
  
## How to Run the site (windows) 
1/ Checkout the git repository 
2/  Start command prompt and navigate to the web application root folder  <local-folder>\BoroughITTest\CustomerManager\CustomerManager.Web
3/ Type "dotnet run". The site will build and display the server url and endpoint. If this hangs up press the space or any other key to get it moving.  Ctrl + C to stop the server. 
4/  Enter url in web browser 
5/  Register with username and password, then login
  
Potential issues
  If any issues with database connection
  1/ update connection string in appSettings.json. Replace |DataDirectory| with the system file path to your web solution e.g. c:\\Dev\|full-path|\BoroughITTest\CustomerManager\CustomerManager.Web\App_Data\aspnet-CustomerManager.Web-53bc9b9d-9d6a-45d4-8429-2a2761773502.mdf. Repeat Step 3 above. 
 2/  if issues persist, navigate to the App_Data folder,  find "aspnet-CustomerManager.Web-53bc9b9d-9d6a-45d4-8429-2a2761773502.mdf", right click. go to Security tab and  give "Full control" to "Authenticated Users" 
  
  
