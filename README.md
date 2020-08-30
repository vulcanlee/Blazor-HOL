# Blazor Hands-On 教育訓練專案原始碼

![Contoso University for Blazor](Docs/Images/BHOL990.png)

這是一份專門針對 ASP.NET Core Blazor Server Side 類型專案所設計的教育訓練開發實作課程。在這份課程中，將會帶領學員從無到有的開發出 Contoso 大學的管理系統，並且將會使用免費的 [MatBlazor](https://www.matblazor.com/) UI 元件與 [Syncfusion](https://www.syncfusion.com/blazor-components) UI 原件來進行設計，在這個系統終將會包含了底下類型的應用：

* 單一資料表的 CRUD 新增、修改、刪除、查詢、搜尋、排序、分頁之設計方式
* 多對一的 CRUD 練習
* 多對多的 CRUD 練習
* 可以開啟視窗，選擇其他資料表內的紀錄

## 說明文件

* [事前準備工作](Docs/chapter01.md)
* [使用 Entity Framework Core 來存取資料庫](Docs/chapter02.md)

# 專案資料夾

|類型|專案名稱|專案說明|
|-|-|-|
|最終成品|SyncfusionLab|使用 Syncfusion 元件來完成 Contoso University 的資料庫存取應用|
|最終成品|MatBlazorLab|使用 MatBlazor 元件來完成 Contoso University 的資料庫存取應用|


|類型|專案名稱|專案說明|
|-|-|-|
|練習情境|Labs/EFCoreReverseEngineering|使用資料庫反向工程，取得 EF Core 的資料模型|
|練習情境|Labs/DBEntityFrameworkCore|Console 專案與 EF Core 讀取已經存在的資料庫|
|練習情境|Labs/CodeFirstEntityFrameworkCore|Console 專案與 EF Core Code First 讀取資料庫|
|練習情境|Labs/EFRelation|一對多的資料讀取 - 讀取關聯式資料表的紀錄操作方式|
|挑戰練習|Labs/DBEntityFrameworkCoreCRUD/Starter|用 Console 專案對 person 資料表做 CRUD 存取|
|範例體驗|Labs/DBUpdateRecord|逐一設定更新欄位來進行資料表紀錄更新|
|範例體驗|Labs/DBUpdateDirectly|簡化更新，不需要逐一設定欄位|
|範例體驗|Labs/DBUpdateChangeTrackingFail|使用實體狀態來做更新相關欄位 (會有什麼問題)|
|練習情境|Labs/DBUpdateChangeTracking|使用實體狀態來做更新相關欄位|
|練習情境|Labs/bzEntityFrameworkCore|使用 Blaozr 專案來顯示出 person 所有紀錄|
|挑戰練習|Labs/bzEntityFrameworkCoreBS4\Starter|使用 table 標籤與 BS4 來格式化 person 所有紀錄|
|挑戰練習|Labs/bzBS4Dialog|使用 BootStrap 4 的對話窗功能|
|挑戰練習|Labs/bzBS4RecordsEdit|BS4 的表格與對話窗綜合開發應用|
|範例體驗|Labs/bzSyncfusionCRUDMemory|使用 Syncfusion DataGrid 元件設計 CRUD|
|挑戰練習|Labs/bzSyncfusionDialog|使用 Syncfusion Dialog 對話窗功能|
|範例體驗|Labs/bzFormValidation|Blazor 的表單驗證設計練習|
|挑戰練習|Labs/bzFormValidationDialog|使用對話窗來進行表單驗證設計練習(動態顯示與隱藏)|
|練習情境|Labs/WhyAutoMapper|AutoMapper 使用範例|
|範例體驗|Labs/bzBuildRenderTree|了解 Render Tree 渲染樹的執行過程 |
|練習情境|Labs/bzFromEmpty|從 空白專案 建立 Blazor|
|練習情境|Labs/PureDI|Hello DI - 原先類別相依於抽象、具體類別要實作該介面|
|範例體驗|Labs/ASPNETCoreDefaultService|查看 ASP.NET Core 預設產生的服務|
||Labs/||
||Labs/||
||Labs/||
||Labs/||
||||
||||
||||


