namespace ContactosApi.Core.DTOs
{
    public class PaginatedResponseDto<T>
    {
        public IEnumerable<T> Data { get; set; } = new List<T>();
        public int TotalRegistros { get; set; }
        public int TotalPaginas { get; set; }
        public int PaginaActual { get; set; }
        public int RegistrosPorPagina { get; set; }
        public int RegistrosEnPaginaActual { get; set; }
        public int? PaginaAnterior { get; set; }
        public int? PaginaSiguiente { get; set; }
        public bool TienePaginaAnterior => PaginaAnterior.HasValue;
        public bool TienePaginaSiguiente => PaginaSiguiente.HasValue;
    }
} 