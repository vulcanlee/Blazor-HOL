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
    public class PersonService : BaseWebAPI<PersonData>
    {
        public PersonService()
            : base()
        {
            this.url = "Person";
            this.host = ConstantHelper.APIHostBase;
        }

        public async Task<ManagerResult> GetAsync()
        {
            IsCollection = true;
            NeedSaveToStorage = true;
            EncodingType = EncodingMethod.JSON;

            #region 要傳遞的參數
            WebQueryDictionary dic = new WebQueryDictionary();
            #endregion

            var mr = await this.GetItemsFromNetAsync(dic, HttpMethod.Get);

            return mr;
        }
    }
}
