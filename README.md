# Blazor Hands-On 教育訓練專案原始碼

## 產生 Entity Framework Core 的 dbContext 與 相關 Model

```
Scaffold-DbContext "Data Source=(localdb)\MSSQLLocalDB;Initial Catalog=School;Integrated Security=True;Connect Timeout=60;Encrypt=False;TrustServerCertificate=False;ApplicationIntent=ReadWrite;MultiSubnetFailover=False" Microsoft.EntityFrameworkCore.SqlServer -StartupProject DatabaseInit -Project EFCoreModel -OutputDir Models -f
```

|類型|專案名稱|專案說明|
|-|-|-|
||||
||||
||||
||||
||||
||||
||||
||||
||||
||||
||||
||||
||||

## 單一資料表的 CRUD 開發步驟說明

* Department
* DepartmentService
* DepartmentAdaptorModel
* DepartmentAdaptor
* DepartmentRazorModel
* DepartmentView
* DepartmentPage

* 建立 Department 的服務
* 建立 Department 轉接器 資料模型 Adaptor Data Model
* 建立 Department 服務與 Grid 元件要用到的 轉接器元件 Adaptor Component
* 建立 Department 頁面要用到的 Razor 資料模型 Razor Data Model
* 建立 Department CRUD 的 View 元件
* 建立 Department CRUD 的 Page 頁面


