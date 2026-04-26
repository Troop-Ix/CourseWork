using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Xml.Serialization;

namespace LogInSystem.XMLClassesForDrawing
{
    public class RoomLayout
    {
        [XmlAttribute] public int RoomID { get; set; }
        [XmlAttribute] public int X { get; set; }
        [XmlAttribute] public int Y { get; set; }
        [XmlAttribute] public int Width { get; set; }
        [XmlAttribute] public int Height { get; set; }
    }
}
