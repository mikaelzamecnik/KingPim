using KingPim.Domain.Entities;
using System;
using System.Collections.Generic;
using System.Text;
using System.Threading.Tasks;

namespace KingPim.Application.SubcategoryAgService
{
    public interface ISubcategoryAgRepository
    {
        Task JoinSCAG(SubcategoryAgModel model);
    }
}
