namespace TravelaFinalApp.Application.Extensions
{
    public static class ValidatorExtension
    {
        public static bool NotContainOnlyNumbers(string str)
        {
            return !int.TryParse(str, out _);
        }
    }
}
