using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;
using BankingAPI.Models;

namespace BankingAPI.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    public class AccountsController : ControllerBase
    {
        Accounts acc = new Accounts();

        #region HttpGet
        [HttpGet]
        [Route("accList")]

        public IActionResult GetAllAccounts()
        {
            return Ok(acc.GetAllAccounts());
        }

        [HttpGet]
        [Route("accList/searchByType/{type}")]

        public IActionResult GetAccountsByType(string type)
        {
            return Ok(acc.GetAccountsByType(type));
        }

        [HttpGet]
        [Route("accList/searchByNo/{accNum}")]

        public IActionResult GetAccountByNum(int accNum)
        {
            try
            {
                return Ok(acc.GetAccountByNo(accNum));
            }
            catch (Exception ex)
            {
                return NotFound(ex.Message);
            }
        }

        [HttpGet]
        [Route("accList/searchByStatus/{status}")]

        public IActionResult GetAccountsByStatus(bool status)
        {
            return Ok(acc.GetAccountsByStatus(status));
        }
        #endregion

        #region HttpPost

        [HttpPost]
        [Route("accList/add")]

        public IActionResult AddNewAccount([FromBody] Accounts newAccount)
        {
            try
            {
                string result = acc.AddNewAccount(newAccount);
                return Created("", result);
            }
            catch (Exception ex)
            {
                return Ok(ex.Message);
            }
        }
        #endregion

        #region HttpPut

        [HttpPut]
        [Route("accList/edit")]

        public IActionResult EditAccount([FromBody] Accounts editAccount)
        {
            try
            {
                string result = acc.EditAccount(editAccount);
                return Accepted(result);
            }
            catch (Exception ex)
            {
                return Ok(ex.Message);
            }
        }
        #endregion

        #region HttpDelete
        [HttpDelete]
        [Route("accList/delete/{accNum}")]

        public IActionResult DeleteAcccount(int accNum)
        {
            try
            {
                string result = acc.DeleteAccount(accNum);
                return Accepted(result);
            }
            catch (Exception ex)
            {
                return Ok(ex.Message);
            }
        }
        #endregion
    }
}
