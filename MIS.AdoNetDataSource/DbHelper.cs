/*************************************************************************************
* CLR版本：        4.0.30319.42000
* 类 名 称：       DbHelper
* 命名空间：       MIS.AdoNetDataSource
* 文 件 名：       DbHelper
* 创建时间：       2019/10/26 21:25:50
* 作    者：       zhangyang
* 说   明：
* 修改时间：
* 修 改 人：
*************************************************************************************/

using System;
using System.Collections.Generic;
using System.Data;
using System.Data.Common;
using System.Linq;
using System.Text;

namespace MIS.AdoNetDataSource
{
   public  class DbHelper
    {
        private DbProviderFactory _providerFactory;
        private string _connectionString = null; //保存连接字符串

        /// <summary>
        /// 生成DbProviderFactory对象
        /// </summary>
        /// <param name="connectionString">连接字符串</param>
        /// <param name="providerType">需要生成的DbProviderFactory对象</param>
        public DbHelper(string connectionString, DbProviderType providerType)
        {
            if (string.IsNullOrEmpty(connectionString)) //连接字符串不能为空
            {
                throw new ArgumentException("connectionString is not null");
            }
            _providerFactory = ProviderFactory.GetDbProviderFactory(providerType);  //获取到生成的DbProviderFactory对象
            _connectionString = connectionString;
            if (_providerFactory == null)
            {
                throw new ArgumentException("can't build DbProviderFactory, please check DbProviderType ");
            }
        }

        /// <summary>
        /// 判断数据库是否可以打开
        /// </summary>
        /// <returns></returns>
        public bool CanOpen()
        {
            var dbConnection = _providerFactory.CreateConnection();
            dbConnection.ConnectionString = _connectionString;
            try
            {
                dbConnection.Open(); //打开连接
                return true;

            }
            catch (Exception ex)
            {
                return false;
            }
            finally
            {
                dbConnection.Close();  //关闭连接
            }
        }

        /// <summary>
        /// 
        /// </summary>
        /// <returns></returns>
        public DbConnection GetDbConnection()
        {
            var connection = _providerFactory.CreateConnection();
            connection.ConnectionString = _connectionString;
            return connection;
        }

        /// <summary>
        /// 执行增删改的方法
        /// </summary>
        /// <param name="sqlString">sql语句</param>
        /// <param name="dbParameters">参数</param>
        /// <param name="commandType">执行方式，是Sql语句还是存储过程</param>
        /// <returns></returns>
        public int ExecuteNonQuery(string sqlString, DbParameter[] dbParameters, CommandType commandType)
        {
            int result;
            using (DbConnection connection = GetDbConnection())
            {
                using (DbCommand command = CreateDbQueryCommand(connection, sqlString, dbParameters, commandType))
                {
                    connection.Open();
                    result = command.ExecuteNonQuery();
                    connection.Close();
                }
            }

            return result;
        }


        public DataTable ExecuteQuery(string sqlString, DbParameter[] dbParameters, CommandType commandType)
        {
            //DataSet dataSet = new DataSet();
            DataTable dataTable = new DataTable();

            using (DbConnection connection = GetDbConnection())
            {
                using (DbDataAdapter adapter = _providerFactory.CreateDataAdapter())
                {
                    adapter.SelectCommand = CreateDbQueryCommand(connection, sqlString, dbParameters, commandType);
                    connection.Open();
                    adapter.Fill(dataTable);
                    connection.Close();
                }
            }
            return dataTable;
        }

        private DbCommand CreateDbQueryCommand(DbConnection connection, string sqlString, IDbDataParameter[] dbParameters, CommandType commandType)
        {
            return CreateDbCommand(connection, sqlString, dbParameters, commandType, null);
        }

        public DbCommand CreateDbCommand(DbConnection connection, string sqlString, IDbDataParameter[] dbParameters, CommandType commandType, DbTransaction dbTransaction)
        {
            DbCommand command = _providerFactory.CreateCommand();
            if (dbTransaction != null)
            {
                command.Transaction = dbTransaction;
            }
            //connection.ConnectionString = _connectionString;
            command.CommandText = sqlString;
            command.CommandType = commandType;
            command.Connection = connection;
            if (dbParameters != null)
            {
                command.Parameters.AddRange(dbParameters);
            }
            return command;
        }


        /// <summary>
        /// 
        /// </summary>
        /// <param name="sqlString">查询语句</param>
        /// <param name="dbParameters">参数</param>
        /// <param name="commandType">Sql语句还是存储过程</param>
        /// <returns></returns>
        public object ExecuteScalar(string sqlString, DbParameter[] dbParameters, CommandType commandType)
        {
            object result;
            using (DbConnection connection = GetDbConnection())
            {
                using (DbCommand command = CreateDbQueryCommand(connection, sqlString, dbParameters, commandType))
                {
                    connection.Open();
                    result = command.ExecuteScalar();
                    connection.Close();
                }
            }
            return result;
        }
    }
}
