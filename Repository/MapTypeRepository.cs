using QSIT.Models;

namespace QSIT.Repository
{
    public interface ImapType 
    {
        List<Map_Type> GetMap_Types();
    }
   
    public class MapTypeRepository:ImapType
    {
        QsitDBContext db;
        public MapTypeRepository(QsitDBContext db)
        {
            this.db = db;
        }
        public List<Map_Type> GetMap_Types() 
        {
            var mapTypes =db.Map_Types.ToList() ;
            return mapTypes ;
        }
    }
}
