namespace GIBDotNet.Options
{
    public static class GIBOptions
    {
        private static bool _isProduction = false;

        public static bool IsProduction
        {
            get => _isProduction;
        }

        public static void EnableProductionMode()
        {
            _isProduction = true;
        }

        public static void EnableTestMode()
        {
            _isProduction = false;
        }
    }
}