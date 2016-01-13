using ProductsApp.Models;
using ProductsApp.Repositories;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Net;
using System.Web.Http;
using System.Net.Http;

namespace ProductsApp.Controllers
{
    public class ProductsController : ApiController
    {
        private ProductsRepository Repository;

        ProductsController()
        {
            this.Repository = new ProductsRepository();
        }

        public IEnumerable<Product> GetAllProducts()
        {
            return Repository.GetAllProducts();
        }

        public HttpResponseMessage GetProduct(int id)
        {
            var product = Repository.GetProduct(id);
            if (product == null)
            {
                return Request.CreateResponse(HttpStatusCode.NotFound);
            }
            return Request.CreateResponse(HttpStatusCode.OK, product);
        }

        public HttpResponseMessage PostProduct(Product product)
        {
           
            Repository.SaveProduct(product);

            var response = Request.CreateResponse<Product>(System.Net.HttpStatusCode.Created, product);
            return response;
        }
    }
}
