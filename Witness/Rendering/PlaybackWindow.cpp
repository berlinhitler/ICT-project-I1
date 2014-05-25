#include "PlaybackWindow.hpp"

// WinProc work around
std::map<HWND, PlaybackWindow*> WndProcMappings;
LRESULT CALLBACK MainWndProc(HWND hwnd, UINT uMsg, WPARAM wParam, LPARAM lParam) { if (WndProcMappings[hwnd]) { WndProcMappings[hwnd]->Event(uMsg, wParam, lParam); } return DefWindowProc(hwnd, uMsg, wParam, lParam); }

/*
==================
PlaybackWindow::PlaybackWindow()
==================
*/
PlaybackWindow::PlaybackWindow() : windowInstances(), windowMessages() {
	ZeroMemory(&windowInstances.wiwndClass, sizeof(windowInstances.wiwndClass));
}

/*
==================
bool PlaybackWindow::Create()
	Call all the necessary items to create the window
	and register all the needed classes / instances.
==================
*/
bool PlaybackWindow::Initalize() {
	if (!Register()) {
		return false;
	}
	if (!Create()) {
		return false;
	}
	if (!Show()) {
		return false;
	}
	return true;
}

/*
==================
void PlaybackWindow::Update()
	Update the window with the recieved messages.
==================
*/
void PlaybackWindow::Update() {
	if (PeekMessage(&windowInstances.wimsg, windowInstances.wihWnd, 0, 0, PM_REMOVE)) {
		TranslateMessage(&windowInstances.wimsg);
		DispatchMessage(&windowInstances.wimsg);
	}
}

/*
==================
void PlaybackWindow::Event(UINT uMsg, WPARAM wParam, LPARAM lParam)
	Callback for the window message processor.
==================
*/
void PlaybackWindow::Event(UINT uMsg, WPARAM wParam, LPARAM lParam) {
	WindowMessage message = {
		uMsg,
		wParam,
		lParam
	};
	windowMessages.push_back(message);
}

/*
==================
void PlaybackWindow::Destroy()
	Close the window and de-register everything.
==================
*/
void PlaybackWindow::Destroy() {
}

/*
==================
bool PlaybackWindow::Register()
	Register the window class with windows.
==================
*/
bool PlaybackWindow::Register() {
	windowInstances.wiwndClass.style = CS_HREDRAW | CS_VREDRAW;
    windowInstances.wiwndClass.lpfnWndProc = MainWndProc; 
    windowInstances.wiwndClass.cbClsExtra = 0; 
    windowInstances.wiwndClass.cbWndExtra = 0; 
	windowInstances.wiwndClass.hInstance = windowInstances.wihInstance; 
    windowInstances.wiwndClass.hIcon = LoadIcon(NULL, IDI_APPLICATION); 
    windowInstances.wiwndClass.hCursor = LoadCursor(NULL, IDC_ARROW); 
    windowInstances.wiwndClass.lpszClassName = L"TetraDefaultClass";

    if (!RegisterClass(&windowInstances.wiwndClass)) {
       return false;
	}
	return true;
}

/*
==================
bool PlaybackWindow::Create()
	call CreateWindow/EX
==================
*/
bool PlaybackWindow::Create() {
	windowInstances.wihWnd = CreateWindow(L"TetraDefaultClass", L"DefaultWindowName", 
        WS_OVERLAPPEDWINDOW, CW_USEDEFAULT, CW_USEDEFAULT, 
		CW_USEDEFAULT, CW_USEDEFAULT, NULL, NULL, windowInstances.wihInstance, 
        NULL);
	if (!windowInstances.wihWnd) {
		return false;
	}
	return true;
}

/*
==================
bool PlaybackWindow::Show()
	Call show window with its current state.
==================
*/
bool PlaybackWindow::Show() {
	ShowWindow(windowInstances.wihWnd, SW_SHOW);
	UpdateWindow(windowInstances.wihWnd);
	windowInstances.wihdc = GetDC(windowInstances.wihWnd);
	WndProcMappings[windowInstances.wihWnd] = this;
	return true;
}

/*
==================
PlaybackWindow::~PlaybackWindow()
==================
*/
PlaybackWindow::~PlaybackWindow() {
}