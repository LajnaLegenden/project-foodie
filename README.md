
# project-foodie
**Development server**: https://devfoodie.linusjansson.com/

## CI
[![GitlabSync](https://github.com/LajnaLegenden/project-foodie/actions/workflows/sync.yml/badge.svg)](https://github.com/LajnaLegenden/project-foodie/actions/workflows/sync.yml)

## Contribute

#### Install .net 7.0
More information can be found here:
https://learn.microsoft.com/en-us/dotnet/core/install/

#### Start development server
Go to `/src`
```bash
dotnet watch
```
#### Database
We use SQLite during development, the database should be placed in `/data/foodie/sqlite.db`
 
Migrate database:
```bash
dotnet ef migrations add <MigrationName>
```

Create database and schemas from migrations:
```bash
dotnet ef database update
```
More information can be found [here](https://learn.microsoft.com/en-us/ef/core/managing-schemas/migrations/?tabs=dotnet-core-cli).

#### Push to repository
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
