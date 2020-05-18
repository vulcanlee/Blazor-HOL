# Blazor Hands-On 教育訓練專案原始碼

## 練習使用資料庫的建立方式

在 [Database] 資料夾內，找到 [SchemaAndData.sql](Database/SchemaAndData.sql) 檔案，將這裡的 SQL 指令，在指定的 SQL Server 來執行，便會自動建立起相關開發使用的資料庫。

## 產生 Entity Framework Core 的 dbContext 與 相關 Model

```
Scaffold-DbContext "Data Source=(localdb)\MSSQLLocalDB;Initial Catalog=School;Integrated Security=True;Connect Timeout=60;Encrypt=False;TrustServerCertificate=False;ApplicationIntent=ReadWrite;MultiSubnetFailover=False" Microsoft.EntityFrameworkCore.SqlServer -StartupProject DatabaseInit -Project EFCoreModel -OutputDir Models -f
```

|類型|專案名稱|專案說明|
|-|-|-|
||SyncfusionLab|使用 Syncfusion 元件來完成 Contoso University 的資料庫存取應用|
||MatBlazorLab|使用 Syncfusion 元件來完成 Contoso University 的資料庫存取應用|
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

* StudentGrade
* StudentGradeService
* StudentGradeAdaptorModel
* StudentGradeAdaptor
* StudentGradeRazorModel
* StudentGradeView
* StudentGradePage

* 建立 StudentGrade 的服務
* 建立 StudentGrade 轉接器 資料模型 Adaptor Data Model
* 建立 StudentGrade 服務與 Grid 元件要用到的 轉接器元件 Adaptor Component
* 建立 StudentGrade 頁面要用到的 Razor 資料模型 Razor Data Model
* 建立 StudentGrade CRUD 的 View 元件
* 建立 StudentGrade CRUD 的 Page 頁面


