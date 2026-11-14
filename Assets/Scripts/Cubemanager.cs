using System.Collections.Generic;
using System.IO.Enumeration;
using UnityEngine;


[CreateAssetMenu (fileName ="CubeData", menuName = "CubeGenerator/CubeData",order =1)]
public class Cubemanager : ScriptableObject
{
    public string TileName;
    public List<Material> TileMaterials;


}
