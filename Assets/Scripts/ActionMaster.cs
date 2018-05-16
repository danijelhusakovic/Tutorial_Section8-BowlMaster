﻿using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class ActionMaster {

	public enum Action { Tidy, Reset, EndTurn, EndGame };

	// private int[] bowls = new int[21];
	private int bowl = 1;

	public Action Bowl (int pins){

		if(pins < 0 || pins > 10){ throw new UnityException ("Invalid number of pins"); }

		// Other behavior here

		if(pins == 10){
			bowl += 2;
			return Action.EndTurn;
		}

		if (bowl % 2 != 0){ // Mid frame or last frame (it's not end of frame)
			bowl += 1;
			return Action.Tidy;
		} else if (bowl % 2 == 0){ // End of frame
			bowl += 1;
			return Action.EndTurn;
		}


		throw new UnityException ("Not sure what action to return!"); // hope it never reaches this line :)

	}

}
