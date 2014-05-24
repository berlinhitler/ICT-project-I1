#include "StreamPGR.hpp"

StreamPGR::StreamPGR() : StreamReady(false) {
}

StreamPGR::StreamPGR(const char* filename) : StreamReady(false) {
	if (!LoadFile(filename)) {
		StreamReady = false;
	} else {
		StreamReady = true;
	}
}

bool StreamPGR::LoadFile(const char* filename) {
	LadybugError error;

	error = ladybugCreateStreamContext( &ReadContext );

	if (error != LADYBUG_OK) {
		printf("Ladybug Error: %s\n", ladybugErrorToString( error ) );
		return false;
	}

	error = ladybugInitializeStreamForReading( ReadContext, filename, true );

	if (error != LADYBUG_OK) {
		printf("Ladybug Error: %s\n", ladybugErrorToString( error ) );
		return false;
	}

	error = ladybugGetStreamHeader( ReadContext, &StreamHeaderInfo );

	if (error != LADYBUG_OK) {
		printf("Ladybug Error: %s\n", ladybugErrorToString( error ) );
		return false;
	}

    const float frameRateToUse = StreamHeaderInfo.ulLadybugStreamVersion < 7 ? (float)StreamHeaderInfo.ulFrameRate : StreamHeaderInfo.frameRate;

    printf( "--- Stream Information ---\n");
    printf( "Stream version : %d\n", StreamHeaderInfo.ulLadybugStreamVersion);
    printf( "Base S/N: %d\n", StreamHeaderInfo.serialBase);
    printf( "Head S/N: %d\n", StreamHeaderInfo.serialHead);
    printf( "Frame rate : %3.2f\n", frameRateToUse);
    printf( "--------------------------\n");

	return false;
}

void StreamPGR::Destroy() {
}

StreamPGR::~StreamPGR() {
}
