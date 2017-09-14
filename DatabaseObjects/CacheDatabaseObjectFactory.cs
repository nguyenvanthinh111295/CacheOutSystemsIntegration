/* 
 This source code (the "Generated Software") is generated by the OutSystems Platform 
 and is licensed by OutSystems (http://www.outsystems.com) to You solely for testing and evaluation 
 purposes, unless You and OutSystems have executed a specific agreement covering the use terms and 
 conditions of the Generated Software, in which case such agreement shall apply. 
*/

using System;
using System.Text.RegularExpressions;
using OutSystems.HubEdition.Extensibility.Data;
using OutSystems.HubEdition.Extensibility.Data.DatabaseObjects;
using OutSystems.HubEdition.Extensibility.Data.IntrospectionService;
using OutSystems.HubEdition.DatabaseProvider.Cache.Configuration;

namespace OutSystems.HubEdition.DatabaseProvider.Cache.Introspection {

    /// <summary>
    /// Creates introspection objects from qualified names, inspecting the database only if needed.
    /// </summary>
    public class CacheDatabaseObjectFactory : IDatabaseObjectFactory {

        protected readonly IDatabaseServices databaseServices;

        // It is unclear wheter the qualifiedName is delimited with single quotes. The Cache example checked for single quote delimited
        // qualifiedName, so we will do the same.
        private static readonly Regex pieceRegex = new Regex("(\"[^\"]+\")|([^\\.\"]+)", RegexOptions.Compiled);

        private static readonly char[] trimChars = " \"".ToCharArray();

        /// <summary>
        /// Initializes a new instance of the <see cref="CacheDatabaseObjectFactory"/> class.
        /// </summary>
        /// <param name="databaseServices">The database services.</param>
        public CacheDatabaseObjectFactory(IDatabaseServices databaseServices) {
            this.databaseServices = databaseServices;
        }

        /// <summary>
        /// Returns an object that contains information about the current database
        /// </summary>
        /// <returns>
        /// Database-specific object that implements the IDatabaseInfo interface
        /// </returns>
        public IDatabaseInfo CreateLocalDatabaseInfo() {
            return new CacheDatabaseInfo(databaseServices, ((CacheRuntimeDatabaseConfiguration)databaseServices.DatabaseConfiguration).Namespace);
        }

        /// <summary>
        /// Returns an object that contains information about a database, inferring it from a database identifier.
        /// If the <paramref name="databaseIdentifier" /> does not contain all the required information, the remaining
        /// should be inferred from the current <see cref="T:OutSystems.HubEdition.Extensibility.Data.ConfigurationService.IRuntimeDatabaseConfiguration" />.
        /// </summary>
        /// <param name="databaseIdentifier">Unique identifier of the database</param>
        /// <returns>
        /// Database-specific object that implements the IDatabaseInfo interface
        /// </returns>
        public IDatabaseInfo CreateDatabaseInfo(string databaseIdentifier) {
            string schema = databaseIdentifier.Trim(trimChars);
            return new CacheDatabaseInfo(databaseServices, schema);
        }

        /// <summary>
        /// Returns an object that contains information about a table source (data source in tabular format), like a database table or view,
        /// inferring both the database and table source information from a qualifiedName. If the <paramref name="qualifiedName" /> does not contain
        /// all the required information, the remaining should be inferred from the current <see cref="T:OutSystems.HubEdition.Extensibility.Data.ConfigurationService.IRuntimeDatabaseConfiguration" />.
        /// </summary>
        /// <param name="qualifiedName">Qualified identifier of the table source, including the database information</param>
        /// <returns>
        /// Database-specific object that implements the ITableSourceInfo interface
        /// </returns>
        public ITableSourceInfo CreateTableSourceInfo(string qualifiedName) {
            string table;
            string schema;
            if (ParseQualifiedTableName(qualifiedName, out schema, out table)) {
                return new CacheTableSourceInfo(databaseServices, new CacheDatabaseInfo(databaseServices, schema), table, qualifiedName);
            }
            throw new IntrospectionServiceException("'" + qualifiedName + "' is not a valid qualified table name.");
        }

        private bool ParseQualifiedTableName(string qualifiedName, out string schema, out string table) {
            bool found = true;
            schema = "";
            table = "";

            MatchCollection matches = pieceRegex.Matches(qualifiedName);
            switch (matches.Count) {
                case 1:
                    table = matches[0].Value.Trim(trimChars);
                    break;
                case 2:
                    schema = matches[0].Value.Trim(trimChars);
                    table = matches[1].Value.Trim(trimChars);
                    break;
                default:
                    found = false;
                    break;
            }
            return found;
        }

    }
}
