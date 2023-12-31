//-------------------------------------------------------------------------------
// <copyright file="Step.cs" company="Universidad Católica del Uruguay">
// Copyright (c) Programación II. Derechos reservados.
// </copyright>
//-------------------------------------------------------------------------------

using System;
using System.Runtime.CompilerServices;

namespace Full_GRASP_And_SOLID.Library
{
    public class Step
    {
        public Step(Product input, double quantity, Equipment equipment, int time)
        {
            this.Quantity = quantity;
            this.Input = input;
            this.Time = time;
            this.Equipment = equipment;
        }

        public Product Input { get; set; }

        public double Quantity { get; set; }

        public int Time { get; set; }

        public Equipment Equipment { get; set; }

        /* le di la responsabilidad de calcular el subtotal a step ya que es quien tiene la informacion
        para calcular el subtotal de cada renglon de la receta (principio expert) */
        public double subTotal()
        {
            double ProductPrice = Input.UnitCost * Quantity;
            double subEquipment = Equipment.HourlyCost * (Time/3600d);
            double subStepTotal = subEquipment + ProductPrice;
            return subStepTotal;
        }
    }

}