//using PizzaStore.Library;
//using System;
//using System.Collections.Generic;
//using System.Text;
//using PizzaStore.Library.Repositories;
//using Microsoft.Extensions.Configuration;
//using System.IO;
//using Microsoft.EntityFrameworkCore;
//using PizzaStore.Data;
//using Xunit;

//namespace PizzaStoreDBTest
//{
//    public class PizzaStoreTesting
//    {
//        [Fact]
//        public void TestRepoAddUser()
//        {
//            //Arrange
//            var configBuilder = new ConfigurationBuilder()
//                .SetBasePath(Directory.GetCurrentDirectory())
//                .AddJsonFile("appsettings.json", optional: true, reloadOnChange: true);

//            IConfigurationRoot configuration = configBuilder.Build();

//            var optionsBuilder = new DbContextOptionsBuilder<PizzaStoreDBContext>();
//            optionsBuilder.UseSqlServer(configuration.GetConnectionString("PizzaStoreDB"));
//            var options = optionsBuilder.Options;

//            var DBContext = new PizzaStoreDBContext(options);
//            var PizzaStoreRepo = new PizzaStoreRepository(DBContext);

//            User u = new User
//            {
//                FirstName = "TestFirst",
//                LastName = "TestLast",
//                DefaultLocation = 2
//            };

//            //Act
//            PizzaStoreRepo.AddUser(u);

//            //Assert
//            Assert.True(PizzaStoreRepo.DoesUserExist(u.FirstName, u.LastName));
//        }

//        [Fact]
//        public void TestingGetUserId()
//        {
//            //Arrange
//            var configBuilder = new ConfigurationBuilder()
//            .SetBasePath(Directory.GetCurrentDirectory())
//            .AddJsonFile("appsettings.json", optional: true, reloadOnChange: true);

//            IConfigurationRoot configuration = configBuilder.Build();

//            var optionsBuilder = new DbContextOptionsBuilder<PizzaStoreDBContext>();
//            optionsBuilder.UseSqlServer(configuration.GetConnectionString("PizzaStoreDB"));
//            var options = optionsBuilder.Options;

//            var DBContext = new PizzaStoreDBContext(options);
//            var PizzaStoreRepo = new PizzaStoreRepository(DBContext);

//            User u = new User
//            {
//                FirstName = "TestFirst1",
//                LastName = "TestLast2",
//                DefaultLocation = 2
//            };

//            //Act
//            PizzaStoreRepo.AddUser(u);

//            //Assert
//            System.Type type = typeof(int);
//            int id = PizzaStoreRepo.GetUserID(u);
//            Assert.True(PizzaStoreRepo.GetUserID(u) == id);
//        }

//        [Fact]
//        public void TestingRepoAddOrder()
//        {
//            //Arrange
//            var configBuilder = new ConfigurationBuilder()
//            .SetBasePath(Directory.GetCurrentDirectory())
//            .AddJsonFile("appsettings.json", optional: true, reloadOnChange: true);

//            IConfigurationRoot configuration = configBuilder.Build();

//            var optionsBuilder = new DbContextOptionsBuilder<PizzaStoreDBContext>();
//            optionsBuilder.UseSqlServer(configuration.GetConnectionString("PizzaStoreDB"));
//            var options = optionsBuilder.Options;

//            var DBContext = new PizzaStoreDBContext(options);
//            var PizzaStoreRepo = new PizzaStoreRepository(DBContext);

//            User u = new User
//            {
//                FirstName = "TestFirst3",
//                LastName = "TestLast4",
//                DefaultLocation = 2
//            };

//            Order o = new Order();

//            //Act
//            PizzaStoreRepo.AddUser(u);

//            //Assert
//            System.Type type = typeof(int);
//            int id = PizzaStoreRepo.GetUserID(u);
//            Assert.True(PizzaStoreRepo.GetUserID(u) == id);


//        }
//    }
//}
