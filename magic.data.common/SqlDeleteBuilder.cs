﻿/*
 * Magic, Copyright(c) Thomas Hansen 2019 - thomas@gaiasoul.com
 * Licensed as Affero GPL unless an explicitly proprietary license has been obtained.
 */

using System.Text;
using magic.node;
using magic.signals.contracts;

namespace magic.data.common
{
    /// <summary>
    /// Specialised delete SQL builder, to create a delete SQL statement by semantically traversing an input node.
    /// </summary>
    public abstract class SqlDeleteBuilder : SqlBuilder
    {
        /// <summary>
        /// Creates a delete SQL statement
        /// </summary>
        /// <param name="node">Root node to generate your SQL from.</param>
        /// <param name="signaler">Signaler to invoke slots.</param>
        /// <param name="escapeChar">Escape character to use for escaping table names etc.</param>
        public SqlDeleteBuilder(Node node, ISignaler signaler, string escapeChar)
            : base(node, signaler, escapeChar)
        { }

        /// <summary>
        /// Builds your delete SQL statement, and returns a structured SQL statement, plus any parameters.
        /// </summary>
        /// <returns>Node containing insert SQL as root node, and parameters as children.</returns>
        public override Node Build()
        {
            // Return value.
            var result = new Node("sql");
            var builder = new StringBuilder();

            // Building SQL text and parameter collection.
            builder.Append("delete from ");

            // Getting table name from base class.
            GetTableName(builder);

            // Getting [where] clause.
            BuildWhere(result, builder);

            // Returning result to caller.
            result.Value = builder.ToString();
            return result;
        }
    }
}
