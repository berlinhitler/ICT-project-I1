#pragma once

#include "..\Rendering\Scene.hpp"
#include "..\Rendering\Primatives.hpp"
#include "..\Math\SpaceConverter.hpp"
#include "..\GPS\GPSX.hpp"

#define WORLD_SCALE 100*100000
#include <vector>

typedef std::map<time_t, GPSEntry>::iterator it_type;

class Actor {

public:
	Actor();
	~Actor();

public:
	void Initalize(const char* GPSData, double OriginLatitude, double OriginLongitude);
	void Destroy();
	void Update(double delta);
	Renderable* GetRenderable();

// Debugging Functions
public:
	void Step();
	void StepBack();

private:
	void UpdatePoints(double OriginLatitude, double OriginLongitude);

private:
	GPSX gpsData;
	Renderable* renderObject;
	std::vector<glm::vec3> loggedPoints;
	std::vector<double> loggedDistances;
	int drawIndex;
};