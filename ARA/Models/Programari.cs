using System;
using System.Collections.Generic;
using System.Text;
using SQLite;

namespace ARA.Models
{
    public class Programari
    {
        [PrimaryKey, AutoIncrement]
        public int ID { get; set; }
        public string Description { get; set; }
        public DateTime Date { get; set; }
    }
}
