﻿using MIS.Model.Result;
using MIS.Model.Sys;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace MIS.IDAL
{
   public interface ISysAttachmentDAL
    {

        /// <summary>
        /// 新增
        /// </summary>
        /// <param name="inputForm"></param>
        /// <returns></returns>
        RequestResult Add(SysAttachmentInputForm inputForm);


        /// <summary>
        /// 修改
        /// </summary>
        /// <param name="inputForm"></param>
        /// <returns></returns>
        RequestResult Edit(SysAttachmentInputForm inputForm);

        /// <summary>
        /// 删除文件记录
        /// </summary>
        /// <param name="uniqueId"></param>
        /// <returns></returns>
        RequestResult Delete(Guid uniqueId);

        /// <summary>
        /// 获取数据
        /// </summary>
        /// <param name="uniqueId"></param>
        /// <returns></returns>
        SysAttachmentInputForm GetItemByUniqueId(Guid uniqueId);
    }
}
