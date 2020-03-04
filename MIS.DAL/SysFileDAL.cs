using MIS.EFDataSource;
using MIS.IDAL;
using MIS.Model.Page;
using MIS.Model.Result;
using MIS.Model.Sys.SysFile;
using MIS.Model.Tree;
using MIS.Utility;
using MIS.Utility.DateUtility;
using MIS.Utility.GuidUtility;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace MIS.DAL
{
   public class SysFileDAL: ISysFileDAL
    {
        /// <summary>
        /// 初始化文件树
        /// </summary>
        /// <returns></returns>
        public List<TreeNode> InitTree()
        {
            Guid root = new Guid("00000000-0000-0000-0000-000000000000");
            return GetSysFileTreeNodes(root);
        }


        /// <summary>
        /// 获取文件数的信息
        /// </summary>
        /// <param name="parentUnqiueId"></param>
        /// <returns></returns>
        public List<TreeNode> GetSysFileTreeNodes(Guid parentUnqiueId)
        {
            MISEntities db = new MISEntities();
            var sysFileList = db.Sys_File.ToList();
            var result = GetSysFileChildTreeNodes(parentUnqiueId, sysFileList);
            return result;

        }


        /// <summary>
        /// 递归查询文件树的信息
        /// </summary>
        /// <param name="parentUniqueId"></param>
        /// <param name="sysFileList"></param>
        /// <returns></returns>
        public static List<TreeNode> GetSysFileChildTreeNodes(Guid parentUniqueId, List<Sys_File> sysFileList)
        {

            var treeNodeList = new List<TreeNode>();

            var childSyFileList = sysFileList.Where(x => x.ParentUniqueId == parentUniqueId).OrderBy(x => x.Sort);
            foreach (var item in childSyFileList)
            {
                treeNodeList.Add(new TreeNode()
                {
                    Id = item.UniqueId.ToString(),
                    Text = item.Name,
                    Name = item.Name,
                    Icon = "layui-icon layui-icon-file-b",
                    Children = GetSysFileChildTreeNodes(item.UniqueId, sysFileList),
                });
            }
            return treeNodeList;

        }



        /// <summary>
        /// 修改
        /// </summary>
        /// <param name="inputForm"></param>
        /// <returns></returns>
        public RequestResult Edit(SysFileInputForm inputForm)
        {
            RequestResult result = new RequestResult();

            try
            {
                MISEntities db = new MISEntities();
                if (db.Sys_File.Any(x => x.UniqueId != inputForm.UniqueId && x.Name == inputForm.Name && x.ParentUniqueId == inputForm.ParentUniqueId))
                {
                    result.ReturnFailedMessage("同一项目下,名称重复");
                }
                else
                {

                    var item = db.Sys_File.Where(x => x.UniqueId == inputForm.UniqueId).FirstOrDefault();
                    item.Name = inputForm.Name;
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
        public RequestResult Add(SysFileInputForm inputForm)
        {
            RequestResult result = new RequestResult();

            try
            {
                MISEntities db = new MISEntities();
                if (db.Sys_File.Any(x => x.Name == inputForm.Name && x.ParentUniqueId == inputForm.ParentUniqueId))
                {
                    result.ReturnFailedMessage("同一项目下,名称重复");
                }
                else
                {

                    if (inputForm.ParentUniqueId == null)
                    {
                        inputForm.ParentUniqueId = new Guid("00000000-0000-0000-0000-000000000000"); ;
                    }
                    Sys_File model = new Sys_File();
                    model.UniqueId = GuidUtils.NewGuid();
                    model.Name = inputForm.Name;
                    model.ParentUniqueId = inputForm.ParentUniqueId;
                    model.Sort = inputForm.Sort;
                    model.CreateTime = DateTime.Now;
                    model.CreateUser = SessionUtils.GetAccountUnqiueId();
                    db.Sys_File.Add(model);
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
        public SysFileInputForm GetItemByUniqueId(Guid uniqueId)
        {
            MISEntities db = new MISEntities();
            return db.Sys_File.Where(x => x.UniqueId == uniqueId).Select(x => new SysFileInputForm()
            {
                UniqueId = x.UniqueId,
                 Name = x.Name,
                Sort = x.Sort,
                ParentUniqueId = x.ParentUniqueId,

            }).FirstOrDefault();
        }

        /// <summary>
        /// 删除
        /// </summary>
        /// <param name="uniqueId"></param>
        /// <returns></returns>
        public RequestResult Delete(Guid uniqueId)
        {
            RequestResult result = new RequestResult();

            try
            {
                MISEntities db = new MISEntities();

                List<Sys_File> list = new List<Sys_File>();

                var sysFileList = db.Sys_File.ToList();
                var deleteSysFileList = GetSysFileListByParendUniqueId(uniqueId, sysFileList);

                deleteSysFileList.Add(sysFileList.Where(x => x.UniqueId == uniqueId).FirstOrDefault());

                db.Sys_File.RemoveRange(deleteSysFileList);
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
        /// 根据父节点获取所有的文件树信息
        /// </summary>
        /// <param name="parentUniqueId"></param>
        /// <param name="allSysFileList"></param>
        /// <returns></returns>
        private static List<Sys_File> GetSysFileListByParendUniqueId(Guid parentUniqueId, List<Sys_File> allSysFileList)
        {
            var sysFileList = new List<Sys_File>();

            var childSysFileList = allSysFileList.Where(x => x.ParentUniqueId == parentUniqueId).OrderBy(x => x.Sort);
            foreach (var item in childSysFileList)
            {
                sysFileList.Add(item);
            }
            return sysFileList;
        }

        /// <summary>
        /// 查询
        /// </summary>
        /// <param name="parameter"></param>
        /// <returns></returns>
        public PageData Query(SysFileParameter parameter)
        {
            using (MISEntities db = new MISEntities())
            {
                var query = (from x in db.Sys_ObjectAttachment
                             join x1 in db.Sys_Attachment on x.AttachmentUniqueId equals x1.UniqueId
                             where x.ObjectUniqueId == parameter.UniqueId
                             select new  {
                                  x1.CreateTime,
                                  x1.CreateUser,
                                  x1.FileName,
                                  x1.UniqueId
                             }).AsQueryable();


                var count = query.Count();
                var list = query.OrderBy(x => x.CreateTime).Skip((parameter.Page - 1) * parameter.Limit).Take(parameter.Limit).ToList();

                var fileGridList = new List<SysFileGrid>();
                var userList = db.Sys_User.ToList();



                foreach (var item in list)
                {
                    SysFileGrid model = new SysFileGrid();
                    model.UniqueId = item.UniqueId;
                    model.CreateTime = item.CreateTime.Value.ToString(DateTimeFormatter.YYYYMMDDHHMMSS);
                    model.CreateUser = userList.Where(x => x.UniqueId == item.CreateUser).FirstOrDefault().Name;
                    model.FileName = item.FileName;
                    fileGridList.Add(model);
                }

                PageData pageData = new PageData(count, fileGridList);
                return pageData;
            }
        }
    }
}
