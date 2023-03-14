
# project-foodie
**Development server**: https://devfoodie.linusjansson.com/

## CI
[![GitlabSync](https://github.com/LajnaLegenden/project-foodie/actions/workflows/sync.yml/badge.svg)](https://github.com/LajnaLegenden/project-foodie/actions/workflows/sync.yml)

## Contribute

### Install .net 7.0
More information can be found here:
https://learn.microsoft.com/en-us/dotnet/core/install/

### Start development server
Go to `/src`
```bash
dotnet watch
```
### Database 
#### Install and start MariaDB
```bash
sudo apt update
sudo apt install mariadb-server
sudo service mariadb start
```
#### Configure MariaDB
```bash
sudo mysql_secure_installation  
```
#### Create local development database
* open mariaDB in terminal: 
``` 
sudo mariadb
```
* in mariadb:
```
create database foodie_dev
create user "foodie" identified by "pass";
Grant all privileges on foodie_dev.* to "foodie";
```

#### Migrate database:
```bash
dotnet ef migrations add <MigrationName>
```

#### Repository pattern:
We use an abstraction layer between the data access and bussines logic layer of the application, by using repositories when working against the database. All repositories can be accessed via the RepositoryWrapper class. 

```
ex. get all orders: 
    repository = new RepositoryWrapper(db);
    repository.Order.getAllAsync();
```
When making changes to the database, call `await repository.SaveAsync();` when all modifications are done.


```
ex. create an order: 
    var order = new Order
    {
        userId = 1,
        menu = await repository.Menu.GetByIdAsync(menu.Id),
        orderDate = DateTime.Now,
        orderItems = new List<OrderItem>()
    };

    repository = new RepositoryWrapper(db);
    repository.Order.AddOrder(order);
    await repository.SaveAsync();

```

#### Create database and schemas from migrations:
```bash
dotnet ef database update
```
More information can be found [here](https://learn.microsoft.com/en-us/ef/core/managing-schemas/migrations/?tabs=dotnet-core-cli).

### Push to repository
- Create a branch from develop named after Jira backlog
```
git checkout dev
```
```
git checkout -b <Jira backlog ex. CBG-237>
```
 
 - Push branch, create pull request and request review from at least one team member.
 - When the pull request is approved, merge the branch to dev. 
 
 At the end of each sprint we merge dev to main with tags. 


## Folder structure

   #### Pages and Components
    .
    ├── Shared
    |	└── Components
    ├── Pages
    │   └── [pagename]
	|		├── pagename.razor
    │   	└── components 
	|			└── component.razor
    └── ...

- Shared components:  `Shared/Components`
- Pages:  `Pages/[pagename]/pagename.razor`
- Page specific components : `Pages/[pagename]/components/component.razor`
