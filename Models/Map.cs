using Microsoft.EntityFrameworkCore.Storage;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;

namespace QSIT.Models
{
    public class Map
    {
        

        public int Id { get; set; }
        public bool Geo_Fencing { get; set; }
        public double Raduis { get; set; }
        public double Location{ get; set; }
        public int Time { get; set; }
        public int Duration { get; set; }

        [ForeignKey("MapType")]
        public int MapTypeId { get; set; }
        public Map_Type MapType { get; set; }


        [ForeignKey("MapSubType")]
        public int MapSubTypeId { get; set; }
        public Map_Sub_Type MapSubType { get;set; }
    }
}
