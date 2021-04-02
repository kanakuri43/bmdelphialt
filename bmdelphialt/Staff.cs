using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Data;
using System.Data.SqlClient;

public class Staff
{
    public string StaffName { get; }
    public string LoginPassword { get; }

    public Staff(int StaffId)
    {
        DataTable dt = new DataTable();

        var dc = new DatabaseController();
        //dc.SQL = "SELECT "
        //        + " 入力者名 "
        //        + "FROM MM入力者 "
        //        + "WHERE "
        //        + " 削除区分 = 0 "
        //        + " AND 入力者コード = '" + StaffId + "'";
        //dt = dc.ReadAsDataTable();

        //int i = 0;
        var sql = "SELECT "
                + " 入力者コード, "
                + " 入力者名 "
                + "FROM M入力者 "
                + "WHERE "
                + " 削除区分 = 0 "
                + " AND 入力者コード = '" + StaffId + "'";
        using (SqlCommand command = new SqlCommand(sql, dc.Connection))
        {
            using (SqlDataReader reader = command.ExecuteReader())
            {
                while (reader.Read())
                {
                    this.StaffName = reader["入力者名"].ToString();
                    //i = (int)reader["staff_id"];
                    //Console.WriteLine(i.ToString() + reader["staff_name"]);
                }
            }
        }


    }
}
