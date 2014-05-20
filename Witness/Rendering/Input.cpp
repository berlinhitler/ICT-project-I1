#include "Input.hpp"

Input::Input() : MouseX(0), MouseY(0), JoyLeft(false), JoyRight(false) {
	for (unsigned int i = 0; i < 1024; i++) {
		Keys[i] = IDLE;
	}
}

void Input::Update() {
}

Input::~Input() {
}