using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Data;
using System.Data.SqlClient;
using System.Drawing;


namespace ktunotifications
{
    class database
    {
        private SqlConnection con = new SqlConnection(@"Data Source=JOELVARGIS\SQLEXPRESS;Initial Catalog=""ktu alerts"";Integrated Security=True");
         public SqlConnection GetCon() 
         { 
             return con; 
         }
         public void OpenCon() 
         { 
             if(con.State==ConnectionState.Closed)
             {
                 con.Open();
             }
         }
         public void CloseCon()
         {
             if (con.State == ConnectionState.Open)
             {
                 con.Close();
             }
         }
     
    }
}
