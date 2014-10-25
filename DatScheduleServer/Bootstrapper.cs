using System;
using Microsoft.Practices.Unity.ObjectBuilder;
using Nancy.Bootstrapper;
using Nancy.Responses;
using Nancy.TinyIoc;

namespace DatScheduleServer
{
    using Nancy;

    public class Bootstrapper : DefaultNancyBootstrapper
    {
        // The bootstrapper enables you to reconfigure the composition of the framework,
        // by overriding the various methods and properties.
        // For more information https://github.com/NancyFx/Nancy/wiki/Bootstrapper
        
        protected override void RequestStartup(TinyIoCContainer requestContainer, IPipelines pipelines, NancyContext context)
        {
            pipelines.OnError.AddItemToEndOfPipeline((ctx, ex) =>
            {
                Log(ex.Message);
                return new TextResponse(HttpStatusCode.InternalServerError, ex.Message);
            });

            base.RequestStartup(requestContainer, pipelines, context);
        }

        private void Log(string message)
        {
            Elmah.ErrorSignal.FromCurrentContext().Raise(new Exception(message));
        }
    }
}