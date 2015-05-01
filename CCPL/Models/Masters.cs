using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.Mvc;

namespace CCPL.Models
{
    public class Masters
    {
        public Stock StockDropDowns()
        {
            List<Vendor_master> list1 = new List<Vendor_master>();
            List<Instrument_master> list2 = new List<Instrument_master>();
            List<Book_size> list3 = new List<Book_size>();
            using (NSDLEntities db = new NSDLEntities())
            {
                list1 = db.Vendor_master.ToList();
                list2 = db.Instrument_master.ToList();
                list3 = db.Book_size.ToList();
            }
            Stock model = new Stock
            {
                VenodorList = new SelectList(list1, "vm_cd", "vm_name"),
                instrumentCodeList = new SelectList(list2, "im_instcd", "im_desc"),
                BookSizeList = new SelectList(list3, "bk_size", "bk_size")
            };
            return model;
        }

    }
    


}