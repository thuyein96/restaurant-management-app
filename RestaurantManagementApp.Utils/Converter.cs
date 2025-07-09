namespace RestaurantManagementApp.Utils;

public static class Converter
{
    public static TimeOnly ToTime(this string timestring)
    {
        return TimeOnly.Parse(timestring);
    }

    public static DateOnly ToDate(this string datestring)
    {
        return DateOnly.Parse(datestring);
    }

    public static string ReservationNumberGenerator()
    {
        return DateTime.UtcNow.ToString("yyyyMMddHHmm");
    }
}