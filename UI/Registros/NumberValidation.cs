using System;
using System.Collections.Generic;
using System.Text;
using System.Windows.Controls;
using System.Globalization;

namespace ProyectoFinal_PA1.UI.Registros
{
    public class NumberValidation : ValidationRule
    {
        public override ValidationResult Validate(object value, CultureInfo cultureInfo)
        {

            if (value != null)
            {
                try
                {
                    int number = 0;
                    number = Convert.ToInt32(value);
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
