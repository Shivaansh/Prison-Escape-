using UnityEngine;
using UnityEngine.UI;
using System.Collections;

public class TextController : MonoBehaviour {

	public Text text;
	int gun;
	string weapon;
	private enum States {cell, hallway, courtyard, NewHall, EscapeDoor, Freedom};
	private States myState;

	// Use this for initialization
	void Start () {
		StartGame ();
		
	}
	
	// Update is called once per frame
	void Update () {
		print (myState);
		
		if (Input.GetKeyDown (KeyCode.Space)){
			text.text = "You have decided to escape from prison? Now, there is no turning back. Press <Enter> to continue.";
		}
		
		if (Input.GetKey (KeyCode.Return)){
		State_Cell ();
		}
		
		if (Input.GetKey (KeyCode.Keypad1)){
			weapon = "m";
			myState = States.hallway;
		}else if(Input.GetKeyDown (KeyCode.Keypad2)){
			weapon = "b";
			myState = States.hallway;
		}
		
		print (weapon);
		
		if(myState == States.hallway){State_hallway ();}
		//for the hallway, we have the option to attack or sneak past the patrolling guard
		if(Input.GetKeyDown (KeyCode.A)){
			if(weapon == "m"){
			myState = States.courtyard;
			weapon = "0";
			}else if(weapon=="b"){
			State_courtyard ();
			myState = States.courtyard;
			weapon = "0";
			}
		}else if(Input.GetKeyDown (KeyCode.B)){
		myState = States.courtyard;
		print(weapon);
		}//we now arrive in the courtyard
		
		if(myState==States.courtyard){State_courtyard ();}
		//in this stage we encounter the guard with a gun
		if(Input.GetKeyDown (KeyCode.C)){
			if(weapon == "m"){
				myState = States.NewHall;
				weapon = "0";
				gun = 1;
			}else if(weapon=="b"){
				State_courtyard ();
				myState = States.NewHall;
				weapon = "0";
				gun = 1;
			}else{
				text.text = "Uh-oh! You attacked the guard without a weapon and were caught! Press <Enter> to try again!";
				myState = States.cell;
			}
		}else if(Input.GetKeyDown (KeyCode.D)){
			text.text = "Uh-oh! You have been caught by the armed guard's thermal vision! Press <Enter> to try again!";
			myState = States.cell;
		}
		 //this is for the armed guard. now we have two stages left
		if(myState==States.NewHall){State_NewHall ();}
		
		if(Input.GetKey (KeyCode.E)){
			gun = 0;
			myState = States.EscapeDoor;
		}else if(Input.GetKeyDown (KeyCode.F)){
			myState = States.EscapeDoor;
		}//we are now moving to the escape door
		
		if(myState==States.EscapeDoor){State_EscapeDoor();} //we now enter the code for what happens when we press 'G'
		
		if(Input.GetKey (KeyCode.G)){
			if(gun==1){
				text.text = "You are now FREE!!";
				myState = States.Freedom;
			}else{
				text.text = "The guard caught your bluff and raised the alarm! Press <Enter> to try again!";
				myState = States.cell;
			}
		}
		
			
}
	#region State Handler Methods
//***************************************************************************************************************
//I shall define all our methods from the following lines.
	void StartGame(){//Executed at the beginning of the game
		text.text = "You are in hell.\n Escape is impossible.\n You will be hanged for crimes you did not commit.\n Will you sit back and give up on" +
			" life, or will you <Press Space> and do the impossible?";
		myState = States.cell;
		
	}
	void State_Cell(){//ideally, the prisoner is in the cell when this method is executed.
		text.text = "In your gloomy cell, you see a mirror, a dirty bedsheet and some wet tissues. \n Press <1> for mirror, <2> for bedsheets.\n" +
			        "Your cell door has mysteriously opened.";

	}//this is executed in the next stage
	void State_hallway(){
		text.text = "You see a guard on patrol. Press <A> to attack and <B> to sneak past.";
	}//on this stage the player encounters a guard with gun
	void State_courtyard(){
		text.text = "You see an armed guard standing in front of you. Press <C> to hit with a weapon and <D> to try and sneak past him.";
	
	}//now the player has a gun
	void State_NewHall(){
		text.text = "You have picked up a silenced gun from the armed guard!\nYou see two patrolling guards approaching.\n" + 
		"Press <E> to shoot them with the gun or <F> to wait for them to pass.";
	}// if the player has ammo in the gun, only then is escape possible, in this stage
	void State_EscapeDoor(){
		text.text = "You have arrived at the escape door, however there is a guard present! \n" + 
			        "Press <G> to threaten the guard with the gun and ask him to open the door.";
	}

#endregion
}
	





















	


