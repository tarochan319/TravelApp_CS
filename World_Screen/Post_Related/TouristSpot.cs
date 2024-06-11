using System.Collections;
using System.Collections.Generic;
using UnityEngine;

[System.Serializable]
public class TouristSpot
{
    public int id;
    public string name;
    public string description;
    public string location;
    public string created_at;
}

[System.Serializable]
public class TouristSpotList
{
    public List<TouristSpot> spots;
}
