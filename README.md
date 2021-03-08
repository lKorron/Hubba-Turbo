# Hubba-Turbo
The mobile game, where the player needs to balance the desk, using plasticine animals. The game goes step by step - the player creating an animal on the left side of the screen and then the computer responding on the right side. After the weight is equalized, the table is automatically set to the default position, the player wins. Below some aspects of the game will be discussed in more detail.
![Level example](/Hubba-Turbo/Assets/ScreenShots/VictoryScreen.png "LevelExample")
Image 1 - Example of balance
## Starting game
To get started, you need to start an _Intro_ scene, although the game will work correctly if you start with scenes from the _Menu_, _StartScreen_, or _Zones_. You can even start the game directly from the level scenes in the _Zone 1_ folder, however, be careful when completing closed levels - __this can cause errors in the progression system__. __Don't run an interface scene__ - it should only work in conjunction with level scenes.
## Progress system
Each level contains three stars - an indicator of the degree of completion.
- __1 star__ - the player has completed level
- __2 stars__ - the player did not let the animals fall or finished the level in 10 seconds
- __3 stars__ - the player did not let the animals fall and finished the level in 10 seconds

After the level has been completed, information about its passage is saved to a binary file, the next level will be opened. If you want to reset all progress, in the _Menu_ scene find gameobject _MenuInfo_ and in the _Menu_ script, check the box next to _IsClearData_. __Do not forget to uncheck the box in the next game session__, otherwise the progress will be cleared again.
![Clear data](/Hubba-Turbo/Assets/ScreenShots/ClearScreen.png "Clear data")
Image 2 - Clearing progress
## Creating levels

# Screenshots
<div>
  <img width="360" height="200" align="left" src="https://github.com/lKorron/Hubba-TurboRep/blob/master/Hubba-Turbo%20New/Assets/ScreenShots/StartScreen.png">
  <img width="360" height="200" align="left" src="https://github.com/lKorron/Hubba-TurboRep/blob/master/Hubba-Turbo%20New/Assets/ScreenShots/LevelsScreen.png">
</div>
<div margin-top = 100>
  <img width="360" height="200" align="left" src="https://github.com/lKorron/Hubba-TurboRep/blob/master/Hubba-Turbo%20New/Assets/ScreenShots/EscapeScreen.png">
  <img width="360" height="200" align="left" src="https://github.com/lKorron/Hubba-TurboRep/blob/master/Hubba-Turbo%20New/Assets/ScreenShots/OctaousScreen.png">
</div>
<div>
  <img width="360" height="200" align="center" src="https://github.com/lKorron/Hubba-TurboRep/blob/master/Hubba-Turbo%20New/Assets/ScreenShots/VictoryScreen.png>
</div>
