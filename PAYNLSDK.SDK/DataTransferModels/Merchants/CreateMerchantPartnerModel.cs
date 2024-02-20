using System.Text.Json.Serialization;

namespace PayNlSdk.Sdk.DataTransferModels.Merchants;

public class CreateMerchantPartnerModel
{
    /// <summary>
    ///     Indicate which type of partner agreement you have with us
    /// </summary>
    [JsonPropertyName("connectionType")]
    public string? ConnectionType { get; set; }

    /// <summary>
    ///     Indicate under which package you want to create a merchant. You can retrieve a list of available package by calling
    ///     Packages API endpoint (see: https://developer.pay.nl/reference/get_packages )
    /// </summary>
    [JsonPropertyName("referralProfileCode")]
    public string? ReferralProfileCode { get; set; }

    /// <summary>
    ///     Indicate if you want to have access to the merchant. Only applicable for connectionType BP and ISO. An alliance
    ///     always have access to their submerchants.
    /// </summary>
    [JsonPropertyName("accessToMerchant")]
    public bool? AccessToMerchant { get; set; }
}