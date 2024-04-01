using OzgurYazilim.OgrenciTakip.Bll.Base;
using OzgurYazilim.OgrenciTakip.Bll.Interfaces;
using OzgurYazilim.OgrenciTakip.Model.Entities;
using System.Windows.Forms;

namespace OzgurYazilim.OgrenciTakip.Bll.General
{
    public class MailParametreBll : BaseGenelBll<MailParametre>, IBaseGenelBll, IBaseCommonBll
    {
        public MailParametreBll()  { }

        public MailParametreBll(Control ctrl) : base(ctrl) { }
    }
}