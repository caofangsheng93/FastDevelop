using CURD.BLL.Interface;
using CURD.DAL.Entity;
using CURD.DAL.Implement;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace CURD.BLL.Implement
{
   public class EmployeeBLL:IEmployee
    {
       private UnitOfWork unitOfWork = new UnitOfWork();

       private List<Employee> lstEmp = new List<Employee>();
       private Employee objEmp = new Employee();

       /// <summary>
       /// 获取所有Employee
       /// </summary>
       /// <returns></returns>
       public IEnumerable<Employee> EmployeeGet()
       {
           lstEmp = unitOfWork.GetEmployeeRepository.Get().ToList();
           return lstEmp;
       }
       /// <summary>
       /// 更新Employee
       /// </summary>
       /// <param name="emp"></param>
       /// <returns></returns>
       public string EmployeeUpdate(Employee emp)
       {
           objEmp = unitOfWork.GetEmployeeRepository.GetByID(emp.EmployeeNo);
           if (objEmp != null)
           {
               objEmp.FirstName = emp.FirstName;
               objEmp.LastName = emp.LastName;
               objEmp.Address = emp.Address;
               objEmp.MobileNo = emp.MobileNo;
               objEmp.PostalCode = emp.PostalCode;
               objEmp.EmailId = emp.EmailId;
           }
           this.unitOfWork.GetEmployeeRepository.Update(objEmp);
           int result = this.unitOfWork.Save();
           if (result > 0)
           {
               return "Update Success!!!";
           }
           else
           {
               return "Update Fail";
           }
       }

       /// <summary>
       /// 删除Employee
       /// </summary>
       /// <param name="id"></param>
       /// <returns></returns>
       public string EmployeeDelete(int id)
       {
           objEmp = this.unitOfWork.GetEmployeeRepository.GetByID(id);
           this.unitOfWork.GetEmployeeRepository.Delete(objEmp);
           int deleteData = this.unitOfWork.Save();
           if (deleteData > 0)
           {
               return "Delete Success";
           }
           else
           {
               return "Delete Fail";
           }
       }

       /// <summary>
       /// 新增Employee
       /// </summary>
       /// <param name="emp"></param>
       /// <returns></returns>
       public string EmployeeInsert(Employee emp)
       {
           this.unitOfWork.GetEmployeeRepository.Insert(emp);
           int insertData = this.unitOfWork.Save();
           if (insertData > 0)
           {
               return "Add Success";
           }
           else
           {
               return "Add Fail";
           }

       }
    }
}
