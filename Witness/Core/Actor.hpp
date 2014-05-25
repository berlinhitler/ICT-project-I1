#pragma once

#include "..\Rendering\Scene.hpp"
#include "..\Rendering\Primatives.hpp"
#include "..\Math\SpaceConverter.hpp"
#include "..\GPS\GPSX.hpp"

#define W_CONSTANT	100000
#define W_MM		1*W_CONSTANT
#define W_CM		10*W_CONSTANT
#define W_M			100*W_CONSTANT
#define W_KM		1000*W_CONSTANT
#define WORLD_SCALE 100*W_CONSTANT

#include <vector>
#include <time.h>
#include <glm\geometric.hpp>

typedef std::map<time_t, GPSEntry>::iterator it_type;

class Actor {

public:
	Actor();
	~Actor();

public:
	void			Initalize(const char* GPSData, double OriginLatitude, double OriginLongitude);
	void			Destroy();
	void			Update(double delta);
	Renderable*		GetRenderable();
	GPSX*			GetGPSData();

// Debugging Functions
public:
	void			Step();
	void			StepBack();

// Translation Functions
public:
	void			CalculateTimeDifferences();
	glm::vec3		GetPoint(int phase);
	int				GetPhase(int timePassed);
	int				GetPhaseTime(int phase);
	bool			CheckTimeBounds(clock_t dt, time_t baseTime);
	void			Move(glm::vec3 direction, double distance, double delta, double movetime);

private:
	void			UpdatePoints(double OriginLatitude, double OriginLongitude);

private:
	GPSX					gpsData;
	Renderable*				renderObject;
	std::vector<glm::vec3>	loggedPoints;
	std::vector<time_t>		realTime;
	std::vector<time_t>		relativeTime;
	std::vector<double>		loggedDistances;
	int						drawIndex;
	int						pointIndex;
};