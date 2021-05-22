using MyShop.Models;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Net;
using System.Net.Http;
using System.Web.Http;

namespace ASPTest.Controllers
{
    public class TestValue
    {
        public string value { get; set; }
    }

    public class ValuesController : ApiController
    {
        // GET api/values
        public IEnumerable<string> Get()
        {
            annshopDBEntities db = new annshopDBEntities();
            List<TestTable> table = db.TestTable.ToList();

            List<string> ret = new List<string>();

            foreach (TestTable t in table)
            {
                ret.Add(t.value);
            }

            return ret.ToArray();
        }

        // GET api/values/5
        public string Get(int id)
        {
            annshopDBEntities db = new annshopDBEntities();
            return db.TestTable.Where(t => t.id == id).Select(t => t.value).FirstOrDefault();
        }

        // POST api/values
        public IHttpActionResult Post(TestValue value)
        {
            if (!ModelState.IsValid)
                return BadRequest("Invalid data.");

            annshopDBEntities db = new annshopDBEntities();

            TestTable tt = new TestTable();
            tt.value = value.value;

            db.TestTable.Add(tt);

            db.SaveChanges();

            return Ok();
        }

        // PUT api/values/5
        public void Put(int id, [FromBody] string value)
        {
            // todo edit record
        }

        // DELETE api/values/5
        public void Delete(int id)
        {
            // todo delete record
        }
    }
}
