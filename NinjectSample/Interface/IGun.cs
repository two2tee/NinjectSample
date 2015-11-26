namespace NinjectSample.Interface
{
    /// <summary>
    ///     Interface representing actions of a simple gun.
    /// </summary>
    public interface IGun
    {
        string Fire();
        string Reload();
        string ShowAmmo();
        string GetName();
    }
}