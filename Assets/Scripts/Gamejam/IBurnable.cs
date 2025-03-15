using System.Collections;
using UnityEngine;

public interface IBurnable
{
    void Burn();
    IEnumerator HandleBurn();
}
