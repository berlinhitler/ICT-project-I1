#pragma once

extern "C" __declspec( dllexport ) void Initalize();
extern "C" __declspec( dllexport ) void PollAdapter();
extern "C" __declspec( dllexport ) int __stdcall GetRSSI(const char* AccessPointName);