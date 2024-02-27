namespace WebAPI_Employee.Enums;
using System.Text.Json.Serialization;

[JsonConverter(typeof(JsonStringEnumConverter))]
public enum ShiftEnum
{
    Manha,
    Tarde,
    Noite
}
