using CURD.DAL.Entity;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace CURD.DAL.Implement
{
    /// <summary>
    ///    The UnitOfWork class designed for binding 
    ///    classes to generic class DataAccess. 
    ///    This class is the conversion or binding class
    /// </summary>
   public class UnitOfWork:IDisposable
    {
       /// <summary>
       /// 存储错误消息
       /// </summary>
       private string errorMessage = string.Empty;

       /// <summary>
       /// Defines condition for disposing object 
       /// </summary>
       private bool _disposed = false;

       private DataAccess<Employee> _employeeRepository;

       /// <summary>
       /// 实例化
       /// </summary>
       private BookDBEntities objEntity = new BookDBEntities();

       public DataAccess<Employee> GetEmployeeRepository
       {
           get 
           {
               if (this._employeeRepository == null)
               {
                   this._employeeRepository = new DataAccess<Employee>(this.objEntity);
               }
               return this._employeeRepository;
           }
       
       }

       /// <summary>
       /// 保存
       /// </summary>
       /// <returns></returns>
       public int Save()
       {
           return this.objEntity.SaveChanges();
       }

       /// <summary>
       /// 
       /// </summary>
       public void Dispose()
       {
           this.Dispose(true);
           GC.SuppressFinalize(this);
       }
       protected virtual void Dispose(bool disposing)
       {
           if (!this._disposed)
           {
               if (disposing)
               {
                   this.objEntity.Dispose();
               }
           }
           this._disposed = true;
       }


    }
}
