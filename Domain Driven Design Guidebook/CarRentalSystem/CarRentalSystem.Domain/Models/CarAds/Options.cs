namespace CarRentalSystem.Domain.Models.CarAds;

using CarRentalSystem.Domain.Common;
using CarRentalSystem.Domain.Exceptions;

using static ModelConstants.Options;

public class Options : ValueObject
{
    internal Options(bool hasClimateControl, int numberOfSeats, TransmissionType transmissionType)
    {
        this.Validate(numberOfSeats);

        this.HasClimateControl = hasClimateControl;
        this.NumberOfSeats = numberOfSeats;
        this.TransmissionType = transmissionType;
    }

    private Options(bool hasClimateControl, int numberOfSeats)
    {
        this.HasClimateControl = hasClimateControl;
        this.NumberOfSeats = numberOfSeats;

        this.TransmissionType = default!;
    }

    public bool HasClimateControl { get; init; }

    public int NumberOfSeats { get; init; }

    public TransmissionType TransmissionType { get; init; }

    private void Validate(int numberOfSeats)
        => Guard.AgainstOutOfRange<InvalidOptionsException>(
            numberOfSeats,
            MinNumberOfSeats,
            MaxNumberOfSeats,
            nameof(this.NumberOfSeats));
}
