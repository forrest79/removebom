#include "removebom.h"

using namespace std;

/** Path to process. */
string path;

/** Files with extension. */
string extension;

/** Test files only. */
bool test;

/** Make backup. */
bool backup;

/** List all files and directories. */
bool listAll;

/**
 * Main function, setup.
 * @param argc number of command line arguments
 * @param argv array of command line arguments
 * @return return code
 */
int main(int argc, char *argv[])
{
	// Initialize
	path.assign("");
	extension.assign("*");
	test = false;
	backup = false;
	listAll = false;

	// Read command line arguments
	if (argc < 2) {
		printHelp(argv[0]);
		return 0;
	} else {
		for (int i = 1; i < argc; i++) {
			string arg(argv[i]);
			if ((arg.compare("-t") == 0) || (arg.compare("--test") == 0)) {
				test = true;
			} else if ((arg.compare("-b") == 0) || (arg.compare("--backup") == 0)) {
				backup = true;
			} else if ((arg.compare("-a") == 0) || (arg.compare("--all") == 0)) {
				listAll = true;
			} else if (((arg.compare("-e") == 0) || (arg.compare("--extension") == 0)) && (argc > i)) {
				extension.assign(argv[i + 1]);
				i++;
			} else if ((arg[0] != '-') && path.empty()) {
				path.assign(argv[i]);
			} else {
				printf("error: unknown option `%s`\n", arg.c_str());
			}
		}
	}

	// Path must be specified...
	if (path.empty()) {
		printf("error: must specify path\n");
		printHelp(argv[0]);
		return 0;
	}

	// Remove trailing slash...
	if (path.at(path.length() - 1) == '\\' || path.at(path.length() - 1) == '/') {
		path.resize(path.length() - 1);
	}

	// Add . prefix to extension...
	if (extension.at(0) != '.') {
		extension.assign(string(".") . append(extension));
	}

	// Process...
	processPath(path.c_str());

	return 0;
}

/**
 * Process path.
 * @param path absolute path
 */
void processPath(const char *path)
{
	struct stat s;
	if (stat(path, &s) == 0) {
		if(s.st_mode & S_IFREG) { // File
			string extensionPath(path);
			if (extension.empty() || (extensionPath.substr(extensionPath.length() - extension.length(), extension.length()).compare(extension) == 0)) {
				removeBOM(path);
			}
		} else if(s.st_mode & S_IFDIR) { // Directory
			if (listAll) {
				printf("%s [DIR]\n", path);
			}

			DIR *dir;
			struct dirent *ent;
			dir = opendir(path);
			if (dir != NULL) {
				while ((ent = readdir(dir)) != NULL) {
					string dirPath(ent->d_name);
					if ((dirPath == ".") || (dirPath == "..")) {
						continue;
					}
					
					string fullPath(path);
					fullPath.append(DIRECTORY_SEPARATOR).append(dirPath);
					processPath(fullPath.c_str());
				}
				closedir (dir);
			} else {
				printf("%s [ERROR]\n", path);
			}
		} else { // Something else
			printf("%s [ERROR]\n", path);
		}
	} else { // Error
		printf("%s [ERROR]\n", path);
	}
}

/**
 * Remove BOM header from file.
 * @param file absolute path to file
 */
void removeBOM(const char *file)
{
	ifstream fileReader(file, ios::binary);
	if (fileReader.is_open()) {
		char headerBOM[3];
		fileReader.read(headerBOM, sizeof(headerBOM));

		if ((fileReader.gcount() == 3) && ((headerBOM[0] + 256) == 239) && ((headerBOM[1] + 256) == 187) && ((headerBOM[2] + 256) == 191)) {
			if (test) {
				printf("%s [INCLUDE BOM]\n", file);
				fileReader.close();
				return;
			} else {
				string fileRemovedBOM = findFreeFilename(file, "removedbom");
				ofstream fileWriter(fileRemovedBOM.c_str(), ofstream::binary);
				if (fileWriter.is_open()) {
					char buffer[1024];
					do {
						fileReader.read(buffer, sizeof(buffer));
						fileWriter.write(buffer, fileReader.gcount());
					} while(!fileReader.eof());

					fileWriter.close();
					fileReader.close();

					if (backup) {
						if (rename(file, findFreeFilename(file, "removebom.bak").c_str()) != 0) {
							printf("%s [ERROR]\n", file);
							return;
						}
					} else {
						if (remove(file) != 0) {
							printf("%s [ERROR]\n", file);
							return;
						}
					}

					if (rename(fileRemovedBOM.c_str(), file) != 0) {
						printf("%s [ERROR]\n", file);
						return;
					}
	
					printf("%s [REMOVE BOM]\n", file);
				} else {
					printf("%s [ERROR]\n", file);
				}
			}
		} else if (listAll) {
			printf("%s [NO BOM]\n", file);
		}
	} else {
		printf("%s [ERROR]\n", file);
	}
}

/**
 * Find free filename on disk.
 * @param file absolute file path
 * @param extension extension to file
 * @return unique file path
 */
string findFreeFilename(const char *file, const char *extension)
{
    string backupFile(file);
	backupFile.append(".").append(extension);

	ifstream testFile(backupFile.c_str());
	if (testFile.good()) {
        int i = 1;
        do
        {
			stringstream strI;
			strI << i;
			backupFile.assign(file).append(".").append(strI.str()).append(".").append(extension);
			testFile.open(backupFile.c_str());
            i++;
		} while (testFile.good());
	}

    return backupFile;
}

/**
 * Print help to console.
 * @param file to execute
 */
void printHelp(char *executable)
{
	string extension(executable);
	int point = extension.find_last_of(".");
	if (point > 0) {
		extension.resize(point);
	}

	printf("RemoveBOM v%s - remove BOM header from file\n", VERSION);
	printf("usage: %s [--test|-t] [--backup|-b] [--all|-a] [--extension|-e <extension>] <path>\n\n", extension.c_str());
	printf("  <path>                   path to file or dir to process\n");
	printf("  --test                   test only for BOM header\n");
	printf("  --backup                 backup file before remove BOM header\n");
	printf("  --all                    list all files (defaul is only files with BOM header)\n");
	printf("  --extension <extension>  process only files with <extension> (default is `*` = all files)\n");
}