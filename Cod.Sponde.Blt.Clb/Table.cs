using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;



namespace Cod.Sponde.Blt.Clb
{
    public class Table : BusinessObject
    {
        public Table()
        {
            Fields = new Field();
            WhenCreated = DateTime.Now;
            WhenModified = WhenCreated;
        }

        public Table(string tableName) : this()
        {
            Name = tableName;
        }

        public Table(string tableName, Field fields)
            : this()
        {
            Name = tableName;
            Fields = fields;
        }

        public string DatabaseName { get; set; }

        public string Name { get; set; }

        public Field Fields { get; set; }

    }
}
