using Microsoft.AspNetCore.Mvc;
using System.Runtime.CompilerServices;
using MedicineItemWebAPI;

// For more information on enabling Web API for empty projects, visit https://go.microsoft.com/fwlink/?LinkID=397860

namespace MedicineItemWebAPI.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    public class MedicineItemController : ControllerBase
    {


        List<MedicineItem> medicineItemList = new()
        {
            new MedicineItem { Name = "Panodil 500 mg" },
            new MedicineItem { Name = "Etanercept 50 mg" },
            new MedicineItem { Name = "Etoricoxib Teva 90 mg" },
            new MedicineItem { Name = "Sulfasalazin 500 mg" },
            new MedicineItem { Name = "Adalimumab 40 mg" }
        };

        // GET: api/<MedicineItemController>
        [HttpGet]
        public IEnumerable<MedicineItem> Get()
        {
            return medicineItemList.ToArray();

        }

        // GET api/<MedicineItemController>/5
        [HttpGet("{id}")]
        public string Get(int id)
        {
            return "value";
        }

        // POST api/<MedicineItemController>
        [HttpPost]
        public void Post([FromBody] string value)
        {
        }

        // PUT api/<MedicineItemController>/5
        [HttpPut("{id}")]
        public void Put(int id, [FromBody] string value)
        {
        }

        // DELETE api/<MedicineItemController>/5
        [HttpDelete("{id}")]
        public void Delete(int id)
        {
        }
    }
}
