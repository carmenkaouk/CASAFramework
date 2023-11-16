using System.Reflection;

namespace CasaFramework.InterfaceLibrary;

public class ServiceProvider
{
    private Dictionary<Type, Type> _typeResolutionDictionary = new Dictionary<Type, Type>();
    private Dictionary<Type, object> _singletonsContainer = new Dictionary<Type, object>();
    public object? GetService(Type interfaceType)
    {
        Type concreteType = ConcreteTypeResolution(interfaceType);
        if (_singletonsContainer.ContainsKey(concreteType))
        {
            if (_singletonsContainer[concreteType] == null)
            {
                object? service = CreateByReflectionRecursive(concreteType);
                _singletonsContainer[concreteType] = service;
            }
            return _singletonsContainer[concreteType];
        }
        else
        {
            return CreateByReflectionRecursive(concreteType);
        }

    }
    public object? CreateByReflectionRecursive(Type concreteType)
    {
        //Get constructor 
        ConstructorInfo constructor = concreteType.GetConstructors().FirstOrDefault();

        if (constructor != null)
        {
            //get parameter types and create them 
            ParameterInfo[] parametersInfo = constructor.GetParameters();
            List<object> parameters = new List<object>();

            foreach (ParameterInfo parameter in parametersInfo)
            {
                Type parameterType = parameter.ParameterType;
                parameters.Add(GetService(parameterType));

            }
            //invoke constructor
            return Activator.CreateInstance(concreteType, parameters.ToArray());
        }
        return null;
    }

    public Type ConcreteTypeResolution(Type interfaceType)
    {
        return _typeResolutionDictionary[interfaceType];
    }

    public ServiceProvider AddSingleton<T, K>()
    {
        _typeResolutionDictionary[typeof(T)] = typeof(K);
        _singletonsContainer[typeof(K)] = null;
        return this;
    }

    public ServiceProvider AddTransient<T, K>()
    {
        _typeResolutionDictionary[typeof(T)] = typeof(K);
        return this;
    }


}