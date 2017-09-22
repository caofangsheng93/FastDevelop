using CURD.BLL.Interface;
using CURD.DAL.Entity;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Net;
using System.Net.Http;
using System.Web.Http;

namespace CURD.Service.Controllers
{
    [System.Web.Http.RoutePrefix("api/Employee")]
    public class EmployeeAPIController : ApiController
    {
        IEmployee objEmp;

        [Route("EmpDetails")]
        public IEnumerable<Employee> GetEmployeeData()
        {
            IEnumerable<Employee> empDetail = new List<Employee>();
            try
            {
                empDetail = objEmp.EmployeeGet();
            }
            catch (ApplicationException ex)
            {
                throw new HttpResponseException(new HttpResponseMessage { StatusCode = HttpStatusCode.BadRequest, ReasonPhrase = ex.Message });
            }
            catch (Exception ex)
            {
                throw new HttpResponseException(new HttpResponseMessage { StatusCode = HttpStatusCode.BadGateway, ReasonPhrase = ex.Message });
            }
            return empDetail;
        }

        [HttpPost]
        [Route("InsertEmpDetails")]
        public string InsertEmployee(Employee emp)
        {
            string objEmployee;
            try
            {
                objEmployee = this.objEmp.EmployeeInsert(emp);
            }
            catch (ApplicationException ex)
            {
                throw new HttpResponseException(new HttpResponseMessage { StatusCode = HttpStatusCode.BadRequest, ReasonPhrase = ex.Message });
            }
            catch (Exception ex)
            {
                throw new HttpResponseException(new HttpResponseMessage { StatusCode = HttpStatusCode.BadGateway, ReasonPhrase = ex.Message });
            }
            return objEmployee;
        }

        [HttpPut]
        [Route("UpdateEmpDetails")]
        public string UpdateEmployee(Employee emp)
        {
            string objEmployee;
            try
            {
                objEmployee = this.objEmp.EmployeeUpdate(emp);
            }
            catch (ApplicationException ex)
            {
                throw new HttpResponseException(new HttpResponseMessage { StatusCode = HttpStatusCode.BadRequest, ReasonPhrase = ex.Message });
            }
            catch (Exception ex)
            {
                throw new HttpResponseException(new HttpResponseMessage { StatusCode = HttpStatusCode.BadGateway, ReasonPhrase = ex.Message });
            }
            return objEmployee;
        }

        [HttpDelete]
        [Route("DeleteEmpData/{id}")]
        public string DeleteEmployeeData(int id)
        {
            string objEmpDetails;
            try
            {
                objEmpDetails = this.objEmp.EmployeeDelete(id);
            }
            catch (ApplicationException ex)
            {
                throw new HttpResponseException(new HttpResponseMessage { StatusCode = HttpStatusCode.BadRequest, ReasonPhrase = ex.Message });
            }
            catch (Exception ex)
            {
                throw new HttpResponseException(new HttpResponseMessage { StatusCode = HttpStatusCode.BadGateway, ReasonPhrase = ex.Message });
            }
            return objEmpDetails;
        }

    }
}
