using MIS.EFDataSource;
using MIS.IDAL;
using MIS.Model.Page;
using MIS.Model.Result;
using MIS.Model.Sys.SysCode;
using MIS.Model.Tree;
using MIS.Utility;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace MIS.DAL
{
  public  class SysCodeDAL: ISysCodeDAL
    {

        /// <summary>
        /// 初始化参数树
        /// </summary>
        /// <returns></returns>
        public List<TreeNode> InitTree()
        {
            return GetSysCodeTreeNodes("*");
        }


        /// <summary>
        /// 获取参数数的信息
        /// </summary>
        /// <param name="parentUnqiueId"></param>
        /// <returns></returns>
        public List<TreeNode> GetSysCodeTreeNodes(string parentUnqiueId)
        {
            MISEntities db = new MISEntities();
            var allorganizationList = db.Sys_Code.ToList();
            var result = GetSysCodeChildTreeNodes(parentUnqiueId, allorganizationList);
            return result;

        }


        /// <summary>
        /// 递归查询参数树的信息
        /// </summary>
        /// <param name="parentUniqueId">父节点</param>
        /// <param name="allSysCodeList"></param>
        /// <returns></returns>
        public static List<TreeNode> GetSysCodeChildTreeNodes(string parentUniqueId, List<Sys_Code> allSysCodeList)
        {

            var treeNodeList = new List<TreeNode>();

            var childSysCodeList = allSysCodeList.Where(x => x.ParentUniqueId == parentUniqueId).OrderBy(x => x.Sort);
            foreach (var item in childSysCodeList)
            {
                treeNodeList.Add(new TreeNode()
                {
                    Id = item.UniqueId,
                    Text = item.CodeText,
                    Name = item.CodeText,
                    Icon = "layui-icon layui-icon-file-b",
                    Children = GetSysCodeChildTreeNodes(item.UniqueId, allSysCodeList),
                });
            }
            return treeNodeList;

        }



        /// <summary>
        /// 修改
        /// </summary>
        /// <param name="inputForm"></param>
        /// <returns></returns>
        public RequestResult Edit(SysCodeInputForm inputForm)
        {
            RequestResult result = new RequestResult();

            try
            {
                MISEntities db = new MISEntities();
                if (db.Sys_Code.Any(x => x.UniqueId != inputForm.CodeValue && x.CodeValue == inputForm.CodeValue&&x.ParentUniqueId==inputForm.ParentUniqueId))
                {
                    result.ReturnFailedMessage("同一项目下,编号重复");
                }
                else
                {

                    var item = db.Sys_Code.Where(x => x.UniqueId == inputForm.UniqueId).FirstOrDefault();
                    item.CodeText = inputForm.CodeText;
                    item.CodeValue = inputForm.CodeValue;
                    item.ParentUniqueId = inputForm.ParentUniqueId;
                    item.Sort = inputForm.Sort;
                    item.ModifyTime = DateTime.Now;
                    item.ModifyUser = SessionUtils.GetAccountUnqiueId();
                    db.SaveChanges();
                    result.Success();
                }
            }
            catch (Exception ex)
            {
                result.ReturnFailedMessage(ex.Message);
            }
            return result;
        }


        /// <summary>
        /// 新增
        /// </summary>
        /// <param name="inputForm"></param>
        /// <returns></returns>
        public RequestResult Add(SysCodeInputForm inputForm)
        {
            RequestResult result = new RequestResult();

            try
            {
                MISEntities db = new MISEntities();
                if (db.Sys_Code.Any(x => x.CodeValue == inputForm.CodeValue &&x.ParentUniqueId==inputForm.ParentUniqueId))
                {
                    result.ReturnFailedMessage("同一项目下,编号重复");
                }
                else
                {

                    if (string.IsNullOrEmpty(inputForm.ParentUniqueId))
                    {
                        inputForm.ParentUniqueId = "*";
                    }
                    Sys_Code model = new Sys_Code();
                    model.UniqueId = Guid.NewGuid().ToString();

                    model.CodeText = inputForm.CodeText;
                    model.CodeValue = inputForm.CodeValue;
                    model.ParentUniqueId = inputForm.ParentUniqueId;
                    model.Sort = inputForm.Sort;
                    model.CreateTime = DateTime.Now;
                    model.CreateUser = SessionUtils.GetAccountUnqiueId();
                    db.Sys_Code.Add(model);
                    db.SaveChanges();
                    result.Success();
                }

            }
            catch (Exception ex)
            {
                result.ReturnFailedMessage(ex.Message);
            }
            return result;
        }

        /// <summary>
        /// 根据唯一编码获取数据
        /// </summary>
        /// <param name="uniqueId"></param>
        /// <returns></returns>
        public SysCodeInputForm GetItemByUniqueId(string uniqueId)
        {
            MISEntities db = new MISEntities();
            return db.Sys_Code.Where(x => x.UniqueId == uniqueId).Select(x => new SysCodeInputForm()
            {
                UniqueId = x.UniqueId,
                CodeText = x.CodeText,
                CodeValue=x.CodeValue,
                Sort=x.Sort,
                ParentUniqueId = x.ParentUniqueId,
              
            }).FirstOrDefault();
        }

        /// <summary>
        /// 删除
        /// </summary>
        /// <param name="uniqueId"></param>
        /// <returns></returns>
        public RequestResult Delete(string uniqueId)
        {
            RequestResult result = new RequestResult();

            try
            {
                MISEntities db = new MISEntities();

                List<Sys_Code> list = new List<Sys_Code>();

                var allsysCodeList = db.Sys_Code.ToList();
                var deleteSysCodeList = GetSysCodeListByParendUniqueId(uniqueId, allsysCodeList);

                deleteSysCodeList.Add(allsysCodeList.Where(x => x.UniqueId == uniqueId).FirstOrDefault());

                db.Sys_Code.RemoveRange(deleteSysCodeList);
                db.SaveChanges();
                result.Success();
            }
            catch (Exception ex)
            {
                result.ReturnFailedMessage(ex.Message);
            }
            return result;
        }

        /// <summary>
        /// 根据父节点获取所有的参数信息
        /// </summary>
        /// <param name="parentId"></param>
        /// <param name="allOrganizationList"></param>
        /// <returns></returns>
        private static List<Sys_Code> GetSysCodeListByParendUniqueId(string parentUniqueId, List<Sys_Code> allSysCodeList)
        {
            var sysCodeList = new List<Sys_Code>();

            var childSysCodeList = allSysCodeList.Where(x => x.ParentUniqueId == parentUniqueId).OrderBy(x => x.Sort);
            foreach (var item in childSysCodeList)
            {
                sysCodeList.Add(item);
            }
            return sysCodeList;
        }

        /// <summary>
        /// 查询
        /// </summary>
        /// <param name="parameter"></param>
        /// <returns></returns>
        public PageData Query(SysCodeParameter parameter)
        {
            using (MISEntities db = new MISEntities())
            {
                var query = db.Sys_Code.AsQueryable();


                query = query.Where(x => x.ParentUniqueId == parameter.UniqueId).AsQueryable();

                var count = query.Count();
                var list = query.OrderBy(x => x.Sort).Skip((parameter.Page - 1) * parameter.Limit).Take(parameter.Limit).Select(x=>new SysCodeGrid(){
                     CodeText=x.CodeText,
                     CodeValue=x.CodeValue,
                     Sort=x.Sort,
                     UniqueId=x.UniqueId
                }).ToList();
               
                PageData pageData = new PageData(count, list);
                return pageData;
            }
        }
    }
}
