using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace DormitoryObjects.Repositories
{
    public interface IRoomAdvancedRepository : IRepository<Room>
    {
        Task<IEnumerable<Room>> FilterRoomByOccupancy(int roomsCount);
        Task<IEnumerable<Room>> GetEmptyRooms();
        Task<IEnumerable<Room>> GetFullRooms();
        Task<IEnumerable<Room>> GetPartlyOccupiedRooms();
    }
}
