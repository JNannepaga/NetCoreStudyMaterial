using DAA = EFCorePMC.DataAnnotation;
using FAPI = EFCorePMC.FluentAPI;
using System;

namespace EFCorePMC
{
    class Program
    {
        static void Main(string[] args)
        {
            //DAA.OnetoManyMapping.OnetoOneImplementor.Encounter();
            //OnetoManyImplementor.Encounter();
            //ManytoManyImplementor.Encounter();
            //FAPI.OnetoManyMapping.OnetoManyImplementor.Encounter();
            FAPI.ManytoManyMapping.ManytoManyImplementor.Encounter();
        }
    }
}
