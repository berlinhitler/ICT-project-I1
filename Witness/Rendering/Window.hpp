#pragma once

#ifndef _Window_HPP_
#define _Window_HPP_

/*
===============================================================================

	Window - Render target for visualisation of objects
	Author - Joshua Richardson

===============================================================================
*/

#include "Scene.hpp"
#include "Input.hpp"
#include <GL/glew.h>
#include <GLFW/glfw3.h>

typedef struct Joystick
{
    GLboolean present;
    char* name;
    float* axes;
    unsigned char* buttons;
    int axis_count;
    int button_count;
} Joystick;

static Joystick joysticks[GLFW_JOYSTICK_LAST - GLFW_JOYSTICK_1 + 1];
static int joystick_count = 0;

class Window {

public:
	Window();
	~Window();

public:
	bool Show();
	void Close();
	void Update();
	void UpdateJoystick();

private:
	void CreateRenderWindow();
	void ShowWindow();
	void SetCallbacks();

private:
	static void ErrorCallback(int error, const char* description);
	static void KeyCallback(GLFWwindow* window, int key, int scancode, int action, int mods);
	static void WindowSizeCallback(GLFWwindow* window, int width, int height);
	static void MouseMoveCallback(GLFWwindow* window, double x, double y);

public:
	Scene* currentScene;
	Input* inputHandle;

public:
	GLboolean isRunning();

private:
	GLboolean glRunning;
	GLFWwindow* glWindow;
	GLint glWindowWidth;
	GLint glWindowHeight;

};

#endif