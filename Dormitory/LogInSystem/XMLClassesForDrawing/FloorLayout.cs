using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Xml.Serialization;

namespace LogInSystem.XMLClassesForDrawing
{
    public class FloorLayout
    {
        [XmlAttribute("Number")]
        public int Number { get; set; }
        [XmlElement("Room")]
        public List<RoomLayout> Rooms { get; set; } = new List<RoomLayout>();
    }
}
