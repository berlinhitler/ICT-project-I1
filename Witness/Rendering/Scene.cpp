#include "Scene.hpp"

Scene::Scene() : objectList(), targetWindow(0), targetCamera(0), width(0), height(0), ready(false) {
}

void Scene::Init(GLFWwindow* targetWindow) {
	glEnable(GL_DEPTH_TEST);
	targetCamera = new Camera();
	ready = true;
}

void Scene::Draw() {
	std::list<Renderable*>::iterator it;

	glEnable(GL_DEPTH_TEST);
	glMatrixMode(GL_MODELVIEW);
	glLoadIdentity();
	targetCamera->Update();
	for (it = objectList.begin(); it != objectList.end(); ++it) {
		glPushMatrix();
			(*it)->Draw();
		glPopMatrix();
	}
	
}

Scene::~Scene() {
}