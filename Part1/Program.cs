
using System;
using System.Collections.Generic;

    namespace RecipeProgram
    {
        class Program
        {
            static void Main(string[] args)
            {
                List<Ingredient> ingredients = new List<Ingredient>();
                List<string> steps = new List<string>();

                Console.WriteLine("Welcome to the Recipe Program!");

                bool exit = false;
                while (!exit)
                {
                    Console.WriteLine("\nPlease select an option:");
                    Console.WriteLine("1. Enter a new recipe");
                    Console.WriteLine("2. Scale the recipe");
                    Console.WriteLine("3. Reset the recipe");
                    Console.WriteLine("4. Clear all data");
                    Console.WriteLine("5. Exit");

                    int choice = int.Parse(Console.ReadLine());

                    switch (choice)
                    {
                        case 1:
                            Console.WriteLine("\nEnter the number of ingredients:");
                            int numIngredients = int.Parse(Console.ReadLine());

                            for (int i = 0; i < numIngredients; i++)
                            {
                                Console.WriteLine($"\nIngredient {i + 1}");
                                Console.Write("Name: ");
                                string name = Console.ReadLine();
                                Console.Write("Quantity: ");
                                double quantity = double.Parse(Console.ReadLine());
                                Console.Write("Unit of measurement: ");
                                string unit = Console.ReadLine();

                                Ingredient ingredient = new Ingredient(name, quantity, unit);
                                ingredients.Add(ingredient);
                            }

                            Console.WriteLine("\nEnter the number of steps:");
                            int numSteps = int.Parse(Console.ReadLine());

                            for (int i = 0; i < numSteps; i++)
                            {
                                Console.WriteLine($"\nStep {i + 1}");
                                Console.Write("Description: ");
                                string description = Console.ReadLine();

                                steps.Add(description);
                            }

                            Console.WriteLine("\nRecipe added successfully!");
                            break;

                        case 2:
                            Console.WriteLine("\nPlease select a scaling factor:");
                            Console.WriteLine("1. Half");
                            Console.WriteLine("2. Double");
                            Console.WriteLine("3. Triple");

                            int factor = int.Parse(Console.ReadLine());

                            foreach (Ingredient ingredient in ingredients)
                            {
                                if (factor == 1)
                                {
                                    ingredient.Scale(0.5);
                                }
                                else if (factor == 2)
                                {
                                    ingredient.Scale(2);
                                }
                                else if (factor == 3)
                                {
                                    ingredient.Scale(3);
                                }
                            }

                            Console.WriteLine("\nRecipe scaled successfully!");
                            break;

                        case 3:
                            foreach (Ingredient ingredient in ingredients)
                            {
                                ingredient.Reset();
                            }

                            Console.WriteLine("\nRecipe reset successfully!");
                            break;

                        case 4:
                            ingredients.Clear();
                            steps.Clear();

                            Console.WriteLine("\nAll data cleared successfully!");
                            break;

                        case 5:
                            exit = true;
                            Console.WriteLine("\nThank you for using the Recipe Program!");
                            break;

                        default:
                            Console.WriteLine("\nInvalid choice. Please try again.");
                            break;
                    }

                    if (ingredients.Count > 0 && steps.Count > 0)
                    {
                        Console.WriteLine("\nRecipe:");
                        foreach (Ingredient ingredient in ingredients)
                        {
                            Console.WriteLine($"{ingredient.Quantity} {ingredient.Unit} {ingredient.Name}");
                        }

                        Console.WriteLine("\nSteps:");
                        for (int i = 0; i < steps.Count; i++)
                        {
                            Console.WriteLine($"{i + 1}. {steps[i]}");
                        }
                    }
                }
            }
        }

        class Ingredient
        {
            public string Name { get; set; }
            public double Quantity { get; set; }
            public string Unit { get; set; }
            private double originalQuantity;

            public Ingredient(string name, double quantity, string unit)
            {
                Name = name;
                Quantity = quantity;
                Unit = unit;
                originalQuantity = quantity;
            }

            public void Scale(double factor)
            {
                Quantity = originalQuantity * factor;
            }

            public void Reset()
            {
                Quantity = originalQuantity;
            }
        }
    }
}