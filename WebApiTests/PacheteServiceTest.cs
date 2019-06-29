using CentruMultimedia.Models;
using Lab3.Services;
using Microsoft.EntityFrameworkCore;
using NUnit.Framework;
using System;
using System.Collections.Generic;
using System.Text;

namespace WebApiTests
{
    class PacheteServiceTest
    {


        [Test]
        public void CreateShouldReturnVAlidPachetGetModel()
        {
            var options = new DbContextOptionsBuilder<FilmeDbContext>()
            .UseInMemoryDatabase(databaseName: nameof(CreateShouldReturnVAlidPachetGetModel))
            .Options;

            using (var context = new FilmeDbContext(options))
            {
                var pacheteService = new PacheteService(context);
                var added = new Lab3.ViewModels.PachetPostModel
                {
                    AdresaDestinatar = "adresa",
                    CodTracking = "123",
                    Cost = 23,
                    DenumireDestinatar = "mama",
                    DenumireExpeditor = "tata",
                    TaraDestinatie = "R0mania",
                    TaraOrigine = "Franta"
                };

                var pachet = pacheteService.Create(added);

                Assert.IsNotNull(pachet);
                Assert.AreEqual(added.CodTracking, pachet.CodTracking);
            }
        }





        [Test]
        public void DeleteShouldEmptyTheDb()
        {
            var options = new DbContextOptionsBuilder<FilmeDbContext>()
            .UseInMemoryDatabase(databaseName: nameof(DeleteShouldEmptyTheDb))
            .Options;

            using (var context = new FilmeDbContext(options))
            {
                var pacheteService = new PacheteService(context);
                var added = new Lab3.ViewModels.PachetPostModel
                {
                    AdresaDestinatar = "adresa",
                    CodTracking = "123",
                    Cost = 23,
                    DenumireDestinatar = "mama",
                    DenumireExpeditor = "tata",
                    TaraDestinatie = "R0mania",
                    TaraOrigine = "Franta"
                };
                
                var pachet = pacheteService.Create(added);

                Assert.IsNotNull(pachet);

                var userDeleted = pacheteService.Delete(1);

                Assert.NotNull(userDeleted);

            }
        }
    }
}
