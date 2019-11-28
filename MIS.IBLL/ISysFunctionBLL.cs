using MIS.Model.Result;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace MIS.IBLL
{
   public interface ISysFunctionBLL
    {
        RequestResult GetFunctionTreeByAccount();
    }
}
