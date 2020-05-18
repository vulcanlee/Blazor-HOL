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

    public class StudentGradeRazorModel
    {
        #region Constructor
        public StudentGradeRazorModel(IStudentGradeService CurrentService,
           SchoolContext SchoolContext,
           IMapper Mapper)
        {
            this.CurrentService = CurrentService;
            this.SchoolContext = SchoolContext;
            mapper = Mapper;
        }
        #endregion

        #region Property
        public SfGrid<StudentGradeAdaptorModel> Grid { get; set; }
        public bool IsShowEditRecord { get; set; } = false;
        public StudentGradeAdaptorModel CurrentRecord { get; set; } = new StudentGradeAdaptorModel();
        public StudentGradeAdaptorModel CurrentNeedDeleteRecord { get; set; } = new StudentGradeAdaptorModel();
        public EditContext LocalEditContext { get; set; }
        public bool ShowAontherRecordPicker { get; set; } = false;
        public CourseAdaptorModel Header { get; set; } = new CourseAdaptorModel();

        #region 訊息說明之對話窗使用的變數
        public ConfirmBoxModel ConfirmMessageBox { get; set; } = new ConfirmBoxModel();
        public MessageBoxModel MessageBox { get; set; } = new MessageBoxModel();
        #endregion

        public string EditRecordDialogTitle { get; set; } = "";
        #endregion

        #region Field
        bool isNewRecordMode;
        private readonly IStudentGradeService CurrentService;
        private readonly SchoolContext SchoolContext;
        private readonly IMapper mapper;
        IRazorPage thisRazorComponent;
        private bool isShowConfirm { get; set; } = false;
        #endregion

        #region Method
        public void Setup(IRazorPage componentBase,
            SfGrid<StudentGradeAdaptorModel> grid)
        {
            thisRazorComponent = componentBase;
            Grid = grid;
            //RazorModel
        }
        public void OnOpenPicker()
        {
            ShowAontherRecordPicker = true;
        }

        public void ToolbarClickHandler(Syncfusion.Blazor.Navigations.ClickEventArgs args)
        {
            if (args.Item.Text == "新增")
            {
                CurrentRecord = new StudentGradeAdaptorModel();
                EditRecordDialogTitle = "新增紀錄";
                isNewRecordMode = true;
                IsShowEditRecord = true;
                CurrentRecord.CourseId = Header.CourseId;
                CurrentRecord.CourseTitle = Header.Title;
            }
        }
        public void OnCommandClicked(CommandClickEventArgs<StudentGradeAdaptorModel> args)
        {
            StudentGradeAdaptorModel item = args.RowData as StudentGradeAdaptorModel;
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
                await CurrentService.DeleteAsync(mapper.Map<StudentGrade>(CurrentNeedDeleteRecord));
                Grid.Refresh();
            }
            ConfirmMessageBox.Hidden();
        }

        public void OnCancel()
        {
            IsShowEditRecord = false;
        }

        public async Task HandleValidSubmit()
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
                    await CurrentService.AddAsync(mapper.Map<StudentGrade>(CurrentRecord));
                    Grid.Refresh();
                }
                else
                {
                    await CurrentService.UpdateAsync(mapper.Map<StudentGrade>(CurrentRecord));
                    Grid.Refresh();
                }
                IsShowEditRecord = false;
            }
        }
        public void OnEditContestChanged(EditContext context)
        {
            LocalEditContext = context;
        }

        #region 開窗選取紀錄使用到的方法
        public void OnPickerCompletion(PersonAdaptorModel e)
        {
            if (e != null)
            {
                CurrentRecord.StudentId = e.PersonId;
                CurrentRecord.StudentName = e.FullName;
            }
            ShowAontherRecordPicker = false;
        }

        #endregion

        public void UpdateMasterHeader(CourseAdaptorModel header)
        {
            Header = header;
            Grid?.Refresh();
        }
        #endregion
    }
}
