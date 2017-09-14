/* 
 This source code (the "Generated Software") is generated by the OutSystems Platform 
 and is licensed by OutSystems (http://www.outsystems.com) to You solely for testing and evaluation 
 purposes, unless You and OutSystems have executed a specific agreement covering the use terms and 
 conditions of the Generated Software, in which case such agreement shall apply. 
*/

using OutSystems.HubEdition.Extensibility.Data;
using OutSystems.HubEdition.Extensibility.Data.ConfigurationService;
using OutSystems.HubEdition.Extensibility.Data.DatabaseObjects;
using OutSystems.HubEdition.Extensibility.Data.DMLService;
using OutSystems.HubEdition.Extensibility.Data.ExecutionService;
using OutSystems.HubEdition.Extensibility.Data.IntrospectionService;
using OutSystems.HubEdition.Extensibility.Data.TransactionService;
using OutSystems.HubEdition.DatabaseProvider.Cache.DML;
using OutSystems.HubEdition.DatabaseProvider.Cache.Execution;
using OutSystems.HubEdition.DatabaseProvider.Cache.Introspection;
using OutSystems.HubEdition.DatabaseProvider.Cache.Transaction;

namespace OutSystems.HubEdition.DatabaseProvider.Cache {

    /// <summary>
    /// Represents the set of services that needs to be implemented to add support for a new database.
    /// </summary>
    public class CacheDatabaseServices : IDatabaseServices {

        private readonly IRuntimeDatabaseConfiguration _configuration;
        private readonly IDatabaseObjectFactory _objectFactory;
        private readonly ITransactionService _transactionService;
        private readonly IExecutionService _executionService;
        private readonly IDMLService _dmlService;
        private readonly IIntrospectionService _introspectionService;

        /// <summary>
        /// Initializes a new instance of the <see cref="CacheDatabaseServices"/> class.
        /// </summary>
        /// <param name="databaseConfiguration">The database configuration.</param>
        public CacheDatabaseServices(IRuntimeDatabaseConfiguration databaseConfiguration) {
            _configuration = databaseConfiguration;
            _objectFactory = new CacheDatabaseObjectFactory(this);
            _transactionService = new CacheTransactionService(this);
            _executionService = new CacheExecutionService(this);
            _dmlService = new CacheDMLService(this);
            _introspectionService = new CacheIntrospectionService(this);
        }

        /// <summary>
        /// Returns a factory capable of creating database information objects from qualified names. If required, this object might access the database.
        /// </summary>
        public IDatabaseObjectFactory ObjectFactory { get { return _objectFactory; } }

        /// <summary>
        /// Gets the <see cref="T:OutSystems.HubEdition.Extensibility.Data.TransactionService.ITransactionService" />object associated with a database.
        /// Represents a specific database connection or transaction.
        /// </summary>
        public ITransactionService TransactionService { get { return _transactionService; } }

        /// <summary>
        /// Gets the <see cref="T:OutSystems.HubEdition.Extensibility.Data.ExecutionService.IExecutionService" /> associated with the database.
        /// Represents an execution context to run SQL commands on a database.
        /// </summary>
        public IExecutionService ExecutionService { get { return _executionService; } }

        /// <summary>
        /// Gets the <see cref="T:OutSystems.HubEdition.Extensibility.Data.DMLService.IDMLService" />object associated with the database.
        /// Represents a service that generates SQL statements.
        /// </summary>
        public IDMLService DMLService { get { return _dmlService; } }

        /// <summary>
        /// Gets the <see href="IIntrospectionService" />object associated with the database.
        /// Represents a service that provides information about meta-data of the database.
        /// </summary>
        public IIntrospectionService IntrospectionService { get { return _introspectionService; } }

        /// <summary>
        /// Gets the <see cref="T:OutSystems.HubEdition.Extensibility.Data.ConfigurationService.IIntegrationDatabaseConfiguration" />object associated with a database.
        /// It encapsulates the necessary information to connect to a database instance.
        /// </summary>
        public IRuntimeDatabaseConfiguration DatabaseConfiguration { get { return _configuration; } }
    }
}
