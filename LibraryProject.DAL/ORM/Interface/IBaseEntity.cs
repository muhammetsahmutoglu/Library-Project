using LibraryProject.DAL.ORM.Enum;
using System;
using System.Collections.Generic;
using System.Text;

namespace LibraryProject.DAL.ORM.Interface
{
    public interface IBaseEntity
    {
         int ID { get; set; }
         DateTime AddDate { get; set; }
         DateTime UpdateDate { get; set; }
         DateTime DeleteDate { get; set; }
         Status Status { get; set; }
    }
}
