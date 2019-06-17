using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Data;
using System.Data.Common;
using System.Data.SQLite;
using System.Configuration;
using System.Collections;


namespace SQLiteOperate
{
    public class SQLiteDBHelper
    {

        public static readonly string ConnectionString = "Data Source=" + System.AppDomain.CurrentDomain.BaseDirectory + @"\SpliceControlMgr.db";
        private string connectionString = string.Empty;
        /// <summary>  
        /// 构造函数  
        /// </summary>  
        /// <param name="dbPath">SQLite数据库文件路径</param>  
        public SQLiteDBHelper(string dbPath)
        {
            this.connectionString = "Data Source=" + dbPath;
        }

        /// <summary>
        /// 获取连接
        /// </summary>
        /// <returns></returns>
        public string GetConnectionString()
        {
            return this.connectionString;
        }

        /// <summary>
        /// 
        /// </summary>
        public SQLiteDBHelper()
        {
            this.connectionString = ConnectionString;
        }

        /// <summary>
        /// 创建数据库
        /// </summary>
        /// <param name="dbPath">数据库路径</param>
        public void CreateTable(string dbPath)
        {
            //如果不存在改数据库文件，则创建该数据库文件  
            if (!System.IO.File.Exists(dbPath))
            {
                SQLiteConnection.CreateFile(dbPath + dbPath.Substring(dbPath.LastIndexOf("\\")) + ".db");
            }
        }
        /// <summary>  
        /// 创建SQLite数据库文件
        /// </summary>  
        /// <param name="dbPath">要创建的SQLite数据库文件路径</param>  
        /// <param name="sql">创建表的sql</param>    
        public void CreateDB(string dbPath, string strSqlite)
        {
            //using (SQLiteConnection connection = new SQLiteConnection(dbPath + dbPath.Substring(dbPath.LastIndexOf("\\")) + ".db"))  
            //{  
            //    connection.Open();  
            //    using (SQLiteCommand command = new SQLiteCommand(connection))  
            //    {
            //        command.CommandText = strSqlite;
            SQLiteDBHelper db = new SQLiteDBHelper(dbPath + dbPath.Substring(dbPath.LastIndexOf("\\")) + ".db");
            db.ExecuteNonQuery(strSqlite, null);
            //}  
            //}  
        }
        /// <summary>  
        /// 对SQLite数据库执行增删改操作，返回受影响的行数。  
        /// </summary>  
        /// <param name="sql">要执行的增删改的SQL语句</param>  
        /// <param name="parameters">执行增删改语句所需要的参数，参数必须以它们在SQL语句中的顺序为准</param>  
        /// <returns></returns>  
        public int ExecuteNonQuery(string sql, SQLiteParameter[] parameters)
        {
            int affectedRows = 0;
            using (SQLiteConnection connection = new SQLiteConnection(connectionString))
            {
                connection.Open();
                using (DbTransaction transaction = connection.BeginTransaction())
                {
                    using (SQLiteCommand command = new SQLiteCommand(connection))
                    {
                        command.CommandText = sql;
                        if (parameters != null)
                        {
                            command.Parameters.AddRange(parameters);
                        }
                        affectedRows = command.ExecuteNonQuery();
                    }
                    transaction.Commit();
                }
            }
            return affectedRows;
        }




        /// <summary>  
        /// 执行一个查询语句，返回一个关联的SQLiteDataReader实例  
        /// </summary>  
        /// <param name="sql">要执行的查询语句</param>  
        /// <param name="parameters">执行SQL查询语句所需要的参数，参数必须以它们在SQL语句中的顺序为准</param>  
        /// <returns></returns>  
        public SQLiteDataReader ExecuteReader(string sql, SQLiteParameter[] parameters)
        {
            SQLiteConnection connection = new SQLiteConnection(connectionString);
            SQLiteCommand command = new SQLiteCommand(sql, connection);
            if (parameters != null)
            {
                command.Parameters.AddRange(parameters);
            }
            connection.Open();
            return command.ExecuteReader(CommandBehavior.CloseConnection);
        }
        /// <summary>  
        /// 执行一个查询语句，返回一个包含查询结果的DataTable  
        /// </summary>  
        /// <param name="sql">要执行的查询语句</param>  
        /// <param name="parameters">执行SQL查询语句所需要的参数，参数必须以它们在SQL语句中的顺序为准</param>  
        /// <returns></returns>  
        public DataTable ExecuteDataTable(string sql, SQLiteParameter[] parameters)
        {
            using (SQLiteConnection connection = new SQLiteConnection(connectionString))
            {
                using (SQLiteCommand command = new SQLiteCommand(sql, connection))
                {
                    if (parameters != null)
                    {
                        command.Parameters.AddRange(parameters);
                    }
                    SQLiteDataAdapter adapter = new SQLiteDataAdapter(command);
                    DataTable data = new DataTable();
                    adapter.Fill(data);
                    return data;
                }
            }
        }


        public DataTable ExecuteDataTable(string sql)
        {
            using (SQLiteConnection connection = new SQLiteConnection(connectionString))
            {
                using (SQLiteCommand command = new SQLiteCommand(sql, connection))
                {
                    //if (parameters != null)
                    //{
                    //    command.Parameters.AddRange(parameters);
                    //}
                    SQLiteDataAdapter adapter = new SQLiteDataAdapter(command);
                    DataTable data = new DataTable();
                    adapter.Fill(data);
                    return data;
                }
            }

        }
        /// <summary>  
        /// 执行一个查询语句，返回查询结果的第一行第一列  
        /// </summary>  
        /// <param name="sql">要执行的查询语句</param>  
        /// <param name="parameters">执行SQL查询语句所需要的参数，参数必须以它们在SQL语句中的顺序为准</param>  
        /// <returns></returns>  
        public Object ExecuteScalar(string sql, SQLiteParameter[] parameters)
        {
            using (SQLiteConnection connection = new SQLiteConnection(connectionString))
            {
                using (SQLiteCommand command = new SQLiteCommand(sql, connection))
                {
                    if (parameters != null)
                    {
                        command.Parameters.AddRange(parameters);
                    }
                    SQLiteDataAdapter adapter = new SQLiteDataAdapter(command);
                    DataTable data = new DataTable();
                    adapter.Fill(data);
                    return data;
                }
            }
        }
        /// <summary>  
        /// 查询数据库中的所有数据类型信息  
        /// </summary>  
        /// <returns></returns>  
        public DataTable GetSchema()
        {
            using (SQLiteConnection connection = new SQLiteConnection(connectionString))
            {
                connection.Open();
                DataTable data = connection.GetSchema("TABLES");
                connection.Close();
                //foreach (DataColumn column in data.Columns)  
                //{  
                //    Console.WriteLine(column.ColumnName);  
                //}
                return data;
            }
        }
        // 哈希表用来存储缓存的参数信息，哈希表可以存储任意类型的参数。
        private static Hashtable parmCache = Hashtable.Synchronized(new Hashtable());
        /// <summary>
        /// 执行多条带事务的SQL语句
        /// </summary>
        /// <param name="connectionString"></param>
        /// <param name="IsTrans"></param>
        /// <param name="cmdType"></param>
        /// <param name="cmdText"></param>
        /// <param name="pramsList"></param>
        /// <returns></returns>
        public int ExecuteNonQuery(string connectionString, bool IsTrans, CommandType cmdType, string[] cmdText, ArrayList pramsList)
        {
            int pramsListIndex = 0;
            SQLiteParameter[] parms = null;
            SQLiteTransaction objTrans = null;
            //用于返回数据受影响的行数
            int val = 0;
            try
            {
                using (SQLiteConnection conn = new SQLiteConnection(connectionString))
                {
                    foreach (string str in cmdText)
                    {
                        if (pramsList != null)
                        {
                            parms = (SQLiteParameter[])pramsList[pramsListIndex];
                        }

                        //判断数据库连接状态
                        if (conn.State != ConnectionState.Open)
                            conn.Open();
                        SQLiteCommand cmd = new SQLiteCommand();
                        //判断
                        if (pramsListIndex == 0)
                        {
                            objTrans = conn.BeginTransaction();
                        }

                        //通过PrePareCommand方法将参数逐个加入到SqlCommand的参数集合中
                        PrepareCommand(cmd, conn, objTrans, cmdType, str, parms);

                        val = cmd.ExecuteNonQuery();

                        //清空SqlCommand中的参数列表
                        cmd.Parameters.Clear();
                        cmd = null;
                        pramsListIndex++;
                    }
                    //事务的提交
                    objTrans.Commit();
                    return val;
                }
            }
            catch (Exception err)
            {
                val = -1;
                //事务的回滚
                objTrans.Rollback();
                Console.WriteLine(err);
            }

            return val;
        }
        /// <summary>
        /// 执行一条不需要返回值的SqlCommand命令
        /// </summary>
        /// <param name="connectionString"></param>
        /// <param name="cmdType"></param>
        /// <param name="cmdText"></param>
        /// <param name="commandParameters"></param>
        /// <returns></returns>
        public static int ExecuteNonQuery(string connectionString, CommandType cmdType, string cmdText, params SQLiteParameter[] commandParameters)
        {

            SQLiteCommand cmd = new SQLiteCommand();
            using (SQLiteConnection conn = new SQLiteConnection(connectionString))
            {
                PrepareCommand(cmd, conn, null, cmdType, cmdText, commandParameters);
                int val = cmd.ExecuteNonQuery();
                cmd.Parameters.Clear();
                conn.Close();
                return val;
            }
        }
        /// <summary>
        /// 执行一个自定义链接的SQL数据
        /// </summary>
        /// <param name="connection"></param>
        /// <param name="cmdType"></param>
        /// <param name="cmdText"></param>
        /// <param name="commandParameters"></param>
        /// <returns></returns>
        public static int ExecuteNonQuery(SQLiteConnection connection, CommandType cmdType, string cmdText, params SQLiteParameter[] commandParameters)
        {
            SQLiteCommand cmd = new SQLiteCommand();
            PrepareCommand(cmd, connection, null, cmdType, cmdText, commandParameters);
            int val = cmd.ExecuteNonQuery();
            cmd.Parameters.Clear();
            connection.Close();
            return val;
        }
        /// <summary>
        /// 执行一个带事务的SQL
        /// </summary>
        /// <param name="trans"></param>
        /// <param name="cmdType"></param>
        /// <param name="cmdText"></param>
        /// <param name="commandParameters"></param>
        /// <returns></returns>
        public static int ExecuteNonQuery(SQLiteTransaction trans, CommandType cmdType, string cmdText, params SQLiteParameter[] commandParameters)
        {
            SQLiteCommand cmd = new SQLiteCommand();
            PrepareCommand(cmd, trans.Connection, trans, cmdType, cmdText, commandParameters);
            int val = cmd.ExecuteNonQuery();
            cmd.Parameters.Clear();
            trans.Connection.Close();
            return val;
        }
        /// <summary>
        ///  执行一条返回结果集的SqlCommand命令，通过专用的连接字符串。返回一个包含结果的SqlDataReader
        /// </summary>
        /// <param name="connectionString"></param>
        /// <param name="cmdType"></param>
        /// <param name="cmdText"></param>
        /// <param name="commandParameters"></param>
        /// <returns></returns>
        public static SQLiteDataReader ExecuteReader(string connectionString, CommandType cmdType, string cmdText, params SQLiteParameter[] commandParameters)
        {
            SQLiteCommand cmd = new SQLiteCommand();
            SQLiteConnection conn = new SQLiteConnection(connectionString);

            // 在这里使用try/catch处理是因为如果方法出现异常，则SqlDataReader就不存在，
            //CommandBehavior.CloseConnection的语句就不会执行，触发的异常由catch捕获。
            //关闭数据库连接，并通过throw再次引发捕捉到的异常。
            try
            {
                PrepareCommand(cmd, conn, null, cmdType, cmdText, commandParameters);
                SQLiteDataReader rdr = cmd.ExecuteReader(CommandBehavior.CloseConnection);
                cmd.Parameters.Clear();
                return rdr;
            }
            catch
            {
                conn.Close();
                throw;
            }
        }
        /// <summary>
        /// 执行一条不带参数的select语句
        /// </summary>
        /// <param name="connectionString"></param>
        /// <param name="cmdType"></param>
        /// <param name="cmdText"></param>
        /// <returns></returns>
        public static SQLiteDataReader ExecuteReader(string connectionString, CommandType cmdType, string cmdText)
        {
            SQLiteCommand cmd = new SQLiteCommand();
            SQLiteConnection conn = new SQLiteConnection(connectionString);

            // 在这里使用try/catch处理是因为如果方法出现异常，则SqlDataReader就不存在，
            //CommandBehavior.CloseConnection的语句就不会执行，触发的异常由catch捕获。
            //关闭数据库连接，并通过throw再次引发捕捉到的异常。
            try
            {
                PrepareCommand(cmd, conn, null, cmdType, cmdText);
                SQLiteDataReader rdr = cmd.ExecuteReader(CommandBehavior.CloseConnection);
                cmd.Parameters.Clear();
                return rdr;
            }
            catch
            {
                conn.Close();
                throw;
            }
        }
        /// <summary>
        /// 执行一条返回第一条记录第一列的SqlCommand命令，通过专用的连接字符串。 
        /// </summary>
        /// <param name="connectionString"></param>
        /// <param name="cmdType"></param>
        /// <param name="cmdText"></param>
        /// <param name="commandParameters"></param>
        /// <returns></returns>
        public static object ExecuteScalar(string connectionString, CommandType cmdType, string cmdText, params SQLiteParameter[] commandParameters)
        {
            SQLiteCommand cmd = new SQLiteCommand();

            using (SQLiteConnection connection = new SQLiteConnection(connectionString))
            {
                PrepareCommand(cmd, connection, null, cmdType, cmdText, commandParameters);
                object val = cmd.ExecuteScalar();
                cmd.Parameters.Clear();
                connection.Close();
                return val;
            }
        }
        /// <summary>
        /// 执行一条返回第一条记录第一列的SqlCommand命令，通过已经存在的数据库连接。
        /// </summary>
        /// <param name="connection"></param>
        /// <param name="cmdType"></param>
        /// <param name="cmdText"></param>
        /// <param name="commandParameters"></param>
        /// <returns></returns>
        public static object ExecuteScalar(SQLiteConnection connection, CommandType cmdType, string cmdText, params SQLiteParameter[] commandParameters)
        {
            SQLiteCommand cmd = new SQLiteCommand();
            PrepareCommand(cmd, connection, null, cmdType, cmdText, commandParameters);
            object val = cmd.ExecuteScalar();
            cmd.Parameters.Clear();
            connection.Close();
            return val;
        }


        /// <summary>
        /// 查询结构返回一个数据集
        /// </summary>
        /// <param name="connectionString"></param>
        /// <param name="cmdType"></param>
        /// <param name="cmdText"></param>
        /// <param name="tableName"></param>
        /// <param name="commandParameters"></param>
        /// <returns></returns>
        public static DataSet ExecuteDataSet(string connectionString, CommandType cmdType, string cmdText, string tableName, params SQLiteParameter[] commandParameters)
        {
            DataSet ds = new DataSet();
            using (SQLiteConnection conn = new SQLiteConnection(connectionString))
            {
                conn.Open();
                SQLiteCommand cmd = new SQLiteCommand();
                using (SQLiteDataAdapter da = new SQLiteDataAdapter())
                {
                    PrepareCommand(cmd, conn, null, cmdType, cmdText, commandParameters);
                    da.SelectCommand = cmd;
                    da.Fill(ds, tableName);
                    cmd.Parameters.Clear();
                    conn.Close();
                }
            }
            return ds;
        }


        /// <summary>
        /// 缓存参数数组
        /// </summary>
        /// <param name="cacheKey">参数缓存的键值</param>
        /// <param name="cmdParms">被缓存的参数列表</param>
        public static void CacheParameters(string cacheKey, params SQLiteParameter[] commandParameters)
        {
            parmCache[cacheKey] = commandParameters;
        }

        /// <summary>
        /// 获取被缓存的参数
        /// </summary>
        /// <param name="cacheKey">用于查找参数的KEY值</param>
        /// <returns>返回缓存的参数数组</returns>
        public static SQLiteParameter[] GetCachedParameters(string cacheKey)
        {
            SQLiteParameter[] cachedParms = (SQLiteParameter[])parmCache[cacheKey];

            if (cachedParms == null)
                return null;

            //新建一个参数的克隆列表
            SQLiteParameter[] clonedParms = new SQLiteParameter[cachedParms.Length];

            //通过循环为克隆参数列表赋值
            for (int i = 0, j = cachedParms.Length; i < j; i++)
                //使用clone方法复制参数列表中的参数
                clonedParms[i] = (SQLiteParameter)((ICloneable)cachedParms[i]).Clone();

            return clonedParms;
        }
        #region 为执行参数做准备
        private static void PrepareCommand(SQLiteCommand cmd, SQLiteConnection conn, SQLiteTransaction trans, CommandType cmdType, string cmdText, SQLiteParameter[] cmdParms)
        {
            if (conn.State != ConnectionState.Open)
                conn.Open();

            cmd.Connection = conn;
            cmd.CommandText = cmdText;

            //判断是否需要事物处理
            if (trans != null)
                cmd.Transaction = trans;
            cmd.CommandType = cmdType;
            if (cmdParms != null)
            {
                foreach (SQLiteParameter parm in cmdParms)
                    cmd.Parameters.Add(parm);
            }
        }
        private static void PrepareCommand(SQLiteCommand cmd, SQLiteConnection conn, SQLiteTransaction trans, CommandType cmdType, string cmdText)
        {
            //判断数据库连接状态
            if (conn.State != ConnectionState.Open)
                conn.Open();
            cmd.Connection = conn;
            cmd.CommandText = cmdText;

            //判断是否需要事物处理
            if (trans != null)
                cmd.Transaction = trans;
            cmd.CommandType = cmdType;
        }
        #endregion
    }
}
