#pragma once

#ifndef _CAMERA_HPP_
#define _CAMERA_HPP_

/*
===============================================================================

	Camera - VP of the MVP
	Author - Joshua Richardson

===============================================================================
*/

#include "glm\vec3.hpp"
#include "glm\vec2.hpp"

class Camera {

public:
	Camera();
	~Camera();

public:
	void Update();

	void Up();
	void Down();
	void Left();
	void Right();
	void Forward();
	void Backward();

private:
	glm::vec3 cameraPosition;
	glm::vec2 cameraRotation;
	float cameraxRotRad;
	float camerayRotRad;

};

#endif