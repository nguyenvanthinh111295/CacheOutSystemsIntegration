/* 
 This source code (the "Generated Software") is generated by the OutSystems Platform 
 and is licensed by OutSystems (http://www.outsystems.com) to You solely for testing and evaluation 
 purposes, unless You and OutSystems have executed a specific agreement covering the use terms and 
 conditions of the Generated Software, in which case such agreement shall apply. 
*/

/*
ABSOLUTE | ADD | ALL | ALLOCATE | ALTER | AND | ANY | ARE | AS | 
ASC | ASSERTION | AT | AUTHORIZATION | AVG | BEGIN | BETWEEN | 
BIT | BIT_LENGTH | BOTH | BY | CASCADE | CASE | CAST |
CHAR | CHARACTER | CHARACTER_LENGTH | CHAR_LENGTH | 
CHECK | CLOSE | COALESCE | COLLATE | COMMIT | CONNECT | 
CONNECTION | CONSTRAINT | CONSTRAINTS | CONTINUE | CONVERT | 
CORRESPONDING | COUNT | CREATE | CROSS | CURRENT | 
CURRENT_DATE | CURRENT_TIME | CURRENT_TIMESTAMP | 
CURRENT_USER | CURSOR | DATE | DEALLOCATE | DEC | DECIMAL | 
DECLARE | DEFAULT | DEFERRABLE | DEFERRED | DELETE | DESC | 
DESCRIBE | DESCRIPTOR | DIAGNOSTICS | DISCONNECT | DISTINCT | 
DOMAIN | DOUBLE | DROP | ELSE | END | ENDEXEC | ESCAPE | EXCEPT | 
EXCEPTION | EXEC | EXECUTE | EXISTS | EXTERNAL | EXTRACT | 
FALSE | FETCH | FIRST | FLOAT | FOR | FOREIGN | FOUND | FROM | FULL | 
GET | GLOBAL | GO | GOTO | GRANT | GROUP | HAVING | HOUR | 
IDENTITY | IMMEDIATE | IN | INDICATOR | INITIALLY | 
INNER | INPUT | INSENSITIVE | INSERT | INT | INTEGER | INTERSECT | 
INTERVAL | INTO | IS | ISOLATION | JOIN | LANGUAGE | LAST | 
LEADING | LEFT | LEVEL | LIKE | LOCAL | LOWER | MATCH | MAX | MIN | 
MINUTE | MODULE | NAMES | NATIONAL | NATURAL | NCHAR | 
NEXT | NO | NOT | NULL | NULLIF | NUMERIC | OCTET_LENGTH | OF | ON | 
ONLY | OPEN | OPTION | OR | OUTER | OUTPUT | OVERLAPS | 
PAD | PARTIAL | PREPARE | PRESERVE | PRIMARY | PRIOR | PRIVILEGES | 
PROCEDURE | PUBLIC | READ | REAL | REFERENCES | RELATIVE | 
RESTRICT | REVOKE | RIGHT | ROLE | ROLLBACK | ROWS | 
SCHEMA | SCROLL | SECOND | SECTION | SELECT | SESSION_USER | 
SET | SMALLINT | SOME | SPACE | SQLERROR | SQLSTATE | STATISTICS | 
SUBSTRING | SUM | SYSDATE | SYSTEM_USER | TABLE | TEMPORARY | 
THEN | TIME | TIMEZONE_HOUR | TIMEZONE_MINUTE | TO | TOP | 
TRAILING | TRANSACTION | TRIM | TRUE | UNION | UNIQUE | 
UPDATE | UPPER | USER | USING | VALUES | VARCHAR | VARYING | WHEN | 
WHENEVER | WHERE | WITH | WORK | WRITE 
 */



using OutSystems.HubEdition.Extensibility.Data;
using OutSystems.HubEdition.Extensibility.Data.DatabaseObjects;
using OutSystems.HubEdition.Extensibility.Data.DMLService;

namespace OutSystems.HubEdition.DatabaseProvider.Cache.DML {

    /// <summary>
    /// Defines a contract for generating SQL fragments to interact with a database.
    /// </summary>
    public class CacheDMLService : BaseDMLService {

        private readonly IDMLQueries _queries;
        private readonly IDMLIdentifiers _identifiers;
        private readonly IDMLOperators _operators;
        private readonly IDMLFunctions _functions;
        private readonly IDMLAggregateFunctions _aggregateFunctions;
        private readonly IDMLDefaultValues _defaultValues;
        private readonly IDMLSyntaxHighlightDefinitions _syntaxHighlightDefinitions;

        /// <summary>
        /// Initializes a new instance of the <see cref="CacheDMLService"/> class.
        /// </summary>
        /// <param name="databaseServices">The database services.</param>
        public CacheDMLService(IDatabaseServices databaseServices)
            : base(databaseServices) {
            _queries = new CacheDMLQueries(this);
            _identifiers = new CacheDMLIdentifiers(this);
            _operators = new CacheDMLOperators(this);
            _functions = new CacheDMLFunctions(this);
            _aggregateFunctions = new CacheDMLAggregateFunctions(this);
            _defaultValues = new CacheDMLDefaultValues(this);
        }

        /// <summary>
        /// Gets an object that generates the SQL fragments required to perform entity actions.
        /// </summary>
        /// <param name="tableSourceInfo">Information about the entity's underlying table source</param>
        /// <returns></returns>
        public override IDMLEntityActions GetEntityActions(ITableSourceInfo tableSourceInfo){
            return new CacheDMLEntityActions(this, tableSourceInfo);
        }

        /// <summary>
        /// Gets an object that generates the SQL fragments required to perform specific queries (e.g. count query).
        /// </summary>
        public override IDMLQueries Queries { get { return _queries; } }

        /// <summary>
        /// Gets an object that generates and manipulates SQL identifiers.
        /// </summary>
        public override IDMLIdentifiers Identifiers { get { return _identifiers; } }

        /// <summary>
        /// Gets an object that generates the SQL operators required to execute simple queries.
        /// </summary>
        public override IDMLOperators Operators { get { return _operators; } }

        /// <summary>
        /// Gets an object that generates the SQL functions required to execute simple queries
        /// </summary>
        public override IDMLFunctions Functions { get { return _functions; } }

        /// <summary>
        /// Gets an object that generates the SQL aggregate functions required to execute simple queries
        /// </summary>
        public override IDMLAggregateFunctions AggregateFunctions { get { return _aggregateFunctions; } }

        /// <summary>
        /// Gets an object that generates the SQL default values for each database type.
        /// </summary>
        public override IDMLDefaultValues DefaultValues { get { return _defaultValues; } }
    }
}
