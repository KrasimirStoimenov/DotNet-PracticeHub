namespace CarRentalSystem.Domain.Models.CarAds;

using CarRentalSystem.Domain.Common;

public class TransmissionType : Enumeration
{
    public static readonly TransmissionType Manual = new(value: 1, name: nameof(Manual));
    public static readonly TransmissionType Automatic = new(value: 2, name: nameof(Automatic));

    private TransmissionType(int value)
        : this(value, FromValue<TransmissionType>(value).Name)
    {
    }

    private TransmissionType(int value, string name)
        : base(value, name)
    {
    }
}
