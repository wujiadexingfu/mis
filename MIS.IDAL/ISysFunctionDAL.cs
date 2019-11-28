using MIS.Model.Result;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace MIS.IDAL
{
   public interface ISysFunctionDAL
    {
        RequestResult GetFunctionTreeByAccount(string accountId);
    }
}
