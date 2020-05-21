using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace MatBlazorLab.Adaptors
{
    using AutoMapper;
    using EFCoreModel.Models;
    using MatBlazorLab.AdaptorModels;
    using MatBlazorLab.Services;
    using Microsoft.EntityFrameworkCore;
    using System.Threading;

    public class DepartmentAdaptor
    {
        public DepartmentAdaptor(IDepartmentService service
            , IMapper mapper)
        {
            this.Service = service;
            Mapper = mapper;
        }

        public IDepartmentService Service { get; }
        public IPersonService PersonService { get; }
        public IMapper Mapper { get; }

        public async Task<object> ReadAsync(DataManagerRequest dataManagerRequest, string key = null)
        {
            IQueryable<Department> DataSource = await Service.GetAsync();
            if (dataManagerRequest.Search != null && dataManagerRequest.Search.Count > 0)
            {
                // 進行搜尋動作
            }
            if (dataManagerRequest.Sorted != null && dataManagerRequest.Sorted.Count > 0)
            {
                // 進行排序動作
            }
            else
            {
                // 進行預設排序
                DataSource = DataSource.OrderBy(x => x.Name);
            }

            // 取得記錄總數量，將要用於分頁元件面板使用
            int count = DataSource.Cast<Department>().Count();

            #region 進行分頁處理
            if (dataManagerRequest.Skip != 0)
            {
                //分頁
                DataSource = DataSource.Skip(dataManagerRequest.Skip);
            }
            if (dataManagerRequest.Take != 0)
            {
                DataSource = DataSource.Take(dataManagerRequest.Take);
            }
            #endregion

            #region 想要做 Table Join 的查詢，也可以在這裡進行呼叫

            #endregion

            var items = DataSource.ToList();
            List<DepartmentAdaptorModel> adaptorModelObjects =
            Mapper.Map<List<DepartmentAdaptorModel>>(items);

            #region 在這裡進行 轉接器 資料模型 的額外屬性初始化
            foreach (var adaptorModelItem in adaptorModelObjects)
            {
                if (adaptorModelItem.Administrator.HasValue)
                {
                    var id = Thread.CurrentThread.ManagedThreadId;
                    var itemReference = Service.GetAdministrator(adaptorModelItem.Administrator.Value);
                    if (itemReference != null)
                    {
                        adaptorModelItem.FullName = $"{itemReference.LastName} {itemReference.FirstName}";
                    }
                }
            }
            #endregion

            #region 解決問題 InvalidOperationException: A second operation started on this context before a previous operation completed
            //List<DepartmentAdaptorModel> adaptorModelObjects=new List<DepartmentAdaptorModel>();
            //await Task.Run(async() =>
            //{
            //    var items = DataSource.ToList();
            //    adaptorModelObjects =
            //    Mapper.Map<List<DepartmentAdaptorModel>>(items);

            //    #region 在這裡進行 轉接器 資料模型 的額外屬性初始化
            //    foreach (var adaptorModelItem in adaptorModelObjects)
            //    {
            //        if (adaptorModelItem.Administrator.HasValue)
            //        {
            //            var id = Thread.CurrentThread.ManagedThreadId;
            //            var itemReference = PersonService.Get(adaptorModelItem.Administrator.Value);
            //            if (itemReference != null)
            //            {
            //                adaptorModelItem.FullName = $"{itemReference.FirstName} {itemReference.LastName}";
            //            }
            //        }
            //    }
            //    #endregion
            //});
            #endregion


            var item = dataManagerRequest.RequiresCounts
            ? new DataResult<DepartmentAdaptorModel>() { Result = adaptorModelObjects, Count = count }
            : (object)adaptorModelObjects;
            await Task.Yield();
            return item;
        }
    }
}
