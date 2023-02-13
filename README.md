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
- Checkout the git repository 
- Start command prompt and navigate to the web application root folder  <local-folder>\BoroughITTest\CustomerManager\CustomerManager.Web
- Type "dotnet run". The site will build and display the server url and endpoint 
- Enter url in web browser 
- Register with username and password, then login 
  
  
