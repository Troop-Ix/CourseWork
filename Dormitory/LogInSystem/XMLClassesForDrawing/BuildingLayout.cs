using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Xml.Serialization;

namespace LogInSystem.XMLClassesForDrawing
{
    [XmlRoot("Building")]
    public class BuildingLayout
    {
        [XmlElement("FloorLayout")]
        public List<FloorLayout> Floors { get; set; }
    }
}
