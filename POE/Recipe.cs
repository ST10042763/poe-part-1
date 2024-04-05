using System;

namespace POE {
    /// <summary>
    /// This is the recipe class! WOOHOO!!!
    /// </summary>
    internal class Recipe {
        private readonly string[] ingredients;
        private readonly UnitOfMeasurement[] UoM;
        private readonly string[] convertedUoM;
        private double[] quantity;
        private readonly double[] origionalQuantity;
        private readonly string[] steps;
        /// <summary>
        /// This is the default constructor
        /// </summary>
        /// <param name="ingredients">The array of ingredients</param>
        /// <param name="UoM">Array of unit of measurements</param>
        /// <param name="quantity">Array of quantities</param>
        /// <param name="steps">Array of steps</param>
        public Recipe(string[] ingredients, UnitOfMeasurement[] UoM, double[] quantity, string[] steps) {
            this.ingredients = ingredients;
            this.UoM = UoM;
            this.quantity = quantity;
            this.origionalQuantity = new double[quantity.Length];
            for (int i = 0; i < quantity.Length; i++) {
                this.origionalQuantity[i] = quantity[i];
            }
            this.steps = steps;
            this.convertedUoM = new string[this.ingredients.Length];

            for (int i = 0; i < this.ingredients.Length; i++) {
                this.convertedUoM[i] = this.ConvertNecessary(this.quantity[i], this.UoM[i]);
            }

        }
        /// <summary>
        /// Resets the recipe to its default values
        /// </summary>
        public void ResetRecipe() {
            for (int i = 0; i < this.origionalQuantity.Length; i++) {
                this.quantity[i] = this.origionalQuantity[i];
                this.convertedUoM[i] = this.ConvertNecessary(this.quantity[i], this.UoM[i]);
            }
        }
        /// <summary>
        /// Scales the recipe by N factor
        /// </summary>
        /// <param name="factor">The factor at which to scale the recipe</param>
        public void Scale(double factor) {
            for (int i = 0; i < this.ingredients.Length; i++) {
                this.quantity[i] *= factor;
                this.convertedUoM[i] = this.ConvertNecessary(this.quantity[i], this.UoM[i]);
            }
        }
        /// <summary>
        /// This method returns the recipe as a string
        /// </summary>
        /// <returns>A formatted view of the recipe</returns>
        public override string ToString() {
            string msg = "Ingredients:\n";
            for (int i = 0; i < this.ingredients.Length; i++) {
                msg += $"{this.convertedUoM[i]} of {this.ingredients[i]}\n";
            }
            msg += "\nSteps:\n";
            for (int i = 0; i < this.steps.Length; i++) {
                msg += $"Step {i + 1}: {this.steps[i]}\n";
            }
            return msg;
        }

#pragma warning disable
        /// <summary>
        /// This is a recursive method that scales the units and quantities appropriately
        /// and calls itself until there is no more scaling to be done
        /// </summary>
        /// <param name="qty">The quantities</param>
        /// <param name="UoM">This units of measurement</param>
        /// <returns>The converted quantites as a string for output</returns>
        private string ConvertNecessary(double qty, UnitOfMeasurement UoM) {
            string convUoM = string.Empty;
            bool converted = false;

            switch (UoM) {
                case UnitOfMeasurement.Tsp: {
                    if (qty >= 3) {
                        int n = Convert.ToInt32(Math.Floor(qty / 3));
                        convUoM += $"{n} {(n == 1 ? "tbsp" : "tbsp's")}";
                        convUoM = this.ConvertNecessary(n, UnitOfMeasurement.Tbsp);
                        converted = true;
                    }
                    if (qty % 3 > 1 && converted) {
                        convUoM += $" {this.ConvertNecessary(qty % 3, UnitOfMeasurement.Tsp)}";
                    }
                    break;
                }
                case UnitOfMeasurement.Tbsp: {
                    if (qty >= 16) {
                        int n = Convert.ToInt32(Math.Floor(qty / 16));
                        convUoM += $"{n} {(n == 1 ? "cup" : "cup's")}";
                        convUoM = this.ConvertNecessary(n, UnitOfMeasurement.Cup);
                        converted = true;
                    }
                    if (qty % 16 > 1 && converted) {
                        convUoM += $" {this.ConvertNecessary(qty % 16, UnitOfMeasurement.Tbsp)}";
                    }
                    break;
                }
                case UnitOfMeasurement.G: {
                    if (qty >= 1000) {
                        int n = Convert.ToInt32(Math.Floor(qty / 1000));
                        convUoM += $"{n} {(n == 1 ? "kg" : "kg's")}";
                        converted = true;
                    }
                    if (qty % 1000 > 1 && converted) {
                        convUoM += $" {this.ConvertNecessary(qty % 1000, UnitOfMeasurement.G)}";
                    }
                    break;
                }
                case UnitOfMeasurement.Ml: {
                    if (qty >= 1000 && !converted) {
                        int n = Convert.ToInt32(Math.Floor(qty / 1000));
                        convUoM += $"{n} {(n == 1 ? "l" : "l's")}";
                        converted = true;
                    }
                    if (qty % 1000 > 1 && converted) {
                        convUoM += $" {this.ConvertNecessary(qty % 1000, UnitOfMeasurement.Ml)}";
                    }
                    break;
                }
            }

            if (!converted) {
                return $"{qty} {(qty == 1 ? $"{UoM}" : $"{UoM}'s")}";
            }

            return convUoM;
        }
    }
#pragma warning restore
}