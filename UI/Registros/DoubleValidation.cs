using System;
using System.Collections.Generic;
using System.Text;
using System.Windows.Controls;
using System.Globalization;

namespace ProyectoFinal_PA1.UI.Registros
{
    public class DoubleValidation : ValidationRule
    {
        public override ValidationResult Validate(object value, CultureInfo cultureInfo)
        {

            if (value != null)
            {
                try
                {
                    double number = 0;
                    number = Convert.ToDouble(value);
                    return ValidationResult.ValidResult;
                }
                catch (Exception e)
                {

                    return new ValidationResult(false, $"Caracter incorrecto or {e.Message}");
                }
            }
            return new ValidationResult(false, $"Caracter incorrecto");
        }
    }
}
