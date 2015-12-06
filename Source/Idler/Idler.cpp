#include <Windows.h>
#include "steam_api.h"

int main() {
	if (SteamAPI_Init()) {
		Sleep(INFINITE);
	}
    return 0;
}
