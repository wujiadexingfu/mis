using System;
using System.Collections.Generic;
using System.Data.Common;
using System.Linq;
using System.Text;
using System.Threading.Tasks;


/********************************************************************************

** 类名称：  ProviderFactory

** 描述：********

** 作者： zhangyang

** Version: 1.0

** 创建时间：2019-11-24 19:49:03

** 最后修改人：（无）

** 最后修改时间：（无）

** CLR版本：4.0.30319.42000      

** 版权所有 (C) :zhangyang

*********************************************************************************/

namespace MIS.AdoNetDataSource
{
 public    class ProviderFactory
    {
        /// <summary>
        /// 保存每种数据访问方式对应的程序集名称
        /// </summary>
        private static Dictionary<DbProviderType, string> providerInvariantNames = new Dictionary<DbProviderType, string>();

        /// <summary>
        /// 保存已经生成的DbProviderFactory对象
        /// </summary>
        private readonly static Dictionary<DbProviderType, DbProviderFactory> providerFactoies = new Dictionary<DbProviderType, DbProviderFactory>(20);

        /// <summary>
        /// 加载已知的访问类型与名称
        /// </summary>
        static ProviderFactory()
        {
            providerInvariantNames.Add(DbProviderType.SqlServer, "System.Data.SqlClient");
            providerInvariantNames.Add(DbProviderType.OleDb, "System.Data.OleDb");
            providerInvariantNames.Add(DbProviderType.ODBC, "System.Data.ODBC");
            providerInvariantNames.Add(DbProviderType.OracleClient, "System.Data.OracleClient");//已经废弃
            providerInvariantNames.Add(DbProviderType.Oracle, "Oracle.ManagedDataAccess.Client"); //需要安装Oracle.ManagedDataAccess插件，否则无效
            providerInvariantNames.Add(DbProviderType.MySql, "MySql.Data.MySqlClient");
            providerInvariantNames.Add(DbProviderType.SQLite, "System.Data.SQLite"); //注意在Nuget加入SQLite程序集
            //出现错误的话，参考https://www.cnblogs.com/leleroyn/archive/2011/03/24/1993627.html
            //<remove invariant="System.Data.SQLite"/>
            //<add name="SQLite Data Provider" invariant="System.Data.SQLite" description=".Net Framework Data Provider for SQLite" type="System.Data.SQLite.SQLiteFactory, System.Data.SQLite" />
            providerInvariantNames.Add(DbProviderType.Firebird, "FirebirdSql.Data.Firebird");
            providerInvariantNames.Add(DbProviderType.PostgreSql, "Npgsql");
            providerInvariantNames.Add(DbProviderType.DB2, "IBM.Data.DB2.iSeries");
            providerInvariantNames.Add(DbProviderType.Informix, "IBM.Data.Informix");
            providerInvariantNames.Add(DbProviderType.SqlServerCe, "System.Data.SqlServerCe");
        }

        public static DbProviderFactory GetDbProviderFactory(DbProviderType providerType)
        {
            if (!providerFactoies.ContainsKey(providerType))
            {
                var factory = BuildDbProviderFactory(providerType); //生成DbProviderFactory对象
                providerFactoies.Add(providerType, factory); //加入到字典中
            }
            return providerFactoies[providerType];
        }

        /// <summary>
        /// 生成DbProviderFactory对象
        /// </summary>
        /// <param name="providerType"></param>
        /// <returns></returns>
        private static DbProviderFactory BuildDbProviderFactory(DbProviderType providerType)
        {
            string provideName = providerInvariantNames[providerType]; //程序集名称；
            DbProviderFactory factory = null;
            try
            {
                factory = DbProviderFactories.GetFactory(provideName);
            }
            catch (Exception ex)
            {
                factory = null;
            }
            return factory;
        }
    }
}
