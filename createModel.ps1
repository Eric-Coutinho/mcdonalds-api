$strconn = "Data Source=CT-C-001YR\SQLEXPRESS" +  ";Initial Catalog=McDataBase" + ";Integrated Security=True;TrustServerCertificate=true"

dotnet add package Microsoft.EntityFrameworkCore.Design
dotnet add package Microsoft.EntityFrameworkCore.SqlServer
dotnet tool install --global dotnet-ef
dotnet ef dbcontext scaffold $strconn Microsoft.EntityFrameworkCore.SqlServer --force -o Model

