
using OutSystems.HubEdition.Extensibility.Data;
using OutSystems.HubEdition.Extensibility.Data.DatabaseObjects;

namespace OutSystems.HubEdition.DatabaseProvider.Cache.Introspection {
    public class CacheDataTypeInfo : IDataTypeInfo {

        public CacheDataTypeInfo(DBDataType type, string sqlDataType, int length, int decimals) {
            Type = type;
            SqlDataType = sqlDataType;
            Length = length;
            Decimals = decimals;
        }

        public DBDataType Type { get; set; }
        public string SqlDataType { get; private set; }
        public int Length { get; set; }
        public int Decimals { get; private set; }
    }
}
