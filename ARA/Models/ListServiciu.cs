using System;
using System.Collections.Generic;
using System.Text;
using SQLite;
using SQLiteNetExtensions.Attributes;

namespace ARA.Models
{
    public class ListServiciu
    {
        [PrimaryKey, AutoIncrement]
        public int ID { get; set; }
        [ForeignKey(typeof(Programari))]
        public int ShopListID { get; set; }
        public int ProductID { get; set; }
    }
}
