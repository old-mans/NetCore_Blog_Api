using System;
using System.Collections.Generic;
using System.Text;
using System.Collections;
using MySql.Data.MySqlClient;
using System.Data;

namespace NetCoreDBContex.Extend
{
    public interface IDBHelper
    {
        /// <summary>
        /// 对SQL数据库执行增删改操作，返回受影响的行数。  
        /// </summary>
        /// <param name="sql">sql语句</param>
        /// <returns></returns>
        public int ExecuteNonQuery(String sql);
        /// <summary>
        ///  对SQL数据库执行增删改操作，返回受影响的行数。
        /// </summary>
        /// <param name="sql"></param>
        /// <param name="cmdParams"></param>
        /// <returns></returns>
        public int ExecuteNonQuery(String sql, MySqlParameter[] cmdParams);
        /// <summary>
        /// 对SQL数据库执行操作，返回 返回第一行第一列数据
        /// </summary>
        /// <param name="sql"></param>
        /// <returns></returns>
        public int ExecuteScalar(String sql);
        /// <summary>
        /// 对SQL数据库执行操作，返回 返回第一行第一列数据
        /// </summary>
        /// <param name="sql"></param>
        /// <param name="cmdParams"></param>
        /// <returns></returns>
        public int ExecuteScalar(String sql, MySqlParameter[] cmdParams);
        /// <summary>
        /// 用执行的数据库连接执行一个返回数据集的sql命令
        /// </summary>
        /// <param name="sql"></param>
        /// <returns></returns>
        public MySqlDataReader ExecuteReader(String sql);
        /// <summary>
        /// 查询返回Dtaset
        /// </summary>
        /// <param name="sql"></param>
        /// <returns></returns>
        public DataSet ExecuteDataSet(String sql);
        /// <summary>
        /// 查询返回Dtaset
        /// </summary>
        /// <param name="sql"></param>
        /// <param name="cmdParams"></param>
        /// <returns></returns>
        public DataSet ExecuteDataSet(String sql, MySqlParameter[] cmdParams);

        /// <summary>
        /// 准备执行一个命令
        /// </summary>
        /// <param name="cmd">sql命令</param>
        /// <param name="conn">OleDb连接</param>
        /// <param name="trans">OleDb事务</param>
        /// <param name="cmdType">命令类型例如 存储过程或者文本</param>
        /// <param name="cmdText">命令文本,例如:Select * from Products</param>
        /// <param name="cmdParms">执行命令的参数</param>
        //private void PrepareCommand(MySqlCommand cmd, MySqlConnection conn, MySqlTransaction trans, CommandType cmdType, string cmdText, MySqlParameter[] cmdParms);
    }
}
