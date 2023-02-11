using UnityEngine;
using System.Collections;
using System.Collections.Generic;
using System.Linq;

public static class SolarSystemAssembler{
    public static SolarSystemModel GetSolarSystemModel(List<StarObject> starObjects, int seed){
        SolarSystemModel systemModel = new SolarSystemModel {
            Name = starObjects[0].objectName,
            Seed = seed
        };

        List<SolarObjectModel> objectModels = new List<SolarObjectModel>();

        for (int i = 0; i < starObjects.Count; i++)
        {
            objectModels.Add(new SolarObjectModel
            {
                Order = i,
                Name = starObjects[i].objectName
            });
        }

        systemModel.SolarObjects = objectModels;

        return systemModel;
    }
}