using System;
using System.Collections.Generic;
using System.Text;
using SQLite;

namespace VodokanalMobile
{
    [Table ("Status")]
    public class Status
    {
        [PrimaryKey, AutoIncrement, Column("Id_status")]
        public int Id_status { get; set; }
        public string Name_status { get; set; }
    }
}
