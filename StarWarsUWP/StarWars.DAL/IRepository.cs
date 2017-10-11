using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using StarWars.Domain;

namespace StarWars.DAL
{
    public interface IRepository
    {
        Movie GetMobieByUrl(string url);
    }
}
