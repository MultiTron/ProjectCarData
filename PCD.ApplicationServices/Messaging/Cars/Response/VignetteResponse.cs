using Newtonsoft.Json;

namespace PCD.ApplicationServices.Messaging.Cars.Response;

public class VignetteResponse
{
    [JsonProperty("vignette")]
    public Vignette Vignette { get; set; }

    [JsonProperty("ok")]
    public bool Ok { get; set; }

    [JsonProperty("status")]
    public Status Status { get; set; }
}

public class Status
{
    [JsonProperty("code")]
    public int Code { get; set; }

    [JsonProperty("message")]
    public string Message { get; set; }
}

public class Vignette
{
    [JsonProperty("licensePlateNumber")]
    public string LicensePlateNumber { get; set; }

    [JsonProperty("country")]
    public string Country { get; set; }

    [JsonProperty("exempt")]
    public bool Exempt { get; set; }

    [JsonProperty("vignetteNumber")]
    public string VignetteNumber { get; set; }

    [JsonProperty("vehicleClass")]
    public string VehicleClass { get; set; }

    [JsonProperty("emissionsClass")]
    public string EmissionsClass { get; set; }

    [JsonProperty("validityDateFromFormated")]
    public string ValidityDateFromFormated { get; set; }

    [JsonProperty("validityDateFrom")]
    public DateTime ValidityDateFrom { get; set; }

    [JsonProperty("validityDateToFormated")]
    public string ValidityDateToFormated { get; set; }

    [JsonProperty("validityDateTo")]
    public DateTime ValidityDateTo { get; set; }

    [JsonProperty("issueDateFormated")]
    public string IssueDateFormated { get; set; }

    [JsonProperty("issueDate")]
    public DateTime IssueDate { get; set; }

    [JsonProperty("price")]
    public int Price { get; set; }

    [JsonProperty("currency")]
    public string Currency { get; set; }

    [JsonProperty("status")]
    public string Status { get; set; }

    [JsonProperty("vehicleClassCode")]
    public string VehicleClassCode { get; set; }

    [JsonProperty("emissionsClassCode")]
    public string EmissionsClassCode { get; set; }

    [JsonProperty("whitelist")]
    public bool Whitelist { get; set; }

    [JsonProperty("vehicleType")]
    public string VehicleType { get; set; }

    [JsonProperty("vehicleTypeCode")]
    public string VehicleTypeCode { get; set; }

    [JsonProperty("statusBoolean")]
    public bool StatusBoolean { get; set; }
}
