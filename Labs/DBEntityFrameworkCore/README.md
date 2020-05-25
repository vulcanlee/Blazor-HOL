# 使用 Entity Framework Core 來存取資料庫

```csharp
using DBEntityFrameworkCore.Model;
using Microsoft.EntityFrameworkCore;
using System;
using System.Linq;
using System.Threading.Tasks;

namespace DBEntityFrameworkCore
{
    class Program
    {
        static async Task Main(string[] args)
        {
            SchoolContext context = new SchoolContext();
            var people = await context.Person
                .OrderBy(x=>x.LastName)
                .ThenBy(x=>x.FirstName)
                .ToListAsync();
            foreach (var item in people)
            {
                Console.WriteLine($"人員:{item.LastName} {item.FirstName}");
            }
        }
    }
}
```

![](../../Docs/Images/BHOL987.png)

