#pragma once

#include <stdio.h>

#include <ladybugstream.h>

class StreamPGR {

public:
	StreamPGR();
	StreamPGR(const char* filename);
	~StreamPGR();

public:
	bool LoadFile(const char* filename);
	void Destroy();

private:
	LadybugStreamContext ReadContext;
	LadybugStreamHeadInfo StreamHeaderInfo;

private:
	bool StreamReady;

};