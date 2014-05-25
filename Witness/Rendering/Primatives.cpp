#include "Primatives.hpp"

#include <math.h>
#include <GL/glew.h>
#include <GLFW/glfw3.h>

//                |             X       Y     Z
#define CUBE_TL(X) glVertex3f(-1.f,    1.0f , X)
#define CUBE_TR(X) glVertex3f( 1.0f,   1.0f , X)
#define CUBE_BR(X) glVertex3f( 1.0f,  -1.0f,  X)
#define CUBE_BL(X) glVertex3f(-1.0f,  -1.0f,  X)

Cube::Cube() {
}

void Cube::Draw() {
	
	glScalef(scale.x, scale.y, scale.z);
	glTranslatef(position.x, position.y, position.z);
	
	#pragma region Draw Calls

    glBegin(GL_TRIANGLES);
		// Front
		glColor3f(1.f, 0.f, 0.f); // Red
			CUBE_TL(1.f);
			CUBE_TR(1.f);
			CUBE_BL(1.f);
			CUBE_TR(1.f);
			CUBE_BR(1.f);
			CUBE_BL(1.f);

		// Back
		glColor3f(0.f, 1.f, 0.f); // Green
			CUBE_TL(-0.5f);
			CUBE_BL(-0.5f);
			CUBE_BR(-0.5f);
			CUBE_TL(-0.5f);
			CUBE_BR(-0.5f);
			CUBE_TR(-0.5f);

		// Left
		glColor3f(0.f, 0.f, 1.f); // Blue
			CUBE_TL(1.f);
			CUBE_BL(1.f);
			CUBE_BL(-0.5f);
			CUBE_TL(1.f);
			CUBE_BL(-0.5f);
			CUBE_TL(-0.5f);

		// Right
		glColor3f(1.f, 1.f, 0.f); // Yellow
			CUBE_TR(1.f);
			CUBE_BR(-0.5f);
			CUBE_BR(1.f);
			CUBE_TR(1.f);
			CUBE_TR(-0.5f);
			CUBE_BR(-0.5f);

		// Top
		glColor3f(1.f, 1.f, 1.f); // White
			CUBE_TR(1.f);
			CUBE_TL(1.f);
			CUBE_TL(-0.5f);
			CUBE_TL(-0.5f);
			CUBE_TR(-0.5f);
			CUBE_TR(1.0f);

		// Bottom
		glColor3f(1.f, 0.f, 1.f); // Pink
			CUBE_BL(-0.5f);
			CUBE_BL(1.f);
			CUBE_BR(1.f);
			CUBE_BR(1.0f);
			CUBE_BR(-0.5f);
			CUBE_BL(-0.5f);
    glEnd();
	#pragma endregion Drawing Code For Cube
}

void Cube::SetRealPosition(glm::vec3 position) {
	this->position = position;
}

void Cube::SetWorldPosition(glm::vec2 position) {
}

void Cube::Scale(glm::vec3 scale) {
	this->scale = scale;
}

void Cube::Translate(glm::vec3 translateVector) {
	position += translateVector;
	if (position.x >= 1.0f) {
		position.x = 1.0f;
	}

	if (position.z >= 110.0f) {
		position.z = 1.0f;
	}
}

Cube::~Cube() {
}

GridLines::GridLines() {
}

void GridLines::Draw() {

	glColor3f(.3,.3,.3);
	glPushMatrix();
	glTranslatef(-50.0f, 0, -50.0f);
	glBegin(GL_LINES);

	for(int i=0;i<=100;i++) {

		if (i==0) { 
			glColor3f(.6,.3,.3); 
		} else { 
			glColor3f(.25,.25,.25); 
		};

		glVertex3f(i,0,0);
		glVertex3f(i,0,100);

		if (i==0) { 
			glColor3f(.3,.3,.6); 
		} else { 
			glColor3f(.25,.25,.25); 
		};

		glVertex3f(0,0,i);
		glVertex3f(100,0,i);
	};
	glPopMatrix();
	glEnd();
}

void GridLines::SetRealPosition(glm::vec3 position) {
}

void GridLines::SetWorldPosition(glm::vec2 position) {
}

void GridLines::Scale(glm::vec3 scale) {
}

GridLines::~GridLines() {
}