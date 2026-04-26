using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Xml.Serialization;

namespace LogInSystem.XMLClassesForDrawing
{
    public class LayoutManager
    {
        private BuildingLayout _fullBuilding;

        public void LoadAll(string filePath)
        {
            XmlSerializer serializer = new XmlSerializer(typeof(BuildingLayout));
            using (var reader = new System.IO.StreamReader(filePath))
            {
                _fullBuilding = (BuildingLayout)serializer.Deserialize(reader);
            }
        }

        public FloorLayout GetRoomsForFloor(int floorNumber)
        {
            if (_fullBuilding == null || _fullBuilding.Floors == null)
            {
                return new FloorLayout();
            }

            return _fullBuilding.Floors.FirstOrDefault(f => f.Number == floorNumber) ?? new FloorLayout();
        }
    }
}
