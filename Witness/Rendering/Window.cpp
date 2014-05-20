#include "Window.hpp"

static Window* windowInstance = 0;

Window::Window() : currentScene(0), inputHandle(0), glRunning(false), glWindow(0), glWindowWidth(200), glWindowHeight(200) {
}

bool Window::Show() {
	glfwSetErrorCallback(ErrorCallback);

	// Create input handle, init first so we dont get null pointer should the key callback trigger
	inputHandle = new Input();

	// Initalize the glut for windows library
	if (!glfwInit()) {
		fprintf(stderr, "Error: %s\n", "GLUT For Windows initalization failed.");
		return false;
	}

	// Create the window context and initalize the window.
	CreateRenderWindow();

	// Set our callbacks for errors, windows sizing and input.
	SetCallbacks();

	// Show the window to the user.
	ShowWindow();
	
	// Initalize GL extension wrangler library
	GLenum err = glewInit();
	if (err != GLEW_OK) {
		fprintf(stderr, "Error: %s\n", glewGetErrorString(err));
		return false;
	}

	//Set this instance as the main instance
	windowInstance = this;

	return true;
}

void Window::Close() {
	glfwDestroyWindow(glWindow);
	glRunning = false;
}

void Window::Update() {
	if (glRunning) {

		glClear(GL_COLOR_BUFFER_BIT | GL_DEPTH_BUFFER_BIT);
		glLoadIdentity();

		if (!currentScene->isReady()) {
			currentScene->Init(glWindow);
		}

		if (currentScene != 0) {
			currentScene->Draw();
		}

		glfwSwapBuffers(glWindow);

		if (glfwWindowShouldClose(glWindow)) {
			glRunning = false;
		}

		glfwPollEvents();
		UpdateJoystick();
	}
}

void Window::UpdateJoystick() {
	for (int i = 0;  i < sizeof(joysticks) / sizeof(Joystick);  i++) {
		Joystick* j = joysticks + i;
		if (glfwJoystickPresent(GLFW_JOYSTICK_1 + i)) {

            const float* axes;
            const unsigned char* buttons;
            int axis_count, button_count;
            free(j->name);
            j->name = strdup(glfwGetJoystickName(GLFW_JOYSTICK_1 + i));
            axes = glfwGetJoystickAxes(GLFW_JOYSTICK_1 + i, &axis_count);

            if (axis_count != j->axis_count) {
                j->axis_count = axis_count;
                j->axes = (float*)realloc(j->axes, j->axis_count * sizeof(float));
            }

            memcpy(j->axes, axes, axis_count * sizeof(float));

            buttons = glfwGetJoystickButtons(GLFW_JOYSTICK_1 + i, &button_count);
            if (button_count != j->button_count) {
                j->button_count = button_count;
                j->buttons = (unsigned char*)realloc(j->buttons, j->button_count);
            }

            memcpy(j->buttons, buttons, button_count * sizeof(unsigned char));

            if (!j->present) {
                printf("Found joystick %i named \'%s\' with %i axes, %i buttons\n",
                       i + 1, j->name, j->axis_count, j->button_count);

                joystick_count++;
            }

            j->present = GL_TRUE;
        }
	}

	for (int i = 0;  i < sizeof(joysticks) / sizeof(Joystick);  i++) {
        Joystick* j = joysticks + i;

        if (j->present) {
            if (j->axis_count) {
				float value = j->axes[i] / 2.f + 0.5f;
				if (value <0.01) {
					inputHandle->JoyLeft = true;
				} else if (value > 0.9) {
					inputHandle->JoyRight = true;
				} else {
					inputHandle->JoyLeft = false;
					inputHandle->JoyRight = false;
				}
			}
        }
    }
}

void Window::CreateRenderWindow() {
	glfwWindowHint(GLFW_VISIBLE, GL_FALSE);
	glfwWindowHint(GLFW_DEPTH_BITS, 16);
	glWindow = glfwCreateWindow(200, 200, "Position Visualisation", NULL, NULL);
	glfwMakeContextCurrent(glWindow);
}

void Window::ShowWindow() {
	glfwShowWindow(glWindow);
	glRunning = true;
	glClearColor(0.1f, 0.1f, 0.1f, 0.0f);
}

void Window::SetCallbacks() {
	glfwSetKeyCallback(glWindow, KeyCallback);
	glfwSetWindowSizeCallback(glWindow, WindowSizeCallback);
	glfwSetCursorPosCallback(glWindow, MouseMoveCallback);
}

void Window::ErrorCallback(int error, const char* description) {
}

void Window::KeyCallback(GLFWwindow* window, int key, int scancode, int action, int mods) {
    if (key == GLFW_KEY_ESCAPE && action == GLFW_PRESS)
        glfwSetWindowShouldClose(window, GL_TRUE);

	if (action == GLFW_PRESS) {
		windowInstance->inputHandle->Keys[key] = PRESSED;
	} else if (action == GLFW_REPEAT) {
		windowInstance->inputHandle->Keys[key] = HELD;
	} else if (action == GLFW_RELEASE) {
		windowInstance->inputHandle->Keys[key] = RELEASED;
	}
}

void Window::WindowSizeCallback(GLFWwindow* window, int width, int height) {
	float aspectRatio = width / height;
	glViewport(0, 0, width, height);
	glMatrixMode(GL_PROJECTION);
	glLoadIdentity();
	gluPerspective(60, aspectRatio, 1.0, 1000.0);
	glClear(GL_COLOR_BUFFER_BIT);
	glMatrixMode (GL_MODELVIEW);
	windowInstance->glWindowWidth = width;
	windowInstance->glWindowHeight = height;
}

void Window::MouseMoveCallback(GLFWwindow* window, double x, double y) {
	windowInstance->inputHandle->MouseX = x - (windowInstance->glWindowHeight/2);
	windowInstance->inputHandle->MouseY = y - (windowInstance->glWindowWidth/2);
	glfwSetCursorPos(windowInstance->glWindow, windowInstance->glWindowHeight/2, windowInstance->glWindowWidth/2);
}

GLboolean Window::isRunning() {
	return glRunning;
}

Window::~Window() {
}