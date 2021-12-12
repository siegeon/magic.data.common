﻿/*
 * Magic Cloud, copyright Aista, Ltd. See the attached LICENSE file for details.
 */

using System.Linq;
using magic.node;
using magic.signals.contracts;
using magic.data.common.builders;

namespace magic.data.common.slots.sql
{
    /// <summary>
    /// [mssql.read] slot for selecting rows from some table.
    /// </summary>
    [Slot(Name = "sql.read")]
    public class Read : ISlot
    {
        /// <summary>
        /// Implementation of your slot.
        /// </summary>
        /// <param name="signaler">Signaler used to raise the signal.</param>
        /// <param name="input">Arguments to your slot.</param>
        public void Signal(ISignaler signaler, Node input)
        {
            var builder = new SqlReadBuilder(input, "'");
            var result = builder.Build();
            input.Value = result.Value;
            input.Clear();
            input.AddRange(result.Children.ToList());
        }
    }
}
