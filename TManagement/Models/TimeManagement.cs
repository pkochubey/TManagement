using System;
using System.Collections.Generic;
using System.Xml.Serialization;

namespace TManagement.Models
{
    [Serializable]
    public class TimeManagement
    {
        [XmlElement("Project")]
        public List<Project> Projects { get; set; }
    }

    public class Project
    {
        [XmlAttribute("name")]
        public string Name { get; set; }

        [XmlElement("TimeInterval")]
        public List<TimeInterval> TimeIntervals { get; set; }

        public override string ToString()
        {
            return Name;
        }
    }

    public class TimeInterval
    {
        [XmlAttribute("start")]
        public string StartDate { get; set; }

        [XmlAttribute("end")]
        public string EndDate { get; set; }

        [XmlAttribute("buy")]
        public int Buy { get; set; }
    }
}