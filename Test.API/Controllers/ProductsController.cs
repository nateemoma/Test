using System;
using System.Collections.Generic;
using System.Linq;
using System.Net;
using System.Net.Http;
using System.Web.Http;
using Test.BusinessLogic;
using Test.DataModel;

namespace Test.API.Controllers
{
    [RoutePrefix("api/Products")]
    public class ProductsController : ApiController
    {
        Process process;

        public ProductsController()
        {
            process = new Process();
        }

        [HttpGet]
        [Route("GetProducts")]
        public HttpResponseMessage GetProducts()
        {
            var items = process.GetProducts();
            return Request.CreateResponse(HttpStatusCode.OK, items);
        }

        [HttpPost]
        [Route("InsertProduct")]
        public HttpResponseMessage InsertProduct(Product product)
        {
            process.InsertProduct(product);
            return Request.CreateResponse(HttpStatusCode.OK, true);
        }


        [HttpPost]
        [Route("UpdateProduct")]
        public HttpResponseMessage UpdateProduct(Product product)
        {
            process.UpdateProduct(product);
            return Request.CreateResponse(HttpStatusCode.OK, true);
        }


        [HttpPost]
        [Route("DeleteProduct")]
        public HttpResponseMessage DeleteProduct(Product product)
        {
            process.DeleteProduct(product);
            return Request.CreateResponse(HttpStatusCode.OK, true);
        }
    }
}
