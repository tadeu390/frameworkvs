using System;
using System.Collections.Generic;
using System.Data.Entity;
using System.Data.Entity.Migrations;
using System.Data.Entity.Validation;
using System.Linq;
using System.Linq.Expressions;
using System.Runtime.Remoting.Contexts;
using System.Text;
using System.Threading.Tasks;
using System.Web.UI.WebControls;

namespace Dal.Repository.Base
{
    public class Repository<T> : IDisposable, IRepository<T> where T : class
    {
        protected FrameworkvsContext _context;

        public Repository()
        {
            _context = new FrameworkvsContext();
        }

        public IQueryable<T> GetAll()
        {
            return _context.Set<T>();
        }

        public IQueryable<T> Get(Expression<Func<T, bool>> predicate)
        {
            return GetAll().Where(predicate).AsQueryable();
        }

        public T Find(params object[] key)
        {
            return _context.Set<T>().Find(key);
        }

        public bool Atualizar(T obj)
        {
            try
            {
                _context.Entry(obj).State = EntityState.Modified;
                _context.SaveChanges();
                return true;
            }
            catch (Exception e)
            {
                return false;
            }

        }

        public void Adicionar(T obj)
        {
            try
            {
                if (obj == null)
                    throw new ArgumentException("Objeto nulo à ser salvo");
                _context.Set<T>().AddOrUpdate(obj);

                _context.SaveChanges();

            }
            catch (DbEntityValidationException dbEx)
            {
                var msg = string.Empty;

                foreach (var validationErrors in dbEx.EntityValidationErrors)
                    foreach (var validationError in validationErrors.ValidationErrors)
                        msg += Environment.NewLine + string.Format("Property: {0} Error: {1}", validationError.PropertyName, validationError.ErrorMessage);

                var fail = new Exception(msg, dbEx);
                //Debug.WriteLine(fail.Message, fail);
                throw fail;
            }
        }


        void IRepository<T>.Dispose()
        {
            throw new NotImplementedException();
        }

        public void Attach(T obj)
        {
            try
            {
                if (obj == null)
                    throw new ArgumentNullException("entity");

                this._context.Set<T>().Attach(obj);

                this._context.SaveChanges();
            }
            catch (DbEntityValidationException dbEx)
            {
                var msg = string.Empty;

                foreach (var validationErrors in dbEx.EntityValidationErrors)
                    foreach (var validationError in validationErrors.ValidationErrors)
                        msg += Environment.NewLine + string.Format("Property: {0} Error: {1}", validationError.PropertyName, validationError.ErrorMessage);

                var fail = new Exception(msg, dbEx);
                //Debug.WriteLine(fail.Message, fail);
                throw fail;
            };
        }

        void IDisposable.Dispose()
        {
            throw new NotImplementedException();
        }
    }
}