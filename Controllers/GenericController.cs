using ApiCrudUsingGeneric.IService;
using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;

namespace ApiCrudUsingGeneric.Controllers
{
    public class GenericController<T> : Controller where T : class
    {
        private IGenericService<T> _genericService;
        public GenericController(IGenericService<T> genericService)
        {
            _genericService = genericService;
        }
        // GET: GenericController
        [HttpGet]
        public List<T> Get()
        {
            return _genericService.GetAll();
        }

        [HttpGet("{id}")]
        // GET: GenericController/Details/5
        public T Get(int id)
        {
            return _genericService.GetById(id);
        }

        // GET: GenericController/Create
        [HttpPost]
        public List<T> Post([FromBody] T value)
        {
            return _genericService.Insert(value);

        }

        // GET: GenericController/Delete/5
        [HttpDelete("{id}")]
        public List<T> Delete(int id)
        {
            return _genericService.Delete(id);
        }

    }
}
