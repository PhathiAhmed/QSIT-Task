using Microsoft.AspNetCore.Mvc;
using QSIT.Repository;
using QSIT.Models;
using QSIT.ViewModels;

namespace QSIT.Controllers
{
    public class MapConfigrationController : Controller
    {
        Imap imap;
        ImapType imaptype;
        IMapSubType imapsubtype;
        public MapConfigrationController(Imap imap , ImapType imaptype , IMapSubType imapsubtype)
        {
            this.imap = imap;
            this.imaptype = imaptype;
            this.imapsubtype = imapsubtype;
        }
        public IActionResult Index()
        {
            var maps = imap.GetMaps();
            return View(maps);
        }
        [HttpGet]
        public IActionResult Save() 
        {
            var viewmodel = new FormViewModel()
            {
                Map_Types = imaptype.GetMap_Types()
            };
            return View(viewmodel);
        }
        public IActionResult GetMapSubType(int maptypeId) 
        {
           var mapsubtypes= imapsubtype.GetMap_Sub_TypeId(maptypeId);
            return Ok(mapsubtypes);
        }
        [HttpPost]
        [ValidateAntiForgeryToken]
        public IActionResult Save(FormViewModel model ) 
        {
            if (ModelState.IsValid == true) 
            {
                var map = new Map()
                {
                    Raduis = model.Raduis,
                    Time = model.Time,
                    Location = model.Location,
                    Duration = model.Duration,
                    MapTypeId = model.MapTypeId,
                    MapSubTypeId = model.MapSupTypeId
                };
                imap.Save(map);
                return RedirectToAction("Index");

            }

            return View(model);

        }
        [HttpGet]
        public IActionResult Edit(int id)
        {
            var maps = imap.MapGetID(id);

            ViewBag.maptypes = imaptype.GetMap_Types();
            ViewBag.mapsuptypes = imapsubtype.GetMap_Sub_TypeId(maps.MapTypeId);
            var item = new FormViewModel()
            {
                Id = maps.Id,
                Raduis = maps.Raduis,
                Location = maps.Location,
                Time = maps.Time,
                Duration = maps.Duration,
                MapTypeId = maps.MapTypeId,
                MapSupTypeId = maps.MapSubTypeId,
                MapName = maps.MapType.Name,
                MapSubTypeName = maps.MapSubType.Name
            };
            return View(item);
        }
        [HttpPost]
        [ValidateAntiForgeryToken]
        public IActionResult Edit(FormViewModel model)
        {
            if (ModelState.IsValid == true) 
            {
                var map = imap.MapGetID(model.Id);

                map.Raduis = model.Raduis;
                map.Location = model.Location;
                map.Time = model.Time;
                map.Duration = model.Duration;
                map.MapTypeId = model.MapTypeId;
                map.MapSubTypeId = model.MapSupTypeId;

                imap.Edit(map);
                return RedirectToAction("Index");
            }
            return View(model);
            
        }

        public IActionResult Delete(int id) 
        {
            imap.Delete(id);
            return RedirectToAction("Index");
        }
    }
}
