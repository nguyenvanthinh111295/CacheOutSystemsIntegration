/* 
 This source code (the "Generated Software") is generated by the OutSystems Platform 
 and is licensed by OutSystems (http://www.outsystems.com) to You solely for testing and evaluation 
 purposes, unless You and OutSystems have executed a specific agreement covering the use terms and 
 conditions of the Generated Software, in which case such agreement shall apply. 
*/

/* Cach� SQL referenece: http://docs.intersystems.com/latest/csp/docbook/DocBook.UI.Page.cls?KEY=RSQL */

using System;
using System.Text;
using OutSystems.HubEdition.Extensibility.Data.DMLService;
using OutSystems.RuntimeCommon;

namespace OutSystems.HubEdition.DatabaseProvider.Cache.DML {

    //--------------------------------- Cach� -----------------------//
    // NOTE: Using the default quotation marks for escape delimiter  //
    // to prevent clash with reserved words. This is default in      //
    // Cach�, although this can be configured to not be supported.   //
    //---------------------------------------------------------------//

    /// <summary>
    /// Implementation of the <see>IDMLIdentifiers</see> interface that defines methods
    /// that help build DML Identifiers for columns, tables, and others.
    /// </summary>
    public class CacheDMLIdentifiers : BaseDMLIdentifiers{

        // No need for secure stuff here
        private static readonly Random random = RandomGenerator.GetRandomGenerator();

        /// <summary>
        /// Initializes a new instance of the <see cref="CacheDMLIdentifiers"/> class.
        /// </summary>
        /// <param name="dmlService">The DML service.</param>
        internal CacheDMLIdentifiers(IDMLService dmlService) : base(dmlService) { }

        /// <summary>
        /// Gets the maximum length of a simple (not compound) identifier. This value should be the minimum valid
        /// length for any kind of identifier (e.g. table name, parameter name)
        /// </summary>
        public override int MaxLength {
            //------------------------- CACHE -----------------------//
            // Cach� performs a maximum length test of 200 characters (this is an arbitrary length used to avoid erroneous input; 
            // it is not an identifier validation).
            // We also add this check here because a length larger than 200 will let the check fail.
            get { return 200; }
        }

        /// <summary>
        /// Returns a name that can be used as a valid identifier (e.g. parameter name, constraint name).
        /// It should contain only valid characters and its length should not exceed the maximum defined in MaxLength.
        /// <para>This implementation escapes the <code>baseName</code> to contain only alphanumeric and '_' characters.
        /// If the <code>baseName</code> exceeds the maximum length, the <code>baseName</code> is truncated
        /// and the last five characters are replaced by random numbers.</para>
        /// </summary>
        /// <param name="baseName">An identifier name.</param>
        /// <param name="truncateUsingRandomDigits">
        /// Indicates if the identifier should be truncated if its length exceeds the <see cref="MaxLength"/>. In this case, 
        /// random digits should be used as a suffix to prevent name clashing.
        /// </param>
        /// <returns>A string representing a valid identifier.</returns>
        public override string GetValidIdentifier(string baseName, bool truncateUsingRandomDigits) {
            // We need to replace invalid characters to create a valid constraint name (#23805)

            //------------------------- CACHE -----------------------//
            // In Cach� the following characters are also allowed in identifiers: @, #, $, % (except those beginning with %Z and %z)
            // Should we add check for this?
            // Identifiers can only start with letter or % or _
            // The rest of the identifier can contain: letter or number or _ or @ or # or $

            int i = 0;
            int startAtIndex = 0;
            int len = baseName.Length;
            string finalIdentifier = String.Empty;
            StringBuilder escapedBaseName = new StringBuilder(len);

            // If identifier starts with %Z or %z then replace it with %_, continue checking the
            // identifier fro index 2 onward.
            if (len >= 2) {
                if ((baseName[0] == '%') && (baseName[1] == 'Z' || baseName[1] == 'z')) {
                    escapedBaseName.Append('%');
                    escapedBaseName.Append('_');
                    startAtIndex = 2;
                }
            }

            for (i = startAtIndex; i < len; i++) {
                char idChar = baseName[i];

                // If this is first cahracter can only start with letter or % or _
                if (i == 0) {
                    if (Char.IsLetter(idChar) || (idChar == '%') || (idChar == '_')) {
                        escapedBaseName.Append(idChar);
                    } else {
                        escapedBaseName.Append('_');
                    }
                } else {
                    if (Char.IsLetterOrDigit(idChar) ||
                        (idChar == '_') ||
                        (idChar == '@') ||
                        (idChar == '#') ||
                        (idChar == '$') ) {
                        escapedBaseName.Append(idChar);
                    } else {
                        escapedBaseName.Append('_');
                    }
                }
            }

            if (!truncateUsingRandomDigits || escapedBaseName.Length <= MaxLength) {
                finalIdentifier = escapedBaseName.ToString();
            } else {
                escapedBaseName.Length = Math.Max(0, MaxLength - 5);
                finalIdentifier = escapedBaseName.Append(String.Format("{0:00000}", random.Next(99999))).ToString();
            }

            return finalIdentifier;
        }

    }
}
