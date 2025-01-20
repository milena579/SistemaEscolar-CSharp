using System.Data;
using System.Text;
using System.Windows.Markup;
using Microsoft.Data.SqlClient;
// using System.Data.SqlClient;

namespace DataBase;
public class  DBSqlServer<T> where T : DataBaseObject, new() {
    private SqlConnection conm;

    public DBSqlServer(string dataSource, string database){
        SqlConnectionStringBuilder s= new();
        s.DataSource = dataSource;
        s.InitialCatalog = database;
        s.IntegratedSecurity = true;
        string connection = s.ConnectionString;
        conm = new SqlConnection(connection);
    }

    public List<T> All{
        get{
            List<T> values = [];
            conm.Open();
            SqlCommand cmd = new ($"SELECT * FROM {typeof(T).Name}");
            cmd.Connection = conm;
            var reader = cmd.ExecuteReader();
            
            DataTable dt = new();
            dt.Load(reader);

            for(int i = 0; i < dt.Rows.Count; i++){
                T obj = new();
                obj.LoadFromSqlRow(dt.Rows[i]);
                values.Add(obj);
            }

            conm.Close();

            return values;
        }
    }
    public void Save(T obj) {
        string values = obj.SaveToSql();
        conm.Open();
        SqlCommand cmd = new(values) {
            Connection = conm
        };

        cmd.ExecuteNonQuery();
        conm.Close();
    }
 }