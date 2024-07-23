using BusinessLayer.DTOS;
using BusinessLayer.Interfaces;
using CoreLayer.Paging;
using Microsoft.AspNetCore.Mvc;

namespace CustomerManagment.Controllers
{
    public class CustomerController : Controller
    {
        private readonly ICustomerServices _service;

        public CustomerController(ICustomerServices service)
        {
            _service = service;
        }

        public async Task<IActionResult> Index(string name, string email,int PageNumber=1)
        {
            var Pagingparams = new CustomerPagingParameters
            {
                PageNumber = PageNumber,
                PageSize = 4
            };
            var customers = await _service.GetFilteredCustomersAsync(name, email,Pagingparams);

            return View(new CustomerViewModel
            {
                Customers = customers,
                PageNumber = PageNumber,
                PageSize = Pagingparams.PageSize,
                TotalCount = customers.Count()
            }) ;
        }

        [HttpGet]
        public IActionResult GetAll()
        {
            return RedirectToAction(nameof(Index), new { name = (string)null, email = (string)null });
        }


        [HttpGet]
        public IActionResult Create()
        {
            return View();
        }

        [HttpPost]
        public async Task<IActionResult> Create(CustomerRequestDTO customer)
        {
            if (ModelState.IsValid)
            {
                await _service.AddCustomerAsync(customer);
                return RedirectToAction(nameof(Index));
            }
            return View(customer);
        }

        [HttpGet]
        public async Task<IActionResult> Edit(int id)
        {
            var customer = await _service.GetCustomerByIdAsync(id);
            if (customer == null)
                return NotFound();

            return View(customer);
        }
  
        [HttpPost]
        public async Task<IActionResult> Edit(int id, CustomerRequestDTO customerDto)
        {
            if (ModelState.IsValid)
            {
                try
                {
                    await _service.UpdateCustomerAsync(id, customerDto);
                    return RedirectToAction(nameof(Index));
                }
                catch (Exception ex)
                {
                    // Handle the exception (e.g., log it)
                    ModelState.AddModelError(string.Empty, "An error occurred while updating the customer.");
                }
            }

            return View(customerDto);
        }
        [HttpGet]
        public async Task<IActionResult> Delete(int id)
        {
            var customer = await _service.GetCustomerByIdAsync(id);
            if (customer == null)
                return NotFound();

            return View(customer);
        }

        [HttpPost, ActionName("DeleteConfirmed")]
        public async Task<IActionResult> DeleteConfirmed(int id)
        {
            await _service.DeleteCustomerAsync(id);
            return RedirectToAction(nameof(Index));
        }

    }
}

