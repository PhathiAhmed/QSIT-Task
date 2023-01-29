using QSIT.Models;
namespace QSIT.Repository
{
    public interface IMapSubType
    {
        List<Map_Sub_Type> GetMap_Sub_TypeId(int id);
    }
    public class MapSupTypeRepository:IMapSubType
    {
        QsitDBContext db;
        public MapSupTypeRepository(QsitDBContext db)
        {
            this.db =db;
        }

        public List<Map_Sub_Type> GetMap_Sub_TypeId(int id) 
        {
            var mapsubtype=db.Map_Sub_Types.Where(m=>m.MapTypeId== id).ToList();
            return mapsubtype;
        }
    }
}
