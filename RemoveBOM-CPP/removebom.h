#ifndef H_REMOVEBOM
#define H_REMOVEBOM

#include <fstream>
#include <sstream>

#ifndef WIN32
#include <sys/stat.h>
#endif

#ifdef WIN32
#include "dirent.h"
#else
#include <dirent.h>
#endif

#define VERSION "1.0.0"

#ifdef WIN32
#define DIRECTORY_SEPARATOR "\\"
#else
#define DIRECTORY_SEPARATOR "/"
#endif

void processPath(const char *path);

void removeBOM(const char *file);

std::string findFreeFilename(const char *file, const char *extension);

void printHelp(char *executable);

#endif
