using System.Text.Json.Serialization;

namespace WebAPI_Employee.Enums;

[JsonConverter(typeof(JsonStringEnumConverter))]
public enum DepartmentEnum
{
    RH,
    Financeiro,
    Compras,
    Atendimento,
    Zeladoria
}
