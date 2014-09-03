#include "exports.h"
#include "console.h"

#include <Windows.h>

void __stdcall ProcessImage(unsigned char* imageStream, int imageStreamSize) {

	RedirectIOToConsole();

	printf("Image passed to unmanaged space with size of %d\n", imageStreamSize);

	if (imageStream[0] == 'B' && imageStream[1] == 'M') {

		// Dont increment the main pointer, make a copy for reading in the header.
		unsigned char* headerLocation = imageStream;

		// Read the bitmap file header, give's the data offset.
		BITMAPFILEHEADER* imageHeader  = (BITMAPFILEHEADER*)headerLocation;
		headerLocation += sizeof(BITMAPFILEHEADER);

		// Read the info header, gives width and height and bit count per pixle
		BITMAPINFOHEADER* imageInfo = (BITMAPINFOHEADER*)headerLocation;
		printf("Image Width %d | Height %d\n", imageInfo->biWidth, imageInfo->biHeight);

		// Do something with the bytes, each pixle is 4 bytes. format is BGRA
		unsigned char* bitmapBytes = imageStream + imageHeader->bfOffBits;
		unsigned int byteCount = imageHeader->bfSize - imageHeader->bfOffBits;
		for (unsigned int i = 0; i < byteCount; i+=4) {
			bitmapBytes[i] = 255;
			bitmapBytes[i+1] = 0;
			bitmapBytes[i+2] = 0;
			bitmapBytes[i+3] = 0;
		}

	} else {
		printf("Invalid Bitmap File\n");
	}
}

