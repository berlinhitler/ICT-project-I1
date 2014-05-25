#pragma once

#ifndef _PRIMATIVES_HPP_
#define _PRIMATIVES_HPP_

/*
===============================================================================

	Primatives - A collection of classes that draw the basic shapes
	Author - Joshua Richardson

===============================================================================
*/

#include "Rendarable.hpp"

class Cube : public Renderable {
	
public:
	Cube();
	~Cube();

public:
	void Draw();
	void SetRealPosition(glm::vec3 position);
	void SetWorldPosition(glm::vec2 position);
	void Scale(glm::vec3 scale);

public:
	glm::vec3 GetRealPosition() { return position; }
	glm::vec2 GetWorldPosition() { return glm::vec2(); };

public:
	void Translate(glm::vec3 translateVector);

private:
	glm::vec3 position;
	glm::vec3 scale;
};

class GridLines : public Renderable {

public:
	GridLines();
	~GridLines();

public:
	void Draw();
	void SetRealPosition(glm::vec3 position);
	void SetWorldPosition(glm::vec2 position);
	void Scale(glm::vec3 scale);

public:
	glm::vec3 GetRealPosition() { return position; }
	glm::vec2 GetWorldPosition() { return glm::vec2(); };

public:
	void Translate(glm::vec3 translateVector) {}

private:
	glm::vec3 position;
	glm::vec3 scale;

};

#endif