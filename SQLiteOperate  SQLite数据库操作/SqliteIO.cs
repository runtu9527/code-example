using System;
using System.Collections.Generic;
using System.IO;
using System.Linq;
using System.Text;
using SQLite;
using System.Data;

namespace SQLiteOperate
{
    public class SqliteIO
    {
        public static List<string> GetTableColumnsName(string dbPath, string tableName)
        {
            List<string> colsName = new List<string>();
            if (!File.Exists(dbPath))
            {
                goto end;
            }

            SQLiteConnection db = null;
            try
            {
                db = new SQLiteConnection(dbPath);
                List<SQLite.SQLiteConnection.ColumnInfo> colsInfo = db.GetTableInfo(tableName);
                foreach (SQLite.SQLiteConnection.ColumnInfo item in colsInfo)
                {
                    colsName.Add(item.Name);
                }
            }
            catch { }
            finally
            {
                if (db != null)
                {
                    db.Close();
                }
            }

            end:
            return colsName;
        }

        public static void CreateTable<T>(string dbPath) where T : new()
        {
            if (File.Exists(dbPath))
            {
                return;
            }

            SQLiteConnection db = null;
            try
            {
                db = new SQLiteConnection(dbPath);
                db.CreateTable<T>();
            }
            catch { }
            finally
            {
                if (db != null)
                {
                    db.Close();
                }
            }
        }

        public static bool SqlExecute(string sql, string dbPath)
        {
            if (!File.Exists(dbPath))
            {
                return false;
            }

            SQLiteConnection db = null;
            int nResult = 0;
            try
            {
                db = new SQLiteConnection(dbPath);
                if (null == db)
                {
                    return false;
                }
                nResult = db.Execute(sql);
            }
            catch { }
            finally
            {
                if (db != null)
                {
                    db.Close();
                }
            }

            return nResult > 0;
        }

        public static bool SqlExecute(string dbPath, string query, params object[] args)
        {
            if (!File.Exists(dbPath))
            {
                return false;
            }

            SQLiteConnection db = null;
            int nResult = 0;
            try
            {
                db = new SQLiteConnection(dbPath);
                if (null == db)
                {
                    return false;
                }
                nResult = db.Execute(query, args);
            }
            catch { }
            finally
            {
                if (db != null)
                {
                    db.Close();
                }
            }

            return nResult > 0;
        }

        public static List<T> GetDbData<T>(string sqlString, string dbPath) where T : new()
        {
            List<T> dataList = null;
            if (!File.Exists(dbPath))
            {
                return null;
            }

            SQLiteConnection db = null;
            try
            {
                db = new SQLiteConnection(dbPath);

                dataList = db.Query<T>(sqlString);
            }
            catch { }
            finally
            {
                if (db != null)
                {
                    db.Close();
                }
            }
            return dataList;
        }

        public static List<T> GetDbData<T>(string dbPath, string query, params object[] args) where T : new()
        {
            List<T> dataList = null;
            if (!File.Exists(dbPath))
            {
                return null;
            }

            SQLiteConnection db = null;
            try
            {
                db = new SQLiteConnection(dbPath);

                dataList = db.Query<T>(query, args);
            }
            catch { }
            finally
            {
                if (db != null)
                {
                    db.Close();
                }
            }
            return dataList;
        }

        public static T GetDbSingleData<T>(string sqlString, string dbPath) where T : new()
        {
            List<T> dataList = null;
            if (!File.Exists(dbPath))
            {
                return default(T);
            }

            SQLiteConnection db = null;
            try
            {
                db = new SQLiteConnection(dbPath);

                dataList = db.Query<T>(sqlString);
            }
            catch { }
            finally
            {
                if (db != null)
                {
                    db.Close();
                }
            }

            if (dataList != null && dataList.Count > 0)
            {
                return dataList[0];
            }
            else
            {
                return default(T);
            }
        }

        public static bool UpdateTable<T>(object obj, string dbPath)
        {
            SQLiteConnection db = null;
            try
            {
                db = new SQLiteConnection(dbPath);
                if (null == db)
                {
                    return false;
                }
                db.CreateTable<T>();
                db.BeginTransaction();
                db.InsertOrReplace(obj);
            }
            catch (Exception e)
            {
                return false;
            }
            finally
            {
                if (db != null)
                {
                    db.Commit();
                    db.Close();
                }
            }

            return true;
        }

        public static bool UpdateTableDatas<T>(List<object> objs, string dbPath)
        {
            SQLiteConnection db = null;
            try
            {
                db = new SQLiteConnection(dbPath);
                if (null == db)
                {
                    return false;
                }
                db.CreateTable<T>();
                db.BeginTransaction();
                foreach (object obj in objs)
                {
                    db.InsertOrReplace(obj);
                }
            }
            catch (Exception e)
            {
                return false;
            }
            finally
            {
                if (db != null)
                {
                    db.Commit();
                    db.Close();
                }
            }

            return true;
        }

        public static bool Delete(object obj, string dbPath)
        {
            SQLiteConnection db = null;
            try
            {
                db = new SQLiteConnection(dbPath);
                if (null == db)
                {
                    return false;
                }

                db.Delete(obj);
            }
            catch (Exception e)
            {
                return false;
            }
            finally
            {
                if (db != null)
                {
                    db.Close();
                }
            }

            return true;
        }

        /// <summary>
        /// 可以查询中文，暂时是查询最好用的一个
        /// </summary>
        /// <param name="sql"></param>
        /// <param name="dbPath"></param>
        /// <returns></returns>
        static public List<T> DBselect<T>(string sql,string dbPath) where T : class, new()
        {
            using (System.Data.SQLite.SQLiteConnection conn = new System.Data.SQLite.SQLiteConnection("Data Source =" + dbPath))//创建连接  
            {
                conn.Open();//打开连接  
                using (System.Data.SQLite.SQLiteTransaction tran = conn.BeginTransaction())//实例化一个事务  
                {
                    System.Data.SQLite.SQLiteCommand cmdQ = new System.Data.SQLite.SQLiteCommand(sql, conn);
                    System.Data.SQLite.SQLiteDataAdapter EmployeeAdapter = new System.Data.SQLite.SQLiteDataAdapter();
                    EmployeeAdapter.SelectCommand = cmdQ;
                    DataSet rs = new DataSet();
                    EmployeeAdapter.Fill(rs);

                    //System.Data.SQLite.SQLiteDataReader reader = cmdQ.ExecuteReader();
                    //tran.Commit();//提交 
                    //conn.Close();
                    tran.Dispose();
                    conn.Dispose();
                    //return rs.Tables[0];
                    List<T> result = new List<T>();
                    result = DataSetOperate.ToList<T> (rs.Tables[0]);
                    return result;
                }
            }
        }


    }
}
