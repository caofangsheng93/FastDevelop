using CURD.DAL.Entity;
using CURD.DAL.Interface;
using System;
using System.Collections.Generic;
using System.Data.Entity;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace CURD.DAL.Implement
{
    public class DataAccess<TEntity> : IDataAccess<TEntity> where TEntity : class
    {
        /// <summary>
        /// 上下文
        /// </summary>
        internal BookDBEntities _context;

        /// <summary>
        /// 数据集
        /// </summary>
        internal DbSet<TEntity> dbSet;

        public DataAccess(BookDBEntities context)
        {
            this._context = context;
            this.dbSet = context.Set<TEntity>();
        }
        /// <summary>
        ///   获取所有数据
        /// </summary>
        /// <returns></returns>
        public virtual IEnumerable<TEntity> Get()
        {
            IQueryable<TEntity> query = this.dbSet;
            return query.ToList();
        }
        /// <summary>
        /// 通过标识符获取实体
        /// </summary>
        /// <param name="id"></param>
        /// <returns></returns>
        public virtual TEntity GetByID(object id)
        {
            return this.dbSet.Find(id);
        }

        /// <summary>
        /// 新增
        /// </summary>
        /// <param name="entity"></param>
        public virtual void Insert(TEntity entity)
        {
            this.dbSet.Add(entity);
        }

        /// <summary>
        ///  通过id删除实体
        /// </summary>
        /// <param name="id"></param>
        public virtual void Delete(object id)
        {
            TEntity entityToDelete = this.dbSet.Find(id);
            this.Delete(entityToDelete);
        }
        /// <summary>
        /// 删除数据
        /// </summary>
        /// <param name="entityToDelete"></param>
        public virtual void Delete(TEntity entityToDelete)
        {
            if (this._context.Entry(entityToDelete).State == EntityState.Detached)
            {
                //把实体加到上下文中
                this.dbSet.Attach(entityToDelete);
            }
            this.dbSet.Remove(entityToDelete);
        }

        /// <summary>
        /// 修改
        /// </summary>
        /// <param name="entityToUpdate"></param>
        public virtual void Update(TEntity entityToUpdate)
        {
            this.dbSet.Attach(entityToUpdate);
            this._context.Entry(entityToUpdate).State = EntityState.Modified;
        }

    }
}
