using Microsoft.AspNetCore.Mvc;
using Microsoft.AspNetCore.Mvc.Filters;
using System.Text.RegularExpressions;

namespace ContactosApi.Core.Attributes
{
    [AttributeUsage(AttributeTargets.Method)]
    public class ValidatedIdAttribute : ActionFilterAttribute
    {
        private readonly string _parameterName;

        public ValidatedIdAttribute(string parameterName = "id")
        {
            _parameterName = parameterName;
        }

        public override void OnActionExecuting(ActionExecutingContext context)
        {
            if (context.ActionArguments.TryGetValue(_parameterName, out var value))
            {
                if (value != null)
                {
                    var stringValue = value.ToString();
                    
                    // Verificar si es un número válido
                    if (!int.TryParse(stringValue, out int id))
                    {
                        context.Result = new BadRequestObjectResult(new
                        {
                            message = "Datos de entrada inválidos",
                            details = $"El parámetro '{_parameterName}' debe ser un número válido",
                            timestamp = DateTime.UtcNow
                        });
                        return;
                    }

                    // Verificar si es positivo
                    if (id <= 0)
                    {
                        context.Result = new BadRequestObjectResult(new
                        {
                            message = "Datos de entrada inválidos",
                            details = $"El parámetro '{_parameterName}' debe ser un número positivo mayor a 0",
                            timestamp = DateTime.UtcNow
                        });
                        return;
                    }

                    // Verificar que solo contenga números
                    if (!Regex.IsMatch(stringValue, @"^[0-9]+$"))
                    {
                        context.Result = new BadRequestObjectResult(new
                        {
                            message = "Datos de entrada inválidos",
                            details = $"El parámetro '{_parameterName}' solo puede contener números positivos",
                            timestamp = DateTime.UtcNow
                        });
                        return;
                    }
                }
            }

            base.OnActionExecuting(context);
        }
    }
} 