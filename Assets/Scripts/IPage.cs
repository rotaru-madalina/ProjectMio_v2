using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public interface IPage
{
    public string Name { get; }
    public string Description { get; }

    public Sprite Picture { get; }

    public void Unlock();

}
