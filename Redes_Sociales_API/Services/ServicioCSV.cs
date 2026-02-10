using Redes_Sociales_API.Models;

namespace Redes_Sociales_API.Services
{
    public class ServicioCSV
    {
        public List<PublicacionRedSocial> LeerPublicaciones()
        {
            var ruta = Path.Combine("Data", "redes_sociales_rd_sentimiento.csv");

            return File.ReadAllLines(ruta)
                .Skip(1)
                .Select(linea =>
                {
                    var columnas = linea.Split(',');

                    return new PublicacionRedSocial
                    {
                        Texto = columnas[0],
                        Sentimiento = columnas[1],
                        Fecha = DateTime.Parse(columnas[2]),
                        Plataforma = columnas[3]
                    };
                }).ToList();
        }
    }
}
