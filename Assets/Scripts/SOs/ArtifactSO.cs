using System.Collections;
using System.Collections.Generic;
using UnityEngine;

[CreateAssetMenu(fileName = "newArtifact", menuName = "ArtifactSO")]
public class ArtifactSO : ItemSO
{
    public Stat stat;
    public int boostValue;
}
