using MIS.EFDataSource;
using MIS.IDAL;
using MIS.Model.Account;
using MIS.Model.Page;
using MIS.Model.Result;
using MIS.Model.Sys.SysFunction;
using MIS.Model.Sys.SysRole;
using MIS.Model.Tree;
using MIS.Utility;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using static MIS.Utility.EnumUtility.SystemEnums;

namespace MIS.DAL
{
   public class SysFunctionDAL:ISysFunctionDAL
    {
        /// <summary>
        /// 根据当前登录用户获取到菜单目录
        /// </summary>
        /// <returns></returns>
        public RequestResult GetFunctionTreeByAccount(string accountId)
        {
            RequestResult result = new RequestResult();
            MISEntities db = new MISEntities();
            var allFunctionList = db.Sys_Function.ToList();

            var functionList = GetFunctionTree("*", allFunctionList);
            result.ReturnData(functionList);
            return result;

        }

        /// <summary>
        /// 获取菜单树结构（递归）
        /// </summary>
        /// <param name="parentId"></param>
        /// <param name="allFunctionList"></param>
        /// <returns></returns>
        private List<AccountFuntion> GetFunctionTree(string parentId, List<Sys_Function> allFunctionList)
        {
            List<Sys_Function> childFunctionList = allFunctionList.Where(x => x.ParentId == parentId).OrderBy(x=>x.Sort).ToList();
            List<AccountFuntion> result = new List<AccountFuntion>();


            if (childFunctionList.Count == 0)
            {
                return null;
            }
            else
            {
                foreach (var item in childFunctionList)
                {
                    var model = new AccountFuntion();
                    model.Id = item.Id;
                    model.Area = item.Area;
                    model.Controller = item.Controller;
                    model.Action = item.Action;
                    model.Icon = item.Icon;
                    model.Sort = item.Sort;
                    model.Description = item.Description;
                    var childAccountFuntion = GetFunctionTree(item.Id, allFunctionList);
                    model.ChildAccountFuntion = childAccountFuntion != null ? childAccountFuntion.OrderBy(x => x.Sort).ToList():null;
                    result.Add(model);
                }
                return result;
            }
        }


        /// <summary>
        /// 根据操作的唯一编码获取到菜单数据
        /// </summary>
        /// <param name="operationUnqiueId">操作的唯一编码</param>
        /// <returns></returns>
        public List<LayuiTreeNode> GetFunctionTreeByOperationUniqueId(string operationUnqiueId)
        {
            MISEntities db = new MISEntities();
            var functionList = db.Sys_Function.ToList();
            var selectFunctionList = db.Sys_OperationFunction.Where(x => x.OperationUniqueId == operationUnqiueId).Select(x=>x.FunctionId).ToList();

            var list= GetFunctionChildTreeNodes("*", functionList, selectFunctionList);

            return list;

        }

        public List<TreeNode> InitTree()
        {
           
            return GetFunctionTreeNodes("*");
        }


        private static List<LayuiTreeNode> GetFunctionChildTreeNodes(string parentId, List<Sys_Function> allFunctionList,List<string> selectedFunctionList)
        {

            var layuiTreeNodeList = new List<LayuiTreeNode>();

            var childFunctionList = allFunctionList.Where(x => x.ParentId == parentId).OrderBy(x => x.Sort);

            foreach (var item in childFunctionList)
            {
                layuiTreeNodeList.Add(new LayuiTreeNode()
                {
                    Id = item.Id,
                    Title=item.Description,
                    Children = GetFunctionChildTreeNodes(item.Id, allFunctionList, selectedFunctionList),
                    Checked =!string.IsNullOrEmpty(item.Controller) &&selectedFunctionList.Any(x => x == item.Id),

                });
            }
            return layuiTreeNodeList;

        }



        /// <summary>
        /// 获取菜单树信息
        /// </summary>
        /// <param name="parentId"></param>
        /// <returns></returns>
        public List<TreeNode> GetFunctionTreeNodes(string parentId)
        {
            MISEntities db = new MISEntities();
            var functionList = db.Sys_Function.ToList();
            var result = GetFunctionChildTreeNodes(parentId, functionList);
            return result;

        }

        /// <summary>
        /// 递归查询菜单树
        /// </summary>
        /// <param name="parentId">父节点</param>
        /// <param name="allOrganizationList">所有组织信息</param>
        /// <returns></returns>
        private static List<TreeNode> GetFunctionChildTreeNodes(string parentId, List<Sys_Function> functionList)
        {

            var treeNodeList = new List<TreeNode>();

            var childOrganizationList = functionList.Where(x => x.ParentId == parentId).OrderBy(x => x.Sort);
            foreach (var item in childOrganizationList)
            {
                treeNodeList.Add(new TreeNode()
                {
                    Id = item.Id,
                    Text = item.Description,
                    Name = item.Description,
                    Icon = "layui-icon layui-icon-file-b",
                    Children = GetFunctionChildTreeNodes(item.Id, functionList),
                });
            }
            return treeNodeList;

        }



        /// <summary>
        /// 修改
        /// </summary>
        /// <param name="inputForm"></param>
        /// <returns></returns>
        public RequestResult Edit(SysFunctionInputForm inputForm)
        {
            RequestResult result = new RequestResult();

            try
            {
                MISEntities db = new MISEntities();
                var item = db.Sys_Function.Where(x => x.Id == inputForm.Id).FirstOrDefault();
                item.Id = inputForm.Id;
                item.Description = inputForm.Description;
                item.ParentId = inputForm.ParentId;
                item.Area = inputForm.Area;
                item.Controller = inputForm.Controller;
                item.Action = inputForm.Action;
                item.IsDisplay = inputForm.IsDisplay=="on"?true:false;
                item.Sort = inputForm.Sort;
                item.ModifyTime = DateTime.Now;
                item.ModifyUser = SessionUtils.GetAccountUnqiueId();
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
        /// 新增
        /// </summary>
        /// <param name="inputForm"></param>
        /// <returns></returns>
        public RequestResult Add(SysFunctionInputForm inputForm)
        {
            RequestResult result = new RequestResult();

            if (string.IsNullOrEmpty(inputForm.ParentId))
            {
                inputForm.ParentId = "*";
            }

            try
            {
                MISEntities db = new MISEntities();
                if (db.Sys_Function.Any(x => x.Id == inputForm.Id))
                {
                    result.ReturnFailedMessage("编号重复");
                }
                else
                {
                    Sys_Function model = new Sys_Function();
                    model.Id = inputForm.Id;
                    model.Description = inputForm.Description;
                    model.ParentId = inputForm.ParentId;
                    model.Area = inputForm.Area;
                    model.Controller = inputForm.Controller;
                    model.Action = inputForm.Action;
                    model.IsDisplay = inputForm.IsDisplay=="on"?true:false;
                    model.Sort = inputForm.Sort;
                    model.CreateTime = DateTime.Now;
                    model.CreateUser = SessionUtils.GetAccountUnqiueId();
                    db.Sys_Function.Add(model);
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
        /// <param name="Id"></param>
        /// <returns></returns>
        public SysFunctionInputForm GetItemByUniqueId(string Id)
        {
            MISEntities db = new MISEntities();
            return db.Sys_Function.Where(x => x.Id == Id).Select(x => new SysFunctionInputForm()
            {
                 Id = x.Id,
                 Action=x.Action,
                 Area=x.Area,
                 Controller=x.Controller,
                 Description=x.Description,
                 IsDisplay=x.IsDisplay?"on":null,
                 ParentId=x.ParentId,
                 Icon=x.Icon,
                 Sort=x.Sort
            }).FirstOrDefault();
        }


        /// <summary>
        ///  删除
        /// </summary>
        /// <param name="Id"></param>
        /// <returns></returns>
        public RequestResult Delete(string Id)
        {
            RequestResult result = new RequestResult();

            try
            {
                MISEntities db = new MISEntities();

                List<Sys_Function> list = new List<Sys_Function>();

                var allFunctionList = db.Sys_Function.ToList();
                var deleteFunctionnList = GetFunctionListByParendId(Id, allFunctionList);

                deleteFunctionnList.Add(allFunctionList.Where(x => x.Id == Id).FirstOrDefault());


                db.Sys_Function.RemoveRange(deleteFunctionnList);

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
        /// 根据父节点获取所有的菜单信息
        /// </summary>
        /// <param name="parentId"></param>
        /// <param name="functionList"></param>
        /// <returns></returns>
        private static List<Sys_Function> GetFunctionListByParendId(string parentId, List<Sys_Function> functionList)
        {
            var result = new List<Sys_Function>();

            var childFunctionList = functionList.Where(x => x.ParentId == parentId).OrderBy(x => x.Sort);
            foreach (var item in childFunctionList)
            {
                result.Add(item);
            }
            return result;
        }

        /// <summary>
        /// 查询
        /// </summary>
        /// <param name="parameter"></param>
        /// <returns></returns>
        public PageData Query(SysFunctionParameter parameter)
        {
            using (MISEntities db = new MISEntities())
            {
                var query = db.Sys_Function.AsQueryable();


                query = query.Where(x => x.ParentId == parameter.Id ).AsQueryable();

                var count = query.Count();
                var list = query.OrderBy(x => x.Sort).Skip((parameter.Page - 1) * parameter.Limit).Take(parameter.Limit).Select(x=>new SysFunctionGrid() {
                    Id=x.Id,
                    Area=x.Area,
                    Action=x.Action,
                    Controller=x.Controller,
                    Description=x.Description,
                    IsDisplay=x.IsDisplay,
                    Sort=x.Sort
                }).ToList();
            
                PageData pageData = new PageData(count, list);
                return pageData;
            }
        }

        /// <summary>
        /// 根据角色唯一编码获取菜单的操作信息
        /// </summary>
        /// <param name="operationUnqiueId"></param>
        /// <returns></returns>
        public List<LayuiTreeNode> GetFunctionTreeByRoleUniqueId(string roleUnqiueId)
        {
            MISEntities db = new MISEntities();
            var functionList = db.Sys_Function.ToList();  //所有的菜单信息
            var selectedOperationFunctionList = db.Sys_RoleOperationFunction.Where(x => x.RoleUniqueId == roleUnqiueId).Select(x=>x.OperationFunctionUniqueId).ToList(); //选中菜单操作信息

            var operationFunctionList = db.view_OperationFunction.ToList(); //所有的菜单操作信息
            




            var list = GetFunctionChildTreeNodesWithType("*", functionList, selectedOperationFunctionList, operationFunctionList);

            return list;

        }


        private static List<LayuiTreeNode> GetFunctionChildTreeNodesWithType(string parentId, List<Sys_Function> allFunctionList, List<string> selectedOperationFunctionList,List<view_OperationFunction> operationFunctionList)
        {

            var layuiTreeNodeList = new List<LayuiTreeNode>();

            var childFunctionList = allFunctionList.Where(x => x.ParentId == parentId).OrderBy(x => x.Sort);

            foreach (var item in childFunctionList)
            {
                var layuiTreeNode = new LayuiTreeNode();

                var operationFunctionNodeList = GetFunctionOperation(item.Id, selectedOperationFunctionList, operationFunctionList);

                layuiTreeNode.Children.AddRange(operationFunctionNodeList);
                layuiTreeNode.Id = item.Id;
                layuiTreeNode.Title = item.Description;
                layuiTreeNode.Children.AddRange(GetFunctionChildTreeNodesWithType(item.Id, allFunctionList, selectedOperationFunctionList, operationFunctionList));

                layuiTreeNodeList.Add(layuiTreeNode);

            }
            return layuiTreeNodeList;

        }

        private static List<LayuiTreeNode> GetFunctionOperation(string functionId, List<string> selectedOperationFunctionList, List<view_OperationFunction> operationFunctionList)
        {
            List<LayuiTreeNode> list = new List<LayuiTreeNode>();


            var operationList = operationFunctionList.Where(x => x.FunctionId == functionId).Distinct().Select(x => new
            {

                x.OperationFunctionUniqueId,
                x.OperationId,
                x.OperationName,
                x.Controller

            }).ToList();

            foreach (var item in operationList)
            {
                if (!string.IsNullOrEmpty(item.Controller))
                {
                    LayuiTreeNode layuiTreeNode = new LayuiTreeNode();
                    layuiTreeNode.Id = item.OperationFunctionUniqueId;
                    layuiTreeNode.Title = item.OperationName;
                    layuiTreeNode.NodeType = TreeNodeType.Operation.ToString();
                    layuiTreeNode.Checked = selectedOperationFunctionList.Any(x => x == item.OperationFunctionUniqueId);

                    list.Add(layuiTreeNode);
                }
            }
            return list;


        }








    }
}
