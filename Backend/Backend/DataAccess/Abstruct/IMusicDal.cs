using System;
using Backend.Entities;

namespace Backend.DataAccess.Abstruct
{
    public interface IMusicDal : IEntityRepository<Music>
    {
        // Methods signatures are inherited from IEntityRepository
    }

}
