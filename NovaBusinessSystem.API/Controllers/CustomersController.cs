using System.Drawing;
using Microsoft.AspNetCore.Mvc;
using Microsoft.Data.SqlClient;
using NovaBusinessSystem.BL;
using NovaBusinessSystem.DTOs;

namespace NovaBusinessSystem.API
{
    [ApiController]
    [Route("api/Customers")]
    public class Customers : ControllerBase
    {
        [HttpGet("", Name = "GetAllCustomers")]

        [ProducesResponseType(StatusCodes.Status200OK)]
        [ProducesResponseType(StatusCodes.Status400BadRequest)]
        public ActionResult<List<CustomerDTO>> GetAllCustomers()
        {
            List<CustomerDTO> allCustomers =
                CustomersBL.GetCustomersList().ToList();

            if (allCustomers is null || !allCustomers.Any())
                return BadRequest("Not have any data");

            return Ok(allCustomers);
        }

        [HttpGet("{id:int}", Name = "GetCustomerByID")]

        [ProducesResponseType(StatusCodes.Status200OK)]
        [ProducesResponseType(StatusCodes.Status400BadRequest)]
        [ProducesResponseType(StatusCodes.Status404NotFound)]
        [ProducesResponseType(StatusCodes.Status500InternalServerError)]
        public ActionResult<CustomerDTO> GetCustomerByID([FromRoute(Name = "id")] int id)
        {

            if (id <= 0)
                return BadRequest("Invalid Data");

            CustomersBL? customer = CustomersBL.Find(id);

            if (customer is null)
                return NotFound("The Customer not found");

            return Ok(customer.CDTO);
        }


        [HttpPost("")]
        [ProducesResponseType(StatusCodes.Status200OK)]
        [ProducesResponseType(StatusCodes.Status400BadRequest)]
        [ProducesResponseType(StatusCodes.Status201Created)]
        [ProducesResponseType(StatusCodes.Status500InternalServerError)]

        public ActionResult AddNewCustomer([FromBody] CustomerAddDTO customer)
        {

            if (customer is null)
                return BadRequest("The Customer is null ");

            if (
                CustomersBL.CheckStringIsValid(customer.FirstName) ||
                CustomersBL.CheckStringIsValid(customer.FirstName) ||
                CustomersBL.CheckStringIsValid(customer.Email) ||
                CustomersBL.CheckStringIsValid(customer.Phone) ||
                CustomersBL.CheckStringIsValid(customer.City) ||
                CustomersBL.CheckStringIsValid(customer.Status) ||
                customer.Status != "Active" || customer.Status != "Inactive" || customer.Status != "Blocked"
                )

                return BadRequest("Invalid Data");

            CustomersBL customersBL = new CustomersBL();

            customersBL.ConvertAddDTOtoObject(customer);


            if (!customersBL.SaveModeCustomer())
                return BadRequest("Connot Be Added This Customer");


            return CreatedAtAction(nameof(GetCustomerByID), new { Id = customersBL.CustomerID }, customersBL.CDTO);
        }

        [HttpPut("{id:int}")]
        [ProducesResponseType(StatusCodes.Status200OK)]
        [ProducesResponseType(StatusCodes.Status400BadRequest)]
        [ProducesResponseType(StatusCodes.Status404NotFound)]
        [ProducesResponseType(StatusCodes.Status500InternalServerError)]
        [ProducesResponseType(StatusCodes.Status204NoContent)]

        public ActionResult UpdateCustomer([FromRoute(Name = "id")] int id, [FromBody] CustomerAddDTO customer)
        {

            if (customer is null)
                return BadRequest("The Customer is null ");
            if (id < 0)
                return BadRequest("Invalid Data 1");

            if (CustomersBL.IsEmailExists(customer.Email))
                return BadRequest("Invalid Data Email");

            if (
                !CustomersBL.CheckStringIsValid(customer.FirstName) ||
                !CustomersBL.CheckStringIsValid(customer.LastName) ||
                !CustomersBL.CheckStringIsValid(customer.Email) ||
                !CustomersBL.CheckStringIsValid(customer.City) ||
                !CustomersBL.CheckStringIsValid(customer.Status)
                )

                return BadRequest("Invalid Data 2 ");

            if (!CustomersBL.IsStatusValid(customer.Status))
                return BadRequest("Invalid Data Status ");

            CustomersBL customersBL = CustomersBL.Find(id)!;

            if (customersBL is null)
                return NotFound("The Customer not found");

            customersBL.ConvertAddDTOtoObject(customer);


            if (!customersBL.SaveModeCustomer())
                return BadRequest("Connot Be Updated This Customer");


            return NoContent();
        }

        [HttpDelete("{id:int}")]
        [ProducesResponseType(StatusCodes.Status204NoContent)]
        [ProducesResponseType(StatusCodes.Status400BadRequest)]
        [ProducesResponseType(StatusCodes.Status404NotFound)]
        [ProducesResponseType(StatusCodes.Status500InternalServerError)]
        [ProducesResponseType(StatusCodes.Status409Conflict)]
        public ActionResult DeleteCustomer([FromRoute(Name = "id")] int id)
        {
            if (id <= 0)
                return BadRequest("Invalid Customer ID.");

            CustomersBL? customersBL = CustomersBL.Find(id);

            if (customersBL is null)
                return NotFound("The Customer was not found.");
            try
            {
                if (!customersBL.DeleteCustomer())
                    return NotFound($"Customer with ID {id} was not found.");

                return NoContent();
            }
            catch (SqlException ex) when (ex.Number == 547)
            {
                return Conflict(
                    "This customer cannot be deleted because they have related sales."
                );
            }
            catch (SqlException)
            {
                return StatusCode(
                    StatusCodes.Status500InternalServerError,
                    "A database error occurred."
                );
            }
        }

    }
}