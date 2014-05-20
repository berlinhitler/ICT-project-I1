#include <Windows.h>
#include <list>

#include "..\Rendering\Window.hpp"
#include "..\GPS\GPSX.hpp"
#include "..\Math\SpaceConverter.hpp"

#include "..\Rendering\Scene.hpp"
#include "..\Rendering\Primatives.hpp"

#include "..\Core\Actor.hpp"

Window mapWindow;
Actor testActor;
Actor testActor2;
Scene backyardScene;
GridLines backyardGrid;

int main() {
	mapWindow.Show();
	testActor.Initalize("8_Apr_2014_12_26_04.gpx", -34.78342726, 138.71205082);
	testActor2.Initalize("20140515153032.gpx", -34.78342726, 138.71205082);
	backyardScene.Insert(testActor.GetRenderable());
	backyardScene.Insert(testActor2.GetRenderable());
	backyardScene.Insert(&backyardGrid);
	mapWindow.currentScene = &backyardScene;

	bool ToggleFlag = false;
	bool ToggleLeft = false;
	bool ToggleRight = false;

	while (mapWindow.isRunning()) {
		mapWindow.Update();

		if (mapWindow.inputHandle->MouseX != 0) {
			if (mapWindow.inputHandle->MouseX < 0) {
				backyardScene.targetCamera->Right();
			} else {
				backyardScene.targetCamera->Left();
			}
			mapWindow.inputHandle->MouseX = 0;
		}

		if (mapWindow.inputHandle->MouseY != 0) {
			if (mapWindow.inputHandle->MouseY < 0) {
				backyardScene.targetCamera->Down();
			} else {
				backyardScene.targetCamera->Up();
			}
			mapWindow.inputHandle->MouseY = 0;
		}

		if (mapWindow.inputHandle->Keys[GLFW_KEY_W] == PRESSED || mapWindow.inputHandle->Keys[GLFW_KEY_W] == HELD) {
			backyardScene.targetCamera->Forward();
		}

		if (mapWindow.inputHandle->Keys[GLFW_KEY_S] == PRESSED || mapWindow.inputHandle->Keys[GLFW_KEY_S] == HELD) {
			backyardScene.targetCamera->Backward();
		}

		if (mapWindow.inputHandle->JoyRight && ToggleRight != true) {
			testActor.Step();
			testActor2.Step();
			ToggleRight = true;
		}

		if (mapWindow.inputHandle->JoyRight == false) {
			ToggleRight = false;
		}

		if (mapWindow.inputHandle->JoyLeft && ToggleLeft != true) {
			testActor.StepBack();
			testActor2.StepBack();
			ToggleLeft = true;
		}

		if (mapWindow.inputHandle->JoyLeft == false) {
			ToggleLeft = false;
		}

	}
}