using OzgurYazilim.Dal.Interfaces;
using OzgurYazilim.OgrenciTakip.Common.Messages;
using System;
using System.Data.Entity;
using System.Data.Entity.Infrastructure;
using System.Data.SqlClient;

namespace OzgurYazilim.Dal.Base
{
    public class UnitOfWork<T> : IUnitOfWork<T> where T : class
    {

        #region Variables

        private readonly DbContext _context;

        #endregion

        public UnitOfWork(DbContext context)
        {
            if (context == null) return;
            _context = context;
        }

        public IRepository<T> Rep => new Repository<T>(_context);

        public bool Save()
        {
            try
            {
                _context.SaveChanges();
            }
            catch (DbUpdateException ex)
            {
                var sqlEx = (SqlException)ex.InnerException?.InnerException;
                if (sqlEx == null)
                {
                    Messages.HataMesaji(ex.Message);
                    return false;
                }
                switch (sqlEx.Number)
                {
                    case 208:
                        Messages.HataMesaji("İşlem yapmak istediğiniz tablo veritabanında bulunamadı!");
                        break;
                    case 547:
                        Messages.HataMesaji("Seçilen kartın işlem görmüş hareketleri var. Kart silinemez!");
                        break;
                    case 2601:
                    case 2627:
                        Messages.HataMesaji("Girmiş olduğunuz Id daha önce kullanılmıştır!");
                        break;
                    case 4060:
                        Messages.HataMesaji("İşlem yapmak istediğiniz veritabanı sunucuda bulunamadı!");
                        break;
                    case 18456:
                        Messages.HataMesaji("Sunucuya bağlanılmak istenilen kullanıcı adı veya şifre hatalıdır!");
                        break;
                    default:
                        Messages.HataMesaji(sqlEx.Message);
                        break;
                }
                return false;
            }
            catch (Exception ex)
            {
                Messages.HataMesaji(ex.Message);
                return false;
            }
            return true;
        }

        #region Dispose

        private bool _disposedValue = false; // To detect redundant calls

        protected virtual void Dispose(bool disposing)
        {
            if (!_disposedValue)
            {
                if (disposing)
                {
                    _context.Dispose();
                }


                _disposedValue = true;
            }
        }

        public void Dispose()
        {
            Dispose(true);
            GC.SuppressFinalize(this);
        }

        #endregion

    }
}