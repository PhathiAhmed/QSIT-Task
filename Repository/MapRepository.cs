using Microsoft.EntityFrameworkCore;
using QSIT.Models;

namespace QSIT.Repository
{
    public interface Imap 
    {
        void Save(Map map);
        List<Map> GetMaps();
        Map MapGetID(int id);
        void Edit(Map map);
        void Delete(int id);
    }
    public class MapRepository:Imap
    {
        QsitDBContext db;
        public MapRepository(QsitDBContext db)
        {
            this.db = db;
        }
        public List<Map>  GetMaps() 
        {
            var maps = db.Maps.Include(m => m.MapType).Include(m => m.MapSubType).ToList();
            return maps;
        }
        public Map MapGetID(int id) 
        {
            var map = db.Maps.Include(m => m.MapType).Include(m => m.MapSubType).SingleOrDefault(m => m.Id == id);
            return map;
        }
        public void Save(Map map) 
        {
            db.Maps.Add(map);
            db.SaveChanges();
        }
        public void Edit(Map map) 
        {
            db.Maps.Update(map);
            db.SaveChanges();
        }
        
        public void Delete(int id) 
        {
            Map map = MapGetID(id);
            db.Maps.Remove(map);
            db.SaveChanges();
        }

    }
}
