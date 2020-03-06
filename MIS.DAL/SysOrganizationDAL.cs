using MIS.EFDataSource;
using MIS.IDAL;
using MIS.Model.Page;
using MIS.Model.Result;
using MIS.Model.Sys.SysOrganization;
using MIS.Model.Tree;
using MIS.Utility;
using MIS.Utility.GuidUtility;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using static MIS.Utility.EnumUtility.SystemEnums;

namespace MIS.DAL
{
    public  class SysOrganizationDAL: ISysOrganizationDAL
    {

        private ISysLogDAL _sysLogDAL;
        public SysOrganizationDAL(ISysLogDAL sysLogDAL)
        {
            _sysLogDAL = sysLogDAL;
        }
        public List<TreeNode> InitTree()
        {
            var root = new Guid("00000000-0000-0000-0000-000000000000");
            return GetOrganizationTreeNodes(root);
        }


        /// <summary>
        /// 获取组织树信息
        /// </summary>
        /// <param name="parentId"></param>
        /// <returns></returns>
        public List<TreeNode> GetOrganizationTreeNodes(Guid  parentId)
        {
            MISEntities db = new MISEntities();
            var allorganizationList = db.Sys_Organization.Where(x=>x.Status!=Status.Delete.ToString()).ToList();
            var result = GetOrganizationChildTreeNodes(parentId, allorganizationList);
            return result;

        }

        /// <summary>
        /// 递归查询组织树
        /// </summary>
        /// <param name="parentId">父节点</param>
        /// <param name="allOrganizationList">所有组织信息</param>
        /// <returns></returns>
        public static List<TreeNode> GetOrganizationChildTreeNodes(Guid parentId,List<Sys_Organization> allOrganizationList)
        {

            var treeNodeList=new  List<TreeNode>();

            var childOrganizationList = allOrganizationList.Where(x => x.ParentUniqueId == parentId).OrderBy(x=>x.Seq);
            foreach (var item in childOrganizationList)
            {
                treeNodeList.Add(new TreeNode()
                {
                    Id=item.UniqueId.ToString(),
                    Text =item.Name,
                    Name=item.Name,
                    Icon= "layui-icon layui-icon-file-b",
                    Children = GetOrganizationChildTreeNodes(item.UniqueId, allOrganizationList),
                });
            }
            return treeNodeList;

        }



        /// <summary>
        /// 修改
        /// </summary>
        /// <param name="inputForm"></param>
        /// <returns></returns>
        public RequestResult Edit(SysOrganizationInputForm inputForm)
        {
            RequestResult result = new RequestResult();

            try
            {
                MISEntities db = new MISEntities();
                if (db.Sys_Organization.Any(x => x.UniqueId != inputForm.UniqueId && x.Id == inputForm.Id))
                {
                    result.ReturnFailedMessage("编号重复");
                }
                else
                {
           
                    var item = db.Sys_Organization.Where(x => x.UniqueId == inputForm.UniqueId).FirstOrDefault();
                    item.Id = inputForm.Id;
                    item.Name = inputForm.Name;
                    item.ParentUniqueId = inputForm.ParentUniqueId;
                    item.ManagerUniqueId = inputForm.ManagerUniqueId;
                    item.Name = inputForm.Name;
                    item.Seq = inputForm.Seq;
                    item.ModifyTime = DateTime.Now;
                    item.ModifyUser = SessionUtils.GetAccountUnqiueId();
                    db.SaveChanges();
                    result.Success();
                }
            }
            catch (Exception ex)
            {
                _sysLogDAL.WriteLog(ex);
                result.ReturnFailedMessage(ex.Message);
            }
            return result;
        }


        /// <summary>
        /// 新增
        /// </summary>
        /// <param name="inputForm"></param>
        /// <returns></returns>
        public RequestResult Add(SysOrganizationInputForm inputForm)
        {
            RequestResult result = new RequestResult();

            try
            {
                MISEntities db = new MISEntities();
                if (db.Sys_Organization.Any(x => x.Id == inputForm.Id))
                {
                    result.ReturnFailedMessage("编号重复");
                }
                else
                {
                    if (inputForm.ParentUniqueId == null)
                    {
                        inputForm.ParentUniqueId=new Guid("00000000-0000-0000-0000-000000000000");
                    }
                    Sys_Organization model = new Sys_Organization();
                    model.UniqueId = GuidUtils.NewGuid();
                    model.Id = inputForm.Id;
                    model.Name = inputForm.Name;
                    model.ManagerUniqueId = inputForm.ManagerUniqueId;
                    model.ParentUniqueId = inputForm.ParentUniqueId;
                    model.Seq = inputForm.Seq;
                    model.CreateTime = DateTime.Now;
                    model.CreateUser = SessionUtils.GetAccountUnqiueId();
                    db.Sys_Organization.Add(model);
                    db.SaveChanges();
                    result.Success();
                }

            }
            catch (Exception ex)
            {
                _sysLogDAL.WriteLog(ex);
                result.ReturnFailedMessage(ex.Message);
            }
            return result;
        }

        /// <summary>
        /// 根据唯一编码获取数据
        /// </summary>
        /// <param name="uniqueId"></param>
        /// <returns></returns>
        public SysOrganizationInputForm GetItemByUniqueId(Guid uniqueId)
        {
            MISEntities db = new MISEntities();
            return db.Sys_Organization.Where(x => x.UniqueId == uniqueId).Select(x => new SysOrganizationInputForm()
            {
                UniqueId=x.UniqueId,
                Id=x.Id,
                ManagerUniqueId=x.ManagerUniqueId,
                Icon=x.Icon,
                Name=x.Name,
                ParentUniqueId=x.ParentUniqueId,
                Seq=x.Seq
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

                List<Sys_Organization> list = new List<Sys_Organization>();

                var allorganizationList = db.Sys_Organization.ToList();
                var deleteOrganizationList= GetOrganizationListByParendId(uniqueId, allorganizationList);

                deleteOrganizationList.Add(allorganizationList.Where(x => x.UniqueId == uniqueId).FirstOrDefault());

                foreach (var item in deleteOrganizationList)
                {
                    item.Status = Status.Delete.ToString();
                    item.ModifyUser= SessionUtils.GetAccountUnqiueId();
                    item.ModifyTime = DateTime.Now;
                }

                db.SaveChanges();
                result.Success();
            }
            catch (Exception ex)
            {
                _sysLogDAL.WriteLog(ex);
                result.ReturnFailedMessage(ex.Message);
            }
            return result;
        }

        /// <summary>
        /// 根据父节点获取所有的组织信息
        /// </summary>
        /// <param name="parentId"></param>
        /// <param name="allOrganizationList"></param>
        /// <returns></returns>
        private static List<Sys_Organization> GetOrganizationListByParendId(Guid parentId, List<Sys_Organization> allOrganizationList)
        {
            var organizationList = new List<Sys_Organization>();

            var childOrganizationList = allOrganizationList.Where(x => x.ParentUniqueId == parentId).OrderBy(x=>x.Seq);
            foreach (var item in childOrganizationList)
            {
                organizationList.Add(item);
            }
            return organizationList;
        }


        public PageData Query(SysOrganizationParameter parameter)
        {
            using (MISEntities db = new MISEntities())
            {
                var query = db.Sys_Organization.AsQueryable();
              

                query = query.Where(x => x.ParentUniqueId == parameter.UniqueId&&x.Status!=Status.Delete.ToString()).AsQueryable();

                var count = query.Count();
                var data = query.OrderBy(x => x.Seq).Skip((parameter.Page - 1) * parameter.Limit).Take(parameter.Limit).ToList();
                List<SysOrganizationGrid> list = new List<SysOrganizationGrid>();

                var organizationList = db.Sys_Organization.ToList();
                var userList = db.Sys_User.ToList();



                foreach (var item in data)
                {
                    SysOrganizationGrid model = new SysOrganizationGrid();

                    var organizationItem = organizationList.Where(x => x.UniqueId == item.ParentUniqueId).FirstOrDefault();
                    var userItem = userList.Where(x => x.UniqueId == item.ManagerUniqueId).FirstOrDefault();

                    model.UniqueId = item.UniqueId;
                    model.Id = item.Id;
                    model.Name = item.Name;
                    model.Icon = item.Icon;
                    model.Parent = organizationItem==null?"":organizationItem.Name;
                    model.Manager = userItem==null?"":userItem.Name;
                    model.Seq = item.Seq;
                    list.Add(model);
                }

              


                PageData pageData = new PageData(count, list);
                return pageData;
            }
        }



    }




}
