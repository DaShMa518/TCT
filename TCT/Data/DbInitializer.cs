using Microsoft.Build.Evaluation;
using TCT.Models;

namespace TCT.Data
{
    public static class DbInitializer
    {
        public static void Initialize(TCTContext context)
        {
            // look for any terminals
            if (context.Terminals.Any())
            {
                return; // db already has data
            }

            var manufacturer = new Manufacturer[]
            {
                new Manufacturer { Name="TE" },
                new Manufacturer { Name="Sumitomo" },
                new Manufacturer { Name="KM USA" }
            };

            context.Manufacturers.AddRange(manufacturer);
            context.SaveChanges();

            var equipType = new EquipType[]
{
                                        new EquipType { Name="Applicator" },
                                        new EquipType { Name="Crimp Die" },
                                        new EquipType { Name="Hand Tool" }
};

            context.EquipTypes.AddRange(equipType);
            context.SaveChanges();

            var termClass = new TermClass[]
{
                            new TermClass { Name="Cut Strip" },
                            new TermClass { Name="Loose Piece" },
                            new TermClass { Name="Reel" }
};

            context.TermClasses.AddRange(termClass);
            context.SaveChanges();



            var terminals = new Terminal[]
            {
                new Terminal { PartNo="2-520181-2",ManufacturerId=1,TermClassId=3,MaxAWG=18,MidMaxAWG=20,MidMinAWG=null,MinAWG=22,MaxInsulDiam=.135f,StripLength=.280f,DimFront=null,DimRear=null },
                new Terminal{ PartNo="2-520183-2",ManufacturerId=1,TermClassId=3,MaxAWG=18,MidMaxAWG=20,MidMinAWG=null,MinAWG=22,MaxInsulDiam=.135f,StripLength=.280f,DimFront=null,DimRear=null },
                new Terminal{ PartNo="1500-0105",ManufacturerId=2,TermClassId=3,MaxAWG=16,MidMaxAWG=18,MidMinAWG=null,MinAWG=20,MaxInsulDiam=null,StripLength=.180f,DimFront=null,DimRear=null },
                new Terminal{ PartNo="1500-0110",ManufacturerId=2,TermClassId=3,MaxAWG=16,MidMaxAWG=18,MidMinAWG=null,MinAWG=20,MaxInsulDiam=null,StripLength=.180f,DimFront=null,DimRear=null }
            };

            context.Terminals.AddRange(terminals);
            context.SaveChanges();

            var tools = new Tool[]
            {
                new Tool{ InternalId="WP5-078",ModelNo="2151034-2",SerialNo="723059",ManufacturerId=1,EquipTypeId=1 },
                new Tool{ InternalId="WP5-109",ModelNo="466779-3",SerialNo="601194",ManufacturerId=1,EquipTypeId=1 },
                new Tool{ InternalId="WP5-152",ModelNo="2151034-2",SerialNo="748702",ManufacturerId=1,EquipTypeId=1 },
                new Tool{ InternalId="WP5-075",ModelNo="2266140-1",SerialNo="743057",ManufacturerId=1,EquipTypeId=1 },
                new Tool{ InternalId="WP5-120",ModelNo="680330-1",SerialNo="606956",ManufacturerId=1,EquipTypeId=1  },
                new Tool{ InternalId="WP5-151",ModelNo="2151916-1",SerialNo="748287",ManufacturerId=1,EquipTypeId=1  },
                new Tool{ InternalId="WP5-206",ModelNo="1500-0105",SerialNo="1122A-10515",ManufacturerId=3,EquipTypeId=1  }
            };

            context.Tools.AddRange(tools);
            context.SaveChanges();

            var termToolXrefs = new TermToolXref[]
            {
                new TermToolXref { TerminalId = 1, ToolId = 1 },
                new TermToolXref { TerminalId = 1, ToolId = 2 },
                new TermToolXref { TerminalId = 1, ToolId = 3 },
                new TermToolXref { TerminalId = 2, ToolId = 1 },
                new TermToolXref { TerminalId = 2, ToolId = 2 },
                new TermToolXref { TerminalId = 2, ToolId = 3 },
                new TermToolXref { TerminalId = 3, ToolId = 4 },
                new TermToolXref { TerminalId = 3, ToolId = 5 },
                new TermToolXref { TerminalId = 3, ToolId = 6 },
                new TermToolXref { TerminalId = 3, ToolId = 7 },
                new TermToolXref { TerminalId = 4, ToolId = 4 },
                new TermToolXref { TerminalId = 4, ToolId = 5 },
                new TermToolXref { TerminalId = 4, ToolId = 6 },
                new TermToolXref { TerminalId = 4, ToolId = 7 }
            };

            context.TermToolXrefs.AddRange(termToolXrefs);
            context.SaveChanges();

            var crimp = new Crimp[]
            {
                new Crimp { TerminalId = 1, ToolId = 1, WireAWG = 18, CrimpHeight = .085f, PullForce = 30 },
                new Crimp { TerminalId = 2, ToolId = 2, WireAWG = 18, CrimpHeight = .085f, PullForce = 30 },
                new Crimp { TerminalId = 3, ToolId = 4, WireAWG = 18, PullForce = 35 },
                new Crimp { TerminalId = 4, ToolId = 5, WireAWG = 18, PullForce = 35 },
            };
            context.Crimps.AddRange(crimp);
            context.SaveChanges();


        }
    }
}
