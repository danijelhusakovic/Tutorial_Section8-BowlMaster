using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class ScoreMaster {

	// Returns a list of cumulative scores, like a normal score card.
	public static List<int> ScoreCumulative (List<int> rolls){
		List<int> cumulativeScores = new List<int> ();
		int runningTotal = 0;

		foreach(int frameScore in ScoreFrames (rolls)){
			runningTotal += frameScore;
			cumulativeScores.Add(runningTotal);
		}

		return cumulativeScores;
	}

	// Returns a list of individual frame scores, NOT cumulative.
	public static List<int> ScoreFrames (List<int> rolls) {
		List <int> frames = new List <int> ();

		for (int i = 1; i < rolls.Count; i+= 2){

			if(rolls[i - 1] + rolls[i] < 10){	// Normal "open" frame
				frames.Add (rolls[i - 1] + rolls[i]);
			}

			if(rolls.Count - i <= 1) {			// Insufficient look-ahead
				break;
			}

			if(rolls[i - 1] + rolls[i] == 10){	// Calculate Spare bonus
				frames.Add (10 + rolls[i + 1]);
			}
		}

		return frames;
	}
}
