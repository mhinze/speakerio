using System.Web.Mvc;
using SpeakerIO.Web.App_Start;
using SpeakerIO.Web.Application.Container;
using StructureMap;
using WebActivator;

[assembly: PostApplicationStartMethod(typeof (StructureMapConfiguration), "Start")]

namespace SpeakerIO.Web.App_Start
{
    public class StructureMapConfiguration
    {
        public static void Start()
        {
            ObjectFactory.Initialize(init => init.AddRegistry<SpeakerIORegistry>());
            DependencyResolver.SetResolver(new StructureMapDependencyResolver(ObjectFactory.Container));
        }
    }
}