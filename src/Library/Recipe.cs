//-------------------------------------------------------------------------
// <copyright file="Recipe.cs" company="Universidad Católica del Uruguay">
// Copyright (c) Programación II. Derechos reservados.
// </copyright>
//-------------------------------------------------------------------------

using System;
using System.Collections;

namespace Full_GRASP_And_SOLID.Library
{
    public class Recipe
    {
        private ArrayList steps = new ArrayList();

        public Product FinalProduct { get; set; }

        public void AddStep(Step step)
        {
            this.steps.Add(step);
        }

        public void RemoveStep(Step step)
        {
            this.steps.Remove(step);
        }

        public void PrintRecipe()
        {
            Console.WriteLine($"Receta de {this.FinalProduct.Description}:");
            foreach (Step step in this.steps)
            {
                Console.WriteLine($"{step.Quantity} de '{step.Input.Description}' " +
                    $"usando '{step.Equipment.Description}' durante {step.Time}");
            }
            double finalCost= this.GetProductionCost();
            Console.WriteLine($"Costo total: {finalCost}");
        }

        /* cree el metodo GetProductionCost para calcular el total de los subtotales de todos los renglones, tambien por expert
        ya que Recipe es la clase que conoce todos los renglones */
        public double GetProductionCost()
        {
            double total = 0;
            foreach (Step step in this.steps)
            {
                double subTotal = Step.subTotal(step.Input,step.Equipment,step.Time);
                total = total + subTotal;
            } 
            return total;
        }  
    }
}