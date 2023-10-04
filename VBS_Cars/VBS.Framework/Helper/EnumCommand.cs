using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
/***********************************************************************************************************
 * Created by       : Shuruthi
 * Created On       : 09/22/2023
 *
 * Reviewed By      :
 * Reviewed On      :
 *
 * Purpose          : manage the commoon Enum number
 ***********************************************************************************************************/


namespace VBS.Framework.Helper
{
    public class EnumCommand
    {
        #region DB Related

        public enum DataType
        {
            BigInt,
            Boolean,
            Byte,
            Char,
            Date,
            DateTime,
            smalldatetime,
            Decimal,
            Double,
            Money,
            Int,
            Int16,
            Int32,
            Int64,
            SByte,
            Single,
            String,
            TimeSpan,
            UInt16,
            UInt32,
            UInt64,
            ByteArray,
            Varchar,
            nVarchar,
            None,
            Memo,
            Blob,
            Text,
            Xml,
            bit,
            ntext
        }

        public enum SQLType
        {
            SQLStatic,
            SQLDynamic,
            SQLStoredProcedure
        }

        public enum DBConnectionType
        {
            MasterDBConnection,
            ClusterDBConnection
        }

        public enum DataSource
        {
            DataSet,
            DataReader,
            DataTable,
            DataView,
            Scalar,
            ExecuteXmlReader
        }

        #endregion DB Related
    }
}
