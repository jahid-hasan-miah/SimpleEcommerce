using Autofac;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using ECommerceSystem.ProductManaging.Contexts;
using ECommerceSystem.ProductManaging.Repositories;
using ECommerceSystem.ProductManaging.Services;
using ECommerceSystem.ProductManaging.UnitOfWorks;

namespace ECommerceSystem.ProductManaging
{
    public class ProductModule : Module
    {
        private readonly string _connectionString;
        private readonly string _migrationAssemblyName;

        public ProductModule(string connectionString, string migrationAssemblyName)
        {
            _connectionString = connectionString;
            _migrationAssemblyName = migrationAssemblyName;
        }

        protected override void Load(ContainerBuilder builder)
        {
            builder.RegisterType<ProductContext>().AsSelf()
                .WithParameter("connectionString", _connectionString)
                .WithParameter("migrationAssemblyName", _migrationAssemblyName)
                .InstancePerLifetimeScope();

            builder.RegisterType<ProductContext>().As<IProductContext>()
                .WithParameter("connectionString", _connectionString)
                .WithParameter("migrationAssemblyName", _migrationAssemblyName)
                .InstancePerLifetimeScope();

            builder.RegisterType<ProductRepostiory>().As<IProductRepository>()
              .InstancePerLifetimeScope();
            builder.RegisterType<ProductUnitOfWork>().As<IProductUnitOfWork>()
                .InstancePerLifetimeScope();
            builder.RegisterType<ProductService>().As<IProductService>()
                .InstancePerLifetimeScope();

            base.Load(builder);
        }
    }
}
