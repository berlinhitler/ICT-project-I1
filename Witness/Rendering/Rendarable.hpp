#pragma once

#ifndef _RENDERABLE_HPP_
#define _RENDERABLE_HPP_

/*
===============================================================================

	Rendarable - An object that can be drawn to a render capable window
	Author - Joshua Richardson

===============================================================================
*/

#include "glm\vec2.hpp"
#include "glm\vec3.hpp"

class Renderable {

public:
	virtual void Draw() = 0;
	virtual void SetRealPosition(glm::vec3 position) = 0;
	virtual void SetWorldPosition(glm::vec2 position) = 0;

public:
	virtual glm::vec3 GetRealPosition() = 0;
	virtual glm::vec2 GetWorldPosition() = 0;

};

#endif