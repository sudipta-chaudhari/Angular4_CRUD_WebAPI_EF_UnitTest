using Angular4WebApi.DBModel;
using Angular4WebApi.Models;
using Angular4WebApi.Repositories;
using System.Collections.Generic;
using System.Web.Http;

namespace Angular4WebApi.Controllers
{
    public class ProductController : ApiController
    {
        #region GlobalVariables
        private IProductRepository _repository;
        private readonly InventoryEntities _context;
        #endregion

        #region C'tor
        public ProductController(IProductRepository repository)
        {
            _context = new InventoryEntities();

            if (repository == null)
            {
                _repository = new ProductRepository();
            }
            else
            {
                _repository = repository;
            }
        }
        #endregion

        #region API Methods
        // GET api/<controller>
        [Route("api/Product/GetProducts")]
        public IList<ProductJSON> GetProducts()
        {
            return _repository.GetProducts();
        }
        // POST api/<controller>
        //public Product Post([FromBody]Product product)
        //{
        //    return _repository.Post(product);
        //}
        [Route("api/Product/AddProduct")]
        [HttpPost]
        /*
         {
	        "Name":"Milk",
	        "Category":"Dairy",
	        "Price":44
         }
        */
        public bool AddProduct([FromBody]ProductJSON product)
        {
            return _repository.AddProduct(product);
        }
        [Route("api/Product/UpdateProduct")]
        [HttpPost]
        //POST:api/Product/UpdateProduct
        public bool UpdateProduct([FromBody]ProductJSON p)
        {
            return _repository.UpdateProduct(p);
        }
        // DELETE api/<controller>/5
        public bool Delete(int id)
        {
            return _repository.Delete(id);
        }
        #endregion
    }
}