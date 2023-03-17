
using Domain;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Application.Interfaces;
public interface IDesignStudioApp
{
    Task<List<DesignStudio>> GetDesignStudios();
    
    Task<string> CreateDesignStudio(DesignStudio designStudio);

    Task<string> UpdateDesignStudio(DesignStudio designStudio);
    

    Task<DesignStudio> GetDesignStudio(int id);

    Task<List<DesignStudio>> GetDesignStudiosByRegion(int regionId);


    Task<string> DeleteDesignStudio(int designStudioId);


}