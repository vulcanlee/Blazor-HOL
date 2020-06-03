using Newtonsoft.Json;
using System;
using System.Collections.Generic;
using System.Net.Http;
using System.Text;
using System.Threading.Tasks;
using xfLab.DTOs;
using xfLab.Helpers.Constants;
using xfLab.Helpers.WebAPIs;
using xfLab.Models;
using xfLab.Models.BaseAPIModels;

namespace xfLab.Services
{
    public class LoginService : BaseWebAPI<LoginData>
    {
        public LoginService()
            : base()
        {
            //資料檔案名稱 = "SampleRepository.txt";
            //this.url = "/webapplication/ntuhwebadminapi/webadministration/T0/searchDoctor";
            this.url = "Login";
            this.host = ConstantHelper.APIHostBase;
        }

        public async Task<ManagerResult> PostAsync(LoginQueryString LoginQueryString)
        {
            IsCollection = false;
            NeedSaveToStorage = true;
            EncodingType = EncodingMethod.JSON;

            #region 要傳遞的參數
            //Dictionary<string, string> dic = new Dictionary<string, string>();
            WebQueryDictionary dic = new WebQueryDictionary();

            // ---------------------------- 另外兩種建立 QueryString的方式
            //dic.Add(Global.getName(() => memberSignIn_QS.app), memberSignIn_QS.app);
            //dic.AddItem<string>(() => 查詢資料QueryString.strHospCode);
            //dic.Add("Price", SetMemberSignUpVM.Price.ToString());
            dic.Add("JSON", JsonConvert.SerializeObject(LoginQueryString));
            #endregion

            var mr = await this.GetItemsFromNetAsync(dic, HttpMethod.Post);

            //mr.Success = false;
            //mr.Message = "測試用的錯誤訊息";
            return mr;
        }
    }
}
