
using CasaFramework.InterfaceLibrary.BaseClasses;
using CasaFramework.InterfaceLibrary.Interfaces;
using Newtonsoft.Json;
using Newtonsoft.Json.Linq;
using System.Collections;
using System.Reflection;


namespace CasaFramework.InterfaceLibrary.Middlewares;

internal class ParameterExtractionMiddleware : BaseMiddleware
{
    public override void Process(Context context)
    {
        ArrayList parameters = new ArrayList();
        ParameterInfo[] parameterInfo = ((MethodInfo)context.Get("MethodInfo")).GetParameters();
        foreach (var paramInfo in parameterInfo)
        {
            Type type = paramInfo.ParameterType;
            var content = ((IRequest)context.Get("Request")).GetContent();
            if (content[paramInfo.Name] is JObject jObjectParameter)
            {
                object deserializedParameter = JsonConvert.DeserializeObject(jObjectParameter.ToString(), type);
                parameters.Add(deserializedParameter);
            }
            else if (type.IsEnum)
            {
                parameters.Add(Enum.ToObject(type, content[paramInfo.Name]));
            }
            else
            {
                parameters.Add(Convert.ChangeType(content[paramInfo.Name], type));
            }
        }
        context.Add("Parameters", parameters.ToArray());
        Next.Process(context);
    }
}
