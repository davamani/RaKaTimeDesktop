using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Data;
 using System.Data.SQLite;

namespace XyzTime
{

    public class SqlLiteDb
    {
        SQLiteConnection conn;
        public SqlLiteDb()
        {
            conn = new SQLiteConnection("Data Source=C:\\Temp\\local_rakatime.db; Version = 3; New = True; Compress = True; ",true);

        }

        public DataSet RetrieveUserInfo()
        {
            return this.GetDataSet("select UEmail, UPassword from UserLogin");
        }

        public void InsertTimeLog(string AppName, string AppTitle, string AppData, int KeyStroke, int MouseClick, int MouseMove, int TimeSec)
        {
            string str_Sql = @"Insert into TimeLog(AppName,AppTitle,AppData,LogOn,KeyStroke,MouseClick,MouseMove,TimeSec) 
            values (@AppName,@AppTitle,@AppData, datetime('now'),@KeyStroke,@MouseClick,@MouseMove,@TimeSec) ";
            SQLiteCommand sc = new SQLiteCommand(str_Sql);
            sc.Parameters.AddWithValue("@AppName", AppName);
            sc.Parameters.AddWithValue("@AppTitle", AppTitle);
            sc.Parameters.AddWithValue("@AppData", AppData);
            sc.Parameters.AddWithValue("@KeyStroke", KeyStroke);
            sc.Parameters.AddWithValue("@MouseClick", MouseClick);
            sc.Parameters.AddWithValue("@MouseMove", MouseMove);
            sc.Parameters.AddWithValue("@TimeSec", TimeSec);

            this.ExecuteQuery(sc);
        }

        public void InsertCaptureScreen(string FileName)
        {
            string str_Sql = @"Insert into CaptureScreen(FileName, FileCreatedOn) values (@FileName, datetime('now')) ";
            SQLiteCommand sc = new SQLiteCommand(str_Sql);
            sc.Parameters.AddWithValue("@FileName", FileName);
            this.ExecuteQuery(sc);
        }


        //   str_CreateTableSql = @"Create Table IF NOT EXISTS CaptureScreen(FileName text, FileCreatedOn Date DEFAULT CURRENT_TIMESTAMP)";


        public DataSet TimeLogTable()
        {
            return this.GetDataSet("Select * from TimeLog Order by LogSeq desc");
        }

        public DataSet GetDataSet(string str_Sql)
        {
            return this.GetDataSet(new SQLiteCommand(str_Sql));
        }
        public DataSet GetDataSet(SQLiteCommand SC)
        {
            //Open the connection
            if (conn.State != System.Data.ConnectionState.Open)
                conn.Open();

            // Create a data adapter  
            SC.Connection = conn;
            SQLiteDataAdapter da = new SQLiteDataAdapter(SC);
           

            // Create DataSet, fill it and view in data grid  
            DataSet ds = new DataSet();
            da.Fill(ds);

            // Open the connection  
            if (conn.State == System.Data.ConnectionState.Open)
                conn.Close();

            return ds;
            //dataGrid1.DataSource = ds.Tables["myTable"].DefaultView;
        }

        public void ExecuteQuery(SQLiteCommand sc)
        {
            // Open the connection  
            if (conn.State != System.Data.ConnectionState.Open)
                conn.Open();

            // Create a data adapter  
            sc.Connection = conn;
            sc.ExecuteNonQuery();
            if (conn.State == System.Data.ConnectionState.Open)
                conn.Close();
        }
        public void ExecuteQuery(string str_Sql)
        {
            this.ExecuteQuery(new SQLiteCommand(str_Sql));
        }

        public void IntializeSqlTables()
        {
            return;

        }

       
        public void SetupDatabase()
        {
             try
            {
                

                if (conn.State != System.Data.ConnectionState.Open) conn.Open();

              
                SQLiteCommand sc = new SQLiteCommand();
                string str_CreateTableSql = @"Create table IF NOT EXISTS TimeLog(LogSeq INTEGER PRIMARY KEY AUTOINCREMENT, LogOn Date DEFAULT CURRENT_TIMESTAMP, AppName text , 
            AppTitle text, AppData text, KeyStroke INTEGER, MouseClick INTEGER, MouseMove INTEGER, TimeSec INTEGER) ";
                
                sc.CommandText = str_CreateTableSql;
                sc.Connection = conn;
               sc.ExecuteNonQuery();


                sc = new SQLiteCommand();
                str_CreateTableSql = @"Create Table IF NOT EXISTS UserLogin(UEmail text,UPassword text)";
                sc.CommandText = str_CreateTableSql;
                sc.Connection = conn;
                sc.ExecuteNonQuery();

                sc = new SQLiteCommand();
                str_CreateTableSql = @"Create Table IF NOT EXISTS CaptureScreen(FileName text, FileCreatedOn Date DEFAULT CURRENT_TIMESTAMP)";
                sc.CommandText = str_CreateTableSql;
                sc.Connection = conn;
                sc.ExecuteNonQuery();


                conn.Close();
            }
            catch (Exception ex)
            {
                System.Windows.Forms.MessageBox.Show(ex.Message);
                if (conn.State != System.Data.ConnectionState.Closed)
                    conn.Close();
            }

        }
    }

    
}
