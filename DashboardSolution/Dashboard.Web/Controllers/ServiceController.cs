using System;
using System.Collections.Generic;
using System.Linq;
using System.Net;
using System.Net.Http;
using System.Threading.Tasks;
using System.Web.Http;
using System.Web.Http.Results;
using Dashboard.Business;
using Dashboard.Web.Models;

namespace Dashboard.Web.Controllers
{
    public class ServiceController : ApiController
    {
        // GET api/<controller>
        public async Task<IHttpActionResult> Get(string path, HourRemainingType type = HourRemainingType.OriginalValue)
        {

            var est = new Estimation();
            var dict = await est.GetAllWorkRemaining(path, type);
            var list = new List<EstimationModel>();
            foreach (var key in dict.Keys)
            {
                list.Add(new EstimationModel
                {
                    ActivityType = key,
                    Hours = dict[key]
                });
            }
            return Ok(list.AsEnumerable());
        }



        //// POST api/<controller>
        //public void Post([FromBody]string value)
        //{
        //}

        //// PUT api/<controller>/5
        //public void Put(int id, [FromBody]string value)
        //{
        //}

        //// DELETE api/<controller>/5
        //public void Delete(int id)
        //{
        //}
    }
}