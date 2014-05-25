#pragma once

// Used for mapping HWND's to window instances.
#include <Windows.h>
#include <map>
#include <vector>

// Internal window handles
struct WindowInstance {
	WNDCLASS	wiwndClass;
	HWND		wihWnd;
	HINSTANCE	wihInstance;
	MSG			wimsg;
	HDC			wihdc;
};

// Structure used for holding messages in a syncronous manner
struct WindowMessage {
	unsigned int wmMessage;
	WPARAM wmwParam;
	LPARAM wmlParam;
};

class PlaybackWindow {

public:
	PlaybackWindow();
	~PlaybackWindow();

public:
	virtual bool Initalize();
	virtual void Update();
	virtual void Destroy();

public:
	void Event(UINT uMsg, WPARAM wParam, LPARAM lParam);

private:
	bool Register();
	bool Create();
	bool Show();

protected:
	WindowInstance windowInstances;
	std::vector<WindowMessage> windowMessages;

};