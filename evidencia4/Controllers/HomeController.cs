using evidencia4.Models;
using Microsoft.AspNetCore.Mvc;
using System.Data;
using System.Data.SqlClient;
using System.Diagnostics;

namespace evidencia4.Controllers
{
    public class HomeController : Controller
    {
        public List<DataModel> list = new List<DataModel>();
        private readonly ILogger<HomeController> _logger;

        public HomeController(ILogger<HomeController> logger)
        {
            _logger = logger;
        }

       
        public IActionResult Index()
        {
            string conn = "Data Source=ASUS_POWER; Initial Catalog=FUZETEA; Integrated Security=True;";
            using (SqlConnection conection = new SqlConnection(conn))
            {
                conection.Open();
                string query = "SELECT * FROM FuzeTea";
                using (SqlCommand cmd = new(query, conection))
                {
                    SqlDataReader reader = cmd.ExecuteReader();
                    while (reader.Read())
                    {
                        DataModel m = new DataModel 
                        {
                            Id = reader.GetInt32("Id"),
                            Nombre = reader.GetString("Nombre"),
                            Descripcion = reader.GetString("Descripcion"),
                            Caracteristica = reader.GetString("Caracteristica"),
                            Image = reader.GetString("Image"),
                        };
                        list.Add(m);

                    }
                }
                }

                return View(list);
            }
        

        public IActionResult Privacy()
        {
            return View();
        }

        [ResponseCache(Duration = 0, Location = ResponseCacheLocation.None, NoStore = true)]
        public IActionResult Error()
        {
            return View(new ErrorViewModel { RequestId = Activity.Current?.Id ?? HttpContext.TraceIdentifier });
        }


        public class DataModel
        {
            public int Id;
            public required string Nombre;
            public required string Descripcion;
            public required string Caracteristica;
            public required string Image; 
        }
    }
}
