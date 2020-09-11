using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace School.WebApp.RazorModels
{
    using AutoMapper;
    using EFCore.Models;
    using School.WebApp.AdapterModels;
    using School.WebApp.Interfaces;
    using School.WebApp.Services;
    using Syncfusion.Blazor.Grids;
    using Microsoft.AspNetCore.Components.Forms;
    using School.WebApp.Helpers;
    using School.WebApp.SortModels;
    using ShareDomain.DataModels;

    public class CourseRazorModel
    {
        #region Constructor
        public CourseRazorModel(ICourseService CurrentService,
           SchoolContext context,
           IMapper Mapper)
        {
            this.CurrentService = CurrentService;
            this.context = context;
            mapper = Mapper;
            CourseSort.Initialization(SortConditions);
        }
        #endregion

        #region Property
        public bool IsShowEditRecord { get; set; } = false;
        public CourseAdapterModel CurrentRecord { get; set; } = new CourseAdapterModel();
        public CourseAdapterModel CurrentNeedDeleteRecord { get; set; } = new CourseAdapterModel();
        public EditContext LocalEditContext { get; set; }
        public bool ShowAontherRecordPicker { get; set; } = false;
        public List<SortCondition> SortConditions { get; set; } = new List<SortCondition>();
        public SortCondition CurrentSortCondition { get; set; } = new SortCondition();


        #region 訊息說明之對話窗使用的變數
        public ConfirmBoxModel ConfirmMessageBox { get; set; } = new ConfirmBoxModel();
        public MessageBoxModel MessageBox { get; set; } = new MessageBoxModel();
        #endregion

        public string EditRecordDialogTitle { get; set; } = "";
        #endregion

        #region Field
        bool isNewRecordMode;
        private readonly ICourseService CurrentService;
        private readonly SchoolContext context;
        private readonly IMapper mapper;
        IRazorPage thisRazorComponent;
        IDataGrid dataGrid;
        private bool isShowConfirm { get; set; } = false;
        #endregion

        #region Method
        #region DataGrid 初始化
        public void Setup(IRazorPage razorPage, IDataGrid dataGrid)
        {
            thisRazorComponent = razorPage;
            this.dataGrid = dataGrid;
        }
        #endregion

        #region 工具列事件 (新增)
        public void ToolbarClickHandler(Syncfusion.Blazor.Navigations.ClickEventArgs args)
        {
            if (args.Item.Text == "新增")
            {
                CurrentRecord = new CourseAdapterModel();
                EditRecordDialogTitle = "新增紀錄";
                isNewRecordMode = true;
                IsShowEditRecord = true;
            }
            else if (args.Item.Text == "重新整理")
            {
                dataGrid.RefreshGrid();
            }
        }
        #endregion

        #region 記錄列的按鈕事件 (修改與刪除)
        public void OnCommandClicked(CommandClickEventArgs<CourseAdapterModel> args)
        {
            CourseAdapterModel item = args.RowData as CourseAdapterModel;
            if (args.CommandColumn.ButtonOption.Content == "修改")
            {
                CurrentRecord = item;
                EditRecordDialogTitle = "修改紀錄";
                IsShowEditRecord = true;
                isNewRecordMode = false;

            }
            else if (args.CommandColumn.ButtonOption.Content == "刪除")
            {
                #region 檢查關聯資料是否存在
                #endregion
                CurrentNeedDeleteRecord = item;
                ConfirmMessageBox.Show("400px", "200px", "警告", "確認要刪除這筆紀錄嗎？");
            }
        }

        public async Task RemoveThisRecord(bool NeedDelete)
        {
            if (NeedDelete == true)
            {
                await CurrentService.DeleteAsync(mapper.Map<Course>(CurrentNeedDeleteRecord));
                dataGrid.RefreshGrid();
            }
            ConfirmMessageBox.Hidden();
        }
        #endregion

        #region 修改紀錄對話窗的按鈕事件
        public void OnEditContestChanged(EditContext context)
        {
            LocalEditContext = context;
        }

        public void OnRecordEditCancel()
        {
            IsShowEditRecord = false;
        }

        public async Task OnRecordEditConfirm()
        {
            #region 進行 Form Validation 檢查驗證作業
            if (LocalEditContext.Validate() == false)
            {
                return;
            }
            #endregion

            #region 檢查資料完整性
            #endregion

            if (IsShowEditRecord == true)
            {
                if (isNewRecordMode == true)
                {
                    await CurrentService.AddAsync(mapper.Map<Course>(CurrentRecord));
                    dataGrid.RefreshGrid();
                }
                else
                {
                    await CurrentService.UpdateAsync(mapper.Map<Course>(CurrentRecord));
                    dataGrid.RefreshGrid();
                }
                IsShowEditRecord = false;
            }
        }
        #endregion

        #region 開窗選取紀錄使用到的方法
        public void OnOpenPicker()
        {
            ShowAontherRecordPicker = true;
        }

        public void OnPickerCompletion(DepartmentAdapterModel e)
        {
            if (e != null)
            {
                CurrentRecord.DepartmentId = e.DepartmentId;
                CurrentRecord.DepartmentName = e.Name;
            }
            ShowAontherRecordPicker = false;
        }
        #endregion

        #region 排序搜尋事件

        public void SortChanged(Syncfusion.Blazor.DropDowns.ChangeEventArgs<int> args)
        {
            if (dataGrid.GridIsExist() == true)
            {
                CurrentSortCondition.Id = args.Value;
                dataGrid.RefreshGrid();
            }
        }

        #endregion
        #endregion
    }
}
