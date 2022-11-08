using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public interface IDataHandler
{
    public GameData Load();
    public void Save(GameData data);
}
