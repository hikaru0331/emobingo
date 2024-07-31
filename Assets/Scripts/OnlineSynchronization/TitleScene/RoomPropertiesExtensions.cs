using ExitGames.Client.Photon;
using Photon.Realtime;

    public static class RoomPropertiesExtensions
    {
        private const string PrizesKey = "Prizes";
        private static readonly Hashtable propsToSet = new Hashtable();

        public static void SetPrizesMaximun(this Room room, int prizes)
        {
            propsToSet[PrizesKey] = prizes;
            room.SetCustomProperties(propsToSet);
            propsToSet.Clear();
        }

        public static int GetPrizesMaximun(this Room room)
        {
            return (room.CustomProperties[PrizesKey] is int prizes) ? prizes : 404;
        }
    }