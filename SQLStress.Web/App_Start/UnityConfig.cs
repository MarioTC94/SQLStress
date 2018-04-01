using SQLStress.Business.Interfaces;
using SQLStress.Business.Logic;
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
            var unityContainer = new UnityContainer();

			/*
             * HERE YOU REGISTER YOUR DEPENDENCY INJETION CLASSES AND INTERFACES LIKE
             * unityContainer.RegisterType<IInterface, class>();
             */

			unityContainer.RegisterType<ISqlCall, SqlCallBL>();
			unityContainer.RegisterType<lReport, ReportBL>();


            DependencyResolver.SetResolver(new UnityDependencyResolver(unityContainer));
        }
    }
}