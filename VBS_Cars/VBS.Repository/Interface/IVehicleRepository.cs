using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using VBS.Models.Input;
using VBS.Models.Output;

namespace VBS.Repository.Interface
{
    public interface IVehicleRepository
    {

        Task<VehicleDetailsResult> GetVehicleDetailsAsync();
        Task<VehicleDetailsDTO> GetVehicleDetailsByIdAsync(int Id);
        Task<int> SaveVehicleDetailsAsync(VehicleDetailsDTO vehicleDetailsDTO);
        Task<Int16> DeleteVehicleDetailsAsync(Int64 Id);

    }
}
