using Core.DataAccess.EntityFramework;
using DataAccess.Abstracts;
using Entities.Concrete;
using System;
using System.Collections.Generic;
using System.Text;

namespace DataAccess.Concrete.EntityFramwork
{
  public  class EfCarImageDal: EfEntityRepositoryBase<CarImage, context>, ICarImageDal
    {
    }
}
