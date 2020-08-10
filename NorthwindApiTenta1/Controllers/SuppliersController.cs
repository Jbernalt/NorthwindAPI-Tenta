using AutoMapper;
using System;
using System.Collections.Generic;
using System.Threading.Tasks;
using System.Web.Http;
using NorthwindApiTenta1.Data;
using NorthwindApiTenta1.Data.Entities;
using NorthwindApiTenta1.Models;

namespace NorthwindApiTenta1.Controllers
{
    [RoutePrefix("api/suppliers")]
    public class SuppliersController : ApiController
    {
        private readonly ISupplierRepository _repository;
        private readonly IMapper _mapper;

        public SuppliersController(ISupplierRepository repository, IMapper mapper)
        {
            _repository = repository;
            _mapper = mapper;
        }

        //GET: api/suppliers
        [Route()]
        public async Task<IHttpActionResult> Get()
        {
            try
            {
                var result = await _repository.GetAllSuppliersAsync();
                var mappedResult = _mapper.Map<IEnumerable<SupplierModel>>(result);

                return Ok(mappedResult);
            }
            catch (Exception ex)
            {
                return InternalServerError(ex);
            }
        }

        //GET: api/suppliers/1
        [Route("{supplierId}", Name = "GetSupplier")]
        public async Task<IHttpActionResult> Get(int supplierId)
        {
            try
            {
                var result = await _repository.GetSupplierAsync(supplierId);
                if (result == null) return NotFound();

                return Ok(_mapper.Map<SupplierModel>(result));
            }
            catch (Exception ex)
            {
                return InternalServerError(ex);
            }
        }

        //POST: api/suppliers
        [Route()]
        public async Task<IHttpActionResult> Post(SupplierModel model)
        {
            try
            {
                if (await _repository.GetSupplierByNameAsync(model.CompanyName) != null)
                {
                    ModelState.AddModelError("CompanyName", "Company Name already in use");
                }

                if (ModelState.IsValid)
                {
                    var supplier = _mapper.Map<Suppliers>(model);

                    _repository.AddSupplier(supplier);

                    if (await _repository.SaveChangesAsync())
                    {
                        var newModel = _mapper.Map<SupplierModel>(supplier);

                        return CreatedAtRoute("GetSupplier", new { supplierid = newModel.SupplierID }, newModel);
                    }

                }
            }
            catch (Exception ex)
            {
                return InternalServerError(ex);
            }

            return BadRequest(ModelState);
        }

        //PUT: api/suppliers/1
        [Route("{supplierId}")]
        public async Task<IHttpActionResult> Put(int supplierId, SupplierModel model)
        {
            try
            {
                var supplier = await _repository.GetSupplierAsync(supplierId);
                if (supplier == null) return NotFound();

                _mapper.Map(model, supplier);

                if (await _repository.SaveChangesAsync())
                {
                    return Ok(_mapper.Map<SupplierModel>(supplier));
                }
                else
                {
                    return InternalServerError();
                }
            }
            catch (Exception ex)
            {
                return InternalServerError(ex);
            }
        }

        //DELETE: api/suppliers/1
        [Route("{supplierId}")]
        public async Task<IHttpActionResult> Delete(int supplierId)
        {
            try
            {
                var supplier = await _repository.GetSupplierAsync(supplierId);
                if (supplier == null) return NotFound();

                _repository.DeleteSupplier(supplier);

                if (await _repository.SaveChangesAsync())
                {
                    return Ok();
                }
                else
                {
                    return InternalServerError();
                }
            }
            catch (Exception ex)
            {
                return InternalServerError(ex);
            }
        }
    }
}