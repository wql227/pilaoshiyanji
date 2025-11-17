using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Data;
using System.Data.OleDb;
using ADOX;



namespace DoPENetConnect.Util
{

    public class AccessHelper
    {
        public string  conStr = "Provider = Microsoft.Jet.OLEDB.4.0; Data Source ={0}";
        string dbAddress;
        public AccessHelper()
        {
        }
        public void TestProgram()
        {
            GetDbName();
            BuildDb();
            CreateTable("table1", "步骤", "指令参数", "指令内容", "跳转到", "循环");
            AddOneRecord("table1", "1", "2", "3", "4", "5");
        }
        public void BuildDb()
        {
            ADOX.Catalog catalog = new Catalog();
            string createStr = string.Format("Provider = Microsoft.Jet.OLEDB.4.0; Data Source = {0}", dbAddress);
            try
            {
                catalog.Create(createStr);
            }
            catch (Exception ex)
            {
                Console.WriteLine(ex.ToString());
            }
        }

        public void CreateTable(string programName,string stepNo,string cmdname,string context,string jump,string cycle)
        {
            OleDbConnection conn = new OleDbConnection(string.Format(conStr,dbAddress));
            string dbstr = string.Format("CREATE TABLE {0}({1} TEXT,{2} TEXT,{3} TEXT, {4} TEXT, {5} TEXT)", programName, stepNo, cmdname,context,jump,cycle);
            OleDbCommand oleDbCom = new OleDbCommand(dbstr, conn);
            conn.Open();
            try
            {
                oleDbCom.ExecuteNonQuery();
            }
            catch (Exception ex)
            {
                Console.WriteLine(ex.ToString());
            }
            conn.Close();
        }

        public void AddOneRecord(string programName, string stepNo, string cmdname, string context, string jump, string cycle)
        {
            OleDbConnection conn = new OleDbConnection(string.Format(conStr, dbAddress));
            string dbstr = string.Format("INSERT INTO {0}(步骤,指令参数,指令内容, 跳转到, 循环) VALUES ({1},{2},{3},{4},{5})", programName, stepNo, cmdname, context, jump, cycle);
            OleDbCommand oleDbCom = new OleDbCommand(dbstr, conn);
            conn.Open();
            try
            {
                oleDbCom.ExecuteNonQuery();
            }
            catch (Exception ex)
            {
                Console.WriteLine(ex.ToString());
            }
            conn.Close();
        }


            public void GetDbName()
        {
            //IniFileHelper iniFileHelper = new IniFileHelper(@"Config.ini");
            //StringBuilder strTmp = new StringBuilder(255);
            //string dbAddress = IniFileHelper.GetIniString("DbSetting","ProgramDbAdress",)
            dbAddress = String.Concat(AppDomain.CurrentDomain.BaseDirectory, "data\\ProgramDb.mdb");
            
        }


        public DataTable viewAccessInfo()
        {
            //【1】连接数据库
            string connect_str = "Provider=Microsoft.Jet.OLEDB.4.0;Data Source=D:\\projects\\deopmaster\\DoPENet_Connect\\AccessDb\\programdb11.mdb";
            OleDbConnection thisConnection = new OleDbConnection(connect_str);
            //【2】编写SQL指令，星号（*）是选取所有列的快捷方式。
            string sql = "select * from NewTable";
            //OleDbDataAdapter是 DataSet 和数据源之间的桥梁，用于检索和保存数据。
            OleDbDataAdapter thisAdapter = new OleDbDataAdapter(sql, thisConnection);
            //DataSet可以理解成在应用程序中的数据库
            DataSet thisDataSet = new System.Data.DataSet();
            //使用 Fill 将数据从数据源加载到 DataSet 中
            thisAdapter.Fill(thisDataSet, "table");
            //DataTable可以理解成DataSet的一个表格；将table中的表格内容添加到datatable
            DataTable dt = thisDataSet.Tables["table"];
            //将数据表和dataGridView1进行绑定
            //关闭连接
            return dt;
        }
    }
}
