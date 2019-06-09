using System;
using Backend.DataAccess.Abstruct;
using Backend.Entities;

namespace Backend.DataAccess.Concrete
{
    public class EFMusicDal : EfEntityRepositoryBase<Music, DataContext>, IMusicDal
    {
        // Implemented by EfEntityRepositoryBase class
    }
}
