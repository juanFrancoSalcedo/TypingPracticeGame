using System.Collections.Generic;

public static class Constants
{
    public static class GameSettings 
    {
        public const int MinAmountPlayersToBegin = 10;
    }
    public static class KeyResources
    {
        public const string PrototypePath = "Prototypes";
    }

    public static class KeyRooms
    {
        private static readonly string defaultRoomName = "Room INS ";
        public static readonly List<string> namesRooms = new List<string>
            {
                defaultRoomName+"1",
                defaultRoomName+"2",
                defaultRoomName+"3",
                defaultRoomName+"4"
            };
    }

    public static class ChatVariables 
    {
        public const string Chanel_Room_One = "ROOM_ONE";
        public const string Chanel_Room_Two = "ROOM_TWO";
        public const string Chanel_Room_Three = "ROOM_THREE";
        public const string Chanel_Room_Four = "ROOM_FOUR";
    }

    public static class KeyCharacters
    {
        public static readonly int[] Managers_keys = new[] { 4, 6 };
        public static readonly int[] Epidemic_keys = new[] { 10,2,5,8,11,12};
    }
}