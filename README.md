# DotNet8WebApi.HexagonalWithResultPattern

### EF scaffold Db Context Command
> dotnet ef dbcontext scaffold "Server=.;Database=testDb;User ID=sa;Password=sasa@123;TrustServerCertificate=True;" Microsoft.EntityFrameworkCore.SqlServer -o AppDbContexts -c AppDbContext

### If Command Not Found Issue occurs
> dotnet tool install --global dotnet-ef --version 7
