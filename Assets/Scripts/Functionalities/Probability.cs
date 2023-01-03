using System.Collections;
using System.Collections.Generic;
using System.Linq;
using UnityEngine;

public class Probability
{
    public static int GetChoice(List<int> weights){
        int totalWeight = Random.Range(1, weights.Sum(x => x));

        int choice = 0;

        while(totalWeight > 0){
            choice++;
            if(choice == weights.Count) choice = 0;

            totalWeight -= weights[choice];
        }

        Debug.Log($"Choice is {choice}");
        return choice;
    }
}
