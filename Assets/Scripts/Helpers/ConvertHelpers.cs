using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class ConvertHelpers
{
    public static LevelState LevelStateFromRating(int rating) {
        switch(rating) {
            case 0: 
                return LevelState.notCompleted;
            case 1: 
                return LevelState.completedOneStar;
            case 2: 
                return LevelState.completedTwoStarts;
            case 3: 
                return LevelState.completedThreeStars;
            default:
                return LevelState.notAvailable;
        }
    }
}
