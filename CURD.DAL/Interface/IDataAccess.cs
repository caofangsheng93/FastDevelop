using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace CURD.DAL.Interface
{
    interface IDataAccess<T>
    {
        /// <summary>
        /// 增加
        /// </summary>
        /// <param name="entity"></param>
        void Insert(T entity);

        /// <summary>
        /// 删除
        /// </summary>
        /// <param name="entity"></param>
        void Delete(T entity);

        /// <summary>
        /// 修改
        /// </summary>
        /// <param name="entity"></param>
        void Update(T entity);


    }
}
