using System;
using System.Collections.Generic;
using System.IO;
using System.Linq;
using System.Net.Http;
using System.Reflection;
using System.Text;
using System.Threading.Tasks;
using Microsoft.AspNetCore.Hosting;
using Microsoft.AspNetCore.Http.Internal;
using Microsoft.AspNetCore.TestHost;
using Newtonsoft.Json;
using RecensysCoreRepository.DTOs;
using RecensysCoreWebAPI;
using Xunit;

namespace SystemTests
{

    public class TestFixture : IDisposable
    {

        public TestServer TestServer { get; set; }
        public HttpClient HttpClient { get; set; }
        public string StudyId { get; set; }
        public string StageId { get; set; }

        public TestFixture()
        {
            TestServer = new TestServer(new WebHostBuilder()
                .UseStartup<Startup>());
            HttpClient = TestServer.CreateClient();
        }

        public void Dispose()
        {
            TestServer.Dispose();
            HttpClient.Dispose();
        }
    }


    public class Tests : IClassFixture<TestFixture>
    {
        private TestFixture _f;

        public Tests(TestFixture fixture)
        {
            _f = fixture;
        }

        [Fact]
        public async Task Study_Post_Get()
        {
            var dto = new StudyDetailsDTO
            {
                Name = "Test Study"
            };

            // Act
            var response = await _f.HttpClient.PostAsync("api/study", new StringContent(JsonConvert.SerializeObject(dto),Encoding.UTF8,"application/json"));
            response.EnsureSuccessStatusCode();
            _f.StudyId = await response.Content.ReadAsStringAsync();

            var getResponse = await _f.HttpClient.GetStringAsync($"api/study/{_f.StudyId}");
            var resDto = JsonConvert.DeserializeObject<StudyDetailsDTO>(getResponse);

            // Assert
            Assert.Equal("Test Study", resDto.Name);
        }

        [Fact]
        public async Task Source_Post()
        {

            var stream = new FileStream("bibtex100.bib", FileMode.Open);
            var dataContent = new MultipartFormDataContent("file");
            dataContent.Add(new StreamContent(stream));

            // Act
            var response =
                await _f.HttpClient.PostAsync($"api/study/{_f.StudyId}/config/source", dataContent);
            response.EnsureSuccessStatusCode();
            var nrOfArticles = await response.Content.ReadAsStringAsync();
            
            // Assert
            Assert.Equal("100", nrOfArticles);
        
        }
    }
}
