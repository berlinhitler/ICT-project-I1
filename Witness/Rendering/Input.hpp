#pragma once

#ifndef _INPUT_HPP_
#define _INPUT_HPP_

/*
===============================================================================

	Input - Stores the current key states
	Author - Joshua Richardson

===============================================================================
*/


enum KEY_STATES {
	IDLE,
	PRESSED,
	HELD,
	RELEASED,
};

class Input {

public:
	Input();
	~Input();

public:
	void Update();

public:
	KEY_STATES Keys[1024];
	double MouseX;
	double MouseY;
	bool JoyLeft;
	bool JoyRight;

};

#endif