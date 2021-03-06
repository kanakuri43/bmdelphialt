using System;
using System.Collections.Generic;
using System.Data;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Xml.XPath;
using System.Xml.Linq;
using System.Data.SqlClient;
using System.Windows.Data;

public class DatabaseController
    {
    public string SQL { set;  get; }

    //public int Readcnt;
    //public string Errmsg = "";
    //public System.Data.OleDb.OleDbDataReader DataReader;
    //public string ConnectionString = "";
    //public string configFname = "";

    //private MySqlConnection Connection;
    public SqlConnection Connection { set;  get; }

    public DatabaseController()
    {
        OpenConnection();

        

    }

    public Boolean OpenConnection()
    {        
        string currentDirectory = System.AppDomain.CurrentDomain.BaseDirectory;
        XElement xml = XElement.Load(currentDirectory + "DatabaseConnection.xml");

        try
        {
            var cs = xml.Element("ConnectString").Value;
            this.Connection = new SqlConnection(cs);
            Connection.Open();
            return true;
        }
        catch
        {
            return false;;
        }
    }

    public string VersionInfo()
    {
        SqlCommand command = new SqlCommand();
        {
            // バージョン情報取得SQLを実行します。
            command.Connection = Connection;
            command.CommandText = "select version()";
            var value = command.ExecuteScalar();
            var versionNo = value.ToString();
            return ($"{versionNo}");
        }

    }

    public DataTable ReadAsDataTable()
    {
        using (SqlCommand command = new SqlCommand(this.SQL, this.Connection))
        {
            DataTable dt;
            var addapter = new SqlDataAdapter(command);
            dt = new DataTable();
            addapter.Fill(dt);
            return dt;
        }




        //Boolean result;

        //System.Data.OleDb.OleDbCommand DbCommand;
        //System.Data.OleDb.OleDbConnection DbConnection = new System.Data.OleDb.OleDbConnection();
        //DbConnection.ConnectionString = ConnectionString;
        //try
        //{
        //    DbConnection.Open();
        //    DbCommand = new System.Data.OleDb.OleDbCommand(this.Sql, DbConnection);
        //    DataReader = DbCommand.ExecuteReader();
        //    result = true ;
        //}
        //catch (Exception ex)
        //{
        //    Errmsg  = ex.Message+ConnectionString;
        //    result = false;
        //}

    }
    //public Boolean getDatatable(ref DataTable dtbl)
    //{
        //Boolean result;

        //System.Data.OleDb.OleDbCommand com;
        //System.Data.OleDb.OleDbConnection cn = new System.Data.OleDb.OleDbConnection();
        //cn.ConnectionString = ConnectionString;
        //try
        //{
        //    cn.Open();
        //    com = new System.Data.OleDb.OleDbCommand(SQL, cn);
        //    System.Data.OleDb.OleDbDataAdapter adapter = new System.Data.OleDb.OleDbDataAdapter(com);
        //    dtbl.Clear();
        //    adapter.Fill(dtbl);
        //}
        //catch (Exception ex)
        //{
        //    Errmsg = ex.Message;
        //    result = false;
        //}
        //finally
        //{
        //    // DB切断
        //    if (cn != null) cn.Close();
        //    result = true;
        //}
        //return result;
    //}

    //public Boolean Execute()
    //{
    //    Boolean result;

    //    System.Data.OleDb.OleDbTransaction oletran;
    //    System.Data.OleDb.OleDbCommand com;
    //    System.Data.OleDb.OleDbConnection cn = new System.Data.OleDb.OleDbConnection();
    //    cn.ConnectionString = ConnectionString;
    //    cn.Open();

    //    com = new System.Data.OleDb.OleDbCommand(SQL, cn);
    //    oletran = cn.BeginTransaction(); //--トランザクション開始
    //    com.Transaction = oletran;
    //    try
    //    {
    //        com.ExecuteNonQuery();
    //        oletran.Commit();
    //        result = true;
    //    }
    //    catch (Exception ex)
    //    {
    //        oletran.Rollback();
    //        Errmsg = ex.Message;

    //        result = false;
    //    }
    //    cn.Close();
    //   return result;
    //}


}
