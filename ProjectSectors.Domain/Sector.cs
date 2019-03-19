using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.ComponentModel.DataAnnotations;
using System.Text;

namespace ProjectSectors.Domain
{
    public class Sector

    {
        [Key, Required]

        public int SectorID { get; set; }

        [Required]

        [Display(Name = "Sector Title")]

        public string Title { get; set; }

        [DefaultValue("No Description")]

        [Display(Name = "Sector Description")]

        public string Description { get; set; }

        public virtual List<ProjectSector> ProjectSectors { get; set; }

        public Sector(int sectorID, string title)
        {
            SectorID = sectorID;
            Title = title;
        }

    }
}
