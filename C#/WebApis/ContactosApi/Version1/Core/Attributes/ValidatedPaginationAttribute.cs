using Microsoft.AspNetCore.Mvc;
using Microsoft.AspNetCore.Mvc.Filters;
using System.Text.RegularExpressions;

namespace ContactosApi.Core.Attributes
{
    [AttributeUsage(AttributeTargets.Method)]
    public class ValidatedPaginationAttribute : ActionFilterAttribute
    {
        public override void OnActionExecuting(ActionExecutingContext context)
        {
            var httpContext = context.HttpContext;
            var query = httpContext.Request.Query;

            // Validar parámetro 'pagina'
            if (query.ContainsKey("pagina"))
            {
                var paginaValue = query["pagina"].ToString();
                
                if (!int.TryParse(paginaValue, out int pagina))
                {
                    context.Result = new BadRequestObjectResult(new
                    {
                        message = "Datos de entrada inválidos",
                        details = "El parámetro 'pagina' debe ser un número válido",
                        timestamp = DateTime.UtcNow
                    });
                    return;
                }

                if (pagina <= 0)
                {
                    context.Result = new BadRequestObjectResult(new
                    {
                        message = "Datos de entrada inválidos",
                        details = "El parámetro 'pagina' debe ser un número positivo mayor a 0",
                        timestamp = DateTime.UtcNow
                    });
                    return;
                }

                if (!Regex.IsMatch(paginaValue, @"^[0-9]+$"))
                {
                    context.Result = new BadRequestObjectResult(new
                    {
                        message = "Datos de entrada inválidos",
                        details = "El parámetro 'pagina' solo puede contener números positivos",
                        timestamp = DateTime.UtcNow
                    });
                    return;
                }
            }

            // Validar parámetro 'registrosPorPagina'
            if (query.ContainsKey("registrosPorPagina"))
            {
                var registrosValue = query["registrosPorPagina"].ToString();
                
                if (!int.TryParse(registrosValue, out int registros))
                {
                    context.Result = new BadRequestObjectResult(new
                    {
                        message = "Datos de entrada inválidos",
                        details = "El parámetro 'registrosPorPagina' debe ser un número válido",
                        timestamp = DateTime.UtcNow
                    });
                    return;
                }

                if (registros <= 0 || registros > 50)
                {
                    context.Result = new BadRequestObjectResult(new
                    {
                        message = "Datos de entrada inválidos",
                        details = "El parámetro 'registrosPorPagina' debe estar entre 1 y 50",
                        timestamp = DateTime.UtcNow
                    });
                    return;
                }

                if (!Regex.IsMatch(registrosValue, @"^[0-9]+$"))
                {
                    context.Result = new BadRequestObjectResult(new
                    {
                        message = "Datos de entrada inválidos",
                        details = "El parámetro 'registrosPorPagina' solo puede contener números positivos",
                        timestamp = DateTime.UtcNow
                    });
                    return;
                }
            }

            base.OnActionExecuting(context);
        }
    }
} 