using System.Reflection;

namespace CASAFramework; 

public class ServiceProvider
{
    private Dictionary<Type, Type> _TypeResolutionDictionary = new Dictionary<Type, Type>();
    private Dictionary <Type, Object> _singletonsContainer = new Dictionary <Type, Object> ();
    public object? getService(Type InterfaceType)
    {
        Type ConcreteType = ConcreteTypeResolution(InterfaceType);
        if (_singletonsContainer.ContainsKey(ConcreteType))
        {
            if (_singletonsContainer[ConcreteType] == null)
            {
                object? service = CreateByReflectionRecursive(ConcreteType);
                _singletonsContainer[ConcreteType] = service; 
            }
            return _singletonsContainer[ConcreteType];
        }
        else
        {
            return CreateByReflectionRecursive(ConcreteType);
        }

    }
    public object? CreateByReflectionRecursive(Type ConcreteType)
    {
        //Get constructor 
        ConstructorInfo constructor = ConcreteType.GetConstructors().FirstOrDefault();

        if (constructor != null)
        {
            //get parameter types and create them 
            ParameterInfo[] parametersInfo = constructor.GetParameters();
            List<object> parameters = new List<object>();

            foreach (ParameterInfo parameter in parametersInfo)
            {
                Type parameterType = parameter.ParameterType;
                parameters.Add(getService(parameterType));

            }
            //invoke constructor
            return Activator.CreateInstance(ConcreteType, parameters.ToArray());
        }
        return null; 
    }

    public Type ConcreteTypeResolution (Type InterfaceType)
    {
        return _TypeResolutionDictionary[InterfaceType];
    }

    public ServiceProvider AddSingleton<T, K>()
    {
        _TypeResolutionDictionary[typeof(K)] = typeof(T);
        _singletonsContainer[typeof(T)] = null; 
        return this; 
    }

    public ServiceProvider AddTransient<T, K>()
    {
        _TypeResolutionDictionary[typeof(K)] = typeof(T);
        return this; 
    }


}
