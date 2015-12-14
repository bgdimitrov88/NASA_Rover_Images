using Microsoft.Practices.Unity;
using NASA_Rover_Images.Presenters;
using NASA_Rover_Images.Utils;
using NASA_Rover_Images.Views;
using System;

namespace NASA_Rover_Images.Unity
{
    /// <summary>
    /// Specifies the Unity configuration.
    /// </summary>
    public class UnityConfig
    {
        private static Lazy<IUnityContainer> container = new Lazy<IUnityContainer>(() =>
        {
            var container = new UnityContainer();
            RegisterTypes(container);
            return container;
        });

        /// <summary>
        /// Gets the configured Unity container.
        /// </summary>
        public static IUnityContainer GetConfiguredContainer()
        {
            return container.Value;
        }

        /// <summary>Registers the type mappings with the Unity container.</summary>
        /// <param name="container">The unity container to configure.</param>
        public static void RegisterTypes(IUnityContainer container)
        {
            // Register types
            container.RegisterType<IMainView, MainForm>();
            container.RegisterType<IMainFormPresenter, MainFormPresenter>();
            container.RegisterType<IRoverInfoView, RoverInfoForm>();
            container.RegisterType<IRoverInfoPresenter, RoverInfoPresenter>();
            container.RegisterType<IPaginator, Paginator>();
            container.RegisterType<INasaApiCommunicator, NasaApiCommunicator>();

        }
    }
}
