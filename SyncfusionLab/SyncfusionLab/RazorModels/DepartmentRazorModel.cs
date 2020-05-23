using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace SyncfusionLab.RazorModels
{
    using AutoMapper;
    using EFCoreModel.Models;
    using SyncfusionLab.AdaptorModels;
    using SyncfusionLab.Interfaces;
    using SyncfusionLab.Services;
    using Syncfusion.Blazor.Grids;
    using Microsoft.AspNetCore.Components.Forms;

    public class DepartmentRazorModel
    {
        #region Constructor
        public DepartmentRazorModel(IDepartmentService CurrentService,
           SchoolContext SchoolContext,
           IMapper Mapper)
        {
            this.CurrentService = CurrentService;
            this.SchoolContext = SchoolContext;
            mapper = Mapper;
            InitializeSortCondition();
        }
        #endregion

        #region Property
        public SfGrid<DepartmentAdaptorModel> Grid { get; set; }
        public bool IsShowEditRecord { get; set; } = false;
        public DepartmentAdaptorModel CurrentRecord { get; set; } = new DepartmentAdaptorModel();
        public DepartmentAdaptorModel CurrentNeedDeleteRecord { get; set; } = new DepartmentAdaptorModel();
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
        private readonly IDepartmentService CurrentService;
        private readonly SchoolContext SchoolContext;
        private readonly IMapper mapper;
        IRazorPage thisRazorComponent;
        private bool isShowConfirm { get; set; } = false;
        #endregion

        #region Method
        #region DataGrid 初始化
        public void Setup(IRazorPage componentBase,
            SfGrid<DepartmentAdaptorModel> grid)
        {
            thisRazorComponent = componentBase;
            Grid = grid;
            //RazorModel
        }
        #endregion

        #region 工具列事件 (新增)
        public void ToolbarClickHandler(Syncfusion.Blazor.Navigations.ClickEventArgs args)
        {
            if (args.Item.Text == "新增")
            {
                CurrentRecord = new DepartmentAdaptorModel();
                EditRecordDialogTitle = "新增紀錄";
                isNewRecordMode = true;
                IsShowEditRecord = true;
            }
        }
        #endregion

        #region 記錄列的按鈕事件 (修改與刪除)
        public void OnCommandClicked(CommandClickEventArgs<DepartmentAdaptorModel> args)
        {
            DepartmentAdaptorModel item = args.RowData as DepartmentAdaptorModel;
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
                await CurrentService.DeleteAsync(mapper.Map<Department>(CurrentNeedDeleteRecord));
                Grid.Refresh();
            }
            ConfirmMessageBox.Hidden();
        }
        #endregion

        #region 修改紀錄對話窗的按鈕事件
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
                    await CurrentService.AddAsync(mapper.Map<Department>(CurrentRecord));
                    Grid.Refresh();
                }
                else
                {
                    await CurrentService.UpdateAsync(mapper.Map<Department>(CurrentRecord));
                    Grid.Refresh();
                }
                IsShowEditRecord = false;
            }
        }

        public void OnEditContestChanged(EditContext context)
        {
            LocalEditContext = context;
        }
        #endregion

        #region 開窗選取紀錄使用到的方法
        public void OnOpenPicker()
        {
            ShowAontherRecordPicker = true;
        }

        public void OnPickerCompletion(PersonAdaptorModel e)
        {
            if (e != null)
            {
                CurrentRecord.Administrator = e.PersonId;
                CurrentRecord.FullName = e.FullName;
            }
            ShowAontherRecordPicker = false;
        }

        #endregion

        #region 排序搜尋事件
        private void InitializeSortCondition()
        {
            SortConditions.Clear();
            SortConditions.Add(new SortCondition()
            {
                Id = "Name Ascending",
                Title = "名稱 遞增"
            });
            SortConditions.Add(new SortCondition()
            {
                Id = "Name Descending",
                Title = "名稱 遞減"
            });
            SortConditions.Add(new SortCondition()
            {
                Id = "Budget Ascending",
                Title = "預算 遞增"
            });
            SortConditions.Add(new SortCondition()
            {
                Id = "Budget Ascending",
                Title = "預算 遞減"
            });
        }

        public void SortChanged(Syncfusion.Blazor.DropDowns.ChangeEventArgs<string> args)
        {
            if (Grid != null)
            {
                CurrentSortCondition.Id = args.Value;
                Grid.Refresh();
            }
        }

        #endregion
        #endregion
    }
}

