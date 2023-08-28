namespace SC.VersionManagement.Enum
{
    public enum EnumObjectType
    {
        Supplier = 1,
        Products = 2,
        Service = 3,
        GroupService = 4,
        Distributor = 5,
        Customner = 6,
        Vehicle = 7,
        Driver = 8,
        Route = 9,
        Schedule = 10,
        Orders = 11,
        PlaceOrEvent = 12,
        TicketSummary = 13,
        Ticket = 14,
        Member = 15,
        Booking = 16
    }

    public enum EnumEnviroment
    {
        None = 0,
        Alpha = 1,
        Beta = 2,
        Product = 3
    }

    public class EnumVision
    {
        public static string VI = "vi";
        public static string EN = "en";
    }

    public enum EnumGroupServiceType
    {
        Single = 1,
        Combo = 2
    }

    #region Product Status
    public static class EnumProductStatus
    {
        public static int Available = 1;
        public static int Planning = 2;
        public static int CurrentlyOutOfStock = 3;
        public static int SetOutOfStock = 4;
    }
    #endregion
}
