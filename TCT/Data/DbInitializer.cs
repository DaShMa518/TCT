<<<<<<< HEAD
﻿using Microsoft.AspNetCore.Identity;
using Microsoft.EntityFrameworkCore;
using Microsoft.VisualBasic;
=======
﻿using Microsoft.Build.Evaluation;
>>>>>>> 881d7f11e5023fb96b845d9f26e3badbcea7d18f
using TCT.Models;

namespace TCT.Data
{
    public static class DbInitializer
    {
<<<<<<< HEAD
        //public static async Task Initialize(IServiceProvider serviceProvider, string testUserPw)
        //{
        //    using (var context = new TCTContext(
        //        serviceProvider.GetRequiredService<DbContextOptions<TCTContext>>()))
        //    {
        //        // For sample purposes seed both with the same password.
        //        // Password is set with the following:
        //        // dotnet user-secrets set SeedUserPW <pw>
        //        // The admin user can do anything

        //        var adminID = await EnsureUser(serviceProvider, testUserPw, "dmaye@ica-south.com");
        //        await EnsureRole(serviceProvider, adminID, "Admin");

        //        // allowed user can create and edit contacts that they create
        //        //var managerID = await EnsureUser(serviceProvider, testUserPw, "manager@contoso.com");
        //        //await EnsureRole(serviceProvider, managerID, "Manager");

        //        SeedDb(context, adminID);
        //    }
        //}

        //private static async Task<string> EnsureUser(IServiceProvider serviceProvider,
        //                                            string testUserPw, string UserName)
        //{
        //    var userManager = serviceProvider.GetService<UserManager<IdentityUser>>();

        //    var user = await userManager.FindByNameAsync(UserName);
        //    if (user == null)
        //    {
        //        user = new IdentityUser
        //        {
        //            UserName = UserName,
        //            EmailConfirmed = true
        //        };
        //        await userManager.CreateAsync(user, testUserPw);
        //    }

        //    if (user == null)
        //    {
        //        throw new Exception("The password is probably not strong enough!");
        //    }

        //    return user.Id;
        //}

        //private static async Task<IdentityResult> EnsureRole(IServiceProvider serviceProvider,
        //                                                              string uid, string role)
        //{
        //    var roleManager = serviceProvider.GetService<RoleManager<IdentityRole>>();

        //    if (roleManager == null)
        //    {
        //        throw new Exception("roleManager null");
        //    }

        //    IdentityResult IR;
        //    if (!await roleManager.RoleExistsAsync(role))
        //    {
        //        IR = await roleManager.CreateAsync(new IdentityRole(role));
        //    }

        //    var userManager = serviceProvider.GetService<UserManager<IdentityUser>>();

        //    //if (userManager == null)
        //    //{
        //    //    throw new Exception("userManager is null");
        //    //}

        //    var user = await userManager.FindByIdAsync(uid);

        //    if (user == null)
        //    {
        //        throw new Exception("The testUserPw password was probably not strong enough!");
        //    }

        //    IR = await userManager.AddToRoleAsync(user, role);

        //    return IR;
        //}

        public static void Initialize(TCTContext context)
        //public static void SeedDb(TCTContext context, string adminID)
=======
        public static void Initialize(TCTContext context)
>>>>>>> 881d7f11e5023fb96b845d9f26e3badbcea7d18f
        {
            // look for any terminals
            if (context.Terminals.Any())
            {
                return; // db already has data
            }

            var manufacturer = new Manufacturer[]
            {
<<<<<<< HEAD
                new Manufacturer { Name = "TE" },
                new Manufacturer { Name = "Sumitomo" },
                new Manufacturer { Name = "KM USA" }
=======
                new Manufacturer { Name="TE" },
                new Manufacturer { Name="Sumitomo" },
                new Manufacturer { Name="KM USA" }
>>>>>>> 881d7f11e5023fb96b845d9f26e3badbcea7d18f
            };

            context.Manufacturers.AddRange(manufacturer);
            context.SaveChanges();

            var equipType = new EquipType[]
{
<<<<<<< HEAD
                                        new EquipType { Name = "Applicator" },
                                        new EquipType { Name = "Crimp Die" },
                                        new EquipType { Name = "Hand Tool" }
=======
                                        new EquipType { Name="Applicator" },
                                        new EquipType { Name="Crimp Die" },
                                        new EquipType { Name="Hand Tool" }
>>>>>>> 881d7f11e5023fb96b845d9f26e3badbcea7d18f
};

            context.EquipTypes.AddRange(equipType);
            context.SaveChanges();

            var termClass = new TermClass[]
{
<<<<<<< HEAD
                            new TermClass { Name = "Cut Strip" },
                            new TermClass { Name = "Loose Piece" },
                            new TermClass { Name = "Reel" }
=======
                            new TermClass { Name="Cut Strip" },
                            new TermClass { Name="Loose Piece" },
                            new TermClass { Name="Reel" }
>>>>>>> 881d7f11e5023fb96b845d9f26e3badbcea7d18f
};

            context.TermClasses.AddRange(termClass);
            context.SaveChanges();



            var terminals = new Terminal[]
            {
<<<<<<< HEAD
                new Terminal{ PartNo = "2-520181-2", ManufacturerId = 1, TermClassId = 3, MinWireAWG = 22, MaxWireAWG = 18, MinInsulDiam = null, MaxInsulDiam = .135f, StripLength = .280f, DimFront = null, DimRear = null },
                new Terminal{ PartNo = "2-520183-2", ManufacturerId = 1, TermClassId = 3, MinWireAWG = 22, MaxWireAWG = 18, MinInsulDiam = null, MaxInsulDiam = .135f, StripLength = .280f, DimFront = null, DimRear = null},
                new Terminal{ PartNo = "1500-0105", ManufacturerId = 2, TermClassId = 3, MinWireAWG = 20, MaxWireAWG = 16, MinInsulDiam = .071f, MaxInsulDiam = .114f, StripLength = .180f, DimFront = null, DimRear = null},
                new Terminal{ PartNo = "1500-0110", ManufacturerId = 2, TermClassId = 3, MinWireAWG = 20, MaxWireAWG = 16, MinInsulDiam = .071f, MaxInsulDiam = .114f, StripLength = .180f, DimFront = null, DimRear = null}
=======
                new Terminal { PartNo="2-520181-2",ManufacturerId=1,TermClassId=3,MaxAWG=18,MidMaxAWG=20,MidMinAWG=null,MinAWG=22,MaxInsulDiam=.135f,StripLength=.280f,DimFront=null,DimRear=null },
                new Terminal{ PartNo="2-520183-2",ManufacturerId=1,TermClassId=3,MaxAWG=18,MidMaxAWG=20,MidMinAWG=null,MinAWG=22,MaxInsulDiam=.135f,StripLength=.280f,DimFront=null,DimRear=null },
                new Terminal{ PartNo="1500-0105",ManufacturerId=2,TermClassId=3,MaxAWG=16,MidMaxAWG=18,MidMinAWG=null,MinAWG=20,MaxInsulDiam=null,StripLength=.180f,DimFront=null,DimRear=null },
                new Terminal{ PartNo="1500-0110",ManufacturerId=2,TermClassId=3,MaxAWG=16,MidMaxAWG=18,MidMinAWG=null,MinAWG=20,MaxInsulDiam=null,StripLength=.180f,DimFront=null,DimRear=null }
>>>>>>> 881d7f11e5023fb96b845d9f26e3badbcea7d18f
            };

            context.Terminals.AddRange(terminals);
            context.SaveChanges();

            var tools = new Tool[]
            {
<<<<<<< HEAD
                new Tool{ InternalId = "WP5-078", ModelNo = "2151034-2", SerialNo = "723059", ManufacturerId = 1, EquipTypeId = 1 },
                new Tool{ InternalId= "WP5-109", ModelNo = "466779-3", SerialNo = "601194", ManufacturerId = 1, EquipTypeId = 1 },
                new Tool{ InternalId= "WP5-152", ModelNo = "2151034-2", SerialNo = "748702", ManufacturerId = 1, EquipTypeId = 1 } ,
                new Tool{ InternalId= "WP5-075", ModelNo = "2266140-1", SerialNo = "743057", ManufacturerId = 1, EquipTypeId = 1 },
                new Tool{ InternalId= "WP5-120", ModelNo = "680330-1", SerialNo = "606956", ManufacturerId = 1, EquipTypeId = 1  },
                new Tool{ InternalId= "WP5-151", ModelNo = "2151916-1", SerialNo = "748287", ManufacturerId = 1, EquipTypeId = 1  },
                new Tool{ InternalId= "WP5-206", ModelNo = "1500-0105", SerialNo = "1122A-10515", ManufacturerId = 3, EquipTypeId = 1  }
=======
                new Tool{ InternalId="WP5-078",ModelNo="2151034-2",SerialNo="723059",ManufacturerId=1,EquipTypeId=1 },
                new Tool{ InternalId="WP5-109",ModelNo="466779-3",SerialNo="601194",ManufacturerId=1,EquipTypeId=1 },
                new Tool{ InternalId="WP5-152",ModelNo="2151034-2",SerialNo="748702",ManufacturerId=1,EquipTypeId=1 },
                new Tool{ InternalId="WP5-075",ModelNo="2266140-1",SerialNo="743057",ManufacturerId=1,EquipTypeId=1 },
                new Tool{ InternalId="WP5-120",ModelNo="680330-1",SerialNo="606956",ManufacturerId=1,EquipTypeId=1  },
                new Tool{ InternalId="WP5-151",ModelNo="2151916-1",SerialNo="748287",ManufacturerId=1,EquipTypeId=1  },
                new Tool{ InternalId="WP5-206",ModelNo="1500-0105",SerialNo="1122A-10515",ManufacturerId=3,EquipTypeId=1  }
>>>>>>> 881d7f11e5023fb96b845d9f26e3badbcea7d18f
            };

            context.Tools.AddRange(tools);
            context.SaveChanges();

<<<<<<< HEAD
            var crimp = new Crimp[]
            {
                new Crimp { TerminalId = 1, ToolId = 1, WireAWG = 20, PullForce = 22 },
                new Crimp { TerminalId = 1, ToolId = 1, WireAWG = 18, PullForce = 30 },
                new Crimp { TerminalId = 2, ToolId = 1, WireAWG = 18, PullForce = 30 },
                new Crimp { TerminalId = 2, ToolId = 2, WireAWG = 18, PullForce = 30 },
                new Crimp { TerminalId = 2, ToolId = 3, WireAWG = 18, PullForce = 30 },
                new Crimp { TerminalId = 3, ToolId = 4, WireAWG = 18, CrimpHeight = .085f, PullForce = 35 },
                new Crimp { TerminalId = 3, ToolId = 4, WireAWG = 16, CrimpHeight = .093f, PullForce = 47 },
                new Crimp { TerminalId = 3, ToolId = 5, WireAWG = 18, CrimpHeight = .085f, PullForce = 35 },
                new Crimp { TerminalId = 3, ToolId = 6, WireAWG = 18, CrimpHeight = .085f, PullForce = 35 },
                new Crimp { TerminalId = 3, ToolId = 7, WireAWG = 18, CrimpHeight = .085f, PullForce = 35 },
                new Crimp { TerminalId = 4, ToolId = 4, WireAWG = 18, CrimpHeight = .085f, PullForce = 35 },
                new Crimp { TerminalId = 4, ToolId = 4, WireAWG = 16, CrimpHeight = .093f, PullForce = 47 },
                new Crimp { TerminalId = 4, ToolId = 5, WireAWG = 18, CrimpHeight = .085f, PullForce = 35 },
                new Crimp { TerminalId = 4, ToolId = 6, WireAWG = 20, CrimpHeight = .078f, PullForce = 22 },
                new Crimp { TerminalId = 4, ToolId = 6, WireAWG = 18, CrimpHeight = .085f, PullForce = 35 },
                new Crimp { TerminalId = 4, ToolId = 6, WireAWG = 16, CrimpHeight = .093f, PullForce = 47 },
                new Crimp { TerminalId = 4, ToolId = 7, WireAWG = 18, CrimpHeight = .085f, PullForce = 35 }
=======
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
>>>>>>> 881d7f11e5023fb96b845d9f26e3badbcea7d18f
            };
            context.Crimps.AddRange(crimp);
            context.SaveChanges();


        }
    }
}
