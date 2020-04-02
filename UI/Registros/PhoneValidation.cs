using System;
using System.Collections.Generic;
using System.Text;
using System.Windows.Controls;
using System.Globalization;
using System.Text.RegularExpressions;

namespace ProyectoFinal_PA1.UI.Registros
{
    public class PhoneValidation : ValidationRule
    {
        public override ValidationResult Validate(object value, CultureInfo cultureInfo)
        {
            
            string phone = value as string;
            try
            {
                if (phone != null)
                {
                   
                    if (Regex.Match(phone, @"^([\+]?1[-]?|[0])?[1-9][0-9]{9}$").Success)
                    {

                        return ValidationResult.ValidResult;
                    }
                    else
                    {
                        return new ValidationResult(false, Message);
                    }
                }
                return new ValidationResult(false, Message);
            }
            catch (Exception e)
            {
                return new ValidationResult(false, $"Introduzca un email correcto or {e.Message}");
            }
        }
        public string Message { get; set; }
    }
}
