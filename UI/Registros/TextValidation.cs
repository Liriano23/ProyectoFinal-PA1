using System;
using System.Collections.Generic;
using System.Text;
using System.Windows.Controls;
using System.Globalization;
namespace ProyectoFinal_PA1.UI.Registros
{
    public class TextValidation : ValidationRule
    {
        public override ValidationResult Validate(object value, CultureInfo cultureInfo)
        {
            string str = value as string;

            if (str != null)
            {
                if (str.Length > 0)
                {
                    return ValidationResult.ValidResult;
                }
            }
            return new ValidationResult(false, Message);
        }
        public string Message { get; set; }
    }
}
