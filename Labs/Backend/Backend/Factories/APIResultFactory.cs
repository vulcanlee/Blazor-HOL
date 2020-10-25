using Backend.DTOs;
using Backend.Enums;
using Microsoft.AspNetCore.Http;

namespace Backend.Factories
{
    public static class APIResultFactory
    {
        public static APIResult Build(bool aPIResultStatus,
            int statusCodes = StatusCodes.Status200OK, ErrorMessageEnum errorMessageEnum = ErrorMessageEnum.None,
            object payload = null, string exceptionMessage = "", bool replaceExceptionMessage = true)
        {
            APIResult apiResult = new APIResult()
            {
                Status = aPIResultStatus,
                ErrorCode = (int)errorMessageEnum,
                Message = (errorMessageEnum == ErrorMessageEnum.None) ? "" : $"錯誤代碼 {(int)errorMessageEnum}, {ErrorMessageMapping.Instance.GetErrorMessage(errorMessageEnum)}",
                HTTPStatus = statusCodes,
                Payload = payload,
            };
            if (apiResult.ErrorCode == (int)ErrorMessageEnum.Exception)
            {
                apiResult.Message = $"{apiResult.Message}{exceptionMessage}";
            }
            else if (string.IsNullOrEmpty(exceptionMessage) == false)
            {
                if (replaceExceptionMessage == true)
                {
                    apiResult.Message = $"{exceptionMessage}";
                }
                else
                {
                    apiResult.Message += $"{exceptionMessage}";
                }
            }
            return apiResult;
        }
    }
}
