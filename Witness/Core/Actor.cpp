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
	for(it_type iterator = gpsData.m_LogData.begin(); iterator != gpsData.m_LogData.end(); iterator++) {
		if (!baseTimeEstablished) {
			relativeTime.push_back(0);
			baseTime = iterator->first;
			prevRealTime = iterator->first;
			baseTimeEstablished = true;
		} else {
			time_t timestep = iterator->first - prevRealTime;
			relativeTime.push_back(timestep);
			printf("%.f | %.d\n", difftime(iterator->first, prevRealTime), iterator->first);
			prevRealTime = iterator->first;
		}
		realTime.push_back(iterator->first);
	}
}

/*
==================
glm::vec3 Actor::GetNextPoint()
==================
*/
glm::vec3 Actor::GetNextPoint() {
	if (pointIndex == loggedPoints.size()) {
		pointIndex = 0;
	}
	glm::vec3 returnVector = loggedPoints[pointIndex];
	pointIndex++;
	return returnVector;
}

/*
==================
bool Actor::CheckTimeBounds(clock_t dt, time_t baseTime)
==================
*/
bool Actor::CheckTimeBounds(clock_t dt, time_t baseTime) {
	float secondsPastBase = ((float)dt)/CLOCKS_PER_SEC;
	if (baseTime <= realTime[0]) {
		double maxBounds = baseTime + secondsPastBase;
		if (maxBounds > realTime[0]) {
			return true;
		}
	}
	return false;
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