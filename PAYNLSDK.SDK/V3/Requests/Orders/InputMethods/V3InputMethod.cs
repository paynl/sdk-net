using System.Text.Json.Serialization;

namespace PayNlSdk.Sdk.V3.Requests.Orders.InputMethods;

[JsonDerivedType(typeof(DirectDebitInput))]
[JsonDerivedType(typeof(IdealInput))]
[JsonDerivedType(typeof(KlarnaInput))]
[JsonDerivedType(typeof(PayByBankInput))]
[JsonDerivedType(typeof(PinInput))]
[JsonDerivedType(typeof(Przelewy27Input))]
[JsonDerivedType(typeof(SprayPayInput))]
public abstract class V3InputMethod
{

}
