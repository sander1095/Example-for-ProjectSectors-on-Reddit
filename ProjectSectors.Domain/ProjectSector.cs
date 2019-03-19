using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;

namespace ProjectSectors.Domain
{
    public class ProjectSector

    {

        [Key, Required]

        [Column(Order = 1)]

        public int ProjectID { get; set; }

        [Key, Required]

        [Column(Order = 2)]

        public int SectorID { get; set; }

        public virtual Project Project { get; set; }

        public virtual Sector Sector { get; set; }

    }
}