# MySqlMVCIdentity
MySql MVC Identity Implementation using Code First with EF6

## Introduction
Prior to MVC 5 Membership providers were used which facilitates developers with having login system to their sites out of the box. The Membership providers are quite helpful with a few flaws i.e. their inability to be customized and applying joins with user-defined tables. 

MVC 5 introduced a Membership mechanism which is called `Identity` , It offers numerious interfaces which can be used to write a custom Membership provider for any of the DBMS available.

Following is the description of our implementation of `Identity` for MySql Database using Code-First.

###Solution Implementation

It contains two projects.
* **AspNet.Identity.MySQL**
* **MVCappWithMySQL**

###AspNet.Identity.MySQL
This project contains actual implementation of Identity with MySQL database.It contains two main folders:

- Models
- Repositories

####Models
This folder contains all the models which are required for Identity.

#####IdentityRole: 
This Model is inheriting from IRole. Because Microsoft provides IRole interface so that we can customize the role table.

#####IdentityUser:
This Model is inheriting from IUser. Because Microsoft provides IUser interface so that we can customize the user table.

#####UserClaims: 
This Model (Original name is UserClaim) is the part of MVC identity. There was a problem, that .net haven't provide option to customize this(UserClaim) table. So we have create a model name UserClaims. By using fluent api have save this table name UserClaim which was the actual requirement of Identity.

#####UserLoginTable:
This Model (Original name is UserLogins) is the part of MVC identity. There was same problem, no option to customize this(UserLogins) table. So we have create a model name UserLoginTable. By using fluent api have save this table name UserLogins which was the actual requirement of Identity.

#####UserRolesTable: 
This Model (Original name is UserRoles) is the part of MVC identity. There was same problem, no option to customize this(UserRoles) table. So we have create a model name UserRolesTable. By using fluent api have save this table name UserRoles which was the actual requirement of Identity.

####Repositories

This folder contains all the Repositories that will perform actions on the database.

####.Net Identity Required Repository Classes

**RoleStoreRepository:**
This repository is the requirement of .net Identity. This repository class implementing the `IQueryableRoleStore<TRole>where TRole : IdentityRole` so that owin context role manager can use this class to perform required action on roles. So in this class all the methods of the interface is implemented. This class is calling the RoleTableRepository to perform CRUD operations.

**UserStoreRepository:**
This repository is the requirement of .net Identity. This repository class implementing the multiple interface so that owin context user manager can use this class to perform required action on users. So in this class all the methods of the interfaces are implemented.This class is calling the UserTableRepository to perform CRUD operations.

####Custom Repository Classes

**RoleTableRepository:** This repository is to perform more actions on Roles as per our requirement.

**UserClaimsTableRepository:** This repository is to perform actions on UserClaim table as per our requirement.

**UserLoginsTableRepository:** This repository is to perform actions on UserLogins table as per our requirement.

**UserRolesTableRepository:** This repository is to perform actions on UserRoles table as per our requirement.

**UserTableRepository:** This repository is to perform actions on User table as per our requirement.

####MySQLDatabase
This is the class that is extending from the DBContext class.
MVCappWithMySQL
This project is the MVC 5 that is using the identity we have customize in the above project. All the implementation in this project is same like if we use SqlServer for Identity.

#####Conclusion
This MySQL customization we have done is too much flexible and customize-able. Because everything is in our control, we will be able to use the same context for our identity tables and our custom table, so that we can perform joins with identity tables.

####Reference Links

-  [Codeplex Original Sample Code](https://aspnet.codeplex.com/SourceControl/latest#Samples/Identity/AspNet.Identity.MySQL/)
- [AspNet Implementing a Custom Identity](http://www.asp.net/identity/overview/extensibility/implementing-a-custom-mysql-aspnet-identity-storage-provider)
