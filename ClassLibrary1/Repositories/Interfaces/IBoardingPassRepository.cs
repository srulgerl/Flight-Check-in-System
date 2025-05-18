using Data.Models;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Data.Repositories
{
    public interface IBoardingPassRepository
    {
        Task<bool> CreateAsync(BoardingPass boardingPass);
        Task<BoardingPass> GetPassengerByIdAsync(int passengerId);
        

    }
}
