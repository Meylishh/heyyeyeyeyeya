namespace stuff.IVehicles
{
    public interface IUnderwater: IWaterborne
    {
        bool IsUnderWater { get; }
    }
}