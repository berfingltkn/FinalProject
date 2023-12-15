using Businnes.Abstract;
using Businnes.Concrete;
using DataAccess.Concrete.EntityFramework;
using Entities.Concrete;
using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace WebAPI2.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    public class ProductsController : ControllerBase
    {
        IProductService _productService;//bağımlılığı ortadan kaldırmak için böyle yaptık. Direkt Get() in içine de yazabilirdik.

        public ProductsController(IProductService productService)
        {
            _productService = productService;
        }

        [HttpGet("getall")]
        //ASP.NET Web API'de [HttpGet] özniteliği, bir Web API denetleyicisi içindeki bir işlevin sadece HTTP GET isteklerine yanıt vereceğini belirtir

        public IActionResult GetAll()
        {
            
            var result= _productService.GetAll();
            if (result.Success)
            {
                return Ok(result);//Ok-->200 durum kodu, başarılı
            }
            return BadRequest(result);
        }
        [HttpGet("getbyid")]//dışarıdan birisi bunu nasıl çağırır? bu yüzden isimlendirdik.
        public IActionResult GetById(int id)
        {
            var result = _productService.GetById(id);
            if (result.Success)
            {
                return Ok(result);
            }
            return BadRequest(result);
        }

        [HttpPost("add")]
        public IActionResult Add(Product product)
        {
            //IActionresult--> aksiyon yönetiminin sonucunu temsil eden bir arabirimdir.
            //Farklı türde sonuçlar döndürmek için kullanılan dönüş tipi olarak işlev görür.

            var result = _productService.Add(product);
            if (result.Success)
            {
                return Ok(result);
            }

            return BadRequest(result);
        }
    }
}
