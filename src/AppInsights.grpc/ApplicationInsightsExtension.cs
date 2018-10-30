using Grpc.Core;
using Grpc.Core.Interceptors;
using Microsoft.ApplicationInsights.Extensibility;
using Petabridge.Tracing.ApplicationInsights;
using OpenTracing.Contrib.Grpc.Interceptors;

namespace AppInsights.Grpc
{
    
    public static class ApplicationInsightsExtension
    {
        // 
        // Summary:
        //     Allows client side tracing to be sent to Application Insights by hooking 
        //     Petabridge.Tracing.ApplicationInsights.ApplicationInsightsTracer into the gRPC channel interceptor. 
        //     Gets the instrumentation key from the APPINSIGHTS_INSTRUMENTATIONKEY environment variable.
        public static CallInvoker UseApplicationInsights(this Channel channel)
        {
            return channel.Intercept(
                new ClientTracingInterceptor(
                    new ApplicationInsightsTracer(
                        TelemetryConfiguration.Active)));
        }

        // 
        // Summary:
        //     Allows client side tracing to be sent to Application Insights by hooking 
        //     Petabridge.Tracing.ApplicationInsights.ApplicationInsightsTracer into the gRPC channel interceptor.
        public static CallInvoker UseApplicationInsights(this Channel channel, string instrumentationKey)
        {
            return channel.Intercept(
                new ClientTracingInterceptor(
                    new ApplicationInsightsTracer(
                        new TelemetryConfiguration(instrumentationKey))));
        }

        // 
        // Summary:
        //     Allows server side tracing to be sent to Application Insights by hooking 
        //     Petabridge.Tracing.ApplicationInsights.ApplicationInsightsTracer into the gRPC service definition interceptor. 
        //     Gets the instrumentation key from the APPINSIGHTS_INSTRUMENTATIONKEY environment variable.
        public static ServerServiceDefinition UseApplicationInsights(this ServerServiceDefinition server)
        {
            return server.Intercept(
                new ServerTracingInterceptor(
                    new ApplicationInsightsTracer(
                        TelemetryConfiguration.Active)));
        }

        // 
        // Summary:
        //     Allows server side tracing to be sent to Application Insights by hooking 
        //     Petabridge.Tracing.ApplicationInsights.ApplicationInsightsTracer into the gRPC service definition interceptor. 
        public static ServerServiceDefinition UseApplicationInsights(this ServerServiceDefinition server, string instrumentationKey)
        {
            return server.Intercept(
                new ServerTracingInterceptor(
                    new ApplicationInsightsTracer(
                        new TelemetryConfiguration(instrumentationKey))));
        }
    }
}
