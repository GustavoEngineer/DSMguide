namespace CarteleraApi.Domain.Entities
{
    /// <summary>
    /// Esta es nuestra entidad Película - es como el "molde" que define
    /// qué información debe tener cada película en nuestro sistema
    /// </summary>
    public class Pelicula
    {
        // PROPIEDADES - Son como los "campos" de información de una película

        /// <summary>
        /// Id: Es como el "número de serie" único de cada película
        /// Piénsalo como tu CURP - nadie más puede tener el mismo
        /// </summary>
        public int Id { get; set; }

        /// <summary>
        /// NombrePelicula: El título de la película
        /// Ejemplo: "Avengers: Endgame", "El Padrino"
        /// </summary>
        public string NombrePelicula { get; set; } = string.Empty;

        /// <summary>
        /// Trama: Un resumen de qué trata la película
        /// Como la descripción que ves en Netflix
        /// </summary>
        public string Trama { get; set; } = string.Empty;

        /// <summary>
        /// Categoria: El género de la película
        /// Ejemplo: "Acción", "Comedia", "Terror", "Drama"
        /// </summary>
        public string Categoria { get; set; } = string.Empty;

        /// <summary>
        /// AnoEmision: El año en que se estrenó la película
        /// Ejemplo: 2019, 2023, 1972
        /// </summary>
        public int AnoEmision { get; set; }

        /// <summary>
        /// Director: Quién dirigió la película
        /// Ejemplo: "Christopher Nolan", "Steven Spielberg"
        /// </summary>
        public string Director { get; set; } = string.Empty;

        /// <summary>
        /// TiempoHoras: Duración de la película en horas decimales
        /// Ejemplo: 2.5 = 2 horas y 30 minutos, 1.75 = 1 hora y 45 minutos
        /// </summary>
        public decimal TiempoHoras { get; set; }

        // CONSTRUCTOR - Es como el "manual de armado" de una película

        /// <summary>
        /// Constructor vacío: Permite crear una película sin datos iniciales
        /// Es como tener un formulario en blanco listo para llenar
        /// </summary>
        public Pelicula()
        {
            // No necesitamos código aquí porque las propiedades ya tienen valores por defecto
        }

        /// <summary>
        /// Constructor con parámetros: Permite crear una película con todos los datos de una vez
        /// Es como llenar todo el formulario de un jalón
        /// </summary>
        public Pelicula(string nombrePelicula, string trama, string categoria,
                    int anoEmision, string director, decimal tiempoHoras)
        {
            NombrePelicula = nombrePelicula;
            Trama = trama;
            Categoria = categoria;
            AnoEmision = anoEmision;
            Director = director;
            TiempoHoras = tiempoHoras;
            // Nota: El Id no se asigna aquí porque lo manejará la base de datos automáticamente
        }

        // MÉTODOS - Son como "funciones especiales" que puede hacer una película

        /// <summary>
        /// ToString: Convierte la película en texto legible
        /// Es como crear una "tarjeta de presentación" de la película
        /// </summary>
        public override string ToString()
        {
            return $"{NombrePelicula} ({AnoEmision}) - Dirigida por {Director} - {TiempoHoras}h";
        }

        /// <summary>
        /// EsPeliculaLarga: Determina si una película es "larga" (más de 2.5 horas)
        /// Es como tener un "detector de películas largas"
        /// </summary>
        public bool EsPeliculaLarga()
        {
            return TiempoHoras > 2.5m; // El 'm' indica que es un decimal
        }

        /// <summary>
        /// EsPeliculaReciente: Determina si una película es "reciente" (últimos 5 años)
        /// </summary>
        public bool EsPeliculaReciente()
        {
            int anoActual = DateTime.Now.Year;
            return (anoActual - AnoEmision) <= 5;
        }
    }
}