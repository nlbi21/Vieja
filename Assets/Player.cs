using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class Player {

	public string name;
	public InputField mov;
	public Game game;
	public int temp = 0;
	public bool good = false;

	public void play(){

		if(mov.text != null){
			temp = int.Parse(mov.text);

			if(temp < 9 || temp >= 0){

				if(game.mapa[temp] == 0){
					game.mapa[temp] = 1;

					good = true;

					Debug.Log("Haz hecho tu movimiento en la posición: " + temp);
				}else{
					Debug.Log("La posición esta en uso por el Player " + game.mapa[temp].ToString());

					good = false;

				}

			}

		}else{
			Debug.Log("Por favor haga su movimiento.");

			good = false;
		}
	}
	
}
