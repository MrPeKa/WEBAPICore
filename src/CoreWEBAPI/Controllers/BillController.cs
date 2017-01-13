using System.Collections.Generic;
using AutoMapper;
using CoreWEBAPI.Database.Repositories;
using CoreWEBAPI.Domain.DTOs;
using CoreWEBAPI.Domain.Models;
using Microsoft.AspNetCore.Authorization;
using Microsoft.AspNetCore.Mvc;

namespace CoreWEBAPI.Controllers
{
    [AllowAnonymous]
    [ProducesResponseType(204)]
    [Route("api/[controller]")]
    [Consumes("application/json")]
    [Produces("application/json")]
    public class BillController : Controller
    {
        private readonly IBillRepository _billRepository;
        private readonly IMapper _mapper;

        public BillController(IBillRepository billRepository, IMapper mapper)
        {
            _billRepository = billRepository;
            _mapper = mapper;
        }

        [HttpGet, Route("")]
        [ProducesResponseType(typeof(IList<BillDto>), 200)]
        public ActionResult Get()
        {
            var bills = _billRepository.GetBills();
            if (bills == null)
                return NoContent();
            IEnumerable<BillDto> dto = _mapper.Map<IEnumerable<BillModel>, IEnumerable<BillDto>>(bills);
            return Ok(dto);
        }

        [HttpGet, Route("{id}", Name = "GetBill")]
        [ProducesResponseType(typeof(BillDto), 200)]
        public ActionResult GetBill(int id)
        {
            var bill = _billRepository.GetBill(id);
            if (bill == null)
                return NoContent();
            var dto = _mapper.Map<BillDto>(bill);
            return Ok(dto);
        }

        [HttpPost]
        [ProducesResponseType(typeof(BillDto), 200)]
        public ActionResult Post([FromBody] BillDto bill)
        {
            if (!ModelState.IsValid)
                return BadRequest();
            var model = _mapper.Map<BillDto, BillModel>(bill);
            model = _billRepository.AddBill(model);
            var dto = _mapper.Map<BillModel, BillDto>(model);
            return Ok(dto);
        }

        [HttpPut, Route("{id}")]
        [ProducesResponseType(typeof(BillDto), 200)]
        public ActionResult Put(int id, [FromBody] BillDto bill)
        {
            if (_billRepository.GetBill(id) == null)
            {
                return NotFound();
            }
            if (!ModelState.IsValid)
                return BadRequest();
            bill.Id = id;
            var model = _mapper.Map<BillDto, BillModel>(bill);
            model = _billRepository.UpdateBill(model);
            var dto = _mapper.Map<BillModel, BillDto>(model);
            return Ok(dto);
        }

        [HttpDelete, Route("{id}")]
        [ProducesResponseType(200)]
        public ActionResult Delete(int id)
        {
            if (_billRepository.GetBill(id) == null)
            {
                return NotFound();
            }
            _billRepository.RemoveBill(id);
            return Ok();
        }
    }
}