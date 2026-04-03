using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;

namespace ACS.BLL
{
  public class OPERATOR : ERMS.Core.DAL.IBindable
  {
    #region IBindable Members

    public void DataBind(ERMS.Core.DAL.IDataRow row)
    {
    }

    public object this[string field]
    {
      get
      {
        throw new NotImplementedException();
      }
      set
      {
        throw new NotImplementedException();
      }
    }

    public bool _IsDataBound
    {
      get { throw new NotImplementedException(); }
    }

    #endregion
  }
}
