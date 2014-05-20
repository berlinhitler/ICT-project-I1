#include "Camera.hpp"

#include <GLFW/glfw3.h>
#include <math.h>

Camera::Camera() : cameraPosition(), cameraRotation(), cameraxRotRad(0), camerayRotRad(0) {
}

void Camera::Update() {
	glRotatef(cameraRotation.x, 1.0f, 0.0f, 0.0f);
	glRotatef(cameraRotation.y/2, 0.0f, 1.0f, 0.0f);
	glTranslated(-cameraPosition.x/64, -cameraPosition.y/64, -cameraPosition.z/64);
}

void Camera::Up() {
	cameraRotation.x += 0.8f;
}

void Camera::Down() {
	cameraRotation.x -= 0.8f;
}

void Camera::Left() {
	cameraRotation.y += 0.8f;
	//if (cameraRotation.x >360) {
	//	cameraRotation.x -= 360;
	//}
}

void Camera::Right() {
	cameraRotation.y -= 0.8f;
	//if (cameraRotation.y >360) {
	//	cameraRotation.y -= 360;
	//}
}

void Camera::Forward() {
	float xrotrad, yrotrad;
	yrotrad = (cameraRotation.y / 180 * 3.141592654f);
	xrotrad = (cameraRotation.x / 180 * 3.141592654f); 
	cameraPosition.x += float(sin(yrotrad));
	cameraPosition.z -= float(cos(yrotrad));
	cameraPosition.y -= float(sin(xrotrad));
}

void Camera::Backward() {
	float xrotrad, yrotrad;
	yrotrad = (cameraRotation.y / 180 * 3.141592654f);
	xrotrad = (cameraRotation.x / 180 * 3.141592654f); 
	cameraPosition.x -= float(sin(yrotrad));
	cameraPosition.z += float(cos(yrotrad));
	cameraPosition.y += float(sin(xrotrad));
}

Camera::~Camera() {
}

