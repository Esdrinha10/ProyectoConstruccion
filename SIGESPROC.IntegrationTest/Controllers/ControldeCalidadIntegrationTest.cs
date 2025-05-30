﻿using Microsoft.VisualStudio.TestTools.UnitTesting;
using SIGESPROC.IntegrationTest.Mocks;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Net.Http;
using System.Text;
using System.Threading.Tasks;
using SIGESPROC.IntegrationTests;

namespace SIGESPROC.IntegrationTest.Controllers
{
    [TestClass]
    public class ControldeCalidadIntegrationTest : DbContextMocker
    {
        private const string ApiKey = "4b567cb1c6b24b51ab55248f8e66e5cc";
        [TestMethod]
        public async Task ControldeCalidadCrearTest()
        {

            //creamos el cliente
            var cliente = factory.CreateClient();

            //añadimos la apikey al header
            cliente.DefaultRequestHeaders.Add("XApiKey", ApiKey);

            var ControldeCalidadMock = ControldeCalidadMocks.CrearMockControldeCalidad();


            // Serializa el objeto a JSON para enviarlo en el cuerpo de la peticion
            var contenido = new StringContent(System.Text.Json.JsonSerializer.Serialize(ControldeCalidadMock), System.Text.Encoding.UTF8, "application/json");

            //aqui hace la peticion ala url tipo Post
            var response = await cliente.PostAsync("https://localhost:44337/api/ControlDeCalidad/Insertar", contenido);
            //response.EnsureSuccessStatusCode();

            if (!response.IsSuccessStatusCode)
            {
                var errorContent = await response.Content.ReadAsStringAsync();
                Console.WriteLine($"Error: {errorContent}");
                Assert.Fail($"Request failed with status code: {response.StatusCode} - {errorContent}");
            }

            //Aserciones
            Assert.AreEqual(System.Net.HttpStatusCode.OK, response.StatusCode);
            Assert.IsNotNull(response);

            // Lee el contenido de la respuesta 
            var responseContent = await response.Content.ReadAsStringAsync();
            Assert.IsFalse(string.IsNullOrEmpty(responseContent));
        }


        [TestMethod]
        public async Task ControldeCalidadEditarTest()
        {

            //creamos el cliente
            var cliente = factory.CreateClient();

            //añadimos la apikey al header
            cliente.DefaultRequestHeaders.Add("XApiKey", ApiKey);

            var ControldeCalidadMock = ControldeCalidadMocks.EditarMockControldeCalidad();


            // Serializa el objeto a JSON para enviarlo en el cuerpo de la peticion
            var contenido = new StringContent(System.Text.Json.JsonSerializer.Serialize(ControldeCalidadMock), System.Text.Encoding.UTF8, "application/json");
            Console.WriteLine(contenido);

            //aqui hace la peticion ala url tipo Post
            var response = await cliente.PutAsync("https://localhost:44337/api/ControlDeCalidad/Actualizar", contenido);
            //response.EnsureSuccessStatusCode();

            response.EnsureSuccessStatusCode();

            //Aserciones
            Assert.AreEqual(System.Net.HttpStatusCode.OK, response.StatusCode);
            Assert.IsNotNull(response);

            // Lee el contenido de la respuesta 
            var responseContent = await response.Content.ReadAsStringAsync();
            Assert.IsFalse(string.IsNullOrEmpty(responseContent));
        }

    }
}
