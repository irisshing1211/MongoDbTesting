using Microsoft.AspNetCore.Hosting;
using Microsoft.Extensions.Configuration;
using MongoDB.Driver;
using MongoDbTesting.Data;
using System;
using System.Collections.Generic;
using System.IO;

namespace MongoDbTesting
{
    class Program
    {
        static void Main(string[] args)
        {
            var configuration = new ConfigurationBuilder()
                 .SetBasePath(Directory.GetCurrentDirectory())
                 .AddJsonFile($"appsettings.json")
                 .Build();

            var host = new WebHostBuilder()
                .UseKestrel()
                .UseContentRoot(Directory.GetCurrentDirectory())
                .UseIISIntegration()
                .UseStartup<Startup>()
                .UseConfiguration(configuration)
                .UseUrls(configuration.GetSection("Setting").GetSection("Url").Value)
                .Build();

            var connStr = "mongodb://sa:123459_abcd@cluster0-shard-00-00-hqlel.mongodb.net:27017,cluster0-shard-00-01-hqlel.mongodb.net:27017,cluster0-shard-00-02-hqlel.mongodb.net:27017/test?ssl=true&replicaSet=Cluster0-shard-0&authSource=admin&retryWrites=true";
            // var connStr = "mongodb://127.0.0.1:27017";
            var client = new MongoClient(connStr);

            IMongoDatabase db = client.GetDatabase("testdb");
            var account = new Account
            {
                //Id = new Guid(),
                Name = "Tester",
            };
            var table_account = db.GetCollection<Account>("AccountTable");
            var allAccount = table_account.Find(a => true).ToList();
            table_account.DeleteMany(Builders<Account>.Filter.Empty);
            table_account.InsertOne(account);

            Console.WriteLine($"Account inserted: {account.Id}");

            var admin = new Role
            {
                // Id = new Guid(),
                Name = "Admin"
            };
            var tester = new Role
            {
                //  Id = new Guid(),
                Name = "Tester"
            };
            var table_role = db.GetCollection<Role>("Role");
            table_role.DeleteMany(Builders<Role>.Filter.Empty);
            table_role.InsertOne(admin);
            table_role.InsertOne(tester);

            Console.WriteLine($"Admin {admin.Id}, Tester: {tester.Id}");

            var mapping = new List<AccountRole>
            {
                new AccountRole{AccountId=account.Id, RoleId=admin.Id},
                new AccountRole{AccountId=account.Id, RoleId=tester.Id}
            };

            var table_mapping = db.GetCollection<AccountRole>("AccountRole");
            table_mapping.DeleteMany(Builders<AccountRole>.Filter.Empty);
            table_mapping.InsertMany(mapping);

            Console.ReadKey();
        }

    }
}
