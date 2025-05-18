using Data.Models;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Services.BusinessLogic
{
    public interface IPrintService
    {
        Task<bool> PrintBoardingPassAsync(BoardingPass boardingPass);
    }
}
