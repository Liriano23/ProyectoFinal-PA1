using System;
using System.Collections.Generic;
using System.Text;
using System.Windows.Controls;
using System.Globalization;
using System.Text.RegularExpressions;

namespace ProyectoFinal_PA1.UI.Registros
{
    public class EmailValidation : ValidationRule
    {
        public override ValidationResult Validate(object value, CultureInfo cultureInfo)
        {
            string expresion;
            string email = value as string;
            try
            {
                if (email != null)
                {
                    expresion = "\\w+([-+.']\\w+)*@\\w+([-.]\\w+)*\\.\\w+([-.]\\w+)*";
                    if (Regex.IsMatch(email, expresion))
                    {
                        if (Regex.Replace(email, expresion, String.Empty).Length == 0)
                        {
                            return ValidationResult.ValidResult;
                        }
                        else
                        {
                            return new ValidationResult(false, Message);
                        }
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
