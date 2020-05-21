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

    public class StudentGradeAdaptor
    {
        public int HeaderID { get; set; }
        public StudentGradeAdaptor(IStudentGradeService service
            , IMapper mapper)
        {
            this.Service = service;
            Mapper = mapper;
        }

        public IStudentGradeService Service { get; }
        public IPersonService PersonService { get; }
        public IMapper Mapper { get; }

        public async Task<object> ReadAsync(DataManagerRequest dataManagerRequest, string key = null)
        {
            IQueryable<StudentGrade> DataSource;
            if(HeaderID == -1)
            {
                DataSource= await Service.GetAsync();
            }
            else
            {
                DataSource= await Service.GetByHeaderIDAsync(HeaderID);
            }
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
                DataSource = DataSource.OrderBy(x => x.Student.LastName).ThenBy(x=>x.Student.FirstName);
            }

            // 取得記錄總數量，將要用於分頁元件面板使用
            int count = DataSource.Cast<StudentGrade>().Count();

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
            List<StudentGradeAdaptorModel> adaptorModelObjects =
            Mapper.Map<List<StudentGradeAdaptorModel>>(items);

            #region 在這裡進行 轉接器 資料模型 的額外屬性初始化
            foreach (var adaptorModelItem in adaptorModelObjects)
            {
                var searchItem = items.FirstOrDefault(x => x.EnrollmentId == adaptorModelItem.EnrollmentId);
                adaptorModelItem.CourseTitle = searchItem.Course.Title;
                adaptorModelItem.StudentName = $"{searchItem.Student.LastName} {searchItem.Student.FirstName}";
            }
            #endregion

            var item = dataManagerRequest.RequiresCounts
            ? new DataResult<StudentGradeAdaptorModel>() { Result = adaptorModelObjects, Count = count }
            : (object)adaptorModelObjects;
            await Task.Yield();
            return item;
        }
    }
}
