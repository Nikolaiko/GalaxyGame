using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class TimedStarsRatingManager : MonoBehaviour, StarRatingManager
{
    private const int FIRST_LEVEL_3_STARS = 2000;
    private const int SECOND_LEVEL_3_STARS = 2000;
    private const int THIRD_LEVEL_3_STARS = 2000;
    private const int FOURTH_LEVEL_3_STARS = 2000;

    private int[] maxRatingValues = {
        FIRST_LEVEL_3_STARS,
        SECOND_LEVEL_3_STARS,
        THIRD_LEVEL_3_STARS,
        FOURTH_LEVEL_3_STARS
    };

    public int GetStarsRating(int levelNumber, int levelScore, float userHealth)
    {
        if (levelNumber <= maxRatingValues.Length && levelNumber > 0) {
            if (levelScore >= maxRatingValues[levelNumber - 1]) {
                if (userHealth == SpaceShip.MAX_HEALTH) {
                    return 3;
                } else {
                    return 2;
                }        
            } else {
                return 1;
            }
        } else {
            throw new UnityException("Wrong level number");
        }        
    }
}
