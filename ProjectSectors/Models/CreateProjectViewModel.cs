using ProjectSectors.Domain;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace ProjectSectors.Models
{
    public class CreateProjectViewModel
    {
        public string Title { get; set; }
        public string Description { get; set; }
        public IList<SectorViewModel> Sectors { get; set; }
    }
}
