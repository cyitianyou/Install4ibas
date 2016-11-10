using BTulz.ModelsTransformer.Transformer;
using System;
using System.Collections.Generic;
using System.Data;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Install4ibas.Tools.Plugin.DbManager
{
    public class SQLExecute
    {
        public static DataTable RunSQLGetTable(string sql, DbTransformer ConnectionFacttory)
        {
            DataTable result = null;

            var dbConnection = ConnectionFacttory.MyDbConnection;
            try
            {
                dbConnection.Open();
                try
                {
                    var sqlCommand = dbConnection.CreateCommand();
                    sqlCommand.CommandText = sql;
                   IDataReader dr=  sqlCommand.ExecuteReader();
                   result = toDataTable(dr);
                    result.TableName = "dt";
                }
                catch (Exception)
                {
                    throw;
                }
                if (dbConnection != null)
                    dbConnection.Close();
            }
            catch (Exception)
            {
                if (dbConnection != null)
                    dbConnection.Close();
                throw;
            }
            return result;
        }
        private static DataTable toDataTable(IDataReader dr)
        {

            DataTable dt = new DataTable();
            int iFieldCount = dr.FieldCount;
            for (int i = 0; i < iFieldCount; ++i)
            {
                DataColumn myDataColumn = new DataColumn();
                myDataColumn.DataType = dr.GetFieldType(i);
                myDataColumn.ColumnName = dr.GetName(i);
                dt.Columns.Add(myDataColumn);
            }
            dt.BeginLoadData();
            object[] objValues = new object[iFieldCount];
            while (dr.Read())
            {
                dr.GetValues(objValues);
                dt.LoadDataRow(objValues, true);
            }
            dr.Close();
            dt.EndLoadData();
            return dt;


        }
    }
}
