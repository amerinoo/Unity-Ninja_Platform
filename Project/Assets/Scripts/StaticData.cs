using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class StaticData : MonoBehaviour
{
	public static float time = 100;

	public static string level = "1";
	public static string character = "IceWizard";

	public static int mainScreen = 0;
	public static int selectScreen = 1;
	public static int gameScreen = 2;
	public static int creditsScreen = 3;

	// Use this for initialization
	void Start ()
	{
		
	}
	
	// Update is called once per frame
	void Update ()
	{
	}

	public static string GetCredits ()
	{
		return 
			"***Programmers***\n" +
		"Albert Eduard Merino Pulido\n\n\n\n" +
		"***Fonts***\n" +
		"https://www.dafont.com/es/orange-juice.font\n" +
		"https://www.dafont.com/super-mario-256.font\n\n\n\n" +
		"***Sprites***\n" +
		"https://goo.gl/vrTy5u (Goomba)\n" +
		"https://www.redbubble.com/es/people/syrensong/works/21824093-8-bit-heart?p=sticker\n" +
		"https://www.gameart2d.com/ninja-adventure---free-sprites.html\n" +
		"https://www.gameart2d.com/free-platformer-game-tileset.html\n" +
		"https://www.gameart2d.com/winter-platformer-game-tileset.html\n" +
		"https://www.gameart2d.com/santa-claus-free-sprites.html\n" +
		"https://www.gameart2d.com/the-zombies-free-sprites.html\n" +
		"https://opengameart.org/content/game-characters-flying-birds-attack-sprite-sheets\n" +
		"https://craftpix.net/freebies/free-horizontal-2d-game-backgrounds/\n" +
		"https://craftpix.net/freebies/2d-game-zombie-character-free-sprite-pack-1/\n" +
		"https://craftpix.net/freebies/2d-game-zombie-kids-character-free-sprite-8/\n" +
		"https://craftpix.net/freebies/2d-game-zombie-character-free-sprite-4/\n" +
		"https://craftpix.net/freebies/2d-fantasy-orcs-free-sprite-sheets/\n\n\n\n" +
		"***Music***\n" +
		"https://www.youtube.com/watch?v=zCLQHbTK_84&t=2348\n" +
		"https://www.youtube.com/watch?v=JTzX_khHmuo\n" +
		"https://www.youtube.com/watch?v=2SEYjNlLDPs\n" +
		"https://www.youtube.com/watch?v=r5X8qDDMC-o\n" +
		"https://www.youtube.com/watch?v=MlrFixkakaA\n" +
		"https://gamethemesongs.com/\n\n\n\n" +
		"***Professors***\n" +
		"Santiago Martínez Rodríguez\n\n\n\n" +
		"***Author***\n" +
		"Albert Eduard Merino Pulido\n" +
		"https://github.com/amerinoo/Unity-Ninja-Platform\n\n\n\n" +
		"***Subject information***\n" +
		"Mobile game developing\n" +
		"Academic year 2017-18\n" +
		"University of Lleida";


	}
}
