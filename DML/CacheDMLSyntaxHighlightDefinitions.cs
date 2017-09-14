//------------------------- CACHE -----------------------
// Caché SQL reference: http://docs.intersystems.com/latest/csp/docbook/DocBook.UI.Page.cls?KEY=RSQL 

using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

using OutSystems.HubEdition.Extensibility.Data.DMLService;

namespace OutSystems.HubEdition.DatabaseProvider.Cache.DML {
    class CacheDMLSyntaxHighlightDefinitions : GenericDMLSyntaxHighlightDefinitions {
        public CacheDMLSyntaxHighlightDefinitions(CacheDMLService dmlService) : base(dmlService) { }

        public override IEnumerable<string> Keywords {
            get {
                return new[] {
                    "ABSOLUTE", "ADD", "ALL", "ALLOCATE", "ALTER", "ARE", "AS", "ASC", "ASSERTION", "AT", "AUTHORIZATION", "BEGIN", 
                    "BOTH", "BY", "CASCADE", "CASE",
                    "CHECK", "CLOSE", "COLLATE", "COMMIT", "CONNECT",
                    "CONNECTION", "CONSTRAINT", "CONSTRAINTS", "CONTINUE",
                    "CORRESPONDING", "CREATE", "CROSS", "CURRENT",
                    "CURSOR", "DEALLOCATE",
                    "DECLARE", "DEFAULT", "DEFERRABLE", "DEFERRED", "DELETE", "DESC",
                    "DESCRIBE", "DESCRIPTOR", "DIAGNOSTICS", "DISCONNECT", "DISTINCT",
                    "DOMAIN", "DROP", "ELSE", "END", "ENDEXEC", "ESCAPE", "EXCEPT",
                    "EXCEPTION", "EXEC", "EXECUTE", "EXTERNAL",
                    "FALSE", "FETCH", "FIRST", "FOR", "FOREIGN", "FROM", "FULL",
                    "GET", "GLOBAL", "GO", "GOTO", "GRANT", "GROUP", "HAVING",
                    "IDENTITY", "IMMEDIATE", "INDICATOR", "INITIALLY",
                    "INNER", "INPUT", "INSENSITIVE", "INSERT", "INTERSECT",
                    "INTO", "IS", "ISOLATION", "JOIN", "LANGUAGE", "LAST",
                    "LEADING", "LEFT", "LEVEL", "LOCAL",
                    "MODULE", "NAMES", "NATIONAL", "NATURAL",
                    "NEXT", "NO", "NULL", "OF", "ON",
                    "ONLY", "OPEN", "OPTION", "OUTER", "OUTPUT",
                    "PAD", "PARTIAL", "PREPARE", "PRESERVE", "PRIMARY", "PRIOR", "PRIVILEGES",
                    "PROCEDURE", "PUBLIC", "READ", "REAL", "REFERENCES", "RELATIVE",
                    "RESTRICT", "REVOKE", "RIGHT", "ROLE", "ROLLBACK", "ROWS",
                    "SCHEMA", "SCROLL", "SECTION", "SELECT",
                    "SET", "SPACE", "SQLERROR", "SQLSTATE", "STATISTICS",
                    "TABLE", "TEMPORARY",
                    "THEN", "TIMEZONE_HOUR", "TIMEZONE_MINUTE", "TO", "TOP",
                    "TRAILING", "TRANSACTION", "TRUE", "UNION", "UNIQUE",
                    "UPDATE", "USING", "VALUES", "VARYING", "WHEN",
                    "WHENEVER", "WHERE", "WITH", "WORK", "WRITE"
                };
            }
        }

        /// <summary>
        /// Based on http://dev.Cache.com/doc/refman/5.6/en/func-op-summary-ref.html
        /// </summary>
        public override IEnumerable<string> Functions {
            get {
                return new[] {
                    // Control flow functions
                    "COALESCE", "IFNULL", "ISNULL", "ISNUMERIC", "NULLIF", "NVL", 
                    // Comparison functions
                    "BETWEEN", "EXISTS", "SOME", "ANY", "GREATEST", "INTERVAL", "%ELEMENT", "%INLIST",
                    "%INSET", "%MATCHES", "OVERLAPS", "%PATTERN", "%STARTSWITH",
                    // Character-Type and Word-Aware Comparisons
                    "%PATTERN", "%CONTAINS", "%CONTAINSTERM", "%SIMILARITY",
                    // Aggregate functions
                    "AVG", "COUNT", "%DLIST", "LEAST", "MAX", "MIN", "STDDEV", "STDDEV_SAMP", "STDDEV_POP", "SUM", "VARIANCE", "VAR_SAMP", "VAR_POP",
                    //String functions
                    "BIT_LENGTH", "CHAR", "CHARACTER_LENGTH", "CHARINDEX", "CHAR_LENGTH", "DATALENGTH", "$EXTRACT",
                    "$FIND", "INSTR", "$JUSTIFY", "LCASE", "LEFT", "LEN", "LENGTH", "$LENGTH",
                    "LOWER", "MATCH", "OCTET_LENGTH", "$PIECE", "POSITION", "REPEAT", "REPLACE", "REPLICATE", "REVERSE", "RIGHT",
                    "SPACE", "%STARTSWITH", "STUFF", "SUBSTR", "SUBSTRING", "$TRANSLATE", "UCASE", "UPPER", 
                    // String Concatenation
                    "CONCAT", "STING", "XMLARG", 
                    // Truncation, Trimming, Padding
                    "LPAD", "RPAD", "TRIM", "LTRIM", "RTRIM", 
                    // Cast and Conversion functions
                    "CAST", "CONVERT", "STR", "STRING", "TO_CHAR", "TO_DATE", "TO_NUMBER", "TO_TIMESTAMP",
                    // Date and time functions
                    "CURDATE", "CURRENT_DATE", "CURRENT_TIME", "CURRENT_TIMESTAMP", "CURTIME", "DATE", "DATEADD", "DATEDIFF",
                    "DATENAME", "DATEPART", "DAY", "DAYNAME", "DAYOFMONTH", "DAYOFWEEK", "DAYOFYEAR",
                    "GETDATE", "GETUTCDATE", "HOUR", "LAST_DAY", "MINUTE", "MONTH", "MONTHNAME", "NOW",
                    "QUARTER", "SECOND", "SYSDATE", "TIMESTAMPADD", "TIMESTAMPDIFF", "WEEK", "YEAR",
                    // Information functions
                    "CURRENT_USER", "DATABASE", "FOUND", "%OID", "SESSION_USER", "SYSTEM_USER", "USER", 
                    // Numeric Functions
                    "ABS", "ACOS", "ASCII", "ASIN", "ATAN", "CEILING", "COS", "COT", "DEGREES", "EXP", "FLOOR", "LOG", "LOG10",
                    "MOD", "PI", "POWER", "RADIANS", "ROUND", "SIGN", "SIN", "SQRT", "SQUARE", "TAN", "TRUNCATE",
                    // Other
                    "DECODE", "%EXTERNAL", "%INTERNAL", "LAST_IDENTITY", "%OBJECT", "%ODBCIN", "%ODBCOUT", "SEARCH_INDEX", "$TSQL_NEWID",
                    // JSON
                    "JSON_ARRAYAGG", "JSON_ARRAY", "JSON_OBJECT",
                    // XML
                    "XMLCONCAT", "XMLELEMENT", "XMLFOREST",
                    // List functions
                    "LIST", "$LIST", "$LISTBUILD", "$LISTFIND", "$LISTFROMSTRING", "$LISTGET", "$LISTLENGTH", "$LISTSAME", "$LISTTOSTRING",
                    // Collation
                    "%EXACT", "%MINUS", "%PLUS", "%SQLSTRING", "%SQLUPPER", "%TRUNCATE",
                    // MultiValue support functions
                    "$MVFMT", "$MVFMTS", "$MVICONV", "$MVICONVS", "$MVOCONV", "$MVOCONVS", "%MVR"
                };
            }
        }

        /// <summary>
        /// Based on http://dev.Cache.com/doc/refman/5.6/en/non-typed-operators.html
        /// </summary>
        public override IEnumerable<string> Operators {
            get {
                return new[] {
                // Arithmetic
                "+", "-", "*", "/", "%",
                // Bitwise
                "&", "|", "^",
                // Comparison
                "=", ">", "<", ">=", "<=", "<>", "!=", "<=>", "BETWEEN", 
                // Assignment
                ":=",
                // Logical
                "AND", "&&", "LIKE", "NOT", "!", "OR", "||", "XOR", "&", "&&",
                // String
                "BINARY", "REGEXP", "RLIKE", "SOUNDS",
                // Other
                ".", "()", "**", "[", "]", "[[", "]]", "@", "?"
            };
            }
        }

        public override IEnumerable<string> DataTypes {
            get {
                return new[] {
                    // Exact
                    "INTEGER", "INT", "SMALLINT", "TINYINT", "MEDIUMINT", "BIGINT", "DEC", "DECIMAL", "NUMBER", "NUMERIC", "BIT", "LONG",
                    // Approximate
                    "FLOAT", "DOUBLE", "DOUBLE PRECISION",
                    // Date and Time
                    "DATE", "DATETIME", "TIMESTAMP", "TIME", "SMALLDATETIME",
                    // Character Strings
                    "CHAR", "NCHAR", "VARCHAR", "NVARCHAR", "CHAR VARYING", "CHARACTER", "CHARACTER VARYING",
                    // Binary Strings
                    "BINARY", "VARBINARY", "RAW", "IMAGE", "LONG BINARY", "LONG RAW", "LONGVARBINARY", 
                    // Global Character Strings
                    "TEXT", "LONGTEXT", "LONGVARCHAR", "NTEXT",
                    // Other
                    "MONEY", "SMALLMONEY", "ROWVERSION", "SERIAL", "SYSNAME", "UNIQUEIDENTIFIER"
                };
            }
        }

    }
}
