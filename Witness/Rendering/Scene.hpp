#pragma once

#ifndef _SCENE_HPP_
#define _SCENE_HPP_

/*
===============================================================================

	Scene - An object with a list of objects that can be drawn
	Author - Joshua Richardson

===============================================================================
*/

#define GLFW_INCLUDE_GLU
#include "Rendarable.hpp"
#include "Camera.hpp"
#include <list>
#include <GL/glew.h>
#include <GLFW/glfw3.h>

class Scene {

public:
	Scene();
	~Scene();

public:
	void Init(GLFWwindow* targetWindow);
	bool isReady() { return ready; }
	void Draw();

public:
	Renderable* Insert(Renderable* object) {
		objectList.push_back(object);
		return object;
	}

	Renderable* Remove(Renderable* object) {
		objectList.remove(object);
		return object;

	}

	void Clear() {
		objectList.clear();
	}

public:
	Camera* targetCamera;

private:
	std::list<Renderable*> objectList;
	GLFWwindow* targetWindow;
	int width;
	int height;
	bool ready;

};

#endif