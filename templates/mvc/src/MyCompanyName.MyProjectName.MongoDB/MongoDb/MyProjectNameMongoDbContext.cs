﻿using MongoDB.Driver;
using MyCompanyName.MyProjectName.Users;
using Volo.Abp.Data;
using Volo.Abp.MongoDB;

namespace MyCompanyName.MyProjectName.MongoDb
{
    [ConnectionStringName("Default")]
    public class MyProjectNameMongoDbContext : AbpMongoDbContext
    {
        public IMongoCollection<AppUser> Users => Collection<AppUser>();

        protected override void CreateModel(IMongoModelBuilder modelBuilder)
        {
            base.CreateModel(modelBuilder);

            modelBuilder.Entity<AppUser>(b =>
            {
                /* Sharing the same "AbpUsers" collection with the Identity module (IdentityUser entity).
                 */
                b.CollectionName = "AbpUsers";
            });
        }
    }
}
