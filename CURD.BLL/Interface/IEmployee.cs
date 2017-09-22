using CURD.DAL.Entity;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace CURD.BLL.Interface
{
   public interface IEmployee
    {
       /// <summary>
       /// 获取所有员工
       /// </summary>
       /// <returns></returns>
       IEnumerable<Employee> EmployeeGet();
       /// <summary>
       /// 添加Employee
       /// </summary>
       /// <param name="emp"></param>
       /// <returns></returns>
       string EmployeeInsert(Employee emp);

       /// <summary>
       /// 修改Employee
       /// </summary>
       /// <param name="emp"></param>
       /// <returns></returns>
       string EmployeeUpdate(Employee emp);

       /// <summary>
       /// 删除Employee
       /// </summary>
       /// <param name="id"></param>
       /// <returns></returns>
       string EmployeeDelete(int id);

    }
}
