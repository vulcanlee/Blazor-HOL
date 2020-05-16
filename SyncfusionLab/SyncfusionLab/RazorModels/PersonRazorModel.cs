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
    public class PersonRazorModel
    {
        #region Constructor
        public PersonRazorModel(PersonService CurrentService,
           SchoolContext SchoolContext,
           IMapper Mapper)
        {
            this.CurrentService = CurrentService;
            this.SchoolContext = SchoolContext;
            mapper = Mapper;
        }
        #endregion

        #region Property
        public SfGrid<PersonAdaptorModel> Grid { get; set; }
        public string[] InitSearch = (new string[] { "Name" });
        public bool isVisibleRecord { get; set; } = false;
        public PersonAdaptorModel CurrentRecord { get; set; } = new PersonAdaptorModel();
        public PersonAdaptorModel CurrentNeedDeleteRecord { get; set; } = new PersonAdaptorModel();


        #region 訊息說明之對話窗使用的變數
        public ConfirmBoxModel ConfirmMessageBox { get; set; } = new ConfirmBoxModel();
        public MessageBoxModel MessageBox { get; set; } = new MessageBoxModel();
        #endregion

        public string DialogTitle { get; set; } = "";
        #endregion

        #region Field
        public bool ShowPicker { get; set; } = false;
        bool newRecordMode;
        private readonly PersonService CurrentService;
        private readonly SchoolContext SchoolContext;
        private readonly IMapper mapper;
        IRazorPage thisRazorComponent;
        private bool isVisibleConfirm { get; set; } = false;
        #endregion

        #region Method
        public void Setup(IRazorPage componentBase,
            SfGrid<PersonAdaptorModel> grid)
        {
            thisRazorComponent = componentBase;
            Grid = grid;
            //RazorModel
        }
        public void OnOpenPicker()
        {
            ShowPicker = true;
        }

        public void ToolbarClickHandler(Syncfusion.Blazor.Navigations.ClickEventArgs args)
        {
            if (args.Item.Text == "新增")
            {
                CurrentRecord = new PersonAdaptorModel();
                DialogTitle = "新增紀錄";
                newRecordMode = true;
                isVisibleRecord = true;
            }
        }
        public void OnCommandClicked(CommandClickEventArgs<PersonAdaptorModel> args)
        {
            PersonAdaptorModel item = args.RowData as PersonAdaptorModel;
            if (args.CommandColumn.ButtonOption.Content == "修改")
            {
                CurrentRecord = item;
                DialogTitle = "修改紀錄";
                isVisibleRecord = true;
                newRecordMode = false;

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
                await CurrentService.DeleteAsync(mapper.Map<Person>(CurrentNeedDeleteRecord));
                Grid.Refresh();
            }
            ConfirmMessageBox.Hidden();
        }

        public void OnCancel()
        {
            isVisibleRecord = false;
        }

        public async Task HandleValidSubmit()
        {
            if (isVisibleRecord == true)
            {
                if (newRecordMode == true)
                {
                    await CurrentService.AddAsync(mapper.Map<Person>(CurrentRecord));
                    Grid.Refresh();
                }
                else
                {
                    await CurrentService.UpdateAsync(mapper.Map<Person>(CurrentRecord));
                    Grid.Refresh();
                    //thisRazorComponent.NeedRefresh();
                }
                isVisibleRecord = false;
            }
        }

        #endregion
    }
}
