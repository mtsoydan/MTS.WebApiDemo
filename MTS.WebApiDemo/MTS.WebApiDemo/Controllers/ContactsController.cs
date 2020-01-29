using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Microsoft.AspNetCore.Mvc;
using MTS.WebApiDemo.Models;

namespace MTS.WebApiDemo.Controllers
{
    [Route("api/[controller]")]
    public class ContactsController : Controller
    {
        [HttpGet("")]
       public List<ContactModel> Contacts()
        {
            return new List<ContactModel>
            {
                new ContactModel{ContactID =1,FirstName="mts",LastName="Soydan"},
                new ContactModel{ContactID=2 ,LastName="soydan",FirstName="furkan"}
            };
        }
    }
}