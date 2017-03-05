using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;
using UnityEngine.SceneManagement;

public class Game : MonoBehaviour {
Player player1 = new Player();
//Player player2 = new Player();

// Array mapa, sí el valor es 0 esta libre, 1 player-1, 2 player-2.
 public int[] mapa = new int[9];
 public Button btn_play;
 public int posLibres = 9;
 public int turn = 0;
 public GameObject[] posiciones;
 public Material[] materials;
 public GameObject[] signos;
 public Text textGanador;
 public GameObject GOGanador;
 public GameObject[] GORayas;
 public Text textPlayer;
 bool boolean = true;
 bool winPlayer1 = false, winPlayer2 = false;

 void Awake()
 {
	for(int i = 0; i < GORayas.Length; i++){
		GORayas[i].SetActive(false);
	}

	GOGanador.SetActive(false);
 }

 void Start()
 {
	 // Inicializacimos todos en 0 al principio de la partida,
	 //	esto se puede hacer igualmente en el test.
	 for(int i = 0; i < mapa.Length; i++){
		mapa[i] = 0;
	 }

	 player1.name = "Player 1";
	 player1.mov = GameObject.Find("InputField").gameObject.GetComponent<InputField>();
	 player1.game = this.GetComponent<Game>();

	 //player2.name = "Player 2";
	 //player2.mov = GameObject.Find("InputField").gameObject.GetComponent<InputField>();

	 turn = Random.Range(1,3);
	 if(turn == 2){
		btn_play.interactable = false;
	 }
 }

 public void Test(){
	numZeros();

	if(posLibres > 0){
		while(posLibres > 0 && winPlayer1 == false && winPlayer2 == false){
			if(turn == 1){
				Debug.Log("Turno: Player " + turn);
				player1.play();
					if(player1.good == true){
						GameObject go = Instantiate(signos[0], posiciones[player1.temp].transform.position, Quaternion.identity);
						go.GetComponent<Renderer>().material = materials[0];
						btn_play.interactable = false;
						turn = 2;
						break;
					}else{
						btn_play.interactable = true;
						turn = 1;
						break;
					}
			}else{
				boolean = false;
				while(boolean == false){
					int temp = Random.Range(0,9);
					
					if(mapa[temp] == 0){
						mapa[temp] = 2;
						GameObject go = Instantiate(signos[1], posiciones[temp].transform.position, Quaternion.identity);
						go.gameObject.transform.FindChild("X1").GetComponent<Renderer>().material = materials[1];
						go.gameObject.transform.FindChild("X2").GetComponent<Renderer>().material = materials[1];
						boolean = true;
					}
					if(boolean == true){
						Debug.Log("PC ha hecho su movimiento en la posición: " + temp);
					}
				}
				
				break;
			}
		}	
	}else{
		Debug.Log("No quedan movimientos libres");
	}

	Ganador();

 }

 void Update(){
	 if(turn == 2 && posLibres > 0){
		StartCoroutine(WaitLittle());
	 }

	 if(Input.GetKey(KeyCode.Escape)){
		Application.Quit();
	 }

	 if(turn == 1){
		textPlayer.text = "Player 1";
	 }else{
		textPlayer.text = "Player 2";
	 }
	 numZeros();

	 if(winPlayer1 == true){

		GOGanador.SetActive(true);
		textGanador.text = "Player 1 gana!";
		btn_play.interactable = false;

	 }else if(winPlayer2 == true){
		 
		GOGanador.SetActive(true);
		textGanador.text = "Player 2 gana!";
		btn_play.interactable = false;

	 }else if(posLibres == 0){

		GOGanador.SetActive(true);
		textGanador.text = "Nadie gana xD!";
		btn_play.interactable = false;

	 }
 }

 void Ganador(){
	if(mapa[0] == mapa[1] && mapa[1] == mapa[2]){
		
		if(mapa[0] == 1){
			winPlayer1 = true;
		}else if(mapa[0] == 2){
			winPlayer2 = true;
		}

		if(winPlayer1 == true || winPlayer2 == true){
			GORayas[0].SetActive(true);
		}

	}else if(mapa[3] == mapa[4] && mapa[4] == mapa[5]){
		if(mapa[3] == 1){
			winPlayer1 = true;
		}else if(mapa[3] == 2){
			winPlayer2 = true;
		}
		if(winPlayer1 == true || winPlayer2 == true){
			GORayas[1].SetActive(true);
		}
		
	}else if(mapa[6] == mapa[7] && mapa[7] == mapa[8]){
		if(mapa[6] == 1){
			winPlayer1 = true;
		}else if(mapa[6] == 2){
			winPlayer2 = true;
		}

		if(winPlayer1 == true || winPlayer2 == true){
			GORayas[2].SetActive(true);
		}

	}else if(mapa[0] == mapa[4] && mapa[4] == mapa[8]){
		if(mapa[8] == 1){
			winPlayer1 = true;
		}else if(mapa[8] == 2){
			winPlayer2 = true;
		}

		if(winPlayer1 == true || winPlayer2 == true){
			GORayas[7].SetActive(true);
		}
		
	}else if(mapa[2] == mapa[4] && mapa[4] == mapa[6]){
		if(mapa[2] == 1){
			winPlayer1 = true;
		}else if(mapa[2] == 2){
			winPlayer2 = true;
		}

		if(winPlayer1 == true || winPlayer2 == true){
			GORayas[6].SetActive(true);
		}

	}else if(mapa[0] == mapa[3] && mapa[3] == mapa[6]){
		if(mapa[3] == 1){
			winPlayer1 = true;
		}else if(mapa[3] == 2){
			winPlayer2 = true;
		}
		if(winPlayer1 == true || winPlayer2 == true){
			GORayas[3].SetActive(true);
		}

	}else if(mapa[1] == mapa[4] && mapa[4] == mapa[7]){
		if(mapa[4] == 1){
			winPlayer1 = true;
		}else if(mapa[4] == 2){
			winPlayer2 = true;
		}

		if(winPlayer1 == true || winPlayer2 == true){
			GORayas[4].SetActive(true);
		}

	}else if(mapa[2] == mapa[5] && mapa[5] == mapa[8]){
		if(mapa[5] == 1){
			winPlayer1 = true;
		}else if(mapa[5] == 2){
			winPlayer2 = true;
		}

		if(winPlayer1 == true || winPlayer2 == true){
			GORayas[5].SetActive(true);
		}
	}
 }

 public void Restart(){
	SceneManager.LoadScene(SceneManager.GetActiveScene().buildIndex);
 }

  IEnumerator WaitLittle() {
        yield return new WaitForSeconds(2);
		if(turn == 2 && posLibres > 0){
		 	Debug.Log("Turno: Player " + turn);
		 	Test();
			turn = 1;
			btn_play.interactable = true;
		}
    }

 void numZeros(){

	posLibres = 0;

	 for(int i = 0; i < mapa.Length; i++){
		 if(mapa[i] == 0){
			posLibres++;
		 }
	 }

	 Debug.Log("posLibres: " + posLibres);
 }
		
}
