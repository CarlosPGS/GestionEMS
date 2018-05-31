namespace AppGestionEMS.Migrations
{
    using Microsoft.AspNet.Identity;
    using Microsoft.AspNet.Identity.EntityFramework;
    using Models;
    using System;
    using System.Data.Entity;
    using System.Data.Entity.Migrations;
    using System.Linq;

    internal sealed class Configuration : DbMigrationsConfiguration<AppGestionEMS.Models.ApplicationDbContext>
    {
        public Configuration()
        {
            AutomaticMigrationsEnabled = false;
        }

        protected override void Seed(AppGestionEMS.Models.ApplicationDbContext context)
        {
            string administrador = "administrador";
            string profesor = "profesor";
            string alumno = "alumno";
            AddRole(context, administrador);
            AddRole(context, profesor);
            AddRole(context, alumno);
            AddUser(context, "Danie", "Champ", "hacker@upm.es", administrador);
            AddUser(context, "Jessica", "Diaz", "yesica.diaz@upm.es", profesor);
            AddUser(context, "Carolina", "Gallardo", "carolina.gallardop@upm.es", profesor);
            AddUser(context, "Julian", " ElCrack", "jec@alumnos.upm.es", alumno);
            AddUser(context, "Alberto", "ElDocument", "word@alumnos.upm.es", alumno);
            AddUser(context, "Carlos", "Desconocido", "lilChals@alumnos.upm.es", alumno);
        }
        public void AddRole(ApplicationDbContext context, String role)
        {
            IdentityResult IdRoleResult;
            var roleStore = new RoleStore<IdentityRole>(context);
            var roleMgr = new RoleManager<IdentityRole>(roleStore);
            if (!roleMgr.RoleExists(role))
                IdRoleResult = roleMgr.Create(new IdentityRole { Name = role });
        }
        public void AddUser(ApplicationDbContext context, String name, String surname, String email, String role)
        {
            IdentityResult IdUserResult;
            var userMgr = new UserManager<ApplicationUser>(new UserStore<ApplicationUser>(context));
            var appUser = new ApplicationUser
            {
                Name = name,
                Surname = surname,
                UserName = email,
                Email = email,
            };
            IdUserResult = userMgr.Create(appUser, "123456Aa!");
            //asociar usuario con role
            if (!userMgr.IsInRole(userMgr.FindByEmail(email).Id, role))
            {
                IdUserResult = userMgr.AddToRole(userMgr.FindByEmail(email).Id, role);
            }
        }
    }
}
