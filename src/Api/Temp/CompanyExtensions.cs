using Api.Temp.ApiModel;
using Dbosoft.YaNco;
using LanguageExt;
using System.Collections.Generic;

namespace Api.Temp
{
    public static class CompanyExtensions
    {
        public static EitherAsync<RfcErrorInfo, IEnumerable<CompanyModel>> GetCompanies(this IRfcContext rfcContext)
        {
            var result = rfcContext.CallFunction("BAPI_COMPANYCODE_GETLIST",
                Output: f => f
                    .MapTable("COMPANYCODE_LIST", s =>
                        from code in s.GetField<string>("COMP_CODE")
                        from name in s.GetField<string>("COMP_NAME")
                        select new CompanyModel
                        {
                            Code = code,
                            Name = name
                        }));

            return result; 
        }
    }
}
