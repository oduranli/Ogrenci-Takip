using OzgurYazilim.OgrenciTakip.Model.Entities.Base;
using System.Collections.Generic;

namespace OzgurYazilim.OgrenciTakip.Bll.Interfaces
{
    public interface IBaseHareketGenelBll
    {
        bool Insert(IList<BaseHareketEntity> entities);
        bool Update(IList<BaseHareketEntity> entities);
        bool Delete(IList<BaseHareketEntity> entities);
    }
}