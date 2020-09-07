using System;
using System.Collections.Generic;
using System.Data;
using System.Linq;
using System.Threading.Tasks;
using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;
using Microsoft.Extensions.Configuration;
using MySql.Data.MySqlClient;
using NetCoreDBContex.Extend;

namespace NetCore_Blog_Api.Controllers
{
    public class APIControllerBase : ControllerBase
    {
        //获取配置文件
        //private IConfiguration _configuration;
        private readonly IDBHelper _dBHelper;


        private static string mConnStr = string.Empty;
        public APIControllerBase(IDBHelper dBHelper/*, IConfiguration configuration*/)
        {

            _dBHelper = dBHelper;
        }

        public DataSet ExecuteDataSet(string sql)
        {
            try
            {
                //创建一个MySqlConnection对象
                using (MySqlConnection connection = new MySqlConnection(mConnStr))
                {
                    connection.Open();
                    MySqlTransaction transaction = connection.BeginTransaction();

                    //创建一个MySqlCommand对象
                    using (MySqlCommand cmd = new MySqlCommand())
                    {
                        try
                        {
                            PrepareCommand(cmd, connection, transaction, CommandType.Text, sql, null);

                            MySqlDataAdapter adapter = new MySqlDataAdapter();
                            adapter.SelectCommand = cmd;
                            DataSet ds = new DataSet();

                            adapter.Fill(ds);

                            transaction.Commit();

                            //清除参数
                            cmd.Parameters.Clear();
                            return ds;

                        }
                        catch (MySqlException e1)
                        {
                            try
                            {
                                transaction.Rollback();
                            }
                            catch (Exception e2)
                            {
                                throw e2;
                            }

                            throw e1;
                        }
                    }
                }
            }
            catch (Exception e)
            {
                throw e;
            }
        }

        public DataSet ExecuteDataSet(string sql, MySqlParameter[] cmdParams)
        {
            try
            {
                //创建一个MySqlConnection对象
                using (MySqlConnection connection = new MySqlConnection(mConnStr))
                {
                    connection.Open();
                    MySqlTransaction transaction = connection.BeginTransaction();

                    //创建一个MySqlCommand对象
                    using (MySqlCommand cmd = new MySqlCommand())
                    {
                        try
                        {
                            PrepareCommand(cmd, connection, transaction, CommandType.Text, sql, cmdParams);

                            MySqlDataAdapter adapter = new MySqlDataAdapter();
                            adapter.SelectCommand = cmd;
                            DataSet ds = new DataSet();

                            adapter.Fill(ds);

                            transaction.Commit();

                            //清除参数
                            cmd.Parameters.Clear();
                            return ds;

                        }
                        catch (MySqlException e1)
                        {
                            try
                            {
                                transaction.Rollback();
                            }
                            catch (Exception e2)
                            {
                                throw e2;
                            }

                            throw e1;
                        }
                    }
                }
            }
            catch (Exception e)
            {
                throw e;
            }
        }

        public int ExecuteNonQuery(string sql)
        {
            try
            {
                using (MySqlConnection connection = new MySqlConnection(mConnStr))
                {
                    connection.Open();
                    MySqlTransaction transaction = connection.BeginTransaction();

                    using (MySqlCommand cmd = new MySqlCommand())
                    {
                        try
                        {
                            PrepareCommand(cmd, connection, transaction, CommandType.Text, sql, null);

                            int rows = cmd.ExecuteNonQuery();
                            transaction.Commit();

                            cmd.Parameters.Clear();
                            return rows;
                        }
                        catch (MySqlException e1)
                        {
                            try
                            {
                                transaction.Rollback();
                            }
                            catch (Exception e2)
                            {
                                throw e2;
                            }

                            throw e1;
                        }
                    }
                }
            }
            catch (Exception e)
            {
                throw e;
            }
        }

        public int ExecuteNonQuery(string sql, MySqlParameter[] cmdParams)
        {
            try
            {
                using (MySqlConnection connection = new MySqlConnection(mConnStr))
                {
                    connection.Open();
                    MySqlTransaction transaction = connection.BeginTransaction();

                    using (MySqlCommand cmd = new MySqlCommand())
                    {
                        try
                        {
                            PrepareCommand(cmd, connection, transaction, CommandType.Text, sql, cmdParams);

                            int rows = cmd.ExecuteNonQuery();
                            transaction.Commit();

                            cmd.Parameters.Clear();
                            return rows;
                        }
                        catch (MySqlException e1)
                        {
                            try
                            {
                                transaction.Rollback();
                            }
                            catch (Exception e2)
                            {
                                throw e2;
                            }

                            throw e1;
                        }
                    }
                }
            }
            catch (Exception e)
            {
                throw e;
            }
        }

        public MySqlDataReader ExecuteReader(string sql)
        {
            try
            {
                //创建一个MySqlConnection对象
                using (MySqlConnection connection = new MySqlConnection(mConnStr))
                {
                    connection.Open();
                    MySqlTransaction transaction = connection.BeginTransaction();

                    //创建一个MySqlCommand对象
                    using (MySqlCommand cmd = new MySqlCommand())
                    {
                        try
                        {
                            PrepareCommand(cmd, connection, transaction, CommandType.Text, sql, null);

                            MySqlDataReader reader = cmd.ExecuteReader(CommandBehavior.CloseConnection);
                            transaction.Commit();

                            cmd.Parameters.Clear();
                            return reader;
                        }
                        catch (MySqlException e1)
                        {
                            try
                            {
                                transaction.Rollback();
                            }
                            catch (Exception e2)
                            {
                                throw e2;
                            }

                            throw e1;
                        }
                    }
                }
            }
            catch (Exception e)
            {
                throw e;
            }
        }

        public int ExecuteScalar(string sql)
        {
            try
            {
                using (MySqlConnection connection = new MySqlConnection(mConnStr))
                {
                    connection.Open();
                    MySqlTransaction transaction = connection.BeginTransaction();

                    using (MySqlCommand cmd = new MySqlCommand())
                    {
                        try
                        {
                            int line = 0;

                            PrepareCommand(cmd, connection, transaction, CommandType.Text, sql, null);

                            String str = cmd.ExecuteScalar().ToString();
                            transaction.Commit();

                            line = Convert.ToInt32(str);
                            cmd.Parameters.Clear();

                            return line;
                        }
                        catch (MySqlException e1)
                        {
                            try
                            {
                                transaction.Rollback();
                            }
                            catch (Exception e2)
                            {
                                throw e2;
                            }

                            throw e1;
                        }
                    }
                }
            }
            catch (Exception e)
            {
                throw e;
            }
        }

        public int ExecuteScalar(string sql, MySqlParameter[] cmdParams)
        {
            try
            {
                using (MySqlConnection connection = new MySqlConnection(mConnStr))
                {
                    connection.Open();
                    MySqlTransaction transaction = connection.BeginTransaction();

                    using (MySqlCommand cmd = new MySqlCommand())
                    {
                        try
                        {
                            int line = 0;

                            PrepareCommand(cmd, connection, transaction, CommandType.Text, sql, cmdParams);

                            String str = cmd.ExecuteScalar().ToString();
                            transaction.Commit();

                            line = Convert.ToInt32(str);
                            cmd.Parameters.Clear();

                            return line;
                        }
                        catch (MySqlException e1)
                        {
                            try
                            {
                                transaction.Rollback();
                            }
                            catch (Exception e2)
                            {
                                throw e2;
                            }

                            throw e1;
                        }
                    }
                }
            }
            catch (Exception e)
            {
                throw e;
            }
        }
        /// <summary>
        /// 准备执行一个命令
        /// </summary>
        /// <param name="cmd">sql命令</param>
        /// <param name="conn">OleDb连接</param>
        /// <param name="trans">OleDb事务</param>
        /// <param name="cmdType">命令类型例如 存储过程或者文本</param>
        /// <param name="cmdText">命令文本,例如:Select * from Products</param>
        /// <param name="cmdParms">执行命令的参数</param>
        private void PrepareCommand(MySqlCommand cmd, MySqlConnection conn, MySqlTransaction trans, CommandType cmdType, string cmdText, MySqlParameter[] cmdParms)
        {
            if (conn.State != ConnectionState.Open)
                conn.Open();

            cmd.Connection = conn;
            cmd.CommandText = cmdText;

            if (trans != null)
                cmd.Transaction = trans;

            cmd.CommandType = cmdType;

            if (cmdParms != null)
            {
                foreach (MySqlParameter parm in cmdParms)
                    cmd.Parameters.Add(parm);
            }

        }
    }
}
