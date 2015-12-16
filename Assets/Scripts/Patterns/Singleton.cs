using System;
using UnityEngine;

public abstract class Singleton<T> : MonoBehaviour where T : MonoBehaviour
{
    private static T _instance;
    private static bool _instantiated;

    public static T Instance
    {
        get
        {
            if (_instantiated) return _instance;

            var type = typeof(T);
            var objects = FindObjectsOfType<T>();

            if (objects.Length > 0)
            {
                Instance = objects[0];
                if (objects.Length > 1)
                {
                    Debug.LogWarning("There is more than one instance of Singleton of type \"" + type + "\". Keeping the first. Destroying the others.");
                    for (var i = 1; i < objects.Length; i++) DestroyImmediate(objects[i].gameObject);
                }
                _instantiated = true;
                return _instance;
            }

            var attribute = Attribute.GetCustomAttribute(type, typeof(PrefabAttribute)) as PrefabAttribute;
            if (attribute == null)
            {
                Debug.LogError("There is no Prefab Atrribute for Singleton of type \"" + type + "\".");
                return null;
            }
            var prefabName = attribute.Name;
            if (String.IsNullOrEmpty(prefabName))
            {
                Debug.LogError("Prefab name is empty for Singleton of type \"" + type + "\".");
                return null;
            }

            var gameObject = Instantiate(Resources.Load<GameObject>(prefabName)) as GameObject;
            if (gameObject == null)
            {
                Debug.LogError("Could not find Prefab \"" + prefabName + "\" on Resources for Singleton of type \"" + type + "\".");
                return null;
            }
            gameObject.name = prefabName;
            Instance = gameObject.GetComponent<T>();
            if (!_instantiated)
            {
                Debug.LogWarning("There wasn't a component of type \"" + type + "\" inside prefab \"" + prefabName + "\". Creating one.");
                Instance = gameObject.AddComponent<T>();
            }
            if (attribute.Persistent)
                DontDestroyOnLoad(_instance.gameObject);
            return _instance;
        }

        private set
        {
            _instance = value;
            _instantiated = value != null;
        }
    }

    private void OnDestroy() { _instantiated = false; }
}

[AttributeUsage(AttributeTargets.Class, Inherited = true)]
public class PrefabAttribute : Attribute
{
    public readonly string Name;
    public readonly bool Persistent;

    public PrefabAttribute(string name, bool persistent)
    {
        Name = name;
        Persistent = persistent;
    }

    public PrefabAttribute(string name)
    {
        Name = name;
        Persistent = false;
    }
}
