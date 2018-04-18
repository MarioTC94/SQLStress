
using SQLStress.Business;
using SQLStress.Business.Interfaces;
using System;
using System.Web.Mvc;
using Unity;
using Unity.AspNet.Mvc;

namespace SQLStress.Web
{
    /// <summary>
    /// Specifies the Unity configuration for the main container.
    /// </summary>
    public static class UnityConfig
    {
        public static void RegisterUnity()
        {
            var Container = new UnityContainer();




			Container.RegisterType<ISQL, SQLBL>();

            DependencyResolver.SetResolver(new UnityDependencyResolver(Container));
        }
    }
}