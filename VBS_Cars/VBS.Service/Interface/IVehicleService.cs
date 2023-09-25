using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using VBS.Models.Input;
using VBS.Models;

namespace VBS.Service.Interface
{
    public interface IVehicleService
    {
        Task<ResultDataArgs> GetVehicleDetailsAsync();

        Task<ResultDataArgs> GetVehicleDetailsByIdAsync(int Id);
        Task<ResultDataArgs> SaveVehicleDetailsAsync(VehicleDetailsDTO vehicleDetailsDTO);

        Task<ResultDataArgs> DeleteVehicleDetailsAsync(Int64 Id);
    }
}
