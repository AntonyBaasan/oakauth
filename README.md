# OakAuth
Simple monolithic authorization server. <a href="https://oakauth.azurewebsites.net" target="_blank">Demo</a>

## Build
OakAuth.Dotnet: [![Build Status](https://antonybaasan.visualstudio.com/OakAuth/_apis/build/status/OakAuth.Dotnet?branchName=master)](https://antonybaasan.visualstudio.com/OakAuth/_build/latest?definitionId=2&branchName=master)

OakAuth.ClientApp: [![Build Status](https://antonybaasan.visualstudio.com/OakAuth/_apis/build/status/OakAuth.ClientApp?branchName=master)](https://antonybaasan.visualstudio.com/OakAuth/_build/latest?definitionId=3&branchName=master)

OakAuth.DeployToAzure: [![Build Status](https://antonybaasan.visualstudio.com/OakAuth/_apis/build/status/OakAuth.DeployToAzure?branchName=master)](https://antonybaasan.visualstudio.com/OakAuth/_build/latest?definitionId=4&branchName=master)

## Getting Started

### Server build

```
dotnet build
```

### Server tests
```
# unit tests
dotnet test test/OakAuth.UnitTests

# integration tests
dotnet test test/OakAuth.IntegrationTests

# all tests
dotnet test
```
### Client commands
```
cd src/Web/ClientApp
npm run lint
npm run test
npm run test_headless
npm run build
```

