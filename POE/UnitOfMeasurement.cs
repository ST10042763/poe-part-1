namespace POE {
    /// <summary>
    /// This is the standardised unit of measurement
    /// </summary>
    internal enum UnitOfMeasurement {
        None = 0,
        Tsp = 1,
        Tbsp = 2,
        Cup = 3,
        G = 4,
        Kg = 5,
        Ml = 6,
        L = 7
    }
    /// <summary>
    /// This is a static class designed for converting from UoM to initial strings
    /// </summary>
    internal class UoMConversions {
        /// <summary>
        /// Converts from UOM to string without 's'
        /// </summary>
        /// <param name="UoM">The unit of measurement</param>
        /// <returns>The string unit of measurement</returns>
        public static string UoMToNameS(UnitOfMeasurement UoM) {
            switch (UoM) {
                case UnitOfMeasurement.None:
                    return null;
                case UnitOfMeasurement.Tsp:
                    return "tea spoon";
                case UnitOfMeasurement.Tbsp:
                    return "table spoon";
                case UnitOfMeasurement.Cup:
                    return "cup";
                case UnitOfMeasurement.G:
                    return "gram";
                case UnitOfMeasurement.Kg:
                    return "kilogram";
                case UnitOfMeasurement.Ml:
                    return "millilitre";
                case UnitOfMeasurement.L:
                    return "litre";
            }
            return null;
        }
        /// <summary>
        /// Converts from UOM to string with 's'
        /// </summary>
        /// <param name="UoM">The unit of measurement</param>
        /// <returns>The string for it ending in s</returns>
        public static string UoMToNameM(UnitOfMeasurement UoM) {
            switch (UoM) {
                case UnitOfMeasurement.None:
                    return null;
                case UnitOfMeasurement.Tsp:
                    return "tea spoons";
                case UnitOfMeasurement.Tbsp:
                    return "table spoons";
                case UnitOfMeasurement.Cup:
                    return "cups";
                case UnitOfMeasurement.G:
                    return "grams";
                case UnitOfMeasurement.Kg:
                    return "kilograms";
                case UnitOfMeasurement.Ml:
                    return "millilitres";
                case UnitOfMeasurement.L:
                    return "litres";
            }
            return null;
        }
    }
}