namespace CityUtilities.PointOfSaleSystem.Core
{
    public enum AisleEnum
    {
        A = 1,
        B = 2,
        C = 3,
        D = 4,
        E = 5,
        F = 6,
        G = 7
    }

    public class Aisle
    {
        public AisleEnum Id { get; set; }
        public string Title {  get; set; }
    }
}
