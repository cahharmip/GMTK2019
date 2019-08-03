using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class ResourceLoadManager : MonoBehaviour
{
  private static Dictionary<string, GameObject> LoadedGameObject = new Dictionary<string, GameObject>();
  private static Dictionary<string, Sprite> LoadedSprite   = new Dictionary<string, Sprite>();

  public static GameObject LoadGameObject(string path)
  {
    if (LoadedGameObject.ContainsKey(path))
    {
      return LoadedGameObject[path];
    }
    else
    {
      LoadedGameObject[path] = Resources.Load<GameObject>(path);
      return LoadedGameObject[path];
    }
  }

  public static Sprite LoadSprite(string path)
  {
    if (LoadedSprite.ContainsKey(path))
    {
      return LoadedSprite[path];
    }
    else
    {
      LoadedSprite[path] = Resources.Load<Sprite>(path);
      return LoadedSprite[path];
    }
  }
}
