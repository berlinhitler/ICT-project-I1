#include <Windows.h>
#include <list>

#include "..\Rendering\Window.hpp"
#include "..\GPS\GPSX.hpp"
#include "..\Math\SpaceConverter.hpp"
#include "..\Rendering\Scene.hpp"
#include "..\Rendering\Primatives.hpp"
#include "..\Core\Actor.hpp"
#include "..\PGR\StreamPGR.hpp"
#include "..\Math\EventTimer.hpp"

Window mapWindow;
Actor testActor;
Actor testActor2;
Scene backyardScene;
GridLines backyardGrid;
EventTimer eventTimer;

void PrintDistances(Actor* actorDetails);

int main() {

	// Window to draw everything too
	mapWindow.Show();

	// Initalize our actors
	testActor.Initalize("8_Apr_2014_12_26_04.gpx", -34.78342726, 138.71205082);
	testActor2.Initalize("20140515153032.gpx", -34.78342726, 138.71205082);
	backyardScene.Insert(testActor.GetRenderable());
	backyardScene.Insert(testActor2.GetRenderable());
	backyardScene.Insert(&backyardGrid);
	mapWindow.currentScene = &backyardScene;

	// Initalize the captured recording
	StreamPGR cameraStream("ladybug_11501046_20140319_014241-000000.pgr");
	eventTimer.RegisterActor(&testActor);
	eventTimer.RegisterActor(&testActor2);

	bool ToggleFlag = false;
	bool ToggleLeft = false;
	bool ToggleRight = false;

	PrintDistances(&testActor);
	PrintDistances(&testActor2);

	testActor.CalculateTimeDifferences();

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

	//double step = 0.015;
	//double dt = 0.03;
	//double time = 0.0;

	//while (time < 2) {

	//	time += 0.0015;
	//	step += 0.00015;

	//	printf("Time: %f | Step: %f\n", time, step);
	//}
}

void PrintDistances(Actor* actorDetails) {

	GPSX* actorGPSData = actorDetails->GetGPSData();
	std::map<time_t, GPSEntry>* GPSData = &actorGPSData->m_LogData;

	double previouseLattitude = 0;
	double previouseLongitude = 0;
	time_t previouseTime = 0;

	for(std::map<time_t, GPSEntry>::iterator iter = GPSData->begin(); iter != GPSData->end(); ++iter) {

		if (!previouseLattitude) {
			previouseLattitude = iter->second.m_Latitude;
		}

		if (!previouseLongitude) {
			previouseLongitude = iter->second.m_Longitude;
		}

		if (!previouseTime) {
			previouseTime = iter->first;
		}

		double currentLattitude = iter->second.m_Latitude;
		double currentLongitude = iter->second.m_Longitude;

		double timeDifference = difftime(iter->first, previouseTime);

		double distance = WS_GetDistanceBetween(previouseLattitude, previouseLongitude, iter->second.m_Latitude, iter->second.m_Longitude);

		previouseLattitude = iter->second.m_Latitude;
		previouseLongitude = iter->second.m_Longitude;
		previouseTime = iter->first;

		printf("Time: %f Distance: %f\n", timeDifference, distance);
	}

	printf("\n\n");

}