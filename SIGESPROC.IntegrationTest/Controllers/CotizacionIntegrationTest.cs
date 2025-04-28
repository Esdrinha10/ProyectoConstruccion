using Microsoft.VisualStudio.TestTools.UnitTesting;
using SIGESPROC.IntegrationTest.Mocks;
using SIGESPROC.IntegrationTests;
using SIGESPROC.IntegrationTests.Mocks;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Net.Http;
using System.Text;
using System.Threading.Tasks;

namespace SIGESPROC.IntegrationTest.Controllers
{
    [TestClass]
    public   class CotizacionIntegrationTest  : DbContextMocker
    {
        //Declaramos en una variable la api Key
        private const string ApiKey = "4b567cb1c6b24b51ab55248f8e66e5cc";

        [TestMethod]
        public async Task CotizacionInsertar()
        {
            // Creamos el cliente
            var cliente = factory.CreateClient();

            // Añadimos la apikey al header
            cliente.DefaultRequestHeaders.Add("XApiKey", ApiKey);

            var cotizacionMock = CotizacionesMocks.CrearMockCotizacion();

            // Serializa el objeto a JSON para enviarlo en el cuerpo de la petición
            var contenido = new StringContent(
                System.Text.Json.JsonSerializer.Serialize(cotizacionMock),
                System.Text.Encoding.UTF8,
                "application/json"
            );

            // Realiza la petición a la URL tipo POST
            var response = await cliente.PostAsync("https://localhost:44337/api/Cotizacion/Insertar", contenido);

            // Comprueba si la respuesta no fue exitosa
            if (!response.IsSuccessStatusCode)
            {
                // Lee el contenido de la respuesta para obtener detalles del error
                var errorContent = await response.Content.ReadAsStringAsync();
                Console.WriteLine($"Error: {errorContent}");
                Assert.Fail($"Request failed with status code: {response.StatusCode} - {errorContent}");
            }

            // Aserciones
            Assert.AreEqual(System.Net.HttpStatusCode.OK, response.StatusCode);
            Assert.IsNotNull(response);

            // Lee el contenido de la respuesta 
            var responseContent = await response.Content.ReadAsStringAsync();
            Assert.IsFalse(string.IsNullOrEmpty(responseContent));
        }


        [TestMethod]
        public async Task CotizacionDetalleEditar()
        {
            var cliente = factory.CreateClient();
            cliente.DefaultRequestHeaders.Add("XApiKey", ApiKey);

            var cotizacionDetalleMock = CotizacionesMocks.EditarMockCotizacionesDetalle();

            // Serializa el objeto a JSON para enviarlo en el cuerpo de la petición
            var contenido = new StringContent(
                System.Text.Json.JsonSerializer.Serialize(cotizacionDetalleMock),
                System.Text.Encoding.UTF8,
                "application/json"
            );

            var response = await cliente.PutAsync("https://localhost:44337/api/CotizacionDetalle/Actualizar", contenido);

            if (!response.IsSuccessStatusCode)
            {
                var errorContent = await response.Content.ReadAsStringAsync();
                Console.WriteLine($"Error: {errorContent}");
                Assert.Fail($"El error aca: {response.StatusCode} - {errorContent}");
            }

            Assert.AreEqual(System.Net.HttpStatusCode.OK, response.StatusCode);
            Assert.IsNotNull(response);

            var responseContent = await response.Content.ReadAsStringAsync();
            Assert.IsFalse(string.IsNullOrEmpty(responseContent));
        }

        [TestMethod]
        public async Task CotizacionListar()
        {
            //creacion del cliente
            var cliente = factory.CreateClient();
            //añade el apikey a al header
            cliente.DefaultRequestHeaders.Add("XApiKey", ApiKey);

            // peticion a la url 
            var response = await cliente.GetAsync("https://localhost:44337/api/Cotizacion/Listar");
            response.EnsureSuccessStatusCode();

            //aserciones 
            Assert.IsInstanceOfType(response, typeof(HttpResponseMessage));
            Assert.IsNotNull(response);
        }

        //[TestMethod]
        //public async Task CotizacionDetallesListar()
        //{
        //    //creacion del cliente
        //    var cliente = factory.CreateClient();
        //    //añade el apikey a al header
        //    cliente.DefaultRequestHeaders.Add("XApiKey", ApiKey);
        //    // peticion a la url 
        //    var response = await cliente.GetAsync("https://localhost:44337/api/CotizacionDetalle/Listar");
        //    response.EnsureSuccessStatusCode();
        //    //aserciones 
        //    Assert.IsInstanceOfType(response, typeof(HttpResponseMessage));
        //    Assert.IsNotNull(response);
        //}


    }
}
