# The Seattle Pour
#### Author:
Teddy Damian || Carrington Beard
## Description
This E-COM project is made to sell Resin Pour product, handmade here in Seattle.
We utilized ASP.NET Core Identity, and style the page with bootstrap.
Pages should be rendered perfectly on browser and responsive to screen size.
The claims that we use includes
- First Name
- Last Name
- Email
- Password

## The Seattle Pour
---
### We are deployed on Azure!

[https://ecomproject.azurewebsites.net/]

---
## Web Application


The web application consists of a frontend written in Razor views, HTML, CSS, and
Bootstrap. The backend was written in C# using ASP.NET Core 2, Entity Framework Core, and the MVC framework.

This is an E-Commerce web application that displays and offers the ability to purchase different acrylic pour paintings and tables. It incorporates ASP.NET Identity for unique user profiles with log in and log out functionality. There is an admin only page where the inventory can be managed by any user with an approved admin role. This web app utilizes full CRUD for inventory management;.
---

## Tools Used
Microsoft Visual Studio Community 2019

- C#
- ASP.Net Core
- Entity Framework
- MVC
- xUnit
- Bootstrap
- Azure

---

## Recent Updates

#### V 1.0
*Created Log in, log out and register pages.* - 20 Apr 2020
*Added Admin roles and an admin dashboard for inventory management* - 28 Apr 2020
*Created `my cart` view model that persists on every page* - 01 May 2020
*Re-vamped styling and layout, updated README* 03 May 2020

---

## Getting Started

Clone this repository to your local machine.

```
$ git clone https://carringtonbeard@dev.azure.com/carringtonbeard/401Ecom/_git/401Ecom
```
Once downloaded, you can either use the dotnet CLI utilities or Visual Studio 2019 (or greater) to build the web application. The solution file is located in the EcomProject subdirectory at the root of the repository.
```
cd 401Ecom/EcomProject
dotnet build
```
The dotnet tools will automatically restore any NuGet dependencies.
```
Update-Database
```
Once the database has been created, the application can be run. Options for running and debugging the application using IIS Express or Kestrel are provided within Visual Studio. From the command line, the following will start an instance of the Kestrel server to host the application:
```
cd 401Ecom/EcomProject
dotnet run
```


---

## Usage

### Logging In
![Registering For Site](https://i.imgur.com/rv1SCgx.png)

### Admin Page
![Admin Page](https://i.imgur.com/7llqHul.png)

### Catalogue with Cart
![Cart](https://i.imgur.com/1J6YB1b.png)

---

### Overall Project Schema
***[This app includes an Identity Database for storing users and passwords. This database is called on from the front end whenever a user registers or logs in. It is also called anytime a user tries to access different areas of the site, based on their assigned roles. The app also has an inventory database that is constantly able to be updated as products are added and sold. This database is called to render all the products on the catalogue page, and whenever a user adds an item to their cart or makes a purchase.]***


---
## Model Properties and Requirements

### Blog

| Parameter | Type | Required |
| --- | --- | --- |
| ID  | int | YES |
| SKU | string | YES |
| Price | Decimal | YES |
| Decription | string(s) | Yes |
| Picture | img jpeg/png | Yes |
| Size | string | NO |
| Color | string | NO |
| Finish | string | NO |
| Material | string | No |


### User

| Parameter | Type | Required |
| --- | --- | --- |
| ID  | int | YES |
| Password | string | YES |
| Email | string | YES |

---

## Change Log
 
1.4: *Created Log in, log out and register pages.* - 20 Apr 2020
1.3: *Added Admin roles and an admin dashboard for inventory management* - 28 Apr 2020
1.2: *Created `my cart` view model that persists on every page* - 01 May 2020
1.1: *Re-vamped styling and layout, updated README* 03 May 2020


---

## Authors
Carrington Beard
Teddy Damian

---
