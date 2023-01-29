using System.ComponentModel.DataAnnotations.Schema;

namespace QSIT.Models
{
    public class Map_Sub_Type
    {
        public int Id { get; set; }
        public string Name { get; set; }

        public int MapTypeId { get; set; }
    }
}
