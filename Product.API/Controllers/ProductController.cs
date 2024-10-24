using AutoMapper;
using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;
using Product.API.Errors;
using Product.Core.Entities;
using Product.Core.Interface;
using Product.Infrastructure.Data;

namespace Product.API.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    public class ProductController : ControllerBase
    {
        private readonly IUnitOfWork _uow;
        private readonly IMapper _mapper;
        public ProductController(IUnitOfWork Uow, IMapper mapper)
        {
            _uow = Uow;
            _mapper = mapper;
        }

        /// <summary>
        /// 取得全部資料
        /// </summary>
        /// <returns></returns>
        [HttpGet("get-all-product")]
        public async Task<ActionResult> Get()
        {
            var res = await _uow.ProductRepository.GetAllAsync(x => x.Category);
            if (res != null)
            {
                var result = _mapper.Map<List<ProductDto>>(res);
                return Ok(result);
            }
            return BadRequest("沒有資料");
        }

        /// <summary>
        /// 取得指定資料
        /// </summary>
        /// <param name="id"></param>
        /// <returns></returns>
        [HttpGet("get-product-by-id/{id}")]
        [ProducesResponseType(StatusCodes.Status200OK)]
        [ProducesResponseType(typeof(BaseCommonResponse), StatusCodes.Status404NotFound)]
        public async Task<ActionResult> Get(int id)
        {
            var src = await _uow.ProductRepository.GetByIdAsync(id, x => x.Category);
            if (src is null)
                return NotFound(new BaseCommonResponse(404));
            var result = _mapper.Map<ProductDto>(src);
            return Ok(result);
        }

        /// <summary>
        /// 新增資料
        /// </summary>
        /// <param name="id"></param>
        /// <returns></returns>
        [HttpPost("add-new-product")]
        public async Task<ActionResult> Post(CreateProductDto productDto)
        {
            try
            {
                if (ModelState.IsValid)
                {

                    var res = await _uow.ProductRepository.AddAsync(productDto);
                    return res ? Ok(productDto) : BadRequest(res);
                }
                return BadRequest(productDto);
            }
            catch (Exception ex)
            {

                return BadRequest(ex.Message);
            }
        }
        [HttpPut("update-exiting-product/{id}")]
        public async Task<ActionResult> Put(int id, [FromForm] UpdateProductDto productDto)
        {
            try
            {
                if (ModelState.IsValid)
                {
                    var res = await _uow.ProductRepository.UpdateAsync(id, productDto);
                    return res ? Ok(productDto) : BadRequest(res);
                }
                return BadRequest(productDto);
            }
            catch (Exception ex)
            {
                return BadRequest(ex.Message);
            }

        }

        [HttpDelete("delete-exiting-product/{id}")]
        public async Task<ActionResult> Delete(int id)
        {
            try
            {
                if (ModelState.IsValid)
                {
                    var res = await _uow.ProductRepository.DeleteAsync(id);
                    return res ? Ok(res) : BadRequest(res);
                }
                return NotFound($"this id={id} not found");

            }

            catch (Exception ex)
            {
                return BadRequest(ex.Message);
            }
        }
    }
}
