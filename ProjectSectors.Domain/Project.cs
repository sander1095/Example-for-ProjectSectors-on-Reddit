using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;

namespace ProjectSectors.Domain
{
    public class Project

    {

        [Key, Required]

        public int ProjectID { get; set; }

        [Required]

        public string Title { get; set; }

        public string Description { get; set; }

        public System.DateTime Date_Proposal { get; set; }

        public int Up_Votes { get; set; }

        public int Down_Votes { get; set; }

        public virtual List<ProjectSector> ProjectSectors { get; set; }

        public Project(string title, string description)
        {
            Title = title;
            Description = description;
        }

    }
}
