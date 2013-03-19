namespace ArctiumConnectionPatcher
{
    enum Offsetsx32 : int
    {
        // Client movement packets
        SendOffset               = 0x448455,
        SendOffset2              = 0x448462,
        SendOffset3              = 0x448472,
        SendOffset4              = 0x44847F,
        // Client packets
        LegacyRoutingTableOffset = 0xACA608,
        // Some server packets
        CommsHandlerOffset       = 0x4479AB,
        // Allow login with email addresses
        emailOffset              = 0x8008E6 
    }
    enum Offsetsx64 : int
    {
        // Client movement packets
        SendOffset               = 0x52561A,
        SendOffset2              = 0x525627,
        SendOffset3              = 0x525636,
        SendOffset4              = 0x525644,
        // Client packets
        LegacyRoutingTableOffset = 0xD046B0,
        // Some server packets
        CommsHandlerOffset       = 0x5247C1,
        // Allow login with email addresses
        emailOffset              = 0x9B30FD 
    }

}
