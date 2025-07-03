using System.ComponentModel.DataAnnotations;

namespace ContactosApi.Core.DTOs
{
    public class PaginationParamsDto
    {
        private int _pagina = 1;
        private int _registrosPorPagina = 10;
        private const int MaxRegistrosPorPagina = 50;

        [Range(1, int.MaxValue, ErrorMessage = "La página debe ser un número positivo mayor a 0")]
        [RegularExpression(@"^[0-9]+$", ErrorMessage = "La página solo puede contener números positivos")]
        public int Pagina
        {
            get => _pagina;
            set => _pagina = value < 1 ? 1 : value;
        }

        [Range(1, 50, ErrorMessage = "Los registros por página deben estar entre 1 y 50")]
        [RegularExpression(@"^[0-9]+$", ErrorMessage = "Los registros por página solo pueden contener números positivos")]
        public int RegistrosPorPagina
        {
            get => _registrosPorPagina;
            set => _registrosPorPagina = value > MaxRegistrosPorPagina ? MaxRegistrosPorPagina : value < 1 ? 1 : value;
        }
    }
} 