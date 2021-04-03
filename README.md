# household-utility-resource-manager
Simple solution for managing water supply to households. Not recommended for production use.

Please consult client-app README for proper Project setup

# Running the project for the first time

## Frontend
1. Navigate to
      `../HurManager.App/client-app`
2. Install npm packages
```
    npm install
```
3. Run the client app
```
    npm run serve
```

## Backend
1. Set database connection settings `../HurManager.App/appsettings.json`
2. In Visual Studio's Package Manager Console switch to `HurManager.Dal` default project
3. Run Update database command
```
    update-database
```

## PS
Please first run frontend, so backend can succsessfully run `UseProxyToSpaDevelopmentServer`
