#include "Actor.hpp"

/*
==================
Actor::Actor()
==================
*/
Actor::Actor() : gpsData(), renderObject(0), loggedPoints(), realTime(), relativeTime(), loggedDistances(), drawIndex(0), pointIndex(0) {
}

/*
==================
void Actor::Initalize(const char* GPSData, double OriginLatitude, double OriginLongitude)
==================
*/
void Actor::Initalize(const char* GPSData, double OriginLatitude, double OriginLongitude) {
	gpsData.Import(GPSData);
	UpdatePoints(OriginLatitude, OriginLongitude);
	renderObject = new Cube();

	renderObject->SetRealPosition(loggedPoints.front());
	((Cube*)renderObject)->Scale(glm::vec3(0.5f, 0.5f, 0.5f));
	//renderObject->Translate(glm::vec3(2, 2, 2));

	printf("GPS -> Realspace Conversion\n");
	printf("----------------------\n");
	for (unsigned int i = 0; i < loggedPoints.size(); i++) {
		printf("X: %f | Y: %f | Z: %f\n", loggedPoints[i].x, loggedPoints[i].y, loggedPoints[i].z);
	}
	printf("----------------------\n\n");

}

/*
==================
void Actor::Destroy()
==================
*/
void Actor::Destroy() {
	if (renderObject) {
		delete renderObject;
	}
}

/*
==================
void Actor::Update(double delta)
==================
*/
void Actor::Update(double delta) {
}

/*
==================
Renderable* Actor::GetRenderable()
==================
*/
Renderable* Actor::GetRenderable() {
	return renderObject;
}

/*
==================
GPSX* Actor::GetGPSData()
==================
*/
GPSX* Actor::GetGPSData() {
	return &gpsData;
}

/*
==================
void Actor::Step()
==================
*/
void Actor::Step() {
	drawIndex++;

	if (drawIndex == loggedPoints.size()) {
		drawIndex = 0;
	}

	renderObject->SetRealPosition(loggedPoints[drawIndex]);
}

/*
==================
void Actor::StepBack()
==================
*/
void Actor::StepBack() {
	drawIndex--;

	if (drawIndex < 0) {
		drawIndex = loggedPoints.size()-1;
	}

	renderObject->SetRealPosition(loggedPoints[drawIndex]);
}

/*
==================
void Actor::CalculateTimeDifferences()
==================
*/
void Actor::CalculateTimeDifferences() {
	bool baseTimeEstablished = false;
	time_t baseTime = 0;
	time_t prevRealTime = 0;
	printf("----------------------\n");
	printf("      Time Diff       \n");
	printf("----------------------\n");
	for(it_type iterator = gpsData.m_LogData.begin(); iterator != gpsData.m_LogData.end(); iterator++) {
		if (!baseTimeEstablished) {
			relativeTime.push_back(0);
			baseTime = iterator->first;
			prevRealTime = iterator->first;
			baseTimeEstablished = true;
		} else {
			time_t timestep = iterator->first - baseTime;// - prevRealTime;
			relativeTime.push_back(timestep);
			printf("Diffrence %.f | Time Stamp %.d\n", difftime(iterator->first, prevRealTime), iterator->first);
			prevRealTime = iterator->first;
		}
		realTime.push_back(iterator->first);
	}
	printf("----------------------\n\n");
}

/*
==================
glm::vec3 Actor::GetPoint(int phase)
==================
*/
glm::vec3 Actor::GetPoint(int phase) {


	// Used in an incremental system rather than phase
	//if (pointIndex == loggedPoints.size()) {
	//	pointIndex = 0;
	//}

	//glm::vec3 returnVector = loggedPoints[pointIndex];
	//pointIndex++;

	if (phase-1 == -1) {
		return loggedPoints[0];
	}

	glm::vec3 returnVector = loggedPoints[phase-1];

	return returnVector;
}

/*
==================
int Actor::GetPhase(int timePassed)
==================
*/
int Actor::GetPhase(int timePassed) {

	for (unsigned int i = 0; i < relativeTime.size(); i++) {

		int relTime = relativeTime[i];

		if (i+1 == relativeTime.size()) {
			if (relTime = timePassed) {
				return i+1;
			}
		} else if (relTime <= timePassed && relativeTime[i+1] > timePassed) {
			return i+1;
		}

	}

	return 0;
}

/*
==================
int	Actor::GetPhaseTime(int phase)
==================
*/
int	Actor::GetPhaseTime(int phase) {
	if (phase == 0 || phase == relativeTime.size()) {
		return 0;
	}
	return relativeTime[phase] - relativeTime[phase-1];
}

/*
==================
bool Actor::CheckTimeBounds(clock_t dt, time_t baseTime)
==================
*/
bool Actor::CheckTimeBounds(clock_t dt, time_t baseTime) {
	int secondsPastBase = ((double)dt)/CLOCKS_PER_SEC;
	if (baseTime <= realTime[0]) {
		double maxBounds = baseTime + secondsPastBase;
		//printf("secondsPastBase: %d | baseTime: %d | realTime[0]: %d | maxBounds %d\n", secondsPastBase, baseTime, realTime[0], maxBounds);
		if (maxBounds >= realTime[0]) {
			return true;
		}
	}
	return false;
}

/*
==================
void Actor::Move(glm::vec3 direction, double distance, double delta, double movetime);
==================
*/
void Actor::Move(glm::vec3 direction, double distance, double delta, double movetime) {
	//glm::vec3 translateVector;
	//
	//translateVector.x = (distance.x / (delta * movetime) * WORLD_SCALE);
	//translateVector.y = (distance.y / (delta * movetime) * WORLD_SCALE);
	//translateVector.z = 0;//distance.z / (delta * movetime);

	//renderObject->Translate(translateVector);

	//glm::vec3 a = glm::normalize(direction);

	//glm::vec3 translateVector(-(direction.x / (delta * movetime)), 0, -(direction.y / (delta * movetime)));

	renderObject->Translate(direction);
}

/*
==================
void Actor::UpdatePoints(double OriginLatitude, double OriginLongitude)
==================
*/
void Actor::UpdatePoints(double OriginLatitude, double OriginLongitude) {

	int index = 0;
	for(it_type iterator = gpsData.m_LogData.begin(); iterator != gpsData.m_LogData.end(); iterator++) {

		double CurrentDistance = WS_GetDistanceBetween(OriginLatitude, OriginLongitude, iterator->second.m_Latitude, iterator->second.m_Longitude);
		double x, y;

		WS_RealSpace(OriginLatitude, OriginLongitude, 
						 iterator->second.m_Latitude, iterator->second.m_Longitude, 
						 &x, &y);

		loggedPoints.push_back(glm::vec3(x*WORLD_SCALE, 0, y*WORLD_SCALE));
		loggedDistances.push_back(CurrentDistance);
		index++;
	}
}

/*
==================
Actor::~Actor()
==================
*/
Actor::~Actor() {
}